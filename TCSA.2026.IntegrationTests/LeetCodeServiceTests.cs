using Moq;
using System.Net;
using System.Text;
using TCSA.V2026.Data.DTOs;
using TCSA.V2026.Data.DTOs.Challenges;
using TCSA.V2026.Data.Enums;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Data.Models.Responses;
using TCSA.V2026.Services.Challenges;

namespace TCSA.V2026.IntegrationTests;

public class LeetCodeServiceTests : IntegrationTestsBase
{
    private LeetCodeService _service;

    [SetUp]
    public void Setup()
    {
        _service = CreateService(HttpStatusCode.OK, """
            {
              "data": {
                "recentAcSubmissionList": []
              }
            }
            """);
    }

    [Test]
    public async Task ChallengeCompletedShouldUpdateXP()
    {
        // Arrange
        using (var seedContext = DbContextFactory.CreateDbContext())
        {
            seedContext.Challenges.Add(new Challenge
            {
                Id = 1,
                ExternalId = "fakeId",
                Description = "desc",
                Keywords = "kw",
                Name = "challenge1",
                ExperiencePoints = 1,
                Platform = ChallengePlatform.LeetCode,
                Level = Level.Green,
            });
            await seedContext.SaveChangesAsync();
        }

        // Act
        await _service.MarkChallengeAsCompleted(new MarkChallengeCompletedRequest(1, "user1"));

        // Assert
        using var assertContext = DbContextFactory.CreateDbContext();
        var user = assertContext.AspNetUsers
            .FirstOrDefault(u => u.Id.Equals("user1"));

        Assert.That(user.ExperiencePoints, Is.EqualTo(1));
    }

    [Test]
    public async Task SyncChallengeWithoutUsernameShouldReturnFailResponse()
    {
        // Act
        var response = await _service.SyncChallenge(new SyncChallengeRequest
        (
            new UserPlatformCredentials(null, null),
            1,
            "two-sum",
            "user1"
        ));

        // Assert
        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Fail));
        Assert.That(response.Message, Is.EqualTo("You haven't integrated your LeetCode account yet. Go to your profile and add your LeetCode username."));
    }

    [Test]
    public async Task SyncChallengeWithValidUsernameAndCompletedChallenge()
    {
        _service = CreateService(HttpStatusCode.OK, """
            {
              "data": {
                "recentAcSubmissionList": [
                  {
                    "title": "Two Sum",
                    "titleSlug": "two-sum",
                    "statusDisplay": "Accepted"
                  }
                ]
              }
            }
            """);

        using (var seedContext = DbContextFactory.CreateDbContext())
        {
            seedContext.Challenges.Add(new Challenge
            {
                Id = 1,
                ExternalId = "two-sum",
                Description = "Find two numbers",
                Keywords = "array",
                Name = "Two Sum",
                ExperiencePoints = 50,
                Platform = ChallengePlatform.LeetCode,
                Level = Level.Green,
            });
            await seedContext.SaveChangesAsync();
        }

        // Act
        var response = await _service.SyncChallenge(new SyncChallengeRequest
        (
            new UserPlatformCredentials(null, "test-user"),
            1,
            "two-sum",
            "user1"
        ));

        // Assert
        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Success));

        using var assertContext = DbContextFactory.CreateDbContext();
        var user = assertContext.AspNetUsers.FirstOrDefault(u => u.Id.Equals("user1"));
        Assert.That(user.ExperiencePoints, Is.EqualTo(50));
    }

    [Test]
    public async Task SyncChallengeWithNotCompletedChallengeShouldReturnFailResponse()
    {
        using (var seedContext = DbContextFactory.CreateDbContext())
        {
            seedContext.Challenges.Add(new Challenge
            {
                Id = 1,
                ExternalId = "some-very-obscure-challenge-12345",
                Description = "desc",
                Keywords = "kw",
                Name = "challenge1",
                ExperiencePoints = 1,
                Platform = ChallengePlatform.LeetCode,
                Level = Level.Green,
            });
            await seedContext.SaveChangesAsync();
        }

        // Act
        var response = await _service.SyncChallenge(new SyncChallengeRequest
        (
            new UserPlatformCredentials(null, "test-user"),
            1,
            "some-very-obscure-challenge-12345",
            "user1"
        ));

        // Assert
        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Fail));
        Assert.That(response.Message, Is.EqualTo("You haven't completed this challenge yet or it is not within the recent 20 submissions."));
    }

    [Test]
    public async Task SyncChallengeWhenLeetCodeIsUnavailableShouldReturnFailResponse()
    {
        _service = CreateService(HttpStatusCode.ServiceUnavailable, "");

        var response = await _service.SyncChallenge(new SyncChallengeRequest
        (
            new UserPlatformCredentials(null, "test-user"),
            1,
            "two-sum",
            "user1"
        ));

        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Fail));
        Assert.That(response.Message, Is.EqualTo("Failed to connect to LeetCode API. Please try again later."));
    }

    [Test]
    public async Task SyncChallengeWithGraphQlErrorsShouldReturnFailResponse()
    {
        _service = CreateService(HttpStatusCode.OK, """
            {
              "errors": [
                {
                  "message": "User not found"
                }
              ]
            }
            """);

        var response = await _service.SyncChallenge(new SyncChallengeRequest
        (
            new UserPlatformCredentials(null, "missing-user"),
            1,
            "two-sum",
            "user1"
        ));

        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Fail));
        Assert.That(response.Message, Is.EqualTo("Failed to retrieve your recent submissions from LeetCode. Contact support if the issue persists."));
    }

    [Test]
    [Category("ExternalApi")]
    public async Task LeetCodeApiShouldReturnRecentSubmissions()
    {
        using var httpClient = new HttpClient();
        var httpClientFactory = new Mock<IHttpClientFactory>();
        httpClientFactory
            .Setup(factory => factory.CreateClient(It.IsAny<string>()))
            .Returns(httpClient);
        var service = new LeetCodeService(DbContextFactory, httpClientFactory.Object);

        var response = await service.SyncChallenge(new SyncChallengeRequest
        (
            new UserPlatformCredentials(null, "leetcode"),
            1,
            "not-a-real-leetcode-challenge",
            "user1"
        ));

        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Fail));
        Assert.That(response.Message, Is.EqualTo("You haven't completed this challenge yet or it is not within the recent 20 submissions."));
    }

    private LeetCodeService CreateService(HttpStatusCode statusCode, string responseBody)
    {
        var handler = new StubHttpMessageHandler(new HttpResponseMessage(statusCode)
        {
            Content = new StringContent(responseBody, Encoding.UTF8, "application/json")
        });
        var httpClientFactory = new Mock<IHttpClientFactory>();
        httpClientFactory
            .Setup(factory => factory.CreateClient(It.IsAny<string>()))
            .Returns(new HttpClient(handler));

        return new LeetCodeService(DbContextFactory, httpClientFactory.Object);
    }

    private sealed class StubHttpMessageHandler(HttpResponseMessage response) : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            return Task.FromResult(response);
        }
    }
}
