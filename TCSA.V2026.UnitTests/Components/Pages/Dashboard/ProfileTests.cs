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
public class ProfileTests : BunitContext
{
    private readonly Mock<IProjectService> _projectServiceMock = new();
    private readonly Mock<IUserService> _userServiceMock = new();

    private const string TestUserId = "test-user-id";

    private readonly ApplicationUser _testUser = new()
    {
        Id = TestUserId,
        DisplayName = "Test User",
        Country = "Ireland"
    };

    private readonly ApplicationUser _onboardingUser = new()
    {
        Id = TestUserId,
        DisplayName = "Test User",
        Country = "Ireland",
        OnboardingStartedDate = DateTimeOffset.UtcNow,
        HasDismissedChecklist = true,
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
        Services.AddSingleton(new HttpClient());
        Services.AddScoped<OnboardingStateService>();
        Services.AddMudServices();
    }

    private void AuthorizeAs(string userId)
    {
        var authContext = AddAuthorization();
        authContext.SetAuthorized("TEST USER");
        authContext.SetClaims(new Claim(ClaimTypes.NameIdentifier, userId));
    }

    private IRenderedComponent<Profile> RenderProfile()
    {
        _userServiceMock
            .Setup(s => s.GetUserProfileById(TestUserId))
            .ReturnsAsync(_testUser);

        return Render<Profile>();
    }

    private IRenderedComponent<Profile> RenderProfileWithOnboardingUser()
    {
        _userServiceMock
            .Setup(s => s.GetUserProfileById(TestUserId))
            .ReturnsAsync(_onboardingUser);

        return Render<Profile>();
    }

    [Test]
    public async Task SaveButton_WhenClickedTwiceWhileProcessing_CallsSaveProfileOnce()
    {
        // Arrange
        var tcs = new TaskCompletionSource<BaseResponse>();

        _userServiceMock
            .Setup(s => s.SaveProfile(It.IsAny<ApplicationUser>()))
            .Returns(tcs.Task);

        AuthorizeAs(TestUserId);
        Render<MudPopoverProvider>();
        var cut = RenderProfile();

        // Act
        cut.FindAll("button").Single(b => b.TextContent.Contains("Save")).Click();
        cut.FindAll("button").Single(b => b.TextContent.Contains("Save")).Click();

        tcs.SetResult(new BaseResponse { Status = ResponseStatus.Success });
        await cut.InvokeAsync(() => { });

        // Assert
        _userServiceMock.Verify(s => s.SaveProfile(It.IsAny<ApplicationUser>()), Times.Once);
    }

    [Test]
    public void SaveButton_WhileProcessing_IsDisabled()
    {
        // Arrange
        var tcs = new TaskCompletionSource<BaseResponse>();

        _userServiceMock
            .Setup(s => s.SaveProfile(It.IsAny<ApplicationUser>()))
            .Returns(tcs.Task);

        AuthorizeAs(TestUserId);
        Render<MudPopoverProvider>();
        var cut = RenderProfile();

        // Act
        cut.FindAll("button").Single(b => b.TextContent.Contains("Save")).Click();

        // Assert
        var saveButton = cut.FindAll("button").Single(b => b.TextContent.Contains("Save"));
        Assert.That(saveButton.HasAttribute("disabled"), Is.True);
    }

    [Test]
    public async Task ResetAccountButton_WhenClickedTwiceWhileProcessing_CallsDialogServiceOnce()
    {
        // Arrange
        var tcs = new TaskCompletionSource<IDialogReference>();
        var dialogServiceMock = new Mock<IDialogService>();
        dialogServiceMock
            .Setup(s => s.ShowAsync<TCSADialog>(It.IsAny<string>(), It.IsAny<DialogOptions>()))
            .Returns(tcs.Task);

        Services.AddSingleton(dialogServiceMock.Object);

        AuthorizeAs(TestUserId);
        Render<MudPopoverProvider>();
        var cut = RenderProfile();

        // Act
        cut.FindAll("button").Single(b => b.TextContent.Contains("Reset Account")).Click();
        cut.FindAll("button").Single(b => b.TextContent.Contains("Reset Account")).Click();

        tcs.SetResult(Mock.Of<IDialogReference>(r => r.Result == Task.FromResult(DialogResult.Cancel())));
        await cut.InvokeAsync(() => { });

        // Assert
        dialogServiceMock.Verify(
            s => s.ShowAsync<TCSADialog>(It.IsAny<string>(), It.IsAny<DialogOptions>()),
            Times.Once);
    }

    [Test]
    public void ResetAccountButton_WhileProcessing_IsDisabled()
    {
        // Arrange
        var tcs = new TaskCompletionSource<IDialogReference>();
        var dialogServiceMock = new Mock<IDialogService>();
        dialogServiceMock
            .Setup(s => s.ShowAsync<TCSADialog>(It.IsAny<string>(), It.IsAny<DialogOptions>()))
            .Returns(tcs.Task);

        Services.AddSingleton(dialogServiceMock.Object);

        AuthorizeAs(TestUserId);
        Render<MudPopoverProvider>();
        var cut = RenderProfile();

        // Act
        cut.FindAll("button").Single(b => b.TextContent.Contains("Reset Account")).Click();

        // Assert
        var resetButton = cut.FindAll("button").Single(b => b.TextContent.Contains("Reset Account"));
        Assert.That(resetButton.HasAttribute("disabled"), Is.True);
    }

    [Test]
    public async Task DeleteAccountButton_WhenClickedTwiceWhileProcessing_CallsDialogServiceOnce()
    {
        // Arrange
        var tcs = new TaskCompletionSource<IDialogReference>();
        var dialogServiceMock = new Mock<IDialogService>();
        dialogServiceMock
            .Setup(s => s.ShowAsync<TCSADialog>(It.IsAny<string>(), It.IsAny<DialogOptions>()))
            .Returns(tcs.Task);

        Services.AddSingleton(dialogServiceMock.Object);

        AuthorizeAs(TestUserId);
        Render<MudPopoverProvider>();
        var cut = RenderProfile();

        // Act
        cut.FindAll("button").Single(b => b.TextContent.Contains("Delete Account")).Click();
        cut.FindAll("button").Single(b => b.TextContent.Contains("Delete Account")).Click();

        tcs.SetResult(Mock.Of<IDialogReference>(r => r.Result == Task.FromResult(DialogResult.Cancel())));
        await cut.InvokeAsync(() => { });

        // Assert
        dialogServiceMock.Verify(
            s => s.ShowAsync<TCSADialog>(It.IsAny<string>(), It.IsAny<DialogOptions>()),
            Times.Once);
    }

    [Test]
    public void DeleteAccountButton_WhileProcessing_IsDisabled()
    {
        // Arrange
        var tcs = new TaskCompletionSource<IDialogReference>();
        var dialogServiceMock = new Mock<IDialogService>();
        dialogServiceMock
            .Setup(s => s.ShowAsync<TCSADialog>(It.IsAny<string>(), It.IsAny<DialogOptions>()))
            .Returns(tcs.Task);

        Services.AddSingleton(dialogServiceMock.Object);

        AuthorizeAs(TestUserId);
        Render<MudPopoverProvider>();
        var cut = RenderProfile();

        // Act
        cut.FindAll("button").Single(b => b.TextContent.Contains("Delete Account")).Click();

        // Assert
        var deleteButton = cut.FindAll("button").Single(b => b.TextContent.Contains("Delete Account"));
        Assert.That(deleteButton.HasAttribute("disabled"), Is.True);
    }

    [Test]
    public async Task RestartOnboardingButton_WhenClickedTwiceWhileProcessing_CallsRestartOnboardingOnce()
    {
        // Arrange
        var tcs = new TaskCompletionSource<BaseResponse>();

        _userServiceMock
            .Setup(s => s.RestartOnboarding(TestUserId))
            .Returns(tcs.Task);

        AuthorizeAs(TestUserId);
        Render<MudPopoverProvider>();
        var cut = RenderProfile();

        // Act
        cut.FindAll("button").Single(b => b.TextContent.Contains("Restart Onboarding")).Click();
        cut.FindAll("button").Single(b => b.TextContent.Contains("Restart Onboarding")).Click();

        tcs.SetResult(new BaseResponse { Status = ResponseStatus.Success });
        await cut.InvokeAsync(() => { });

        // Assert
        _userServiceMock.Verify(s => s.RestartOnboarding(TestUserId), Times.Once);
    }

    [Test]
    public void RestartOnboardingButton_WhileProcessing_IsDisabled()
    {
        // Arrange
        var tcs = new TaskCompletionSource<BaseResponse>();

        _userServiceMock
            .Setup(s => s.RestartOnboarding(TestUserId))
            .Returns(tcs.Task);

        AuthorizeAs(TestUserId);
        Render<MudPopoverProvider>();
        var cut = RenderProfile();

        // Act
        cut.FindAll("button").Single(b => b.TextContent.Contains("Restart Onboarding")).Click();

        // Assert
        var button = cut.FindAll("button").Single(b => b.TextContent.Contains("Restart Onboarding"));
        Assert.That(button.HasAttribute("disabled"), Is.True);
    }

    [Test]
    public void ResumeChecklistButton_IsNotVisible_WhenConditionsNotMet()
    {
        // Arrange
        AuthorizeAs(TestUserId);
        Render<MudPopoverProvider>();
        var cut = RenderProfile();

        // Assert
        Assert.That(
            cut.FindAll("button").Any(b => b.TextContent.Contains("Resume Checklist")),
            Is.False);
    }

    [Test]
    public void ResumeChecklistButton_IsVisible_WhenConditionsMet()
    {
        // Arrange
        AuthorizeAs(TestUserId);
        Render<MudPopoverProvider>();
        var cut = RenderProfileWithOnboardingUser();

        // Assert
        Assert.That(
            cut.FindAll("button").Any(b => b.TextContent.Contains("Resume Checklist")),
            Is.True);
    }

    [Test]
    public async Task ResumeChecklistButton_WhenClickedTwiceWhileProcessing_CallsResumeChecklistOnce()
    {
        // Arrange
        var tcs = new TaskCompletionSource<BaseResponse>();

        _userServiceMock
            .Setup(s => s.ResumeChecklist(TestUserId))
            .Returns(tcs.Task);

        AuthorizeAs(TestUserId);
        Render<MudPopoverProvider>();
        var cut = RenderProfileWithOnboardingUser();

        // Act
        cut.FindAll("button").Single(b => b.TextContent.Contains("Resume Checklist")).Click();
        cut.FindAll("button").Single(b => b.TextContent.Contains("Resume Checklist")).Click();

        tcs.SetResult(new BaseResponse { Status = ResponseStatus.Success });
        await cut.InvokeAsync(() => { });

        // Assert
        _userServiceMock.Verify(s => s.ResumeChecklist(TestUserId), Times.Once);
    }

    [Test]
    public void ResumeChecklistButton_WhileProcessing_IsDisabled()
    {
        // Arrange
        var tcs = new TaskCompletionSource<BaseResponse>();

        _userServiceMock
            .Setup(s => s.ResumeChecklist(TestUserId))
            .Returns(tcs.Task);

        AuthorizeAs(TestUserId);
        Render<MudPopoverProvider>();
        var cut = RenderProfileWithOnboardingUser();

        // Act
        cut.FindAll("button").Single(b => b.TextContent.Contains("Resume Checklist")).Click();

        // Assert
        var button = cut.FindAll("button").Single(b => b.TextContent.Contains("Resume Checklist"));
        Assert.That(button.HasAttribute("disabled"), Is.True);
    }
}
