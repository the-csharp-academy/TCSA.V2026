using TCSA.V2026.Helpers;

namespace TCSA.V2026.UnitTests.Helpers;

[TestFixture]
public class FeedbackPageHelperTests
{
    [TestCase("/dashboard/profile", "/dashboard/profile")]
    [TestCase("  /dashboard/profile  ", "/dashboard/profile")]
    [TestCase("/Dashboard/Profile", "/dashboard/profile")]
    [TestCase("/dashboard/profile/", "/dashboard/profile")]
    [TestCase("/dashboard/profile?tab=badges", "/dashboard/profile")]
    [TestCase("/dashboard/profile/?tab=badges&x=1", "/dashboard/profile")]
    [TestCase("/dashboard/profile#top", "/dashboard/profile")]
    [TestCase("/Article/12/My-Slug/?Q=Foo#Bar", "/article/12/my-slug")]
    public void Normalize_AppliesTheSpecRules(string input, string expected)
    {
        Assert.That(FeedbackPageHelper.Normalize(input), Is.EqualTo(expected));
    }

    [TestCase("dashboard/profile", "/dashboard/profile")]
    [TestCase("dashboard/profile?tab=badges", "/dashboard/profile")]
    public void Normalize_AddsMissingLeadingSlash(string input, string expected)
    {
        Assert.That(FeedbackPageHelper.Normalize(input), Is.EqualTo(expected));
    }

    [TestCase("https://thecsharpacademy.com/dashboard/profile?tab=badges", "/dashboard/profile")]
    [TestCase("https://thecsharpacademy.com/Dashboard/", "/dashboard")]
    [TestCase("https://thecsharpacademy.com", "/")]
    public void Normalize_ReducesAbsoluteUrlsToTheirPath(string input, string expected)
    {
        Assert.That(FeedbackPageHelper.Normalize(input), Is.EqualTo(expected));
    }

    [TestCase("/")]
    [TestCase("")]
    [TestCase("   ")]
    [TestCase("?tab=1")]
    public void Normalize_RootAndEmptyInputsBecomeSlash(string input)
    {
        Assert.That(FeedbackPageHelper.Normalize(input), Is.EqualTo("/"));
    }

    [Test]
    public void Normalize_NullBecomesSlash()
    {
        Assert.That(FeedbackPageHelper.Normalize(null), Is.EqualTo("/"));
    }

    [TestCase("/admin")]
    [TestCase("/Admin/")]
    [TestCase("/admin/comments")]
    [TestCase("/admin/some-user-id")]
    [TestCase("/adminpending")]
    [TestCase("/adminsearch")]
    [TestCase("/adminreports")]
    [TestCase("/adminactivity/some-user-id")]
    [TestCase("https://thecsharpacademy.com/adminreports?x=1")]
    public void IsAdminPath_AdminRoutes_AreTrue(string path)
    {
        Assert.That(FeedbackPageHelper.IsAdminPath(path), Is.True);
    }

    [TestCase("/")]
    [TestCase("")]
    [TestCase(null)]
    [TestCase("/dashboard")]
    [TestCase("/dashboard/admin")]
    [TestCase("/about")]
    public void IsAdminPath_OtherRoutes_AreFalse(string? path)
    {
        Assert.That(FeedbackPageHelper.IsAdminPath(path), Is.False);
    }
}
