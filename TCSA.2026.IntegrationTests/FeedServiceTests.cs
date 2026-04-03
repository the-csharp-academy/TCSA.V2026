using Microsoft.Extensions.Logging;
using Moq;
using TCSA.V2026.Data.Enums;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Services;

namespace TCSA.V2026.IntegrationTests;

public class FeedServiceTests : IntegrationTestsBase
{
    private FeedService _feedService;

    [SetUp]
    public void SetUp()
    {
        BaseSetup();
        var loggerMock = new Mock<ILogger<UserService>>();
        var userService = new UserService(DbContextFactory, loggerMock.Object);
        _feedService = new FeedService(DbContextFactory, userService);
    }

    [TearDown]
    public void TearDown()
    {
        BaseTearDown();
    }

    [Test]
    public async Task GetPaginatedFeedItems_ShouldExcludeCommunityIssues()
    {
        // Arrange
        using var context = DbContextFactory.CreateDbContext();

        // Add community issues
        var communityIssue1 = new CommunityIssue
        {
            Id = 1,
            ProjectId = 1001,
            CommunityProjectId = 207,
            Title = "Fix Bug in Login",
            Type = IssueType.Bugfix,
            ExperiencePoints = 20,
            IconUrl = "icons8-insect-64.png",
            IsClosed = true,
            GithubUrl = "https://github.com/test/issue/1"
        };

        var communityIssue2 = new CommunityIssue
        {
            Id = 2,
            ProjectId = 1002,
            CommunityProjectId = 207,
            Title = "Add French Translation",
            Type = IssueType.Translation,
            ExperiencePoints = 20,
            IconUrl = "icons8-foreign-language-66.png",
            IsClosed = true,
            GithubUrl = "https://github.com/test/issue/2"
        };

        context.Issues.AddRange(communityIssue1, communityIssue2);

        // Add regular project activity (should appear in feed)
        var regularActivity = new AppUserActivity
        {
            Id = 1,
            AppUserId = "user1",
            ProjectId = (int)ArticleName.MathGame,
            ActivityType = ActivityType.ProjectCompleted,
            DateSubmitted = DateTime.UtcNow.AddDays(-1)
        };

        // Add community issue activity (should be excluded from feed)
        var issueActivity1 = new AppUserActivity
        {
            Id = 2,
            AppUserId = "user1",
            ProjectId = 1001,
            ActivityType = ActivityType.ProjectCompleted,
            DateSubmitted = DateTime.UtcNow.AddDays(-2)
        };

        var issueActivity2 = new AppUserActivity
        {
            Id = 3,
            AppUserId = "user2",
            ProjectId = 1002,
            ActivityType = ActivityType.ProjectCompleted,
            DateSubmitted = DateTime.UtcNow.AddDays(-3)
        };

        // Add belt activity (should appear in feed)
        var beltActivity = new AppUserActivity
        {
            Id = 4,
            AppUserId = "user2",
            ProjectId = 0,
            ActivityType = ActivityType.NewBelt,
            Level = Level.Green,
            DateSubmitted = DateTime.UtcNow.AddDays(-4)
        };

        context.UserActivity.AddRange(regularActivity, issueActivity1, issueActivity2, beltActivity);

        await context.SaveChangesAsync();

        // Act
        var result = await _feedService.GetPaginatedFeedItems(1);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Items, Has.Count.EqualTo(4));

        var communityIssueActivities = result.Items.Where(f =>
            f.ProjectId.HasValue && (f.ProjectId.Value == 1001 || f.ProjectId.Value == 1002)).ToList();
        Assert.That(communityIssueActivities, Is.Empty);
    }

    [Test]
    public async Task GetPaginatedFeedItems_ShouldIncludeRegularProjects()
    {
        // Arrange
        using var context = DbContextFactory.CreateDbContext();

        var activity = new AppUserActivity
        {
            Id = 1,
            AppUserId = "user1",
            ProjectId = (int)ArticleName.Calculator,
            ActivityType = ActivityType.ProjectCompleted,
            DateSubmitted = DateTime.UtcNow.AddDays(-1)
        };

        context.UserActivity.Add(activity);
        await context.SaveChangesAsync();

        // Act
        var result = await _feedService.GetPaginatedFeedItems(1);

        // Assert
        var projectActivity = result.Items.FirstOrDefault(f => f.ActivityType == ActivityType.ProjectCompleted);
        Assert.That(projectActivity, Is.Not.Null);
        Assert.That(projectActivity.ProjectName, Is.Not.Null.And.Not.Empty);
        Assert.That(projectActivity.ProjectIconUrl, Is.Not.Null.And.Not.Empty);
        Assert.That(projectActivity.ProjectName, Is.EqualTo("Calculator"));
        Assert.That(projectActivity.Level, Is.Null);
        Assert.That(projectActivity.User.Id, Is.EqualTo("user1"));
    }

    [Test]
    public async Task GetPaginatedFeedItems_ShouldIncludeUsers()
    {
        // Arrange
        using var context = DbContextFactory.CreateDbContext();
        var newUser = new ApplicationUser
        {
            Id = "newuser1",
            UserName = "newuser1",
            Country = "Testland",
            FirstName = "Test",
            LastName = "User",
            CreatedDate = DateTime.UtcNow.AddDays(-1)
        };

        context.Users.Add(newUser);
        await context.SaveChangesAsync();

        // Act
        var result = await _feedService.GetPaginatedFeedItems(1);

        // Assert
        var newUserFeedItem = result.Items.FirstOrDefault(f => f.ActivityType == ActivityType.NewUser && f.User.Id == "newuser1");
        Assert.That(newUserFeedItem, Is.Not.Null);
        Assert.That(newUserFeedItem.User.UserName, Is.EqualTo("newuser1"));
        Assert.That(newUserFeedItem.ProjectName, Is.Null.Or.Empty);
        Assert.That(newUserFeedItem.ProjectIconUrl, Is.Null.Or.Empty);
        Assert.That(newUserFeedItem.Level, Is.Null);
    }

    [Test]
    public async Task GetPaginatedFeedItems_ShouldIncludeBeltActivities()
    {
        // Arrange
        using var context = DbContextFactory.CreateDbContext();

        var beltActivity = new AppUserActivity
        {
            Id = 1,
            AppUserId = "user1",
            ProjectId = 0,
            ActivityType = ActivityType.NewBelt,
            Level = Level.Blue,
            DateSubmitted = DateTime.UtcNow.AddDays(-1)
        };

        context.UserActivity.Add(beltActivity);
        await context.SaveChangesAsync();

        // Act
        var result = await _feedService.GetPaginatedFeedItems(1);

        // Assert
        var beltFeedItem = result.Items.FirstOrDefault(f => f.ActivityType == ActivityType.NewBelt && f.User.Id == "user1");
        Assert.That(beltFeedItem, Is.Not.Null);
        Assert.That(beltFeedItem.Level, Is.EqualTo(Level.Blue));
        Assert.That(beltFeedItem.ProjectName, Is.Null.Or.Empty);
        Assert.That(beltFeedItem.ProjectIconUrl, Is.Null.Or.Empty);
    }

    [Test]
    public async Task GetRecentFeedItems_ShouldIncludeUsers()
    {
        // Arrange
        using var context = DbContextFactory.CreateDbContext();
        var newUser = new ApplicationUser
        {
            Id = "recentuser1",
            UserName = "recentuser1",
            Country = "Testland",
            FirstName = "Test",
            LastName = "User",
            CreatedDate = DateTime.UtcNow.AddDays(-1)
        };

        context.Users.Add(newUser);
        await context.SaveChangesAsync();

        // Act
        var result = await _feedService.GetRecentFeedItems();

        // Assert
        var newUserFeedItem = result.FirstOrDefault(f => f.ActivityType == ActivityType.NewUser && f.User.Id == "recentuser1");
        Assert.That(newUserFeedItem, Is.Not.Null);
        Assert.That(newUserFeedItem.User.UserName, Is.EqualTo("recentuser1"));
        Assert.That(newUserFeedItem.ProjectName, Is.Null.Or.Empty);
        Assert.That(newUserFeedItem.ProjectIconUrl, Is.Null.Or.Empty);
        Assert.That(newUserFeedItem.Level, Is.Null);
    }

    [Test]
    public async Task GetRecentFeedItems_ShouldIncludeNewBeltActivities()
    {
        // Arrange
        using var context = DbContextFactory.CreateDbContext();

        var beltActivity = new AppUserActivity
        {
            Id = 1,
            AppUserId = "user1",
            ProjectId = 0,
            ActivityType = ActivityType.NewBelt,
            Level = Level.Red,
            DateSubmitted = DateTime.UtcNow.AddDays(-1)
        };
        context.UserActivity.Add(beltActivity);
        await context.SaveChangesAsync();

        // Act
        var result = await _feedService.GetRecentFeedItems();

        // Assert
        var beltFeedItem = result.FirstOrDefault(f => f.ActivityType == ActivityType.NewBelt && f.User.Id == "user1");
        Assert.That(beltFeedItem, Is.Not.Null);
        Assert.That(beltFeedItem.Level, Is.EqualTo(Level.Red));
        Assert.That(beltFeedItem.ProjectName, Is.Null.Or.Empty);
        Assert.That(beltFeedItem.ProjectIconUrl, Is.Null.Or.Empty);
    }

    [Test]
    public async Task GetRecentFeedItems_ShouldIncludeRegularProjects()
    {
        // Arrange
        using var context = DbContextFactory.CreateDbContext();

        var activity = new AppUserActivity
        {
            Id = 1,
            AppUserId = "user1",
            ProjectId = (int)ArticleName.Calculator,
            ActivityType = ActivityType.ProjectCompleted,
            DateSubmitted = DateTime.UtcNow.AddDays(-1)
        };

        context.UserActivity.Add(activity);
        await context.SaveChangesAsync();

        // Act
        var result = await _feedService.GetRecentFeedItems();

        // Assert
        var projectActivity = result.FirstOrDefault(f => f.ActivityType == ActivityType.ProjectCompleted);
        Assert.That(projectActivity, Is.Not.Null);
        Assert.That(projectActivity.ProjectName, Is.Not.Null.And.Not.Empty);
        Assert.That(projectActivity.ProjectIconUrl, Is.Not.Null.And.Not.Empty);
        Assert.That(projectActivity.ProjectName, Is.EqualTo("Calculator"));
        Assert.That(projectActivity.Level, Is.Null);
        Assert.That(projectActivity.User.Id, Is.EqualTo("user1"));
    }

    [Test]
    public async Task GetRecentFeedItems_ShouldExcludeCommunityIssues()
    {
        // Arrange
        using var context = DbContextFactory.CreateDbContext();

        // Add community issues
        var communityIssue1 = new CommunityIssue
        {
            Id = 1,
            ProjectId = 1001,
            CommunityProjectId = 207,
            Title = "Fix Bug in Login",
            Type = IssueType.Bugfix,
            ExperiencePoints = 20,
            IconUrl = "icons8-insect-64.png",
            IsClosed = true,
            GithubUrl = "https://github.com/test/issue/1"
        };

        var communityIssue2 = new CommunityIssue
        {
            Id = 2,
            ProjectId = 1002,
            CommunityProjectId = 207,
            Title = "Add French Translation",
            Type = IssueType.Translation,
            ExperiencePoints = 20,
            IconUrl = "icons8-foreign-language-66.png",
            IsClosed = true,
            GithubUrl = "https://github.com/test/issue/2"
        };

        context.Issues.AddRange(communityIssue1, communityIssue2);

        // Add regular project activity (should appear in feed)
        var regularActivity = new AppUserActivity
        {
            Id = 1,
            AppUserId = "user1",
            ProjectId = (int)ArticleName.MathGame,
            ActivityType = ActivityType.ProjectCompleted,
            DateSubmitted = DateTime.UtcNow.AddDays(-1)
        };

        // Add community issue activity (should be excluded from feed)
        var issueActivity1 = new AppUserActivity
        {
            Id = 2,
            AppUserId = "user1",
            ProjectId = 1001,
            ActivityType = ActivityType.ProjectCompleted,
            DateSubmitted = DateTime.UtcNow.AddDays(-2)
        };

        var issueActivity2 = new AppUserActivity
        {
            Id = 3,
            AppUserId = "user2",
            ProjectId = 1002,
            ActivityType = ActivityType.ProjectCompleted,
            DateSubmitted = DateTime.UtcNow.AddDays(-3)
        };

        // Add belt activity (should appear in feed)
        var beltActivity = new AppUserActivity
        {
            Id = 4,
            AppUserId = "user2",
            ProjectId = 0,
            ActivityType = ActivityType.NewBelt,
            Level = Level.Green,
            DateSubmitted = DateTime.UtcNow.AddDays(-4)
        };

        context.UserActivity.AddRange(regularActivity, issueActivity1, issueActivity2, beltActivity);

        await context.SaveChangesAsync();

        // Act
        var result = await _feedService.GetRecentFeedItems();

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Has.Count.EqualTo(4));

        var communityIssueActivities = result.Where(f =>
            f.ProjectId.HasValue && (f.ProjectId.Value == 1001 || f.ProjectId.Value == 1002)).ToList();
        Assert.That(communityIssueActivities, Is.Empty);
    }
}
