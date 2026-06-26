using Bunit;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using MudBlazor;
using MudBlazor.Services;
using System.Security.Claims;
using TCSA.V2026.Components.Layout;
using TCSA.V2026.Components.UI;
using TCSA.V2026.Data.DTOs;
using TCSA.V2026.Data.Helpers;
using TCSA.V2026.Services;

namespace TCSA.V2026.UnitTests.Components.Layout;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class MainLayoutTests : BunitContext
{
    private readonly Mock<IDialogService> _dialogServiceMock = new();
    private readonly Mock<IUserService> _userServiceMock = new();
    private readonly Mock<ISearchService> _searchServiceMock = new();

    private const string TestUserId = "test-user-id";

    [SetUp]
    public void SetUp()
    {
        JSInterop.Mode = JSRuntimeMode.Loose;

        var mockConfig = new Mock<IConfiguration>();
        mockConfig.Setup(c => c["LinkProvider:DiscordLink"]).Returns("https://discord.gg/test");

        ServiceProviderAccessor.ServiceProvider = new ServiceCollection()
            .AddSingleton(mockConfig.Object)
            .BuildServiceProvider();

        var httpContextAccessorMock = new Mock<IHttpContextAccessor>();
        httpContextAccessorMock.Setup(h => h.HttpContext).Returns((HttpContext?)null);

        Services.AddSingleton(httpContextAccessorMock.Object);
        Services.AddSingleton<ThemeService>();
        Services.AddSingleton(_userServiceMock.Object);
        Services.AddLogging();
        Services.AddMudServices();
        Services.AddSingleton(_dialogServiceMock.Object);
        Services.AddSingleton(_searchServiceMock.Object);
        Services.AddScoped<OnboardingStateService>();

        AddAuthorization();
    }

    private void AuthorizeAs(string userId)
    {
        var authContext = AddAuthorization();
        authContext.SetAuthorized("TEST USER");
        authContext.SetClaims(new Claim(ClaimTypes.NameIdentifier, userId));
    }

    private IRenderedComponent<MainLayout> RenderMainLayout()
    {
        ComponentFactories.AddStub<NavMenu>();
        ComponentFactories.AddStub<CommunityFeedWidget>();
        return Render<MainLayout>();
    }

    private Mock<IDialogReference> SetupDialogMock(bool canceled)
    {
        var dialogResult = canceled
            ? DialogResult.Cancel()
            : DialogResult.Ok<object>(null!);

        var dialogRefMock = new Mock<IDialogReference>();
        dialogRefMock
            .Setup(d => d.Result)
            .ReturnsAsync(dialogResult);

        _dialogServiceMock
            .Setup(s => s.ShowAsync<TCSAWelcomeDialog>(
                null,
                It.IsAny<DialogParameters<TCSAWelcomeDialog>>(),
                It.IsAny<DialogOptions>()))
            .ReturnsAsync(dialogRefMock.Object);

        return dialogRefMock;
    }

    [Test]
    public void Guest_CannotSeeChecklist()
    {
        // Act
        var cut = RenderMainLayout();

        // Assert
        Assert.That(cut.FindComponents<GetStartedChecklist>(), Is.Empty);
    }

    [Test]
    public void NewUser_CanSeeChecklist()
    {
        // Arrange
        _userServiceMock
            .Setup(s => s.GetOnboardingStatus(TestUserId))
            .ReturnsAsync(new OnboardingStatusDto
            {
                ShowWelcome = false,
                ShowChecklist = true,
                Tasks = []
            });

        AuthorizeAs(TestUserId);

        // Act
        var cut = RenderMainLayout();

        // Assert
        var checklist = cut.WaitForComponent<GetStartedChecklist>();
        Assert.That(checklist, Is.Not.Null);
    }

    [Test]
    public void Guest_CannotSeeWelcomeIntroductionModal()
    {
        // Act
        RenderMainLayout();

        // Assert
        _dialogServiceMock.Verify(
            s => s.ShowAsync<TCSAWelcomeDialog>(
                It.IsAny<string>(),
                It.IsAny<DialogParameters<TCSAWelcomeDialog>>(),
                It.IsAny<DialogOptions>()),
            Times.Never);
    }

    [Test]
    public void Guest_CannotSeeOnboardingTour()
    {
        // Act
        RenderMainLayout();

        // Assert
        Assert.That(
            JSInterop.Invocations.Any(i => i.Identifier == "import"),
            Is.False);
    }

    [Test]
    public void NewUser_CanSeeWelcomeIntroductionModal()
    {
        // Arrange
        _userServiceMock
            .Setup(s => s.GetOnboardingStatus(TestUserId))
            .ReturnsAsync(new OnboardingStatusDto { ShowWelcome = true });

        SetupDialogMock(canceled: true);

        AuthorizeAs(TestUserId);

        // Act
        var cut = RenderMainLayout();

        // Assert
        cut.WaitForAssertion(() =>
            _dialogServiceMock.Verify(
                s => s.ShowAsync<TCSAWelcomeDialog>(
                    null,
                    It.IsAny<DialogParameters<TCSAWelcomeDialog>>(),
                    It.IsAny<DialogOptions>()),
                Times.Once));
    }

    [Test]
    public void NewUser_CanSeeOnboardingTour()
    {
        // Arrange
        _userServiceMock
            .Setup(s => s.GetOnboardingStatus(TestUserId))
            .ReturnsAsync(new OnboardingStatusDto { ShowWelcome = true });

        SetupDialogMock(canceled: false);

        AuthorizeAs(TestUserId);

        // Act
        var cut = RenderMainLayout();

        // Assert
        cut.WaitForAssertion(() =>
            Assert.That(
                JSInterop.Invocations.Any(i =>
                    i.Identifier == "import" &&
                    i.Arguments.Count > 0 &&
                    i.Arguments[0]?.ToString() == "./js/onboarding-tour.js"),
                Is.True));
    }

    [Test]
    public async Task OnboardingStateNotification_WithShowWelcome_ShowsWelcomeDialog()
    {
        // Arrange
        _userServiceMock
            .Setup(s => s.GetOnboardingStatus(TestUserId))
            .ReturnsAsync(new OnboardingStatusDto { ShowWelcome = false });

        SetupDialogMock(canceled: true);
        AuthorizeAs(TestUserId);
        var cut = RenderMainLayout();

        cut.WaitForAssertion(() =>
            _userServiceMock.Verify(s => s.GetOnboardingStatus(TestUserId), Times.Once));

        // Act
        _userServiceMock
            .Setup(s => s.GetOnboardingStatus(TestUserId))
            .ReturnsAsync(new OnboardingStatusDto { ShowWelcome = true });

        var onboardingState = Services.GetRequiredService<OnboardingStateService>();
        await cut.InvokeAsync(() => onboardingState.NotifyChangedAsync());

        // Assert
        cut.WaitForAssertion(() =>
            _dialogServiceMock.Verify(
                s => s.ShowAsync<TCSAWelcomeDialog>(
                    null,
                    It.IsAny<DialogParameters<TCSAWelcomeDialog>>(),
                    It.IsAny<DialogOptions>()),
                Times.Once));
    }

    [Test]
    public async Task OnboardingStateNotification_WithShowChecklist_ShowsChecklistComponent()
    {
        // Arrange
        _userServiceMock
            .Setup(s => s.GetOnboardingStatus(TestUserId))
            .ReturnsAsync(new OnboardingStatusDto { ShowChecklist = false });

        AuthorizeAs(TestUserId);
        var cut = RenderMainLayout();

        cut.WaitForAssertion(() =>
            _userServiceMock.Verify(s => s.GetOnboardingStatus(TestUserId), Times.Once));

        // Act
        _userServiceMock
            .Setup(s => s.GetOnboardingStatus(TestUserId))
            .ReturnsAsync(new OnboardingStatusDto { ShowChecklist = true, Tasks = [] });

        var onboardingState = Services.GetRequiredService<OnboardingStateService>();
        await cut.InvokeAsync(() => onboardingState.NotifyChangedAsync());

        // Assert
        cut.WaitForAssertion(() =>
            Assert.That(cut.FindComponents<GetStartedChecklist>(), Is.Not.Empty));
    }
}
