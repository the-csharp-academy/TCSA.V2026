using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using MudBlazor;
using MudBlazor.Services;
using TCSA.V2026.Components.Pages.Admin;
using TCSA.V2026.Data.DTOs;
using TCSA.V2026.Data.Enums;
using TCSA.V2026.Data.Models.Responses;
using TCSA.V2026.Services;

namespace TCSA.V2026.UnitTests.Components.Pages.Admin;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class FeedbackNeedsReviewTests : BunitContext
{
    private const string ScriptBody = "<script>alert('xss')</script><b>bold</b> & <img src=x onerror=alert(1)>";

    private readonly Mock<IFeedbackAdminService> _serviceMock = new();
    private IRenderedComponent<MudDialogProvider> _dialogs = null!;

    [SetUp]
    public void SetUp()
    {
        JSInterop.Mode = JSRuntimeMode.Loose;
        Services.AddMudServices();
        Services.AddSingleton(_serviceMock.Object);
        Services.AddSingleton(new FeedbackDetailState());
        Render<MudBlazor.MudPopoverProvider>();
        _dialogs = Render<MudDialogProvider>();
    }

    private static FeedbackClusterDto Cluster(string page, string sample) => new()
    {
        Category = FeedbackCategory.Bug,
        Page = page,
        Count = 4,
        NewCount = 3,
        FirstSeen = new DateTimeOffset(2026, 10, 1, 12, 0, 0, TimeSpan.Zero),
        LastSeen = new DateTimeOffset(2026, 10, 8, 12, 0, 0, TimeSpan.Zero),
        SampleBody = sample
    };

    [Test]
    public void EmptyQueue_ShowsTheQueueIsClear()
    {
        _serviceMock.Setup(s => s.GetQueue()).ReturnsAsync([]);

        var cut = Render<FeedbackNeedsReview>();

        cut.WaitForAssertion(() => Assert.That(cut.Markup, Does.Contain("The queue is clear")));
    }

    [Test]
    public void Cluster_ShowsPageSampleAndCounts()
    {
        _serviceMock.Setup(s => s.GetQueue()).ReturnsAsync([Cluster("/dashboard/profile", "Save button broken")]);

        var cut = Render<FeedbackNeedsReview>();

        cut.WaitForAssertion(() => Assert.That(cut.FindAll(".needs-review-cluster"), Has.Count.EqualTo(1)));
        using (Assert.EnterMultipleScope())
        {
            Assert.That(cut.Find(".needs-review-page").TextContent, Is.EqualTo("/dashboard/profile"));
            Assert.That(cut.Find(".needs-review-sample").TextContent.Trim(), Is.EqualTo("Save button broken"));
            Assert.That(cut.Markup, Does.Contain("3 new"));
            Assert.That(cut.Markup, Does.Contain("4 total"));
        }
    }

    [Test]
    public void Cluster_RendersUserTextContainingMarkupAsLiteralText()
    {
        _serviceMock.Setup(s => s.GetQueue()).ReturnsAsync([Cluster("<i>/dashboard</i>", ScriptBody)]);

        var cut = Render<FeedbackNeedsReview>();

        cut.WaitForAssertion(() => Assert.That(cut.FindAll(".needs-review-cluster"), Has.Count.EqualTo(1)));
        using (Assert.EnterMultipleScope())
        {
            Assert.That(cut.Find(".needs-review-page").Children, Is.Empty);
            Assert.That(cut.Find(".needs-review-sample").Children, Is.Empty);
            Assert.That(cut.Find(".needs-review-page").TextContent, Is.EqualTo("<i>/dashboard</i>"));
            Assert.That(cut.FindAll("script"), Is.Empty);
            Assert.That(cut.FindAll("img[onerror]"), Is.Empty);
        }
    }

    private static readonly FeedbackClusterKey ProfileBugs = new(FeedbackCategory.Bug, "/dashboard/profile");

    private IRenderedComponent<MudDialogProvider> Dialogs => _dialogs;

    private IRenderedComponent<FeedbackNeedsReview> RenderExpandedQueueWith(FeedbackClusterDto cluster)
    {
        _serviceMock.Setup(s => s.GetQueue()).ReturnsAsync([cluster]);
        _serviceMock.Setup(s => s.GetClusterItems(It.IsAny<FeedbackClusterKey>())).ReturnsAsync([]);

        var cut = Render<FeedbackNeedsReview>();
        cut.WaitForAssertion(() => Assert.That(cut.FindAll(".needs-review-cluster"), Has.Count.EqualTo(1)));
        cut.Find(".mud-expand-panel-header").Click();
        return cut;
    }

    private void ConfirmDialog(string confirmLabel)
    {
        Dialogs.WaitForAssertion(() => Assert.That(Dialogs.FindAll(".mud-dialog"), Has.Count.EqualTo(1)));
        Dialogs.Find($"button:contains('{confirmLabel}')").Click();
    }

    [Test]
    public void Queue_ThatFailsToLoad_StopsSpinningAndOffersARetry()
    {
        _serviceMock.Setup(s => s.GetQueue()).ThrowsAsync(new InvalidOperationException("db down"));

        var cut = Render<FeedbackNeedsReview>();

        cut.WaitForAssertion(() => Assert.That(cut.Markup, Does.Contain("Try again")));
        using (Assert.EnterMultipleScope())
        {
            Assert.That(cut.FindAll(".mud-progress-circular"), Is.Empty);
            Assert.That(cut.Markup, Does.Not.Contain("The queue is clear"));
        }
    }

    [Test]
    public void Retry_AfterAFailedLoad_ShowsTheQueue()
    {
        _serviceMock.SetupSequence(s => s.GetQueue())
            .ThrowsAsync(new InvalidOperationException("db down"))
            .ReturnsAsync([Cluster("/dashboard/profile", "Save button broken")]);

        var cut = Render<FeedbackNeedsReview>();
        cut.WaitForElement("button:contains('Try again')").Click();

        cut.WaitForAssertion(() =>
        {
            Assert.That(cut.FindAll(".needs-review-cluster"), Has.Count.EqualTo(1));
            Assert.That(cut.Markup, Does.Not.Contain("Try again"));
        });
    }

    [Test]
    public async Task Queue_ThatFailsToReloadAfterAnAction_KeepsTheLastQueueAndOffersARetry()
    {
        _serviceMock.SetupSequence(s => s.GetQueue())
            .ReturnsAsync([Cluster("/dashboard/profile", "Save button broken")])
            .ThrowsAsync(new InvalidOperationException("db down"));
        var cut = Render<FeedbackNeedsReview>();
        cut.WaitForAssertion(() => Assert.That(cut.FindAll(".needs-review-cluster"), Has.Count.EqualTo(1)));

        await cut.InvokeAsync(() => cut.Instance.Reload());

        using (Assert.EnterMultipleScope())
        {
            Assert.That(cut.FindAll(".needs-review-cluster"), Has.Count.EqualTo(1));
            Assert.That(cut.Markup, Does.Contain("Try again"));
        }
    }

    [Test]
    public void DeleteCluster_ConfirmationNamesTheCurrentCount_AndTheServiceIsToldTheSameCount()
    {
        var stale = Cluster("/dashboard/profile", "Save button broken");
        var current = Cluster("/dashboard/profile", "Save button broken");
        current.Count = 6;
        current.NewCount = 5;
        _serviceMock.Setup(s => s.GetCluster(ProfileBugs)).ReturnsAsync(current);
        _serviceMock.Setup(s => s.DeleteCluster(ProfileBugs, 6))
            .ReturnsAsync(Result.Success(6, new Success("Feedback.Deleted", "Deleted 6 feedback items.")));
        var cut = RenderExpandedQueueWith(stale);

        cut.WaitForElement("button:contains('Delete all 4')").Click();
        Dialogs.WaitForAssertion(() => Assert.That(Dialogs.Markup, Does.Contain("all 6 items")));
        ConfirmDialog("Delete 6");

        cut.WaitForAssertion(() => _serviceMock.Verify(s => s.DeleteCluster(ProfileBugs, 6), Times.Once));
    }

    [Test]
    public void SetClusterState_ConfirmationNamesTheCurrentNewCount_AndTheServiceIsToldTheSameCount()
    {
        var stale = Cluster("/dashboard/profile", "Save button broken");
        var current = Cluster("/dashboard/profile", "Save button broken");
        current.NewCount = 2;
        _serviceMock.Setup(s => s.GetCluster(ProfileBugs)).ReturnsAsync(current);
        _serviceMock.Setup(s => s.SetClusterState(ProfileBugs, FeedbackReviewState.Reviewed, 2))
            .ReturnsAsync(Result.Success(2, new Success("Feedback.Updated", "Marked 2 as Reviewed.")));
        var cut = RenderExpandedQueueWith(stale);

        cut.WaitForElement(".needs-review-actions-buttons button:contains('Reviewed')").Click();
        Dialogs.WaitForAssertion(() => Assert.That(Dialogs.Markup, Does.Contain("the 2 new items")));
        ConfirmDialog("Mark 2 as Reviewed");

        cut.WaitForAssertion(() => _serviceMock.Verify(s => s.SetClusterState(ProfileBugs, FeedbackReviewState.Reviewed, 2), Times.Once));
    }

    [Test]
    public void DeleteCluster_WhenTheClusterIsGone_NeverAsksForConfirmationOrDeletes_AndRefreshesTheQueue()
    {
        _serviceMock.Setup(s => s.GetCluster(ProfileBugs)).ReturnsAsync((FeedbackClusterDto?)null);
        var cut = RenderExpandedQueueWith(Cluster("/dashboard/profile", "Save button broken"));

        cut.WaitForElement("button:contains('Delete all 4')").Click();

        cut.WaitForAssertion(() => _serviceMock.Verify(s => s.GetQueue(), Times.AtLeast(2)));
        using (Assert.EnterMultipleScope())
        {
            Assert.That(Dialogs.FindAll(".mud-dialog"), Is.Empty);
            _serviceMock.Verify(s => s.DeleteCluster(It.IsAny<FeedbackClusterKey>(), It.IsAny<int>()), Times.Never);
        }
    }

    [Test]
    public void SetClusterState_WhenTheClusterHasNoNewItemsLeft_NeverAsksForConfirmation()
    {
        var handled = Cluster("/dashboard/profile", "Save button broken");
        handled.NewCount = 0;
        _serviceMock.Setup(s => s.GetCluster(ProfileBugs)).ReturnsAsync(handled);
        var cut = RenderExpandedQueueWith(Cluster("/dashboard/profile", "Save button broken"));

        cut.WaitForElement(".needs-review-actions-buttons button:contains('Archived')").Click();

        cut.WaitForAssertion(() => _serviceMock.Verify(s => s.GetQueue(), Times.AtLeast(2)));
        using (Assert.EnterMultipleScope())
        {
            Assert.That(Dialogs.FindAll(".mud-dialog"), Is.Empty);
            _serviceMock.Verify(s => s.SetClusterState(It.IsAny<FeedbackClusterKey>(), It.IsAny<FeedbackReviewState>(), It.IsAny<int>()), Times.Never);
        }
    }

    [Test]
    public void SetClusterState_WhenTheServiceReportsAConflict_ReloadsTheQueue()
    {
        var current = Cluster("/dashboard/profile", "Save button broken");
        _serviceMock.Setup(s => s.GetCluster(ProfileBugs)).ReturnsAsync(current);
        _serviceMock.Setup(s => s.SetClusterState(ProfileBugs, FeedbackReviewState.Archived, 3))
            .ReturnsAsync(Result.Failure<int>(new Error("Feedback.Conflict", "This feedback changed while you were looking at it.")));
        var cut = RenderExpandedQueueWith(current);

        cut.WaitForElement(".needs-review-actions-buttons button:contains('Archived')").Click();
        ConfirmDialog("Mark 3 as Archived");

        cut.WaitForAssertion(() => _serviceMock.Verify(s => s.GetQueue(), Times.AtLeast(2)));
    }
}
