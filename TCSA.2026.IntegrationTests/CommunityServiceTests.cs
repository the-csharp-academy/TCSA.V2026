using TCSA.V2026.Data.Enums;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Data.Models.Responses;
using TCSA.V2026.Helpers.Constants;
using TCSA.V2026.Services;

namespace TCSA.V2026.IntegrationTests;

[TestFixture]
public class CommunityServiceTests : IntegrationTestsBase
{
    private CommunityService _service;

    [SetUp]
    public void Setup()
    {
        BaseSetup();
        _service = new CommunityService(DbContextFactory);
    }

    [TearDown]
    public void TearDown()
    {
        BaseTearDown();
    }

    [Test]
    public async Task IssuesShouldHaveNoDupes()
    {
        await _service.CreateIssue(IssueType.Feature, $"{UrlConstants.TCSARepositoryIssuesUrl}/1", "Test Issue 1", CommunityProject.TCSA);
        await _service.CreateIssue(IssueType.Feature, $"{UrlConstants.TCSARepositoryIssuesUrl}/1", "Test Issue 1", CommunityProject.TCSA);

        using var verifyContext = DbContextFactory.CreateDbContext();

        var list = verifyContext.Issues
        .Where(p => p.Title.Equals("Test Issue 1"))
        .ToList();

        Assert.That(list.Count, Is.EqualTo(1));
    }

    [TestCase("https://github.com/random-org/random-repo/issues/1")]
    [TestCase("https://github.com/the-csharp-academy/TCSA.V2026/pull/1")]
    [TestCase("https://github.com/the-csharp-academy/TCSA.V2026/issues/")]
    [TestCase("https://github.com/the-csharp-academy/TCSA.V2026/issues/abc")]
    [TestCase("not-a-url")]
    [TestCase("")]
    public async Task IssueWithInvalidUrlShouldNotBeSaved(string invalidUrl)
    {
        var result = await _service.CreateIssue(IssueType.Feature, invalidUrl, "Invalid Issue", CommunityProject.TCSA);

        using var verifyContext = DbContextFactory.CreateDbContext();
        var count = verifyContext.Issues.Count();

        Assert.That(result.Status, Is.EqualTo(ResponseStatus.Fail));
        Assert.That(count, Is.EqualTo(0));
    }

    [TestCase("https://github.com/the-csharp-academy/TCSA.KnowTheCity/issues/1")]
    [TestCase("https://github.com/the-csharp-academy/TCSA.V2026/issues/1")]
    public async Task IssueWithValidUrlShouldBeSaved(string validUrl)
    {
        CommunityProject project = validUrl.Contains("KnowTheCity") ? CommunityProject.KnowTheCity : CommunityProject.TCSA;

        var result = await _service.CreateIssue(IssueType.Feature, validUrl, "Valid Issue", project);

        using var verifyContext = DbContextFactory.CreateDbContext();
        var count = verifyContext.Issues.Count();

        Assert.That(result.Status, Is.EqualTo(ResponseStatus.Success));
        Assert.That(count, Is.EqualTo(1));
    }
}
