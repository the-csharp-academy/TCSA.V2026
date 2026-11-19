using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using TCSA.V2026.Data.DTOs;
using TCSA.V2026.Data.Enums;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Helpers.Constants;
using TCSA.V2026.Services;

namespace TCSA.V2026.IntegrationTests;

[TestFixture]
public class FeedbackAdminServiceTests : IntegrationTestsBase
{
    private static readonly DateTimeOffset Now = new(2026, 10, 8, 12, 0, 0, TimeSpan.Zero);

    private FeedbackAdminService _service;

    [SetUp]
    public void Setup()
    {
        BaseSetup();
        _service = new FeedbackAdminService(DbContextFactory, NullLogger<FeedbackAdminService>.Instance);
    }

    [TearDown]
    public void TearDown()
    {
        BaseTearDown();
    }

    private async Task<int> Seed(
        FeedbackCategory category = FeedbackCategory.Idea,
        DateTimeOffset? createdAt = null,
        FeedbackReviewState? reviewState = null,
        FeedbackArea? area = null,
        string? reportedPage = null,
        string originUrl = "/dashboard",
        string body = "Seeded feedback body",
        string userId = "user1")
    {
        using var context = DbContextFactory.CreateDbContext();
        var item = new FeedbackItem
        {
            AppUserId = userId,
            Category = category,
            Area = area,
            ReportedPage = reportedPage,
            OriginUrl = originUrl,
            Body = body,
            ReviewState = reviewState,
            CreatedAt = createdAt ?? Now
        };
        context.FeedbackItems.Add(item);
        await context.SaveChangesAsync();
        return item.Id;
    }

    private async Task<List<int>> Ids(FeedbackAdminFilter filter, int pageNumber = 1, int pageSize = 50)
    {
        var page = await _service.GetItems(filter, pageNumber, pageSize);
        return page.Items.Select(i => i.Id).ToList();
    }

    [Test]
    public async Task GetItems_ReturnsEveryItemRegardlessOfReviewState()
    {
        var newBug = await Seed(FeedbackCategory.Bug, reviewState: FeedbackReviewState.New);
        var archived = await Seed(FeedbackCategory.Idea, reviewState: FeedbackReviewState.Archived);
        var compliment = await Seed(FeedbackCategory.Compliment, reviewState: null);

        var ids = await Ids(new FeedbackAdminFilter());

        Assert.That(ids, Is.EquivalentTo([newBug, archived, compliment]));
    }

    [Test]
    public async Task GetItems_OrdersNewestFirst_WithIdAsTieBreak()
    {
        var oldest = await Seed(createdAt: Now.AddHours(-2));
        var tieFirst = await Seed(createdAt: Now.AddHours(-1));
        var tieSecond = await Seed(createdAt: Now.AddHours(-1));
        var newest = await Seed(createdAt: Now);

        var ids = await Ids(new FeedbackAdminFilter());

        Assert.That(ids, Is.EqualTo([newest, tieSecond, tieFirst, oldest]));
    }

    [Test]
    public async Task GetItems_PaginatesOnTheServer()
    {
        var seeded = new List<int>();
        for (var i = 0; i < 7; i++)
        {
            seeded.Add(await Seed(createdAt: Now.AddMinutes(i)));
        }
        seeded.Reverse(); // newest first

        var page1 = await _service.GetItems(new FeedbackAdminFilter(), 1, 3);
        var page2 = await _service.GetItems(new FeedbackAdminFilter(), 2, 3);
        var page3 = await _service.GetItems(new FeedbackAdminFilter(), 3, 3);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(page1.Items.Select(i => i.Id), Is.EqualTo(seeded.Take(3)));
            Assert.That(page2.Items.Select(i => i.Id), Is.EqualTo(seeded.Skip(3).Take(3)));
            Assert.That(page3.Items.Select(i => i.Id), Is.EqualTo(seeded.Skip(6)));
            Assert.That(page1.TotalItems, Is.EqualTo(7));
            Assert.That(page1.TotalPages, Is.EqualTo(3));
            Assert.That(page2.PageNumber, Is.EqualTo(2));
            Assert.That(page2.PageSize, Is.EqualTo(3));
        }
    }

    [Test]
    public async Task GetItems_DefaultsToTheAdminPageSize()
    {
        for (var i = 0; i < PagingConstants.AdminFeedbackPageSize + 2; i++)
        {
            await Seed(createdAt: Now.AddMinutes(i));
        }

        var page = await _service.GetItems(new FeedbackAdminFilter(), 1);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(page.Items, Has.Count.EqualTo(PagingConstants.AdminFeedbackPageSize));
            Assert.That(page.TotalItems, Is.EqualTo(PagingConstants.AdminFeedbackPageSize + 2));
        }
    }

    [Test]
    public async Task GetItems_PageBeyondTheEnd_ReturnsNoItemsButTheTotal()
    {
        await Seed();

        var page = await _service.GetItems(new FeedbackAdminFilter(), 5, 10);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(page.Items, Is.Empty);
            Assert.That(page.TotalItems, Is.EqualTo(1));
        }
    }

    [Test]
    public async Task GetItems_InvalidPaging_IsClampedToFirstPage()
    {
        var id = await Seed();

        var page = await _service.GetItems(new FeedbackAdminFilter(), 0, 0);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(page.PageNumber, Is.EqualTo(1));
            Assert.That(page.Items.Select(i => i.Id), Is.EqualTo([id]));
        }
    }

    [Test]
    public async Task GetItems_FiltersByCategory()
    {
        var bug = await Seed(FeedbackCategory.Bug);
        await Seed(FeedbackCategory.Idea);

        var ids = await Ids(new FeedbackAdminFilter { Category = FeedbackCategory.Bug });

        Assert.That(ids, Is.EqualTo([bug]));
    }

    [Test]
    public async Task GetItems_FiltersByReviewState()
    {
        var reviewed = await Seed(FeedbackCategory.Bug, reviewState: FeedbackReviewState.Reviewed);
        await Seed(FeedbackCategory.Bug, reviewState: FeedbackReviewState.New);
        await Seed(FeedbackCategory.Compliment, reviewState: null);

        var ids = await Ids(new FeedbackAdminFilter { ReviewState = FeedbackReviewState.Reviewed });

        Assert.That(ids, Is.EqualTo([reviewed]));
    }

    [Test]
    public async Task GetItems_FiltersByArea()
    {
        var profileBug = await Seed(FeedbackCategory.Bug, area: FeedbackArea.Profile, reportedPage: "/dashboard/profile");
        await Seed(FeedbackCategory.Bug, area: FeedbackArea.Leaderboard, reportedPage: "/dashboard/leaderboard");
        await Seed(FeedbackCategory.Idea);

        var ids = await Ids(new FeedbackAdminFilter { Area = FeedbackArea.Profile });

        Assert.That(ids, Is.EqualTo([profileBug]));
    }

    [Test]
    public async Task GetItems_Search_MatchesBodyReportedPageAndOriginUrl_IgnoringCase()
    {
        var byBody = await Seed(body: "The Leaderboard is slow");
        var byPage = await Seed(FeedbackCategory.Bug, area: FeedbackArea.Other, reportedPage: "/dashboard/leaderboard");
        var byOrigin = await Seed(originUrl: "/dashboard/leaderboard/2");
        await Seed(body: "Something else entirely", originUrl: "/dashboard/profile");

        var ids = await Ids(new FeedbackAdminFilter { Search = "LEADERBOARD" });

        Assert.That(ids, Is.EquivalentTo([byBody, byPage, byOrigin]));
    }

    [Test]
    public async Task GetItems_Search_IgnoresBlankText()
    {
        var id = await Seed();

        var ids = await Ids(new FeedbackAdminFilter { Search = "   " });

        Assert.That(ids, Is.EqualTo([id]));
    }

    [Test]
    public async Task GetItems_FiltersByDateRange_FromInclusive_ToExclusive()
    {
        await Seed(createdAt: Now.AddDays(-3));
        var atFrom = await Seed(createdAt: Now.AddDays(-2));
        var inside = await Seed(createdAt: Now.AddDays(-1));
        await Seed(createdAt: Now);

        var ids = await Ids(new FeedbackAdminFilter { From = Now.AddDays(-2), To = Now });

        Assert.That(ids, Is.EqualTo([inside, atFrom]));
    }

    [Test]
    public async Task GetItems_CombinedFilters_AllApply()
    {
        var match = await Seed(FeedbackCategory.Bug, createdAt: Now, reviewState: FeedbackReviewState.New,
            area: FeedbackArea.Profile, reportedPage: "/dashboard/profile", body: "Save button broken");
        await Seed(FeedbackCategory.Bug, createdAt: Now, reviewState: FeedbackReviewState.Reviewed,
            area: FeedbackArea.Profile, reportedPage: "/dashboard/profile", body: "Save button broken");
        await Seed(FeedbackCategory.Bug, createdAt: Now, reviewState: FeedbackReviewState.New,
            area: FeedbackArea.Leaderboard, reportedPage: "/dashboard/leaderboard", body: "Save button broken");
        await Seed(FeedbackCategory.Idea, createdAt: Now, reviewState: FeedbackReviewState.New, body: "Save button broken");
        await Seed(FeedbackCategory.Bug, createdAt: Now.AddDays(-10), reviewState: FeedbackReviewState.New,
            area: FeedbackArea.Profile, reportedPage: "/dashboard/profile", body: "Save button broken");

        var ids = await Ids(new FeedbackAdminFilter
        {
            Category = FeedbackCategory.Bug,
            ReviewState = FeedbackReviewState.New,
            Area = FeedbackArea.Profile,
            Search = "save",
            From = Now.AddDays(-1)
        });

        Assert.That(ids, Is.EqualTo([match]));
    }

    [Test]
    public async Task GetItems_TotalItemsReflectsTheFilter()
    {
        await Seed(FeedbackCategory.Bug);
        await Seed(FeedbackCategory.Bug);
        await Seed(FeedbackCategory.Idea);

        var page = await _service.GetItems(new FeedbackAdminFilter { Category = FeedbackCategory.Bug }, 1, 1);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(page.TotalItems, Is.EqualTo(2));
            Assert.That(page.Items, Has.Count.EqualTo(1));
        }
    }

    [Test]
    public async Task GetItem_ExistingItem_ReturnsDetail()
    {
        var id = await Seed(FeedbackCategory.Bug, area: FeedbackArea.Profile, reportedPage: "/dashboard/profile",
            originUrl: "/dashboard/profile", body: "Save button broken", reviewState: FeedbackReviewState.New);

        var result = await _service.GetItem(id);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSuccess, Is.True);
            Assert.That(result.Value.Id, Is.EqualTo(id));
            Assert.That(result.Value.Category, Is.EqualTo(FeedbackCategory.Bug));
            Assert.That(result.Value.Area, Is.EqualTo(FeedbackArea.Profile));
            Assert.That(result.Value.ReportedPage, Is.EqualTo("/dashboard/profile"));
            Assert.That(result.Value.OriginUrl, Is.EqualTo("/dashboard/profile"));
            Assert.That(result.Value.Body, Is.EqualTo("Save button broken"));
            Assert.That(result.Value.ReviewState, Is.EqualTo(FeedbackReviewState.New));
            Assert.That(result.Value.UserName, Is.EqualTo("testuser"));
        }
    }

    [Test]
    public async Task GetItem_Missing_ReturnsNotFound()
    {
        var result = await _service.GetItem(999);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailure, Is.True);
            Assert.That(result.Reason.Code, Is.EqualTo(FeedbackErrorCodes.NotFound));
        }
    }

    [Test]
    public async Task DeleteItem_RemovesOnlyThatItemPermanently()
    {
        var doomed = await Seed();
        var kept = await Seed();

        var result = await _service.DeleteItem(doomed);

        using var context = DbContextFactory.CreateDbContext();
        var remaining = await context.FeedbackItems.AsNoTracking().Select(f => f.Id).ToListAsync();
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSuccess, Is.True);
            Assert.That(remaining, Is.EqualTo(new[] { kept }));
            Assert.That(await Ids(new FeedbackAdminFilter()), Is.EqualTo([kept]));
        }
    }

    [Test]
    public async Task DeleteItem_Missing_ReturnsNotFoundAndChangesNothing()
    {
        var kept = await Seed();

        var result = await _service.DeleteItem(999);

        using var context = DbContextFactory.CreateDbContext();
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailure, Is.True);
            Assert.That(result.Reason.Code, Is.EqualTo(FeedbackErrorCodes.NotFound));
            Assert.That(await context.FeedbackItems.CountAsync(), Is.EqualTo(1));
            Assert.That(await context.FeedbackItems.AnyAsync(f => f.Id == kept), Is.True);
        }
    }
}
