using Microsoft.EntityFrameworkCore;
using System.Data;
using TCSA.V2026.Data;
using TCSA.V2026.Data.Curriculum;
using TCSA.V2026.Data.DTOs;
using TCSA.V2026.Data.Enums;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Data.Models.Responses;
using TCSA.V2026.Helpers;

namespace TCSA.V2026.Services;

public interface IPeerReviewService
{
    Task<List<CodeReviewDetail>> GetCodeReviewDetails(string userId);
    Task<ApplicationUser> GetUserForPeerReview(string reviewerId);
    Task<List<PeerReviewDisplay>> GetProjectsForPeerReview(string userId);
    Task<BaseResponse> AssignUserToCodeReview(string userId, int id);
    Task<BaseResponse> ReleaseUserFromCodeReview(string userId, int id);
    Task<BaseResponse> MarkCodeReviewAsCompleted(string reviewerId, int dashboardProjectId);
}
public class PeerReviewService(IDbContextFactory<ApplicationDbContext> _factory) : IPeerReviewService
{
    public async Task<BaseResponse> AssignUserToCodeReview(string userId, int id)
    {
        var result = new BaseResponse();

        try
        {
            using (var context = _factory.CreateDbContext())
            {
                await context.UserReviews.AddAsync(new UserReview
                {
                    AppUserId = userId,
                    DashboardProjectId = id
                });

                await context.SaveChangesAsync();
            }

            return result;
        }
        catch (Exception ex)
        {
            result.Message = ex.Message;
            result.Status = ResponseStatus.Fail;
            return result;
        }
    }

    public async Task<BaseResponse> ReleaseUserFromCodeReview(string userId, int id)
    {
        var result = new BaseResponse();

        try
        {
            using (var context = _factory.CreateDbContext())
            {
                var userReview = await context.UserReviews
                    .FirstOrDefaultAsync(x => x.AppUserId == userId && x.DashboardProjectId == id);

                if (userReview is null)
                {
                    result.Message = "User is Null";
                    result.Status = ResponseStatus.Fail;
                    return result;
                }

                context.UserReviews.Remove(userReview);
                await context.SaveChangesAsync();
            }

            return result;
        }
        catch (Exception ex)
        {
            result.Message = ex.Message;
            result.Status = ResponseStatus.Fail;
            return result;
        }
    }

    public async Task<ApplicationUser> GetUserForPeerReview(string reviewerId)
    {
        try
        {
            using (var context = _factory.CreateDbContext())
            {
                return await context.AspNetUsers
                    .Include(x => x.CodeReviewProjects)
                    .FirstOrDefaultAsync(x => x.Id.Equals(reviewerId));
            }
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public async Task<List<PeerReviewDisplay>> GetProjectsForPeerReview(string userId)
    {
        var validUrls = new[]
        {
            "https://github.com/the-csharp-academy/CodeReviews",
            "https://github.com/TheCSharpAcademy/CodeReviews"
        };

        try
        {
            using (var context = _factory.CreateDbContext())
            {
                var user = await context.AspNetUsers
                    .AsNoTracking()
                    .Include(x => x.CodeReviewProjects)
                    .Include(x => x.DashboardProjects.Where(dp => dp.IsCompleted))
                    .FirstOrDefaultAsync(x => x.Id.Equals(userId));

                if (user.Level < Level.Yellow)
                {
                    return new List<PeerReviewDisplay> { };
                }

                List<int> eligibleProjectIds =
                    PeerReviewHelpers.DetermineReviewableProjectIds(user.Level, user.DashboardProjects.Select(dp => dp.ProjectId));

                var assignedProjectIds = context.UserReviews
                    .Where(x => x.AppUserId != user.Id)
                    .Select(x => x.DashboardProjectId);

                var projects = await context.DashboardProjects
                    .AsNoTracking()
                    .Include(x => x.AppUser)
                    .Where(x => x.IsPendingReview
                        && eligibleProjectIds.Contains(x.ProjectId)
                        && !assignedProjectIds.Contains(x.Id)
                        && (x.GithubUrl.StartsWith(validUrls[0]) || x.GithubUrl.StartsWith(validUrls[1])))
                    .OrderBy(x => x.DateSubmitted)
                    .ToListAsync();

                var reviewedIds = new HashSet<int>(user.CodeReviewProjects.Select(x => x.DashboardProjectId));
                return PeerReviewHelpers.MapPeerReviewDisplays(projects, reviewedIds);
            }
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public async Task<List<CodeReviewDetail>> GetCodeReviewDetails(string userId)
    {
        try
        {
            using (var context = _factory.CreateDbContext())
            {
                var result = await context.UserReviews
                    .Where(x => x.AppUserId == userId)
                    .Select(review => new
                    {
                        review.DashboardProject.ProjectId,
                        review.DashboardProject.IsCompleted,
                        review.DashboardProject.IsArchived,
                        review.DashboardProject.GithubUrl,
                        review.DashboardProject.Id,
                        UserName = review.DashboardProject.AppUser.FirstName + " " + review.DashboardProject.AppUser.LastName
                    })
                    .Where(project => project.ProjectId != null)
                    .Select(project => new CodeReviewDetail
                    {
                        ProjectId = project.ProjectId,
                        IsCompleted = project.IsCompleted || project.IsArchived,
                        UserName = project.UserName,
                        GithubUrl = project.GithubUrl,
                        DashboardProjectId = project.Id
                    })
                    .ToListAsync();

                return result;
            }
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public async Task<BaseResponse> MarkCodeReviewAsCompleted(string reviewerId, int dashboardProjectId)
    {
        var result = new BaseResponse();

        try
        {
            using (var context = _factory.CreateDbContext())
            {
                var reviewer = context.Users
                    .Include(x => x.UserActivity.Where(x => x.ActivityType == ActivityType.CodeReviewCompleted))
                    .FirstOrDefault(x => x.Id == reviewerId);

                var reviewedProjects = reviewer.UserActivity;

                var dashboardProject = await context.DashboardProjects
                    .Include(dp => dp.AppUser)
                    .FirstOrDefaultAsync(x => x.Id == dashboardProjectId);

                var academyProject = ProjectHelper.GetProjects().FirstOrDefault(x => x.Id == dashboardProject.ProjectId);

                dashboardProject.IsPendingReview = false;
                dashboardProject.IsPendingNotification = true;
                dashboardProject.IsCompleted = true;
                dashboardProject.DateCompleted = DateTime.UtcNow;

                context.UserActivity.AddRange(
                    new AppUserActivity
                    {
                        ProjectId = dashboardProject.ProjectId,
                        AppUserId = dashboardProject.AppUserId,
                        DateSubmitted = DateTime.UtcNow,
                        ActivityType = ActivityType.ProjectCompleted
                    },
                    new AppUserActivity
                    {
                        ProjectId = dashboardProject.ProjectId,
                        AppUserId = reviewerId,
                        DateSubmitted = DateTime.UtcNow,
                        ActivityType = ActivityType.CodeReviewCompleted
                    }
                );

                if (reviewer != null
                    && reviewedProjects != null
                    && reviewer.ReviewExperiencePoints == 0
                    && reviewedProjects.Count > 0)
                {
                    //This has to be retroactive, so if some user has reviews but no points, it will calculate them first.
                    //This is the same as the leaderboard calculation, but just in case the leaderboard calculation is never done and some user escapes the check, we make sure that the points are set here.
                    foreach (AppUserActivity review in reviewedProjects)
                    {
                        var reviewAcademyProject = ProjectHelper.GetProjects().FirstOrDefault(x => x.Id == review.ProjectId);

                        reviewer.ReviewExperiencePoints = reviewer.ReviewExperiencePoints + reviewAcademyProject.ExperiencePoints;
                    }
                    //If reviewer has no experience points set, that means the reviewedProjects column is also not set yet.
                    reviewer.ReviewedProjects = reviewedProjects.Count;
                }

                dashboardProject.AppUser.ExperiencePoints = dashboardProject.AppUser.ExperiencePoints + academyProject.ExperiencePoints;
                reviewer.ExperiencePoints = reviewer.ExperiencePoints + academyProject.ExperiencePoints;
                reviewer.ReviewedProjects = reviewer.ReviewedProjects + 1;

                await context.SaveChangesAsync();

                return result;
            }
        }
        catch (Exception ex)
        {
            result.Message = ex.Message;
            result.Status = ResponseStatus.Fail;
            return result;
        }
    }
}
