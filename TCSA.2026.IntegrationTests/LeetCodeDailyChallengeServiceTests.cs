using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using System.Net;
using TCSA.V2026.Data.Enums;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Services.Challenges;

namespace TCSA.V2026.IntegrationTests;

public class LeetCodeDailyChallengeServiceTests
{
    [Test]
    public async Task FetchDailyChallenge_EasyProblem_ReturnsMappedChallenge()
    {
        // Arrange
        var json = BuildPayload("Two Sum", "two-sum", "Easy", false,
            "<p>Given an array of integers nums and an integer target.</p>",
            "2026-05-15", [("Array", "array")]);
        var service = CreateService(json);

        // Act
        var challenge = await service.FetchDailyChallenge();

        // Assert
        Assert.That(challenge, Is.Not.Null);
        Assert.That(challenge!.ExternalId, Is.EqualTo("two-sum"));
        Assert.That(challenge.Name, Is.EqualTo("Two Sum"));
        Assert.That(challenge.Description, Is.Not.Null.And.Not.Empty);
        Assert.That(challenge.Level, Is.EqualTo(Level.Green));
        Assert.That(challenge.ExperiencePoints, Is.EqualTo(5));
        Assert.That(challenge.Platform, Is.EqualTo(ChallengePlatform.LeetCode));
        Assert.That(challenge.Category, Is.EqualTo(ChallengeCategory.CSharp));
        Assert.That(challenge.ReleaseDate.Date, Is.EqualTo(new DateTime(2026, 5, 15)));
    }

    [Test]
    public async Task FetchDailyChallenge_MediumDatabaseProblem_ReturnsSqlCategoryAndCorrectXp()
    {
        // Arrange
        var json = BuildPayload("Employees Earning More Than Their Managers",
            "employees-earning-more-than-their-managers", "Medium", false,
            "<p>Find all employees who earn more than their manager.</p>",
            "2026-05-15", [("Database", "database")]);
        var service = CreateService(json);

        // Act
        var challenge = await service.FetchDailyChallenge();

        // Assert
        Assert.That(challenge, Is.Not.Null);
        Assert.That(challenge!.Level, Is.EqualTo(Level.Yellow));
        Assert.That(challenge.ExperiencePoints, Is.EqualTo(10));
        Assert.That(challenge.Category, Is.EqualTo(ChallengeCategory.SQL));
    }

    [Test]
    public async Task FetchDailyChallenge_HardProblem_ReturnsCorrectLevelAndXp()
    {
        // Arrange
        var json = BuildPayload("Median of Two Sorted Arrays",
            "median-of-two-sorted-arrays", "Hard", false,
            "<p>Find the median of the two sorted arrays.</p>",
            "2026-05-15", [("Array", "array")]);
        var service = CreateService(json);

        // Act
        var challenge = await service.FetchDailyChallenge();

        // Assert
        Assert.That(challenge, Is.Not.Null);
        Assert.That(challenge!.Level, Is.EqualTo(Level.Orange));
        Assert.That(challenge.ExperiencePoints, Is.EqualTo(15));
    }

    [Test]
    public async Task FetchDailyChallenge_PaidOnlyProblem_ReturnsNull()
    {
        // Arrange
        var json = BuildPayload("Premium Problem", "premium-problem", "Easy", true,
            "<p>This is a premium problem.</p>",
            "2026-05-15", []);
        var service = CreateService(json);

        // Act
        var challenge = await service.FetchDailyChallenge();

        // Assert
        Assert.That(challenge, Is.Null);
    }

    [Test]
    public async Task FetchDailyChallenge_ApiReturnsFailure_ReturnsNull()
    {
        // Arrange
        var service = CreateService(statusCode: HttpStatusCode.ServiceUnavailable);

        // Act
        var challenge = await service.FetchDailyChallenge();

        // Assert
        Assert.That(challenge, Is.Null);
    }

    private static LeetCodeDailyChallengeService CreateService(string? json = null, HttpStatusCode statusCode = HttpStatusCode.OK)
    {
        var factory = new Mock<IHttpClientFactory>();
        factory.Setup(f => f.CreateClient(It.IsAny<string>()))
               .Returns(new HttpClient(new MockHttpMessageHandler(json, statusCode)));
        return new LeetCodeDailyChallengeService(factory.Object, NullLogger<LeetCodeDailyChallengeService>.Instance);
    }

    private static string BuildPayload(string title, string titleSlug, string difficulty, bool isPaidOnly,
        string content, string date, (string Name, string Slug)[] tags)
    {
        var tagsJson = string.Join(", ", tags.Select(t => $$"""{"name":"{{t.Name}}","slug":"{{t.Slug}}"}"""));
        return $$"""
            {
              "data": {
                "activeDailyCodingChallengeQuestion": {
                  "date": "{{date}}",
                  "question": {
                    "title": "{{title}}",
                    "titleSlug": "{{titleSlug}}",
                    "difficulty": "{{difficulty}}",
                    "isPaidOnly": {{isPaidOnly.ToString().ToLower()}},
                    "content": "{{content}}",
                    "topicTags": [{{tagsJson}}]
                  }
                }
              }
            }
            """;
    }
}
