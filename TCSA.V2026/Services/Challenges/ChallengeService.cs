using Microsoft.EntityFrameworkCore;
using TCSA.V2026.Data;
using TCSA.V2026.Data.DTOs.Challenges;
using TCSA.V2026.Data.Enums;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Data.Models.Responses;
using TCSA.V2026.Helpers.Constants;

namespace TCSA.V2026.Services;

public interface IChallengeService
{
    Task<PaginatedList<ChallengeDetails>?> GetPaginatedChallenges(int pageNumber,
        string userId,
        Level userLevel,
        bool showCompleted,
        IEnumerable<Level> selectedLevels,
        IEnumerable<ChallengeCategory> selectedCategories,
        IEnumerable<ChallengePlatform> selectedPlatforms);
    Task<ChallengeStatistics?> GetChallengeStatistics(string userId);
    Task UpdateStreakInfo(string userId);
}

public class ChallengeService(IDbContextFactory<ApplicationDbContext> _factory) : IChallengeService
{
    public async Task<ChallengeStatistics?> GetChallengeStatistics(string userId)
    {
        try
        {
            using var context = _factory.CreateDbContext();
            var data = await context.Users
                .Where(u => u.Id == userId)
                .Select(u => new
                {
                    Streak = u.DailyStreak,
                    ChallengeCount = u.UserChallenges.Count
                })
                .FirstOrDefaultAsync();

            if (data == null) return null;

            var streak = data.Streak;

            if (streak.CurrentStreak > 0 && streak.LastCompletedDate < DateTime.UtcNow.Date.AddDays(-1))
            {
                streak.CurrentStreak = 0;
                await context.SaveChangesAsync();
            }

            return new ChallengeStatistics(
                new DailyStreakDetails(streak.CurrentStreak, streak.LongestStreak, streak.LastCompletedDate),
                data.ChallengeCount
            );
        }
        catch (Exception)
        {
            return null;
        }
    }

    public async Task<PaginatedList<ChallengeDetails>?> GetPaginatedChallenges(
        int pageNumber,
        string userId,
        Level userLevel,
        bool showCompleted,
        IEnumerable<Level> selectedLevels,
        IEnumerable<ChallengeCategory> selectedCategories,
        IEnumerable<ChallengePlatform> selectedPlatforms
    )
    {
        try
        {
            using var context = _factory.CreateDbContext();
            var currentUtcDate = DateTime.UtcNow;
            var query = context.Challenges
                .Where(c => c.ReleaseDate <= currentUtcDate && c.Level <= userLevel + 1)
                .AsNoTracking();

            if (!showCompleted)
            {
                query = query.Where(c => !c.UserChallenges.Any(uc => uc.UserId == userId));
            }

            if (selectedLevels.Any())
            {
                query = query.Where(c => selectedLevels.Contains(c.Level));
            }

            if (selectedCategories.Any())
            {
                query = query.Where(c => selectedCategories.Contains(c.Category));
            }

            if (selectedPlatforms.Any())
            {
                query = query.Where(c => selectedPlatforms.Contains(c.Platform));
            }

            var totalItems = await query.CountAsync();

            var items = await query
                .OrderByDescending(c => c.ReleaseDate)
                .Skip((pageNumber - 1) * PagingConstants.ChallengesPageSize)
                .Take(PagingConstants.ChallengesPageSize).Select(c => new ChallengeDetails
                (
                    c.Id,
                    c.ExternalId,
                    c.UserChallenges.Any(uc => uc.UserId == userId),
                    c.Level,
                    c.Name,
                    c.Description,
                    c.Category,
                    c.Platform,
                    c.ExperiencePoints
                )).ToListAsync();

            return new PaginatedList<ChallengeDetails>(
                items,
                totalItems,
                pageNumber,
                PagingConstants.ChallengesPageSize
            );
        }
        catch (Exception)
        {
            return null;
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
}
