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
    }

    [TestCaseSource(nameof(ActiveFilters))]
    public void Filter_WithAnyCriterion_IsActive(FeedbackAdminFilter filter)
    {
        Assert.That(filter.IsActive, Is.True);
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
