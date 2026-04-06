using Bunit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using MudBlazor;
using MudBlazor.Services;
using System.Security.Claims;
using TCSA.V2026.Components.Pages.Dashboard;
using TCSA.V2026.Data.DTOs;
using TCSA.V2026.Data.Enums;
using TCSA.V2026.Data.Helpers;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Data.Models.Responses;
using TCSA.V2026.Services;

namespace TCSA.V2026.UnitTests.Components.Pages.Dashboard;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class PeerReviewsTests : BunitContext
{
    private readonly Mock<IProjectService> _projectServiceMock = new();
    private readonly Mock<IUserService> _userServiceMock = new();
    private readonly Mock<IPeerReviewService> _peerReviewServiceMock = new();

    private const string TestUserId = "test-user-id";
    private const int TestDashboardProjectId = 42;

    private readonly ApplicationUser _yellowBeltUser = new()
    {
        Id = TestUserId,
        Level = Level.Yellow
    };

    private readonly PeerReviewDisplay _unassignedProject = new()
    {
        DashboardProjectId = TestDashboardProjectId,
        ProjectId = 1,
        IsAssigned = false,
        Title = "Test Project",
        Name = "Student Name",
        IconUrl = "test.png",
        GithubUrl = "https://github.com/test/pr",
        ProjectSlug = "test-project"
    };

    private readonly PeerReviewDisplay _assignedProject = new()
    {
        DashboardProjectId = TestDashboardProjectId,
        ProjectId = 1,
        IsAssigned = true,
        Title = "Test Project",
        Name = "Student Name",
        IconUrl = "test.png",
        GithubUrl = "https://github.com/test/pr",
        ProjectSlug = "test-project"
    };

    [SetUp]
    public void SetUp()
    {
        JSInterop.Mode = JSRuntimeMode.Loose;

        var mockConfig = new Mock<IConfiguration>();
        mockConfig.Setup(c => c["LinkProvider:DiscordLink"]).Returns("https://discord.gg/test");

        ServiceProviderAccessor.ServiceProvider = new ServiceCollection()
            .AddSingleton(mockConfig.Object)
            .BuildServiceProvider();

        Services.AddSingleton(_projectServiceMock.Object);
        Services.AddSingleton(_userServiceMock.Object);
        Services.AddSingleton(_peerReviewServiceMock.Object);
        Services.AddMudServices();
    }

    private void AuthorizeAs(string userId)
    {
        var authContext = AddAuthorization();
        authContext.SetAuthorized("TEST USER");
        authContext.SetClaims(new Claim(ClaimTypes.NameIdentifier, userId));
    }

    [Test]
    public async Task PickButton_WhenClickedTwiceWhileProcessing_CallsAssignUserToCodeReviewOnce()
    {
        // Arrange
        var tcs = new TaskCompletionSource<BaseResponse>();

        AuthorizeAs(TestUserId);
        Render<MudPopoverProvider>();

        _userServiceMock
            .Setup(s => s.GetUserById(TestUserId))
            .ReturnsAsync(_yellowBeltUser);

        _peerReviewServiceMock
            .Setup(s => s.GetProjectsForPeerReview(TestUserId))
            .ReturnsAsync([_unassignedProject]);

        _peerReviewServiceMock
            .Setup(s => s.AssignUserToCodeReview(TestUserId, TestDashboardProjectId))
            .Returns(tcs.Task);

        var cut = Render<PeerReviews>();

        // Act
        cut.FindAll("button").Single(b => b.TextContent.Contains("Pick")).Click();
        cut.FindAll("button").Single(b => b.TextContent.Contains("Pick")).Click();

        tcs.SetResult(new BaseResponse { Status = ResponseStatus.Success });
        await cut.InvokeAsync(() => { });

        // Assert
        _peerReviewServiceMock.Verify(
            s => s.AssignUserToCodeReview(TestUserId, TestDashboardProjectId),
            Times.Once);
    }

    [Test]
    public void PickButton_WhileProcessing_IsDisabled()
    {
        // Arrange
        var tcs = new TaskCompletionSource<BaseResponse>();

        AuthorizeAs(TestUserId);
        Render<MudPopoverProvider>();

        _userServiceMock
            .Setup(s => s.GetUserById(TestUserId))
            .ReturnsAsync(_yellowBeltUser);

        _peerReviewServiceMock
            .Setup(s => s.GetProjectsForPeerReview(TestUserId))
            .ReturnsAsync([_unassignedProject]);

        _peerReviewServiceMock
            .Setup(s => s.AssignUserToCodeReview(TestUserId, TestDashboardProjectId))
            .Returns(tcs.Task);

        var cut = Render<PeerReviews>();

        // Act
        cut.FindAll("button").Single(b => b.TextContent.Contains("Pick")).Click();

        // Assert
        var pickButton = cut.FindAll("button").Single(b => b.TextContent.Contains("Pick"));
        Assert.That(pickButton.HasAttribute("disabled"), Is.True);
    }

    [Test]
    public async Task DropButton_WhenClickedTwiceWhileProcessing_CallsReleaseUserFromCodeReviewOnce()
    {
        // Arrange
        var tcs = new TaskCompletionSource<BaseResponse>();

        AuthorizeAs(TestUserId);
        Render<MudPopoverProvider>();

        _userServiceMock
            .Setup(s => s.GetUserById(TestUserId))
            .ReturnsAsync(_yellowBeltUser);

        _peerReviewServiceMock
            .Setup(s => s.GetProjectsForPeerReview(TestUserId))
            .ReturnsAsync([_assignedProject]);

        _peerReviewServiceMock
            .Setup(s => s.ReleaseUserFromCodeReview(TestUserId, TestDashboardProjectId))
            .Returns(tcs.Task);

        var cut = Render<PeerReviews>();

        // Act
        cut.FindAll("button").Single(b => b.TextContent.Contains("Drop")).Click();
        cut.FindAll("button").Single(b => b.TextContent.Contains("Drop")).Click();

        tcs.SetResult(new BaseResponse { Status = ResponseStatus.Success });
        await cut.InvokeAsync(() => { });

        // Assert
        _peerReviewServiceMock.Verify(
            s => s.ReleaseUserFromCodeReview(TestUserId, TestDashboardProjectId),
            Times.Once);
    }

    [Test]
    public void DropButton_WhileProcessing_IsDisabled()
    {
        // Arrange
        var tcs = new TaskCompletionSource<BaseResponse>();

        AuthorizeAs(TestUserId);
        Render<MudPopoverProvider>();

        _userServiceMock
            .Setup(s => s.GetUserById(TestUserId))
            .ReturnsAsync(_yellowBeltUser);

        _peerReviewServiceMock
            .Setup(s => s.GetProjectsForPeerReview(TestUserId))
            .ReturnsAsync([_assignedProject]);

        _peerReviewServiceMock
            .Setup(s => s.ReleaseUserFromCodeReview(TestUserId, TestDashboardProjectId))
            .Returns(tcs.Task);

        var cut = Render<PeerReviews>();

        // Act
        cut.FindAll("button").Single(b => b.TextContent.Contains("Drop")).Click();

        // Assert
        var dropButton = cut.FindAll("button").Single(b => b.TextContent.Contains("Drop"));
        Assert.That(dropButton.HasAttribute("disabled"), Is.True);
    }

    [Test]
    public async Task TickButton_WhenClickedTwiceWhileProcessing_CallsMarkCodeReviewAsCompletedOnce()
    {
        // Arrange
        var tcs = new TaskCompletionSource<BaseResponse>();

        AuthorizeAs(TestUserId);
        Render<MudPopoverProvider>();

        _userServiceMock
            .Setup(s => s.GetUserById(TestUserId))
            .ReturnsAsync(_yellowBeltUser);

        _peerReviewServiceMock
            .Setup(s => s.GetProjectsForPeerReview(TestUserId))
            .ReturnsAsync([_assignedProject]);

        _peerReviewServiceMock
            .Setup(s => s.MarkCodeReviewAsCompleted(TestUserId, TestDashboardProjectId))
            .Returns(tcs.Task);

        var cut = Render<PeerReviews>();

        // Act
        cut.FindAll("button").Single(b => b.TextContent.Contains("Tick")).Click();
        cut.FindAll("button").Single(b => b.TextContent.Contains("Tick")).Click();

        tcs.SetResult(new BaseResponse { Status = ResponseStatus.Success });
        await cut.InvokeAsync(() => { });

        // Assert
        _peerReviewServiceMock.Verify(
            s => s.MarkCodeReviewAsCompleted(TestUserId, TestDashboardProjectId),
            Times.Once);
    }

    [Test]
    public void TickButton_WhileProcessing_IsDisabled()
    {
        // Arrange
        var tcs = new TaskCompletionSource<BaseResponse>();

        AuthorizeAs(TestUserId);
        Render<MudPopoverProvider>();

        _userServiceMock
            .Setup(s => s.GetUserById(TestUserId))
            .ReturnsAsync(_yellowBeltUser);

        _peerReviewServiceMock
            .Setup(s => s.GetProjectsForPeerReview(TestUserId))
            .ReturnsAsync([_assignedProject]);

        _peerReviewServiceMock
            .Setup(s => s.MarkCodeReviewAsCompleted(TestUserId, TestDashboardProjectId))
            .Returns(tcs.Task);

        var cut = Render<PeerReviews>();

        // Act
        cut.FindAll("button").Single(b => b.TextContent.Contains("Tick")).Click();

        // Assert
        var tickButton = cut.FindAll("button").Single(b => b.TextContent.Contains("Tick"));
        Assert.That(tickButton.HasAttribute("disabled"), Is.True);
    }
}
