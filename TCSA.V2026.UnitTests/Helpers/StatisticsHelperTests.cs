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
    public void SingleCompletedProject_ReturnsTimeSinceSubmitted()
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

        // New logic measures time since submission regardless of completion
        var result = StatisticsHelper.CalculateAverageReviewTime(projects, Now);
        Assert.That(result, Is.EqualTo(TimeSpan.FromHours(48)));
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
    public void MixedCompletedAndPending_ReturnsAverageTimeSinceSubmitted()
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

        // (48 + 10) / 2 = 29h
        var result = StatisticsHelper.CalculateAverageReviewTime(projects, Now);
        Assert.That(result, Is.EqualTo(TimeSpan.FromHours(29)));
    }

    [Test]
    public void MultipleProjects_ReturnsAverageTimeSinceSubmitted()
    {
        var projects = new List<DashboardProject>
        {
            new() { DateSubmitted = Now.AddHours(-10) },
            new() { DateSubmitted = Now.AddHours(-20) },
            new() { DateSubmitted = Now.AddHours(-30) },
        };

        // (10 + 20 + 30) / 3 = 20h
        var result = StatisticsHelper.CalculateAverageReviewTime(projects, Now);
        Assert.That(result, Is.EqualTo(TimeSpan.FromHours(20)));
    }

    [Test]
    public void FlagsAreIgnored_AllProjectsCounted()
    {
        var projects = new List<DashboardProject>
        {
            new() { IsCompleted = true, IsPendingReview = false, DateSubmitted = Now.AddHours(-20) },
            new() { IsCompleted = false, IsPendingReview = false, DateSubmitted = Now.AddHours(-40) },
            new() { IsCompleted = false, IsPendingReview = true, DateSubmitted = Now.AddHours(-60) },
        };

        // (20 + 40 + 60) / 3 = 40h — IsCompleted / IsPendingReview no longer filter anything
        var result = StatisticsHelper.CalculateAverageReviewTime(projects, Now);
        Assert.That(result, Is.EqualTo(TimeSpan.FromHours(40)));
    }

    [Test]
    public void VeryShortTimeSinceSubmitted_ReturnsFractionalDuration()
    {
        var projects = new List<DashboardProject>
        {
            new() { DateSubmitted = Now.AddMinutes(-30) }
        };

        var result = StatisticsHelper.CalculateAverageReviewTime(projects, Now);
        Assert.That(result, Is.EqualTo(TimeSpan.FromMinutes(30)));
    }
}
