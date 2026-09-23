using Microsoft.Extensions.Logging.Abstractions;
using TCSA.V2026.Data.Enums;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Data.Models.Responses;
using TCSA.V2026.Services;

namespace TCSA.V2026.IntegrationTests;

[TestFixture]
public class BadgeServiceTests : IntegrationTestsBase
{
    private BadgeService _service;

    [SetUp]
    public void Setup()
    {
        BaseSetup();
        _service = new BadgeService(DbContextFactory, NullLogger<BadgeService>.Instance);
    }

    [TearDown]
    public void TearDown()
    {
        BaseTearDown();
    }

    [Test]
    public async Task AwardBadge_NewBadge_PersistsBadgeWithPendingNotification()
    {
        var response = await _service.AwardBadge("user1", (int)BadgeId.PlatformBuilder);

        using var context = DbContextFactory.CreateDbContext();
        var badge = context.Badges.FirstOrDefault(b => b.UserId == "user1" && b.BadgeId == (int)BadgeId.PlatformBuilder);

        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Success));
        Assert.That(badge, Is.Not.Null);
        Assert.That(badge.IsPendingNotification, Is.True);
    }

    [Test]
    public async Task AwardBadge_AlreadyAwarded_ReturnsFailAndDoesNotDuplicate()
    {
        await _service.AwardBadge("user1", (int)BadgeId.PlatformBuilder);
        var secondResponse = await _service.AwardBadge("user1", (int)BadgeId.PlatformBuilder);

        using var context = DbContextFactory.CreateDbContext();
        var count = context.Badges.Count(b => b.UserId == "user1" && b.BadgeId == (int)BadgeId.PlatformBuilder);

        Assert.That(secondResponse.Status, Is.EqualTo(ResponseStatus.Fail));
        Assert.That(count, Is.EqualTo(1));
    }

    [Test]
    public async Task AwardPlatformBuilderBadges_NoMergedPullRequests_AwardsNothing()
    {
        await _service.AwardPlatformBuilderBadges("user1");

        using var context = DbContextFactory.CreateDbContext();
        var count = context.Badges.Count(b => b.UserId == "user1");

        Assert.That(count, Is.EqualTo(0));
    }

    [Test]
    public async Task AwardPlatformBuilderBadges_OneMergedPullRequest_AwardsPlatformBuilderOnly()
    {
        await SeedClosedCommunityIssues("user1", 1);

        await _service.AwardPlatformBuilderBadges("user1");

        using var context = DbContextFactory.CreateDbContext();
        var badgeIds = context.Badges.Where(b => b.UserId == "user1").Select(b => b.BadgeId).ToList();

        Assert.That(badgeIds, Is.EquivalentTo(new[] { (int)BadgeId.PlatformBuilder }));
    }

    [Test]
    public async Task AwardPlatformBuilderBadges_TenMergedPullRequests_AwardsUpToPlatformContributor()
    {
        await SeedClosedCommunityIssues("user1", 10);

        await _service.AwardPlatformBuilderBadges("user1");

        using var context = DbContextFactory.CreateDbContext();
        var badgeIds = context.Badges.Where(b => b.UserId == "user1").Select(b => b.BadgeId).ToList();

        Assert.That(badgeIds, Is.EquivalentTo(new[] { (int)BadgeId.PlatformBuilder, (int)BadgeId.PlatformContributor }));
    }

    [Test]
    public async Task AwardPlatformBuilderBadges_TwentyMergedPullRequests_AwardsAllTiers()
    {
        await SeedClosedCommunityIssues("user1", 20);

        await _service.AwardPlatformBuilderBadges("user1");

        using var context = DbContextFactory.CreateDbContext();
        var badgeIds = context.Badges.Where(b => b.UserId == "user1").Select(b => b.BadgeId).ToList();

        Assert.That(badgeIds, Is.EquivalentTo(new[] { (int)BadgeId.PlatformBuilder, (int)BadgeId.PlatformContributor, (int)BadgeId.PlatformArchitect }));
    }

    private async Task SeedClosedCommunityIssues(string userId, int count)
    {
        using var context = DbContextFactory.CreateDbContext();
        for (var i = 0; i < count; i++)
        {
            context.Issues.Add(new CommunityIssue
            {
                AppUserId = userId,
                Title = $"Issue {i}",
                IsClosed = true,
                GithubUrl = $"issue-url-{i}",
                IconUrl = "icon-url"
            });
        }

        await context.SaveChangesAsync();
    }

    [Test]
    public async Task AwardReviewBadges_OneReview_AwardsCodeReviewerOnly()
    {
        await _service.AwardReviewBadges("user1", 1);

        using var context = DbContextFactory.CreateDbContext();
        var badgeIds = context.Badges.Where(b => b.UserId == "user1").Select(b => b.BadgeId).ToList();

        Assert.That(badgeIds, Is.EquivalentTo(new[] { (int)BadgeId.CodeReviewer }));
    }

    [Test]
    public async Task AwardReviewBadges_TwentyFiveReviews_AwardsUpToTrustedReviewer()
    {
        await _service.AwardReviewBadges("user1", 25);

        using var context = DbContextFactory.CreateDbContext();
        var badgeIds = context.Badges.Where(b => b.UserId == "user1").Select(b => b.BadgeId).ToList();

        Assert.That(badgeIds, Is.EquivalentTo(new[] { (int)BadgeId.CodeReviewer, (int)BadgeId.TrustedReviewer }));
    }

    [Test]
    public async Task AwardReviewBadges_OneHundredReviews_AwardsAllReviewTiers()
    {
        await _service.AwardReviewBadges("user1", 100);

        using var context = DbContextFactory.CreateDbContext();
        var badgeIds = context.Badges.Where(b => b.UserId == "user1").Select(b => b.BadgeId).ToList();

        Assert.That(badgeIds, Is.EquivalentTo(new[]
        {
            (int)BadgeId.CodeReviewer,
            (int)BadgeId.TrustedReviewer,
            (int)BadgeId.MasterReviewer
        }));
    }

    [Test]
    public async Task GetRecentAwardedBadges_OnlyReturnsBadgesWithinWindow()
    {
        using (var seedContext = DbContextFactory.CreateDbContext())
        {
            seedContext.Badges.AddRange(
                new Badge { UserId = "user1", BadgeId = (int)BadgeId.PlatformBuilder, DateAwarded = DateTimeOffset.UtcNow.AddDays(-10) },
                new Badge { UserId = "user1", BadgeId = (int)BadgeId.CodeReviewer, DateAwarded = DateTimeOffset.UtcNow.AddDays(-1) }
            );
            await seedContext.SaveChangesAsync();
        }

        var recentBadges = await _service.GetRecentAwardedBadges("user1", DateTimeOffset.UtcNow.AddDays(-7));

        Assert.That(recentBadges.Select(b => b.BadgeId), Is.EquivalentTo(new[] { (int)BadgeId.CodeReviewer }));
    }

    [Test]
    public async Task AwardMissingBadges_FlagsUserAndIsIdempotentOnSecondCall()
    {
        using (var seedContext = DbContextFactory.CreateDbContext())
        {
            var user = seedContext.AspNetUsers.First(u => u.Id == "purpleuser");
            user.ReviewedProjects = 25;

            seedContext.Issues.Add(new CommunityIssue
            {
                AppUserId = "purpleuser",
                Title = "Test issue",
                IsClosed = true,
                GithubUrl = "issue-url",
                IconUrl = "icon-url"
            });

            await seedContext.SaveChangesAsync();
        }

        await _service.AwardMissingBadges("purpleuser");
        await _service.AwardMissingBadges("purpleuser");

        using var assertContext = DbContextFactory.CreateDbContext();
        var user1 = assertContext.AspNetUsers.First(u => u.Id == "purpleuser");
        var badgeCountsById = assertContext.Badges
            .Where(b => b.UserId == "purpleuser")
            .ToList()
            .GroupBy(b => b.BadgeId)
            .ToDictionary(g => g.Key, g => g.Count());

        Assert.That(user1.HasBackfilledBadges, Is.True);
        Assert.That(badgeCountsById.Values, Is.All.EqualTo(1));
        Assert.That(badgeCountsById.Keys, Is.SupersetOf(new[]
        {
            (int)BadgeId.CodeReviewer,
            (int)BadgeId.TrustedReviewer,
            (int)BadgeId.PlatformBuilder
        }));
    }
}
