using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using TCSA.V2026.Data.Enums;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Data.Models.Responses;
using TCSA.V2026.Services;

namespace TCSA.V2026.IntegrationTests;

public class ChallengeServiceTests : IntegrationTestsBase
{
    private ChallengeService _service;

    [SetUp]
    public void Setup()
    {
        BaseSetup();
        _service = new ChallengeService(DbContextFactory, NullLogger<ChallengeService>.Instance);
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

    [Test]
    public async Task AddChallenge_ShouldNotAddDuplicate()
    {
        // Arrange
        var challenge = new Challenge
        {
            ExternalId = "fakeId",
            Description = "desc",
            Keywords = "kw",
            Name = "challenge1",
            ExperiencePoints = 1,
            Platform = ChallengePlatform.LeetCode,
            Level = Level.Green,
        };

        // Act
        var result = await _service.AddChallenge(challenge);
        var resultDuplicate = await _service.AddChallenge(challenge);

        // Assert
        Assert.That(result.Status, Is.EqualTo(ResponseStatus.Success));
        Assert.That(resultDuplicate.Status, Is.EqualTo(ResponseStatus.Fail));
        Assert.That(resultDuplicate.Message, Is.EqualTo("Challenge already exists."));

        using var assertContext = DbContextFactory.CreateDbContext();
        var challenges = await assertContext.Challenges.Where(c => c.ExternalId == challenge.ExternalId).ToListAsync();
        Assert.That(challenges.Count, Is.EqualTo(1));
    }
}
