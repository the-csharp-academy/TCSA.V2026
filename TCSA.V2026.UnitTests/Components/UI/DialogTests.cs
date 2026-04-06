using Bunit;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using MudBlazor;
using MudBlazor.Services;
using TCSA.V2026.Components.UI;
using TCSA.V2026.Data.DTOs;
using TCSA.V2026.Data.Helpers;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Data.Models.Responses;
using TCSA.V2026.Services;

namespace TCSA.V2026.UnitTests.Components.UI;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class DialogTests : BunitContext
{
    private readonly Mock<IProjectService> _projectServiceMock = new();
    private readonly Mock<ICommunityService> _communityServiceMock = new();
    private readonly Mock<IGalleryService> _galleryServiceMock = new();

    private const string TestUserId = "test-user-id";
    private const int TestProjectId = 1;

    private readonly ApplicationUser _testUser = new()
    {
        Id = TestUserId,
        DashboardProjects = [new DashboardProject
        {
            ProjectId = TestProjectId,
            GithubUrl = "https://github.com/TheCSharpAcademy/CodeReviews/pull/1"
        }]
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
        Services.AddSingleton(_communityServiceMock.Object);
        Services.AddSingleton(_galleryServiceMock.Object);
        Services.AddMudServices();
    }

    private async Task<IRenderedComponent<MudDialogProvider>> ShowDialog<TDialog>(
        DialogParameters<TDialog> parameters) where TDialog : ComponentBase
    {
        var providerCut = Render<MudDialogProvider>();
        var dialogService = Services.GetRequiredService<IDialogService>();

        await providerCut.InvokeAsync(() =>
            dialogService.ShowAsync<TDialog>(string.Empty, parameters));

        return providerCut;
    }

    [Test]
    public async Task SubmitIssueDialog_SubmitButton_WhenClickedTwiceWhileProcessing_CallsCreateIssueOnce()
    {
        // Arrange
        var tcs = new TaskCompletionSource<BaseResponse>();

        _communityServiceMock
            .Setup(s => s.CreateIssue(It.IsAny<IssueType>(), It.IsAny<string>(), It.IsAny<string>(), TestUserId))
            .Returns(tcs.Task);

        var parameters = new DialogParameters<TCSASubmitIssueDialog>();
        parameters.Add(x => x.UserId, TestUserId);
        var providerCut = await ShowDialog(parameters);

        // Act
        providerCut.FindAll("button").Single(b => b.TextContent.Contains("Submit")).Click();
        providerCut.FindAll("button").Single(b => b.TextContent.Contains("Submit")).Click();

        tcs.SetResult(new BaseResponse { Status = ResponseStatus.Success });
        await providerCut.InvokeAsync(() => { });

        // Assert
        _communityServiceMock.Verify(
            s => s.CreateIssue(It.IsAny<IssueType>(), It.IsAny<string>(), It.IsAny<string>(), TestUserId),
            Times.Once);
    }

    [Test]
    public async Task SubmitIssueDialog_SubmitButton_WhileProcessing_IsDisabled()
    {
        // Arrange
        var tcs = new TaskCompletionSource<BaseResponse>();

        _communityServiceMock
            .Setup(s => s.CreateIssue(It.IsAny<IssueType>(), It.IsAny<string>(), It.IsAny<string>(), TestUserId))
            .Returns(tcs.Task);

        var parameters = new DialogParameters<TCSASubmitIssueDialog>();
        parameters.Add(x => x.UserId, TestUserId);
        var providerCut = await ShowDialog(parameters);

        // Act
        providerCut.FindAll("button").Single(b => b.TextContent.Contains("Submit")).Click();

        // Assert
        var submitButton = providerCut.FindAll("button").Single(b => b.TextContent.Contains("Submit"));
        Assert.That(submitButton.HasAttribute("disabled"), Is.True);
    }

    [Test]
    public async Task SubmitProjectDialog_SubmitButton_WhenClickedTwiceWhileProcessing_CallsSubmitIssueToReviewOnce()
    {
        // Arrange
        var tcs = new TaskCompletionSource<BaseResponse>();

        _communityServiceMock
            .Setup(s => s.SubmitIssueToReview(TestProjectId, It.IsAny<string>()))
            .Returns(tcs.Task);

        var parameters = new DialogParameters<TCSASubmitProjectDialog>();
        parameters.Add(x => x.ProjectId, TestProjectId);
        parameters.Add(x => x.IsIssue, true);
        parameters.Add(x => x.User, _testUser);
        var providerCut = await ShowDialog(parameters);

        // Act
        providerCut.FindAll("button").Single(b => b.TextContent.Contains("Submit")).Click();
        providerCut.FindAll("button").Single(b => b.TextContent.Contains("Submit")).Click();

        tcs.SetResult(new BaseResponse { Status = ResponseStatus.Success });
        await providerCut.InvokeAsync(() => { });

        // Assert
        _communityServiceMock.Verify(
            s => s.SubmitIssueToReview(TestProjectId, It.IsAny<string>()),
            Times.Once);
    }

    [Test]
    public async Task SubmitProjectDialog_SubmitButton_WhileProcessing_IsDisabled()
    {
        // Arrange
        var tcs = new TaskCompletionSource<BaseResponse>();

        _communityServiceMock
            .Setup(s => s.SubmitIssueToReview(TestProjectId, It.IsAny<string>()))
            .Returns(tcs.Task);

        var parameters = new DialogParameters<TCSASubmitProjectDialog>();
        parameters.Add(x => x.ProjectId, TestProjectId);
        parameters.Add(x => x.IsIssue, true);
        parameters.Add(x => x.User, _testUser);
        var providerCut = await ShowDialog(parameters);

        // Act
        providerCut.FindAll("button").Single(b => b.TextContent.Contains("Submit")).Click();

        // Assert
        var submitButton = providerCut.FindAll("button").Single(b => b.TextContent.Contains("Submit"));
        Assert.That(submitButton.HasAttribute("disabled"), Is.True);
    }

    private async Task<IRenderedComponent<MudDialogProvider>> ShowShowcaseDialog()
    {
        var testProjects = new List<ShowcaseProjectInfo>
        {
            new() { Id = TestProjectId, Title = "Test Project" }
        };

        var parameters = new DialogParameters<TCSASubmitShowcaseProjectDialog>();
        parameters.Add(x => x.CurrentUser, _testUser);
        parameters.Add(x => x.Projects, testProjects);

        var providerCut = await ShowDialog(parameters);

        var mudSelect = providerCut.FindComponent<MudSelect<int>>();
        await providerCut.InvokeAsync(() => mudSelect.Instance.ValueChanged.InvokeAsync(TestProjectId));

        providerCut.FindAll("input").Last().Change("https://github.com/test/repo");

        return providerCut;
    }

    [Test]
    public async Task SubmitShowcaseProjectDialog_SubmitButton_WhenClickedTwiceWhileProcessing_CallsAddItemOnce()
    {
        // Arrange
        var tcs = new TaskCompletionSource<BaseResponse>();

        _galleryServiceMock
            .Setup(s => s.AddItem(It.IsAny<ShowcaseItemDTO>()))
            .Returns(tcs.Task);

        var providerCut = await ShowShowcaseDialog();

        // Act
        providerCut.FindAll("button").Single(b => b.TextContent.Contains("Submit")).Click();
        providerCut.FindAll("button").Single(b => b.TextContent.Contains("Submit")).Click();

        tcs.SetResult(new BaseResponse { Status = ResponseStatus.Success });
        await providerCut.InvokeAsync(() => { });

        // Assert
        _galleryServiceMock.Verify(s => s.AddItem(It.IsAny<ShowcaseItemDTO>()), Times.Once);
    }

    [Test]
    public async Task SubmitShowcaseProjectDialog_SubmitButton_WhileProcessing_IsDisabled()
    {
        // Arrange
        var tcs = new TaskCompletionSource<BaseResponse>();

        _galleryServiceMock
            .Setup(s => s.AddItem(It.IsAny<ShowcaseItemDTO>()))
            .Returns(tcs.Task);

        var providerCut = await ShowShowcaseDialog();

        // Act
        providerCut.FindAll("button").Single(b => b.TextContent.Contains("Submit")).Click();

        // Assert
        var submitButton = providerCut.FindAll("button").Single(b => b.TextContent.Contains("Submit"));
        Assert.That(submitButton.HasAttribute("disabled"), Is.True);
    }
}
