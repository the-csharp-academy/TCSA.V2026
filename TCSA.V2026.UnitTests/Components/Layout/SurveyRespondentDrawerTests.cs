using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using MudBlazor;
using MudBlazor.Services;
using TCSA.V2026.Components.Layout;
using TCSA.V2026.Data.DTOs;
using TCSA.V2026.Data.Enums;
using TCSA.V2026.Services;

namespace TCSA.V2026.UnitTests.Components.Layout;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class SurveyRespondentDrawerTests : BunitContext
{
    private readonly SurveyRespondentDetailState _state = new();
    private readonly Mock<ISurveyResultsService> _serviceMock = new();

    private static readonly SurveyRespondentDto Ada = new()
    {
        ResponseId = 9,
        UserId = "user1",
        UserName = "ada",
        Email = "ada@example.com",
        SubmittedAt = new DateTimeOffset(2026, 10, 1, 12, 0, 0, TimeSpan.Zero)
    };

    [SetUp]
    public void SetUp()
    {
        JSInterop.Mode = JSRuntimeMode.Loose;
        Services.AddMudServices();
        Services.AddSingleton(_serviceMock.Object);
        Services.AddSingleton(_state);
        Render<MudPopoverProvider>();
    }

    [Test]
    public void Drawer_ShowsNumberedAnswersAndMarksSkippedOnes()
    {
        _serviceMock.Setup(s => s.GetRespondentAnswers(9)).ReturnsAsync(new RespondentAnswersDto
        {
            Respondent = Ada,
            Answers =
            [
                new RespondentAnswerDto { QuestionId = 1, QuestionText = "Rate it", Type = SurveyQuestionType.Rating, Answer = "5 of 5" },
                new RespondentAnswerDto { QuestionId = 2, QuestionText = "Anything else?", Type = SurveyQuestionType.FreeText, Answer = null }
            ]
        });
        var cut = Render<SurveyRespondentDrawer>();

        _state.Open(Ada);

        cut.WaitForAssertion(() => Assert.That(cut.FindAll(".survey-respondent-answer"), Has.Count.EqualTo(2)));
        using (Assert.EnterMultipleScope())
        {
            Assert.That(cut.Markup, Does.Contain("Rate it"));
            Assert.That(cut.Markup, Does.Contain("5 of 5"));
            Assert.That(cut.Find(".survey-respondent-skipped").TextContent.Trim(), Is.EqualTo("Skipped"));
            Assert.That(cut.FindAll(".survey-respondent-number").Select(n => n.TextContent), Is.EqualTo(new[] { "1", "2" }));
            Assert.That(cut.Find(".survey-respondent-facts").TextContent, Does.Contain("1 of 2 questions"));
        }
    }

    [Test]
    public void Drawer_RendersAnswerContainingMarkupAsLiteralText()
    {
        const string markup = "<script>alert('x')</script><b>bold</b>";
        _serviceMock.Setup(s => s.GetRespondentAnswers(9)).ReturnsAsync(new RespondentAnswersDto
        {
            Respondent = Ada,
            Answers = [new RespondentAnswerDto { QuestionId = 1, QuestionText = "Q", Type = SurveyQuestionType.FreeText, Answer = markup }]
        });
        var cut = Render<SurveyRespondentDrawer>();

        _state.Open(Ada);

        cut.WaitForAssertion(() => Assert.That(cut.FindAll(".survey-respondent-answer"), Has.Count.EqualTo(1)));
        using (Assert.EnterMultipleScope())
        {
            Assert.That(cut.Find(".survey-respondent-answer").TextContent.Trim(), Is.EqualTo(markup));
            Assert.That(cut.FindAll("script"), Is.Empty);
        }
    }

    [Test]
    public void Drawer_WhenTheResponseWasDeleted_ShowsAWarning()
    {
        _serviceMock.Setup(s => s.GetRespondentAnswers(9)).ReturnsAsync((RespondentAnswersDto?)null);
        var cut = Render<SurveyRespondentDrawer>();

        _state.Open(Ada);

        cut.WaitForAssertion(() => Assert.That(cut.Markup, Does.Contain("These answers no longer exist.")));
    }
}
