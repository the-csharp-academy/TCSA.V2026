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
public class SurveyServiceTests : IntegrationTestsBase
{
    private const string UserId = "user1";
    private const string OtherUserId = "user2";

    private SurveyService _service;

    [SetUp]
    public void Setup()
    {
        BaseSetup();
        _service = new SurveyService(DbContextFactory, NullLogger<SurveyService>.Instance);
    }

    [TearDown]
    public void TearDown()
    {
        BaseTearDown();
    }

    private sealed record Seeded(
        int SurveyId,
        int RatingId,
        int SingleId,
        int MultipleId,
        int TextId,
        int YesNoId,
        List<int> SingleOptionIds,
        List<int> MultipleOptionIds);

    private async Task<Seeded> SeedSurvey(SurveyStatus status = SurveyStatus.Active, string title = "Course feedback")
    {
        using var context = DbContextFactory.CreateDbContext();
        var survey = new Survey
        {
            Title = title,
            Description = "Tell us how it went",
            Status = status,
            CreatedAt = DateTimeOffset.UtcNow,
            Questions =
            [
                RatingQuestion.Create("How was it?", true, 0),
                SingleChoiceQuestion.Create("Best part?", true, 1, ["Videos", "Projects"]),
                MultipleChoiceQuestion.Create("What else?", false, 2, ["Community", "Reviews", "Articles"]),
                FreeTextQuestion.Create("Anything to add?", false, 3),
                YesNoQuestion.Create("Recommend it?", false, 4)
            ]
        };
        context.Surveys.Add(survey);
        await context.SaveChangesAsync();

        var questions = await context.SurveyQuestions.Include(q => ((ChoiceQuestion)q).Options)
            .Where(q => q.SurveyId == survey.Id).OrderBy(q => q.Order).ToListAsync();

        return new Seeded(
            survey.Id,
            questions[0].Id,
            questions[1].Id,
            questions[2].Id,
            questions[3].Id,
            questions[4].Id,
            [.. ((ChoiceQuestion)questions[1]).Options.OrderBy(o => o.Order).Select(o => o.Id)],
            [.. ((ChoiceQuestion)questions[2]).Options.OrderBy(o => o.Order).Select(o => o.Id)]);
    }

    private static SurveySubmissionDto ValidSubmission(Seeded s) => new()
    {
        SurveyId = s.SurveyId,
        Answers =
        [
            new() { QuestionId = s.RatingId, NumericValue = 4 },
            new() { QuestionId = s.SingleId, OptionIds = [s.SingleOptionIds[1]] }
        ]
    };

    private static SurveySubmissionDto With(Seeded s, params SurveyAnswerDto[] answers) => new()
    {
        SurveyId = s.SurveyId,
        Answers = [.. answers]
    };

    private static SurveyAnswerDto Rating(Seeded s, int? value) => new() { QuestionId = s.RatingId, NumericValue = value };

    private static SurveyAnswerDto Single(Seeded s, params int[] optionIds) => new() { QuestionId = s.SingleId, OptionIds = [.. optionIds] };

    private static void AssertFailure(Result result, string code)
    {
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailure, Is.True);
            Assert.That(result.Reason.Code, Is.EqualTo(code));
        }
    }

    private async Task<int> ResponseCount()
    {
        using var context = DbContextFactory.CreateDbContext();
        return await context.SurveyResponses.CountAsync();
    }

    private async Task AssertRejectedWithNothingStored(SurveySubmissionDto submission, string code)
    {
        var result = await _service.SubmitSurvey(UserId, submission);

        AssertFailure(result, code);
        using var context = DbContextFactory.CreateDbContext();
        using (Assert.EnterMultipleScope())
        {
            Assert.That(await context.SurveyResponses.CountAsync(), Is.Zero);
            Assert.That(await context.SurveyAnswers.CountAsync(), Is.Zero);
            Assert.That(await context.SurveyAnswerOptions.CountAsync(), Is.Zero);
        }
    }

    #region Availability

    [Test]
    public async Task GetAvailableSurveys_ReturnsActiveSurveysWithOrderedQuestionsAndOptions()
    {
        var seeded = await SeedSurvey();

        var surveys = await _service.GetAvailableSurveys(UserId);

        var survey = surveys.Single();
        using (Assert.EnterMultipleScope())
        {
            Assert.That(survey.Id, Is.EqualTo(seeded.SurveyId));
            Assert.That(survey.Title, Is.EqualTo("Course feedback"));
            Assert.That(survey.Description, Is.EqualTo("Tell us how it went"));
            Assert.That(survey.QuestionCount, Is.EqualTo(5));
            Assert.That(survey.Questions.Select(q => q.Id),
                Is.EqualTo(new[] { seeded.RatingId, seeded.SingleId, seeded.MultipleId, seeded.TextId, seeded.YesNoId }));
            Assert.That(survey.Questions[0].IsRequired, Is.True);
            Assert.That(survey.Questions[2].IsRequired, Is.False);
            Assert.That(survey.Questions[1].Options.Select(o => o.Text), Is.EqualTo(new[] { "Videos", "Projects" }));
            Assert.That(survey.Questions[2].Options.Select(o => o.Id), Is.EqualTo(seeded.MultipleOptionIds));
        }
    }

    [Test]
    public async Task GetAvailableSurveys_NeverShowsDraftOrInactiveSurveys()
    {
        await SeedSurvey(SurveyStatus.Draft, "Draft");
        await SeedSurvey(SurveyStatus.Inactive, "Inactive");
        var active = await SeedSurvey(SurveyStatus.Active, "Active");

        var surveys = await _service.GetAvailableSurveys(UserId);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(surveys.Select(s => s.Id), Is.EqualTo(new[] { active.SurveyId }));
            Assert.That(await _service.GetAvailableCount(UserId), Is.EqualTo(1));
        }
    }

    [Test]
    public async Task GetAvailableSurveys_IsEmpty_WhenThereAreNoSurveys()
    {
        using (Assert.EnterMultipleScope())
        {
            Assert.That(await _service.GetAvailableSurveys(UserId), Is.Empty);
            Assert.That(await _service.GetAvailableCount(UserId), Is.Zero);
        }
    }

    [Test]
    public async Task SubmittedSurvey_IsNeverOfferedAgainToThatUser_ButStaysAvailableToOthers()
    {
        var seeded = await SeedSurvey();
        await _service.SubmitSurvey(UserId, ValidSubmission(seeded));

        using (Assert.EnterMultipleScope())
        {
            Assert.That(await _service.GetAvailableSurveys(UserId), Is.Empty);
            Assert.That(await _service.GetAvailableCount(UserId), Is.Zero);
            Assert.That(await _service.GetAvailableSurveys(OtherUserId), Has.Count.EqualTo(1));
            Assert.That(await _service.GetAvailableCount(OtherUserId), Is.EqualTo(1));
        }
    }

    [Test]
    public async Task RefusedSurvey_IsNeverOfferedAgainToThatUser_ButStaysAvailableToOthers()
    {
        var seeded = await SeedSurvey();
        await _service.RefuseSurvey(UserId, seeded.SurveyId);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(await _service.GetAvailableSurveys(UserId), Is.Empty);
            Assert.That(await _service.GetAvailableCount(UserId), Is.Zero);
            Assert.That(await _service.GetAvailableCount(OtherUserId), Is.EqualTo(1));
        }
    }

    [Test]
    public async Task GetAvailableCount_OnlyCountsSurveysTheUserHasNotAnsweredOrRefused()
    {
        var answered = await SeedSurvey(title: "Answered");
        var refused = await SeedSurvey(title: "Refused");
        await SeedSurvey(title: "Open one");
        await SeedSurvey(title: "Open two");
        await _service.SubmitSurvey(UserId, ValidSubmission(answered));
        await _service.RefuseSurvey(UserId, refused.SurveyId);

        Assert.That(await _service.GetAvailableCount(UserId), Is.EqualTo(2));
    }

    [Test]
    public async Task DeactivatedSurvey_DisappearsFromTheList()
    {
        var seeded = await SeedSurvey();
        using (var context = DbContextFactory.CreateDbContext())
        {
            (await context.Surveys.SingleAsync(s => s.Id == seeded.SurveyId)).Status = SurveyStatus.Inactive;
            await context.SaveChangesAsync();
        }

        Assert.That(await _service.GetAvailableSurveys(UserId), Is.Empty);
    }

    #endregion

    #region Submit

    [Test]
    public async Task Submit_RecordsExactlyOneResponseWithTheGivenAnswers()
    {
        var seeded = await SeedSurvey();
        var submission = With(seeded,
            Rating(seeded, 5),
            Single(seeded, seeded.SingleOptionIds[0]),
            new() { QuestionId = seeded.MultipleId, OptionIds = [seeded.MultipleOptionIds[0], seeded.MultipleOptionIds[2]] },
            new() { QuestionId = seeded.TextId, TextValue = "Loved the projects" },
            new() { QuestionId = seeded.YesNoId, NumericValue = 1 });

        var result = await _service.SubmitSurvey(UserId, submission);

        using var context = DbContextFactory.CreateDbContext();
        var response = await context.SurveyResponses
            .Include(r => r.Answers).ThenInclude(a => ((ChoiceAnswer)a).SelectedOptions)
            .SingleAsync();
        var answers = response.Answers.ToDictionary(a => a.SurveyQuestionId);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSuccess, Is.True, result.Message);
            Assert.That(result.Reason.Code, Is.EqualTo(SurveyErrorCodes.Submitted));
            Assert.That(response.SurveyId, Is.EqualTo(seeded.SurveyId));
            Assert.That(response.AppUserId, Is.EqualTo(UserId));
            Assert.That(response.SubmittedAt, Is.EqualTo(DateTimeOffset.UtcNow).Within(TimeSpan.FromMinutes(1)));
            Assert.That(answers, Has.Count.EqualTo(5));
            Assert.That(((RatingAnswer)answers[seeded.RatingId]).Rating, Is.EqualTo(5));
            Assert.That(((SingleChoiceAnswer)answers[seeded.SingleId]).SelectedOptions.Select(o => o.SurveyOptionId),
                Is.EqualTo(new[] { seeded.SingleOptionIds[0] }));
            Assert.That(((MultipleChoiceAnswer)answers[seeded.MultipleId]).SelectedOptions.Select(o => o.SurveyOptionId),
                Is.EquivalentTo(new[] { seeded.MultipleOptionIds[0], seeded.MultipleOptionIds[2] }));
            Assert.That(((FreeTextAnswer)answers[seeded.TextId]).Text, Is.EqualTo("Loved the projects"));
            Assert.That(((YesNoAnswer)answers[seeded.YesNoId]).IsYes, Is.True);
        }
    }

    [Test]
    public async Task Submit_StoresNoAnswerForSkippedOptionalQuestions()
    {
        var seeded = await SeedSurvey();
        var submission = With(seeded,
            Rating(seeded, 3),
            Single(seeded, seeded.SingleOptionIds[0]),
            new() { QuestionId = seeded.MultipleId },
            new() { QuestionId = seeded.TextId, TextValue = "   " },
            new() { QuestionId = seeded.YesNoId });

        var result = await _service.SubmitSurvey(UserId, submission);

        using var context = DbContextFactory.CreateDbContext();
        var answered = await context.SurveyAnswers.Select(a => a.SurveyQuestionId).ToListAsync();
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSuccess, Is.True, result.Message);
            Assert.That(answered, Is.EquivalentTo(new[] { seeded.RatingId, seeded.SingleId }));
        }
    }

    [Test]
    public async Task Submit_AcceptsAnOptionalQuestionThatIsNotMentionedAtAll()
    {
        var seeded = await SeedSurvey();

        var result = await _service.SubmitSurvey(UserId, ValidSubmission(seeded));

        Assert.That(result.IsSuccess, Is.True, result.Message);
    }

    [Test]
    public async Task Submit_AcceptsFreeTextOfExactlyTheMaximumLength()
    {
        var seeded = await SeedSurvey();
        var submission = ValidSubmission(seeded);
        submission.Answers.Add(new() { QuestionId = seeded.TextId, TextValue = new string('a', SurveyLimits.FreeTextAnswerMaxLength) });

        var result = await _service.SubmitSurvey(UserId, submission);

        Assert.That(result.IsSuccess, Is.True, result.Message);
    }

    #endregion

    #region Server validation

    [Test]
    public async Task Submit_Rejects_WhenARequiredQuestionIsMissing()
    {
        var seeded = await SeedSurvey();

        await AssertRejectedWithNothingStored(With(seeded, Single(seeded, seeded.SingleOptionIds[0])), SurveyErrorCodes.RequiredAnswerMissing);
    }

    [Test]
    public async Task Submit_Rejects_WhenARequiredQuestionIsPresentButBlank()
    {
        var seeded = await SeedSurvey();

        await AssertRejectedWithNothingStored(
            With(seeded, Rating(seeded, null), Single(seeded, seeded.SingleOptionIds[0])),
            SurveyErrorCodes.RequiredAnswerMissing);
    }

    [Test]
    public async Task Submit_Rejects_WhenARequiredChoiceHasNoOptionSelected()
    {
        var seeded = await SeedSurvey();

        await AssertRejectedWithNothingStored(With(seeded, Rating(seeded, 3), Single(seeded)), SurveyErrorCodes.RequiredAnswerMissing);
    }

    [Test]
    public async Task Submit_Rejects_AnEmptySubmission()
    {
        var seeded = await SeedSurvey();

        await AssertRejectedWithNothingStored(With(seeded), SurveyErrorCodes.RequiredAnswerMissing);
    }

    [TestCase(0)]
    [TestCase(6)]
    [TestCase(-1)]
    public async Task Submit_Rejects_ARatingOutsideOneToFive(int rating)
    {
        var seeded = await SeedSurvey();

        await AssertRejectedWithNothingStored(
            With(seeded, Rating(seeded, rating), Single(seeded, seeded.SingleOptionIds[0])),
            SurveyErrorCodes.InvalidRating);
    }

    [TestCase(1)]
    [TestCase(5)]
    public async Task Submit_AcceptsTheRatingBoundaries(int rating)
    {
        var seeded = await SeedSurvey();

        var result = await _service.SubmitSurvey(UserId, With(seeded, Rating(seeded, rating), Single(seeded, seeded.SingleOptionIds[0])));

        Assert.That(result.IsSuccess, Is.True, result.Message);
    }

    [TestCase(2)]
    [TestCase(-1)]
    public async Task Submit_Rejects_AYesNoAnswerThatIsNotZeroOrOne(int value)
    {
        var seeded = await SeedSurvey();
        var submission = ValidSubmission(seeded);
        submission.Answers.Add(new() { QuestionId = seeded.YesNoId, NumericValue = value });

        await AssertRejectedWithNothingStored(submission, SurveyErrorCodes.InvalidYesNo);
    }

    [TestCase(0)]
    [TestCase(1)]
    public async Task Submit_AcceptsYesAndNo(int value)
    {
        var seeded = await SeedSurvey();
        var submission = ValidSubmission(seeded);
        submission.Answers.Add(new() { QuestionId = seeded.YesNoId, NumericValue = value });

        var result = await _service.SubmitSurvey(UserId, submission);

        Assert.That(result.IsSuccess, Is.True, result.Message);
    }

    [Test]
    public async Task Submit_Rejects_ASingleChoiceWithMoreThanOneOption()
    {
        var seeded = await SeedSurvey();

        await AssertRejectedWithNothingStored(
            With(seeded, Rating(seeded, 3), Single(seeded, [.. seeded.SingleOptionIds])),
            SurveyErrorCodes.InvalidChoiceCount);
    }

    [Test]
    public async Task Submit_Rejects_ASingleChoiceThatRepeatsTheSameOption()
    {
        var seeded = await SeedSurvey();

        await AssertRejectedWithNothingStored(
            With(seeded, Rating(seeded, 3), Single(seeded, seeded.SingleOptionIds[0], seeded.SingleOptionIds[0])),
            SurveyErrorCodes.InvalidChoiceCount);
    }

    [Test]
    public async Task Submit_Rejects_AChosenOptionThatBelongsToAnotherQuestion()
    {
        var seeded = await SeedSurvey();

        await AssertRejectedWithNothingStored(
            With(seeded, Rating(seeded, 3), Single(seeded, seeded.MultipleOptionIds[0])),
            SurveyErrorCodes.OptionNotInQuestion);
    }

    [Test]
    public async Task Submit_Rejects_AChosenOptionThatBelongsToAnotherSurvey()
    {
        var seeded = await SeedSurvey();
        var other = await SeedSurvey(title: "Other survey");

        await AssertRejectedWithNothingStored(
            With(seeded, Rating(seeded, 3), Single(seeded, other.SingleOptionIds[0])),
            SurveyErrorCodes.OptionNotInQuestion);
    }

    [Test]
    public async Task Submit_Rejects_AChosenOptionThatDoesNotExist()
    {
        var seeded = await SeedSurvey();

        await AssertRejectedWithNothingStored(
            With(seeded, Rating(seeded, 3), Single(seeded, 999_999)),
            SurveyErrorCodes.OptionNotInQuestion);
    }

    [Test]
    public async Task Submit_Rejects_AMultipleChoiceThatIncludesAForeignOption()
    {
        var seeded = await SeedSurvey();
        var submission = ValidSubmission(seeded);
        submission.Answers.Add(new() { QuestionId = seeded.MultipleId, OptionIds = [seeded.MultipleOptionIds[0], seeded.SingleOptionIds[0]] });

        await AssertRejectedWithNothingStored(submission, SurveyErrorCodes.OptionNotInQuestion);
    }

    [Test]
    public async Task Submit_StoresARepeatedOptionOnAMultipleChoiceOnce()
    {
        var seeded = await SeedSurvey();
        var submission = ValidSubmission(seeded);
        submission.Answers.Add(new() { QuestionId = seeded.MultipleId, OptionIds = [seeded.MultipleOptionIds[1], seeded.MultipleOptionIds[1]] });

        var result = await _service.SubmitSurvey(UserId, submission);

        using var context = DbContextFactory.CreateDbContext();
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSuccess, Is.True, result.Message);
            Assert.That(await context.SurveyAnswerOptions.CountAsync(o => o.SurveyOptionId == seeded.MultipleOptionIds[1]), Is.EqualTo(1));
        }
    }

    [Test]
    public async Task Submit_Rejects_FreeTextOverTheLimit()
    {
        var seeded = await SeedSurvey();
        var submission = ValidSubmission(seeded);
        submission.Answers.Add(new() { QuestionId = seeded.TextId, TextValue = new string('a', SurveyLimits.FreeTextAnswerMaxLength + 1) });

        await AssertRejectedWithNothingStored(submission, SurveyErrorCodes.AnswerTooLong);
    }

    [Test]
    public async Task Submit_Rejects_AnAnswerToAQuestionOutsideTheSurvey()
    {
        var seeded = await SeedSurvey();
        var other = await SeedSurvey(title: "Other survey");
        var submission = ValidSubmission(seeded);
        submission.Answers.Add(new() { QuestionId = other.TextId, TextValue = "sneaky" });

        await AssertRejectedWithNothingStored(submission, SurveyErrorCodes.UnknownQuestion);
    }

    [Test]
    public async Task Submit_Rejects_TwoAnswersToTheSameQuestion()
    {
        var seeded = await SeedSurvey();
        var submission = ValidSubmission(seeded);
        submission.Answers.Add(Rating(seeded, 1));

        await AssertRejectedWithNothingStored(submission, SurveyErrorCodes.DuplicateAnswer);
    }

    [Test]
    public async Task Submit_IgnoresFieldsThatDoNotBelongToTheQuestionType()
    {
        var seeded = await SeedSurvey();
        var submission = With(seeded,
            new() { QuestionId = seeded.RatingId, NumericValue = 4, TextValue = "stray", OptionIds = [seeded.SingleOptionIds[0]] },
            Single(seeded, seeded.SingleOptionIds[0]));

        var result = await _service.SubmitSurvey(UserId, submission);

        using var context = DbContextFactory.CreateDbContext();
        var rating = await context.SurveyAnswers.SingleAsync(a => a.SurveyQuestionId == seeded.RatingId);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSuccess, Is.True, result.Message);
            Assert.That(rating, Is.TypeOf<RatingAnswer>());
            Assert.That(((RatingAnswer)rating).Rating, Is.EqualTo(4));
            Assert.That(await context.SurveyAnswerOptions.CountAsync(), Is.EqualTo(1));
        }
    }

    #endregion

    #region Survey state

    [Test]
    public async Task Submit_Rejects_AnInactiveSurvey()
    {
        var seeded = await SeedSurvey(SurveyStatus.Inactive);

        await AssertRejectedWithNothingStored(ValidSubmission(seeded), SurveyErrorCodes.Unavailable);
    }

    [Test]
    public async Task Submit_Rejects_ADraftSurvey()
    {
        var seeded = await SeedSurvey(SurveyStatus.Draft);

        await AssertRejectedWithNothingStored(ValidSubmission(seeded), SurveyErrorCodes.Unavailable);
    }

    [Test]
    public async Task Submit_Rejects_ASurveyThatWasDeactivatedWhileTheModalWasOpen()
    {
        var seeded = await SeedSurvey();
        var submission = ValidSubmission(seeded);
        using (var context = DbContextFactory.CreateDbContext())
        {
            (await context.Surveys.SingleAsync(s => s.Id == seeded.SurveyId)).Status = SurveyStatus.Inactive;
            await context.SaveChangesAsync();
        }

        var result = await _service.SubmitSurvey(UserId, submission);

        using (Assert.EnterMultipleScope())
        {
            AssertFailure(result, SurveyErrorCodes.Unavailable);
            Assert.That(result.Message, Does.Contain("no longer available"));
            Assert.That(await ResponseCount(), Is.Zero);
        }
    }

    [Test]
    public async Task Submit_Rejects_ASurveyThatNeverExisted()
    {
        await AssertRejectedWithNothingStored(new SurveySubmissionDto { SurveyId = 424_242 }, SurveyErrorCodes.Unavailable);
    }

    [Test]
    public async Task Submit_Rejects_ANullSubmission()
    {
        var result = await _service.SubmitSurvey(UserId, null!);

        AssertFailure(result, SurveyErrorCodes.Unavailable);
    }

    [Test]
    public async Task Submit_Twice_YieldsExactlyOneResponse()
    {
        var seeded = await SeedSurvey();

        var first = await _service.SubmitSurvey(UserId, ValidSubmission(seeded));
        var second = await _service.SubmitSurvey(UserId, ValidSubmission(seeded));

        using var context = DbContextFactory.CreateDbContext();
        using (Assert.EnterMultipleScope())
        {
            Assert.That(first.IsSuccess, Is.True, first.Message);
            AssertFailure(second, SurveyErrorCodes.AlreadySubmitted);
            Assert.That(await context.SurveyResponses.CountAsync(), Is.EqualTo(1));
            Assert.That(await context.SurveyAnswers.CountAsync(), Is.EqualTo(2));
        }
    }

    [Test]
    public async Task Submit_ASecondTime_CannotChangeTheStoredAnswers()
    {
        var seeded = await SeedSurvey();
        await _service.SubmitSurvey(UserId, With(seeded, Rating(seeded, 5), Single(seeded, seeded.SingleOptionIds[0])));

        await _service.SubmitSurvey(UserId, With(seeded, Rating(seeded, 1), Single(seeded, seeded.SingleOptionIds[1])));

        using var context = DbContextFactory.CreateDbContext();
        Assert.That((await context.SurveyAnswers.OfType<RatingAnswer>().SingleAsync(a => a.SurveyQuestionId == seeded.RatingId)).Rating, Is.EqualTo(5));
    }

    [Test]
    public async Task Submit_LetsTwoUsersEachAnswerTheSameSurvey()
    {
        var seeded = await SeedSurvey();

        var first = await _service.SubmitSurvey(UserId, ValidSubmission(seeded));
        var second = await _service.SubmitSurvey(OtherUserId, ValidSubmission(seeded));

        using (Assert.EnterMultipleScope())
        {
            Assert.That(first.IsSuccess, Is.True, first.Message);
            Assert.That(second.IsSuccess, Is.True, second.Message);
            Assert.That(await ResponseCount(), Is.EqualTo(2));
        }
    }

    [Test]
    public async Task Submit_Rejects_ASurveyTheUserRefused()
    {
        var seeded = await SeedSurvey();
        await _service.RefuseSurvey(UserId, seeded.SurveyId);

        await AssertRejectedWithNothingStored(ValidSubmission(seeded), SurveyErrorCodes.AlreadyRefused);
    }

    #endregion

    #region Refuse

    [Test]
    public async Task Refuse_HidesTheSurveyWithoutRecordingAResponse()
    {
        var seeded = await SeedSurvey();

        var result = await _service.RefuseSurvey(UserId, seeded.SurveyId);

        using var context = DbContextFactory.CreateDbContext();
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSuccess, Is.True, result.Message);
            Assert.That(result.Reason.Code, Is.EqualTo(SurveyErrorCodes.Refused));
            Assert.That(await context.SurveyResponses.CountAsync(), Is.Zero);
            Assert.That(await context.SurveyRefusals.CountAsync(r => r.SurveyId == seeded.SurveyId && r.AppUserId == UserId), Is.EqualTo(1));
        }
    }

    [Test]
    public async Task Refuse_Twice_RecordsOneRefusalAndReturnsFailureTheSecondTime()
    {
        var seeded = await SeedSurvey();

        await _service.RefuseSurvey(UserId, seeded.SurveyId);
        var second = await _service.RefuseSurvey(UserId, seeded.SurveyId);

        using var context = DbContextFactory.CreateDbContext();
        using (Assert.EnterMultipleScope())
        {
            Assert.That(second.IsSuccess, Is.False);
            Assert.That(await context.SurveyRefusals.CountAsync(), Is.EqualTo(1));
        }
    }

    [Test]
    public async Task Refuse_Rejects_ASurveyTheUserAlreadySubmitted()
    {
        var seeded = await SeedSurvey();
        await _service.SubmitSurvey(UserId, ValidSubmission(seeded));

        var result = await _service.RefuseSurvey(UserId, seeded.SurveyId);

        using var context = DbContextFactory.CreateDbContext();
        using (Assert.EnterMultipleScope())
        {
            AssertFailure(result, SurveyErrorCodes.AlreadySubmitted);
            Assert.That(await context.SurveyRefusals.CountAsync(), Is.Zero);
        }
    }

    [TestCase(SurveyStatus.Draft)]
    [TestCase(SurveyStatus.Inactive)]
    public async Task Refuse_Rejects_ASurveyThatIsNotActive(SurveyStatus status)
    {
        var seeded = await SeedSurvey(status);

        var result = await _service.RefuseSurvey(UserId, seeded.SurveyId);

        AssertFailure(result, SurveyErrorCodes.Unavailable);
    }

    [Test]
    public async Task Refuse_Rejects_ASurveyThatDoesNotExist()
    {
        var result = await _service.RefuseSurvey(UserId, 424_242);

        AssertFailure(result, SurveyErrorCodes.Unavailable);
    }

    [Test]
    public async Task Refuse_OnlyAffectsTheUserWhoRefused()
    {
        var seeded = await SeedSurvey();
        await _service.RefuseSurvey(UserId, seeded.SurveyId);

        var otherSubmit = await _service.SubmitSurvey(OtherUserId, ValidSubmission(seeded));

        Assert.That(otherSubmit.IsSuccess, Is.True, otherSubmit.Message);
    }

    #endregion
}
