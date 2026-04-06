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
}
