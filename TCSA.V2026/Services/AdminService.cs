using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using TCSA.V2026.Data;
using TCSA.V2026.Data.DTOs;
using TCSA.V2026.Data.Enums;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Data.Models.Responses;
using TCSA.V2026.Helpers;

namespace TCSA.V2026.Services;

public interface IAdminService
{
    Task<ApplicationUser> GetUserForAdmin(string id);
    Task<List<AdminEventDisplay>> GetAdminEvents();
    Task<List<AdminPendingDisplay>> GetAdminPendingProjects();
    Task<List<ApplicationUser>> SearchUsers(string? email, string? userName, string? displayName, string? discordAlias);
    Task<BaseResponse> ChangeBelt(string userId, Level newBelt);
    Task<BaseResponse> ChangePoints(string userId, int points);
    Task<BaseResponse> RequestChanges(int dashboardProjectId);
    Task<ServiceResponse> ChangeReviewPoints(string userId, int points);
}

public class AdminService(
    IDbContextFactory<ApplicationDbContext> _factory,
    IDiscordService _discordService
    ) : IAdminService
{
    public async Task<BaseResponse> ChangePoints(string userId, int points)
    {
        try
        {
            using (var context = _factory.CreateDbContext())
            {
                var user = await context.AspNetUsers.FirstOrDefaultAsync(u => u.Id == userId);

                user.ExperiencePoints = points;

                await context.SaveChangesAsync();

            }
            return new BaseResponse
            {
                Status = ResponseStatus.Success,
            };
        }
        catch (Exception ex)
        {
            return new BaseResponse
            {
                Status = ResponseStatus.Fail,
                Message = ex.Message
            };
        }
    }

    public async Task<ServiceResponse> ChangeReviewPoints(string userId, int points)
    {
        try
        {
            using (var context = _factory.CreateDbContext())
            {
                var user = await context.AspNetUsers.FirstOrDefaultAsync(u => u.Id == userId);

                user.ReviewExperiencePoints = points;

                await context.SaveChangesAsync();

            }
            return new ServiceResponse
            {
                IsSuccessful = true,
            };
        }
        catch (Exception ex)
        {
            return new ServiceResponse
            {
                IsSuccessful = false,
                Message = ex.Message
            };
        }
    }

    public async Task<BaseResponse> ChangeBelt(string userId, Level newBelt)
    {
        try
        {
            using (var context = _factory.CreateDbContext())
            {
                var user = await context.AspNetUsers.FirstOrDefaultAsync(u => u.Id == userId);

                user.Level = newBelt;
                user.HasPendingBeltNotification = true;

                await context.UserActivity.AddAsync(new AppUserActivity
                {
                    AppUserId = userId,
                    ProjectId = 0,
                    ChallengeId = 0,
                    DateSubmitted = DateTimeOffset.UtcNow,
                    ActivityType = ActivityType.NewBelt,
                    Level = newBelt
                });

                await context.SaveChangesAsync();

                if (user.DiscordAlias != null)
                {
                    await _discordService.ChangeDiscordBelt(user.DiscordAlias!, newBelt);
                }
            }
            return new BaseResponse
            {
                Status = ResponseStatus.Success,
            };
        }
        catch (Exception ex)
        {
            return new BaseResponse
            {
                Status = ResponseStatus.Fail,
                Message = ex.Message
            };
        }
    }

    public async Task<ApplicationUser> GetUserForAdmin(string id)
    {
        var startTime = DateTime.UtcNow;
        try
        {
            using (var context = _factory.CreateDbContext())
            {
                var result = await context.AspNetUsers
               .AsNoTracking()
               .Include(u => u.UserChallenges)
                   .ThenInclude(x => x.Challenge)
               .Include(u => u.DashboardProjects)
               .Include(u => u.CodeReviewProjects)
                   .ThenInclude(cr => cr.DashboardProject)
               .Include(u => u.Issues)
               .AsSplitQuery()
               .FirstOrDefaultAsync(x => x.Id.Equals(id));

                var loadTime = DateTime.UtcNow - startTime;
                return result;
            }

        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public async Task<List<AdminEventDisplay>> GetAdminEvents()
    {
        try
        {
            using (var context = _factory.CreateDbContext())
            {
                return await context.UserActivity
                    .Where(x => x.DateSubmitted >= DateTime.UtcNow.AddDays(-3))
                    .OrderByDescending(x => x.DateSubmitted)
                    .Select(ua => new AdminEventDisplay
                    {
                        AppUserId = ua.AppUserId,
                        ActivityType = ua.ActivityType,
                        Date = ua.DateSubmitted.AddHours(10).ToString("ddd, dd-MMM, HH:mm"),
                        ActivityName = DashboardProjectsHelpers.GetProject(ua.ProjectId).Title
                    })
                    .ToListAsync();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return null;
    }

    public async Task<List<AdminPendingDisplay>> GetAdminPendingProjects()
    {
        try
        {
            using (var context = _factory.CreateDbContext())
            {
                var projects = await context.DashboardProjects
                    .Include(p => p.AppUser)
                    .Where(p => !p.IsCompleted && !p.IsArchived)
                    .OrderByDescending(x => x.DateSubmitted)
                    .Select(ua => new AdminPendingDisplay
                    {
                        AppUserId = ua.AppUserId,
                        DashboardProjectId = ua.Id,
                        ProjectName = DashboardProjectsHelpers.GetProject(ua.ProjectId).Title,
                        DateSubmitted = ua.DateSubmitted.AddHours(10).ToString("ddd, dd-MMM, HH:mm"),
                        DateChangesRequested = ua.DateRequestedChange.AddHours(10).ToString("ddd, dd-MMM, HH:mm"),
                        UserName = ua.AppUser.UserName ?? ua.AppUser.DisplayName ?? ua.AppUser.Email
                    })
                    .ToListAsync();

                var pendingIds = projects.Select(x => x.DashboardProjectId);

                var reviews = await context.UserReviews
                    .AsSplitQuery()
                    .AsNoTracking()
                    .Include(x => x.User)
                    .Where(ur => pendingIds.Contains(ur.DashboardProjectId))
                    .ToListAsync();

                foreach (var project in projects)
                {
                    var review = reviews.FirstOrDefault(r => r.DashboardProjectId == project.DashboardProjectId);
                    project.ReviewerName = project.ReviewerName = review?.User?.UserName
                        ?? review?.User?.DisplayName
                        ?? review?.User?.Email
                        ?? "No Reviewer";
                }

                return projects;

            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return null;
    }

    public async Task<BaseResponse> RequestChanges(int dashboardProjectId)
    {
        try
        {
            using (var context = _factory.CreateDbContext())
            {
                var project = context.DashboardProjects.FirstOrDefault(p => p.Id == dashboardProjectId);

                if (project == null)
                {
                    return new BaseResponse
                    {
                        Status = ResponseStatus.Fail,
                        Message = "Project Not Found"
                    };
                }

                project.DateRequestedChange = DateTime.UtcNow;

                await context.SaveChangesAsync();
            }

            return new BaseResponse
            {
                Status = ResponseStatus.Success,
            };
        }
        catch (Exception ex)
        {
            return new BaseResponse
            {
                Status = ResponseStatus.Fail,
                Message = ex.Message
            };
        }
    }

    public async Task<List<ApplicationUser>> SearchUsers(string? email, string? userName, string? displayName, string? discordAlias)
    {
        await using var context = _factory.CreateDbContext();

        email = string.IsNullOrWhiteSpace(email) ? null : email.Trim();
        userName = string.IsNullOrWhiteSpace(userName) ? null : userName.Trim();
        discordAlias = string.IsNullOrWhiteSpace(discordAlias) ? null : discordAlias.Trim();
        displayName = string.IsNullOrWhiteSpace(displayName) ? null : displayName.Trim();

        if (email is null && userName is null && displayName is null && discordAlias is null)
            return new List<ApplicationUser>();

        IQueryable<ApplicationUser> query = context.AspNetUsers.AsNoTracking();

        if (email is not null)
            query = query.Where(u => EF.Functions.Like(u.Email!, $"%{email}%"));

        if (userName is not null)
            query = query.Where(u => EF.Functions.Like(u.UserName!, $"%{userName}%"));

        if (discordAlias is not null)
            query = query.Where(u => EF.Functions.Like(u.DiscordAlias!, $"%{discordAlias}%"));

        if (displayName is not null)
            query = query.Where(u => EF.Functions.Like(u.DisplayName!, $"%{displayName}%"));

        return await query.ToListAsync();
    }

}
