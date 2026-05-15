using TCSA.V2026.Data.Models;
using TCSA.V2026.Data.Models.Responses;
using TCSA.V2026.Services;

namespace TCSA.V2026.IntegrationTests;

public class PeerReviewTests : IntegrationTestsBase
{

    private PeerReviewService _service;

    [SetUp]
    public void Setup()
    {
        BaseSetup();
        _service = new PeerReviewService(DbContextFactory);
    }

    [TearDown]
    public void TearDown()
    {
        BaseTearDown();
    }

    [Test]
    public async Task GetProjectsForPeerReview_MathGameNotRetrieved()
    {
        var codeReviewsUrl = "https://github.com/TheCSharpAcademy/CodeReviews";

        using (var seedContext = DbContextFactory.CreateDbContext())
        {
            seedContext.DashboardProjects.AddRange(
                new DashboardProject
                {
                    Id = 1,
                    AppUserId = "user1",
                    ProjectId = (int)ArticleName.Calculator, // 11
                    IsPendingReview = true,
                    GithubUrl = $"{codeReviewsUrl}/Calculator",
                    DateSubmitted = DateTimeOffset.Now.AddDays(-3)
                },
                new DashboardProject
                {
                    Id = 2,
                    AppUserId = "user1",
                    ProjectId = (int)ArticleName.HabitLogger, // 12
                    IsPendingReview = true,
                    GithubUrl = $"{codeReviewsUrl}/HabitLogger",
                    DateSubmitted = DateTimeOffset.Now.AddDays(-2)
                },
                new DashboardProject
                {
                    Id = 3,
                    AppUserId = "user1",
                    ProjectId = (int)ArticleName.MathGame, // 53 - not in beginnerProjects
                    IsPendingReview = true,
                    GithubUrl = $"{codeReviewsUrl}/MathGame",
                    DateSubmitted = DateTimeOffset.Now.AddDays(-1)
                },
                new DashboardProject
                {
                    Id = 4,
                    AppUserId = "user1",
                    ProjectId = (int)ArticleName.PhoneBook,
                    IsPendingReview = true,
                    GithubUrl = $"{codeReviewsUrl}/PhoneBook",
                    DateSubmitted = DateTimeOffset.Now.AddDays(-1)
                }
            );

            await seedContext.SaveChangesAsync();
        }

        var projects = await _service.GetProjectsForPeerReview("user2");
        var count = projects.Count;
        Assert.That(count, Is.EqualTo(2));
    }

    [Test]
    public async Task GetProjectsForPeerReview_OrangeBeltCanSeeIntermediateProjects()
    {
        var codeReviewsUrl = "https://github.com/TheCSharpAcademy/CodeReviews";

        using (var seedContext = DbContextFactory.CreateDbContext())
        {
            seedContext.DashboardProjects.AddRange(
                new DashboardProject
                {
                    Id = 1,
                    AppUserId = "user1",
                    ProjectId = (int)ArticleName.Calculator, // 11
                    IsPendingReview = true,
                    GithubUrl = $"{codeReviewsUrl}/Calculator",
                    DateSubmitted = DateTimeOffset.Now.AddDays(-3)
                },
                new DashboardProject
                {
                    Id = 2,
                    AppUserId = "user1",
                    ProjectId = (int)ArticleName.HabitLogger, // 12
                    IsPendingReview = true,
                    GithubUrl = $"{codeReviewsUrl}/HabitLogger",
                    DateSubmitted = DateTimeOffset.Now.AddDays(-2)
                },
                new DashboardProject
                {
                    Id = 3,
                    AppUserId = "user1",
                    ProjectId = (int)ArticleName.MathGame, // 53 - not in beginnerProjects
                    IsPendingReview = true,
                    GithubUrl = $"{codeReviewsUrl}/MathGame",
                    DateSubmitted = DateTimeOffset.Now.AddDays(-1)
                },
                new DashboardProject
                {
                    Id = 4,
                    AppUserId = "user1",
                    ProjectId = (int)ArticleName.PhoneBook,
                    IsPendingReview = true,
                    GithubUrl = $"{codeReviewsUrl}/PhoneBook",
                    DateSubmitted = DateTimeOffset.Now.AddDays(-1)
                },
                new DashboardProject
                {
                    Id = 5,
                    AppUserId = "user1",
                    ProjectId = (int)ArticleName.UnitTesting,
                    IsPendingReview = true,
                    GithubUrl = $"{codeReviewsUrl}/UnitTesting",
                    DateSubmitted = DateTimeOffset.Now.AddDays(-1)
                }
            );

            await seedContext.SaveChangesAsync();
        }

        var projects = await _service.GetProjectsForPeerReview("orangeuser");
        var count = projects.Count;
        Assert.That(count, Is.EqualTo(3));
    }

    [Test]
    public async Task GetProjectsForPeerReview_PurpleBeltCanSeeAdvancedProjects()
    {
        var codeReviewsUrl = "https://github.com/TheCSharpAcademy/CodeReviews";

        using (var seedContext = DbContextFactory.CreateDbContext())
        {
            seedContext.DashboardProjects.AddRange(
                new DashboardProject
                {
                    Id = 1,
                    AppUserId = "user1",
                    ProjectId = (int)ArticleName.Calculator, // 11
                    IsPendingReview = true,
                    GithubUrl = $"{codeReviewsUrl}/Calculator",
                    DateSubmitted = DateTimeOffset.Now.AddDays(-3)
                },
                new DashboardProject
                {
                    Id = 2,
                    AppUserId = "user1",
                    ProjectId = (int)ArticleName.HabitLogger, // 12
                    IsPendingReview = true,
                    GithubUrl = $"{codeReviewsUrl}/HabitLogger",
                    DateSubmitted = DateTimeOffset.Now.AddDays(-2)
                },
                new DashboardProject
                {
                    Id = 3,
                    AppUserId = "user1",
                    ProjectId = (int)ArticleName.MathGame, // 53 - not in beginnerProjects
                    IsPendingReview = true,
                    GithubUrl = $"{codeReviewsUrl}/MathGame",
                    DateSubmitted = DateTimeOffset.Now.AddDays(-1)
                },
                new DashboardProject
                {
                    Id = 4,
                    AppUserId = "user1",
                    ProjectId = (int)ArticleName.PhoneBook,
                    IsPendingReview = true,
                    GithubUrl = $"{codeReviewsUrl}/PhoneBook",
                    DateSubmitted = DateTimeOffset.Now.AddDays(-1)
                },
                new DashboardProject
                {
                    Id = 5,
                    AppUserId = "user1",
                    ProjectId = (int)ArticleName.UnitTesting,
                    IsPendingReview = true,
                    GithubUrl = $"{codeReviewsUrl}/UnitTesting",
                    DateSubmitted = DateTimeOffset.Now.AddDays(-1)
                }
            );

            await seedContext.SaveChangesAsync();
        }

        var projects = await _service.GetProjectsForPeerReview("purpleuser");
        var count = projects.Count;
        Assert.That(count, Is.EqualTo(4));
    }

    [Test]
    public async Task MarkCodeReviewAsCompleted_ReviewerNotFound_ReturnsFail()
    {
        using (var seedContext = DbContextFactory.CreateDbContext())
        {
            seedContext.DashboardProjects.Add(new DashboardProject
            {
                Id = 1,
                AppUserId = "user1",
                ProjectId = (int)ArticleName.Calculator,
                IsPendingReview = true,
                GithubUrl = "https://github.com/TheCSharpAcademy/CodeReviews/Calculator"
            });
            await seedContext.SaveChangesAsync();
        }

        var response = await _service.MarkCodeReviewAsCompleted("nonexistent-reviewer", 1);

        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Fail));
        Assert.That(response.Message, Is.EqualTo("Reviewer not found."));
    }

    [Test]
    public async Task MarkCodeReviewAsCompleted_DashboardProjectNotFound_ReturnsFail()
    {
        var response = await _service.MarkCodeReviewAsCompleted("user2", 9999);

        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Fail));
        Assert.That(response.Message, Is.EqualTo("Dashboard project not found."));
    }

    [Test]
    public async Task MarkCodeReviewAsCompleted_ProjectAlreadyCompleted_ReturnsFail()
    {
        using (var seedContext = DbContextFactory.CreateDbContext())
        {
            seedContext.DashboardProjects.Add(new DashboardProject
            {
                Id = 1,
                AppUserId = "user1",
                ProjectId = (int)ArticleName.Calculator,
                IsCompleted = true,
                IsPendingReview = false,
                GithubUrl = "https://github.com/TheCSharpAcademy/CodeReviews/Calculator"
            });
            await seedContext.SaveChangesAsync();
        }

        var response = await _service.MarkCodeReviewAsCompleted("user2", 1);

        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Fail));
        Assert.That(response.Message, Is.EqualTo("Project is already marked as completed."));
    }

    [Test]
    public async Task MarkCodeReviewAsCompleted_ValidInput_ReturnsSuccess()
    {
        using (var seedContext = DbContextFactory.CreateDbContext())
        {
            seedContext.DashboardProjects.Add(new DashboardProject
            {
                Id = 1,
                AppUserId = "user1",
                ProjectId = (int)ArticleName.Calculator,
                IsPendingReview = true,
                GithubUrl = "https://github.com/TheCSharpAcademy/CodeReviews/Calculator"
            });
            await seedContext.SaveChangesAsync();
        }

        var response = await _service.MarkCodeReviewAsCompleted("user2", 1);

        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Success));
    }

    [Test]
    public async Task MarkCodeReviewAsCompleted_ValidInput_SetsProjectAsCompleted()
    {
        using (var seedContext = DbContextFactory.CreateDbContext())
        {
            seedContext.DashboardProjects.Add(new DashboardProject
            {
                Id = 1,
                AppUserId = "user1",
                ProjectId = (int)ArticleName.Calculator,
                IsPendingReview = true,
                GithubUrl = "https://github.com/TheCSharpAcademy/CodeReviews/Calculator"
            });
            await seedContext.SaveChangesAsync();
        }

        await _service.MarkCodeReviewAsCompleted("user2", 1);

        using var assertContext = DbContextFactory.CreateDbContext();
        var project = assertContext.DashboardProjects.FirstOrDefault(p => p.Id == 1);

        Assert.That(project, Is.Not.Null);
        Assert.That(project.IsCompleted, Is.True);
        Assert.That(project.IsPendingReview, Is.False);
        Assert.That(project.IsPendingNotification, Is.True);
        Assert.That(project.DateCompleted, Is.Not.Null);
    }

    [Test]
    public async Task MarkCodeReviewAsCompleted_ValidInput_CreatesActivityRecords()
    {
        using (var seedContext = DbContextFactory.CreateDbContext())
        {
            seedContext.DashboardProjects.Add(new DashboardProject
            {
                Id = 1,
                AppUserId = "user1",
                ProjectId = (int)ArticleName.Calculator,
                IsPendingReview = true,
                GithubUrl = "https://github.com/TheCSharpAcademy/CodeReviews/Calculator"
            });
            await seedContext.SaveChangesAsync();
        }

        await _service.MarkCodeReviewAsCompleted("user2", 1);

        using var assertContext = DbContextFactory.CreateDbContext();
        var ownerActivity = assertContext.UserActivity
            .FirstOrDefault(x => x.AppUserId == "user1" && x.ActivityType == ActivityType.ProjectCompleted);
        var reviewerActivity = assertContext.UserActivity
            .FirstOrDefault(x => x.AppUserId == "user2" && x.ActivityType == ActivityType.CodeReviewCompleted);

        Assert.That(ownerActivity, Is.Not.Null);
        Assert.That(ownerActivity.ProjectId, Is.EqualTo((int)ArticleName.Calculator));
        Assert.That(reviewerActivity, Is.Not.Null);
        Assert.That(reviewerActivity.ProjectId, Is.EqualTo((int)ArticleName.Calculator));
    }

    [Test]
    public async Task MarkCodeReviewAsCompleted_ValidInput_UpdatesReviewerExperiencePoints()
    {
        using (var seedContext = DbContextFactory.CreateDbContext())
        {
            seedContext.DashboardProjects.Add(new DashboardProject
            {
                Id = 1,
                AppUserId = "user1",
                ProjectId = (int)ArticleName.Calculator,
                IsPendingReview = true,
                GithubUrl = "https://github.com/TheCSharpAcademy/CodeReviews/Calculator"
            });
            await seedContext.SaveChangesAsync();
        }

        await _service.MarkCodeReviewAsCompleted("user2", 1);

        using var assertContext = DbContextFactory.CreateDbContext();
        var reviewer = assertContext.AspNetUsers.FirstOrDefault(u => u.Id == "user2");

        Assert.That(reviewer, Is.Not.Null);
        Assert.That(reviewer.ExperiencePoints, Is.EqualTo(110));
        Assert.That(reviewer.ReviewedProjects, Is.EqualTo(2));
    }

    [Test]
    public async Task MarkCodeReviewAsCompleted_ValidInput_UpdatesProjectOwnerExperiencePoints()
    {
        using (var seedContext = DbContextFactory.CreateDbContext())
        {
            seedContext.DashboardProjects.Add(new DashboardProject
            {
                Id = 1,
                AppUserId = "user1",
                ProjectId = (int)ArticleName.Calculator,
                IsPendingReview = true,
                GithubUrl = "https://github.com/TheCSharpAcademy/CodeReviews/Calculator"
            });
            await seedContext.SaveChangesAsync();
        }

        await _service.MarkCodeReviewAsCompleted("user2", 1);

        using var assertContext = DbContextFactory.CreateDbContext();
        var owner = assertContext.AspNetUsers.FirstOrDefault(u => u.Id == "user1");

        Assert.That(owner, Is.Not.Null);
        Assert.That(owner.ExperiencePoints, Is.EqualTo(10));
    }

    [Test]
    public async Task ReleaseUserFromCodeReview_UserReviewNotFound_ReturnsFail()
    {
        using (var seedContext = DbContextFactory.CreateDbContext())
        {
            seedContext.DashboardProjects.Add(new DashboardProject
            {
                Id = 1,
                AppUserId = "user10000",
                ProjectId = (int)ArticleName.Calculator,
                IsPendingReview = true,
                GithubUrl = "https://github.com/TheCSharpAcademy/CodeReviews/Calculator"
            });
            await seedContext.SaveChangesAsync();
        }

        var response = await _service.ReleaseUserFromCodeReview("user10000", 1);

        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Fail));
        Assert.That(response.Message, Is.EqualTo("User is Null"));
    }

    [Test]
    public async Task ReleaseUserFromCodeReview_ProjectAlreadyCompleted_ReturnsFail()
    {
        using (var seedContext = DbContextFactory.CreateDbContext())
        {
            seedContext.DashboardProjects.Add(new DashboardProject
            {
                Id = 1,
                AppUserId = "user1",
                ProjectId = (int)ArticleName.Calculator,
                IsCompleted = true,
                IsPendingReview = false,
                GithubUrl = "https://github.com/TheCSharpAcademy/CodeReviews/Calculator"
            });
            seedContext.UserReviews.Add(new UserReview
            {
                AppUserId = "user2",
                DashboardProjectId = 1
            });
            await seedContext.SaveChangesAsync();
        }

        var response = await _service.ReleaseUserFromCodeReview("user2", 1);

        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Fail));
        Assert.That(response.Message, Is.EqualTo("Project is already completed and cannot be released."));
    }

    [Test]
    public async Task ReleaseUserFromCodeReview_ValidInput_ReturnsSuccess()
    {
        using (var seedContext = DbContextFactory.CreateDbContext())
        {
            seedContext.DashboardProjects.Add(new DashboardProject
            {
                Id = 1,
                AppUserId = "user1",
                ProjectId = (int)ArticleName.Calculator,
                IsPendingReview = true,
                GithubUrl = "https://github.com/TheCSharpAcademy/CodeReviews/Calculator"
            });
            seedContext.UserReviews.Add(new UserReview
            {
                AppUserId = "user2",
                DashboardProjectId = 1
            });
            await seedContext.SaveChangesAsync();
        }

        var response = await _service.ReleaseUserFromCodeReview("user2", 1);

        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Success));
    }

    [Test]
    public async Task ReleaseUserFromCodeReview_ValidInput_RemovesUserReview()
    {
        using (var seedContext = DbContextFactory.CreateDbContext())
        {
            seedContext.DashboardProjects.Add(new DashboardProject
            {
                Id = 1,
                AppUserId = "user1",
                ProjectId = (int)ArticleName.Calculator,
                IsPendingReview = true,
                GithubUrl = "https://github.com/TheCSharpAcademy/CodeReviews/Calculator"
            });
            seedContext.UserReviews.Add(new UserReview
            {
                AppUserId = "user2",
                DashboardProjectId = 1
            });
            await seedContext.SaveChangesAsync();
        }

        await _service.ReleaseUserFromCodeReview("user2", 1);

        using var assertContext = DbContextFactory.CreateDbContext();
        var userReview = assertContext.UserReviews.FirstOrDefault(x => x.AppUserId == "user2" && x.DashboardProjectId == 1);

        Assert.That(userReview, Is.Null);
    }

    [Test]
    public async Task GetProjectsForPeerReview_GivenUserCompletedMVC_canSeeMVCProjects()
    {
        var codeReviewsUrl = "https://github.com/TheCSharpAcademy/CodeReviews";

        using (var seedContext = DbContextFactory.CreateDbContext())
        {
            seedContext.DashboardProjects.AddRange(
                new DashboardProject
                {
                    Id = 1,
                    AppUserId = "user1",
                    ProjectId = (int)ArticleName.Calculator, // 11
                    IsPendingReview = true,
                    GithubUrl = $"{codeReviewsUrl}/Calculator",
                    DateSubmitted = DateTimeOffset.Now.AddDays(-3)
                },
                new DashboardProject
                {
                    Id = 2,
                    AppUserId = "user1",
                    ProjectId = (int)ArticleName.HabitLogger, // 12
                    IsPendingReview = true,
                    GithubUrl = $"{codeReviewsUrl}/HabitLogger",
                    DateSubmitted = DateTimeOffset.Now.AddDays(-2)
                },
                new DashboardProject
                {
                    Id = 3,
                    AppUserId = "user1",
                    ProjectId = (int)ArticleName.MathGame, // 53 - not in beginnerProjects
                    IsPendingReview = true,
                    GithubUrl = $"{codeReviewsUrl}/MathGame",
                    DateSubmitted = DateTimeOffset.Now.AddDays(-1)
                },
                new DashboardProject
                {
                    Id = 4,
                    AppUserId = "user1",
                    ProjectId = (int)ArticleName.PhoneBook,
                    IsPendingReview = true,
                    GithubUrl = $"{codeReviewsUrl}/PhoneBook",
                    DateSubmitted = DateTimeOffset.Now.AddDays(-1)
                },
                new DashboardProject
                {
                    Id = 5,
                    AppUserId = "user1",
                    ProjectId = (int)ArticleName.UnitTesting,
                    IsPendingReview = true,
                    GithubUrl = $"{codeReviewsUrl}/UnitTesting",
                    DateSubmitted = DateTimeOffset.Now.AddDays(-1)
                },
                new DashboardProject
                {
                    Id = 6,
                    AppUserId = "user1",
                    ProjectId = (int)ArticleName.WaterLogger,
                    IsPendingReview = true,
                    GithubUrl = $"{codeReviewsUrl}/WaterLogger",
                    DateSubmitted = DateTimeOffset.Now.AddDays(-1)
                },
                new DashboardProject
                {
                    Id = 7,
                    AppUserId = "user1",
                    ProjectId = (int)ArticleName.Budget,
                    IsPendingReview = true,
                    GithubUrl = $"{codeReviewsUrl}/Budget",
                    DateSubmitted = DateTimeOffset.Now.AddDays(-1)
                }
            );

            await seedContext.SaveChangesAsync();
        }

        var projects = await _service.GetProjectsForPeerReview("purpleuser");
        var count = projects.Count;
        Assert.That(count, Is.EqualTo(5));
    }
}