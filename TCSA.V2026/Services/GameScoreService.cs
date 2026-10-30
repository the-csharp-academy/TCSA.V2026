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

public interface IGameScoreService
{
    Task<Result<int>> SaveBestScore(string gameId, int score);
    Task<Result<PaginatedList<GameLeaderboardEntry>>> GetLeaderboard(string gameId, int pageNumber);
}

public class GameScoreService(
    IDbContextFactory<ApplicationDbContext> factory,
    AuthenticationStateProvider authenticationState,
    ILogger<GameScoreService> logger) : IGameScoreService
{
    public async Task<Result<PaginatedList<GameLeaderboardEntry>>> GetLeaderboard(string gameId, int pageNumber)
    {
        if (!GameCatalog.Games.Any(game => game.Slug == gameId))
        {
            return Result.Failure<PaginatedList<GameLeaderboardEntry>>(
                new Error("GameScore.InvalidGame", "This game was not found."));
        }

        try
        {
            await using var context = await factory.CreateDbContextAsync();
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

        if (score < 0 || !GameCatalog.Games.Any(game => game.Slug == gameId))
        {
            return Result.Failure<int>(new Error("GameScore.Invalid", "This game score is invalid."));
        }

        try
        {
            await using var context = await factory.CreateDbContextAsync();
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
