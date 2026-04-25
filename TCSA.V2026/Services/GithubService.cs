using Microsoft.EntityFrameworkCore;
using TCSA.V2026.Data;
using TCSA.V2026.Data.Curriculum;
using TCSA.V2026.Data.DTOs;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Data.Models.Responses;
using TCSA.V2026.Helpers;

namespace TCSA.V2026.Services;

public interface IGithubService
{
    Task<BaseResponse> MarkAsCompleted(PullRequestReviewDto pullRequestReviewDto);
    Task<BaseResponse> ProcessPullRequest(PullRequestDto pullRequestDto);
}

public class GithubService(IDbContextFactory<ApplicationDbContext> _factory) : IGithubService
{
    public async Task<BaseResponse> ProcessPullRequest(PullRequestDto pullRequestDto)
    {
        if (!pullRequestDto.Action.Equals("opened"))
        {
            return new BaseResponse
            {
                Status = ResponseStatus.Fail,
                Message = "Pull request action is not 'opened'."
            };
        }

        var projectId = GithubHelper.GetProjectId(pullRequestDto.Repository.Id);

        if (projectId == 0)
        {
            return new BaseResponse
            {
                Status = ResponseStatus.Fail,
                Message = "Repository can't be mapped."
            };
        }

        using (var context = _factory.CreateDbContext())
        {
            var fuckingName = "TheCSharpAcademy";
            var user = await context.AspNetUsers
                .Include(u => u.DashboardProjects)
                .FirstOrDefaultAsync(u => u.GithubUsername.Trim().ToLower() == pullRequestDto.PullRequest.User.Login.Trim().ToLower());

            if (user == null)
            {
                return new BaseResponse
                {
                    Status = ResponseStatus.Fail,
                    Message = "No user found with the provided GitHub username."
                };
            }

            var projectExists = user.DashboardProjects.Any(x => x.ProjectId == projectId && !x.IsArchived);

            if (!projectExists)
            {
                await context.DashboardProjects.AddAsync(
                    new DashboardProject
                    {
                        ProjectId = projectId,
                        AppUserId = user.Id,
                        GithubUrl = pullRequestDto.PullRequest.HtmlUrl,
                        DateSubmitted = DateTime.UtcNow,
                        IsArchived = false,
                        IsCompleted = false,
                        IsPendingNotification = false,
                        IsPendingReview = true
                    });

                await context.UserActivity.AddAsync(
                    new AppUserActivity
                    {
                        ProjectId = projectId,
                        AppUserId = user.Id,
                        DateSubmitted = DateTime.UtcNow,
                        ActivityType = ActivityType.ProjectSubmitted
                    });

                await context.SaveChangesAsync();
            }
        }

        return new BaseResponse
        {
            Status = ResponseStatus.Success,
            Message = "Pull request processed successfully."
        };
    }

    public async Task<BaseResponse> MarkAsCompleted(PullRequestReviewDto pullRequestReviewDto)
    {
        if (!pullRequestReviewDto.Review.State.Equals("approved"))
        {
            return new BaseResponse
            {
                Status = ResponseStatus.Fail,
                Message = "Pull request action is not 'approved'."
            };
        }

        var projectId = GithubHelper.GetProjectId(pullRequestReviewDto.Repository.Id);

        if (projectId == 0)
        {
            return new BaseResponse
            {
                Status = ResponseStatus.Fail,
                Message = "Repository can't be mapped."
            };
        }

        try
        {
            var projectDefinition = ProjectHelper.GetProjects().FirstOrDefault(p => p.Id == projectId);

            if (projectDefinition is null)
            {
                return new BaseResponse
                {
                    Status = ResponseStatus.Fail,
                    Message = "Project definition not found."
                };
            }

            var points = projectDefinition.ExperiencePoints;

            using (var context = _factory.CreateDbContext())
            {
                var project = await context.DashboardProjects
                    .Include(p => p.AppUser)
                       .ThenInclude(u => u.UserActivity)
                    .FirstOrDefaultAsync(p => p.ProjectId == projectId && p.GithubUrl.Contains(pullRequestReviewDto.PullRequest.Number.ToString()));

                if (project == null)
                {
                    return new BaseResponse
                    {
                        Status = ResponseStatus.Fail,
                        Message = "Project submission not found for this pull request."
                    };
                }

                if (project.IsCompleted)
                {
                    return new BaseResponse
                    {
                        Status = ResponseStatus.Success,
                        Message = "Pull request was already processed as completed."
                    };
                }

                project.IsPendingNotification = true;
                project.IsPendingReview = false;
                project.IsCompleted = true;
                project.DateCompleted = DateTimeOffset.UtcNow;

                project.AppUser.ExperiencePoints = project.AppUser.ExperiencePoints + points;
                project.AppUser.UserActivity.Add(new AppUserActivity
                {
                    ActivityType = ActivityType.ProjectCompleted,
                    ProjectId = project.ProjectId,
                    DateSubmitted = DateTimeOffset.UtcNow
                });

                var review = await context.UserReviews
                    .Include(x => x.User)
                        .ThenInclude(u => u.UserActivity)
                    .FirstOrDefaultAsync(r => r.DashboardProjectId == project.Id);

                if (review != null)
                {
                    review.User.ExperiencePoints = review.User.ExperiencePoints + points;
                    review.User.ReviewedProjects = review.User.ReviewedProjects + 1;
                    review.User.ReviewExperiencePoints = review.User.ReviewExperiencePoints + points;
                    review.User.UserActivity.Add(new AppUserActivity
                    {
                        ActivityType = ActivityType.CodeReviewCompleted,
                        ProjectId = project.ProjectId,
                        DateSubmitted = DateTimeOffset.UtcNow
                    });
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
}
