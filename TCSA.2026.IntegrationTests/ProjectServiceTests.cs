using TCSA.V2026.Data.Models;
using TCSA.V2026.Services;

namespace TCSA.V2026.IntegrationTests;

[TestFixture]
public class ProjectServiceTests : IntegrationTestsBase
{
    private ProjectService _service;

    [SetUp]
    public void Setup()
    {
        BaseSetup();
        _service = new ProjectService(DbContextFactory);
    }

    [TearDown]
    public void TearDown()
    {
        BaseTearDown();
    }

    [Test]
    public async Task DashboardProjectsShouldHaveNoDupes()
    {
        await _service.CreateDashboardProject(12, "user1", "fakeUrl");
        await _service.CreateDashboardProject(12, "user1", "fakeUrl");

        using var verifyContext = DbContextFactory.CreateDbContext();

        var list = verifyContext.DashboardProjects
        .Where(p => p.ProjectId == 12 && p.AppUserId == "user1")
        .ToList();

        Assert.That(list.Count, Is.EqualTo(1));
    }

    [Test]
    public async Task AddingArticles_ShouldIncrementXPs()
    {
        await _service.MarkArticleAsRead((int)ArticleName.StartHere, "user1");

        using var verifyContext = DbContextFactory.CreateDbContext();

        using var assertContext = DbContextFactory.CreateDbContext();
        var user = assertContext.AspNetUsers
            .FirstOrDefault(u => u.Id.Equals("user1"));

        Assert.That(user.ExperiencePoints, Is.EqualTo(5));
    }

    [Test]
    public async Task AddingProject_ShouldNotIncrementXPs()
    {
        await _service.CreateDashboardProject((int)ArticleName.MathGame, "user1", "fakeUrl");

        using var verifyContext = DbContextFactory.CreateDbContext();

        using var assertContext = DbContextFactory.CreateDbContext();
        var user = assertContext.AspNetUsers
            .FirstOrDefault(u => u.Id.Equals("user1"));

        Assert.That(user.ExperiencePoints, Is.EqualTo(0));
    }

    [Test]
    public async Task ArchivedCanBeReopened()
    {
        using (var seedContext = DbContextFactory.CreateDbContext())
        {
            seedContext.DashboardProjects.Add(new DashboardProject
            {
                Id = 1,
                AppUserId = "user1",
                ProjectId = 12,
                IsArchived = true,
                IsPendingNotification = false,
                IsPendingReview = false,
                DateSubmitted = DateTime.Now.AddDays(-10),
                GithubUrl = "fakeUrl1"
            });

            await seedContext.SaveChangesAsync();
        }

        await _service.CreateDashboardProject(12, "user1", "fakeUrl2");

        using var assertContext = DbContextFactory.CreateDbContext();
        var list = assertContext.DashboardProjects
            .Where(p => p.ProjectId == 12 && p.AppUserId == "user1")
            .ToList();

        Assert.That(list.Count, Is.EqualTo(2));
    }

    [Test]
    public async Task ArchivingAddsCorrectPoints()
    {
        using (var seedContext = DbContextFactory.CreateDbContext())
        {
            seedContext.DashboardProjects.Add(new DashboardProject
            {
                Id = 1,
                AppUserId = "user1",
                ProjectId = 12,
                IsArchived = false,
                IsPendingNotification = false,
                IsPendingReview = true,
                DateSubmitted = DateTime.Now.AddDays(-10),
                GithubUrl = "fakeUrl1"
            });

            seedContext.UserReviews.Add(new UserReview
            {
                Id = 1,
                AppUserId = "user2",
                DashboardProjectId = 1,
            });

            await seedContext.SaveChangesAsync();
        }

        await _service.Archive(1);

        using var assertContext = DbContextFactory.CreateDbContext();
        var user = assertContext.AspNetUsers
            .FirstOrDefault(p => p.Id.Equals("user2"));

        Assert.That(user.ExperiencePoints, Is.EqualTo(110));
    }
}
