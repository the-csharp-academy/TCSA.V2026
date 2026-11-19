using Bunit;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using MudBlazor;
using MudBlazor.Services;
using System.Security.Claims;
using TCSA.V2026.Components.Layout;
using TCSA.V2026.Services;

namespace TCSA.V2026.UnitTests.Components.Layout;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class FeedbackWidgetTests : BunitContext
{
    private const string ButtonSelector = "button[aria-label='Send feedback']";

    [SetUp]
    public void SetUp()
    {
        JSInterop.Mode = JSRuntimeMode.Loose;
        Services.AddMudServices();
    }

    private void SignIn()
    {
        var authContext = AddAuthorization();
        authContext.SetAuthorized("TEST USER");
        authContext.SetClaims(new Claim(ClaimTypes.NameIdentifier, "test-user-id"));
    }

    private IRenderedComponent<FeedbackWidget> RenderAt(string path)
    {
        Services.GetRequiredService<NavigationManager>().NavigateTo(path);
        return Render<FeedbackWidget>();
    }

    [Test]
    public void Guest_DoesNotSeeTheFeedbackButton()
    {
        AddAuthorization();

        var cut = RenderAt("/dashboard");

        Assert.That(cut.FindAll(ButtonSelector), Is.Empty);
    }

    [TestCase("/")]
    [TestCase("/dashboard")]
    [TestCase("/dashboard/profile?tab=badges")]
    [TestCase("/article/12/some-article")]
    [TestCase("/about")]
    public void SignedInUser_SeesTheFeedbackButton(string path)
    {
        SignIn();

        var cut = RenderAt(path);

        Assert.That(cut.FindAll(ButtonSelector), Has.Count.EqualTo(1));
    }

    [TestCase("/admin")]
    [TestCase("/Admin")]
    [TestCase("/admin/")]
    [TestCase("/admin/comments")]
    [TestCase("/admin/some-user-id")]
    [TestCase("/adminreports")]
    [TestCase("/adminpending")]
    [TestCase("/adminsearch")]
    [TestCase("/adminactivity/some-user-id")]
    public void SignedInUser_DoesNotSeeTheFeedbackButtonOnAdminPages(string path)
    {
        SignIn();

        var cut = RenderAt(path);

        Assert.That(cut.FindAll(ButtonSelector), Is.Empty);
    }

    [Test]
    public void ClickingTheButton_OpensTheDialogPrefilledFromTheCurrentLocation()
    {
        SignIn();
        Services.AddSingleton(Mock.Of<IFeedbackService>());
        Render<MudPopoverProvider>();
        var dialogProvider = Render<MudDialogProvider>();
        var cut = RenderAt("/Dashboard/Challenges/?tab=1");

        cut.Find(ButtonSelector).Click();

        dialogProvider.WaitForAssertion(() => Assert.That(dialogProvider.FindAll("button.feedback-card"), Has.Count.EqualTo(4)));
        dialogProvider.FindAll("button.feedback-card").Single(b => b.TextContent.Contains("Report a bug")).Click();

        var inputValues = dialogProvider.FindAll("input").Select(i => i.GetAttribute("value")).ToList();
        using (Assert.EnterMultipleScope())
        {
            Assert.That(inputValues, Does.Contain("/dashboard/challenges"));
            Assert.That(inputValues, Does.Contain("Challenges"));
        }
    }

    [Test]
    public void SignedInUser_ButtonFollowsNavigationBetweenAdminAndPublicPages()
    {
        SignIn();
        var cut = RenderAt("/dashboard");
        var navigation = Services.GetRequiredService<NavigationManager>();

        cut.InvokeAsync(() => navigation.NavigateTo("/admin"));
        cut.WaitForAssertion(() => Assert.That(cut.FindAll(ButtonSelector), Is.Empty));

        cut.InvokeAsync(() => navigation.NavigateTo("/dashboard/leaderboard"));
        cut.WaitForAssertion(() => Assert.That(cut.FindAll(ButtonSelector), Has.Count.EqualTo(1)));
    }
}
