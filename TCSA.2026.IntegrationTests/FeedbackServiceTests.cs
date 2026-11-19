using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using TCSA.V2026.Data;
using TCSA.V2026.Data.DTOs;
using TCSA.V2026.Data.Enums;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Helpers.Constants;
using TCSA.V2026.Services;

namespace TCSA.V2026.IntegrationTests;

[TestFixture]
public class FeedbackServiceTests : IntegrationTestsBase
{
    private const string UserId = "user1";

    private FeedbackService _service;

    [SetUp]
    public void Setup()
    {
        BaseSetup();
        _service = new FeedbackService(DbContextFactory, NullLogger<FeedbackService>.Instance);
    }

    [TearDown]
    public void TearDown()
    {
        BaseTearDown();
    }

    private static FeedbackSubmissionDto Idea(string description = "Please add a dark mode toggle.") => new()
    {
        Category = FeedbackCategory.Idea,
        Description = description,
        OriginUrl = "/dashboard/roadmap"
    };

    private static FeedbackSubmissionDto Bug(string description = "The save button does nothing.") => new()
    {
        Category = FeedbackCategory.Bug,
        Description = description,
        OriginUrl = "/dashboard/profile",
        Area = FeedbackArea.Profile,
        Page = "/dashboard/profile"
    };

    private async Task<List<FeedbackItem>> StoredItems()
    {
        using var context = DbContextFactory.CreateDbContext();
        return await context.FeedbackItems.AsNoTracking().ToListAsync();
    }

    private async Task SeedItems(string userId, int count, DateTimeOffset createdAt)
    {
        using var context = DbContextFactory.CreateDbContext();
        for (var i = 0; i < count; i++)
        {
            context.FeedbackItems.Add(new FeedbackItem
            {
                AppUserId = userId,
                Category = FeedbackCategory.Idea,
                Body = $"Seeded item {i}",
                OriginUrl = "/",
                ReviewState = FeedbackReviewState.New,
                CreatedAt = createdAt
            });
        }

        await context.SaveChangesAsync();
    }

    [Test]
    public async Task Submit_ValidIdea_StoresItemWithUserTimestampAndOrigin()
    {
        var before = DateTimeOffset.UtcNow;

        var result = await _service.Submit(UserId, Idea());

        var after = DateTimeOffset.UtcNow;
        var items = await StoredItems();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSuccess, Is.True);
            Assert.That(items, Has.Count.EqualTo(1));
            Assert.That(items[0].AppUserId, Is.EqualTo(UserId));
            Assert.That(items[0].Category, Is.EqualTo(FeedbackCategory.Idea));
            Assert.That(items[0].Body, Is.EqualTo("Please add a dark mode toggle."));
            Assert.That(items[0].OriginUrl, Is.EqualTo("/dashboard/roadmap"));
            Assert.That(items[0].CreatedAt, Is.InRange(before, after));
        }
    }

    [Test]
    public async Task Submit_OriginUrl_IsNormalized()
    {
        var submission = Idea();
        submission.OriginUrl = "/Dashboard/Roadmap/?tab=2";

        await _service.Submit(UserId, submission);

        var items = await StoredItems();
        Assert.That(items[0].OriginUrl, Is.EqualTo("/dashboard/roadmap"));
    }

    [Test]
    public async Task Submit_Description_IsTrimmed()
    {
        await _service.Submit(UserId, Idea("   Please add a dark mode toggle.   "));

        var items = await StoredItems();
        Assert.That(items[0].Body, Is.EqualTo("Please add a dark mode toggle."));
    }

    [Test]
    public async Task Submit_Idea_IgnoresAreaAndPage()
    {
        var submission = Idea();
        submission.Area = FeedbackArea.Profile;
        submission.Page = "/dashboard/profile";

        await _service.Submit(UserId, submission);

        var items = await StoredItems();
        using (Assert.EnterMultipleScope())
        {
            Assert.That(items[0].Area, Is.Null);
            Assert.That(items[0].ReportedPage, Is.Null);
        }
    }

    [Test]
    public async Task Submit_Bug_StoresAreaAndNormalizedReportedPageAlongsideOrigin()
    {
        var submission = Bug();
        submission.OriginUrl = "/dashboard/profile";
        submission.Area = FeedbackArea.Challenges;
        submission.Page = "  /Dashboard/Challenges/?x=1 ";

        var result = await _service.Submit(UserId, submission);

        var items = await StoredItems();
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSuccess, Is.True);
            Assert.That(items[0].Area, Is.EqualTo(FeedbackArea.Challenges));
            Assert.That(items[0].ReportedPage, Is.EqualTo("/dashboard/challenges"));
            Assert.That(items[0].OriginUrl, Is.EqualTo("/dashboard/profile"));
        }
    }

    [TestCase(FeedbackCategory.Bug, FeedbackReviewState.New)]
    [TestCase(FeedbackCategory.Idea, FeedbackReviewState.New)]
    [TestCase(FeedbackCategory.Help, FeedbackReviewState.New)]
    [TestCase(FeedbackCategory.Compliment, FeedbackReviewState.New)]
    public async Task Submit_EveryWidgetItem_StartsAsNew(FeedbackCategory category, FeedbackReviewState? expected)
    {
        var submission = Bug();
        submission.Category = category;

        var result = await _service.Submit(UserId, submission);

        var items = await StoredItems();
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSuccess, Is.True);
            Assert.That(items[0].ReviewState, Is.EqualTo(expected));
        }
    }

    [Test]
    public async Task Submit_DescriptionAtMinimumLength_IsAccepted()
    {
        var result = await _service.Submit(UserId, Idea(new string('a', FeedbackLimits.DescriptionMinLength)));

        Assert.That(result.IsSuccess, Is.True);
    }

    [Test]
    public async Task Submit_DescriptionAtMaximumLength_IsAccepted()
    {
        var result = await _service.Submit(UserId, Idea(new string('a', FeedbackLimits.DescriptionMaxLength)));

        Assert.That(result.IsSuccess, Is.True);
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase("     ")]
    [TestCase("abcd")]
    [TestCase("  abcd  ")]
    public async Task Submit_DescriptionBelowMinimum_IsRejectedAndNothingIsStored(string? description)
    {
        var result = await _service.Submit(UserId, Idea(description!));

        var items = await StoredItems();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailure, Is.True);
            Assert.That(result.Reason.Code, Is.EqualTo(FeedbackErrorCodes.DescriptionLength));
            Assert.That(items, Is.Empty);
        }
    }

    [Test]
    public async Task Submit_DescriptionAboveMaximum_IsRejectedAndNothingIsStored()
    {
        var result = await _service.Submit(UserId, Idea(new string('a', FeedbackLimits.DescriptionMaxLength + 1)));

        var items = await StoredItems();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailure, Is.True);
            Assert.That(result.Reason.Code, Is.EqualTo(FeedbackErrorCodes.DescriptionLength));
            Assert.That(items, Is.Empty);
        }
    }

    [Test]
    public async Task Submit_BugWithoutArea_IsRejected()
    {
        var submission = Bug();
        submission.Area = null;

        var result = await _service.Submit(UserId, submission);

        var items = await StoredItems();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailure, Is.True);
            Assert.That(result.Reason.Code, Is.EqualTo(FeedbackErrorCodes.AreaRequired));
            Assert.That(items, Is.Empty);
        }
    }

    [Test]
    public async Task Submit_BugWithUnknownArea_IsRejected()
    {
        var submission = Bug();
        submission.Area = (FeedbackArea)999;

        var result = await _service.Submit(UserId, submission);

        var items = await StoredItems();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailure, Is.True);
            Assert.That(result.Reason.Code, Is.EqualTo(FeedbackErrorCodes.AreaRequired));
            Assert.That(items, Is.Empty);
        }
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase("   ")]
    public async Task Submit_BugWithoutPage_IsRejected(string? page)
    {
        var submission = Bug();
        submission.Page = page;

        var result = await _service.Submit(UserId, submission);

        var items = await StoredItems();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailure, Is.True);
            Assert.That(result.Reason.Code, Is.EqualTo(FeedbackErrorCodes.PageRequired));
            Assert.That(items, Is.Empty);
        }
    }

    [Test]
    public async Task Submit_BugWithPageAtMaximumLength_IsAccepted()
    {
        var submission = Bug();
        submission.Page = "/" + new string('a', FeedbackLimits.PageMaxLength - 1);

        var result = await _service.Submit(UserId, submission);

        Assert.That(result.IsSuccess, Is.True);
    }

    [Test]
    public async Task Submit_BugWithPageAboveMaximum_IsRejected()
    {
        var submission = Bug();
        submission.Page = "/" + new string('a', FeedbackLimits.PageMaxLength);

        var result = await _service.Submit(UserId, submission);

        var items = await StoredItems();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailure, Is.True);
            Assert.That(result.Reason.Code, Is.EqualTo(FeedbackErrorCodes.PageTooLong));
            Assert.That(items, Is.Empty);
        }
    }

    [Test]
    public async Task Submit_BugWithPageWhoseNormalizedFormExceedsMaximum_IsRejected()
    {
        // No leading slash: the raw value is exactly at the limit, but it normalizes to one character more.
        var submission = Bug();
        submission.Page = new string('a', FeedbackLimits.PageMaxLength);

        var result = await _service.Submit(UserId, submission);

        var items = await StoredItems();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailure, Is.True);
            Assert.That(result.Reason.Code, Is.EqualTo(FeedbackErrorCodes.PageTooLong));
            Assert.That(items, Is.Empty);
        }
    }

    [Test]
    public async Task Submit_BugWithPageWhoseNormalizedFormIsAtMaximum_IsAcceptedAndStoredWithinTheColumnLimit()
    {
        var submission = Bug();
        submission.Page = new string('a', FeedbackLimits.PageMaxLength - 1);

        var result = await _service.Submit(UserId, submission);

        var items = await StoredItems();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSuccess, Is.True);
            Assert.That(items[0].ReportedPage, Has.Length.EqualTo(FeedbackLimits.PageMaxLength));
        }
    }

    [Test]
    public async Task Submit_WhenSavingFails_ReturnsAGenericMessageAndLogsTheException()
    {
        var failure = new InvalidOperationException("Cannot open server 'db-prod-01' (secret detail)");
        var factoryMock = new Mock<IDbContextFactory<ApplicationDbContext>>();
        factoryMock.Setup(f => f.CreateDbContext()).Throws(failure);
        var loggerMock = new Mock<ILogger<FeedbackService>>();
        var service = new FeedbackService(factoryMock.Object, loggerMock.Object);

        var result = await service.Submit(UserId, Idea());

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailure, Is.True);
            Assert.That(result.Reason.Code, Is.EqualTo(FeedbackErrorCodes.Unexpected));
            Assert.That(result.Message, Does.Not.Contain("secret detail"));
            Assert.That(result.Message, Is.Not.Empty);
            loggerMock.Verify(l => l.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                failure,
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()), Times.Once);
        }
    }

    [Test]
    public async Task Submit_NonBugWithOverlongPage_IsAcceptedBecausePageIsIgnored()
    {
        var submission = Idea();
        submission.Page = new string('a', FeedbackLimits.PageMaxLength * 2);

        var result = await _service.Submit(UserId, submission);

        Assert.That(result.IsSuccess, Is.True);
    }

    [Test]
    public async Task Submit_UnknownCategory_IsRejected()
    {
        var submission = Idea();
        submission.Category = (FeedbackCategory)999;

        var result = await _service.Submit(UserId, submission);

        var items = await StoredItems();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailure, Is.True);
            Assert.That(result.Reason.Code, Is.EqualTo(FeedbackErrorCodes.CategoryInvalid));
            Assert.That(items, Is.Empty);
        }
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase("  ")]
    public async Task Submit_WithoutUser_IsRejected(string? userId)
    {
        var result = await _service.Submit(userId!, Idea());

        var items = await StoredItems();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailure, Is.True);
            Assert.That(result.Reason.Code, Is.EqualTo(FeedbackErrorCodes.UserRequired));
            Assert.That(items, Is.Empty);
        }
    }

    [Test]
    public async Task Submit_OverlongOriginUrl_IsTruncatedNotRejected()
    {
        var submission = Idea();
        submission.OriginUrl = "/" + new string('a', FeedbackLimits.OriginUrlMaxLength * 2);

        var result = await _service.Submit(UserId, submission);

        var items = await StoredItems();
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSuccess, Is.True);
            Assert.That(items[0].OriginUrl, Has.Length.EqualTo(FeedbackLimits.OriginUrlMaxLength));
        }
    }

    [Test]
    public async Task Submit_OverRateLimit_IsRejectedWithClearMessage()
    {
        for (var i = 0; i < FeedbackLimits.RateLimitMaxSubmissions; i++)
        {
            var accepted = await _service.Submit(UserId, Idea($"Submission number {i}"));
            Assert.That(accepted.IsSuccess, Is.True, $"submission {i} should be accepted");
        }

        var result = await _service.Submit(UserId, Idea("One too many"));

        var items = await StoredItems();
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailure, Is.True);
            Assert.That(result.Reason.Code, Is.EqualTo(FeedbackErrorCodes.RateLimited));
            Assert.That(result.Message, Is.Not.Empty);
            Assert.That(items, Has.Count.EqualTo(FeedbackLimits.RateLimitMaxSubmissions));
        }
    }

    [Test]
    public async Task Submit_UnderRateLimit_IsAccepted()
    {
        await SeedItems(UserId, FeedbackLimits.RateLimitMaxSubmissions - 1, DateTimeOffset.UtcNow.AddMinutes(-1));

        var result = await _service.Submit(UserId, Idea());

        Assert.That(result.IsSuccess, Is.True);
    }

    [Test]
    public async Task Submit_AtRateLimitWithinWindow_IsRejected()
    {
        await SeedItems(UserId, FeedbackLimits.RateLimitMaxSubmissions,
            DateTimeOffset.UtcNow - FeedbackLimits.RateLimitWindow + TimeSpan.FromSeconds(30));

        var result = await _service.Submit(UserId, Idea());

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailure, Is.True);
            Assert.That(result.Reason.Code, Is.EqualTo(FeedbackErrorCodes.RateLimited));
        }
    }

    [Test]
    public async Task Submit_AtRateLimitButOutsideWindow_IsAccepted()
    {
        await SeedItems(UserId, FeedbackLimits.RateLimitMaxSubmissions,
            DateTimeOffset.UtcNow - FeedbackLimits.RateLimitWindow - TimeSpan.FromSeconds(30));

        var result = await _service.Submit(UserId, Idea());

        Assert.That(result.IsSuccess, Is.True);
    }

    [Test]
    public async Task Submit_OtherUsersItems_DoNotCountTowardsTheLimit()
    {
        await SeedItems("user2", FeedbackLimits.RateLimitMaxSubmissions, DateTimeOffset.UtcNow.AddMinutes(-1));

        var result = await _service.Submit(UserId, Idea());

        Assert.That(result.IsSuccess, Is.True);
    }

    [Test]
    public async Task Submit_RateLimitAppliesToEveryCategory()
    {
        await SeedItems(UserId, FeedbackLimits.RateLimitMaxSubmissions, DateTimeOffset.UtcNow.AddMinutes(-1));
        var compliment = Idea();
        compliment.Category = FeedbackCategory.Compliment;

        var result = await _service.Submit(UserId, compliment);

        Assert.That(result.Reason.Code, Is.EqualTo(FeedbackErrorCodes.RateLimited));
    }

    [Test]
    public async Task Submit_InvalidSubmissionWhileRateLimited_ReportsTheValidationError()
    {
        await SeedItems(UserId, FeedbackLimits.RateLimitMaxSubmissions, DateTimeOffset.UtcNow.AddMinutes(-1));

        var result = await _service.Submit(UserId, Idea("abc"));

        Assert.That(result.Reason.Code, Is.EqualTo(FeedbackErrorCodes.DescriptionLength));
    }
}
