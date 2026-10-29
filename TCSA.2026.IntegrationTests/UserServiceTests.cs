using Microsoft.Extensions.Logging.Abstractions;
using TCSA.V2026.Data.Models.Responses;
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

    [Test]
    public async Task SaveProfile_WithValidLinkedInUrl_PersistsUrl()
    {
        var user = await _service.GetUserProfileById("user1");
        user.LinkedInUrl = "https://www.linkedin.com/in/test-user";

        var result = await _service.SaveProfile(user);

        Assert.That(result.IsSuccess, Is.True);

        using var context = DbContextFactory.CreateDbContext();
        var saved = context.AspNetUsers.First(u => u.Id == "user1");
        Assert.That(saved.LinkedInUrl, Is.EqualTo("https://www.linkedin.com/in/test-user"));
    }

    [Test]
    public async Task SaveProfile_WithEmptyLinkedInUrl_Succeeds()
    {
        var user = await _service.GetUserProfileById("user1");
        user.LinkedInUrl = "   ";

        var result = await _service.SaveProfile(user);

        Assert.That(result.IsSuccess, Is.True);
    }

    [TestCase("not-a-url")]
    [TestCase("linkedin.com/in/test-user")]
    [TestCase("http://www.linkedin.com/in/test-user")]
    [TestCase("https://www.linkedin.com/company/test-company")]
    [TestCase("https://github.com/test-user")]
    public async Task SaveProfile_WithInvalidLinkedInUrl_ReturnsFailure_AndDoesNotPersist(string linkedInUrl)
    {
        var user = await _service.GetUserProfileById("user1");
        user.LinkedInUrl = linkedInUrl;

        var result = await _service.SaveProfile(user);

        Assert.That(result.IsFailure, Is.True);
        Assert.That(result.Reason, Is.InstanceOf<ValidationError>());
        var validationError = (ValidationError)result.Reason;
        Assert.That(validationError.Errors.Single().Code, Is.EqualTo(UserErrorCodes.InvalidLinkedInUrl));

        using var context = DbContextFactory.CreateDbContext();
        var saved = context.AspNetUsers.First(u => u.Id == "user1");
        Assert.That(saved.LinkedInUrl, Is.Null);
    }
}
