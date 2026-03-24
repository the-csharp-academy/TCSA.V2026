using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text.Json;
using TCSA.V2026.Data;
using TCSA.V2026.Data.DTOs;
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

    public async Task<BaseResponse> SyncChallenge(SyncChallengeRequest request)
    {
        var result = new BaseResponse();
        var username = request.PlatformCredentials.LeetCodeUsername;

        if (username == null)
        {
            result.Status = ResponseStatus.Fail;
            result.Message = "You haven't integrated your LeetCode account yet. Go to your profile and add your LeetCode username.";
            return result;
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
            result.Status = ResponseStatus.Fail;
            result.Message = "Failed to connect to LeetCode API. Please try again later.";
            return result;
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
            result.Status = ResponseStatus.Fail;
            result.Message = "Failed to retrieve your recent submissions from LeetCode. Contact support if the issue persists.";
            return result;
        }

        if (apiResponse.Data.RecentAcSubmissionList.Any(s => s.TitleSlug == request.ExternalId && s.StatusDisplay == "Accepted"))
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
            result.Message = "You haven't completed this challenge yet or it is not within the recent 20 submissions.";
            return result;
        }
    }
}
