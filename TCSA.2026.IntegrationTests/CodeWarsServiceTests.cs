using Moq;
using System.Net;
using System.Text;
using TCSA.V2026.Data.DTOs;
using TCSA.V2026.Data.DTOs.Challenges;
using TCSA.V2026.Data.Enums;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Services.Challenges;

namespace TCSA.V2026.IntegrationTests;

public class CodeWarsServiceTests : IntegrationTestsBase
{
    private CodewarsService _service;
    private Mock<IHttpClientFactory> _httpClientFactoryMock;

    [SetUp]
    public void Setup()
    {
        BaseSetup();
        var httpClientFactoryMock = new Mock<IHttpClientFactory>();
        httpClientFactoryMock
            .Setup(f => f.CreateClient(It.IsAny<string>()))
            .Returns(new HttpClient());
        _service = new CodewarsService(DbContextFactory, httpClientFactoryMock.Object);
    }

    [TearDown]
    public void TearDown()
    {
        BaseTearDown();
    }

    [Test]
    public async Task ChallengeCompletedShouldUpdateXP()
    {
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
                Platform = ChallengePlatform.CodeWars,
                Level = Level.Green,
            });

            await seedContext.SaveChangesAsync();
        }

        await _service.MarkChallengeAsCompleted(new MarkChallengeCompletedRequest(1, "user1"));

        using var assertContext = DbContextFactory.CreateDbContext();
        var user = assertContext.AspNetUsers
            .FirstOrDefault(u => u.Id.Equals("user1"));

        Assert.That(user.ExperiencePoints, Is.EqualTo(1));
    }

    [Test]
    public async Task GetCompletedChallenges_UserWithoutCodeWarsUsername_ReturnsFailure()
    {
        var service = CreateService(HttpStatusCode.OK, "{}");

        var result = await service.GetCodeWarsCompletedChallenges("user1", CreateChallenges());

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailure, Is.True);
            Assert.That(result.Reason.Code, Is.EqualTo("CodeWars.AccountNotIntegrated"));
        }
    }

    [Test]
    public async Task GetCompletedChallenges_UsernameNotFoundOnCodeWars_ReturnsFailure()
    {
        await SetCodeWarsUsername("user1", "unknown-user");
        var service = CreateService(HttpStatusCode.NotFound, "{}");

        var result = await service.GetCodeWarsCompletedChallenges("user1", CreateChallenges());

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailure, Is.True);
            Assert.That(result.Reason.Code, Is.EqualTo("CodeWars.UsernameNotFound"));
            Assert.That(result.Message, Is.EqualTo("Username not found. Go to the dashboard and click on 'Codewars Integration' to update your username."));
        }
    }

    [Test]
    public async Task GetCompletedChallenges_UnexpectedStatusCode_ReturnsFailure()
    {
        await SetCodeWarsUsername("user1", "some-user");
        var service = CreateService(HttpStatusCode.InternalServerError, CompletedChallengesJson("abc"));

        var result = await service.GetCodeWarsCompletedChallenges("user1", CreateChallenges());

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailure, Is.True);
            Assert.That(result.Reason.Code, Is.EqualTo("CodeWars.UnexpectedResponse"));
        }
    }

    [Test]
    public async Task GetCompletedChallenges_SuccessfulResponse_MarksCompletedChallenges()
    {
        await SetCodeWarsUsername("user1", "some-user");
        var service = CreateService(HttpStatusCode.OK, CompletedChallengesJson("abc"));
        var challenges = CreateChallenges();

        var result = await service.GetCodeWarsCompletedChallenges("user1", challenges);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSuccess, Is.True);
            Assert.That(result.Value, Is.SameAs(challenges));
            Assert.That(result.Value.Single(c => c.Id == "abc").IsCompleted, Is.True);
            Assert.That(result.Value.Single(c => c.Id == "def").IsCompleted, Is.False);
        }
    }

    [Test]
    public async Task GetCompletedChallenges_SolvedInDifferentLanguage_IsNotMarkedCompleted()
    {
        await SetCodeWarsUsername("user1", "some-user");
        var service = CreateService(HttpStatusCode.OK, CompletedChallengesJson("abc", "rust"));

        var result = await service.GetCodeWarsCompletedChallenges("user1", CreateChallenges());

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSuccess, Is.True);
            Assert.That(result.Value.Single(c => c.Id == "abc").IsCompleted, Is.False);
        }
    }

    [Test]
    public async Task SyncChallenge_SolvedInRequiredLanguage_AwardsXp()
    {
        await SeedChallenge(1, "abc", ChallengeCategory.SQL, 10);
        var service = CreateService(HttpStatusCode.OK, CompletedChallengesJson("abc", "rust", "sql"));

        var result = await service.SyncChallenge(CreateSyncRequest("abc", ChallengeCategory.SQL));

        Assert.That(result.IsSuccess, Is.True);
        Assert.That(GetUserXp("user1"), Is.EqualTo(10));
    }

    [Test]
    public async Task SyncChallenge_CSharpChallengeSolvedInCSharp_AwardsXp()
    {
        await SeedChallenge(1, "abc", ChallengeCategory.CSharp, 10);
        var service = CreateService(HttpStatusCode.OK, CompletedChallengesJson("abc", "csharp"));

        var result = await service.SyncChallenge(CreateSyncRequest("abc", ChallengeCategory.CSharp));

        Assert.That(result.IsSuccess, Is.True);
        Assert.That(GetUserXp("user1"), Is.EqualTo(10));
    }

    [Test]
    public async Task SyncChallenge_SolvedInDifferentLanguage_FailsAndAwardsNoXp()
    {
        await SeedChallenge(1, "abc", ChallengeCategory.SQL, 10);
        var service = CreateService(HttpStatusCode.OK, CompletedChallengesJson("abc", "rust"));

        var result = await service.SyncChallenge(CreateSyncRequest("abc", ChallengeCategory.SQL));

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailure, Is.True);
            Assert.That(result.Reason.Code, Is.EqualTo("CodeWars.ChallengeNotCompleted"));
            Assert.That(GetUserXp("user1"), Is.EqualTo(0));
        }
    }

    [Test]
    public async Task SyncChallenge_UnknownCategory_FailsAndAwardsNoXp()
    {
        await SeedChallenge(1, "abc", ChallengeCategory.Unknown, 10);
        var service = CreateService(HttpStatusCode.OK, CompletedChallengesJson("abc", "sql"));

        var result = await service.SyncChallenge(CreateSyncRequest("abc", ChallengeCategory.Unknown));

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailure, Is.True);
            Assert.That(result.Reason.Code, Is.EqualTo("CodeWars.UnsupportedCategory"));
            Assert.That(GetUserXp("user1"), Is.EqualTo(0));
        }
    }

    [Test]
    public async Task SyncChallenge_KataNotInCompletedList_Fails()
    {
        await SeedChallenge(1, "abc", ChallengeCategory.SQL, 10);
        var service = CreateService(HttpStatusCode.OK, CompletedChallengesJson("other", "sql"));

        var result = await service.SyncChallenge(CreateSyncRequest("abc", ChallengeCategory.SQL));

        Assert.That(result.Reason.Code, Is.EqualTo("CodeWars.ChallengeNotCompleted"));
    }

    [Test]
    public async Task SyncChallenge_WithoutUsername_Fails()
    {
        var service = CreateService(HttpStatusCode.OK, "{}");

        var result = await service.SyncChallenge(new SyncChallengeRequest(
            new UserPlatformCredentials(null, null), 1, "abc", "user1", ChallengeCategory.SQL));

        Assert.That(result.Reason.Code, Is.EqualTo("CodeWars.AccountNotIntegrated"));
    }

    private static SyncChallengeRequest CreateSyncRequest(string externalId, ChallengeCategory category) =>
        new(new UserPlatformCredentials("some-user", null), 1, externalId, "user1", category);

    private async Task SeedChallenge(int id, string externalId, ChallengeCategory category, int xp)
    {
        using var context = DbContextFactory.CreateDbContext();
        context.Challenges.Add(new Challenge
        {
            Id = id,
            ExternalId = externalId,
            Description = "desc",
            Keywords = "kw",
            Name = "challenge",
            ExperiencePoints = xp,
            Platform = ChallengePlatform.CodeWars,
            Level = Level.Green,
            Category = category
        });
        await context.SaveChangesAsync();
    }

    private int GetUserXp(string userId)
    {
        using var context = DbContextFactory.CreateDbContext();
        return context.AspNetUsers.First(u => u.Id == userId).ExperiencePoints;
    }

    private async Task SetCodeWarsUsername(string userId, string username)
    {
        using var context = DbContextFactory.CreateDbContext();
        var user = context.AspNetUsers.First(u => u.Id == userId);
        user.CodeWarsUsername = username;
        await context.SaveChangesAsync();
    }

    private static List<CodeWarsChallenge> CreateChallenges() =>
    [
        new CodeWarsChallenge { Id = "abc", Name = "First" },
        new CodeWarsChallenge { Id = "def", Name = "Second" }
    ];

    private static string CompletedChallengesJson(string completedId, params string[] languages)
    {
        var langs = string.Join(",", (languages.Length == 0 ? ["sql"] : languages).Select(l => $"\"{l}\""));
        return $$"""{"totalPages":1,"totalItems":1,"data":[{"id":"{{completedId}}","name":"First","slug":"first","completedLanguages":[{{langs}}],"completedAt":"2024-01-01T00:00:00Z"}]}""";
    }

    private CodewarsService CreateService(HttpStatusCode statusCode, string responseBody)
    {
        var handler = new StubHttpMessageHandler(new HttpResponseMessage(statusCode)
        {
            Content = new StringContent(responseBody, Encoding.UTF8, "application/json")
        });
        var httpClientFactory = new Mock<IHttpClientFactory>();
        httpClientFactory
            .Setup(factory => factory.CreateClient(It.IsAny<string>()))
            .Returns(new HttpClient(handler));

        return new CodewarsService(DbContextFactory, httpClientFactory.Object);
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
