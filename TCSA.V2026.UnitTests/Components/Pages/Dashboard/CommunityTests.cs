using Bunit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using MudBlazor;
using MudBlazor.Services;
using System.Security.Claims;
using TCSA.V2026.Components.Pages.Dashboard;
using TCSA.V2026.Components.UI;
using TCSA.V2026.Data.Helpers;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Data.Models.Responses;
using TCSA.V2026.Services;

namespace TCSA.V2026.UnitTests.Components.Pages.Dashboard;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class CommunityTests : BunitContext
{
    private readonly Mock<IProjectService> _projectServiceMock = new();
    private readonly Mock<IUserService> _userServiceMock = new();
    private readonly Mock<ICommunityService> _communityServiceMock = new();
    private readonly Mock<IDialogService> _dialogServiceMock = new();

    private const string TestUserId = "test-user-id";

    private readonly ApplicationUser _userWithNoProjects = new()
    {
        Id = TestUserId,
        DashboardProjects = []
    };

    private readonly ApplicationUser _userWithAssignedIssue = new()
    {
        Id = TestUserId,
        DashboardProjects = [new DashboardProject { ProjectId = 207, IsPendingReview = false }]
    };

    private readonly CommunityIssue _testIssue = new()
    {
        Id = 1,
        ProjectId = 207,
        CommunityProjectId = 207,
        Title = "Fix a bug",
        GithubUrl = "https://github.com/test/issue"
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

        var snackbarMock = new Mock<ISnackbar>();

        Services.AddSingleton(_projectServiceMock.Object);
        Services.AddSingleton(_userServiceMock.Object);
        Services.AddSingleton(_communityServiceMock.Object);
        Services.AddSingleton(_dialogServiceMock.Object);
        Services.AddMudServices();
    }

    private void AuthorizeAs(string userId)
    {
        var authContext = AddAuthorization();
        authContext.SetAuthorized("TEST USER");
        authContext.SetClaims(new Claim(ClaimTypes.NameIdentifier, userId));
    }

    [Test]
    public async Task PickButton_WhenClickedTwiceWhileProcessing_CallsAssignUserToIssueOnce()
    {
        // Arrange
        var tcs = new TaskCompletionSource<BaseResponse>();

        AuthorizeAs(TestUserId);
        Render<MudPopoverProvider>();

        _userServiceMock
            .Setup(s => s.GetUserById(TestUserId))
            .ReturnsAsync(_userWithNoProjects);

        _communityServiceMock
            .Setup(s => s.GetAvailableIssuesForCommunityPage(TestUserId))
            .ReturnsAsync([_testIssue]);

        _communityServiceMock
            .Setup(s => s.AssignUserToIssue(TestUserId, _testIssue))
            .Returns(tcs.Task);

        var cut = Render<Community>();

        cut.FindAll("button").Single(b => b.TextContent.Contains("Pick")).Click();
        cut.FindAll("button").Single(b => b.TextContent.Contains("Pick")).Click();

        tcs.SetResult(new BaseResponse { Status = ResponseStatus.Success });
        await cut.InvokeAsync(() => { });

        // Assert
        _communityServiceMock.Verify(
            s => s.AssignUserToIssue(TestUserId, It.IsAny<CommunityIssue>()),
            Times.Once);
    }

    [Test]
    public async Task CreateIssueButton_WhenClickedTwiceWhileProcessing_CallsDialogServiceOnce()
    {
        // Arrange
        var tcs = new TaskCompletionSource<IDialogReference>();
        _dialogServiceMock
            .Setup(s => s.ShowAsync<TCSASubmitIssueDialog>(
                It.IsAny<string>(),
                It.IsAny<DialogParameters<TCSASubmitIssueDialog>>(),
                It.IsAny<DialogOptions>()))
            .Returns(tcs.Task);

        AuthorizeAs(TestUserId);
        Render<MudPopoverProvider>();

        _userServiceMock
            .Setup(s => s.GetUserById(TestUserId))
            .ReturnsAsync(_userWithNoProjects);

        _communityServiceMock
            .Setup(s => s.GetAvailableIssuesForCommunityPage(TestUserId))
            .ReturnsAsync([_testIssue]);

        var cut = Render<Community>();

        // Act
        cut.FindAll("button").Single(b => b.TextContent.Contains("Create Issue")).Click();
        cut.FindAll("button").Single(b => b.TextContent.Contains("Create Issue")).Click();

        tcs.SetResult(Mock.Of<IDialogReference>(r => r.Result == Task.FromResult(DialogResult.Cancel())));
        await cut.InvokeAsync(() => { });

        // Assert
        _dialogServiceMock.Verify(
            s => s.ShowAsync<TCSASubmitIssueDialog>(
                It.IsAny<string>(),
                It.IsAny<DialogParameters<TCSASubmitIssueDialog>>(),
                It.IsAny<DialogOptions>()),
            Times.Once);
    }

    [Test]
    public void CreateIssueButton_WhileProcessing_IsDisabled()
    {
        // Arrange
        var tcs = new TaskCompletionSource<IDialogReference>();
        var dialogServiceMock = new Mock<IDialogService>();
        dialogServiceMock
            .Setup(s => s.ShowAsync<TCSASubmitIssueDialog>(
                It.IsAny<string>(),
                It.IsAny<DialogParameters<TCSASubmitIssueDialog>>(),
                It.IsAny<DialogOptions>()))
            .Returns(tcs.Task);

        Services.AddSingleton(dialogServiceMock.Object);

        AuthorizeAs(TestUserId);
        Render<MudPopoverProvider>();

        _userServiceMock
            .Setup(s => s.GetUserById(TestUserId))
            .ReturnsAsync(_userWithNoProjects);

        _communityServiceMock
            .Setup(s => s.GetAvailableIssuesForCommunityPage(TestUserId))
            .ReturnsAsync([_testIssue]);

        var cut = Render<Community>();

        // Act
        cut.FindAll("button").Single(b => b.TextContent.Contains("Create Issue")).Click();

        // Assert
        var createButton = cut.FindAll("button").Single(b => b.TextContent.Contains("Create Issue"));
        Assert.That(createButton.HasAttribute("disabled"), Is.True);
    }

    [Test]
    public async Task SubmitPrButton_WhenClickedTwiceWhileProcessing_CallsDialogServiceOnce()
    {
        // Arrange
        var tcs = new TaskCompletionSource<IDialogReference>();
        var dialogServiceMock = new Mock<IDialogService>();
        dialogServiceMock
            .Setup(s => s.ShowAsync<TCSASubmitProjectDialog>(
                It.IsAny<string>(),
                It.IsAny<DialogParameters<TCSASubmitProjectDialog>>(),
                It.IsAny<DialogOptions>()))
            .Returns(tcs.Task);

        Services.AddSingleton(dialogServiceMock.Object);

        AuthorizeAs(TestUserId);
        Render<MudPopoverProvider>();

        _userServiceMock
            .Setup(s => s.GetUserById(TestUserId))
            .ReturnsAsync(_userWithAssignedIssue);

        _communityServiceMock
            .Setup(s => s.GetAvailableIssuesForCommunityPage(TestUserId))
            .ReturnsAsync([_testIssue]);

        var cut = Render<Community>();

        // Act
        cut.FindAll("button").Single(b => b.TextContent.Contains("Submit PR")).Click();
        cut.FindAll("button").Single(b => b.TextContent.Contains("Submit PR")).Click();

        tcs.SetResult(Mock.Of<IDialogReference>(r => r.Result == Task.FromResult(DialogResult.Cancel())));
        await cut.InvokeAsync(() => { });

        // Assert
        dialogServiceMock.Verify(
            s => s.ShowAsync<TCSASubmitProjectDialog>(
                It.IsAny<string>(),
                It.IsAny<DialogParameters<TCSASubmitProjectDialog>>(),
                It.IsAny<DialogOptions>()),
            Times.Once);
    }

    [Test]
    public void SubmitPrButton_WhileProcessing_IsDisabled()
    {
        // Arrange
        var tcs = new TaskCompletionSource<IDialogReference>();
        var dialogServiceMock = new Mock<IDialogService>();
        dialogServiceMock
            .Setup(s => s.ShowAsync<TCSASubmitProjectDialog>(
                It.IsAny<string>(),
                It.IsAny<DialogParameters<TCSASubmitProjectDialog>>(),
                It.IsAny<DialogOptions>()))
            .Returns(tcs.Task);

        Services.AddSingleton(dialogServiceMock.Object);

        AuthorizeAs(TestUserId);
        Render<MudPopoverProvider>();

        _userServiceMock
            .Setup(s => s.GetUserById(TestUserId))
            .ReturnsAsync(_userWithAssignedIssue);

        _communityServiceMock
            .Setup(s => s.GetAvailableIssuesForCommunityPage(TestUserId))
            .ReturnsAsync([_testIssue]);

        var cut = Render<Community>();

        // Act
        cut.FindAll("button").Single(b => b.TextContent.Contains("Submit PR")).Click();

        // Assert
        var submitButton = cut.FindAll("button").Single(b => b.TextContent.Contains("Submit PR"));
        Assert.That(submitButton.HasAttribute("disabled"), Is.True);
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
            .ReturnsAsync(_userWithNoProjects);

        _communityServiceMock
            .Setup(s => s.GetAvailableIssuesForCommunityPage(TestUserId))
            .ReturnsAsync([_testIssue]);

        _communityServiceMock
            .Setup(s => s.AssignUserToIssue(TestUserId, It.IsAny<CommunityIssue>()))
            .Returns(tcs.Task);

        var cut = Render<Community>();

        // Act
        cut.FindAll("button").Single(b => b.TextContent.Contains("Pick")).Click();

        var pickButton = cut.FindAll("button").Single(b => b.TextContent.Contains("Pick"));
        Assert.That(pickButton.HasAttribute("disabled"), Is.True);

        tcs.SetResult(new BaseResponse { Status = ResponseStatus.Success });
    }
}
