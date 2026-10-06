using Microsoft.EntityFrameworkCore;
using TCSA.V2026.Data;
using TCSA.V2026.Data.Enums;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Data.Models.Responses;
using TCSA.V2026.Helpers;

namespace TCSA.V2026.Services;

public interface ICommunityService
{
    Task<CommunityIssue> GetIssueByProjectId(int projectId);
    Task<List<CommunityIssue>> GetAvailableIssuesForCommunityPage(string appUserId);
    Task<Result> AssignUserToIssue(string appUserId, CommunityIssue issue);
    Task<Result> SubmitIssueToReview(int issueId, string githubUrl);
    Task<Result> CreateIssue(IssueType type, string issueUrl, string Title, CommunityProject communityProject);
}

public class CommunityService(IDbContextFactory<ApplicationDbContext> _factory) : ICommunityService
{
    public async Task<Result> CreateIssue(IssueType type, string issueUrl, string title, CommunityProject communityProject)
    {
        string iconUrl = type switch
        {
            IssueType.Translation => "icons8-foreign-language-66.png",
            IssueType.Bugfix => "icons8-insect-64.png",
            IssueType.Feature => "icons8-feature-64.png",
            IssueType.Infrastructure => "icons8-infrastructure-55.png"
        };

        if (!UrlHelper.IsValidCommunityProjectIssueUrl(issueUrl, communityProject))
        {
            return Result.Failure(new Error("Community.InvalidIssueUrl", "Invalid issue URL for the selected community project."));
        }

        try
        {
            using (var context = _factory.CreateDbContext())
            {
                var lastIssue = await context.Issues.OrderByDescending(x => x.ProjectId).Select(x => x.ProjectId).FirstOrDefaultAsync();
                int nextProjectId = lastIssue != 0 ? lastIssue + 1 : 1;

                var existingIssue = await context.Issues.FirstOrDefaultAsync(i => i.GithubUrl == issueUrl && i.CommunityProjectId == (int)communityProject);

                if (existingIssue != null)
                {
                    return Result.Failure(new Error("Community.IssueAlreadyExists", "Issue with the same URL already exists."));
                }

                var issue = new CommunityIssue
                {
                    GithubUrl = issueUrl,
                    Title = title,
                    Type = type,
                    IsClosed = false,
                    CommunityProjectId = (int)communityProject,
                    ExperiencePoints = 20,
                    IconUrl = iconUrl,
                    ProjectId = nextProjectId
                };

                context.Issues.Add(issue);

                await context.SaveChangesAsync();
            }

            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure(new Error("Community.Unexpected", ex.Message));
        }
    }

    public async Task<Result> AssignUserToIssue(string appUserId, CommunityIssue issue)
    {
        try
        {
            using (var context = _factory.CreateDbContext())
            {
                await context.DashboardProjects.AddAsync(new DashboardProject
                {
                    GithubUrl = string.Empty,
                    AppUserId = appUserId,
                    ProjectId = issue.ProjectId,
                });

                var dbIssue = await context.Issues.FirstOrDefaultAsync(x => x.ProjectId == issue.ProjectId);
                dbIssue.AppUserId = appUserId;

                await context.SaveChangesAsync();
            }

            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure(new Error("Community.Unexpected", ex.Message));
        }
    }
    public async Task<Result> SubmitIssueToReview(int issueId, string githubUrl)
    {
        try
        {
            using (var context = _factory.CreateDbContext())
            {
                var project = await context.DashboardProjects.FirstOrDefaultAsync(context => context.ProjectId == issueId);

                project.GithubUrl = githubUrl;
                project.IsPendingReview = true;
                project.DateSubmitted = DateTime.UtcNow;
                await context.SaveChangesAsync();
            }

            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure(new Error("Community.Unexpected", ex.Message));
        }
    }
    public async Task<List<CommunityIssue>> GetAvailableIssuesForCommunityPage(string appUserId)
    {
        try
        {
            using (var context = _factory.CreateDbContext())
            {
                return await context.Issues
                    .Where(i => !i.IsClosed)
                    .Where(i => string.IsNullOrEmpty(i.AppUserId) || i.AppUserId.Equals(appUserId))
                    .ToListAsync();
            }
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public async Task<CommunityIssue> GetIssueByProjectId(int projectId)
    {
        try
        {
            using (var context = _factory.CreateDbContext())
            {
                return await context.Issues.FirstOrDefaultAsync(x => x.ProjectId == projectId);
            }
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}
