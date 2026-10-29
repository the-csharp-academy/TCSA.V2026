using TCSA.V2026.Data.Enums;
using TCSA.V2026.Helpers;

namespace TCSA.V2026.UnitTests.Helpers;

[TestFixture]
public class FeedbackAreaHelperTests
{
    [TestCase("/dashboard", FeedbackArea.Dashboard)]
    [TestCase("/dashboard/roadmap", FeedbackArea.Dashboard)]
    [TestCase("/dashboard/statistics", FeedbackArea.Dashboard)]
    [TestCase("/dashboard/activity", FeedbackArea.Dashboard)]
    [TestCase("/project/12/water-logger", FeedbackArea.Projects)]
    [TestCase("/gallery", FeedbackArea.Projects)]
    [TestCase("/dashboard/courses", FeedbackArea.CoursesArticles)]
    [TestCase("/course/1/article/2/3/false", FeedbackArea.CoursesArticles)]
    [TestCase("/article/12/some-article", FeedbackArea.CoursesArticles)]
    [TestCase("/articles", FeedbackArea.CoursesArticles)]
    [TestCase("/articles/csharp", FeedbackArea.CoursesArticles)]
    [TestCase("/dashboard/reviews", FeedbackArea.PeerReviews)]
    [TestCase("/dashboard/leaderboard", FeedbackArea.Leaderboard)]
    [TestCase("/dashboard/community", FeedbackArea.Community)]
    [TestCase("/feed", FeedbackArea.Community)]
    [TestCase("/dashboard/challenges", FeedbackArea.Challenges)]
    [TestCase("/dashboard/profile", FeedbackArea.Profile)]
    [TestCase("/profile/some-user-id", FeedbackArea.Profile)]
    public void FromPath_MapsRoutePrefixToArea(string path, FeedbackArea expected)
    {
        Assert.That(FeedbackAreaHelper.FromPath(path), Is.EqualTo(expected));
    }

    [TestCase("/")]
    [TestCase("/about")]
    [TestCase("/contribute")]
    [TestCase("/search")]
    [TestCase("/something/that/does/not/exist")]
    public void FromPath_UnknownRoutesAreOther(string path)
    {
        Assert.That(FeedbackAreaHelper.FromPath(path), Is.EqualTo(FeedbackArea.Other));
    }

    [TestCase("/Dashboard/Profile", FeedbackArea.Profile)]
    [TestCase("/dashboard/profile/", FeedbackArea.Profile)]
    [TestCase("/dashboard/profile?tab=badges", FeedbackArea.Profile)]
    [TestCase("dashboard/profile", FeedbackArea.Profile)]
    public void FromPath_NormalizesBeforeMatching(string path, FeedbackArea expected)
    {
        Assert.That(FeedbackAreaHelper.FromPath(path), Is.EqualTo(expected));
    }

    [TestCase("/dashboardfoo")]
    [TestCase("/dashboard/profiles")]
    [TestCase("/articlesfoo")]
    public void FromPath_OnlyMatchesWholePathSegments(string path)
    {
        Assert.That(FeedbackAreaHelper.FromPath(path), Is.Not.EqualTo(FeedbackArea.Profile));
        Assert.That(FeedbackAreaHelper.FromPath(path), Is.Not.EqualTo(FeedbackArea.CoursesArticles));
    }

    [Test]
    public void FromPath_NullIsOther()
    {
        Assert.That(FeedbackAreaHelper.FromPath(null), Is.EqualTo(FeedbackArea.Other));
    }
}
