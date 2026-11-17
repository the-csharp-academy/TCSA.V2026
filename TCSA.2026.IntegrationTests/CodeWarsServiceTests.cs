using Microsoft.Extensions.Logging.Abstractions;
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
        _service = new CodewarsService(DbContextFactory, httpClientFactoryMock.Object, NullLogger<CodewarsService>.Instance);
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
    public async Task GetCompletedChallenges_ChallengeOnLaterPage_MarksItCompleted()
    {
        await SetCodeWarsUsername("user1", "some-user");
        var handler = new PagedHttpMessageHandler(page => page switch
        {
            0 => (HttpStatusCode.OK, PageJson(totalPages: 2, "other-1")),
            _ => (HttpStatusCode.OK, PageJson(totalPages: 2, "abc"))
        });
        var service = CreateService(handler);

        var result = await service.GetCodeWarsCompletedChallenges("user1", CreateChallenges());

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSuccess, Is.True);
            Assert.That(result.Value.Single(c => c.Id == "abc").IsCompleted, Is.True);
            Assert.That(result.Value.Single(c => c.Id == "def").IsCompleted, Is.False);
            Assert.That(handler.RequestedPages, Is.EqualTo(new[] { 0, 1 }));
        }
    }

    [Test]
    public async Task GetCompletedChallenges_AllChallengesFoundOnFirstPage_StopsRequestingPages()
    {
        await SetCodeWarsUsername("user1", "some-user");
        var handler = new PagedHttpMessageHandler(page => (HttpStatusCode.OK, PageJson(totalPages: 3, "abc", "def")));
        var service = CreateService(handler);

        var result = await service.GetCodeWarsCompletedChallenges("user1", CreateChallenges());

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSuccess, Is.True);
            Assert.That(result.Value.All(c => c.IsCompleted), Is.True);
            Assert.That(handler.RequestedPages, Is.EqualTo(new[] { 0 }));
        }
    }

    [Test]
    public async Task GetCompletedChallenges_ChallengeNotCompletedOnAnyPage_FetchesAllPagesAndMarksIncomplete()
    {
        await SetCodeWarsUsername("user1", "some-user");
        var handler = new PagedHttpMessageHandler(page => (HttpStatusCode.OK, PageJson(totalPages: 3, $"other-{page}")));
        var service = CreateService(handler);

        var result = await service.GetCodeWarsCompletedChallenges("user1", CreateChallenges());

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSuccess, Is.True);
            Assert.That(result.Value.Any(c => c.IsCompleted), Is.False);
            Assert.That(handler.RequestedPages, Is.EqualTo(new[] { 0, 1, 2 }));
        }
    }

    [Test]
    public async Task GetCompletedChallenges_NoCompletedChallenges_MarksAllIncompleteAfterSingleRequest()
    {
        await SetCodeWarsUsername("user1", "some-user");
        var handler = new PagedHttpMessageHandler(page => (HttpStatusCode.OK, PageJson(totalPages: 0)));
        var service = CreateService(handler);

        var result = await service.GetCodeWarsCompletedChallenges("user1", CreateChallenges());

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSuccess, Is.True);
            Assert.That(result.Value.Any(c => c.IsCompleted), Is.False);
            Assert.That(handler.RequestedPages, Is.EqualTo(new[] { 0 }));
        }
    }

    [TestCase(HttpStatusCode.NotFound, "CodeWars.UsernameNotFound")]
    [TestCase(HttpStatusCode.InternalServerError, "CodeWars.UnexpectedResponse")]
    public async Task GetCompletedChallenges_FailureOnLaterPage_ReturnsFailure(HttpStatusCode statusCode, string expectedCode)
    {
        await SetCodeWarsUsername("user1", "some-user");
        var handler = new PagedHttpMessageHandler(page => page == 0
            ? (HttpStatusCode.OK, PageJson(totalPages: 2, "other-1"))
            : (statusCode, "{}"));
        var service = CreateService(handler);
        var challenges = CreateChallenges();

        var result = await service.GetCodeWarsCompletedChallenges("user1", challenges);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailure, Is.True);
            Assert.That(result.Reason.Code, Is.EqualTo(expectedCode));
            Assert.That(handler.RequestedPages, Is.EqualTo(new[] { 0, 1 }));
        }
    }

    [Test]
    public async Task SyncChallenge_WithoutUsername_ReturnsAccountNotIntegrated()
    {
        var handler = new PagedHttpMessageHandler(page => (HttpStatusCode.OK, PageJson(totalPages: 1, "abc")));
        var service = CreateService(handler);

        var result = await service.SyncChallenge(CreateSyncRequest(username: null));

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailure, Is.True);
            Assert.That(result.Reason.Code, Is.EqualTo("CodeWars.AccountNotIntegrated"));
            Assert.That(handler.RequestedPages, Is.Empty);
        }
    }

    [Test]
    public async Task SyncChallenge_ChallengeOnLaterPage_MarksCompletedAndAwardsXp()
    {
        await SeedChallenge(experiencePoints: 50);
        var handler = new PagedHttpMessageHandler(page => page switch
        {
            0 => (HttpStatusCode.OK, PageJson(totalPages: 2, "other-1")),
            _ => (HttpStatusCode.OK, PageJson(totalPages: 2, "abc"))
        });
        var service = CreateService(handler);

        var result = await service.SyncChallenge(CreateSyncRequest("some-user"));

        using var assertContext = DbContextFactory.CreateDbContext();
        var user = assertContext.AspNetUsers.First(u => u.Id == "user1");

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSuccess, Is.True);
            Assert.That(user.ExperiencePoints, Is.EqualTo(50));
            Assert.That(assertContext.UserChallenges.Any(uc => uc.UserId == "user1" && uc.ChallengeId == 1), Is.True);
            Assert.That(handler.RequestedPages, Is.EqualTo(new[] { 0, 1 }));
        }
    }

    [Test]
    public async Task SyncChallenge_ChallengeFoundOnFirstPage_StopsRequestingPages()
    {
        await SeedChallenge(experiencePoints: 50);
        var handler = new PagedHttpMessageHandler(page => (HttpStatusCode.OK, PageJson(totalPages: 3, "abc")));
        var service = CreateService(handler);

        var result = await service.SyncChallenge(CreateSyncRequest("some-user"));

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSuccess, Is.True);
            Assert.That(handler.RequestedPages, Is.EqualTo(new[] { 0 }));
        }
    }

    [Test]
    public async Task SyncChallenge_ChallengeNotCompletedOnAnyPage_ReturnsFailureAndAwardsNoXp()
    {
        await SeedChallenge(experiencePoints: 50);
        var handler = new PagedHttpMessageHandler(page => (HttpStatusCode.OK, PageJson(totalPages: 3, $"other-{page}")));
        var service = CreateService(handler);

        var result = await service.SyncChallenge(CreateSyncRequest("some-user"));

        using var assertContext = DbContextFactory.CreateDbContext();
        var user = assertContext.AspNetUsers.First(u => u.Id == "user1");

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailure, Is.True);
            Assert.That(result.Reason.Code, Is.EqualTo("CodeWars.ChallengeNotCompleted"));
            Assert.That(user.ExperiencePoints, Is.EqualTo(0));
            Assert.That(assertContext.UserChallenges.Any(uc => uc.UserId == "user1" && uc.ChallengeId == 1), Is.False);
            Assert.That(handler.RequestedPages, Is.EqualTo(new[] { 0, 1, 2 }));
        }
    }

    [TestCase(HttpStatusCode.NotFound, "CodeWars.UsernameNotFound")]
    [TestCase(HttpStatusCode.InternalServerError, "CodeWars.UnexpectedResponse")]
    public async Task SyncChallenge_FailureOnLaterPage_ReturnsFailureAndAwardsNoXp(HttpStatusCode statusCode, string expectedCode)
    {
        await SeedChallenge(experiencePoints: 50);
        var handler = new PagedHttpMessageHandler(page => page == 0
            ? (HttpStatusCode.OK, PageJson(totalPages: 2, "other-1"))
            : (statusCode, "{}"));
        var service = CreateService(handler);

        var result = await service.SyncChallenge(CreateSyncRequest("some-user"));

        using var assertContext = DbContextFactory.CreateDbContext();
        var user = assertContext.AspNetUsers.First(u => u.Id == "user1");

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailure, Is.True);
            Assert.That(result.Reason.Code, Is.EqualTo(expectedCode));
            Assert.That(user.ExperiencePoints, Is.EqualTo(0));
            Assert.That(handler.RequestedPages, Is.EqualTo(new[] { 0, 1 }));
        }
    }

    private async Task SeedChallenge(int experiencePoints)
    {
        using var context = DbContextFactory.CreateDbContext();
        context.Challenges.Add(new Challenge
        {
            Id = 1,
            ExternalId = "abc",
            Description = "desc",
            Keywords = "kw",
            Name = "challenge1",
            ExperiencePoints = experiencePoints,
            Platform = ChallengePlatform.CodeWars,
            Level = Level.Green,
        });
        await context.SaveChangesAsync();
    }

    private static SyncChallengeRequest CreateSyncRequest(string? username) =>
        new(new UserPlatformCredentials(username, null), ChallengeId: 1, ExternalId: "abc", UserId: "user1");

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

    private static string CompletedChallengesJson(string completedId) =>
        $$"""{"totalPages":1,"totalItems":1,"data":[{"id":"{{completedId}}","name":"First","slug":"first","completedLanguages":["sql"],"completedAt":"2024-01-01T00:00:00Z"}]}""";

    private static string PageJson(int totalPages, params string[] completedIds)
    {
        var items = string.Join(",", completedIds.Select(id =>
            $$"""{"id":"{{id}}","name":"n","slug":"s","completedLanguages":["sql"],"completedAt":"2024-01-01T00:00:00Z"}"""));

        return $$"""{"totalPages":{{totalPages}},"totalItems":{{completedIds.Length}},"data":[{{items}}]}""";
    }

    private CodewarsService CreateService(HttpStatusCode statusCode, string responseBody)
    {
        var handler = new StubHttpMessageHandler(new HttpResponseMessage(statusCode)
        {
            Content = new StringContent(responseBody, Encoding.UTF8, "application/json")
        });

        return CreateService(handler);
    }

    private CodewarsService CreateService(HttpMessageHandler handler)
    {
        var httpClientFactory = new Mock<IHttpClientFactory>();
        httpClientFactory
            .Setup(factory => factory.CreateClient(It.IsAny<string>()))
            .Returns(new HttpClient(handler));

        return new CodewarsService(DbContextFactory, httpClientFactory.Object, NullLogger<CodewarsService>.Instance);
    }

    private sealed class PagedHttpMessageHandler(Func<int, (HttpStatusCode StatusCode, string Body)> responder) : HttpMessageHandler
    {
        public List<int> RequestedPages { get; } = [];

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            var page = int.Parse(System.Web.HttpUtility.ParseQueryString(request.RequestUri!.Query)["page"]!);
            RequestedPages.Add(page);

            var (statusCode, body) = responder(page);

            return Task.FromResult(new HttpResponseMessage(statusCode)
            {
                Content = new StringContent(body, Encoding.UTF8, "application/json")
            });
        }
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
