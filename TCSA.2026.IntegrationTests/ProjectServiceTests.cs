using Microsoft.Extensions.Logging.Abstractions;
using TCSA.V2026.Data.Enums;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Data.Models.Responses;
using TCSA.V2026.Services;

namespace TCSA.V2026.IntegrationTests;

[TestFixture]
public class ProjectServiceTests : IntegrationTestsBase
{
    private ProjectService _service;
    private BadgeService _badgeService;

    [SetUp]
    public void Setup()
    {
        BaseSetup();
        _badgeService = new BadgeService(DbContextFactory, NullLogger<BadgeService>.Instance);
        _service = new ProjectService(DbContextFactory, _badgeService);
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
    public async Task ArchivedArticleCanBeReopened()
    {
        using (var seedContext = DbContextFactory.CreateDbContext())
        {
            seedContext.DashboardProjects.Add(new DashboardProject
            {
                Id = 1,
                AppUserId = "user1",
                ProjectId = (int)ArticleName.StartHere,
                IsArchived = true,
                IsPendingNotification = false,
                IsPendingReview = false,
                DateSubmitted = DateTime.Now.AddDays(-10),
                GithubUrl = "fakeUrl1"
            });

            await seedContext.SaveChangesAsync();
        }

        await _service.MarkArticleAsRead((int)ArticleName.StartHere, "user1");

        using var assertContext = DbContextFactory.CreateDbContext();
        var list = assertContext.DashboardProjects
            .Where(p => p.ProjectId == (int)ArticleName.StartHere && p.AppUserId == "user1")
            .ToList();

        Assert.That(list.Count, Is.EqualTo(2));
    }

    [Test]
    public async Task CreateDashboardProject_SetsExpectedFieldsAndLogsActivity()
    {
        await _service.CreateDashboardProject(12, "user1", "fakeUrl");

        using var assertContext = DbContextFactory.CreateDbContext();
        var project = assertContext.DashboardProjects
            .First(p => p.ProjectId == 12 && p.AppUserId == "user1");

        Assert.That(project.IsPendingReview, Is.True);
        Assert.That(project.IsCompleted, Is.False);
        Assert.That(project.IsArchived, Is.False);
        Assert.That(project.GithubUrl, Is.EqualTo("fakeUrl"));

        var activity = assertContext.UserActivity
            .FirstOrDefault(a => a.AppUserId == "user1" && a.ProjectId == 12 && a.ActivityType == ActivityType.ProjectSubmitted);

        Assert.That(activity, Is.Not.Null);
    }

    [Test]
    public async Task UpdateDashboardProjectUrl_UpdatesGithubUrl()
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
                DateSubmitted = DateTime.Now.AddDays(-1),
                GithubUrl = "fakeUrl1"
            });

            await seedContext.SaveChangesAsync();
        }

        var response = await _service.UpdateDashboardProjectUrl(12, "user1", "updatedUrl");

        using var assertContext = DbContextFactory.CreateDbContext();
        var project = assertContext.DashboardProjects.First(p => p.ProjectId == 12 && p.AppUserId == "user1");

        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Success));
        Assert.That(project.GithubUrl, Is.EqualTo("updatedUrl"));
    }

    [Test]
    public async Task UpdateDashboardProjectUrl_NoMatchingProject_ReturnsFail()
    {
        var response = await _service.UpdateDashboardProjectUrl(12, "user1", "updatedUrl");

        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Fail));
    }

    [Test]
    public async Task MarkArticleAsRead_CalledTwice_DoesNotDuplicateOrDoubleAwardXp()
    {
        await _service.MarkArticleAsRead((int)ArticleName.StartHere, "user1");
        await _service.MarkArticleAsRead((int)ArticleName.StartHere, "user1");

        using var assertContext = DbContextFactory.CreateDbContext();
        var list = assertContext.DashboardProjects
            .Where(p => p.ProjectId == (int)ArticleName.StartHere && p.AppUserId == "user1")
            .ToList();

        Assert.That(list.Count, Is.EqualTo(1));

        var user = assertContext.AspNetUsers.First(u => u.Id == "user1");
        Assert.That(user.ExperiencePoints, Is.EqualTo(5));
    }

    [Test]
    public async Task MarkArticleAsRead_SetsExpectedFieldsAndLogsActivity()
    {
        await _service.MarkArticleAsRead((int)ArticleName.StartHere, "user1");

        using var assertContext = DbContextFactory.CreateDbContext();
        var project = assertContext.DashboardProjects
            .First(p => p.ProjectId == (int)ArticleName.StartHere && p.AppUserId == "user1");

        Assert.That(project.IsCompleted, Is.True);
        Assert.That(project.IsPendingReview, Is.False);
        Assert.That(project.GithubUrl, Is.Empty);

        var activity = assertContext.UserActivity
            .FirstOrDefault(a => a.AppUserId == "user1" && a.ProjectId == (int)ArticleName.StartHere && a.ActivityType == ActivityType.ArticleRead);

        Assert.That(activity, Is.Not.Null);
    }

    [Test]
    public async Task MarkArticleAsRead_UnknownUser_DoesNothing()
    {
        var response = await _service.MarkArticleAsRead((int)ArticleName.StartHere, "nonexistent-user");

        using var assertContext = DbContextFactory.CreateDbContext();
        var list = assertContext.DashboardProjects.Where(p => p.AppUserId == "nonexistent-user").ToList();

        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Success));
        Assert.That(list, Is.Empty);
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

    [Test]
    public async Task MarkAsCompleted_CommunityIssue_AwardsPlatformBuilderBadge()
    {
        const int communityProjectId = 999999;

        using (var seedContext = DbContextFactory.CreateDbContext())
        {
            seedContext.DashboardProjects.Add(new DashboardProject
            {
                Id = 1,
                AppUserId = "user1",
                ProjectId = communityProjectId,
                GithubUrl = "https://github.com/TheCSharpAcademy/CommunityRepo/pull/1"
            });
            seedContext.Issues.Add(new CommunityIssue
            {
                ProjectId = communityProjectId,
                AppUserId = "user1",
                Title = "Community issue",
                GithubUrl = "https://github.com/TheCSharpAcademy/CommunityRepo/issues/1",
                IconUrl = "icons8-feature-64.png",
                ExperiencePoints = 15,
                IsClosed = false
            });

            await seedContext.SaveChangesAsync();
        }

        await _service.MarkAsCompleted(1);

        using var assertContext = DbContextFactory.CreateDbContext();
        var badge = assertContext.Badges.FirstOrDefault(b => b.UserId == "user1" && b.BadgeId == (int)BadgeId.PlatformBuilder);

        Assert.That(badge, Is.Not.Null);
    }

    [Test]
    public async Task MarkAsCompleted_CurriculumProject_DoesNotAwardPlatformBuilderBadge()
    {
        using (var seedContext = DbContextFactory.CreateDbContext())
        {
            seedContext.DashboardProjects.Add(new DashboardProject
            {
                Id = 100,
                AppUserId = "user1",
                ProjectId = (int)ArticleName.Calculator,
                GithubUrl = "fakeUrl"
            });

            await seedContext.SaveChangesAsync();
        }

        await _service.MarkAsCompleted(100);

        using var assertContext = DbContextFactory.CreateDbContext();
        var badgeCount = assertContext.Badges.Count(b => b.UserId == "user1");

        Assert.That(badgeCount, Is.EqualTo(0));
    }

    [Test]
    public async Task MarkAsCompleted_ProjectNotFound_DoesNotAwardAnyBadge()
    {
        var response = await _service.MarkAsCompleted(9999);

        using var assertContext = DbContextFactory.CreateDbContext();
        var badgeCount = assertContext.Badges.Count();

        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Fail));
        Assert.That(badgeCount, Is.EqualTo(0));
    }
}
