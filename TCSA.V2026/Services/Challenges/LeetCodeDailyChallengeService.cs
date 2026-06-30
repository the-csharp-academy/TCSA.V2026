using System.Net;
using System.Text.Json;
using System.Text.RegularExpressions;
using TCSA.V2026.Data.Enums;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Data.Models.Responses;
using TCSA.V2026.Helpers.Constants;

namespace TCSA.V2026.Services.Challenges;

public class LeetCodeDailyChallengeService : IDailyChallengeFetchService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<LeetCodeDailyChallengeService> _logger;

    public LeetCodeDailyChallengeService(IHttpClientFactory httpClientFactory, ILogger<LeetCodeDailyChallengeService> logger)
    {
        _httpClient = httpClientFactory.CreateClient();
        _logger = logger;
    }

    public async Task<Challenge?> FetchDailyChallenge()
    {
        try
        {
            var apiRequest = new { query = ChallengePlatformConstants.LeetCode.Queries.GetDailyChallenge };

            var response = await _httpClient.PostAsJsonAsync(
                ChallengePlatformConstants.LeetCode.GraphQLEndpoint,
                apiRequest
            );

            if (!response.IsSuccessStatusCode)
                return null;

            var json = await response.Content.ReadAsStringAsync();

            var apiResponse = JsonSerializer.Deserialize<GraphQLResponse<LeetCodeDailyResult>>(
                json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            var daily = apiResponse?.Data?.ActiveDailyCodingChallengeQuestion;
            if (daily is null || apiResponse?.Errors?.Count > 0)
                return null;

            var problem = daily.Question;
            if (problem.IsPaidOnly)
                return null;

            return new Challenge
            {
                ExternalId = problem.TitleSlug,
                Name = problem.Title,
                Description = ExtractFirstSentence(problem.Content),
                Keywords = string.Join(", ", problem.TopicTags.Select(t => t.Name)),
                ReleaseDate = DateTime.Parse(daily.Date, null, System.Globalization.DateTimeStyles.AssumeUniversal),
                Level = MapLevel(problem.Difficulty),
                ExperiencePoints = MapXp(problem.Difficulty),
                Platform = ChallengePlatform.LeetCode,
                Category = problem.TopicTags.Any(t => t.Slug == "database")
                    ? ChallengeCategory.SQL
                    : ChallengeCategory.CSharp
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to fetch LeetCode daily challenge.");
            return null;
        }
    }

    private static Level MapLevel(string difficulty) => difficulty switch
    {
        "Easy" => Level.Green,
        "Medium" => Level.Yellow,
        "Hard" => Level.Orange,
        _ => Level.Green
    };

    private static int MapXp(string difficulty) => difficulty switch
    {
        "Easy" => 5,
        "Medium" => 10,
        "Hard" => 15,
        _ => 5
    };

    private static string ExtractFirstSentence(string html)
    {
        var plain = Regex.Replace(html, "<[^>]+>", " ");
        plain = WebUtility.HtmlDecode(Regex.Replace(plain, @"\s+", " ").Trim());
        var end = plain.IndexOfAny(['.', '!', '?']);
        return end >= 0 ? plain[..(end + 1)].Trim() : plain[..Math.Min(200, plain.Length)].Trim();
    }
}
