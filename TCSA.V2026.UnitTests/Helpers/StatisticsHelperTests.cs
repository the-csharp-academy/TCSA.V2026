using TCSA.V2026.Data.Models;
using TCSA.V2026.Helpers;

namespace TCSA.V2026.UnitTests.Helpers;

[TestFixture]
public class StatisticsHelperTests
{
    private static readonly DateTimeOffset Now = new DateTimeOffset(2026, 3, 8, 12, 0, 0, TimeSpan.Zero);

    [Test]
    public void EmptyList_ReturnsZero()
    {
        var result = StatisticsHelper.CalculateAverageReviewTime(new List<DashboardProject>(), Now);
        Assert.That(result, Is.EqualTo(TimeSpan.Zero));
    }

    [Test]
    public void NullList_ReturnsZero()
    {
        var result = StatisticsHelper.CalculateAverageReviewTime(null, Now);
        Assert.That(result, Is.EqualTo(TimeSpan.Zero));
    }

    [Test]
    public void SingleCompletedProject_ReturnsCorrectDuration()
    {
        var projects = new List<DashboardProject>
        {
            new()
            {
                IsCompleted = true,
                IsPendingReview = false,
                DateSubmitted = Now.AddHours(-48),
                DateCompleted = Now.AddHours(-24)
            }
        };

        var result = StatisticsHelper.CalculateAverageReviewTime(projects, Now);
        Assert.That(result, Is.EqualTo(TimeSpan.FromHours(24)));
    }

    [Test]
    public void SinglePendingProject_ReturnsTimeSinceSubmitted()
    {
        var projects = new List<DashboardProject>
        {
            new()
            {
                IsCompleted = false,
                IsPendingReview = true,
                DateSubmitted = Now.AddHours(-10),
                DateCompleted = null
            }
        };

        var result = StatisticsHelper.CalculateAverageReviewTime(projects, Now);
        Assert.That(result, Is.EqualTo(TimeSpan.FromHours(10)));
    }

    [Test]
    public void MixedCompletedAndPending_ReturnsCorrectAverage()
    {
        var projects = new List<DashboardProject>
        {
            new()
            {
                IsCompleted = true,
                IsPendingReview = false,
                DateSubmitted = Now.AddHours(-48),
                DateCompleted = Now.AddHours(-24)
            },
            new()
            {
                IsCompleted = false,
                IsPendingReview = true,
                DateSubmitted = Now.AddHours(-10),
                DateCompleted = null
            }
        };

        // (24 + 10) / 2 = 17h
        var result = StatisticsHelper.CalculateAverageReviewTime(projects, Now);
        Assert.That(result, Is.EqualTo(TimeSpan.FromHours(17)));
    }

    [Test]
    public void ProjectsNeitherCompletedNorPending_AreIgnored()
    {
        var projects = new List<DashboardProject>
        {
            new()
            {
                IsCompleted = false,
                IsPendingReview = false,
                DateSubmitted = Now.AddHours(-100),
                DateCompleted = null
            }
        };

        var result = StatisticsHelper.CalculateAverageReviewTime(projects, Now);
        Assert.That(result, Is.EqualTo(TimeSpan.Zero));
    }

    [Test]
    public void MultipleCompletedProjects_ReturnsAverageDuration()
    {
        var projects = new List<DashboardProject>
        {
            new() { IsCompleted = true, DateSubmitted = Now.AddHours(-15), DateCompleted = Now.AddHours(-5) },
            new() { IsCompleted = true, DateSubmitted = Now.AddHours(-30), DateCompleted = Now.AddHours(-10) },
            new() { IsCompleted = true, DateSubmitted = Now.AddHours(-50), DateCompleted = Now.AddHours(-20) },
        };

        var result = StatisticsHelper.CalculateAverageReviewTime(projects, Now);
        Assert.That(result, Is.EqualTo(TimeSpan.FromHours(20)));
    }

    [Test]
    public void VeryShortReviewTime_ReturnsFractionalDuration()
    {
        var projects = new List<DashboardProject>
        {
            new()
            {
                IsCompleted = true,
                DateSubmitted = Now.AddMinutes(-30),
                DateCompleted = Now
            }
        };

        var result = StatisticsHelper.CalculateAverageReviewTime(projects, Now);
        Assert.That(result, Is.EqualTo(TimeSpan.FromMinutes(30)));
    }

    [Test]
    public void ListWithMixedValidAndIgnoredProjects_AveragesOnlyValidOnes()
    {
        var projects = new List<DashboardProject>
        {
            new() { IsCompleted = true, DateSubmitted = Now.AddHours(-20), DateCompleted = Now },
            new() { IsCompleted = false, IsPendingReview = false, DateSubmitted = Now.AddHours(-99), DateCompleted = null },
            new() { IsCompleted = false, IsPendingReview = true, DateSubmitted = Now.AddHours(-40), DateCompleted = null },
        };

        var result = StatisticsHelper.CalculateAverageReviewTime(projects, Now);
        Assert.That(result, Is.EqualTo(TimeSpan.FromHours(30)));
    }
}
