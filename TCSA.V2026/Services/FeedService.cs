using Microsoft.EntityFrameworkCore;
using TCSA.V2026.Data;
using TCSA.V2026.Data.Curriculum;
using TCSA.V2026.Data.DTOs;
using TCSA.V2026.Data.Enums;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Data.Models.Responses;
using TCSA.V2026.Helpers;
using TCSA.V2026.Helpers.Constants;

namespace TCSA.V2026.Services;

public interface IFeedService
{
    Task<List<FeedDisplay>> GetRecentFeedItems();
    Task<CursorPage<FeedDisplay>> GetFeedItemsByCursor(string? cursor);
}

public class FeedService : IFeedService
{
    private readonly IDbContextFactory<ApplicationDbContext> _factory;
    private readonly IUserService _userService;

    public FeedService(IDbContextFactory<ApplicationDbContext> factory, IUserService userService)
    {
        _factory = factory;
        _userService = userService;
    }

    public async Task<CursorPage<FeedDisplay>> GetFeedItemsByCursor(string? cursor)
    {
        using var context = _factory.CreateDbContext();

        var decoded = FeedCursor.Decode(cursor);

        var activitiesQuery = context.UserActivity
            .Where(ua => ua.ActivityType == ActivityType.NewBelt || ua.ActivityType == ActivityType.ProjectCompleted)
            .Where(ua => !context.Issues.Any(i => i.ProjectId == ua.ProjectId))
            .Where(ua => decoded == null ||
                ua.DateSubmitted < decoded.Date ||
                (ua.DateSubmitted == decoded.Date && string.Compare(ua.AppUserId, decoded.UserId) < 0))
            .Select(ua => new
            {
                UserId = ua.AppUserId,
                DisplayName = ua.ApplicationUser!.DisplayName,
                UserName = ua.ApplicationUser.UserName,
                ActivityType = ua.ActivityType,
                ProjectId = (int?)ua.ProjectId,
                Level = ua.Level,
                Date = ua.DateSubmitted
            });

        var usersQuery = context.Users
            .Where(u => decoded == null ||
                u.CreatedDate < decoded.Date ||
                (u.CreatedDate == decoded.Date && string.Compare(u.Id, decoded.UserId) < 0))
            .Select(u => new
            {
                UserId = u.Id,
                DisplayName = u.DisplayName,
                UserName = u.UserName,
                ActivityType = ActivityType.NewUser,
                ProjectId = (int?)null,
                Level = (Level?)null,
                Date = u.CreatedDate
            });

        var rows = await activitiesQuery
            .Union(usersQuery)
            .OrderByDescending(f => f.Date)
            .Take(PagingConstants.FeedPageSize + 1)
            .AsNoTracking()
            .ToListAsync();

        var hasMore = rows.Count > PagingConstants.FeedPageSize;
        if (hasMore)
        {
            rows.RemoveAt(rows.Count - 1);
        }

        var items = rows
            .Select(f => new FeedDisplay
            {
                ProjectId = f.ProjectId,
                UserId = f.UserId,
                DisplayName = f.DisplayName,
                UserName = f.UserName,
                ActivityType = f.ActivityType,
                ProjectName = ProjectHelper.GetProjectName(f.ProjectId),
                ProjectIconUrl = ProjectHelper.GetProjectIconUrl(f.ProjectId),
                Level = f.Level,
                Date = f.Date
            })
            .ToList();

        string? nextCursor = null;
        if (hasMore && items.Count > 0)
        {
            var lastItem = items[^1];
            nextCursor = FeedCursor.Encode(lastItem.Date, lastItem.UserId);
        }

        return new CursorPage<FeedDisplay> { Items = items, NextCursor = nextCursor };
    }

    public async Task<List<FeedDisplay>> GetRecentFeedItems()
    {
        using var context = _factory.CreateDbContext();
        var recentActivitiesTask = context.UserActivity
            .Include(ua => ua.ApplicationUser)
            .Where(ua => ua.ActivityType == ActivityType.NewBelt || ua.ActivityType == ActivityType.ProjectCompleted)
            .Where(ua => !context.Issues.Any(i => i.ProjectId == ua.ProjectId))
            .OrderByDescending(ua => ua.DateSubmitted)
            .Take(FeedConstants.FeedWidgetItemLimits.RecentActivitiesLimit)
            .ToListAsync();

        var recentUsersTask = _userService.GetRecentlyJoinedUsers(FeedConstants.FeedWidgetItemLimits.RecentUsersLimit);

        await Task.WhenAll(recentActivitiesTask, recentUsersTask);

        var recentActivities = recentActivitiesTask.Result;
        var recentUsers = recentUsersTask.Result;

        return recentActivities
            .Select(FeedHelper.MapActivityToFeedDisplay)
            .Concat(recentUsers.Select(FeedHelper.MapUserToFeedDisplay))
            .OrderByDescending(fd => fd.Date)
            .ToList();
    }
}
