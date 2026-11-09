using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using MudBlazor;
using MudBlazor.Services;
using TCSA.V2026.Components.Pages.Admin;
using TCSA.V2026.Data.DTOs;
using TCSA.V2026.Data.Enums;
using TCSA.V2026.Data.Models.Responses;
using TCSA.V2026.Services;

namespace TCSA.V2026.UnitTests.Components.Pages.Admin;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class AdminSurveysTests : BunitContext
{
    private readonly Mock<ISurveyAdminService> _serviceMock = new();

    [SetUp]
    public void SetUp()
    {
        JSInterop.Mode = JSRuntimeMode.Loose;
        Services.AddMudServices();
        Services.AddSingleton(_serviceMock.Object);
        Render<MudPopoverProvider>();
        Render<MudDialogProvider>();
    }

    private static SurveyListItemDto Survey(int id, string title, SurveyStatus status) => new()
    {
        Id = id,
        Title = title,
        Description = $"{title} description",
        Status = status,
        QuestionCount = 3,
        CreatedAt = new DateTimeOffset(2026, 10, 1, 12, 0, 0, TimeSpan.Zero)
    };

    private IRenderedComponent<AdminSurveys> RenderPage(params SurveyListItemDto[] surveys)
    {
        _serviceMock.Setup(s => s.GetSurveys()).ReturnsAsync([.. surveys]);
        return Render<AdminSurveys>();
    }

    private static IRenderedComponent<AdminSurveys> OpenBuilder(IRenderedComponent<AdminSurveys> cut)
    {
        cut.WaitForAssertion(() => Assert.That(cut.Markup, Does.Contain("New survey")));
        cut.FindAll("button").First(b => b.TextContent.Contains("New survey")).Click();
        return cut;
    }

    [Test]
    public void EmptyList_ShowsAPromptToCreateTheFirstSurvey()
    {
        var cut = RenderPage();

        cut.WaitForAssertion(() => Assert.That(cut.Markup, Does.Contain("No surveys yet")));
    }

    [Test]
    public void List_OffersDeactivateOnlyForActiveSurveys_AndActivateForTheRest()
    {
        var cut = RenderPage(
            Survey(1, "Draft one", SurveyStatus.Draft),
            Survey(2, "Active one", SurveyStatus.Active),
            Survey(3, "Inactive one", SurveyStatus.Inactive));

        cut.WaitForAssertion(() => Assert.That(cut.FindAll("tbody tr"), Has.Count.EqualTo(3)));
        var buttonLabels = cut.FindAll("tbody tr").Select(r => r.QuerySelectorAll("button").Select(b => b.TextContent.Trim()).ToList()).ToList();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(buttonLabels[0], Does.Contain("Activate"));
            Assert.That(buttonLabels[1], Does.Contain("Deactivate"));
            Assert.That(buttonLabels[1], Does.Not.Contain("Activate"));
            Assert.That(buttonLabels[2], Does.Contain("Activate"));
        }
    }

    [Test]
    public void List_DisablesDeleteForAnActiveSurveyOnly()
    {
        var cut = RenderPage(
            Survey(1, "Draft one", SurveyStatus.Draft),
            Survey(2, "Active one", SurveyStatus.Active),
            Survey(3, "Inactive one", SurveyStatus.Inactive));

        cut.WaitForAssertion(() => Assert.That(cut.FindAll("tbody tr"), Has.Count.EqualTo(3)));
        var deleteDisabled = cut.FindAll("tbody tr")
            .Select(r => r.QuerySelector("button[aria-label='Delete survey']")!.HasAttribute("disabled"))
            .ToList();

        Assert.That(deleteDisabled, Is.EqualTo(new[] { false, true, false }));
    }

    [Test]
    public void List_LinksEverySurveyToItsResults_IncludingInactiveOnes()
    {
        var cut = RenderPage(
            Survey(1, "Active one", SurveyStatus.Active),
            Survey(3, "Inactive one", SurveyStatus.Inactive));

        cut.WaitForAssertion(() => Assert.That(cut.FindAll("tbody tr"), Has.Count.EqualTo(2)));
        var links = cut.FindAll("tbody tr a").Where(a => a.TextContent.Contains("Results")).Select(a => a.GetAttribute("href")).ToList();

        Assert.That(links, Is.EqualTo(new[] { "/admin/surveys/1", "/admin/surveys/3" }));
    }

    [Test]
    public void Builder_StartsWithOneQuestion_AndOffersEveryQuestionType()
    {
        var cut = OpenBuilder(RenderPage());

        using (Assert.EnterMultipleScope())
        {
            Assert.That(cut.Markup, Does.Contain("1 / 20"));
            foreach (var label in new[] { "Rating", "Single choice", "Multiple choice", "Free text", "Yes / No" })
            {
                Assert.That(cut.FindAll("button").Any(b => b.TextContent.Trim() == label), Is.True, label);
            }
        }
    }

    [Test]
    public void Builder_AddingAChoiceQuestion_StartsWithTwoEmptyOptions()
    {
        var cut = OpenBuilder(RenderPage());

        cut.FindAll("button").First(b => b.TextContent.Trim() == "Single choice").Click();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(cut.Markup, Does.Contain("2 / 20"));
            Assert.That(cut.FindAll("input[placeholder^='Option ']"), Has.Count.EqualTo(2));
        }
    }

    [Test]
    public void Builder_RemovingTheLastQuestion_LeavesNoQuestionsAndBlocksSaving()
    {
        var cut = OpenBuilder(RenderPage());

        cut.Find("button[aria-label='Remove question']").Click();
        cut.FindAll("button").First(b => b.TextContent.Contains("Save as draft")).Click();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(cut.Markup, Does.Contain("2 to fix"));
            _serviceMock.Verify(s => s.CreateSurvey(It.IsAny<SurveyDraftDto>()), Times.Never);
        }
    }

    [Test]
    public void Builder_SavingAnInvalidSurvey_IsBlockedBeforeCallingTheService()
    {
        var cut = OpenBuilder(RenderPage());

        cut.FindAll("button").First(b => b.TextContent.Contains("Save as draft")).Click();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(cut.Markup, Does.Contain("Title is required."));
            Assert.That(cut.Markup, Does.Contain("Question text is required."));
            _serviceMock.Verify(s => s.CreateSurvey(It.IsAny<SurveyDraftDto>()), Times.Never);
        }
    }

    [Test]
    public void Builder_SaveBarChip_FollowsTheQuestionTextAsItIsTyped()
    {
        var cut = OpenBuilder(RenderPage());
        cut.Find("input[type='text']").Input("Course feedback");
        Assert.That(cut.Markup, Does.Contain("1 to fix"));

        cut.Find("input[maxlength='300']").Input("How was it?");

        cut.WaitForAssertion(() => Assert.That(cut.Markup, Does.Contain("Ready to save")));
    }

    [Test]
    public void Builder_SavingAValidSurvey_SendsTheDraftAndReturnsToTheList()
    {
        SurveyDraftDto? saved = null;
        _serviceMock
            .Setup(s => s.CreateSurvey(It.IsAny<SurveyDraftDto>()))
            .Callback<SurveyDraftDto>(d => saved = d)
            .ReturnsAsync(Result.Success(7));
        var cut = OpenBuilder(RenderPage());

        cut.Find("input[type='text']").Input("Course feedback");
        cut.Find("input[maxlength='300']").Input("How was it?");
        cut.FindAll("button").First(b => b.TextContent.Contains("Save as draft")).Click();

        cut.WaitForAssertion(() => Assert.That(saved, Is.Not.Null));
        using (Assert.EnterMultipleScope())
        {
            Assert.That(saved!.Title, Is.EqualTo("Course feedback"));
            Assert.That(saved.Questions, Has.Count.EqualTo(1));
            Assert.That(saved.Questions[0].Text, Is.EqualTo("How was it?"));
            Assert.That(cut.Markup, Does.Not.Contain("Save as draft"));
        }
    }
}
