using TCSA.V2026.Data.Curriculum;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Services;

namespace TCSA.V2026.IntegrationTests;

[TestFixture]
public class ReportServiceTests : IntegrationTestsBase
{
    private ReportService _service;

    [SetUp]
    public void Setup()
    {
        BaseSetup();
        _service = new ReportService(DbContextFactory);
    }

    [TearDown]
    public void TearDown()
    {
        BaseTearDown();
    }

    [Test]
    public async Task GetCourseCount_NoCompletedArticles_ReturnsZeroForEveryCourse()
    {
        var result = await _service.GetCourseCount();

        Assert.Multiple(() =>
        {
            Assert.That(result.IsSuccess, Is.True);
            Assert.That(result.Value.Keys, Is.EquivalentTo(CourseHelper.GetCourses().Select(c => c.Title)));
            Assert.That(result.Value.Values, Is.All.Zero);
        });
    }

    [Test]
    public async Task GetCourseCount_CompletedArticles_AreCountedPerCourse()
    {
        var course = CourseHelper.GetCourses().First(c => c.Articles.Count >= 3);
        var articles = course.Articles.Take(3).ToList();

        using (var seedContext = DbContextFactory.CreateDbContext())
        {
            seedContext.DashboardProjects.AddRange(
                new DashboardProject { ProjectId = articles[0].Id, AppUserId = "user1", IsCompleted = true, GithubUrl = string.Empty },
                new DashboardProject { ProjectId = articles[1].Id, AppUserId = "user1", IsCompleted = true, GithubUrl = string.Empty },
                new DashboardProject { ProjectId = articles[2].Id, AppUserId = "user1", IsCompleted = false, GithubUrl = string.Empty });
            await seedContext.SaveChangesAsync();
        }

        var result = await _service.GetCourseCount();

        Assert.Multiple(() =>
        {
            Assert.That(result.IsSuccess, Is.True);
            Assert.That(result.Value[course.Title], Is.EqualTo(2));
        });
    }
}
