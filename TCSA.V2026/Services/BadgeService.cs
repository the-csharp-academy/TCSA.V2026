using Microsoft.EntityFrameworkCore;
using TCSA.V2026.Data;
using TCSA.V2026.Data.Enums;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Data.Models.Responses;
using TCSA.V2026.Helpers;

namespace TCSA.V2026.Services;

public interface IBadgeService
{
    Task<IEnumerable<Badge>> GetUserAwardedBadges(string userId);
    Task<IEnumerable<Badge>> GetRecentAwardedBadges(string userId, DateTimeOffset since);
    Task<BaseResponse> AwardBadge(string userId, int badgeId);
    Task AwardFullStackBadges(string userId, List<int> completedProjectIds);
    Task AwardReviewBadges(string userId, int reviewedProjectsCount);
    Task<BaseResponse> AcknowledgeBadgeNotifications(string userId);
    Task AwardMissingBadges(string userId);
}

public class BadgeService(IDbContextFactory<ApplicationDbContext> _factory, ILogger<BadgeService> _logger) : IBadgeService
{
    public async Task<BaseResponse> AwardBadge(string userId, int badgeId)
    {
        try
        {
            using var context = await _factory.CreateDbContextAsync();
            context.Badges.Add(new Badge
            {
                UserId = userId,
                BadgeId = badgeId,
                DateAwarded = DateTime.UtcNow,
                IsPendingNotification = true
            });

            await context.SaveChangesAsync();

            return new BaseResponse
            {
                Status = ResponseStatus.Success,
            };
        }
        catch (DbUpdateException ex)
        {
            _logger.LogError(ex, "Error awarding badge {BadgeId} to user {UserId}", badgeId, userId);
            return new BaseResponse
            {
                Status = ResponseStatus.Fail,
                Message = $"Badge has already been awarded.",
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unexpected error awarding badge {BadgeId} to user {UserId}", badgeId, userId);
            return new BaseResponse
            {
                Status = ResponseStatus.Fail,
                Message = $"An unexpected error occurred while awarding the badge.",
            };
        }
    }

    public async Task<IEnumerable<Badge>> GetUserAwardedBadges(string userId)
    {
        using var context = await _factory.CreateDbContextAsync();
        return await context.Badges
            .Where(b => b.UserId == userId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Badge>> GetRecentAwardedBadges(string userId, DateTimeOffset since)
    {
        using var context = await _factory.CreateDbContextAsync();
        return await context.Badges
            .Where(b => b.UserId == userId && b.DateAwarded > since)
            .ToListAsync();
    }

    private const int FullStackAreaCount = 5;

    public async Task AwardFullStackBadges(string userId, List<int> completedProjectIds)
    {
        if (completedProjectIds is null)
        {
            return;
        }

        var completedAreas = RoadmapHelper.GetFullStackAreasCompleted(completedProjectIds);

        if (completedAreas.Count >= 1)
        {
            await AwardBadge(userId, (int)BadgeId.FullstackDeveloper);
        }

        if (completedAreas.Count == FullStackAreaCount)
        {
            await AwardBadge(userId, (int)BadgeId.PolyglotDeveloper);
        }
    }

    public async Task AwardReviewBadges(string userId, int reviewedProjectsCount)
    {
        if (reviewedProjectsCount >= 1)
        {
            await AwardBadge(userId, (int)BadgeId.CodeReviewer);
        }

        if (reviewedProjectsCount >= 25)
        {
            await AwardBadge(userId, (int)BadgeId.TrustedReviewer);
        }

        if (reviewedProjectsCount >= 100)
        {
            await AwardBadge(userId, (int)BadgeId.MasterReviewer);
        }

        if (reviewedProjectsCount >= 500)
        {
            await AwardBadge(userId, (int)BadgeId.ExpertReviewer);
        }
    }

    public async Task<BaseResponse> AcknowledgeBadgeNotifications(string userId)
    {
        try
        {
            using var context = await _factory.CreateDbContextAsync();
            await context.Badges
                .Where(b => b.UserId == userId && b.IsPendingNotification)
                .ExecuteUpdateAsync(s => s.SetProperty(b => b.IsPendingNotification, false));

            return new BaseResponse
            {
                Status = ResponseStatus.Success,
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to acknowledge badge notifications for user {UserId}", userId);
            return new BaseResponse
            {
                Status = ResponseStatus.Fail,
                Message = ex.Message
            };
        }
    }

    public async Task AwardMissingBadges(string userId)
    {
        try
        {
            using var context = await _factory.CreateDbContextAsync();

            var user = await context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (user is null || user.HasBackfilledBadges)
            {
                return;
            }

            var completedProjectIds = await context.DashboardProjects
                .AsNoTracking()
                .Where(dp => dp.AppUserId == userId && dp.IsCompleted)
                .Select(dp => dp.ProjectId)
                .ToListAsync();

            var hasClosedCommunityIssue = await context.Issues
                .AsNoTracking()
                .AnyAsync(i => i.AppUserId == userId && i.IsClosed);

            await AwardReviewBadges(userId, user.ReviewedProjects);
            await AwardFullStackBadges(userId, completedProjectIds);

            if (hasClosedCommunityIssue)
            {
                await AwardBadge(userId, (int)BadgeId.PlatformBuilder);
            }

            user.HasBackfilledBadges = true;
            await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to backfill missing badges for user {UserId}", userId);
        }
    }
}
