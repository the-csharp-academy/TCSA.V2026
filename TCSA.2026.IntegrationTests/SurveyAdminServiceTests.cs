using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using TCSA.V2026.Data.DTOs;
using TCSA.V2026.Data.Enums;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Data.Models.Responses;
using TCSA.V2026.Helpers.Constants;
using TCSA.V2026.Services;

namespace TCSA.V2026.IntegrationTests;

[TestFixture]
public class SurveyAdminServiceTests : IntegrationTestsBase
{
    private SurveyAdminService _service;

    [SetUp]
    public void Setup()
    {
        BaseSetup();
        _service = new SurveyAdminService(DbContextFactory, NullLogger<SurveyAdminService>.Instance);
    }

    [TearDown]
    public void TearDown()
    {
        BaseTearDown();
    }

    private static SurveyQuestionDraftDto Rating(string text = "How was it?", bool required = true) =>
        new() { Text = text, Type = SurveyQuestionType.Rating, IsRequired = required };

    private static SurveyQuestionDraftDto Choice(
        SurveyQuestionType type = SurveyQuestionType.SingleChoice, params string[] options) =>
        new() { Text = "Pick one", Type = type, Options = [.. (options.Length == 0 ? ["A", "B"] : options)] };

    private static SurveyDraftDto Draft(params SurveyQuestionDraftDto[] questions) => new()
    {
        Title = "Course feedback",
        Description = "Tell us how the course went",
        Questions = [.. (questions.Length == 0 ? [Rating()] : questions)]
    };

    private async Task<int> Create(SurveyDraftDto? draft = null)
    {
        var result = await _service.CreateSurvey(draft ?? Draft());
        Assert.That(result.IsSuccess, Is.True, result.Message);
        return result.Value;
    }

    private async Task<int> SeedSurvey(SurveyStatus status, List<SurveyQuestion>? questions = null)
    {
        using var context = DbContextFactory.CreateDbContext();
        var survey = new Survey
        {
            Title = "Seeded",
            Description = "Seeded survey",
            Status = status,
            CreatedAt = DateTimeOffset.UtcNow,
            Questions = questions ?? []
        };
        context.Surveys.Add(survey);
        await context.SaveChangesAsync();
        return survey.Id;
    }

    private async Task<SurveyStatus> StatusOf(int id)
    {
        using var context = DbContextFactory.CreateDbContext();
        return (await context.Surveys.AsNoTracking().SingleAsync(s => s.Id == id)).Status;
    }

    private static void AssertFailure(Result result, string code)
    {
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailure, Is.True);
            Assert.That(result.Reason.Code, Is.EqualTo(code));
        }
    }

    private async Task AssertNothingStored()
    {
        using var context = DbContextFactory.CreateDbContext();
        using (Assert.EnterMultipleScope())
        {
            Assert.That(await context.Surveys.CountAsync(), Is.Zero);
            Assert.That(await context.SurveyQuestions.CountAsync(), Is.Zero);
            Assert.That(await context.SurveyOptions.CountAsync(), Is.Zero);
        }
    }

    [Test]
    public async Task CreateSurvey_SavesAsDraft_WithTitleAndDescription()
    {
        var id = await Create();

        using var context = DbContextFactory.CreateDbContext();
        var survey = await context.Surveys.AsNoTracking().SingleAsync(s => s.Id == id);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(survey.Status, Is.EqualTo(SurveyStatus.Draft));
            Assert.That(survey.Title, Is.EqualTo("Course feedback"));
            Assert.That(survey.Description, Is.EqualTo("Tell us how the course went"));
            Assert.That(survey.CreatedAt, Is.EqualTo(DateTimeOffset.UtcNow).Within(TimeSpan.FromMinutes(1)));
        }
    }

    [Test]
    public async Task CreateSurvey_StoresAllFiveQuestionTypes_InOrder_WithRequiredFlag()
    {
        var id = await Create(Draft(
            Rating("Rate it", required: true),
            Choice(SurveyQuestionType.SingleChoice, "One", "Two"),
            Choice(SurveyQuestionType.MultipleChoice, "X", "Y", "Z"),
            new SurveyQuestionDraftDto { Text = "Anything else?", Type = SurveyQuestionType.FreeText, IsRequired = false },
            new SurveyQuestionDraftDto { Text = "Would you recommend it?", Type = SurveyQuestionType.YesNo, IsRequired = true }));

        using var context = DbContextFactory.CreateDbContext();
        var questions = await context.SurveyQuestions.AsNoTracking()
            .Include(q => ((ChoiceQuestion)q).Options)
            .Where(q => q.SurveyId == id)
            .OrderBy(q => q.Order)
            .ToListAsync();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(questions.Select(q => q.Type), Is.EqualTo(new[]
            {
                SurveyQuestionType.Rating, SurveyQuestionType.SingleChoice, SurveyQuestionType.MultipleChoice,
                SurveyQuestionType.FreeText, SurveyQuestionType.YesNo
            }));
            Assert.That(questions.Select(q => q.GetType()), Is.EqualTo(new[]
            {
                typeof(RatingQuestion), typeof(SingleChoiceQuestion), typeof(MultipleChoiceQuestion),
                typeof(FreeTextQuestion), typeof(YesNoQuestion)
            }));
            Assert.That(questions.Select(q => q.IsRequired), Is.EqualTo(new[] { true, true, true, false, true }));
            Assert.That(questions.Select(q => q.Order), Is.Ordered.And.Unique);
            Assert.That(questions[0].Text, Is.EqualTo("Rate it"));
            Assert.That(((ChoiceQuestion)questions[2]).Options.OrderBy(o => o.Order).Select(o => o.Text), Is.EqualTo(new[] { "X", "Y", "Z" }));
        }
    }

    [Test]
    public async Task CreateSurvey_KeepsTheOrderTheAdminBuilt()
    {
        var id = await Create(Draft(Rating("Third?"), Rating("First?"), Rating("Second?")));

        using var context = DbContextFactory.CreateDbContext();
        var texts = await context.SurveyQuestions.AsNoTracking()
            .Where(q => q.SurveyId == id).OrderBy(q => q.Order).Select(q => q.Text).ToListAsync();

        Assert.That(texts, Is.EqualTo(new[] { "Third?", "First?", "Second?" }));
    }

    [Test]
    public async Task CreateSurvey_TrimsTextAndDropsBlankOptions()
    {
        var draft = Draft(Choice(SurveyQuestionType.SingleChoice, "  Yes please ", "", "No", "   "));
        draft.Title = "  Padded title  ";
        draft.Questions[0].Text = "  Pick one  ";

        var id = await Create(draft);

        using var context = DbContextFactory.CreateDbContext();
        var survey = await context.Surveys.AsNoTracking().Include(s => s.Questions).ThenInclude(q => ((ChoiceQuestion)q).Options).SingleAsync(s => s.Id == id);
        var question = (ChoiceQuestion)survey.Questions.Single();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(survey.Title, Is.EqualTo("Padded title"));
            Assert.That(question.Text, Is.EqualTo("Pick one"));
            Assert.That(question.Options.OrderBy(o => o.Order).Select(o => o.Text), Is.EqualTo(new[] { "Yes please", "No" }));
        }
    }

    [Test]
    public async Task CreateSurvey_IgnoresOptionsOnNonChoiceQuestions()
    {
        var question = Rating();
        question.Options = ["stale", "options"];

        var id = await Create(Draft(question));

        using var context = DbContextFactory.CreateDbContext();
        Assert.That(await context.SurveyOptions.CountAsync(o => o.Question.SurveyId == id), Is.Zero);
    }

    [Test]
    public async Task CreateSurvey_AllowsAnEmptyDescription()
    {
        var draft = Draft();
        draft.Description = string.Empty;

        var result = await _service.CreateSurvey(draft);

        Assert.That(result.IsSuccess, Is.True);
    }

    [Test]
    public async Task CreateSurvey_StoresMarkupVerbatim()
    {
        var draft = Draft(Rating("<script>alert(1)</script>"));
        draft.Title = "<b>Bold</b>";

        var id = await Create(draft);

        using var context = DbContextFactory.CreateDbContext();
        var survey = await context.Surveys.AsNoTracking().Include(s => s.Questions).SingleAsync(s => s.Id == id);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(survey.Title, Is.EqualTo("<b>Bold</b>"));
            Assert.That(survey.Questions.Single().Text, Is.EqualTo("<script>alert(1)</script>"));
        }
    }

    [Test]
    public async Task CreateSurvey_RejectsZeroQuestions()
    {
        var empty = new SurveyDraftDto { Title = "T", Description = "D" };

        var result = await _service.CreateSurvey(empty);

        AssertFailure(result, SurveyErrorCodes.NoQuestions);
        await AssertNothingStored();
    }

    [TestCase("")]
    [TestCase("   ")]
    public async Task CreateSurvey_RejectsABlankTitle(string title)
    {
        var draft = Draft();
        draft.Title = title;

        var result = await _service.CreateSurvey(draft);

        AssertFailure(result, SurveyErrorCodes.TitleRequired);
        await AssertNothingStored();
    }

    [Test]
    public async Task CreateSurvey_EnforcesTitleLimit()
    {
        var draft = Draft();
        draft.Title = new string('t', SurveyLimits.TitleMaxLength);
        Assert.That((await _service.CreateSurvey(draft)).IsSuccess, Is.True);

        draft.Title = new string('t', SurveyLimits.TitleMaxLength + 1);
        AssertFailure(await _service.CreateSurvey(draft), SurveyErrorCodes.TitleTooLong);
    }

    [Test]
    public async Task CreateSurvey_EnforcesDescriptionLimit()
    {
        var draft = Draft();
        draft.Description = new string('d', SurveyLimits.DescriptionMaxLength);
        Assert.That((await _service.CreateSurvey(draft)).IsSuccess, Is.True);

        draft.Description = new string('d', SurveyLimits.DescriptionMaxLength + 1);
        AssertFailure(await _service.CreateSurvey(draft), SurveyErrorCodes.DescriptionTooLong);
    }

    [Test]
    public async Task CreateSurvey_EnforcesQuestionCountLimit()
    {
        var atLimit = Draft([.. Enumerable.Range(0, SurveyLimits.MaxQuestions).Select(i => Rating($"Q{i}"))]);
        Assert.That((await _service.CreateSurvey(atLimit)).IsSuccess, Is.True);

        var overLimit = Draft([.. Enumerable.Range(0, SurveyLimits.MaxQuestions + 1).Select(i => Rating($"Q{i}"))]);
        AssertFailure(await _service.CreateSurvey(overLimit), SurveyErrorCodes.TooManyQuestions);
    }

    [TestCase("")]
    [TestCase("  ")]
    public async Task CreateSurvey_RejectsABlankQuestion(string text)
    {
        var result = await _service.CreateSurvey(Draft(Rating(text)));

        AssertFailure(result, SurveyErrorCodes.QuestionTextRequired);
        await AssertNothingStored();
    }

    [Test]
    public async Task CreateSurvey_EnforcesQuestionTextLimit()
    {
        var atLimit = Draft(Rating(new string('q', SurveyLimits.QuestionMaxLength)));
        Assert.That((await _service.CreateSurvey(atLimit)).IsSuccess, Is.True);

        var overLimit = Draft(Rating(new string('q', SurveyLimits.QuestionMaxLength + 1)));
        AssertFailure(await _service.CreateSurvey(overLimit), SurveyErrorCodes.QuestionTextTooLong);
    }

    [Test]
    public async Task CreateSurvey_RejectsAnUnknownQuestionType()
    {
        var question = Rating();
        question.Type = (SurveyQuestionType)999;

        AssertFailure(await _service.CreateSurvey(Draft(question)), SurveyErrorCodes.QuestionTypeInvalid);
        await AssertNothingStored();
    }

    [TestCase(SurveyQuestionType.SingleChoice)]
    [TestCase(SurveyQuestionType.MultipleChoice)]
    public async Task CreateSurvey_RejectsAChoiceQuestionWithFewerThanTwoOptions(SurveyQuestionType type)
    {
        AssertFailure(await _service.CreateSurvey(Draft(Choice(type, "Only one"))), SurveyErrorCodes.TooFewOptions);
        AssertFailure(await _service.CreateSurvey(Draft(new SurveyQuestionDraftDto { Text = "None", Type = type })), SurveyErrorCodes.TooFewOptions);
        await AssertNothingStored();
    }

    [Test]
    public async Task CreateSurvey_CountsOnlyNonBlankOptionsTowardsTheMinimum()
    {
        var result = await _service.CreateSurvey(Draft(Choice(SurveyQuestionType.SingleChoice, "Real", "", "  ")));

        AssertFailure(result, SurveyErrorCodes.TooFewOptions);
    }

    [Test]
    public async Task CreateSurvey_EnforcesOptionCountLimit()
    {
        var atLimit = Draft(Choice(SurveyQuestionType.MultipleChoice, [.. Enumerable.Range(0, SurveyLimits.MaxOptions).Select(i => $"O{i}")]));
        Assert.That((await _service.CreateSurvey(atLimit)).IsSuccess, Is.True);

        var overLimit = Draft(Choice(SurveyQuestionType.MultipleChoice, [.. Enumerable.Range(0, SurveyLimits.MaxOptions + 1).Select(i => $"O{i}")]));
        AssertFailure(await _service.CreateSurvey(overLimit), SurveyErrorCodes.TooManyOptions);
    }

    [Test]
    public async Task CreateSurvey_EnforcesOptionTextLimit()
    {
        var atLimit = Draft(Choice(SurveyQuestionType.SingleChoice, new string('o', SurveyLimits.OptionMaxLength), "B"));
        Assert.That((await _service.CreateSurvey(atLimit)).IsSuccess, Is.True);

        var overLimit = Draft(Choice(SurveyQuestionType.SingleChoice, new string('o', SurveyLimits.OptionMaxLength + 1), "B"));
        AssertFailure(await _service.CreateSurvey(overLimit), SurveyErrorCodes.OptionTextTooLong);
    }

    [Test]
    public async Task GetSurveys_ReturnsNewestFirst_WithStatusAndQuestionCount()
    {
        var older = await Create(Draft(Rating(), Rating("Two")));
        await Task.Delay(5);
        var newer = await Create(Draft(Rating()));
        await _service.ActivateSurvey(newer);

        var surveys = await _service.GetSurveys();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(surveys.Select(s => s.Id), Is.EqualTo(new[] { newer, older }));
            Assert.That(surveys[0].Status, Is.EqualTo(SurveyStatus.Active));
            Assert.That(surveys[0].QuestionCount, Is.EqualTo(1));
            Assert.That(surveys[1].Status, Is.EqualTo(SurveyStatus.Draft));
            Assert.That(surveys[1].QuestionCount, Is.EqualTo(2));
            Assert.That(surveys[1].Title, Is.EqualTo("Course feedback"));
            Assert.That(surveys[1].ResponseCount, Is.Zero);
        }
    }

    [Test]
    public async Task GetSurveys_CountsEachSurveysResponsesSeparately()
    {
        var busy = await Create();
        var quiet = await Create();
        var empty = await Create();
        using (var context = DbContextFactory.CreateDbContext())
        {
            context.SurveyResponses.AddRange(
                new SurveyResponse { SurveyId = busy, AppUserId = "user1", SubmittedAt = DateTimeOffset.UtcNow },
                new SurveyResponse { SurveyId = busy, AppUserId = "user2", SubmittedAt = DateTimeOffset.UtcNow },
                new SurveyResponse { SurveyId = quiet, AppUserId = "user1", SubmittedAt = DateTimeOffset.UtcNow });
            context.SurveyRefusals.Add(new SurveyRefusal { SurveyId = empty, AppUserId = "user1", RefusedAt = DateTimeOffset.UtcNow });
            await context.SaveChangesAsync();
        }

        var counts = (await _service.GetSurveys()).ToDictionary(s => s.Id, s => s.ResponseCount);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(counts[busy], Is.EqualTo(2));
            Assert.That(counts[quiet], Is.EqualTo(1));
            Assert.That(counts[empty], Is.Zero);
        }
    }

    [Test]
    public async Task ActivateSurvey_MovesDraftToActive()
    {
        var id = await Create();

        var result = await _service.ActivateSurvey(id);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSuccess, Is.True);
            Assert.That(await StatusOf(id), Is.EqualTo(SurveyStatus.Active));
        }
    }

    [Test]
    public async Task DeactivateSurvey_MovesActiveToInactive()
    {
        var id = await Create();
        await _service.ActivateSurvey(id);

        var result = await _service.DeactivateSurvey(id);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSuccess, Is.True);
            Assert.That(await StatusOf(id), Is.EqualTo(SurveyStatus.Inactive));
        }
    }

    [Test]
    public async Task ActivateSurvey_MovesInactiveBackToActive()
    {
        var id = await Create();
        await _service.ActivateSurvey(id);
        await _service.DeactivateSurvey(id);

        var result = await _service.ActivateSurvey(id);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSuccess, Is.True);
            Assert.That(await StatusOf(id), Is.EqualTo(SurveyStatus.Active));
        }
    }

    [Test]
    public async Task ActivateSurvey_RejectsAnAlreadyActiveSurvey()
    {
        var id = await Create();
        await _service.ActivateSurvey(id);

        AssertFailure(await _service.ActivateSurvey(id), SurveyErrorCodes.InvalidTransition);
        Assert.That(await StatusOf(id), Is.EqualTo(SurveyStatus.Active));
    }

    [TestCase(SurveyStatus.Draft)]
    [TestCase(SurveyStatus.Inactive)]
    public async Task DeactivateSurvey_RejectsAnythingThatIsNotActive(SurveyStatus status)
    {
        var id = await SeedSurvey(status);

        AssertFailure(await _service.DeactivateSurvey(id), SurveyErrorCodes.InvalidTransition);
        Assert.That(await StatusOf(id), Is.EqualTo(status));
    }

    [Test]
    public async Task StatusChanges_FailForAMissingSurvey()
    {
        AssertFailure(await _service.ActivateSurvey(404), SurveyErrorCodes.NotFound);
        AssertFailure(await _service.DeactivateSurvey(404), SurveyErrorCodes.NotFound);
        AssertFailure(await _service.DeleteSurvey(404), SurveyErrorCodes.NotFound);
    }

    [Test]
    public async Task ActivateSurvey_RejectsASurveyWithNoQuestions()
    {
        var id = await SeedSurvey(SurveyStatus.Draft);

        AssertFailure(await _service.ActivateSurvey(id), SurveyErrorCodes.NoQuestions);
        Assert.That(await StatusOf(id), Is.EqualTo(SurveyStatus.Draft));
    }

    [Test]
    public async Task ActivateSurvey_RejectsAChoiceQuestionWithFewerThanTwoOptions()
    {
        // The model refuses to build a choice question with one option, so this state can only come from outside the app.
        var id = await SeedSurvey(SurveyStatus.Inactive, [SingleChoiceQuestion.Create("Pick", true, 0, ["A", "B"])]);
        using (var context = DbContextFactory.CreateDbContext())
        {
            context.SurveyOptions.RemoveRange(await context.SurveyOptions.Where(o => o.Order == 1).ToListAsync());
            await context.SaveChangesAsync();
        }

        AssertFailure(await _service.ActivateSurvey(id), SurveyErrorCodes.TooFewOptions);
        Assert.That(await StatusOf(id), Is.EqualTo(SurveyStatus.Inactive));
    }

    [TestCase(SurveyStatus.Draft)]
    [TestCase(SurveyStatus.Inactive)]
    public async Task DeleteSurvey_RemovesTheSurveyItsQuestionsAndOptions(SurveyStatus status)
    {
        var id = await Create(Draft(Rating(), Choice(SurveyQuestionType.MultipleChoice, "A", "B", "C")));
        var other = await Create(Draft(Choice()));
        using (var context = DbContextFactory.CreateDbContext())
        {
            (await context.Surveys.SingleAsync(s => s.Id == id)).Status = status;
            await context.SaveChangesAsync();
        }

        var result = await _service.DeleteSurvey(id);

        Assert.That(result.IsSuccess, Is.True);
        using var verify = DbContextFactory.CreateDbContext();
        using (Assert.EnterMultipleScope())
        {
            Assert.That(await verify.Surveys.AnyAsync(s => s.Id == id), Is.False);
            Assert.That(await verify.SurveyQuestions.CountAsync(q => q.SurveyId == id), Is.Zero);
            Assert.That(await verify.Surveys.AnyAsync(s => s.Id == other), Is.True);
            Assert.That(await verify.SurveyQuestions.CountAsync(), Is.EqualTo(1));
            Assert.That(await verify.SurveyOptions.CountAsync(), Is.EqualTo(2));
        }
    }

    [Test]
    public async Task DeleteSurvey_RejectsAnActiveSurvey()
    {
        var id = await Create();
        await _service.ActivateSurvey(id);

        AssertFailure(await _service.DeleteSurvey(id), SurveyErrorCodes.DeleteActive);

        using var context = DbContextFactory.CreateDbContext();
        Assert.That(await context.Surveys.AnyAsync(s => s.Id == id), Is.True);
    }
}
