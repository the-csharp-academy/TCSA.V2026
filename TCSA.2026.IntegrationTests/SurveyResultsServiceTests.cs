using Microsoft.EntityFrameworkCore;
using TCSA.V2026.Data;
using TCSA.V2026.Data.DTOs;
using TCSA.V2026.Data.Enums;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Helpers.Constants;
using TCSA.V2026.Services;

namespace TCSA.V2026.IntegrationTests;

[TestFixture]
public class SurveyResultsServiceTests : IntegrationTestsBase
{
    private const string MarkupText = "Great <script>alert(1)</script> & <b>bold</b>";

    private SurveyResultsService _service;

    [SetUp]
    public void Setup()
    {
        BaseSetup();
        _service = new SurveyResultsService(DbContextFactory);
    }

    [TearDown]
    public void TearDown()
    {
        BaseTearDown();
    }

    private record Seeded(
        int SurveyId,
        int RatingId,
        int SingleId, int[] SingleOptions,
        int MultiId, int[] MultiOptions,
        int FreeTextId,
        int YesNoId);

    private static async Task<Seeded> SeedSurvey(
        IDbContextFactory<ApplicationDbContext> factory, SurveyStatus status = SurveyStatus.Active, string title = "Course feedback")
    {
        using var context = factory.CreateDbContext();
        var survey = new Survey
        {
            Title = title,
            Description = "Tell us how it went",
            Status = status,
            CreatedAt = DateTimeOffset.UtcNow,
            Questions =
            [
                RatingQuestion.Create("Rate it", true, 0),
                SingleChoiceQuestion.Create("Best part?", false, 1, ["A", "B", "C"]),
                MultipleChoiceQuestion.Create("Which topics?", true, 2, ["X", "Y", "Z"]),
                FreeTextQuestion.Create("Anything else?", false, 3),
                YesNoQuestion.Create("Recommend it?", false, 4)
            ]
        };
        context.Surveys.Add(survey);
        await context.SaveChangesAsync();

        var questions = await context.SurveyQuestions.AsNoTracking()
            .Include(q => ((ChoiceQuestion)q).Options)
            .Where(q => q.SurveyId == survey.Id)
            .OrderBy(q => q.Order)
            .ToListAsync();
        int[] OptionIds(int index) => [.. ((ChoiceQuestion)questions[index]).Options.OrderBy(o => o.Order).Select(o => o.Id)];

        return new Seeded(survey.Id, questions[0].Id, questions[1].Id, OptionIds(1), questions[2].Id, OptionIds(2), questions[3].Id, questions[4].Id);
    }

    private async Task<int> Respond(
        Seeded s, string userId, int rating, int? single, int[] multi, string? freeText, bool? yes, DateTimeOffset? submittedAt = null)
    {
        using var context = DbContextFactory.CreateDbContext();
        var answers = new List<SurveyAnswer>
        {
            RatingAnswer.Create(s.RatingId, rating),
            MultipleChoiceAnswer.Create(s.MultiId, multi.Select(i => s.MultiOptions[i]))
        };
        if (single is { } option) answers.Add(SingleChoiceAnswer.Create(s.SingleId, s.SingleOptions[option]));
        if (freeText is not null) answers.Add(FreeTextAnswer.Create(s.FreeTextId, freeText));
        if (yes is { } isYes) answers.Add(YesNoAnswer.Create(s.YesNoId, isYes));

        var response = new SurveyResponse
        {
            SurveyId = s.SurveyId,
            AppUserId = userId,
            SubmittedAt = submittedAt ?? DateTimeOffset.UtcNow,
            Answers = answers
        };
        context.SurveyResponses.Add(response);
        await context.SaveChangesAsync();
        return response.Id;
    }

    private async Task<Seeded> SeedKnownResponses(SurveyStatus status = SurveyStatus.Active)
    {
        var s = await SeedSurvey(DbContextFactory, status);
        await Respond(s, "user1", 5, 0, [0, 1], MarkupText, true);
        await Respond(s, "user2", 4, 0, [0], null, false);
        await Respond(s, "orangeuser", 4, 1, [1, 2], "Loved it", null);
        await Respond(s, "purpleuser", 1, null, [0], null, null);
        return s;
    }

    private static QuestionResultDto Question(SurveyResultsDto results, int id) => results.Questions.Single(q => q.QuestionId == id);

    private static int[] Counts(QuestionResultDto question) => [.. question.Buckets.Select(b => b.Count)];

    [Test]
    public async Task GetResults_ReturnsTheSurveyHeaderAndTheResponseCount()
    {
        var s = await SeedKnownResponses();

        var results = await _service.GetResults(s.SurveyId);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(results, Is.Not.Null);
            Assert.That(results!.Id, Is.EqualTo(s.SurveyId));
            Assert.That(results.Title, Is.EqualTo("Course feedback"));
            Assert.That(results.Description, Is.EqualTo("Tell us how it went"));
            Assert.That(results.Status, Is.EqualTo(SurveyStatus.Active));
            Assert.That(results.ResponseCount, Is.EqualTo(4));
        }
    }

    [Test]
    public async Task GetResults_ListsEveryQuestionInOrder_WithItsTypeAndRequiredFlag()
    {
        var s = await SeedKnownResponses();

        var results = await _service.GetResults(s.SurveyId);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(results!.Questions.Select(q => q.QuestionId), Is.EqualTo(new[] { s.RatingId, s.SingleId, s.MultiId, s.FreeTextId, s.YesNoId }));
            Assert.That(results.Questions.Select(q => q.Type), Is.EqualTo(new[]
            {
                SurveyQuestionType.Rating, SurveyQuestionType.SingleChoice, SurveyQuestionType.MultipleChoice,
                SurveyQuestionType.FreeText, SurveyQuestionType.YesNo
            }));
            Assert.That(results.Questions.Select(q => q.IsRequired), Is.EqualTo(new[] { true, false, true, false, false }));
            Assert.That(results.Questions[0].Text, Is.EqualTo("Rate it"));
            Assert.That(results.RequiredQuestionCount, Is.EqualTo(2));
        }
    }

    [Test]
    public async Task GetResults_Rating_ReportsTheAverageAndAOneToFiveDistribution()
    {
        var s = await SeedKnownResponses();

        var rating = Question(await _service.GetResults(s.SurveyId) ?? throw new AssertionException("no results"), s.RatingId);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(rating.AnswerCount, Is.EqualTo(4));
            Assert.That(rating.Average, Is.EqualTo(3.5).Within(0.001));
            Assert.That(rating.Buckets.Select(b => b.Label), Is.EqualTo(new[] { "1", "2", "3", "4", "5" }));
            Assert.That(Counts(rating), Is.EqualTo(new[] { 1, 0, 0, 2, 1 }));
            Assert.That(rating.Buckets.Select(b => b.Percentage), Is.EqualTo(new[] { 25.0, 0, 0, 50, 25 }).Within(0.001));
        }
    }

    [Test]
    public async Task GetResults_SingleChoice_CountsEachOption_AndSkippedAnswersLeaveThePercentageBase()
    {
        var s = await SeedKnownResponses();

        var single = Question((await _service.GetResults(s.SurveyId))!, s.SingleId);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(single.AnswerCount, Is.EqualTo(3), "one respondent skipped this optional question");
            Assert.That(single.Buckets.Select(b => b.Label), Is.EqualTo(new[] { "A", "B", "C" }));
            Assert.That(Counts(single), Is.EqualTo(new[] { 2, 1, 0 }));
            Assert.That(single.Buckets.Select(b => b.Percentage), Is.EqualTo(new[] { 200.0 / 3, 100.0 / 3, 0 }).Within(0.001));
            Assert.That(single.Average, Is.Null);
        }
    }

    [Test]
    public async Task GetResults_MultipleChoice_CountsEachPickedOption_AndPercentagesCanExceedOneHundred()
    {
        var s = await SeedKnownResponses();

        var multi = Question((await _service.GetResults(s.SurveyId))!, s.MultiId);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(multi.AnswerCount, Is.EqualTo(4));
            Assert.That(multi.Buckets.Select(b => b.Label), Is.EqualTo(new[] { "X", "Y", "Z" }));
            Assert.That(Counts(multi), Is.EqualTo(new[] { 3, 2, 1 }));
            Assert.That(multi.Buckets.Select(b => b.Percentage), Is.EqualTo(new[] { 75.0, 50, 25 }).Within(0.001));
            Assert.That(multi.Buckets.Sum(b => b.Percentage), Is.GreaterThan(100));
        }
    }

    [Test]
    public async Task GetResults_YesNo_CountsYesAndNo_AndIgnoresSkippedAnswers()
    {
        var s = await SeedKnownResponses();

        var yesNo = Question((await _service.GetResults(s.SurveyId))!, s.YesNoId);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(yesNo.AnswerCount, Is.EqualTo(2));
            Assert.That(yesNo.Buckets.Select(b => b.Label), Is.EqualTo(new[] { "Yes", "No" }));
            Assert.That(Counts(yesNo), Is.EqualTo(new[] { 1, 1 }));
            Assert.That(yesNo.Buckets.Select(b => b.Percentage), Is.EqualTo(new[] { 50.0, 50 }).Within(0.001));
        }
    }

    [Test]
    public async Task GetResults_FreeText_CountsAnswersButLeavesTheTextToThePagedList()
    {
        var s = await SeedKnownResponses();

        var freeText = Question((await _service.GetResults(s.SurveyId))!, s.FreeTextId);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(freeText.AnswerCount, Is.EqualTo(2));
            Assert.That(freeText.Buckets, Is.Empty);
            Assert.That(freeText.Average, Is.Null);
        }
    }

    [Test]
    public async Task GetResults_StillWorksAfterTheSurveyIsDeactivated()
    {
        var s = await SeedKnownResponses(SurveyStatus.Inactive);

        var results = await _service.GetResults(s.SurveyId);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(results, Is.Not.Null);
            Assert.That(results!.Status, Is.EqualTo(SurveyStatus.Inactive));
            Assert.That(results.ResponseCount, Is.EqualTo(4));
            Assert.That(Question(results, s.RatingId).Average, Is.EqualTo(3.5).Within(0.001));
        }
    }

    [Test]
    public async Task GetResults_ForASurveyWithNoResponses_ReturnsZeroesWithoutDividingByZero()
    {
        var s = await SeedSurvey(DbContextFactory);

        var results = await _service.GetResults(s.SurveyId);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(results!.ResponseCount, Is.Zero);
            Assert.That(results.Questions, Has.Count.EqualTo(5));
            Assert.That(results.Questions.Select(q => q.AnswerCount), Is.All.Zero);
            Assert.That(Question(results, s.RatingId).Average, Is.Null);
            Assert.That(Counts(Question(results, s.RatingId)), Is.EqualTo(new[] { 0, 0, 0, 0, 0 }));
            Assert.That(Counts(Question(results, s.SingleId)), Is.EqualTo(new[] { 0, 0, 0 }));
            Assert.That(Counts(Question(results, s.YesNoId)), Is.EqualTo(new[] { 0, 0 }));
            Assert.That(results.Questions.SelectMany(q => q.Buckets).Select(b => b.Percentage), Is.All.Zero);
        }
    }

    [Test]
    public async Task GetResults_ForAMissingSurvey_ReturnsNull()
    {
        Assert.That(await _service.GetResults(404), Is.Null);
    }

    [Test]
    public async Task GetResults_DoesNotMixInAnotherSurveysResponses()
    {
        var s = await SeedKnownResponses();
        var other = await SeedSurvey(DbContextFactory, title: "Other");
        await Respond(other, "user1", 1, 2, [2], "Other text", false);
        await Respond(other, "user2", 1, 2, [2], null, false);

        var results = await _service.GetResults(s.SurveyId);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(results!.ResponseCount, Is.EqualTo(4));
            Assert.That(Question(results, s.RatingId).Average, Is.EqualTo(3.5).Within(0.001));
            Assert.That(Counts(Question(results, s.SingleId)), Is.EqualTo(new[] { 2, 1, 0 }));
            Assert.That(Counts(Question(results, s.YesNoId)), Is.EqualTo(new[] { 1, 1 }));
        }
    }

    [Test]
    public async Task GetFreeTextAnswers_ListsEachAnswerWithItsAuthor_NewestFirst()
    {
        var s = await SeedSurvey(DbContextFactory);
        var now = DateTimeOffset.UtcNow;
        await Respond(s, "user1", 5, 0, [0], "Older", null, now.AddHours(-2));
        await Respond(s, "user2", 5, 0, [0], MarkupText, null, now.AddHours(-1));
        await Respond(s, "orangeuser", 5, 0, [0], null, null, now);

        var page = await _service.GetFreeTextAnswers(s.FreeTextId, 1);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(page.TotalItems, Is.EqualTo(2), "a skipped free-text answer is not listed");
            Assert.That(page.Items.Select(i => i.Text), Is.EqualTo(new[] { MarkupText, "Older" }));
            Assert.That(page.Items.Select(i => i.AuthorLabel), Is.EqualTo(new[] { "testuser2", "testuser" }));
            Assert.That(page.Items.Select(i => i.UserId), Is.EqualTo(new[] { "user2", "user1" }));
        }
    }

    [Test]
    public async Task GetFreeTextAnswers_ReturnsTextVerbatim_SoThePageCanRenderItInert()
    {
        var s = await SeedSurvey(DbContextFactory);
        await Respond(s, "user1", 5, 0, [0], MarkupText, null);

        var page = await _service.GetFreeTextAnswers(s.FreeTextId, 1);

        Assert.That(page.Items.Single().Text, Is.EqualTo(MarkupText));
    }

    [Test]
    public async Task GetFreeTextAnswers_PagesTheAnswers()
    {
        var s = await SeedSurvey(DbContextFactory);
        var users = await AddUsers(PagingConstants.SurveyFreeTextPageSize + 1);
        var start = DateTimeOffset.UtcNow.AddDays(-1);
        for (var i = 0; i < users.Count; i++)
        {
            await Respond(s, users[i], 3, 0, [0], $"Answer {i}", null, start.AddMinutes(i));
        }

        var first = await _service.GetFreeTextAnswers(s.FreeTextId, 1);
        var second = await _service.GetFreeTextAnswers(s.FreeTextId, 2);
        var beyond = await _service.GetFreeTextAnswers(s.FreeTextId, 3);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(first.TotalItems, Is.EqualTo(PagingConstants.SurveyFreeTextPageSize + 1));
            Assert.That(first.TotalPages, Is.EqualTo(2));
            Assert.That(first.PageSize, Is.EqualTo(PagingConstants.SurveyFreeTextPageSize));
            Assert.That(first.Items, Has.Count.EqualTo(PagingConstants.SurveyFreeTextPageSize));
            Assert.That(first.Items[0].Text, Is.EqualTo($"Answer {PagingConstants.SurveyFreeTextPageSize}"));
            Assert.That(second.Items.Select(i => i.Text), Is.EqualTo(new[] { "Answer 0" }));
            Assert.That(beyond.Items, Is.Empty);
        }
    }

    [Test]
    public async Task GetFreeTextAnswers_TreatsAPageBelowOneAsTheFirstPage()
    {
        var s = await SeedSurvey(DbContextFactory);
        await Respond(s, "user1", 5, 0, [0], "Only one", null);

        var page = await _service.GetFreeTextAnswers(s.FreeTextId, 0);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(page.PageNumber, Is.EqualTo(1));
            Assert.That(page.Items, Has.Count.EqualTo(1));
        }
    }

    [Test]
    public async Task GetFreeTextAnswers_ForAQuestionThatIsNotFreeText_ReturnsAnEmptyPage()
    {
        var s = await SeedKnownResponses();

        var page = await _service.GetFreeTextAnswers(s.RatingId, 1);

        Assert.That(page.Items, Is.Empty);
    }

    [Test]
    public async Task GetRespondents_ListsNameEmailAndSubmittedDate_NewestFirst()
    {
        var s = await SeedSurvey(DbContextFactory);
        var older = new DateTimeOffset(2026, 9, 1, 10, 0, 0, TimeSpan.Zero);
        var newer = new DateTimeOffset(2026, 9, 2, 10, 0, 0, TimeSpan.Zero);
        await Respond(s, "user1", 5, 0, [0], null, null, older);
        await Respond(s, "user2", 4, 0, [0], null, null, newer);

        var page = await _service.GetRespondents(s.SurveyId, 1);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(page.TotalItems, Is.EqualTo(2));
            Assert.That(page.Items.Select(r => r.UserId), Is.EqualTo(new[] { "user2", "user1" }));
            Assert.That(page.Items.Select(r => r.Label), Is.EqualTo(new[] { "testuser2", "testuser" }));
            Assert.That(page.Items.Select(r => r.Email), Is.EqualTo(new[] { "test2@test.com", "test@test.com" }));
            Assert.That(page.Items.Select(r => r.SubmittedAt), Is.EqualTo(new[] { newer, older }));
            Assert.That(page.Items.All(r => r.ResponseId > 0), Is.True);
        }
    }

    [Test]
    public async Task GetRespondents_OnlyIncludesThisSurveysRespondents_AndWorksWhenInactive()
    {
        var s = await SeedSurvey(DbContextFactory, SurveyStatus.Inactive);
        var other = await SeedSurvey(DbContextFactory, title: "Other");
        await Respond(s, "user1", 5, 0, [0], null, null);
        await Respond(other, "user2", 5, 0, [0], null, null);

        var page = await _service.GetRespondents(s.SurveyId, 1);

        Assert.That(page.Items.Select(r => r.UserId), Is.EqualTo(new[] { "user1" }));
    }

    [Test]
    public async Task GetRespondents_PagesTheList()
    {
        var s = await SeedSurvey(DbContextFactory);
        var users = await AddUsers(PagingConstants.SurveyRespondentsPageSize + 3);
        var start = DateTimeOffset.UtcNow.AddDays(-1);
        for (var i = 0; i < users.Count; i++)
        {
            await Respond(s, users[i], 3, 0, [0], null, null, start.AddMinutes(i));
        }

        var first = await _service.GetRespondents(s.SurveyId, 1);
        var second = await _service.GetRespondents(s.SurveyId, 2);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(first.TotalItems, Is.EqualTo(PagingConstants.SurveyRespondentsPageSize + 3));
            Assert.That(first.Items, Has.Count.EqualTo(PagingConstants.SurveyRespondentsPageSize));
            Assert.That(second.Items, Has.Count.EqualTo(3));
        }
    }

    [Test]
    public async Task GetRespondentAnswers_ReturnsTheFullAnswerSet_InQuestionOrder()
    {
        var s = await SeedSurvey(DbContextFactory);
        var responseId = await Respond(s, "user1", 5, 1, [0, 2], MarkupText, true);

        var result = await _service.GetRespondentAnswers(responseId);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(result!.Respondent.UserId, Is.EqualTo("user1"));
            Assert.That(result.Respondent.Email, Is.EqualTo("test@test.com"));
            Assert.That(result.Answers.Select(a => a.QuestionId), Is.EqualTo(new[] { s.RatingId, s.SingleId, s.MultiId, s.FreeTextId, s.YesNoId }));
            Assert.That(result.Answers.Select(a => a.QuestionText), Is.EqualTo(new[] { "Rate it", "Best part?", "Which topics?", "Anything else?", "Recommend it?" }));
            Assert.That(result.Answers.Select(a => a.Answer), Is.EqualTo(new[] { "5 of 5", "B", "X, Z", MarkupText, "Yes" }));
            Assert.That(result.Answers.Any(a => a.Skipped), Is.False);
        }
    }

    [Test]
    public async Task GetRespondentAnswers_MarksSkippedOptionalQuestions()
    {
        var s = await SeedSurvey(DbContextFactory);
        var responseId = await Respond(s, "user1", 2, null, [1], null, null);

        var result = await _service.GetRespondentAnswers(responseId);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result!.Answers, Has.Count.EqualTo(5), "every question is listed, answered or not");
            Assert.That(result.Answers.Select(a => a.Skipped), Is.EqualTo(new[] { false, true, false, true, true }));
            Assert.That(result.Answers.Select(a => a.IsRequired), Is.EqualTo(new[] { true, false, true, false, false }));
        }
    }

    [Test]
    public async Task GetRespondentAnswers_ForAMissingResponse_ReturnsNull()
    {
        Assert.That(await _service.GetRespondentAnswers(404), Is.Null);
    }

    private async Task<List<string>> AddUsers(int count)
    {
        using var context = DbContextFactory.CreateDbContext();
        var users = Enumerable.Range(0, count)
            .Select(i => new ApplicationUser
            {
                Id = $"extra{i}",
                UserName = $"extra{i}",
                Email = $"extra{i}@test.com",
                FirstName = "Extra",
                LastName = $"User{i}",
                Country = "Testland"
            })
            .ToList();
        context.AspNetUsers.AddRange(users);
        await context.SaveChangesAsync();
        return [.. users.Select(u => u.Id)];
    }
}
