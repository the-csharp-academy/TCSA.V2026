using Bunit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using MudBlazor;
using MudBlazor.Services;
using TCSA.V2026.Components.UI;
using TCSA.V2026.Data.DTOs;
using TCSA.V2026.Data.Enums;
using TCSA.V2026.Data.Helpers;
using TCSA.V2026.Data.Models.Responses;
using TCSA.V2026.Helpers.Constants;
using TCSA.V2026.Services;

namespace TCSA.V2026.UnitTests.Components.UI;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class FeedbackDialogTests : BunitContext
{
    private readonly Mock<IFeedbackService> _feedbackServiceMock = new();

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

        _feedbackServiceMock
            .Setup(s => s.Submit(It.IsAny<string>(), It.IsAny<FeedbackSubmissionDto>()))
            .ReturnsAsync(Result.Success());

        Services.AddSingleton(_feedbackServiceMock.Object);
        Services.AddMudServices();
    }

    private async Task<IRenderedComponent<MudDialogProvider>> ShowDialog(string originUrl)
    {
        Render<MudPopoverProvider>();
        var providerCut = Render<MudDialogProvider>();
        var dialogService = Services.GetRequiredService<IDialogService>();

        var parameters = new DialogParameters<TCSAFeedbackDialog>
        {
            { p => p.UserId, TestUserId },
            { p => p.OriginUrl, originUrl }
        };

        await providerCut.InvokeAsync(() => dialogService.ShowAsync<TCSAFeedbackDialog>(string.Empty, parameters));

        return providerCut;
    }

    private static void ChooseCategory(IRenderedComponent<MudDialogProvider> dialog, string title)
    {
        dialog.FindAll("button.feedback-card").Single(b => b.TextContent.Contains(title)).Click();
    }

    private static bool HasField(IRenderedComponent<MudDialogProvider> dialog, string label) =>
        dialog.FindAll("label").Any(l => l.TextContent.Trim() == label);

    private static void Write(IRenderedComponent<MudDialogProvider> dialog, string text)
    {
        dialog.Find("textarea").Input(text);
    }

    private static void ClickButton(IRenderedComponent<MudDialogProvider> dialog, string text)
    {
        dialog.FindAll("button").Single(b => b.TextContent.Trim() == text).Click();
    }

    [Test]
    public async Task FirstStep_OffersTheFourCategoriesAndNoInputs()
    {
        var dialog = await ShowDialog("dashboard/profile");

        var cards = dialog.FindAll("button.feedback-card").Select(b => b.TextContent).ToList();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(cards, Has.Count.EqualTo(4));
            Assert.That(cards, Has.One.Contains("Report a bug"));
            Assert.That(cards, Has.One.Contains("Share an idea"));
            Assert.That(cards, Has.One.Contains("I'm confused"));
            Assert.That(cards, Has.One.Contains("Say thanks"));
            Assert.That(dialog.FindAll("textarea"), Is.Empty);
        }
    }

    [Test]
    public async Task Bug_ShowsDescriptionAreaAndPagePrefilledFromWhereTheDialogWasOpened()
    {
        var dialog = await ShowDialog("Dashboard/Challenges/?tab=1");

        ChooseCategory(dialog, "Report a bug");

        using (Assert.EnterMultipleScope())
        {
            Assert.That(dialog.FindAll("textarea"), Has.Count.EqualTo(1));
            Assert.That(HasField(dialog, "Area"), Is.True);
            Assert.That(HasField(dialog, "Page"), Is.True);
            Assert.That(dialog.FindAll("input").Select(i => i.GetAttribute("value")), Does.Contain("/dashboard/challenges"));
            Assert.That(dialog.FindAll("input").Select(i => i.GetAttribute("value")), Does.Contain("Challenges"));
        }
    }

    [TestCase("Share an idea")]
    [TestCase("I'm confused")]
    [TestCase("Say thanks")]
    public async Task OtherCategories_ShowOnlyADescription(string title)
    {
        var dialog = await ShowDialog("dashboard/profile");

        ChooseCategory(dialog, title);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(dialog.FindAll("textarea"), Has.Count.EqualTo(1));
            Assert.That(HasField(dialog, "Area"), Is.False);
            Assert.That(HasField(dialog, "Page"), Is.False);
        }
    }

    [Test]
    public async Task Send_WithTooShortDescription_ShowsErrorAndDoesNotCallTheService()
    {
        var dialog = await ShowDialog("dashboard/profile");
        ChooseCategory(dialog, "Share an idea");
        Write(dialog, "abcd");

        ClickButton(dialog, "Send");

        using (Assert.EnterMultipleScope())
        {
            Assert.That(dialog.Markup, Does.Contain("Please write at least 5 characters."));
            _feedbackServiceMock.Verify(s => s.Submit(It.IsAny<string>(), It.IsAny<FeedbackSubmissionDto>()), Times.Never);
        }
    }

    [Test]
    public async Task Send_ValidIdea_SubmitsOnceAndShowsTheThankYouState()
    {
        var dialog = await ShowDialog("Dashboard/Roadmap");
        ChooseCategory(dialog, "Share an idea");
        Write(dialog, "Please add a dark mode toggle.");

        ClickButton(dialog, "Send");

        using (Assert.EnterMultipleScope())
        {
            _feedbackServiceMock.Verify(s => s.Submit(TestUserId, It.Is<FeedbackSubmissionDto>(d =>
                d.Category == FeedbackCategory.Idea &&
                d.Description == "Please add a dark mode toggle." &&
                d.OriginUrl == "Dashboard/Roadmap" &&
                d.Area == null &&
                d.Page == null)), Times.Once);
            Assert.That(dialog.Markup, Does.Contain("Thanks for your feedback!"));
            Assert.That(dialog.Markup, Does.Contain("It&#x27;s in the team&#x27;s review queue.").Or.Contain("It's in the team's review queue."));
        }
    }

    [Test]
    public async Task Send_Compliment_ThankYouStateAlsoMentionsTheReviewQueue()
    {
        var dialog = await ShowDialog("dashboard");
        ChooseCategory(dialog, "Say thanks");
        Write(dialog, "Love the new leaderboard!");

        ClickButton(dialog, "Send");

        using (Assert.EnterMultipleScope())
        {
            Assert.That(dialog.Markup, Does.Contain("It&#x27;s in the team&#x27;s review queue.").Or.Contain("It's in the team's review queue."));
            Assert.That(dialog.Markup, Does.Not.Contain("The team reads every message."));
        }
    }

    [Test]
    public async Task Send_Bug_SubmitsTheAreaAndPageFromTheForm()
    {
        var dialog = await ShowDialog("dashboard/profile");
        ChooseCategory(dialog, "Report a bug");
        Write(dialog, "The save button does nothing.");

        ClickButton(dialog, "Send");

        _feedbackServiceMock.Verify(s => s.Submit(TestUserId, It.Is<FeedbackSubmissionDto>(d =>
            d.Category == FeedbackCategory.Bug &&
            d.Area == FeedbackArea.Profile &&
            d.Page == "/dashboard/profile" &&
            d.OriginUrl == "dashboard/profile")), Times.Once);
    }

    [Test]
    public async Task Send_WhenRateLimited_ShowsTheServerMessageAsAWarningAndStaysOnTheForm()
    {
        _feedbackServiceMock
            .Setup(s => s.Submit(It.IsAny<string>(), It.IsAny<FeedbackSubmissionDto>()))
            .ReturnsAsync(Result.Failure(new Error(FeedbackErrorCodes.RateLimited, "Slow down, please.")));
        var dialog = await ShowDialog("dashboard");
        ChooseCategory(dialog, "Share an idea");
        Write(dialog, "Please add a dark mode toggle.");

        ClickButton(dialog, "Send");

        using (Assert.EnterMultipleScope())
        {
            Assert.That(dialog.Markup, Does.Contain("Slow down, please."));
            Assert.That(dialog.Find(".mud-alert").ClassList, Does.Contain("mud-alert-text-warning"));
            Assert.That(dialog.FindAll("textarea"), Has.Count.EqualTo(1));
            Assert.That(dialog.Markup, Does.Not.Contain("Thanks for your feedback!"));
        }
    }

    [Test]
    public async Task Send_WhenSubmitFailsForAnotherReason_ShowsTheServerMessageAsAnError()
    {
        _feedbackServiceMock
            .Setup(s => s.Submit(It.IsAny<string>(), It.IsAny<FeedbackSubmissionDto>()))
            .ReturnsAsync(Result.Failure(new Error(FeedbackErrorCodes.Unexpected, "Something went wrong.")));
        var dialog = await ShowDialog("dashboard");
        ChooseCategory(dialog, "Share an idea");
        Write(dialog, "Please add a dark mode toggle.");

        ClickButton(dialog, "Send");

        using (Assert.EnterMultipleScope())
        {
            Assert.That(dialog.Markup, Does.Contain("Something went wrong."));
            Assert.That(dialog.Find(".mud-alert").ClassList, Does.Contain("mud-alert-text-error"));
        }
    }

    [Test]
    public async Task SendAnother_ReturnsToTheCategoryStep()
    {
        var dialog = await ShowDialog("dashboard");
        ChooseCategory(dialog, "Share an idea");
        Write(dialog, "Please add a dark mode toggle.");
        ClickButton(dialog, "Send");

        ClickButton(dialog, "Send another");

        Assert.That(dialog.FindAll("button.feedback-card"), Has.Count.EqualTo(4));
    }
}
