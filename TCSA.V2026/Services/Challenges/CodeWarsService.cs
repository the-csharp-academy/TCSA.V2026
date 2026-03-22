using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text.Json;
using TCSA.V2026.Data;
using TCSA.V2026.Data.DTOs;
using TCSA.V2026.Data.Helpers.ProjectsSubHelpers;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Data.Models.Responses;
using TCSA.V2026.Models.Responses;

namespace TCSA.V2026.Services.Challenges;

public interface ICodewarsService
{
    Task<int> MarkSqlProjectAsCompleted(int projectId, string userId);
    Task<CodeWarsResponse> GetCodeWarsCompletedChallenges(string? username, List<CodeWarsChallenge> challenges);
}

public class CodewarsService : ICodewarsService, IChallengePlatformService
{
    private readonly IDbContextFactory<ApplicationDbContext> _factory;
    private readonly HttpClient _httpClient;

    public CodewarsService(IDbContextFactory<ApplicationDbContext> factory, IHttpClientFactory httpClientFactory)
    {
        _factory = factory;
        _httpClient = httpClientFactory.CreateClient();
    }

    // This checks if challenges from the SQL area were completed on CodeWars, it's called from Project Page (provided it's a SQL project). 
    public async Task<CodeWarsResponse> GetCodeWarsCompletedChallenges(string userId, List<CodeWarsChallenge> challenges)
    {
        var codeWarsResponse = new CodeWarsResponse();
        var alias = string.Empty;

        using (var context = _factory.CreateDbContext())
        {
            alias = await context.AspNetUsers
                .Where(x => x.Id == userId)
                .Select(x => x.CodeWarsUsername)
                .FirstOrDefaultAsync();

            if (string.IsNullOrEmpty(alias))
            {
                codeWarsResponse.Status = ResponseStatus.Fail;
                codeWarsResponse.Message = "You haven't integrated your Codewars account yet. Complete your profile with your Codewars username.";
                codeWarsResponse.Challenges = new List<CodeWarsChallenge>();
                return codeWarsResponse;
            }
        }

        string apiUrl = $"https://www.codewars.com/api/v1/users/{alias}/code-challenges/completed?";

        HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            codeWarsResponse.Status = ResponseStatus.Fail;
            codeWarsResponse.Message = "Username not found. Go to the dashboard and click on 'Codewars Integration' to update your username.";
            codeWarsResponse.Challenges = new List<CodeWarsChallenge>();
            return codeWarsResponse;
        }

        string jsonResponse = await response.Content.ReadAsStringAsync();
        CodeWarsApiResponse apiResponse = JsonSerializer.Deserialize<CodeWarsApiResponse>(jsonResponse);

        var completedChallenges = apiResponse.data.Select(x => x.id).ToList();

        foreach (var challenge in challenges)
        {
            challenge.IsCompleted = completedChallenges.Contains(challenge.Id);
        }

        if (response.StatusCode == HttpStatusCode.OK)
        {
            codeWarsResponse.Status = ResponseStatus.Success;
            codeWarsResponse.Challenges = challenges;
        }

        return codeWarsResponse;
    }

    public async Task<BaseResponse> SyncChallenge(SyncChallengeRequest request)
    {
        var result = new BaseResponse();
        var username = request.PlatformCredentials.CodeWarsUsername;

        if (username == null)
        {
            result.Status = ResponseStatus.Fail;
            result.Message = "You haven't integrated your Codewars account yet. Go to the dashboard and click on 'Codewars Integration'";
            return result;
        }

        string apiUrl = $"https://www.codewars.com/api/v1/users/{username}/code-challenges/completed?";

        HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            result.Status = ResponseStatus.Fail;
            result.Message = "Username not found. Go to the dashboard and click on 'Codewars Integration' to update your username.";
            return result;
        }

        string jsonResponse = await response.Content.ReadAsStringAsync();
        CodeWarsApiResponse apiResponse = JsonSerializer.Deserialize<CodeWarsApiResponse>(jsonResponse);

        if (apiResponse.data.Any(x => x.id == request.ExternalId))
        {
            try
            {
                await MarkChallengeAsCompleted(new MarkChallengeCompletedRequest(request.ChallengeId, request.UserId));

                return result;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Status = ResponseStatus.Fail;
                return result;
            }
        }
        else
        {
            result.Status = ResponseStatus.Fail;
            result.Message = "You haven't completed this challenge yet.";
            return result;
        }
    }

    public async Task MarkChallengeAsCompleted(MarkChallengeCompletedRequest request)
    {
        using (var context = _factory.CreateDbContext())
        {
            var project = context.UserChallenges.Add(new UserChallenge
            {
                UserId = request.UserId,
                ChallengeId = request.ChallengeId,
                CompletedAt = DateTime.UtcNow
            });

            var user = await context.AspNetUsers
                .Where(x => x.Id == request.UserId)
                .FirstOrDefaultAsync();

            var challenge = await context.Challenges
                .Where(c => c.Id == request.ChallengeId)
                .FirstOrDefaultAsync();

            user.ExperiencePoints += challenge.ExperiencePoints;

            await context.SaveChangesAsync();
        }
    }

    public async Task<int> MarkSqlProjectAsCompleted(int projectId, string userId)
    {
        var project = SqlProjectsHelper.GetProjects().FirstOrDefault(x => x.Id == projectId);

        using (var context = _factory.CreateDbContext())
        {
            var user = await context.AspNetUsers
                .Include(u => u.DashboardProjects)
                .Include(u => u.UserActivity)
                .Where(x => x.Id == userId)
                .FirstOrDefaultAsync();

            var dashboardProject = new DashboardProject
            {
                ProjectId = projectId,
                AppUserId = userId,
                DateSubmitted = DateTime.UtcNow,
                IsCompleted = true,
                IsPendingNotification = true,
                IsPendingReview = false,
                DateRequestedChange = DateTime.UtcNow,
                GithubUrl = "Not applicable"
            };

            user.DashboardProjects
                .Add(dashboardProject);

            user.UserActivity.Add(new AppUserActivity
            {
                ProjectId = projectId,
                AppUserId = userId,
                DateSubmitted = DateTime.UtcNow,
                ActivityType = ActivityType.ProjectCompleted
            });

            user.ExperiencePoints += project.ExperiencePoints;

            return await context.SaveChangesAsync();
        }
    }
}