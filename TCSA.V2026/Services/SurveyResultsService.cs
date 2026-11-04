using Microsoft.EntityFrameworkCore;
using TCSA.V2026.Data;
using TCSA.V2026.Data.DTOs;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Data.Models.Responses;
using TCSA.V2026.Helpers;
using TCSA.V2026.Helpers.Constants;
using TCSA.V2026.Helpers.SurveyQuestions;

namespace TCSA.V2026.Services;

public interface ISurveyResultsService
{
    Task<SurveyResultsDto?> GetResults(int surveyId);
    Task<PaginatedList<FreeTextResultDto>> GetFreeTextAnswers(int questionId, int pageNumber);
    Task<PaginatedList<SurveyRespondentDto>> GetRespondents(int surveyId, int pageNumber);
    Task<RespondentAnswersDto?> GetRespondentAnswers(int responseId);
}

public class SurveyResultsService(IDbContextFactory<ApplicationDbContext> _factory) : ISurveyResultsService
{
    public async Task<SurveyResultsDto?> GetResults(int surveyId)
    {
        using var context = _factory.CreateDbContext();

        var survey = await context.Surveys
            .AsNoTracking()
            .Include(s => s.Questions).ThenInclude(q => ((ChoiceQuestion)q).Options)
            .FirstOrDefaultAsync(s => s.Id == surveyId);

        if (survey is null)
        {
            return null;
        }

        var responseCountTask = context.SurveyResponses.CountAsync(r => r.SurveyId == surveyId);

        var answerCountsTask = CountAnswersPerQuestion(surveyId);
        var ratingsTask = CountRatings(surveyId);
        var yesNosTask = CountYesNos(surveyId);
        var optionsTask = CountPickedOptions(surveyId);

        await Task.WhenAll(responseCountTask, answerCountsTask, ratingsTask, yesNosTask, optionsTask);

        var questions = survey.Questions.OrderBy(q => q.Order).Select(question =>
        {
            var answerCount = answerCountsTask.Result.GetValueOrDefault(question.Id);
            var result = new QuestionResultDto
            {
                QuestionId = question.Id,
                Text = question.Text,
                Type = question.Type,
                IsRequired = question.IsRequired,
                AnswerCount = answerCount
            };

            switch (question)
            {
                case RatingQuestion:
                    var byRating = ratingsTask.Result.GetValueOrDefault(question.Id) ?? [];
                    result.Buckets = [.. Enumerable.Range(SurveyLimits.MinRating, SurveyLimits.MaxRating - SurveyLimits.MinRating + 1)
                        .Select(rating => Bucket(rating.ToString(), byRating.GetValueOrDefault(rating), answerCount))];
                    result.Average = answerCount == 0 ? null : (double)byRating.Sum(r => r.Key * r.Value) / answerCount;
                    break;

                case YesNoQuestion:
                    var byAnswer = yesNosTask.Result.GetValueOrDefault(question.Id) ?? [];
                    result.Buckets =
                    [
                        Bucket("Yes", byAnswer.GetValueOrDefault(true), answerCount),
                        Bucket("No", byAnswer.GetValueOrDefault(false), answerCount)
                    ];
                    break;

                case ChoiceQuestion choice:
                    result.Buckets = [.. choice.Options.OrderBy(o => o.Order)
                        .Select(o => Bucket(o.Text, optionsTask.Result.GetValueOrDefault(o.Id), answerCount))];
                    break;
            }

            return result;
        });

        return new SurveyResultsDto
        {
            Id = survey.Id,
            Title = survey.Title,
            Description = survey.Description,
            Status = survey.Status,
            ResponseCount = responseCountTask.Result,
            Questions = [.. questions]
        };
    }

    public async Task<PaginatedList<FreeTextResultDto>> GetFreeTextAnswers(int questionId, int pageNumber)
    {
        var page = Math.Max(1, pageNumber);
        using var context = _factory.CreateDbContext();

        var answers = context.SurveyAnswers
            .AsNoTracking()
            .OfType<FreeTextAnswer>()
            .Where(a => a.SurveyQuestionId == questionId);

        var total = await answers.CountAsync();

        var items = await answers
            .OrderByDescending(a => a.Response.SubmittedAt)
            .ThenByDescending(a => a.Id)
            .Skip((page - 1) * PagingConstants.SurveyFreeTextPageSize)
            .Take(PagingConstants.SurveyFreeTextPageSize)
            .Select(a => new FreeTextResultDto
            {
                ResponseId = a.SurveyResponseId,
                UserId = a.Response.AppUserId,
                UserName = a.Response.AppUser.UserName ?? string.Empty,
                UserDisplayName = a.Response.AppUser.DisplayName,
                Text = a.Text,
                SubmittedAt = a.Response.SubmittedAt
            })
            .ToListAsync();

        return new PaginatedList<FreeTextResultDto>(items, total, page, PagingConstants.SurveyFreeTextPageSize);
    }

    public async Task<PaginatedList<SurveyRespondentDto>> GetRespondents(int surveyId, int pageNumber)
    {
        var page = Math.Max(1, pageNumber);
        using var context = _factory.CreateDbContext();

        var responses = context.SurveyResponses
            .AsNoTracking()
            .Where(r => r.SurveyId == surveyId);

        var total = await responses.CountAsync();

        var items = await responses
            .OrderByDescending(r => r.SubmittedAt)
            .ThenByDescending(r => r.Id)
            .Skip((page - 1) * PagingConstants.SurveyRespondentsPageSize)
            .Take(PagingConstants.SurveyRespondentsPageSize)
            .Select(r => new SurveyRespondentDto
            {
                ResponseId = r.Id,
                UserId = r.AppUserId,
                UserName = r.AppUser.UserName ?? string.Empty,
                UserDisplayName = r.AppUser.DisplayName,
                Email = r.AppUser.Email ?? string.Empty,
                SubmittedAt = r.SubmittedAt
            })
            .ToListAsync();

        return new PaginatedList<SurveyRespondentDto>(items, total, page, PagingConstants.SurveyRespondentsPageSize);
    }

    public async Task<RespondentAnswersDto?> GetRespondentAnswers(int responseId)
    {
        using var context = _factory.CreateDbContext();

        var response = await context.SurveyResponses
            .AsNoTracking()
            .Include(r => r.AppUser)
            .Include(r => r.Answers).ThenInclude(a => ((ChoiceAnswer)a).SelectedOptions)
            .FirstOrDefaultAsync(r => r.Id == responseId);

        if (response is null)
        {
            return null;
        }

        var survey = await context.Surveys
            .AsNoTracking()
            .Include(s => s.Questions).ThenInclude(q => ((ChoiceQuestion)q).Options)
            .FirstAsync(s => s.Id == response.SurveyId);

        var byQuestion = response.Answers.ToDictionary(a => a.SurveyQuestionId);

        return new RespondentAnswersDto
        {
            Respondent = new SurveyRespondentDto
            {
                ResponseId = response.Id,
                UserId = response.AppUserId,
                UserName = response.AppUser.UserName ?? string.Empty,
                UserDisplayName = response.AppUser.DisplayName,
                Email = response.AppUser.Email ?? string.Empty,
                SubmittedAt = response.SubmittedAt
            },
            Answers = [.. survey.ToDto().Questions.Select(question => new RespondentAnswerDto
            {
                QuestionId = question.Id,
                QuestionText = question.Text,
                Type = question.Type,
                IsRequired = question.IsRequired,
                Answer = byQuestion.TryGetValue(question.Id, out var answer)
                    ? SurveyQuestionRegistry.Get(question.Type).DescribeAnswer(question, answer.ToDto())
                    : null
            })]
        };
    }

    private static ResultBucketDto Bucket(string label, int count, int answerCount) => new()
    {
        Label = label,
        Count = count,
        Percentage = answerCount == 0 ? 0 : count * 100.0 / answerCount
    };

    private async Task<Dictionary<int, int>> CountAnswersPerQuestion(int surveyId)
    {
        using var context = _factory.CreateDbContext();

        return await context.SurveyAnswers
            .Where(a => a.Question.SurveyId == surveyId)
            .GroupBy(a => a.SurveyQuestionId)
            .Select(g => new { QuestionId = g.Key, Count = g.Count() })
            .ToDictionaryAsync(x => x.QuestionId, x => x.Count);
    }

    private async Task<Dictionary<int, Dictionary<int, int>>> CountRatings(int surveyId)
    {
        using var context = _factory.CreateDbContext();

        var rows = await context.SurveyAnswers
            .OfType<RatingAnswer>()
            .Where(a => a.Question.SurveyId == surveyId)
            .GroupBy(a => new { a.SurveyQuestionId, a.Rating })
            .Select(g => new { g.Key.SurveyQuestionId, g.Key.Rating, Count = g.Count() })
            .ToListAsync();

        return rows.GroupBy(r => r.SurveyQuestionId)
            .ToDictionary(g => g.Key, g => g.ToDictionary(r => r.Rating, r => r.Count));
    }

    private async Task<Dictionary<int, Dictionary<bool, int>>> CountYesNos(int surveyId)
    {
        using var context = _factory.CreateDbContext();

        var rows = await context.SurveyAnswers
            .OfType<YesNoAnswer>()
            .Where(a => a.Question.SurveyId == surveyId)
            .GroupBy(a => new { a.SurveyQuestionId, a.IsYes })
            .Select(g => new { g.Key.SurveyQuestionId, g.Key.IsYes, Count = g.Count() })
            .ToListAsync();

        return rows.GroupBy(r => r.SurveyQuestionId)
            .ToDictionary(g => g.Key, g => g.ToDictionary(r => r.IsYes, r => r.Count));
    }

    private async Task<Dictionary<int, int>> CountPickedOptions(int surveyId)
    {
        using var context = _factory.CreateDbContext();
        return await context.SurveyAnswerOptions
            .Where(o => o.Answer.Question.SurveyId == surveyId)
            .GroupBy(o => o.SurveyOptionId)
            .Select(g => new { OptionId = g.Key, Count = g.Count() })
            .ToDictionaryAsync(x => x.OptionId, x => x.Count);
    }
}
