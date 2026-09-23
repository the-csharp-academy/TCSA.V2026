using Microsoft.Extensions.Logging.Abstractions;
using TCSA.V2026.Services;

namespace TCSA.V2026.IntegrationTests;

[TestFixture]
public class UserServiceTests : IntegrationTestsBase
{
    private UserService _service;

    [SetUp]
    public void Setup()
    {
        BaseSetup();
        _service = new UserService(DbContextFactory, NullLogger<UserService>.Instance);
    }

    [TearDown]
    public void TearDown()
    {
        BaseTearDown();
    }

    [Test]
    public async Task GetUserIdsPendingBackfill_ReturnsOnlyUnflaggedUsers()
    {
        using (var seedContext = DbContextFactory.CreateDbContext())
        {
            var user1 = seedContext.AspNetUsers.First(u => u.Id == "user1");
            user1.HasBackfilledBadges = true;
            await seedContext.SaveChangesAsync();
        }

        var pendingUserIds = await _service.GetUserIdsPendingBackfill(10);

        Assert.That(pendingUserIds, Does.Not.Contain("user1"));
        Assert.That(pendingUserIds, Is.EquivalentTo(new[] { "user2", "orangeuser", "purpleuser" }));
    }

    [Test]
    public async Task GetUserIdsPendingBackfill_CapsResultAtBatchSize()
    {
        var pendingUserIds = await _service.GetUserIdsPendingBackfill(2);

        Assert.That(pendingUserIds.Count, Is.EqualTo(2));
    }
}
