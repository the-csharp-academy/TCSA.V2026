using TCSA.V2026.Data.Enums;
using TCSA.V2026.Helpers;
using TCSA.V2026.Helpers.Constants;

namespace TCSA.V2026.UnitTests.Helpers;

[TestFixture]
public class UrlHelperTests
{
    [TestCase($"{UrlConstants.TCSARepositoryIssuesUrl}/1", CommunityProject.TCSA, true)]
    [TestCase($"{UrlConstants.TCSARepositoryIssuesUrl}/999", CommunityProject.TCSA, true)]
    [TestCase($"{UrlConstants.KnowTheCityRepositoryIssuesUrl}/1", CommunityProject.KnowTheCity, true)]
    [TestCase($"{UrlConstants.KnowTheCityRepositoryIssuesUrl}/999", CommunityProject.KnowTheCity, true)]
    [TestCase("https://github.com/random-org/random-repo/issues/1", CommunityProject.TCSA, false)]
    [TestCase($"{UrlConstants.TCSARepositoryIssuesUrl}/1", CommunityProject.KnowTheCity, false)]
    [TestCase($"{UrlConstants.KnowTheCityRepositoryIssuesUrl}/1", CommunityProject.TCSA, false)]
    [TestCase($"{UrlConstants.TCSARepositoryPullUrl}/1", CommunityProject.TCSA, false)]
    [TestCase($"{UrlConstants.TCSARepositoryIssuesUrl}/", CommunityProject.TCSA, false)]
    [TestCase($"{UrlConstants.TCSARepositoryIssuesUrl}/abc", CommunityProject.TCSA, false)]
    [TestCase($"{UrlConstants.TCSARepositoryIssuesUrl}", CommunityProject.TCSA, false)]
    [TestCase("not-a-url", CommunityProject.TCSA, false)]
    [TestCase("", CommunityProject.TCSA, false)]
    public void IsValidCommunityProjectIssueUrl_ShouldReturnExpected(string url, CommunityProject project, bool expected)
    {
        var result = UrlHelper.IsValidCommunityProjectIssueUrl(url, project);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void IsValidCommunityProjectIssueUrl_ShouldThrow_WhenProjectIsInvalid()
    {
        Assert.Throws<ArgumentException>(() =>
            UrlHelper.IsValidCommunityProjectIssueUrl("https://github.com/any/repo/issues/1", (CommunityProject)9999));
    }

    [TestCase($"{UrlConstants.TCSARepositoryPullUrl}/1", CommunityProject.TCSA, true)]
    [TestCase($"{UrlConstants.TCSARepositoryPullUrl}/999", CommunityProject.TCSA, true)]
    [TestCase($"{UrlConstants.KnowTheCityRepositoryPullUrl}/1", CommunityProject.KnowTheCity, true)]
    [TestCase($"{UrlConstants.KnowTheCityRepositoryPullUrl}/999", CommunityProject.KnowTheCity, true)]
    [TestCase("https://github.com/random-org/random-repo/pull/1", CommunityProject.TCSA, false)]
    [TestCase($"{UrlConstants.TCSARepositoryPullUrl}/1", CommunityProject.KnowTheCity, false)]
    [TestCase($"{UrlConstants.KnowTheCityRepositoryPullUrl}/1", CommunityProject.TCSA, false)]
    [TestCase($"{UrlConstants.TCSARepositoryIssuesUrl}/1", CommunityProject.TCSA, false)]
    [TestCase($"{UrlConstants.TCSARepositoryPullUrl}/", CommunityProject.TCSA, false)]
    [TestCase($"{UrlConstants.TCSARepositoryPullUrl}/abc", CommunityProject.TCSA, false)]
    [TestCase($"{UrlConstants.TCSARepositoryPullUrl}", CommunityProject.TCSA, false)]
    [TestCase("not-a-url", CommunityProject.TCSA, false)]
    [TestCase("", CommunityProject.TCSA, false)]
    public void IsValidCommunityProjectPrUrl_ShouldReturnExpected(string url, CommunityProject project, bool expected)
    {
        var result = UrlHelper.IsValidCommunityProjectPrUrl(url, project);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void IsValidCommunityProjectPrUrl_ShouldThrow_WhenProjectIsInvalid()
    {
        Assert.Throws<ArgumentException>(() =>
            UrlHelper.IsValidCommunityProjectPrUrl("https://github.com/any/repo/pull/1", (CommunityProject)9999));
    }
}
