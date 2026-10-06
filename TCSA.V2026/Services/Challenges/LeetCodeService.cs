using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text.Json;
using TCSA.V2026.Data;
using TCSA.V2026.Data.DTOs.Challenges;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Data.Models.Responses;
using TCSA.V2026.Helpers.Constants;

namespace TCSA.V2026.Services.Challenges;

public class LeetCodeService : IChallengePlatformService
{
    private readonly IDbContextFactory<ApplicationDbContext> _factory;
    private readonly HttpClient _httpClient;

    public LeetCodeService(IDbContextFactory<ApplicationDbContext> factory, IHttpClientFactory httpClientFactory)
    {
        _factory = factory;
        _httpClient = httpClientFactory.CreateClient();
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

    public async Task<Result> SyncChallenge(SyncChallengeRequest request)
    {
        var username = request.PlatformCredentials.LeetCodeUsername;

        if (username == null)
        {
            return Result.Failure(new Error("LeetCode.AccountNotIntegrated", "You haven't integrated your LeetCode account yet. Go to your profile and add your LeetCode username."));
        }

        var apiRequest = new
        {
            query = ChallengePlatformConstants.LeetCode.Queries.GetRecentSubmissions,
            variables = new
            {
                username
            }
        };

        var response = await _httpClient.PostAsJsonAsync(
            ChallengePlatformConstants.LeetCode.GraphQLEndpoint,
            apiRequest
        );

        if (response.StatusCode != HttpStatusCode.OK)
        {
            return Result.Failure(new Error("LeetCode.ApiUnavailable", "Failed to connect to LeetCode API. Please try again later."));
        }

        string jsonResponse = await response.Content.ReadAsStringAsync();

        GraphQLResponse<RecentSubmissionResult>? apiResponse = JsonSerializer
            .Deserialize<GraphQLResponse<RecentSubmissionResult>>(
                jsonResponse,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );

        if (apiResponse?.Data == null || apiResponse.Errors?.Count > 0)
        {
            return Result.Failure(new Error("LeetCode.SubmissionsUnavailable", "Failed to retrieve your recent submissions from LeetCode. Contact support if the issue persists."));
        }

        if (!apiResponse.Data.RecentAcSubmissionList.Any(s => s.TitleSlug == request.ExternalId && s.StatusDisplay == "Accepted"))
        {
            return Result.Failure(new Error("LeetCode.ChallengeNotCompleted", "You haven't completed this challenge yet or it is not within the recent 20 submissions."));
        }

        try
        {
            await MarkChallengeAsCompleted(new MarkChallengeCompletedRequest(request.ChallengeId, request.UserId));

            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure(new Error("LeetCode.Unexpected", ex.Message));
        }
    }
}
