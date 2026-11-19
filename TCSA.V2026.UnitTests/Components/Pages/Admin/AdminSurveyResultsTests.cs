using Bunit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using MudBlazor;
using MudBlazor.Services;
using System.Reflection;
using TCSA.V2026.Components.Pages.Admin;
using TCSA.V2026.Data.DTOs;
using TCSA.V2026.Data.Enums;
using TCSA.V2026.Data.Models.Responses;
using TCSA.V2026.Helpers.Constants;
using TCSA.V2026.Services;

namespace TCSA.V2026.UnitTests.Components.Pages.Admin;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class AdminSurveyResultsTests : BunitContext
{
    private const string Markup = "<script>alert('x')</script><b>bold</b>";

    private readonly Mock<ISurveyResultsService> _serviceMock = new();
    private readonly SurveyRespondentDetailState _detailState = new();

    [SetUp]
    public void SetUp()
    {
        JSInterop.Mode = JSRuntimeMode.Loose;
        Services.AddMudServices();
        Services.AddSingleton(_serviceMock.Object);
        Services.AddSingleton(_detailState);
        Render<MudPopoverProvider>();
    }

    private static ResultBucketDto Bucket(string label, int count, double percentage) =>
        new() { Label = label, Count = count, Percentage = percentage };

    private static SurveyResultsDto Results(int responses, params QuestionResultDto[] questions) => new()
    {
        Id = 5,
        Title = "Course feedback",
        Description = "Tell us how it went",
        Status = SurveyStatus.Inactive,
        ResponseCount = responses,
        Questions = [.. questions]
    };

    private static QuestionResultDto RatingQuestion() => new()
    {
        QuestionId = 1,
        Text = "Rate it",
        Type = SurveyQuestionType.Rating,
        IsRequired = true,
        AnswerCount = 4,
        Average = 3.5,
        Buckets = [Bucket("1", 1, 25), Bucket("2", 0, 0), Bucket("3", 0, 0), Bucket("4", 2, 50), Bucket("5", 1, 25)]
    };

    private static QuestionResultDto FreeTextQuestion() => new()
    {
        QuestionId = 2,
        Text = "Anything else?",
        Type = SurveyQuestionType.FreeText,
        AnswerCount = 1
    };

    private static FreeTextResultDto FreeText(string text) => new()
    {
        ResponseId = 9,
        UserId = "user1",
        UserName = "ada",
        UserDisplayName = "Ada",
        Text = text,
        SubmittedAt = new DateTimeOffset(2026, 10, 1, 12, 0, 0, TimeSpan.Zero)
    };

    private IRenderedComponent<AdminSurveyResults> RenderPage(SurveyResultsDto? results)
    {
        _serviceMock.Setup(s => s.GetResults(5)).ReturnsAsync(results);
        _serviceMock
            .Setup(s => s.GetFreeTextAnswers(It.IsAny<int>(), It.IsAny<int>()))
            .ReturnsAsync(new PaginatedList<FreeTextResultDto>([FreeText(Markup)], 1, 1, PagingConstants.SurveyFreeTextPageSize));
        return Render<AdminSurveyResults>(p => p.Add(x => x.SurveyId, 5));
    }

    [Test]
    public void Page_IsRestrictedToAdmins()
    {
        var authorize = typeof(AdminSurveyResults).GetCustomAttribute<AuthorizeAttribute>();

        Assert.That(authorize?.Roles, Is.EqualTo("Admin"));
    }

    [Test]
    public void Page_ShowsTheTitleStatusAndResponseCount_ForAnInactiveSurvey()
    {
        var cut = RenderPage(Results(4, RatingQuestion()));

        cut.WaitForAssertion(() =>
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(cut.Markup, Does.Contain("Course feedback"));
                Assert.That(cut.Markup, Does.Contain("Inactive"));
                Assert.That(cut.Find("#response-count").TextContent.Trim(), Is.EqualTo("4"));
            }
        });
    }

    [Test]
    public void Page_WithNoResponses_ShowsAnEmptyState()
    {
        var cut = RenderPage(Results(0, RatingQuestion()));

        cut.WaitForAssertion(() =>
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(cut.Markup, Does.Contain("No responses yet"));
                Assert.That(cut.Markup, Does.Not.Contain("Respondents"));
            }
        });
    }

    [Test]
    public void Page_ForAMissingSurvey_SaysSo()
    {
        var cut = RenderPage(null);

        cut.WaitForAssertion(() => Assert.That(cut.Markup, Does.Contain("no longer exists")));
    }

    [Test]
    public void RatingQuestion_ShowsTheAverageAndTheDistribution()
    {
        var cut = RenderPage(Results(4, RatingQuestion()));

        cut.WaitForAssertion(() =>
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(cut.Find(".rating-average").TextContent.Trim(), Is.EqualTo("3.5"));
                Assert.That(cut.FindAll(".result-bar-row"), Has.Count.EqualTo(5));
                Assert.That(cut.FindAll(".result-bar-value").Select(v => v.TextContent.Trim()),
                    Is.EqualTo(new[] { "25% 1 answer", "0% 0 answers", "0% 0 answers", "50% 2 answers", "25% 1 answer" }));
                Assert.That(cut.FindAll(".result-bar-label").Select(l => l.TextContent.Trim()),
                    Is.EqualTo(new[] { "1 star", "2 stars", "3 stars", "4 stars", "5 stars" }));
                Assert.That(cut.FindAll(".result-bar-fill").Select(f => f.GetAttribute("style")),
                    Has.Some.Contains("width: 50%"));
            }
        });
    }

    [Test]
    public void MultipleChoiceQuestion_NotesThatPercentagesCanExceedOneHundred()
    {
        var question = new QuestionResultDto
        {
            QuestionId = 3,
            Text = "Which topics?",
            Type = SurveyQuestionType.MultipleChoice,
            AnswerCount = 4,
            Buckets = [Bucket("X", 3, 75), Bucket("Y", 2, 50)]
        };

        var cut = RenderPage(Results(4, question));

        cut.WaitForAssertion(() => Assert.That(cut.Markup, Does.Contain("add up to more than 100%")));
    }

    [Test]
    public void MultipleChoiceQuestion_WhenEveryonePickedOneOption_HasNoOverHundredNote()
    {
        var question = new QuestionResultDto
        {
            QuestionId = 3,
            Text = "Which topics?",
            Type = SurveyQuestionType.MultipleChoice,
            AnswerCount = 4,
            Buckets = [Bucket("X", 3, 75), Bucket("Y", 1, 25)]
        };

        var cut = RenderPage(Results(4, question));

        cut.WaitForAssertion(() => Assert.That(cut.FindAll(".result-bar-row"), Has.Count.EqualTo(2)));
        Assert.That(cut.Markup, Does.Not.Contain("more than 100"));
    }

    [Test]
    public void FreeTextAnswers_AreShownWithTheAuthor_AndMarkupIsRenderedAsLiteralText()
    {
        var cut = RenderPage(Results(1, FreeTextQuestion()));

        cut.WaitForAssertion(() => Assert.That(cut.FindAll(".free-text-quote"), Has.Count.EqualTo(1)));
        var quote = cut.Find(".free-text-quote");

        using (Assert.EnterMultipleScope())
        {
            Assert.That(quote.QuerySelector("blockquote")!.TextContent, Is.EqualTo(Markup));
            Assert.That(quote.QuerySelector("blockquote")!.Children, Is.Empty, "the answer must not produce child elements");
            Assert.That(cut.FindAll("script"), Is.Empty);
            Assert.That(cut.FindAll("blockquote b"), Is.Empty);
            Assert.That(quote.TextContent, Does.Contain("Ada"));
        }
    }

    [Test]
    public void RespondentsTab_ListsNameEmailAndDate_AndLinksToTheUsersAdminPage()
    {
        _serviceMock
            .Setup(s => s.GetRespondents(5, It.IsAny<int>()))
            .ReturnsAsync(new PaginatedList<SurveyRespondentDto>(
            [
                new SurveyRespondentDto
                {
                    ResponseId = 9, UserId = "user1", UserName = "ada", UserDisplayName = "Ada",
                    Email = "ada@example.com", SubmittedAt = new DateTimeOffset(2026, 10, 1, 12, 0, 0, TimeSpan.Zero)
                }
            ], 1, 1, PagingConstants.SurveyRespondentsPageSize));
        var cut = RenderPage(Results(1, RatingQuestion()));

        cut.WaitForAssertion(() => Assert.That(cut.FindAll("[role=tab]"), Has.Count.EqualTo(2)));
        cut.FindAll("[role=tab]").First(t => t.TextContent.Contains("Respondents")).Click();

        cut.WaitForAssertion(() =>
        {
            var row = cut.Find("tbody tr");
            using (Assert.EnterMultipleScope())
            {
                Assert.That(row.TextContent, Does.Contain("Ada"));
                Assert.That(row.TextContent, Does.Contain("ada@example.com"));
                Assert.That(row.TextContent, Does.Contain("2026"));
                Assert.That(row.QuerySelector("a[href='/admin/user1']"), Is.Not.Null);
            }
        });
    }

    [Test]
    public void RespondentRow_SelectsTheRespondentForTheAnswersDrawer()
    {
        _serviceMock
            .Setup(s => s.GetRespondents(5, It.IsAny<int>()))
            .ReturnsAsync(new PaginatedList<SurveyRespondentDto>(
                [new SurveyRespondentDto { ResponseId = 9, UserId = "user1", UserName = "ada", Email = "ada@example.com" }],
                1, 1, PagingConstants.SurveyRespondentsPageSize));
        var cut = RenderPage(Results(1, RatingQuestion()));
        cut.WaitForAssertion(() => Assert.That(cut.FindAll("[role=tab]"), Has.Count.EqualTo(2)));
        cut.FindAll("[role=tab]").First(t => t.TextContent.Contains("Respondents")).Click();
        cut.WaitForAssertion(() => Assert.That(cut.FindAll("tbody tr"), Has.Count.EqualTo(1)));

        cut.Find("tbody tr button").Click();

        Assert.That(_detailState.Selected?.ResponseId, Is.EqualTo(9));
    }
}
