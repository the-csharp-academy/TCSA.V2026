using Moq;
using TCSA.V2026.Services;

namespace TCSA.V2026.IntegrationTests;

[TestFixture]
public class AdminServiceTests : IntegrationTestsBase
{
    private AdminService _service;

    [SetUp]
    public void Setup()
    {
        BaseSetup();
        _service = new AdminService(DbContextFactory, new Mock<IDiscordService>().Object);
    }

    [TearDown]
    public void TearDown()
    {
        BaseTearDown();
    }

    [Test]
    public async Task ChangePoints_ExistingUser_UpdatesPointsAndReturnsSuccess()
    {
        var result = await _service.ChangePoints("user1", 42);

        using var assertContext = DbContextFactory.CreateDbContext();
        var user = assertContext.AspNetUsers.First(u => u.Id == "user1");

        Assert.Multiple(() =>
        {
            Assert.That(result.IsSuccess, Is.True);
            Assert.That(user.ExperiencePoints, Is.EqualTo(42));
        });
    }

    [Test]
    public async Task ChangePoints_UnknownUser_ReturnsFailure()
    {
        var result = await _service.ChangePoints("missing-user", 42);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsFailure, Is.True);
            Assert.That(result.Reason.Code, Is.EqualTo("Admin.Unexpected"));
        });
    }

    [Test]
    public async Task PortData_UnknownOriginUser_ReturnsFailure()
    {
        var result = await _service.PortData("missing-user", "user1");

        Assert.Multiple(() =>
        {
            Assert.That(result.IsFailure, Is.True);
            Assert.That(result.Reason.Code, Is.EqualTo("Admin.Unexpected"));
        });
    }

    [Test]
    public async Task PortData_OriginWithoutProjects_ReturnsFailureWithMessage()
    {
        var result = await _service.PortData("user1", "user2");

        Assert.Multiple(() =>
        {
            Assert.That(result.IsFailure, Is.True);
            Assert.That(result.Reason.Code, Is.EqualTo("Admin.NoProjectsToPort"));
            Assert.That(result.Message, Is.EqualTo("Origin user has no projects to port."));
        });
    }

    [Test]
    public async Task RequestChanges_UnknownProject_ReturnsFailure()
    {
        var result = await _service.RequestChanges(999);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsFailure, Is.True);
            Assert.That(result.Message, Is.EqualTo("Project Not Found"));
        });
    }
}
