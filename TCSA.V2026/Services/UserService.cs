using Microsoft.EntityFrameworkCore;
using TCSA.V2026.Data;
using TCSA.V2026.Data.DTOs;
using TCSA.V2026.Data.DTOs.PublicProfile;
using TCSA.V2026.Data.Enums;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Data.Models.Responses;
using TCSA.V2026.Helpers;

namespace TCSA.V2026.Services;

public interface IUserService
{
    Task<ApplicationUser> GetUserById(string userId);
    Task<ApplicationUser> GetUserForDashboard(string userId);
    Task<ApplicationUser> GetDetailedUserById(string userId);
    Task<ApplicationUser> GetUserProfileById(string userId);
    Task<Result> SaveProfile(ApplicationUser user);
    Task<Result> ResetAccount(ApplicationUser user);
    Task<Result> DeleteAccount(ApplicationUser user);
    Task<ApplicationUser?> GetUserByIdWithShowcaseItems(string? userid);
    Task<List<ApplicationUser>> GetRecentlyJoinedUsers(int count);
    Task<Result> AcknowledgeBeltNotification(string userId);
    Task<OnboardingStatusDto> GetOnboardingStatus(string userId);
    Task<Result> MarkWelcomeSeen(string userId);
    Task<Result> MarkTourCompleted(string userId);
    Task<Result> MarkChecklistDismissed(string userId);
    Task<Result> RestartOnboarding(string userId);
    Task<Result> ResumeChecklist(string userId);
    Task<Result<PublicProfileResponse>> GetPublicProfile(string userId);
    Task<List<string>> GetUserIdsPendingBackfill(int batchSize);
}

public class UserService : IUserService
{
    private readonly IDbContextFactory<ApplicationDbContext> _factory;
    private readonly ILogger<UserService> _logger;

    public UserService(IDbContextFactory<ApplicationDbContext> factory, ILogger<UserService> logger)
    {
        _factory = factory;
        _logger = logger;
    }
    public async Task<ApplicationUser> GetUserProfileById(string userId)
    {
        try
        {
            using (var context = _factory.CreateDbContext())
            {
                return await context.AspNetUsers.FirstOrDefaultAsync(x => x.Id.Equals(userId));
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to GetUserProfileById for userId: {UserId}", userId);
            return null;
        }
    }

    public async Task<ApplicationUser> GetUserById(string userId)
    {
        try
        {
            using (var context = _factory.CreateDbContext())
            {
                var user = await context.AspNetUsers
                .Include(x => x.Issues)
                .Include(x => x.DashboardProjects)
                .Include(x => x.UserActivity)
                    .AsSplitQuery()
                .FirstOrDefaultAsync(x => x.Id.Equals(userId));

                return user;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to retrieve GetUserById {UserId}", userId);
            return null;
        }
    }

    public async Task<ApplicationUser> GetUserForDashboard(string userId)
    {
        try
        {
            using (var context = _factory.CreateDbContext())
            {
                return await context.AspNetUsers
                    .Include(x => x.DashboardProjects)
                    .Include(x => x.UserActivity)
                    .AsSplitQuery()
                    .FirstOrDefaultAsync(x => x.Id.Equals(userId));
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to retrieve GetUserForDashboard {UserId}", userId);
            return null;
        }
    }

    public async Task<ApplicationUser> GetDetailedUserById(string userId)
    {
        try
        {
            using (var context = _factory.CreateDbContext())
            {
                var user =
                await context.AspNetUsers
                .AsNoTracking()
                .Include(x => x.CodeReviewProjects)
                   .ThenInclude(x => x.DashboardProject)
                .Include(x => x.UserActivity)
                .Include(x => x.DashboardProjects)
                .Include(x => x.Issues)
                .Include(x => x.UserChallenges)
                    .ThenInclude(x => x.Challenge)
                .AsSplitQuery()
                .FirstOrDefaultAsync(x => x.Id.Equals(userId));

                return user;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to retrieve GetDetailedUserById {UserId}", userId);
            return null;
        }
    }

    public async Task<Result> SaveProfile(ApplicationUser user)
    {
        try
        {
            using (var context = _factory.CreateDbContext())
            {
                var dbUser = await context.AspNetUsers.FirstOrDefaultAsync(x => x.Id.Equals(user.Id));
                dbUser.DisplayName = user.DisplayName;
                dbUser.DiscordAlias = user.DiscordAlias;
                dbUser.GithubUsername = user.GithubUsername;
                dbUser.LinkedInUrl = user.LinkedInUrl;
                dbUser.Country = user.Country;
                dbUser.CodeWarsUsername = user.CodeWarsUsername;
                dbUser.LeetCodeUsername = user.LeetCodeUsername;

                await context.SaveChangesAsync();

                return Result.Success(new Success("Profile.Updated", "Profile updated successfully."));
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to SaveProfile {UserId}", user.Id);
            return Result.Failure(new Error("User.Unexpected", ex.Message));
        }
    }

    public async Task<Result> DeleteAccount(ApplicationUser user)
    {
        try
        {
            using (var context = _factory.CreateDbContext())
            {
                var dbUser = await context.AspNetUsers.FirstOrDefaultAsync(x => x.Id.Equals(user.Id));
                context.AspNetUsers.Remove(dbUser);

                await context.SaveChangesAsync();

                return Result.Success(new Success("Account.Deleted", "Account deleted successfully."));
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to DeleteAccount {UserId}", user.Id);
            return Result.Failure(new Error("User.Unexpected", ex.Message));
        }
    }

    public async Task<Result> ResetAccount(ApplicationUser user)
    {
        try
        {
            using (var context = _factory.CreateDbContext())
            {
                var dbUser = await context.AspNetUsers
                    .FirstOrDefaultAsync(x => x.Id.Equals(user.Id));

                if (dbUser == null)
                    return Result.Failure(new Error("User.NotFound", "User not found."));

                dbUser.ExperiencePoints = 0;
                dbUser.ReviewedProjects = 0;
                dbUser.Level = Level.White;

                context.DailyStreaks.RemoveRange(context.DailyStreaks.Where(ua => ua.AppUserId == user.Id));
                context.UserChallenges.RemoveRange(context.UserChallenges.Where(ua => ua.UserId == user.Id));
                context.ShowcaseItems.RemoveRange(context.ShowcaseItems.Where(ua => ua.AppUserId == user.Id));
                context.UserReviews.RemoveRange(context.UserReviews.Where(ua => ua.AppUserId == user.Id));
                context.UserActivity.RemoveRange(context.UserActivity.Where(ua => ua.AppUserId == user.Id));
                context.Issues.RemoveRange(context.Issues.Where(ua => ua.AppUserId == user.Id));
                context.DashboardProjects.RemoveRange(context.DashboardProjects.Where(ua => ua.AppUserId == user.Id));

                await context.SaveChangesAsync();

                return Result.Success(new Success("Account.Reset", "User data reset successfully."));
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to ResetAccount {UserId}", user.Id);
            return Result.Failure(new Error("User.Unexpected", ex.Message));
        }
    }

    public async Task<ApplicationUser?> GetUserByIdWithShowcaseItems(string? userId)
    {
        try
        {
            using (var context = _factory.CreateDbContext())
            {
                return await context.AspNetUsers
                .AsNoTracking()
                .Include(x => x.DashboardProjects)
                .Include(x => x.ShowcaseItems)
                .AsSplitQuery()
                .FirstOrDefaultAsync(x => x.Id.Equals(userId));
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to retrieve GetUserByIdWithShowcaseItems {UserId}", userId);
            return null;
        }
    }

    public async Task<List<ApplicationUser>> GetRecentlyJoinedUsers(int count)
    {
        try
        {
            using (var context = _factory.CreateDbContext())
            {
                return await context.AspNetUsers
                    .AsNoTracking()
                    .OrderByDescending(u => u.CreatedDate)
                    .Take(count)
                    .ToListAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to retrieve GetRecentlyJoinedUsers");
            return new List<ApplicationUser>();
        }
    }

    public async Task<Result> AcknowledgeBeltNotification(string userId)
    {
        try
        {
            using (var context = _factory.CreateDbContext())
            {
                var user = await context.Users.FirstOrDefaultAsync(u => u.Id == userId);
                if (user != null && user.HasPendingBeltNotification)
                {
                    user.HasPendingBeltNotification = false;
                    await context.SaveChangesAsync();
                }
            }

            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure(new Error("User.Unexpected", ex.Message));
        }
    }

    public async Task<OnboardingStatusDto> GetOnboardingStatus(string userId)
    {
        try
        {
            using (var context = _factory.CreateDbContext())
            {
                var user = await context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == userId);
                if (user == null || user.OnboardingStartedDate == null)
                {
                    return new OnboardingStatusDto();
                }

                return new OnboardingStatusDto
                {
                    ShowWelcome = !user.HasCompletedWelcome,
                    ShowTour = !user.HasCompletedTour,
                    ShowChecklist = !user.HasDismissedChecklist,
                    Tasks = !user.HasDismissedChecklist ? ChecklistHelper.BuildProfileTasks(user) : new()
                };
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to retrieve onboarding status for userId: {UserId}", userId);
            return new OnboardingStatusDto();
        }
    }

    public Task<Result> MarkWelcomeSeen(string userId)
    {
        return UpdateOnboardingFlag(userId, user =>
        {
            user.HasCompletedWelcome = true;
        });
    }

    public Task<Result> MarkTourCompleted(string userId)
    {
        return UpdateOnboardingFlag(userId, user =>
        {
            user.HasCompletedTour = true;
        });
    }

    public Task<Result> MarkChecklistDismissed(string userId)
    {
        return UpdateOnboardingFlag(userId, user =>
        {
            user.HasDismissedChecklist = true;
        });
    }

    public Task<Result> RestartOnboarding(string userId)
    {
        return UpdateOnboardingFlag(userId, user =>
        {
            user.HasCompletedWelcome = false;
            user.HasCompletedTour = false;
            user.OnboardingStartedDate = DateTime.UtcNow;
        });
    }

    public Task<Result> ResumeChecklist(string userId)
    {
        return UpdateOnboardingFlag(userId, user =>
        {
            user.HasDismissedChecklist = false;
        });
    }

    private async Task<Result> UpdateOnboardingFlag(string userId, Action<ApplicationUser> applyUpdate)
    {
        try
        {
            using (var context = _factory.CreateDbContext())
            {
                var user = await context.Users.FirstOrDefaultAsync(u => u.Id == userId);
                if (user == null)
                {
                    return Result.Failure(new Error("User.NotFound", "User not found."));
                }

                applyUpdate(user);
                await context.SaveChangesAsync();
            }

            return Result.Success();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to update onboarding flags for userId: {UserId}", userId);
            return Result.Failure(new Error("User.Unexpected", ex.Message));
        }
    }

    public async Task<Result<PublicProfileResponse>> GetPublicProfile(string userId)
    {
        try
        {
            using var context = _factory.CreateDbContext();
            var rawSql = @"
                SELECT
                    ExperiencePoints,
                    ReviewExperiencePoints,
                    Level,
                    CreatedDate,
                    UserName,
                    DisplayName,
                    Country,
                    FirstName,
                    LastName,
                    LinkedInUrl,
                    CodeWarsUsername,
                    LeetCodeUsername,
                    LeaderboardRank,
                    ReviewLeaderboardRank
                FROM (
                    SELECT
                        Id,
                        ExperiencePoints,
                        ReviewExperiencePoints,
                        Level,
                        CreatedDate,
                        UserName,
                        DisplayName,
                        Country,
                        FirstName,
                        LastName,
                        LinkedInUrl,
                        CodeWarsUsername,
                        LeetCodeUsername,
                        CASE WHEN ExperiencePoints > 0 THEN
                            ROW_NUMBER() OVER (ORDER BY CASE WHEN ExperiencePoints > 0 THEN 0 ELSE 1 END, ExperiencePoints DESC, CreatedDate, Id)
                        END AS LeaderboardRank,
                        CASE WHEN ReviewExperiencePoints > 0 THEN
                            ROW_NUMBER() OVER (ORDER BY CASE WHEN ReviewExperiencePoints > 0 THEN 0 ELSE 1 END, ReviewExperiencePoints DESC, CreatedDate, Id)
                        END AS ReviewLeaderboardRank
                    FROM AspNetUsers
                ) AS RankedUsers
                WHERE Id = {0}
            ";

            var profileIdentity = await context.Database
                .SqlQueryRaw<PublicProfileIdentityResponse>(rawSql, userId)
                .FirstOrDefaultAsync();

            if (profileIdentity == null)
                return Result.Failure<PublicProfileResponse>(new Error("User.NotFound", "User not found."));

            var profilePullRequests = await context.DashboardProjects
                .AsNoTracking()
                .Where(dp => dp.AppUserId == userId && dp.IsCompleted)
                .Join(
                    context.Issues,
                    dp => dp.ProjectId,
                    i => i.ProjectId,
                    (dp, i) => new { dp, i }
                )
                .OrderByDescending(x => x.dp.DateCompleted)
                .ThenBy(x => x.i.Id)
                .Select(x => new PublicProfilePullRequestDetailsResponse
                (
                    x.dp.DateCompleted,
                    x.i.Title,
                    x.dp.GithubUrl,
                    x.i.CommunityProjectId
                ))
                .Take(5)
                .ToListAsync();

            int[] communityProjectIds = [.. Enum.GetValues<CommunityProject>().Cast<int>()];

            var completedProjectIds = await context.DashboardProjects
                .AsNoTracking()
                .Where(dp => dp.AppUserId == userId && dp.IsCompleted && !communityProjectIds.Contains(dp.ProjectId))
                .Select(dp => dp.ProjectId)
                .ToListAsync();

            return Result.Success(new PublicProfileResponse(
                profileIdentity,
                profilePullRequests,
                completedProjectIds
            ));

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to retrieve public profile for userId: {UserId}", userId);
            return Result.Failure<PublicProfileResponse>(new Error("User.Unexpected", ex.Message));
        }
    }

    public async Task<List<string>> GetUserIdsPendingBackfill(int batchSize)
    {
        try
        {
            using var context = _factory.CreateDbContext();
            return await context.Users
                .AsNoTracking()
                .Where(u => !u.HasBackfilledBadges)
                .OrderBy(u => u.Id)
                .Select(u => u.Id)
                .Take(batchSize)
                .ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to retrieve user ids pending badge backfill");
            return new List<string>();
        }
    }
}
