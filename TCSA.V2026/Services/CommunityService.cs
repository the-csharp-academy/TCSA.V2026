using Microsoft.EntityFrameworkCore;
using TCSA.V2026.Data;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Data.Models.Responses;

namespace TCSA.V2026.Services;

public interface ICommunityService
{
    Task<CommunityIssue> GetIssueByProjectId(int projectId);
    Task<List<CommunityIssue>> GetAvailableIssuesForCommunityPage(string appUserId);
    Task<BaseResponse> AssignUserToIssue(string appUserId, CommunityIssue issue);
    Task<BaseResponse> SubmitIssueToReview(int issueId, string githubUrl);
    Task<BaseResponse> CreateIssue(IssueType type, string issueUrl, string Title, string userId);
}

public class CommunityService(IDbContextFactory<ApplicationDbContext> _factory) : ICommunityService
{
    public async Task<BaseResponse> CreateIssue(IssueType type, string issueUrl, string title, string userId)
    {
        string iconUrl = type switch
        {
            IssueType.Translation => "icons8-foreign-language-66.png",
            IssueType.Bugfix => "icons8-insect-64.png",
            IssueType.Feature => "icons8-feature-64.png",
            IssueType.Infrastructure => "icons8-infrastructure-55.png"
        };

        var result = new BaseResponse();
        try
        {
            using (var context = _factory.CreateDbContext())
            {
                var lastIssue = await context.Issues.OrderByDescending(x => x.ProjectId).Select(x => x.ProjectId).FirstOrDefaultAsync();
                int nextProjectId = lastIssue != 0 ? lastIssue + 1 : 1;

                var existingIssue = await context.Issues.FirstOrDefaultAsync(i => i.GithubUrl == issueUrl);

                if (existingIssue != null)
                {
                    result.Status = ResponseStatus.Fail;
                    result.Message = "Issue with the same URL already exists.";
                    return result;
                }

                var issue = new CommunityIssue
                {
                    GithubUrl = issueUrl,
                    Title = title,
                    Type = type,
                    IsClosed = false,
                    CommunityProjectId = 207,
                    ExperiencePoints = 20,
                    IconUrl = iconUrl,
                    ProjectId = nextProjectId
                };

                context.Issues.Add(issue);

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

    public async Task<BaseResponse> AssignUserToIssue(string appUserId, CommunityIssue issue)
    {
        var result = new BaseResponse();
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

            return result;
        }
        catch (Exception ex)
        {
            result.Message = ex.Message;
            result.Status = ResponseStatus.Fail;
            return result;
        }
    }
    public async Task<BaseResponse> SubmitIssueToReview(int issueId, string githubUrl)
    {
        var result = new BaseResponse();
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

            return result;
        }
        catch (Exception ex)
        {
            result.Message = ex.Message;
            result.Status = ResponseStatus.Fail;
            return result;
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
