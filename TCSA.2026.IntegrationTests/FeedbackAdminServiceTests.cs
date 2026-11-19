using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using TCSA.V2026.Data.DTOs;
using TCSA.V2026.Data.Enums;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Helpers;
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

    private static readonly FeedbackClusterKey ProfileBugs = new(FeedbackCategory.Bug, "/dashboard/profile");

    private Task<int> SeedBug(string page = "/dashboard/profile", FeedbackReviewState? state = FeedbackReviewState.New,
        DateTimeOffset? createdAt = null, string body = "Bug body", string originUrl = "/dashboard") =>
        Seed(FeedbackCategory.Bug, createdAt, state, FeedbackArea.Profile, page, originUrl, body);

    private Task<int> SeedIdea(string originUrl = "/dashboard", FeedbackReviewState? state = FeedbackReviewState.New,
        DateTimeOffset? createdAt = null, string body = "Idea body") =>
        Seed(FeedbackCategory.Idea, createdAt, state, originUrl: originUrl, body: body);

    private async Task<FeedbackReviewState?> StateOf(int id)
    {
        using var context = DbContextFactory.CreateDbContext();
        return (await context.FeedbackItems.AsNoTracking().SingleAsync(f => f.Id == id)).ReviewState;
    }

    private async Task<int> TotalItems()
    {
        using var context = DbContextFactory.CreateDbContext();
        return await context.FeedbackItems.CountAsync();
    }

    [Test]
    public async Task GetQueue_ContainsEveryCategory_AsSeparateClusters()
    {
        await SeedBug("/dashboard/profile");
        await SeedIdea("/dashboard/profile");
        await Seed(FeedbackCategory.Compliment, reviewState: FeedbackReviewState.New, originUrl: "/dashboard/profile");
        await Seed(FeedbackCategory.Help, reviewState: FeedbackReviewState.New, originUrl: "/dashboard/profile");

        var queue = await _service.GetQueue();

        Assert.That(queue.Select(c => c.Category),
            Is.EquivalentTo([FeedbackCategory.Bug, FeedbackCategory.Idea, FeedbackCategory.Compliment, FeedbackCategory.Help]));
    }

    [TestCase(FeedbackCategory.Compliment)]
    [TestCase(FeedbackCategory.Help)]
    public async Task GetQueue_ClustersComplimentsAndHelpByOriginPath(FeedbackCategory category)
    {
        await Seed(category, reviewState: FeedbackReviewState.New, originUrl: "/dashboard/profile");
        await Seed(category, reviewState: FeedbackReviewState.New, originUrl: "/dashboard/profile");
        await Seed(category, reviewState: FeedbackReviewState.New, originUrl: "/dashboard/leaderboard");

        var queue = await _service.GetQueue();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(queue, Has.Count.EqualTo(2));
            Assert.That(queue.Single(c => c.Page == "/dashboard/profile").Count, Is.EqualTo(2));
            Assert.That(queue.Single(c => c.Page == "/dashboard/leaderboard").Count, Is.EqualTo(1));
        }
    }

    [Test]
    public async Task GetQueue_GroupsBugsOnTheSameNormalizedPage_AndSeparatesDifferentPages()
    {
        await SeedBug("/dashboard/profile", originUrl: "/dashboard");
        await SeedBug("/dashboard/profile", originUrl: "/dashboard/leaderboard");
        await SeedBug("/dashboard/leaderboard");

        var queue = await _service.GetQueue();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(queue, Has.Count.EqualTo(2));
            Assert.That(queue.Single(c => c.Page == "/dashboard/profile").Count, Is.EqualTo(2));
            Assert.That(queue.Single(c => c.Page == "/dashboard/leaderboard").Count, Is.EqualTo(1));
        }
    }

    [Test]
    public async Task GetQueue_ClustersIdeasByOriginPath_AndKeepsThemApartFromBugsOnTheSamePage()
    {
        await SeedIdea("/dashboard/profile");
        await SeedIdea("/dashboard/profile");
        await SeedIdea("/dashboard/leaderboard");
        await SeedBug("/dashboard/profile");

        var queue = await _service.GetQueue();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(queue, Has.Count.EqualTo(3));
            Assert.That(queue.Single(c => c.Category == FeedbackCategory.Idea && c.Page == "/dashboard/profile").Count, Is.EqualTo(2));
            Assert.That(queue.Single(c => c.Category == FeedbackCategory.Bug).Count, Is.EqualTo(1));
        }
    }

    [Test]
    public async Task GetQueue_CarriesCountsFirstAndLastSeenAndTheNewestNewBodyAsSample()
    {
        await SeedBug(createdAt: Now.AddDays(-3), body: "oldest", state: FeedbackReviewState.Reviewed);
        await SeedBug(createdAt: Now.AddDays(-2), body: "older new");
        await SeedBug(createdAt: Now.AddDays(-1), body: "newest new");
        await SeedBug(createdAt: Now, body: "newest but handled", state: FeedbackReviewState.Archived);

        var cluster = (await _service.GetQueue()).Single();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(cluster.Key, Is.EqualTo(ProfileBugs));
            Assert.That(cluster.Count, Is.EqualTo(4));
            Assert.That(cluster.NewCount, Is.EqualTo(2));
            Assert.That(cluster.FirstSeen, Is.EqualTo(Now.AddDays(-3)));
            Assert.That(cluster.LastSeen, Is.EqualTo(Now));
            Assert.That(cluster.SampleBody, Is.EqualTo("newest new"));
        }
    }

    [Test]
    public async Task GetQueue_ClusterStaysWhileItHasNewItems_AndLeavesWhenNoneRemain()
    {
        var first = await SeedBug();
        var second = await SeedBug();

        await _service.SetItemState(first, FeedbackReviewState.Reviewed);
        var stillQueued = await _service.GetQueue();

        await _service.SetItemState(second, FeedbackReviewState.Actioned);
        var cleared = await _service.GetQueue();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(stillQueued.Single().NewCount, Is.EqualTo(1));
            Assert.That(stillQueued.Single().Count, Is.EqualTo(2));
            Assert.That(cleared, Is.Empty);
        }
    }

    [Test]
    public async Task GetQueue_OrdersByNewCountThenMostRecentActivity()
    {
        await SeedBug("/a", createdAt: Now.AddDays(-5));
        await SeedBug("/b", createdAt: Now.AddDays(-4));
        await SeedBug("/b", createdAt: Now.AddDays(-4));
        await SeedBug("/c", createdAt: Now);

        var queue = await _service.GetQueue();

        Assert.That(queue.Select(c => c.Page), Is.EqualTo(["/b", "/c", "/a"]));
    }

    [Test]
    public async Task GetNewCount_CountsNewItemsOfEveryCategory()
    {
        await SeedBug();
        await SeedIdea();
        await SeedBug(state: FeedbackReviewState.Reviewed);
        await Seed(FeedbackCategory.Compliment, reviewState: FeedbackReviewState.New);
        await Seed(FeedbackCategory.Help, reviewState: FeedbackReviewState.New);
        await Seed(FeedbackCategory.Help, reviewState: FeedbackReviewState.Reviewed);

        Assert.That(await _service.GetNewCount(), Is.EqualTo(4));
    }

    [Test]
    public async Task GetClusterItems_ReturnsEveryItemOfThatCluster_NewOnesFirstThenNewestFirst()
    {
        var older = await SeedBug(createdAt: Now.AddHours(-4));
        var newer = await SeedBug(createdAt: Now.AddHours(-3));
        var handledOld = await SeedBug(createdAt: Now.AddHours(-2), state: FeedbackReviewState.Archived);
        var handledNew = await SeedBug(createdAt: Now.AddHours(-1), state: FeedbackReviewState.Reviewed);
        await SeedBug("/dashboard/leaderboard");
        await SeedIdea("/dashboard/profile");

        var items = await _service.GetClusterItems(ProfileBugs);

        Assert.That(items.Select(i => i.Id), Is.EqualTo([newer, older, handledNew, handledOld]));
    }

    [Test]
    public async Task GetClusterItems_ForACompliment_ReturnsOnlyItemsOnThatOriginPath()
    {
        var compliment = await Seed(FeedbackCategory.Compliment, reviewState: FeedbackReviewState.New, originUrl: "/dashboard/profile");
        await Seed(FeedbackCategory.Compliment, reviewState: FeedbackReviewState.New, originUrl: "/dashboard/leaderboard");
        await Seed(FeedbackCategory.Help, reviewState: FeedbackReviewState.New, originUrl: "/dashboard/profile");

        var items = await _service.GetClusterItems(new FeedbackClusterKey(FeedbackCategory.Compliment, "/dashboard/profile"));

        Assert.That(items.Select(i => i.Id), Is.EqualTo([compliment]));
    }

    [TestCase(FeedbackReviewState.Reviewed)]
    [TestCase(FeedbackReviewState.Actioned)]
    [TestCase(FeedbackReviewState.Archived)]
    public async Task SetItemState_RemovesTheItemFromTheQueue_ButKeepsItInAllFeedback(FeedbackReviewState state)
    {
        var id = await SeedBug();
        await SeedBug("/dashboard/leaderboard");

        var result = await _service.SetItemState(id, state);

        var all = await _service.GetItems(new FeedbackAdminFilter { ReviewState = state }, 1);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSuccess, Is.True);
            Assert.That(await StateOf(id), Is.EqualTo(state));
            Assert.That((await _service.GetQueue()).Select(c => c.Page), Is.EqualTo(["/dashboard/leaderboard"]));
            Assert.That(all.Items.Select(i => i.Id), Is.EqualTo([id]));
        }
    }

    [Test]
    public async Task SetItemState_TouchesOnlyThatItem()
    {
        var target = await SeedBug();
        var sibling = await SeedBug();

        await _service.SetItemState(target, FeedbackReviewState.Reviewed);

        Assert.That(await StateOf(sibling), Is.EqualTo(FeedbackReviewState.New));
    }

    [Test]
    public async Task SetItemState_Missing_ReturnsNotFound()
    {
        var result = await _service.SetItemState(999, FeedbackReviewState.Reviewed);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailure, Is.True);
            Assert.That(result.Reason.Code, Is.EqualTo(FeedbackErrorCodes.NotFound));
        }
    }

    [TestCase(FeedbackCategory.Compliment, FeedbackReviewState.Reviewed)]
    [TestCase(FeedbackCategory.Compliment, FeedbackReviewState.Archived)]
    [TestCase(FeedbackCategory.Help, FeedbackReviewState.Reviewed)]
    [TestCase(FeedbackCategory.Help, FeedbackReviewState.Actioned)]
    public async Task SetItemState_ForComplimentAndHelp_RemovesThemFromTheQueue_ButKeepsThemInAllFeedback(FeedbackCategory category, FeedbackReviewState state)
    {
        var id = await Seed(category, reviewState: FeedbackReviewState.New);

        var result = await _service.SetItemState(id, state);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSuccess, Is.True);
            Assert.That(await StateOf(id), Is.EqualTo(state));
            Assert.That(await _service.GetQueue(), Is.Empty);
            Assert.That(await Ids(new FeedbackAdminFilter { ReviewState = state }), Is.EqualTo([id]));
        }
    }

    [Test]
    public async Task SetItemState_UndefinedState_IsRejected()
    {
        var id = await SeedBug();

        var result = await _service.SetItemState(id, (FeedbackReviewState)99);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.Reason.Code, Is.EqualTo(FeedbackErrorCodes.StateInvalid));
            Assert.That(await StateOf(id), Is.EqualTo(FeedbackReviewState.New));
        }
    }

    [Test]
    public async Task SetClusterState_AppliesToNewItemsOnly_AndReportsHowManyChanged()
    {
        var newOne = await SeedBug();
        var newTwo = await SeedBug();
        var reviewed = await SeedBug(state: FeedbackReviewState.Reviewed);
        var actioned = await SeedBug(state: FeedbackReviewState.Actioned);

        var result = await _service.SetClusterState(ProfileBugs, FeedbackReviewState.Archived, expectedNewCount: 2);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSuccess, Is.True);
            Assert.That(result.Value, Is.EqualTo(2));
            Assert.That(await StateOf(newOne), Is.EqualTo(FeedbackReviewState.Archived));
            Assert.That(await StateOf(newTwo), Is.EqualTo(FeedbackReviewState.Archived));
            Assert.That(await StateOf(reviewed), Is.EqualTo(FeedbackReviewState.Reviewed));
            Assert.That(await StateOf(actioned), Is.EqualTo(FeedbackReviewState.Actioned));
            Assert.That(await _service.GetQueue(), Is.Empty);
        }
    }

    [Test]
    public async Task SetClusterState_LeavesOtherClustersAlone()
    {
        await SeedBug();
        var otherPage = await SeedBug("/dashboard/leaderboard");
        var idea = await SeedIdea("/dashboard/profile");

        await _service.SetClusterState(ProfileBugs, FeedbackReviewState.Reviewed, expectedNewCount: 1);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(await StateOf(otherPage), Is.EqualTo(FeedbackReviewState.New));
            Assert.That(await StateOf(idea), Is.EqualTo(FeedbackReviewState.New));
        }
    }

    [Test]
    public async Task SetClusterState_ForAClusterWithNoItems_ReturnsNotFound()
    {
        var result = await _service.SetClusterState(ProfileBugs, FeedbackReviewState.Reviewed, expectedNewCount: 1);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailure, Is.True);
            Assert.That(result.Reason.Code, Is.EqualTo(FeedbackErrorCodes.NotFound));
        }
    }

    [Test]
    public async Task SetClusterState_ForAComplimentCluster_AppliesToItsNewItemsOnly()
    {
        var key = new FeedbackClusterKey(FeedbackCategory.Compliment, "/dashboard/profile");
        var newOne = await Seed(FeedbackCategory.Compliment, reviewState: FeedbackReviewState.New, originUrl: "/dashboard/profile");
        var handled = await Seed(FeedbackCategory.Compliment, reviewState: FeedbackReviewState.Archived, originUrl: "/dashboard/profile");
        var otherPage = await Seed(FeedbackCategory.Compliment, reviewState: FeedbackReviewState.New, originUrl: "/dashboard/leaderboard");
        var help = await Seed(FeedbackCategory.Help, reviewState: FeedbackReviewState.New, originUrl: "/dashboard/profile");

        var result = await _service.SetClusterState(key, FeedbackReviewState.Reviewed, expectedNewCount: 1);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.Value, Is.EqualTo(1));
            Assert.That(await StateOf(newOne), Is.EqualTo(FeedbackReviewState.Reviewed));
            Assert.That(await StateOf(handled), Is.EqualTo(FeedbackReviewState.Archived));
            Assert.That(await StateOf(otherPage), Is.EqualTo(FeedbackReviewState.New));
            Assert.That(await StateOf(help), Is.EqualTo(FeedbackReviewState.New));
        }
    }

    [Test]
    public async Task DeleteCluster_HardDeletesEveryItemInItIncludingHandledOnes_AndReturnsTheCount()
    {
        await SeedBug();
        await SeedBug(state: FeedbackReviewState.Reviewed);
        await SeedBug(state: FeedbackReviewState.Archived);
        var otherPage = await SeedBug("/dashboard/leaderboard");
        var idea = await SeedIdea("/dashboard/profile");
        var compliment = await Seed(FeedbackCategory.Compliment, reviewState: FeedbackReviewState.New, originUrl: "/dashboard/profile");

        var result = await _service.DeleteCluster(ProfileBugs, expectedCount: 3);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSuccess, Is.True);
            Assert.That(result.Value, Is.EqualTo(3));
            Assert.That(await Ids(new FeedbackAdminFilter()), Is.EquivalentTo([otherPage, idea, compliment]));
        }
    }

    [Test]
    public async Task DeleteCluster_ALaterMatchingReportStartsAFreshCluster()
    {
        await SeedBug(createdAt: Now.AddDays(-5));
        await SeedBug(createdAt: Now.AddDays(-4));
        await _service.DeleteCluster(ProfileBugs, expectedCount: 2);

        await SeedBug(createdAt: Now);
        var cluster = (await _service.GetQueue()).Single();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(cluster.Count, Is.EqualTo(1));
            Assert.That(cluster.FirstSeen, Is.EqualTo(Now));
        }
    }

    [Test]
    public async Task DeleteCluster_ForAClusterWithNoItems_ReturnsNotFoundAndChangesNothing()
    {
        await SeedBug("/dashboard/leaderboard");

        var result = await _service.DeleteCluster(ProfileBugs, expectedCount: 1);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.Reason.Code, Is.EqualTo(FeedbackErrorCodes.NotFound));
            Assert.That(await TotalItems(), Is.EqualTo(1));
        }
    }

    [Test]
    public async Task DeleteCluster_ForAHelpCluster_DeletesOnlyThatClustersItems()
    {
        await Seed(FeedbackCategory.Help, reviewState: FeedbackReviewState.New, originUrl: "/dashboard/profile");
        await Seed(FeedbackCategory.Help, reviewState: FeedbackReviewState.Reviewed, originUrl: "/dashboard/profile");
        var otherPage = await Seed(FeedbackCategory.Help, reviewState: FeedbackReviewState.New, originUrl: "/dashboard/leaderboard");
        var compliment = await Seed(FeedbackCategory.Compliment, reviewState: FeedbackReviewState.New, originUrl: "/dashboard/profile");

        var result = await _service.DeleteCluster(new FeedbackClusterKey(FeedbackCategory.Help, "/dashboard/profile"), expectedCount: 2);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.Value, Is.EqualTo(2));
            Assert.That(await Ids(new FeedbackAdminFilter()), Is.EquivalentTo([otherPage, compliment]));
        }
    }

    [Test]
    public async Task GetCluster_ReturnsTheClusterInfoIncludingHandledItems()
    {
        await SeedBug(createdAt: Now.AddDays(-2));
        await SeedBug(createdAt: Now, state: FeedbackReviewState.Reviewed);

        var cluster = await _service.GetCluster(ProfileBugs);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(cluster, Is.Not.Null);
            Assert.That(cluster!.Count, Is.EqualTo(2));
            Assert.That(cluster.NewCount, Is.EqualTo(1));
            Assert.That(cluster.FirstSeen, Is.EqualTo(Now.AddDays(-2)));
            Assert.That(cluster.LastSeen, Is.EqualTo(Now));
        }
    }

    [Test]
    public async Task GetCluster_ForAFullyHandledCluster_StillReturnsIt()
    {
        await SeedBug(state: FeedbackReviewState.Archived);

        var cluster = await _service.GetCluster(ProfileBugs);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(cluster, Is.Not.Null);
            Assert.That(cluster!.NewCount, Is.EqualTo(0));
            Assert.That(cluster.SampleBody, Is.EqualTo("Bug body"));
        }
    }

    [Test]
    public async Task GetCluster_Unknown_ReturnsNull()
    {
        Assert.That(await _service.GetCluster(ProfileBugs), Is.Null);
    }

    [Test]
    public async Task GetItems_FiltersByCluster_IncludingHandledItems()
    {
        var newOne = await SeedBug();
        var handled = await SeedBug(state: FeedbackReviewState.Reviewed);
        await SeedBug("/dashboard/leaderboard");
        await SeedIdea("/dashboard/profile");

        var ids = await Ids(new FeedbackAdminFilter { Cluster = ProfileBugs });

        Assert.That(ids, Is.EquivalentTo([newOne, handled]));
    }

    [Test]
    public async Task GetItems_FiltersByAnIdeaCluster_UsingTheOriginPath()
    {
        var idea = await SeedIdea("/dashboard/profile");
        await SeedIdea("/dashboard/leaderboard");
        await SeedBug("/dashboard/profile");

        var ids = await Ids(new FeedbackAdminFilter { Cluster = new FeedbackClusterKey(FeedbackCategory.Idea, "/dashboard/profile") });

        Assert.That(ids, Is.EqualTo([idea]));
    }

    [Test]
    public async Task GetItem_ForAClusteredItem_ExposesItsClusterKey()
    {
        var id = await SeedBug();

        var result = await _service.GetItem(id);

        Assert.That(result.Value.ClusterKey, Is.EqualTo(ProfileBugs));
    }

    [Test]
    public async Task GetItems_FiltersByCluster_UsesTheReportedPageForBugsAndNeverTheirOriginUrl()
    {
        var bug = await SeedBug("/dashboard/profile", originUrl: "/dashboard/leaderboard");
        await SeedBug("/dashboard/leaderboard", originUrl: "/dashboard/profile");

        var onReportedPage = await Ids(new FeedbackAdminFilter { Cluster = ProfileBugs });
        var onOriginOnly = await Ids(new FeedbackAdminFilter { Cluster = new FeedbackClusterKey(FeedbackCategory.Bug, "/dashboard/leaderboard") });

        using (Assert.EnterMultipleScope())
        {
            Assert.That(onReportedPage, Is.EqualTo([bug]));
            Assert.That(onOriginOnly, Has.Count.EqualTo(1));
            Assert.That(onOriginOnly, Does.Not.Contain(bug));
        }
    }

    [Test]
    public async Task SearchClusterKeys_WithoutATerm_ReturnsEachClusterOnce_IncludingFullyHandledOnes()
    {
        await SeedBug(createdAt: Now.AddDays(-2));
        await SeedBug(createdAt: Now);
        await SeedBug("/dashboard/leaderboard", state: FeedbackReviewState.Archived);
        await SeedIdea("/dashboard/profile");
        await Seed(FeedbackCategory.Compliment, reviewState: FeedbackReviewState.Reviewed, originUrl: "/dashboard/profile");

        var keys = await _service.SearchClusterKeys(null);

        Assert.That(keys, Is.EquivalentTo(new[]
        {
            ProfileBugs,
            new FeedbackClusterKey(FeedbackCategory.Bug, "/dashboard/leaderboard"),
            new FeedbackClusterKey(FeedbackCategory.Idea, "/dashboard/profile"),
            new FeedbackClusterKey(FeedbackCategory.Compliment, "/dashboard/profile")
        }));
    }

    [Test]
    public async Task SearchClusterKeys_MatchesOnPageOrTypeLabel_IgnoringCase()
    {
        await SeedBug("/dashboard/profile");
        await SeedBug("/dashboard/leaderboard");
        await SeedIdea("/dashboard/leaderboard");

        var byPage = await _service.SearchClusterKeys("LEADERBOARD");
        var byType = await _service.SearchClusterKeys(FeedbackLabelHelper.CategoryLabel(FeedbackCategory.Idea));

        using (Assert.EnterMultipleScope())
        {
            Assert.That(byPage, Is.EquivalentTo(new[]
            {
                new FeedbackClusterKey(FeedbackCategory.Bug, "/dashboard/leaderboard"),
                new FeedbackClusterKey(FeedbackCategory.Idea, "/dashboard/leaderboard")
            }));
            Assert.That(byType, Is.EqualTo([new FeedbackClusterKey(FeedbackCategory.Idea, "/dashboard/leaderboard")]));
        }
    }

    [Test]
    public async Task SearchClusterKeys_ReturnsAtMostTheRequestedNumberOfKeys()
    {
        await SeedBug("/a");
        await SeedBug("/b");
        await SeedBug("/c");

        var keys = await _service.SearchClusterKeys(null, take: 2);

        Assert.That(keys, Has.Count.EqualTo(2));
    }

    [Test]
    public async Task SearchClusterKeys_WithNoFeedback_ReturnsNothing()
    {
        Assert.That(await _service.SearchClusterKeys(null), Is.Empty);
    }

    [Test]
    public async Task GetCluster_CountsOnlyTheRequestedCluster()
    {
        await SeedBug(createdAt: Now.AddDays(-3));
        await SeedBug("/dashboard/leaderboard", createdAt: Now.AddDays(-9));
        await SeedIdea("/dashboard/profile", createdAt: Now.AddDays(-8));

        var cluster = await _service.GetCluster(ProfileBugs);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(cluster!.Count, Is.EqualTo(1));
            Assert.That(cluster.FirstSeen, Is.EqualTo(Now.AddDays(-3)));
            Assert.That(cluster.LastSeen, Is.EqualTo(Now.AddDays(-3)));
        }
    }

    [Test]
    public async Task SetClusterState_WhenTheNewCountIsNotWhatTheAdminConfirmed_ReturnsConflictAndChangesNothing()
    {
        var first = await SeedBug();
        var second = await SeedBug();

        var result = await _service.SetClusterState(ProfileBugs, FeedbackReviewState.Reviewed, expectedNewCount: 1);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailure, Is.True);
            Assert.That(result.Reason.Code, Is.EqualTo(FeedbackErrorCodes.Conflict));
            Assert.That(await StateOf(first), Is.EqualTo(FeedbackReviewState.New));
            Assert.That(await StateOf(second), Is.EqualTo(FeedbackReviewState.New));
        }
    }

    [Test]
    public async Task SetClusterState_WhenEveryNewItemWasHandledMeanwhile_ReturnsConflict()
    {
        await SeedBug(state: FeedbackReviewState.Reviewed);

        var result = await _service.SetClusterState(ProfileBugs, FeedbackReviewState.Archived, expectedNewCount: 2);

        Assert.That(result.Reason.Code, Is.EqualTo(FeedbackErrorCodes.Conflict));
    }

    [Test]
    public async Task DeleteCluster_WhenTheCountIsNotWhatTheAdminConfirmed_ReturnsConflictAndDeletesNothing()
    {
        await SeedBug();
        await SeedBug(state: FeedbackReviewState.Reviewed);
        await SeedBug();

        var result = await _service.DeleteCluster(ProfileBugs, expectedCount: 2);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailure, Is.True);
            Assert.That(result.Reason.Code, Is.EqualTo(FeedbackErrorCodes.Conflict));
            Assert.That(await TotalItems(), Is.EqualTo(3));
        }
    }

    private async Task SeedSurveyResponse(int surveyId, DateTimeOffset submittedAt, string userId = "user1")
    {
        using var context = DbContextFactory.CreateDbContext();
        context.SurveyResponses.Add(new SurveyResponse { SurveyId = surveyId, AppUserId = userId, SubmittedAt = submittedAt });
        await context.SaveChangesAsync();
    }

    private async Task<int> SeedSurvey(SurveyStatus status)
    {
        using var context = DbContextFactory.CreateDbContext();
        var survey = new Survey { Title = "Seeded", Description = "Seeded survey", Status = status, CreatedAt = DateTimeOffset.UtcNow };
        context.Surveys.Add(survey);
        await context.SaveChangesAsync();
        return survey.Id;
    }

    [Test]
    public async Task GetOverview_CountsOnlyResponsesFromTheLastSevenDays()
    {
        var survey = await SeedSurvey(SurveyStatus.Active);
        await SeedSurveyResponse(survey, DateTimeOffset.UtcNow.AddDays(-6).AddHours(-23), "user1");
        await SeedSurveyResponse(survey, DateTimeOffset.UtcNow.AddHours(-1), "user2");
        await SeedSurveyResponse(survey, DateTimeOffset.UtcNow.AddDays(-7).AddHours(-1), "user3");
        await SeedSurveyResponse(survey, DateTimeOffset.UtcNow.AddDays(-30), "user4");

        var overview = await _service.GetOverview();

        Assert.That(overview.ResponsesLastSevenDays, Is.EqualTo(2));
    }

    [Test]
    public async Task GetOverview_CountsOnlyActiveSurveys()
    {
        await SeedSurvey(SurveyStatus.Active);
        await SeedSurvey(SurveyStatus.Active);
        await SeedSurvey(SurveyStatus.Draft);
        await SeedSurvey(SurveyStatus.Inactive);

        var overview = await _service.GetOverview();

        Assert.That(overview.ActiveSurveys, Is.EqualTo(2));
    }

    [Test]
    public async Task GetOverview_ReviewQueueSizeCountsNewItemsOfEveryCategory()
    {
        await Seed(FeedbackCategory.Bug, reviewState: FeedbackReviewState.New, reportedPage: "/a", area: FeedbackArea.Other);
        await Seed(FeedbackCategory.Idea, reviewState: FeedbackReviewState.New);
        await Seed(FeedbackCategory.Help, reviewState: FeedbackReviewState.New);
        await Seed(FeedbackCategory.Compliment, reviewState: FeedbackReviewState.New);
        await Seed(FeedbackCategory.Idea, reviewState: FeedbackReviewState.Reviewed);
        await Seed(FeedbackCategory.Idea, reviewState: FeedbackReviewState.Actioned);
        await Seed(FeedbackCategory.Idea, reviewState: FeedbackReviewState.Archived);

        var overview = await _service.GetOverview();

        Assert.That(overview.ReviewQueueSize, Is.EqualTo(4));
    }

    [Test]
    public async Task GetOverview_RecentItemsAreTheFiveNewestRegardlessOfState()
    {
        var ids = new List<int>();
        for (var i = 0; i < 7; i++)
        {
            var state = i % 2 == 0 ? FeedbackReviewState.New : FeedbackReviewState.Archived;
            ids.Add(await Seed(createdAt: Now.AddHours(-i), reviewState: state));
        }

        var overview = await _service.GetOverview();

        Assert.That(overview.RecentItems.Select(i => i.Id), Is.EqualTo(ids.Take(5)));
    }

    [Test]
    public async Task GetOverview_TopClustersAreTheThreeLargestByCount()
    {
        for (var i = 0; i < 4; i++) await SeedIdea("/four");
        for (var i = 0; i < 3; i++) await SeedIdea("/three");
        for (var i = 0; i < 2; i++) await SeedIdea("/two");
        await SeedIdea("/one");

        var overview = await _service.GetOverview();

        Assert.That(overview.TopClusters.Select(c => (c.Page, c.Count)),
            Is.EqualTo(new[] { ("/four", 4), ("/three", 3), ("/two", 2) }));
    }

    [Test]
    public async Task GetOverview_TopClustersUseTheSameDefinitionAsTheQueue()
    {
        for (var i = 0; i < 2; i++) await SeedBug("/dashboard/profile", originUrl: "/dashboard");
        await SeedBug("/dashboard/profile", originUrl: "/projects");
        await SeedIdea("/dashboard/profile");

        var overview = await _service.GetOverview();
        var queue = await _service.GetQueue();

        Assert.That(overview.TopClusters.Select(c => (c.Key, c.Count, c.NewCount)),
            Is.EquivalentTo(queue.Select(c => (c.Key, c.Count, c.NewCount))));
    }

    [Test]
    public async Task GetOverview_WithNoData_ReturnsZerosAndEmptyLists()
    {
        var overview = await _service.GetOverview();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(overview.ResponsesLastSevenDays, Is.Zero);
            Assert.That(overview.ActiveSurveys, Is.Zero);
            Assert.That(overview.ReviewQueueSize, Is.Zero);
            Assert.That(overview.RecentItems, Is.Empty);
            Assert.That(overview.TopClusters, Is.Empty);
        }
    }

    [Test]
    public async Task GetOverview_IsNotCached_ReflectsChangesOnTheNextCall()
    {
        await SeedIdea();
        Assert.That((await _service.GetOverview()).ReviewQueueSize, Is.EqualTo(1));

        await SeedIdea("/other");

        Assert.That((await _service.GetOverview()).ReviewQueueSize, Is.EqualTo(2));
    }
}
