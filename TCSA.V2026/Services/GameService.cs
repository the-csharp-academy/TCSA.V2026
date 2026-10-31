using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using TCSA.V2026.Data;
using TCSA.V2026.Data.DTOs;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Data.Models.Responses;
using TCSA.V2026.Helpers;
using TCSA.V2026.Helpers.Constants;

namespace TCSA.V2026.Services;

public interface IGameService
{
    Task<Result<List<Game>>> GetGames();
    Task<Result<Game>> GetGame(string slug);
    Task<Result> RecordPlay(string slug);
    Task<Result<int>> SaveBestScore(string gameId, int score);
    Task<Result<PaginatedList<GameLeaderboardEntry>>> GetLeaderboard(string gameId, int pageNumber);
}

public class GameService(
    IDbContextFactory<ApplicationDbContext> factory,
    AuthenticationStateProvider authenticationState,
    ILogger<GameService> logger) : IGameService
{
    public async Task<Result> RecordPlay(string slug)
    {
        // Each retry reloads the shared counter after a concurrent update.
        for (var attempt = 0; attempt < 3; attempt++)
        {

            try
            {
                await using var context = await factory.CreateDbContextAsync();
                var gameQuery = context.Games.Where(game => game.Slug == slug);
                var game = await gameQuery.SingleOrDefaultAsync();

                if (game is null)
                {
                    return Result.Failure(new Error("Game.NotFound", "This game was not found."));
                }

                game.TimesPlayed++;
                await context.SaveChangesAsync();

                return Result.Success();
            }
            catch (DbUpdateConcurrencyException) when (attempt < 2)
            {
                // The next attempt uses the latest counter value.
            }
            catch (Exception exception)
            {
                logger.LogError(exception, "Could not record play for game {Slug}", slug);

                return Result.Failure(new Error("Game.RecordPlayFailed", "Your play could not be recorded. Please try again."));
            }
        }

        return Result.Failure(new Error("Game.RecordPlayFailed", "Your play could not be recorded. Please try again."));
    }

    public async Task<Result<List<Game>>> GetGames()
    {
        try
        {
            await using var context = await factory.CreateDbContextAsync();
            var gamesQuery = context.Games.AsNoTracking().OrderBy(game => game.Title).ThenBy(game => game.Slug);
            var games = await gamesQuery.ToListAsync();

            return Result.Success(games);
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "Could not load games");

            return Result.Failure<List<Game>>(new Error("Game.LoadFailed", "Games could not be loaded. Please try again."));
        }
    }

    public async Task<Result<Game>> GetGame(string slug)
    {
        try
        {
            await using var context = await factory.CreateDbContextAsync();
            var gameQuery = context.Games.AsNoTracking().Where(game => game.Slug == slug);
            var game = await gameQuery.SingleOrDefaultAsync();

            if (game is null)
            {
                return Result.Failure<Game>(new Error("Game.NotFound", "This game was not found."));
            }

            return Result.Success(game);
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "Could not load game {Slug}", slug);

            return Result.Failure<Game>(new Error("Game.LoadFailed", "The game could not be loaded. Please try again."));
        }
    }

    public async Task<Result<PaginatedList<GameLeaderboardEntry>>> GetLeaderboard(string gameId, int pageNumber)
    {
        try
        {
            await using var context = await factory.CreateDbContextAsync();
            var gameExists = await context.Games.AnyAsync(game => game.Slug == gameId);

            if (!gameExists)
            {
                return Result.Failure<PaginatedList<GameLeaderboardEntry>>(
                    new Error("GameScore.InvalidGame", "This game was not found."));
            }

            var leaderboardQuery = from score in context.GameScores.AsNoTracking()
                                   join user in context.Users.AsNoTracking() on score.UserId equals user.Id
                                   where score.GameId == gameId
                                   select new { score, user };
            var totalItems = await leaderboardQuery.CountAsync();
            var totalPages = Math.Max(1, (int)Math.Ceiling(totalItems / (double)PagingConstants.LeaderboardPageSize));
            var selectedPage = Math.Clamp(pageNumber, 1, totalPages);
            var offset = (selectedPage - 1) * PagingConstants.LeaderboardPageSize;

            // Earlier achievements win ties; user ID keeps ordering stable across pages.
            var pageQuery = leaderboardQuery
                .OrderByDescending(entry => entry.score.BestScore)
                .ThenBy(entry => entry.score.BestScoreAchievedAt)
                .ThenBy(entry => entry.user.Id)
                .Skip(offset)
                .Take(PagingConstants.LeaderboardPageSize)
                .Select(entry => new
                {
                    entry.user.Id,
                    entry.user.DisplayName,
                    entry.user.UserName,
                    entry.user.Country,
                    entry.user.Level,
                    entry.score.BestScore
                });
            var players = await pageQuery.ToListAsync();
            var entries = players.Select((player, index) => new GameLeaderboardEntry
            {
                UserId = player.Id,
                DisplayName = UserDisplayNameHelper.GetDisplayName(player.DisplayName, player.UserName),
                Country = player.Country,
                Level = player.Level,
                Score = player.BestScore,
                Ranking = offset + index + 1
            }).ToList();
            var leaderboard = new PaginatedList<GameLeaderboardEntry>(
                entries, totalItems, selectedPage, PagingConstants.LeaderboardPageSize);

            return Result.Success(leaderboard);
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "Could not load leaderboard for game {GameId}", gameId);

            return Result.Failure<PaginatedList<GameLeaderboardEntry>>(
                new Error("GameScore.LeaderboardFailed", "The leaderboard could not be loaded. Please try again."));
        }
    }

    public async Task<Result<int>> SaveBestScore(string gameId, int score)
    {
        var authentication = await authenticationState.GetAuthenticationStateAsync();
        var userId = authentication.User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (authentication.User.Identity?.IsAuthenticated != true || string.IsNullOrWhiteSpace(userId))
        {
            return Result.Failure<int>(new Error("GameScore.Unauthorized", "Sign in to save your score."));
        }

        if (score < 0 || string.IsNullOrWhiteSpace(gameId))
        {
            return Result.Failure<int>(new Error("GameScore.Invalid", "This game score is invalid."));
        }

        try
        {
            await using var context = await factory.CreateDbContextAsync();
            var gameExists = await context.Games.AnyAsync(game => game.Slug == gameId);

            if (!gameExists)
            {
                return Result.Failure<int>(new Error("GameScore.Invalid", "This game score is invalid."));
            }

            var existingScoreQuery = context.GameScores
                .Where(gameScore => gameScore.GameId == gameId && gameScore.UserId == userId);
            var existingScore = await existingScoreQuery.SingleOrDefaultAsync();

            if (existingScore is null)
            {
                existingScore = new GameScore
                {
                    GameId = gameId,
                    UserId = userId,
                    BestScore = score,
                    BestScoreAchievedAt = DateTimeOffset.UtcNow
                };
                context.GameScores.Add(existingScore);
            }
            else if (score > existingScore.BestScore)
            {
                existingScore.BestScore = score;
                existingScore.BestScoreAchievedAt = DateTimeOffset.UtcNow;
            }

            await context.SaveChangesAsync();

            return Result.Success(existingScore.BestScore);
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "Could not save score for game {GameId} and user {UserId}", gameId, userId);

            return Result.Failure<int>(new Error("GameScore.SaveFailed", "Your score could not be saved. Please try again."));
        }
    }
}
