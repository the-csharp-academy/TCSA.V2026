using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using TCSA.V2026.Data;
using TCSA.V2026.Data.Enums;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Data.Models.Responses;

namespace TCSA.V2026.Services;

public interface IChallengeService
{
    Task<List<Challenge>> GetChallenges(Level level);
    Task<DailyStreak> GetStreakInfo(string userId);
    Task UpdateStreakInfo(string userId);
    Task<BaseResponse> AddChallenge(Challenge challenge);
}

public class ChallengeService(IDbContextFactory<ApplicationDbContext> _factory, ILogger<ChallengeService> _logger) : IChallengeService
{
    public async Task<List<Challenge>> GetChallenges(Level level)
    {
        using (var context = _factory.CreateDbContext())
        {
            var currentUtcDate = DateTime.UtcNow;
            return await context.Challenges
                .Where(c => c.ReleaseDate <= currentUtcDate && c.Level <= level + 1)
                .OrderByDescending(c => c.ReleaseDate)
                .ToListAsync()
                .ConfigureAwait(false);
        }
    }

    public async Task<DailyStreak> GetStreakInfo(string userId)
    {
        using (var context = _factory.CreateDbContext())
        {
            var streakInfo = await context.DailyStreaks.FirstOrDefaultAsync(s => s.AppUserId == userId);

            if (streakInfo is null) return new DailyStreak();

            if (streakInfo.CurrentStreak > 0 &&
                streakInfo.LastCompletedDate < DateTime.UtcNow.Date.AddDays(-1))
            {
                streakInfo.CurrentStreak = 0;
                context.DailyStreaks.Update(streakInfo);
                await context.SaveChangesAsync();
            }

            return streakInfo;
        }
    }

    public async Task UpdateStreakInfo(string userId)
    {
        using (var context = _factory.CreateDbContext())
        {

            var streak = await context.DailyStreaks.FirstOrDefaultAsync(s => s.AppUserId == userId);
            var today = DateTime.UtcNow.Date;

            if (streak == null)
            {
                streak = new DailyStreak
                {
                    AppUserId = userId,
                    CurrentStreak = 1,
                    LongestStreak = 1,
                    LastCompletedDate = today
                };
                context.DailyStreaks.Add(streak);
            }
            else
            {
                if (streak.LastCompletedDate == today.AddDays(-1))
                {
                    streak.CurrentStreak++;
                }
                else if (streak.LastCompletedDate < today.AddDays(-1))
                {
                    streak.CurrentStreak = 1;
                }

                if (streak.CurrentStreak > streak.LongestStreak)
                {
                    streak.LongestStreak = streak.CurrentStreak;
                }

                streak.LastCompletedDate = today;
                context.DailyStreaks.Update(streak);
            }

            await context.SaveChangesAsync();
        }
    }

    public async Task<BaseResponse> AddChallenge(Challenge challenge)
    {
        try
        {
            using var context = _factory.CreateDbContext();

            bool exists = await context.Challenges.AnyAsync(c => c.ExternalId == challenge.ExternalId);
            if (exists)
                return new BaseResponse { Status = ResponseStatus.Fail, Message = "Challenge already exists." };

            context.Challenges.Add(challenge);
            await context.SaveChangesAsync();
            return new BaseResponse { Status = ResponseStatus.Success };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to add challenge with ExternalId {ExternalId}.", challenge.ExternalId);
            return new BaseResponse { Status = ResponseStatus.Fail, Message = ex.Message };
        }
    }
}
