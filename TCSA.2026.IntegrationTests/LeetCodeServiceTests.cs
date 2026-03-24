using Microsoft.Extensions.DependencyInjection;
using TCSA.V2026.Data.DTOs;
using TCSA.V2026.Data.Enums;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Data.Models.Responses;
using TCSA.V2026.IntegrationTests;
using TCSA.V2026.Services.Challenges;

namespace TCSA._2026.IntegrationTests;
public class LeetCodeServiceTests : IntegrationTestsBase
{
    private LeetCodeService _service;
    private IHttpClientFactory _httpClientFactory;

    [SetUp]
    public void Setup()
    {
        BaseSetup();
        var services = new ServiceCollection();
        services.AddHttpClient();
        var serviceProvider = services.BuildServiceProvider();
        _httpClientFactory = serviceProvider.GetRequiredService<IHttpClientFactory>();

        _service = new LeetCodeService(DbContextFactory, _httpClientFactory);
    }

    [TearDown]
    public void TearDown()
    {
        BaseTearDown();
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
        string realLeetCodeUsername = "Dejmenek";

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
            new UserPlatformCredentials(null, realLeetCodeUsername),
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
        string leetCodeUsername = "leetcode";

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
            new UserPlatformCredentials(null, leetCodeUsername),
            1,
            "some-very-obscure-challenge-12345",
            "user1"
        ));

        // Assert
        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Fail));
        Assert.That(response.Message, Is.EqualTo("You haven't completed this challenge yet or it is not within the recent 20 submissions."));
    }
}
