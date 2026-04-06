using TCSA.V2026.Data.Models;
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
        await _service.CreateIssue(IssueType.Feature, "issueUrl.com", "Test Issue 1", "user1");
        await _service.CreateIssue(IssueType.Feature, "issueUrl.com", "Test Issue 1", "user1");

        using var verifyContext = DbContextFactory.CreateDbContext();

        var list = verifyContext.Issues
        .Where(p => p.Title.Equals("Test Issue 1"))
        .ToList();

        Assert.That(list.Count, Is.EqualTo(1));
    }
}
