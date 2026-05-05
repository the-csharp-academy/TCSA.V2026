using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging.Abstractions;
using TCSA.V2026.Data.Enums;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Services.Challenges;

namespace TCSA.V2026.IntegrationTests;

public class LeetCodeDailyChallengeServiceTests : IntegrationTestsBase
{
    private LeetCodeDailyChallengeService _service;
    private IHttpClientFactory _httpClientFactory;

    [SetUp]
    public void Setup()
    {
        BaseSetup();
        var services = new ServiceCollection();
        services.AddHttpClient();
        var serviceProvider = services.BuildServiceProvider();
        _httpClientFactory = serviceProvider.GetRequiredService<IHttpClientFactory>();

        _service = new LeetCodeDailyChallengeService(_httpClientFactory, NullLogger<LeetCodeDailyChallengeService>.Instance);
    }

    [TearDown]
    public void TearDown()
    {
        BaseTearDown();
    }

    [Test]
    public async Task FetchDailyChallenge_ShouldReturnValidChallenge()
    {
        // Act
        var challenge = await _service.FetchDailyChallenge();

        // Assert
        Assert.That(challenge, Is.Not.Null);
        Assert.That(challenge.ExternalId, Is.Not.Null.And.Not.Empty);
        Assert.That(challenge.Name, Is.Not.Null.And.Not.Empty);
        Assert.That(challenge.Description, Is.Not.Null.And.Not.Empty);
        Assert.That(challenge.Platform, Is.EqualTo(ChallengePlatform.LeetCode));
        Assert.That(challenge.ReleaseDate.Date, Is.EqualTo(DateTime.UtcNow.Date));
        Assert.That(challenge.Level, Is.AnyOf(Level.Green, Level.Yellow, Level.Orange));
        Assert.That(challenge.ExperiencePoints, Is.AnyOf(5, 10, 15));
        Assert.That(challenge.Category, Is.AnyOf(ChallengeCategory.SQL, ChallengeCategory.CSharp));
    }
}
