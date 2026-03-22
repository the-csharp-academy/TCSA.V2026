using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using TCSA.V2026.Data;
using TCSA.V2026.Data.Enums;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Data.Models.Responses;

namespace TCSA.V2026.Services;

public interface IUserService
{
    Task<ApplicationUser> GetUserById(string userId);
    Task<ApplicationUser> GetUserChallengeDetails(string userId);
    Task<ApplicationUser> GetDetailedUserById(string userId);
    Task<ApplicationUser> GetUserProfileById(string userId);
    Task<BaseResponse> SaveProfile(ApplicationUser user);
    Task<BaseResponse> ResetAccount(ApplicationUser user);
    Task<BaseResponse> DeleteAccount(ApplicationUser user);
    Task<ApplicationUser?> GetUserByIdWithShowcaseItems(string? userid);
    Task<List<ApplicationUser>> GetRecentlyJoinedUsers(int count);
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

    public async Task<BaseResponse> SaveProfile(ApplicationUser user)
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

                return new BaseResponse
                {
                    Status = ResponseStatus.Success,
                    Message = "Profile updated successfully."
                };
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to SaveProfile {UserId}", user.Id);
            return new BaseResponse
            {
                Status = ResponseStatus.Fail,
                Message = ex.Message
            };
        }
    }

    public async Task<BaseResponse> DeleteAccount(ApplicationUser user)
    {
        try
        {
            using (var context = _factory.CreateDbContext())
            {
                var dbUser = await context.AspNetUsers.FirstOrDefaultAsync(x => x.Id.Equals(user.Id));
                context.AspNetUsers.Remove(dbUser);

                await context.SaveChangesAsync();

                return new BaseResponse
                {
                    Status = ResponseStatus.Success,
                    Message = "Account deleted successfully."
                };
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to DeleteAccount {UserId}", user.Id);
            return new BaseResponse
            {
                Status = ResponseStatus.Fail,
                Message = ex.Message
            };
        }
    }

    public async Task<BaseResponse> ResetAccount(ApplicationUser user)
    {
        try
        {
            using (var context = _factory.CreateDbContext())
            {
                var dbUser = await context.AspNetUsers
                    .FirstOrDefaultAsync(x => x.Id.Equals(user.Id));

                if (dbUser == null)
                    return new BaseResponse { Status = ResponseStatus.Fail, Message = "User not found." };

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

                return new BaseResponse
                {
                    Status = ResponseStatus.Success,
                    Message = "User data reset successfully."
                };
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to ResetAccount {UserId}", user.Id);
            return new BaseResponse
            {
                Status = ResponseStatus.Fail,
                Message = ex.Message
            };
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

    public async Task<ApplicationUser> GetUserChallengeDetails(string userId)
    {
        try
        {
            using (var context = _factory.CreateDbContext())
            {
                var user =
                await context.AspNetUsers
                .AsNoTracking()
                .Include(x => x.UserChallenges)
                    .ThenInclude(x => x.Challenge)
                .AsSplitQuery()
                .FirstOrDefaultAsync(x => x.Id.Equals(userId));

                return user;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to retrieve GetUserChallengeDetails {UserId}", userId);
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
}
