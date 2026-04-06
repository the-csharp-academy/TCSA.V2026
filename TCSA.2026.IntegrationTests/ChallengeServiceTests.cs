using Microsoft.EntityFrameworkCore;
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
    public async Task GetStreakInfo_ShouldReturnNewStreakInfo_WhenUserHasNoExistingStreak()
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
        var streakInfo = await _service.GetStreakInfo(userId);

        // Assert
        Assert.That(streakInfo, Is.Not.Null);
        Assert.That(streakInfo.CurrentStreak, Is.EqualTo(0));
        Assert.That(streakInfo.LongestStreak, Is.EqualTo(0));
        Assert.That(streakInfo.LastCompletedDate, Is.EqualTo(default(DateTime)));
    }

    [Test]
    public async Task GetStreakInfo_ShouldResetStreak_WhenLastCompletedDateIsBeforeYesterday()
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
        var streakInfo = await _service.GetStreakInfo(userId);

        // Assert
        Assert.That(streakInfo, Is.Not.Null);
        Assert.That(streakInfo.CurrentStreak, Is.EqualTo(0));
        Assert.That(streakInfo.LongestStreak, Is.EqualTo(5));
        Assert.That(streakInfo.LastCompletedDate.Date, Is.EqualTo(DateTime.UtcNow.Date.AddDays(-3)));

        using var assertContext = DbContextFactory.CreateDbContext();
        var updatedStreak = await assertContext.DailyStreaks
            .FirstOrDefaultAsync(s => s.AppUserId == userId);
        Assert.That(updatedStreak, Is.Not.Null);
        Assert.That(updatedStreak.CurrentStreak, Is.EqualTo(0));
    }
}
