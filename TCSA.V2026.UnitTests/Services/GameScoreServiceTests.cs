using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using TCSA.V2026.Data;
using TCSA.V2026.Services;

namespace TCSA.V2026.UnitTests.Services;

public class GameScoreServiceTests
{
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
    [TestCase("unknown-game", 10)]
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

    private static GameScoreService CreateService(
        Mock<IDbContextFactory<ApplicationDbContext>> factory, ClaimsPrincipal user)
    {
        var authentication = new Mock<AuthenticationStateProvider>();
        authentication.Setup(provider => provider.GetAuthenticationStateAsync())
            .ReturnsAsync(new AuthenticationState(user));

        return new GameScoreService(factory.Object, authentication.Object, NullLogger<GameScoreService>.Instance);
    }
}
