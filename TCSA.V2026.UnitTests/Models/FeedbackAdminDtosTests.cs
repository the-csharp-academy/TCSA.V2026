using TCSA.V2026.Data.DTOs;
using TCSA.V2026.Data.Enums;

namespace TCSA.V2026.UnitTests.Models;

[TestFixture]
public class FeedbackAdminDtosTests
{
    [Test]
    public void Filter_Empty_IsNotActive()
    {
        Assert.That(new FeedbackAdminFilter().IsActive, Is.False);
    }

    [Test]
    public void Filter_BlankSearch_IsNotActive()
    {
        Assert.That(new FeedbackAdminFilter { Search = "   " }.IsActive, Is.False);
    }

    private static IEnumerable<TestCaseData> ActiveFilters()
    {
        yield return new TestCaseData(new FeedbackAdminFilter { Category = FeedbackCategory.Bug }).SetName("Category");
        yield return new TestCaseData(new FeedbackAdminFilter { ReviewState = FeedbackReviewState.New }).SetName("ReviewState");
        yield return new TestCaseData(new FeedbackAdminFilter { Area = FeedbackArea.Profile }).SetName("Area");
        yield return new TestCaseData(new FeedbackAdminFilter { Search = "save" }).SetName("Search");
        yield return new TestCaseData(new FeedbackAdminFilter { From = DateTimeOffset.UnixEpoch }).SetName("From");
        yield return new TestCaseData(new FeedbackAdminFilter { To = DateTimeOffset.UnixEpoch }).SetName("To");
        yield return new TestCaseData(new FeedbackAdminFilter { Cluster = new FeedbackClusterKey(FeedbackCategory.Bug, "/") }).SetName("Cluster");
    }

    [TestCaseSource(nameof(ActiveFilters))]
    public void Filter_WithAnyCriterion_IsActive(FeedbackAdminFilter filter)
    {
        Assert.That(filter.IsActive, Is.True);
    }

    [Test]
    public void ClusterKey_ForABug_UsesTheReportedPage()
    {
        var item = new FeedbackAdminItemDto { Category = FeedbackCategory.Bug, ReportedPage = "/dashboard/profile", OriginUrl = "/dashboard" };

        Assert.That(item.ClusterKey, Is.EqualTo(new FeedbackClusterKey(FeedbackCategory.Bug, "/dashboard/profile")));
    }

    [Test]
    public void ClusterKey_ForAnIdea_UsesTheOriginPath()
    {
        var item = new FeedbackAdminItemDto { Category = FeedbackCategory.Idea, OriginUrl = "/dashboard" };

        Assert.That(item.ClusterKey, Is.EqualTo(new FeedbackClusterKey(FeedbackCategory.Idea, "/dashboard")));
    }

    [TestCase(FeedbackCategory.Compliment)]
    [TestCase(FeedbackCategory.Help)]
    public void ClusterKey_ForHelpAndCompliment_UsesTheOriginPath(FeedbackCategory category)
    {
        var item = new FeedbackAdminItemDto { Category = category, OriginUrl = "/dashboard" };

        Assert.That(item.ClusterKey, Is.EqualTo(new FeedbackClusterKey(category, "/dashboard")));
    }

    [Test]
    public void Location_PrefersTheReportedPage()
    {
        var item = new FeedbackAdminItemDto { ReportedPage = "/dashboard/profile", OriginUrl = "/dashboard" };

        Assert.That(item.Location, Is.EqualTo("/dashboard/profile"));
    }

    [TestCase(null)]
    [TestCase("")]
    public void Location_FallsBackToTheOriginUrl(string? reportedPage)
    {
        var item = new FeedbackAdminItemDto { ReportedPage = reportedPage, OriginUrl = "/dashboard" };

        Assert.That(item.Location, Is.EqualTo("/dashboard"));
    }

    [Test]
    public void UserLabel_PrefersTheDisplayName()
    {
        var item = new FeedbackAdminItemDto { UserDisplayName = "Ada", UserName = "ada@example.com" };

        Assert.That(item.UserLabel, Is.EqualTo("Ada"));
    }

    [Test]
    public void UserLabel_FallsBackToTheUserNameWithoutTheEmailDomain()
    {
        var item = new FeedbackAdminItemDto { UserDisplayName = null, UserName = "ada@example.com" };

        Assert.That(item.UserLabel, Is.EqualTo("ada"));
    }
}
