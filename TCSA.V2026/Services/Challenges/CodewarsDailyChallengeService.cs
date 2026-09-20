using HtmlAgilityPack;
using System.Net.Http.Json;
using System.Text.Json;
using TCSA.V2026.Data.Enums;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Data.Models.Responses;
using TCSA.V2026.Helpers;
using TCSA.V2026.Helpers.Constants;

namespace TCSA.V2026.Services.Challenges;

public class CodewarsDailyChallengeService : IDailyChallengeFetchService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<CodewarsDailyChallengeService> _logger;

    public CodewarsDailyChallengeService(IHttpClientFactory httpClientFactory, ILogger<CodewarsDailyChallengeService> logger)
    {
        _httpClient = httpClientFactory.CreateClient();
        _logger = logger;
    }

    public async Task<IEnumerable<Challenge>> FetchDailyChallenges()
    {
        var challenges = new List<Challenge>();

        foreach (var category in ChallengePlatformConstants.CodeWars.SupportedCategories)
        {
            var challenge = await FetchDailyChallenge(category);
            if (challenge is not null)
                challenges.Add(challenge);
        }

        return challenges;
    }

    private async Task<Challenge?> FetchDailyChallenge(ChallengeCategory category)
    {
        try
        {
            var listUrl = GetDailyChallengeListUrl(category);
            var challengeHtml = await _httpClient.GetStringAsync(listUrl);
            var challengeDoc = new HtmlDocument();
            challengeDoc.LoadHtml(challengeHtml);

            var kataNode = challengeDoc.DocumentNode.SelectSingleNode("//div[contains(@class,'list-item-kata')]");
            if (kataNode is null)
                return null;

            var externalId = kataNode.GetAttributeValue("id", string.Empty);
            var name = kataNode.GetAttributeValue("data-title", string.Empty);
            if (string.IsNullOrEmpty(externalId) || string.IsNullOrEmpty(name))
                return null;

            var kyuRank = kataNode
                .SelectSingleNode(".//div[contains(@class,'inner-small-hex')]/span")
                ?.InnerText.Trim() ?? string.Empty;

            var keywords = kataNode
                .SelectNodes(".//div[contains(@class,'keyword-tag')]/a")
                ?.Select(a => a.InnerText.Trim())
                .ToList() ?? [];

            var details = await _httpClient.GetFromJsonAsync<CodewarsChallengeDetailsResponse>(
                $"{ChallengePlatformConstants.CodeWars.ChallengeApiUrl}{externalId}",
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            var description = !string.IsNullOrEmpty(details?.Description)
                ? ChallengeHelper.ExtractFirstSentence(details.Description)
                : string.Empty;

            return new Challenge
            {
                ExternalId = externalId,
                Name = name,
                Description = description,
                Keywords = string.Join(", ", keywords),
                ReleaseDate = DateTime.UtcNow,
                Level = MapLevel(kyuRank),
                ExperiencePoints = MapXp(kyuRank),
                Platform = ChallengePlatform.CodeWars,
                Category = category
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to fetch Codewars daily challenge for category {Category}.", category);
            return null;
        }
    }

    private static string GetDailyChallengeListUrl(ChallengeCategory category) => category switch
    {
        ChallengeCategory.CSharp => ChallengePlatformConstants.CodeWars.DailyCSharpChallengeUrl,
        ChallengeCategory.SQL => ChallengePlatformConstants.CodeWars.DailySQLChallengeUrl,
        _ => throw new ArgumentOutOfRangeException(nameof(category), category, null)
    };

    private static Level MapLevel(string kata) => kata switch
    {
        "8 kyu" => Level.White,
        "7 kyu" => Level.Green,
        "6 kyu" => Level.OliveGreen,
        "5 kyu" => Level.Yellow,
        "4 kyu" => Level.Orange,
        "3 kyu" => Level.Red,
        "2 kyu" => Level.Purple,
        "1 kyu" => Level.Brown,
        "1 dan" => Level.Grey,
        "2 dan" => Level.Blue,
        "3 dan" or "4 dan" or "5 dan" or "6 dan" or "7 dan" or "8 dan" => Level.Black,
        _ => Level.Green
    };

    private static int MapXp(string kata) => kata switch
    {
        "8 kyu" => 5,
        "7 kyu" => 7,
        "6 kyu" => 9,
        "5 kyu" => 11,
        "4 kyu" => 13,
        "3 kyu" => 15,
        "2 kyu" => 18,
        "1 kyu" => 21,
        "1 dan" => 25,
        "2 dan" => 28,
        "3 dan" or "4 dan" or "5 dan" or "6 dan" or "7 dan" or "8 dan" => 30,
        _ => 5
    };
}
