using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using TCSA.V2026.Data;
using TCSA.V2026.Data.Curriculum;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Data.Models.Responses;
using TCSA.V2026.Helpers;

namespace TCSA.V2026.Services;

public interface IProjectService
{
    Task<BaseResponse> MarkAsCompleted(int projectId);
    Task<bool> IsProjectCompleted(string userId, int projectId);
    Task<List<int>> GetCompletedProjectsById(string userId);
    Task<BaseResponse> PostArticle(int projectId, string userId, string url, bool isArticle, bool isUpdate);
    Task<BaseResponse> DeleteProject(int dashboardProjectId, string userId);
    Task<BaseResponse> Archive(int dashboardProjectId);
    Task<BaseResponse> AcknowledgeNotifications(string userId);
    Task<int> GetCompletionCount(int projectId, bool isArticle);

}

public class ProjectService(IDbContextFactory<ApplicationDbContext> _factory) : IProjectService
{
    public async Task<BaseResponse> AcknowledgeNotifications(string userId)
    {
        try
        {
            using (var context = _factory.CreateDbContext())
            {
                var projects = context.DashboardProjects
                    .Where(p => p.AppUserId == userId)
                    .Where(p => p.IsPendingNotification)
                    .ToList();

                foreach (var p in projects)
                {
                    p.IsPendingNotification = false;
                }

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

    public async Task<BaseResponse> DeleteProject(int dashboardProjectId, string userId)
    {
        try
        {
            using (var context = _factory.CreateDbContext())
            {
                var project = context.DashboardProjects
                    .FirstOrDefault(p => p.Id == dashboardProjectId);

                if (project == null)
                {
                    return new BaseResponse
                    {
                        Status = ResponseStatus.Fail,
                        Message = "Project Not Found"
                    };
                }

                var activity = context.UserActivity.Where(a => a.AppUserId == userId && a.ProjectId == project.ProjectId);

                context.DashboardProjects.Remove(project);
                context.UserActivity.RemoveRange(activity);

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

    public async Task<BaseResponse> Archive(int dashboardProjectId)
    {
        try
        {
            using (var context = _factory.CreateDbContext())
            {
                var reviewProject = await context.UserReviews
                    .Include(r => r.DashboardProject)
                    .Include(r => r.User)
                        .ThenInclude(u => u.UserActivity)
                    .FirstOrDefaultAsync(x => x.DashboardProjectId == dashboardProjectId);

                if (reviewProject == null)
                {
                    return new BaseResponse
                    {
                        Status = ResponseStatus.Fail,
                        Message = "Project Not Found"
                    };
                }

                var academyProject = ProjectHelper.GetProjects().FirstOrDefault(x => x.Id == reviewProject.DashboardProject.ProjectId);

                reviewProject.DashboardProject.IsArchived = true;
                reviewProject.DashboardProject.IsPendingReview = false;
                reviewProject.User.UserActivity.Add(new AppUserActivity
                {
                    ProjectId = reviewProject.DashboardProject.ProjectId,
                    AppUserId = reviewProject.AppUserId,
                    DateSubmitted = DateTime.UtcNow,
                    ActivityType = ActivityType.CodeReviewCompleted
                });
                reviewProject.User.ExperiencePoints = reviewProject.User.ExperiencePoints + academyProject.ExperiencePoints;

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

    public async Task<List<int>> GetCompletedProjectsById(string userId)
    {
        try
        {
            using (var context = _factory.CreateDbContext())
            {
                return await context.DashboardProjects
                    .Where(x => x.AppUserId == userId && x.IsCompleted)
                    .Select(x => x.ProjectId)
                    .ToListAsync();
            }
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public async Task<BaseResponse> PostArticle(int projectId, string userId, string url, bool isArticle, bool isUpdate)
    {
        var project = DashboardProjectsHelpers.GetProject(projectId);

        try
        {
            using (var context = _factory.CreateDbContext())
            {
                var user = await context.Users
                    .Include(u => u.UserActivity)
                    .Include(u => u.DashboardProjects)
                    .FirstOrDefaultAsync(u => u.Id == userId);

                var dashboardProject = user?.DashboardProjects?.FirstOrDefault
                (dp => dp.ProjectId == projectId && dp.AppUserId == userId && !dp.IsArchived);

                if (isUpdate)
                {
                    dashboardProject!.GithubUrl = url;
                    await context.SaveChangesAsync();
                    return new BaseResponse();
                }

                if (user != null && user.DashboardProjects != null && dashboardProject == null)
                {
                    var newProject = new DashboardProject
                    {
                        ProjectId = projectId,
                        AppUserId = userId,
                        IsCompleted = isArticle ? true : false,
                        IsArchived = false,
                        IsPendingNotification = false,
                        IsPendingReview = isArticle ? false : true,
                        DateSubmitted = DateTime.UtcNow,
                        GithubUrl = url
                    };

                    var trackedEntity = context.ChangeTracker.Entries<DashboardProject>().FirstOrDefault(e => e.Entity.ProjectId == newProject.ProjectId);

                    if (trackedEntity != null)
                    {
                        trackedEntity.State = EntityState.Detached;
                    }

                    await context.DashboardProjects.AddAsync(newProject);

                    await context.UserActivity.AddAsync(
                      new AppUserActivity
                      {
                          ProjectId = projectId,
                          AppUserId = userId,
                          DateSubmitted = DateTime.UtcNow,
                          ActivityType = isArticle ? ActivityType.ArticleRead : ActivityType.ProjectSubmitted
                      });

                    if (isArticle)
                    {
                        user.ExperiencePoints = user.ExperiencePoints + project.ExperiencePoints;
                    }

                    await context.SaveChangesAsync();
                };
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

        return new BaseResponse();
    }

    public async Task<bool> IsProjectCompleted(string userId, int projectId)
    {
        try
        {
            using (var context = _factory.CreateDbContext())
            {
                return await context.DashboardProjects
                    .AnyAsync(
                        x => x.IsCompleted
                        && x.ProjectId == projectId
                        && x.AppUserId == userId
                    );
            }
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<BaseResponse> MarkAsCompleted(int projectId)
    {
        try
        {
            using (var context = _factory.CreateDbContext())
            {
                var project = context.DashboardProjects
                    .Include(dp => dp.AppUser)
                    .FirstOrDefault(p => p.Id == projectId);

                if (project == null)
                {
                    return new BaseResponse
                    {
                        Status = ResponseStatus.Fail,
                        Message = "Project Not Found"
                    };
                }

                project.IsCompleted = true;
                project.IsPendingReview = false;
                project.DateCompleted = DateTime.UtcNow;
                project.IsPendingNotification = true;

                int experiencePoints;
                var dashboardProject = DashboardProjectsHelpers.GetProject(project.ProjectId);

                if (dashboardProject == null)
                {
                    var issue = await context.Issues.FirstOrDefaultAsync(x => x.ProjectId == project.ProjectId);
                    experiencePoints = issue.ExperiencePoints;   
                    issue.IsClosed = true;
                } 
                else
                {
                    experiencePoints = dashboardProject.ExperiencePoints;
                }

                context.UserActivity.Add(new AppUserActivity
                {
                    AppUserId = project.AppUser.Id,
                    ProjectId = project.ProjectId,
                    DateSubmitted = DateTime.UtcNow,
                    ActivityType = ActivityType.ProjectCompleted
                });

                context.Users.Attach(project.AppUser);
                project.AppUser.ExperiencePoints += experiencePoints;
                context.Entry(project.AppUser).Property(u => u.ExperiencePoints).IsModified = true;

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

    public async Task<int> GetCompletionCount(int projectId, bool isArticle)
    {
        try
        {
            using (var context = _factory.CreateDbContext())
            {
                var activityType = isArticle ? ActivityType.ArticleRead : ActivityType.ProjectCompleted;
                return await context.UserActivity
                    .CountAsync(x => x.ProjectId == projectId && x.ActivityType == activityType);
            }
        }
        catch (Exception ex)
        {
            return 0;
        }
    }
}

