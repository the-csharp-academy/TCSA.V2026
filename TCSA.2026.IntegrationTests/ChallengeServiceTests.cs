using Microsoft.EntityFrameworkCore;
using TCSA.V2026.Data.Enums;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Services;

namespace TCSA.V2026.IntegrationTests;

public class ChallengeServiceTests : IntegrationTestsBase
{
    private ChallengeService _service;

    [SetUp]
    public void Setup()
    {
        BaseSetup();
        _service = new ChallengeService(DbContextFactory);
    }

    [TearDown]
    public void TearDown()
    {
        BaseTearDown();
    }

    [Test]
    public async Task UpdateStreakInfo_ShouldInitializeStreakForNewUser()
    {
        // Arrange
        string userId = "user1";
        using (var seedContext = DbContextFactory.CreateDbContext())
        {
            var existingStreak = await seedContext.DailyStreaks
                .FirstOrDefaultAsync(s => s.AppUserId == userId);
            if (existingStreak != null)
            {
                seedContext.DailyStreaks.Remove(existingStreak);
                await seedContext.SaveChangesAsync();
            }
        }

        // Act
        await _service.UpdateStreakInfo(userId);

        // Assert
        using var assertContext = DbContextFactory.CreateDbContext();
        var streakInfo = await assertContext.DailyStreaks
            .FirstOrDefaultAsync(s => s.AppUserId == userId);
        Assert.That(streakInfo, Is.Not.Null);
        Assert.That(streakInfo.CurrentStreak, Is.EqualTo(1));
        Assert.That(streakInfo.LongestStreak, Is.EqualTo(1));
        Assert.That(streakInfo.LastCompletedDate.Date, Is.EqualTo(DateTime.UtcNow.Date));
    }

    [Test]
    public async Task UpdateStreakInfo_ShouldIncrementCurrentStreak_WhenLastCompletedDateIsYesterday()
    {
        // Arrange
        string userId = "user1";
        using (var seedContext = DbContextFactory.CreateDbContext())
        {
            var existingStreak = await seedContext.DailyStreaks
                .FirstOrDefaultAsync(s => s.AppUserId == userId);
            if (existingStreak != null)
            {
                existingStreak.CurrentStreak = 3;
                existingStreak.LongestStreak = 5;
                existingStreak.LastCompletedDate = DateTime.UtcNow.Date.AddDays(-1);
                seedContext.DailyStreaks.Update(existingStreak);
                await seedContext.SaveChangesAsync();
            }
        }

        // Act
        await _service.UpdateStreakInfo(userId);

        // Assert
        using var assertContext = DbContextFactory.CreateDbContext();
        var streakInfo = await assertContext.DailyStreaks
            .FirstOrDefaultAsync(s => s.AppUserId == userId);
        Assert.That(streakInfo, Is.Not.Null);
        Assert.That(streakInfo.CurrentStreak, Is.EqualTo(4));
        Assert.That(streakInfo.LongestStreak, Is.EqualTo(5));
        Assert.That(streakInfo.LastCompletedDate.Date, Is.EqualTo(DateTime.UtcNow.Date));
    }

    [Test]
    public async Task UpdateStreakInfo_ShouldResetCurrentStreak_WhenLastCompletedDateIsNotYesterday()
    {
        // Arrange
        string userId = "user1";
        using (var seedContext = DbContextFactory.CreateDbContext())
        {
            var existingStreak = await seedContext.DailyStreaks
                .FirstOrDefaultAsync(s => s.AppUserId == userId);
            if (existingStreak != null)
            {
                existingStreak.CurrentStreak = 3;
                existingStreak.LongestStreak = 5;
                existingStreak.LastCompletedDate = DateTime.UtcNow.Date.AddDays(-3);
                seedContext.DailyStreaks.Update(existingStreak);
                await seedContext.SaveChangesAsync();
            }
        }

        // Act
        await _service.UpdateStreakInfo(userId);

        // Assert
        using var assertContext = DbContextFactory.CreateDbContext();
        var streakInfo = await assertContext.DailyStreaks
            .FirstOrDefaultAsync(s => s.AppUserId == userId);
        Assert.That(streakInfo, Is.Not.Null);
        Assert.That(streakInfo.CurrentStreak, Is.EqualTo(1));
        Assert.That(streakInfo.LongestStreak, Is.EqualTo(5));
        Assert.That(streakInfo.LastCompletedDate.Date, Is.EqualTo(DateTime.UtcNow.Date));
    }

    [Test]
    public async Task UpdateStreakInfo_ShouldUpdateLongestStreak_WhenCurrentStreakExceedsPreviousLongest()
    {
        // Arrange
        string userId = "user1";
        using (var seedContext = DbContextFactory.CreateDbContext())
        {
            var existingStreak = await seedContext.DailyStreaks
                .FirstOrDefaultAsync(s => s.AppUserId == userId);
            if (existingStreak != null)
            {
                existingStreak.CurrentStreak = 5;
                existingStreak.LongestStreak = 5;
                existingStreak.LastCompletedDate = DateTime.UtcNow.Date.AddDays(-1);
                seedContext.DailyStreaks.Update(existingStreak);
                await seedContext.SaveChangesAsync();
            }
        }

        // Act
        await _service.UpdateStreakInfo(userId);

        // Assert
        using var assertContext = DbContextFactory.CreateDbContext();
        var streakInfo = await assertContext.DailyStreaks
            .FirstOrDefaultAsync(s => s.AppUserId == userId);
        Assert.That(streakInfo, Is.Not.Null);
        Assert.That(streakInfo.CurrentStreak, Is.EqualTo(6));
        Assert.That(streakInfo.LongestStreak, Is.EqualTo(6));
        Assert.That(streakInfo.LastCompletedDate.Date, Is.EqualTo(DateTime.UtcNow.Date));
    }

    [Test]
    public async Task GetChallengeStatistics_ShouldReturnNull_WhenUserDoesNotExist()
    {
        // Act
        var result = await _service.GetChallengeStatistics("nonexistent-user");

        // Assert
        Assert.That(result, Is.Null);
    }

    [Test]
    public async Task GetChallengeStatistics_ShouldReturnZeroCompletedChallenges_WhenUserHasNoCompletedChallenges()
    {
        // Act
        var result = await _service.GetChallengeStatistics("user1");

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.CompletedChallenges, Is.Zero);
    }

    [Test]
    public async Task GetChallengeStatistics_ShouldReturnCorrectCompletedChallenges_WhenUserHasCompletedChallenges()
    {
        // Arrange
        string userId = "user1";
        using (var seedContext = DbContextFactory.CreateDbContext())
        {
            seedContext.Challenges.AddRange(
                BuildChallenge(1),
                BuildChallenge(2)
            );
            seedContext.UserChallenges.AddRange(
                new UserChallenge { ChallengeId = 1, UserId = userId, CompletedAt = DateTime.UtcNow.AddDays(-2) },
                new UserChallenge { ChallengeId = 2, UserId = userId, CompletedAt = DateTime.UtcNow.AddDays(-1) }
            );
            await seedContext.SaveChangesAsync();
        }

        // Act
        var result = await _service.GetChallengeStatistics(userId);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.CompletedChallenges, Is.EqualTo(2));
    }

    [Test]
    public async Task GetChallengeStatistics_ShouldReturnCorrectStreakInfo_WhenStreakIsActive()
    {
        // Arrange
        string userId = "user1";
        using (var seedContext = DbContextFactory.CreateDbContext())
        {
            var streak = await seedContext.DailyStreaks.FirstOrDefaultAsync(s => s.AppUserId == userId);
            if (streak != null)
            {
                streak.CurrentStreak = 5;
                streak.LongestStreak = 10;
                streak.LastCompletedDate = DateTime.UtcNow.Date.AddDays(-1);
                seedContext.DailyStreaks.Update(streak);
                await seedContext.SaveChangesAsync();
            }
        }

        // Act
        var result = await _service.GetChallengeStatistics(userId);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.DailyStreakDetails.CurrentStreak, Is.EqualTo(5));
        Assert.That(result.DailyStreakDetails.LongestStreak, Is.EqualTo(10));
        Assert.That(result.DailyStreakDetails.LastCompletedDate.Date, Is.EqualTo(DateTime.UtcNow.Date.AddDays(-1)));
    }

    [Test]
    public async Task GetChallengeStatistics_ShouldResetCurrentStreak_WhenStreakHasExpired()
    {
        // Arrange
        string userId = "user1";
        using (var seedContext = DbContextFactory.CreateDbContext())
        {
            var streak = await seedContext.DailyStreaks.FirstOrDefaultAsync(s => s.AppUserId == userId);
            if (streak != null)
            {
                streak.CurrentStreak = 3;
                streak.LongestStreak = 7;
                streak.LastCompletedDate = DateTime.UtcNow.Date.AddDays(-3);
                seedContext.DailyStreaks.Update(streak);
                await seedContext.SaveChangesAsync();
            }
        }

        // Act
        var result = await _service.GetChallengeStatistics(userId);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.DailyStreakDetails.CurrentStreak, Is.EqualTo(0));
        Assert.That(result.DailyStreakDetails.LongestStreak, Is.EqualTo(7));

        using var assertContext = DbContextFactory.CreateDbContext();
        var updatedStreak = await assertContext.DailyStreaks.FirstOrDefaultAsync(s => s.AppUserId == userId);
        Assert.That(updatedStreak, Is.Not.Null);
        Assert.That(updatedStreak.CurrentStreak, Is.Zero);
    }

    [Test]
    public async Task GetChallengeStatistics_ShouldNotResetStreak_WhenLastCompletedDateIsToday()
    {
        // Arrange
        string userId = "user1";
        using (var seedContext = DbContextFactory.CreateDbContext())
        {
            var streak = await seedContext.DailyStreaks.FirstOrDefaultAsync(s => s.AppUserId == userId);
            if (streak != null)
            {
                streak.CurrentStreak = 4;
                streak.LongestStreak = 8;
                streak.LastCompletedDate = DateTime.UtcNow.Date;
                seedContext.DailyStreaks.Update(streak);
                await seedContext.SaveChangesAsync();
            }
        }

        // Act
        var result = await _service.GetChallengeStatistics(userId);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.DailyStreakDetails.CurrentStreak, Is.EqualTo(4));
    }

    [Test]
    public async Task GetChallengeStatistics_ShouldNotResetStreak_WhenLastCompletedDateIsYesterday()
    {
        // Arrange
        string userId = "user1";
        using (var seedContext = DbContextFactory.CreateDbContext())
        {
            var streak = await seedContext.DailyStreaks.FirstOrDefaultAsync(s => s.AppUserId == userId);
            if (streak != null)
            {
                streak.CurrentStreak = 6;
                streak.LongestStreak = 6;
                streak.LastCompletedDate = DateTime.UtcNow.Date.AddDays(-1);
                seedContext.DailyStreaks.Update(streak);
                await seedContext.SaveChangesAsync();
            }
        }

        // Act
        var result = await _service.GetChallengeStatistics(userId);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.DailyStreakDetails.CurrentStreak, Is.EqualTo(6));
    }

    private static Challenge BuildChallenge(
        int id,
        Level level = Level.White,
        ChallengeCategory category = ChallengeCategory.CSharp,
        ChallengePlatform platform = ChallengePlatform.CodeWars,
        int daysOffset = -1) =>
        new Challenge
        {
            Id = id,
            ExternalId = $"ext{id}",
            Name = $"Challenge {id}",
            Description = "desc",
            Keywords = "kw",
            ReleaseDate = DateTime.UtcNow.AddDays(daysOffset),
            ExperiencePoints = 10 * id,
            Platform = platform,
            Category = category,
            Level = level
        };

    [Test]
    public async Task GetPaginatedChallenges_ShouldReturnEmpty_WhenNoChallengesExist()
    {
        // Act
        var result = await _service.GetPaginatedChallenges(1, "user1", Level.White, false, [], []);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Items, Is.Empty);
        Assert.That(result.TotalPages, Is.Zero);
    }

    [Test]
    public async Task GetPaginatedChallenges_ShouldOnlyReturnChallengesUpToOneLevelAboveUser()
    {
        using (var seedContext = DbContextFactory.CreateDbContext())
        {
            seedContext.Challenges.Add(BuildChallenge(1, level: Level.White));
            seedContext.Challenges.Add(BuildChallenge(2, level: Level.Green));
            seedContext.Challenges.Add(BuildChallenge(3, level: Level.OliveGreen));
            await seedContext.SaveChangesAsync();
        }

        // Act
        var result = await _service.GetPaginatedChallenges(1, "user1", Level.White, false, [], []);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Items.Count, Is.EqualTo(2));
        Assert.That(result.Items.Select(c => c.Id), Is.EquivalentTo([1, 2]));
    }

    [Test]
    public async Task GetPaginatedChallenges_WithShowCompletedFalse_ShouldExcludeCompletedChallenges()
    {
        // Arrange
        string userId = "user1";
        using (var seedContext = DbContextFactory.CreateDbContext())
        {
            seedContext.Challenges.Add(BuildChallenge(1));
            seedContext.Challenges.Add(BuildChallenge(2));
            seedContext.UserChallenges.Add(new UserChallenge { ChallengeId = 1, UserId = userId, CompletedAt = DateTime.UtcNow.AddDays(-1) });
            await seedContext.SaveChangesAsync();
        }

        // Act
        var result = await _service.GetPaginatedChallenges(1, userId, Level.White, showCompleted: false, [], []);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Items.Count, Is.EqualTo(1));
        Assert.That(result.Items[0].Id, Is.EqualTo(2));
    }

    [Test]
    public async Task GetPaginatedChallenges_WithShowCompletedTrue_ShouldIncludeCompletedChallenges()
    {
        // Arrange
        string userId = "user1";
        using (var seedContext = DbContextFactory.CreateDbContext())
        {
            seedContext.Challenges.Add(BuildChallenge(1));
            seedContext.Challenges.Add(BuildChallenge(2));
            seedContext.UserChallenges.Add(new UserChallenge { ChallengeId = 1, UserId = userId, CompletedAt = DateTime.UtcNow.AddDays(-1) });
            await seedContext.SaveChangesAsync();
        }

        // Act
        var result = await _service.GetPaginatedChallenges(1, userId, Level.White, showCompleted: true, [], []);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Items.Count, Is.EqualTo(2));
    }

    [Test]
    public async Task GetPaginatedChallenges_WithLevelFilter_ShouldReturnOnlyMatchingLevels()
    {
        // Arrange
        using (var seedContext = DbContextFactory.CreateDbContext())
        {
            seedContext.Challenges.Add(BuildChallenge(1, level: Level.White));
            seedContext.Challenges.Add(BuildChallenge(2, level: Level.Green));
            seedContext.Challenges.Add(BuildChallenge(3, level: Level.OliveGreen));
            await seedContext.SaveChangesAsync();
        }

        // Act
        var result = await _service.GetPaginatedChallenges(1, "user1", Level.Green, false, [Level.White], []);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Items.Count, Is.EqualTo(1));
        Assert.That(result.Items[0].Level, Is.EqualTo(Level.White));
    }

    [Test]
    public async Task GetPaginatedChallenges_WithMultipleSelectedLevels_ShouldReturnAllMatchingLevels()
    {
        // Arrange
        using (var seedContext = DbContextFactory.CreateDbContext())
        {
            seedContext.Challenges.Add(BuildChallenge(1, level: Level.White));
            seedContext.Challenges.Add(BuildChallenge(2, level: Level.Green));
            seedContext.Challenges.Add(BuildChallenge(3, level: Level.OliveGreen));
            await seedContext.SaveChangesAsync();
        }

        // Act
        var result = await _service.GetPaginatedChallenges(1, "user1", Level.OliveGreen, false, [Level.White, Level.Green], []);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Items.Count, Is.EqualTo(2));
        Assert.That(result.Items.Select(c => c.Id), Is.EquivalentTo([1, 2]));
    }

    [Test]
    public async Task GetPaginatedChallenges_WithCategoryFilter_ShouldReturnOnlyMatchingCategories()
    {
        // Arrange
        using (var seedContext = DbContextFactory.CreateDbContext())
        {
            seedContext.Challenges.Add(BuildChallenge(1, category: ChallengeCategory.CSharp));
            seedContext.Challenges.Add(BuildChallenge(2, category: ChallengeCategory.SQL));
            await seedContext.SaveChangesAsync();
        }

        // Act
        var result = await _service.GetPaginatedChallenges(1, "user1", Level.White, false, [], [ChallengeCategory.SQL]);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Items.Count, Is.EqualTo(1));
        Assert.That(result.Items[0].Category, Is.EqualTo(ChallengeCategory.SQL));
    }

    [Test]
    public async Task GetPaginatedChallenges_WithLevelAndCategoryFilters_ShouldReturnOnlyMatchingChallenges()
    {
        // Arrange
        using (var seedContext = DbContextFactory.CreateDbContext())
        {
            seedContext.Challenges.Add(BuildChallenge(1, level: Level.White, category: ChallengeCategory.CSharp));
            seedContext.Challenges.Add(BuildChallenge(2, level: Level.White, category: ChallengeCategory.SQL));
            seedContext.Challenges.Add(BuildChallenge(3, level: Level.Green, category: ChallengeCategory.CSharp));
            await seedContext.SaveChangesAsync();
        }

        // Act
        var result = await _service.GetPaginatedChallenges(1, "user1", Level.Green, false, [Level.White], [ChallengeCategory.CSharp]);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Items.Count, Is.EqualTo(1));
        Assert.That(result.Items[0].Id, Is.EqualTo(1));
    }
}
