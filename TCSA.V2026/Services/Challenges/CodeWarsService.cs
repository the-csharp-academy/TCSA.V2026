using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text.Json;
using TCSA.V2026.Data;
using TCSA.V2026.Data.DTOs.Challenges;
using TCSA.V2026.Data.Helpers.ProjectsSubHelpers;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Data.Models.Responses;
using TCSA.V2026.Models.Responses;

namespace TCSA.V2026.Services.Challenges;

public interface ICodewarsService
{
    Task<int> MarkSqlProjectAsCompleted(int projectId, string userId);
    Task<Result<List<CodeWarsChallenge>>> GetCodeWarsCompletedChallenges(string? username, List<CodeWarsChallenge> challenges, CancellationToken cancellationToken = default);
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
    public async Task<Result<List<CodeWarsChallenge>>> GetCodeWarsCompletedChallenges(string userId, List<CodeWarsChallenge> challenges, CancellationToken cancellationToken = default)
    {
        var alias = string.Empty;

        using (var context = _factory.CreateDbContext())
        {
            alias = await context.AspNetUsers
                .Where(x => x.Id == userId)
                .Select(x => x.CodeWarsUsername)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);
        }

        if (string.IsNullOrEmpty(alias))
        {
            return Result.Failure<List<CodeWarsChallenge>>(new Error("CodeWars.AccountNotIntegrated", "You haven't integrated your Codewars account yet. Complete your profile with your Codewars username."));
        }

        var result = await GetCompletedIdsAcrossPagesAsync(alias, challenges.Select(c => c.Id), cancellationToken);

        if (result.IsFailure) return Result.Failure<List<CodeWarsChallenge>>((Error)result.Reason);

        foreach (var challenge in challenges)
            challenge.IsCompleted = result.Value.Contains(challenge.Id);

        return Result.Success(challenges);
    }

    public async Task<Result> SyncChallenge(SyncChallengeRequest request)
    {
        var username = request.PlatformCredentials.CodeWarsUsername;

        if (username == null)
        {
            return Result.Failure(new Error("CodeWars.AccountNotIntegrated", "You haven't integrated your Codewars account yet. Go to the dashboard and click on 'Codewars Integration'"));
        }

        var result = await GetCompletedIdsAcrossPagesAsync(username, [request.ExternalId], default);

        if (result.IsFailure)
        {
            return Result.Failure((Error)result.Reason);
        }

        if (!result.Value.Contains(request.ExternalId))
        {
            return Result.Failure(new Error("CodeWars.ChallengeNotCompleted", "You haven't completed this challenge yet."));
        }

        try
        {
            await MarkChallengeAsCompleted(new MarkChallengeCompletedRequest(request.ChallengeId, request.UserId));

            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure(new Error("CodeWars.Unexpected", ex.Message));
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

    private async Task<Result<HashSet<string>>> GetCompletedIdsAcrossPagesAsync(string username, IEnumerable<string> idsToFind, CancellationToken cancellationToken)
    {
        var pending = idsToFind.ToHashSet();
        var completed = new HashSet<string>();
        int page = 0;
        int totalPages;

        do
        {
            var response = await _httpClient.GetAsync($"https://www.codewars.com/api/v1/users/{username}/code-challenges/completed?page={page}", cancellationToken);

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return Result.Failure<HashSet<string>>(new Error("CodeWars.UsernameNotFound", "Username not found. Go to the dashboard and click on 'Codewars Integration' to update your username."));
            }

            if (response.StatusCode != HttpStatusCode.OK)
            {
                return Result.Failure<HashSet<string>>(new Error("CodeWars.UnexpectedResponse", "Could not retrieve your completed challenges from Codewars. Please try again later."));
            }

            string jsonResponse = await response.Content.ReadAsStringAsync(cancellationToken);
            var apiResponse = JsonSerializer.Deserialize<CodeWarsApiResponse>(jsonResponse);

            foreach (var item in apiResponse.data)
            {
                if (pending.Remove(item.id))
                    completed.Add(item.id);
            }

            totalPages = apiResponse.totalPages;
            page++;
        } while (pending.Count > 0 && page < totalPages);

        return Result.Success(completed);
    }
}