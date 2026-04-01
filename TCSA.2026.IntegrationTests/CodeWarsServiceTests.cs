using Moq;
using TCSA.V2026.Data.DTOs;
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
}
