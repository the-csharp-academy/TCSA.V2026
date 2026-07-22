using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Moq;
using TCSA.V2026.Data;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Data.Models.Responses;
using TCSA.V2026.Services;

namespace TCSA.V2026.UnitTests.Services;

[TestFixture]
public class ProjectServiceResetCourseTests
{
    private DbContextOptions<ApplicationDbContext> _options = null!;
    private ProjectService _sut = null!;

    [SetUp]
    public void SetUp()
    {
        var databaseRoot = new InMemoryDatabaseRoot();
        _options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase($"reset-course-{Guid.NewGuid()}", databaseRoot)
            .Options;

        var factory = new Mock<IDbContextFactory<ApplicationDbContext>>();
        factory.Setup(x => x.CreateDbContext()).Returns(() => new ApplicationDbContext(_options));
        _sut = new ProjectService(factory.Object);
    }

    [Test]
    public async Task ResetCourse_DeletesCourseRecordsAndSubtractsCompletedChapterXpOnly()
    {
        var course = CreateCourse();
        await using (var context = new ApplicationDbContext(_options))
        {
            context.Users.Add(User(experiencePoints: 20));
            context.DashboardProjects.AddRange(
                Project("user-1", 101, completed: true),
                Project("user-1", 102, completed: false),
                Project("user-1", 999, completed: true));
            context.UserActivity.AddRange(
                Activity("user-1", 101),
                Activity("user-1", 102),
                Activity("user-1", 999));
            await context.SaveChangesAsync();
        }

        var result = await _sut.ResetCourse("user-1", course);

        Assert.That(result.Status, Is.EqualTo(ResponseStatus.Success));
        await using var verification = new ApplicationDbContext(_options);
        Assert.Multiple(() =>
        {
            Assert.That(verification.DashboardProjects.Count(x => x.AppUserId == "user-1"), Is.EqualTo(1));
            Assert.That(verification.DashboardProjects.Single().ProjectId, Is.EqualTo(999));
            Assert.That(verification.UserActivity.Count(x => x.AppUserId == "user-1"), Is.EqualTo(1));
            Assert.That(verification.UserActivity.Single().ProjectId, Is.EqualTo(999));
            Assert.That(verification.Users.Single(x => x.Id == "user-1").ExperiencePoints, Is.EqualTo(17));
        });
    }

    [Test]
    public async Task ResetCourse_DoesNotSubtractXpTwiceForDuplicateActivityRecords()
    {
        var course = CreateCourse();
        await using (var context = new ApplicationDbContext(_options))
        {
            context.Users.Add(User(experiencePoints: 10));
            context.DashboardProjects.Add(Project("user-1", 101, completed: true));
            context.UserActivity.AddRange(Activity("user-1", 101), Activity("user-1", 101));
            await context.SaveChangesAsync();
        }

        var result = await _sut.ResetCourse("user-1", course);

        Assert.That(result.Status, Is.EqualTo(ResponseStatus.Success));
        await using var verification = new ApplicationDbContext(_options);
        Assert.That(verification.Users.Single().ExperiencePoints, Is.EqualTo(7));
    }

    [Test]
    public async Task ResetCourse_NeverMakesExperiencePointsNegative()
    {
        var course = CreateCourse();
        await using (var context = new ApplicationDbContext(_options))
        {
            context.Users.Add(User(experiencePoints: 1));
            context.DashboardProjects.Add(Project("user-1", 102, completed: true));
            await context.SaveChangesAsync();
        }

        await _sut.ResetCourse("user-1", course);

        await using var verification = new ApplicationDbContext(_options);
        Assert.That(verification.Users.Single().ExperiencePoints, Is.Zero);
    }

    private static Course CreateCourse() => new()
    {
        Id = 1,
        Articles =
        [
            new Article { Id = 101, ExperiencePoints = 3 },
            new Article { Id = 102, ExperiencePoints = 5 }
        ]
    };

    private static DashboardProject Project(string userId, int articleId, bool completed) => new()
    {
        AppUserId = userId,
        ProjectId = articleId,
        IsCompleted = completed,
        GithubUrl = string.Empty
    };

    private static AppUserActivity Activity(string userId, int articleId) => new()
    {
        AppUserId = userId,
        ProjectId = articleId,
        ActivityType = ActivityType.ArticleRead
    };

    private static ApplicationUser User(int experiencePoints) => new()
    {
        Id = "user-1",
        UserName = "user-1",
        FirstName = "Test",
        LastName = "User",
        Country = "AU",
        ExperiencePoints = experiencePoints
    };
}
