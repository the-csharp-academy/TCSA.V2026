using AngleSharp.Dom;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor;
using MudBlazor.Services;
using TCSA.V2026.Components.UI;
using TCSA.V2026.Data.DTOs;
using TCSA.V2026.Data.Models.Responses;
using TCSA.V2026.Helpers;
using static TCSA.V2026.UnitTests.Components.UI.SurveyFixtures;

namespace TCSA.V2026.UnitTests.Components.UI;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class SurveyDialogTests : BunitContext
{
    private SurveySubmissionDto? _submitted;
    private int _submitCalls;
    private int _refuseCalls;
    private Result _submitResult = Result.Success();
    private Result _refuseResult = Result.Success();

    [SetUp]
    public void SetUp()
    {
        JSInterop.Mode = JSRuntimeMode.Loose;
        Services.AddMudServices();
    }

    private async Task<(IRenderedComponent<MudDialogProvider> Provider, IDialogReference Reference)> ShowDialog()
    {
        Render<MudPopoverProvider>();
        var provider = Render<MudDialogProvider>();
        var dialogService = Services.GetRequiredService<IDialogService>();

        var parameters = new DialogParameters<TCSASurveyDialog>
        {
            { p => p.Survey, TwoQuestionSurvey() },
            { p => p.OnSubmit, dto => { _submitCalls++; _submitted = dto; return Task.FromResult(_submitResult); } },
            { p => p.OnRefuse, () => { _refuseCalls++; return Task.FromResult(_refuseResult); } }
        };

        var reference = await provider.InvokeAsync(() => dialogService.ShowAsync<TCSASurveyDialog>(string.Empty, parameters));
        return (provider, reference);
    }

    private static IElement Button(IRenderedComponent<MudDialogProvider> dialog, string text) =>
        dialog.FindAll("button").Single(b => b.TextContent.Trim() == text);

    private static bool HasButton(IRenderedComponent<MudDialogProvider> dialog, string text) =>
        dialog.FindAll("button").Any(b => b.TextContent.Trim() == text);

    private static bool IsDisabled(IElement button) => button.HasAttribute("disabled");

    private static async Task<IRenderedComponent<MudDialogProvider>> AtFirstQuestion(Task<(IRenderedComponent<MudDialogProvider> Provider, IDialogReference Reference)> shown)
    {
        var (dialog, _) = await shown;
        Button(dialog, "Start").Click();
        return dialog;
    }

    private async Task<IRenderedComponent<MudDialogProvider>> AtReview()
    {
        var dialog = await AtFirstQuestion(ShowDialog());
        Button(dialog, "Yes").Click();
        Button(dialog, "Next").Click();
        Button(dialog, "Skip").Click();
        return dialog;
    }

    [Test]
    public async Task Intro_ShowsTitleDescriptionQuestionCount_AndTheThreeChoices()
    {
        var (dialog, _) = await ShowDialog();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(dialog.Markup, Does.Contain("Tell us how the course went"));
            Assert.That(dialog.Markup, Does.Contain("2 questions"));
            Assert.That(HasButton(dialog, "Start"), Is.True);
            Assert.That(HasButton(dialog, "Maybe later"), Is.True);
            Assert.That(HasButton(dialog, "Never show again"), Is.True);
        }
    }

    [Test]
    public async Task Questions_ShowOneAtATimeWithAProgressIndicator()
    {
        var dialog = await AtFirstQuestion(ShowDialog());

        using (Assert.EnterMultipleScope())
        {
            Assert.That(dialog.Markup, Does.Contain("1 of 2"));
            Assert.That(dialog.Markup, Does.Contain("Is it clear?"));
            Assert.That(dialog.Markup, Does.Not.Contain("Anything else?"));
            Assert.That(HasButton(dialog, "Back"), Is.True);
            Assert.That(HasButton(dialog, "Never show again"), Is.False);
        }
    }

    [Test]
    public async Task ARequiredUnansweredQuestion_DisablesNext_AndSaysWhatIsMissing()
    {
        var dialog = await AtFirstQuestion(ShowDialog());

        using (Assert.EnterMultipleScope())
        {
            Assert.That(IsDisabled(Button(dialog, "Next")), Is.True);
            Assert.That(dialog.Markup, Does.Contain("Answer required to continue."));
            Assert.That(HasButton(dialog, "Skip"), Is.False);
        }
    }

    [Test]
    public async Task AnsweringTheRequiredQuestion_EnablesNext_AndClearsTheMessage()
    {
        var dialog = await AtFirstQuestion(ShowDialog());

        Button(dialog, "Yes").Click();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(IsDisabled(Button(dialog, "Next")), Is.False);
            Assert.That(dialog.Markup, Does.Not.Contain("Answer required to continue."));
        }
    }

    [Test]
    public async Task AnOptionalQuestion_OffersSkip()
    {
        var dialog = await AtFirstQuestion(ShowDialog());
        Button(dialog, "No").Click();
        Button(dialog, "Next").Click();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(dialog.Markup, Does.Contain("2 of 2"));
            Assert.That(dialog.Markup, Does.Contain("optional"));
            Assert.That(HasButton(dialog, "Skip"), Is.True);
        }
    }

    [Test]
    public async Task Back_ReturnsToTheIntro_FromTheFirstQuestion()
    {
        var dialog = await AtFirstQuestion(ShowDialog());

        Button(dialog, "Back").Click();

        Assert.That(HasButton(dialog, "Start"), Is.True);
    }

    [Test]
    public async Task ReviewStep_ListsEveryAnswer_AndSubmitSendsOnlyTheAnsweredQuestions()
    {
        var dialog = await AtReview();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(dialog.Markup, Does.Contain("Ready to submit?"));
            Assert.That(dialog.Markup, Does.Contain("Is it clear?"));
            Assert.That(dialog.Markup, Does.Contain("Skipped"));
        }

        Button(dialog, "Submit").Click();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(_submitCalls, Is.EqualTo(1));
            Assert.That(_submitted!.SurveyId, Is.EqualTo(3));
            Assert.That(_submitted.Answers.Select(a => a.QuestionId), Is.EqualTo(new[] { 10 }));
            Assert.That(_submitted.Answers[0].NumericValue, Is.EqualTo(1));
            Assert.That(dialog.Markup, Does.Contain("Thank you!"));
            Assert.That(HasButton(dialog, "Close"), Is.True);
        }
    }

    [Test]
    public async Task ReviewStep_LetsTheUserJumpBackToAnAnswer_AndReturnsStraightToTheReview()
    {
        var dialog = await AtReview();

        dialog.FindAll("button.survey-summary-row").First().Click();
        Assert.That(dialog.Markup, Does.Contain("1 of 2"));

        Button(dialog, "No").Click();
        Button(dialog, "Next").Click();

        Assert.That(dialog.Markup, Does.Contain("Ready to submit?"));
    }

    [Test]
    public async Task Submit_RejectedBecauseTheSurveyIsGone_ShowsTheMessage_AndOnlyOffersClose()
    {
        _submitResult = Result.Failure(SurveyErrors.Unavailable);
        var dialog = await AtReview();

        Button(dialog, "Submit").Click();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(dialog.Markup, Does.Contain("no longer available"));
            Assert.That(dialog.Markup, Does.Not.Contain("Thank you!"));
            Assert.That(HasButton(dialog, "Submit"), Is.False);
            Assert.That(HasButton(dialog, "Close"), Is.True);
        }
    }

    [Test]
    public async Task Submit_RejectedForAnotherReason_ShowsTheMessage_AndKeepsTheAnswersSubmittable()
    {
        _submitResult = Result.Failure(SurveyErrors.RequiredAnswerMissing("Is it clear?"));
        var dialog = await AtReview();

        Button(dialog, "Submit").Click();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(dialog.Markup, Does.Contain("needs an answer"));
            Assert.That(HasButton(dialog, "Submit"), Is.True);
            Assert.That(dialog.Markup, Does.Not.Contain("Thank you!"));
        }
    }

    [Test]
    public async Task MaybeLater_CancelsTheDialog_WithoutSubmittingOrRefusing()
    {
        var (dialog, reference) = await ShowDialog();

        Button(dialog, "Maybe later").Click();
        var result = await reference.Result;

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result!.Canceled, Is.True);
            Assert.That(_submitCalls, Is.Zero);
            Assert.That(_refuseCalls, Is.Zero);
        }
    }

    [Test]
    public async Task NeverShowAgain_RefusesTheSurvey_AndClosesTheDialog()
    {
        var (dialog, reference) = await ShowDialog();

        Button(dialog, "Never show again").Click();
        var result = await reference.Result;

        using (Assert.EnterMultipleScope())
        {
            Assert.That(_refuseCalls, Is.EqualTo(1));
            Assert.That(_submitCalls, Is.Zero);
            Assert.That(result!.Canceled, Is.False);
        }
    }

    [Test]
    public async Task NeverShowAgain_WhenTheServerRejects_ShowsTheMessage_AndOnlyOffersClose()
    {
        _refuseResult = Result.Failure(SurveyErrors.Unavailable);
        var (dialog, _) = await ShowDialog();

        Button(dialog, "Never show again").Click();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(dialog.Markup, Does.Contain("no longer available"));
            Assert.That(HasButton(dialog, "Close"), Is.True);
            Assert.That(HasButton(dialog, "Start"), Is.False);
        }
    }
}
