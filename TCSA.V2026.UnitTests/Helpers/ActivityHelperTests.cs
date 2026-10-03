using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using TCSA.V2026.Data.DTOs;
using TCSA.V2026.Data.Helpers;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Helpers;

namespace TCSA.V2026.UnitTests.Helpers;

[TestFixture]
public class ActivityHelperTests
{
    [SetUp]
    public void SetUp()
    {
        var mockConfig = new Mock<IConfiguration>();
        mockConfig.Setup(c => c["LinkProvider:DiscordLink"]).Returns("https://discord.gg/test");

        ServiceProviderAccessor.ServiceProvider = new ServiceCollection()
            .AddSingleton(mockConfig.Object)
            .BuildServiceProvider();
    }

    [Test]
    public void ArticlesShouldReturnCorrectActivity()
    {
        var user = new ApplicationUser
        {
            Id = Guid.NewGuid().ToString(),
            ExperiencePoints = 126,
            DashboardProjects = new List<DashboardProject>
            {
                new DashboardProject
                {
                    ProjectId = (int) ArticleName.StartHere,
                    IsCompleted = true,
                },
                new DashboardProject
                {
                    ProjectId = (int) ArticleName.HabitLogger,
                    IsCompleted = true,
                },
                new DashboardProject
                {
                    ProjectId = (int) ArticleName.CoursesOopFirst,
                    IsCompleted = true,
                }
            },
            Issues = new List<CommunityIssue>
            {
                new CommunityIssue
                {
                    ProjectId = 1000,
                    ExperiencePoints = 100,
                    Title = "Test Issue 1"
                }
            },
            UserActivity = new List<AppUserActivity>
            {
                new AppUserActivity
                {
                    DateSubmitted = DateTime.Now.AddDays(-7),
                    ProjectId =  (int) ArticleName.StartHere,
                    ActivityType = ActivityType.ArticleRead,
                },
                new AppUserActivity
                {
                    DateSubmitted = DateTime.Now.AddDays(-6),
                    ProjectId =  (int) ArticleName.HabitLogger,
                    ActivityType = ActivityType.ProjectSubmitted
                },
                new AppUserActivity
                {
                    DateSubmitted = DateTime.Now.AddDays(-5),
                    ProjectId =  (int) ArticleName.HabitLogger,
                    ActivityType = ActivityType.ProjectCompleted
                },
                new AppUserActivity
                {
                    DateSubmitted = DateTime.Now.AddDays(-4),
                    ProjectId =  (int) ArticleName.CoursesOopFirst,
                    ActivityType = ActivityType.ArticleRead
                },
                new AppUserActivity
                {
                    DateSubmitted = DateTime.Now.AddDays(-3),
                    ProjectId =  263,
                    ActivityType = ActivityType.IssueSubmitted
                },
                new AppUserActivity
                {
                    DateSubmitted = DateTime.Now.AddDays(-2),
                    ProjectId =  1000,
                    ActivityType = ActivityType.ProjectCompleted
                },
                new AppUserActivity
                {
                    DateSubmitted = DateTime.Now.AddDays(-1),
                    ProjectId =  (int) ArticleName.MathGame,
                    ActivityType = ActivityType.CodeReviewCompleted
                },
            }
        };

        List<ActivityDisplay> actual = ActivityHelper.GetActivityDisplay(user);
        //List<ActivityDisplay> expected = new List<ActivityDisplay>
        //{
        //    new ActivityDisplay
        //    {
        //        ActivityType = ActivityType.ArticleRead
        //    },
        //    new ActivityDisplay
        //    {
        //        ActivityType = ActivityType.ArticleRead
        //    }
        //    new 
        //};

        Assert.That(actual[0].CurrentExperiencePoints, Is.EqualTo(126));
        Assert.That(actual[1].CurrentExperiencePoints, Is.EqualTo(116));
        Assert.That(actual[2].CurrentExperiencePoints, Is.EqualTo(16));
        Assert.That(actual[3].CurrentExperiencePoints, Is.EqualTo(16));
        Assert.That(actual[4].CurrentExperiencePoints, Is.EqualTo(15));
        Assert.That(actual[5].CurrentExperiencePoints, Is.EqualTo(5));
        Assert.That(actual[6].CurrentExperiencePoints, Is.EqualTo(5));
    }

    [Test]
    public void FreestyleProject_MultipleCompletions_BothAppearButSecondIsFlaggedAsDuplicateByDescription()
    {
        var user = new ApplicationUser
        {
            Id = Guid.NewGuid().ToString(),
            ExperiencePoints = 40,
            UserActivity = new List<AppUserActivity>
            {
                new AppUserActivity
                {
                    DateSubmitted = DateTime.Now.AddDays(-2),
                    ProjectId = (int) ArticleName.FreestyleProject,
                    ActivityType = ActivityType.ProjectCompleted,
                },
                new AppUserActivity
                {
                    DateSubmitted = DateTime.Now.AddDays(-1),
                    ProjectId = (int) ArticleName.FreestyleProject,
                    ActivityType = ActivityType.ProjectCompleted,
                }
            }
        };

        List<ActivityDisplay> actual = ActivityHelper.GetActivityDisplay(user);

        // Both completions must still show up, most recent first (OrderByDescending DateSubmitted).
        Assert.That(actual.Count, Is.EqualTo(2));
        Assert.That(actual[0].Description, Does.Contain("Free Style Project"));
        Assert.That(actual[1].Description, Does.Contain("Free Style Project"));

        // Documents the current false-positive: identical descriptions from repeat Freestyle
        // completions get flagged as duplicates even though they're legitimate separate submissions.
        // CheckForDupes iterates newest-first and flags the second (older) occurrence it sees.
        Assert.That(actual[0].IsDuplicate, Is.False);
        Assert.That(actual[1].IsDuplicate, Is.True);
    }
}
