using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using TCSA.V2026.Data;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Services;

namespace TCSA.V2026.UnitTests.Services;

public class GameServiceTests
{
    [Test]
    public async Task DatabaseGameTracksRoundsAcrossPlayers()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        await using (var seedContext = new ApplicationDbContext(options))
        {
            seedContext.Games.Add(new Game
            {
                Slug = "new-game",
                Title = "New Game",
                Description = "Added through the database",
                Url = "https://example.com/new-game"
            });
            await seedContext.SaveChangesAsync();
        }

        var factory = new Mock<IDbContextFactory<ApplicationDbContext>>();
        factory.Setup(contextFactory => contextFactory.CreateDbContextAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(() => new ApplicationDbContext(options));
        var playService = CreateService(factory, new ClaimsPrincipal(new ClaimsIdentity()));

        foreach (var userId in new[] { "first-player", "second-player", "first-player" })
        {
            var playResult = await playService.RecordPlay("new-game");
            Assert.That(playResult.IsSuccess, Is.True);
            var user = new ClaimsPrincipal(new ClaimsIdentity(
                [new Claim(ClaimTypes.NameIdentifier, userId)], "Test"));
            var result = await CreateService(factory, user).SaveBestScore("new-game", 10);
            Assert.That(result.IsSuccess, Is.True);
        }

        var catalogService = CreateService(factory, new ClaimsPrincipal(new ClaimsIdentity()));
        var anonymousPlay = await catalogService.RecordPlay("new-game");
        var anonymousScore = await CreateService(factory, new ClaimsPrincipal(new ClaimsIdentity()))
            .SaveBestScore("new-game", 10);
        var firstPlayer = new ClaimsPrincipal(new ClaimsIdentity(
            [new Claim(ClaimTypes.NameIdentifier, "first-player")], "Test"));
        var retriedScore = await CreateService(factory, firstPlayer).SaveBestScore("new-game", 10);
        var catalog = await catalogService.GetGames();
        var game = await catalogService.GetGame("new-game");
        var missingGame = await catalogService.GetGame("missing-game");
        await using var context = new ApplicationDbContext(options);

        Assert.Multiple(() =>
        {
            Assert.That(anonymousPlay.IsSuccess, Is.True);
            Assert.That(anonymousScore.Reason.Code, Is.EqualTo("GameScore.Unauthorized"));
            Assert.That(retriedScore.IsSuccess, Is.True);
            Assert.That(context.Games.Single().TimesPlayed, Is.EqualTo(4));
            Assert.That(context.GameScores.Count(), Is.EqualTo(2));
            Assert.That(catalog.Value.Select(item => item.Slug), Is.EqualTo(new[] { "new-game" }));
            Assert.That(game.Value.Title, Is.EqualTo("New Game"));
            Assert.That(missingGame.Reason.Code, Is.EqualTo("Game.NotFound"));
        });
    }

    [Test]
    public async Task UnknownGameCannotCreateScoreOrIncrementCounter()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        var factory = new Mock<IDbContextFactory<ApplicationDbContext>>();
        factory.Setup(contextFactory => contextFactory.CreateDbContextAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(() => new ApplicationDbContext(options));
        var user = new ClaimsPrincipal(new ClaimsIdentity(
            [new Claim(ClaimTypes.NameIdentifier, "academy-user")], "Test"));
        var service = CreateService(factory, user);

        var result = await service.SaveBestScore("unknown-game", 10);
        var leaderboard = await service.GetLeaderboard("unknown-game", 1);
        var playResult = await CreateService(factory, new ClaimsPrincipal(new ClaimsIdentity()))
            .RecordPlay("unknown-game");
        await using var context = new ApplicationDbContext(options);

        Assert.Multiple(() =>
        {
            Assert.That(result.Reason.Code, Is.EqualTo("GameScore.Invalid"));
            Assert.That(playResult.Reason.Code, Is.EqualTo("Game.NotFound"));
            Assert.That(leaderboard.Reason.Code, Is.EqualTo("GameScore.InvalidGame"));
            Assert.That(context.GameScores.Count(), Is.Zero);
            Assert.That(context.Games.Count(), Is.Zero);
        });
    }

    [Test]
    public async Task EveryRoundIncrementsTimesPlayedWhilePreservingBestScore()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        await using (var seedContext = new ApplicationDbContext(options))
        {
            seedContext.Games.Add(new Game
            {
                Slug = "button-challenge",
                Title = "Button Challenge",
                Description = "Test game",
                Url = "https://example.com/game"
            });
            await seedContext.SaveChangesAsync();
        }

        var factory = new Mock<IDbContextFactory<ApplicationDbContext>>();
        factory.Setup(contextFactory => contextFactory.CreateDbContextAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(() => new ApplicationDbContext(options));
        var user = new ClaimsPrincipal(new ClaimsIdentity(
            [new Claim(ClaimTypes.NameIdentifier, "academy-user")], "Test"));
        var service = CreateService(factory, user);
        var playService = CreateService(factory, new ClaimsPrincipal(new ClaimsIdentity()));

        foreach (var score in new[] { 10, 5, 10, 20, 0 })
        {
            var playResult = await playService.RecordPlay("button-challenge");
            Assert.That(playResult.IsSuccess, Is.True);
            var result = await service.SaveBestScore("button-challenge", score);
            Assert.That(result.IsSuccess, Is.True);
        }

        await using var context = new ApplicationDbContext(options);
        var savedScore = await context.GameScores.SingleAsync();

        Assert.Multiple(() =>
        {
            Assert.That(context.Games.Single().TimesPlayed, Is.EqualTo(5));
            Assert.That(savedScore.BestScore, Is.EqualTo(20));
        });
    }

    [Test]
    public async Task ExistingScoreStartsTrackingFromZero()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        var achievedAt = DateTimeOffset.UtcNow.AddDays(-1);

        await using (var context = new ApplicationDbContext(options))
        {
            context.GameScores.Add(new GameScore
            {
                GameId = "button-challenge",
                UserId = "academy-user",
                BestScore = 100,
                BestScoreAchievedAt = achievedAt
            });
            await context.SaveChangesAsync();
        }

        await using (var seedContext = new ApplicationDbContext(options))
        {
            seedContext.Games.Add(new Game
            {
                Slug = "button-challenge",
                Title = "Button Challenge",
                Description = "Test game",
                Url = "https://example.com/game"
            });
            await seedContext.SaveChangesAsync();
        }

        var factory = new Mock<IDbContextFactory<ApplicationDbContext>>();
        factory.Setup(contextFactory => contextFactory.CreateDbContextAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(() => new ApplicationDbContext(options));
        var user = new ClaimsPrincipal(new ClaimsIdentity(
            [new Claim(ClaimTypes.NameIdentifier, "academy-user")], "Test"));
        var service = CreateService(factory, user);

        var result = await service.SaveBestScore("button-challenge", 10);
        var playResult = await CreateService(factory, new ClaimsPrincipal(new ClaimsIdentity()))
            .RecordPlay("button-challenge");
        await using var verificationContext = new ApplicationDbContext(options);
        var savedScore = await verificationContext.GameScores.SingleAsync();

        Assert.Multiple(() =>
        {
            Assert.That(result.IsSuccess, Is.True);
            Assert.That(playResult.IsSuccess, Is.True);
            Assert.That(verificationContext.Games.Single().TimesPlayed, Is.EqualTo(1));
            Assert.That(savedScore.BestScore, Is.EqualTo(100));
            Assert.That(savedScore.BestScoreAchievedAt, Is.EqualTo(achievedAt));
        });
    }

    [Test]
    public async Task AnonymousUserCannotSaveScore()
    {
        var factory = new Mock<IDbContextFactory<ApplicationDbContext>>(MockBehavior.Strict);
        var service = CreateService(factory, new ClaimsPrincipal(new ClaimsIdentity()));

        var result = await service.SaveBestScore("button-challenge", 10);

        Assert.That(result.IsFailure, Is.True);
        Assert.That(result.Reason.Code, Is.EqualTo("GameScore.Unauthorized"));
        factory.VerifyNoOtherCalls();
    }

    [TestCase("button-challenge", -1)]
    [TestCase("", 10)]
    public async Task InvalidSubmissionDoesNotAccessDatabase(string gameId, int score)
    {
        var factory = new Mock<IDbContextFactory<ApplicationDbContext>>(MockBehavior.Strict);
        var user = new ClaimsPrincipal(new ClaimsIdentity(
            [new Claim(ClaimTypes.NameIdentifier, "academy-user")], "Test"));
        var service = CreateService(factory, user);

        var result = await service.SaveBestScore(gameId, score);

        Assert.That(result.IsFailure, Is.True);
        Assert.That(result.Reason.Code, Is.EqualTo("GameScore.Invalid"));
        factory.VerifyNoOtherCalls();
    }

    private static GameService CreateService(
        Mock<IDbContextFactory<ApplicationDbContext>> factory, ClaimsPrincipal user)
    {
        var authentication = new Mock<AuthenticationStateProvider>();
        authentication.Setup(provider => provider.GetAuthenticationStateAsync())
            .ReturnsAsync(new AuthenticationState(user));

        return new GameService(factory.Object, authentication.Object, NullLogger<GameService>.Instance);
    }
}
