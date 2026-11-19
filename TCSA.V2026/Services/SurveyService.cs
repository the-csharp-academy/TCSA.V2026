using Microsoft.EntityFrameworkCore;
using TCSA.V2026.Data;
using TCSA.V2026.Data.DTOs;
using TCSA.V2026.Data.Enums;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Data.Models.Responses;
using TCSA.V2026.Helpers;
using TCSA.V2026.Helpers.Constants;
using TCSA.V2026.Helpers.SurveyQuestions;

namespace TCSA.V2026.Services;

public interface ISurveyService
{
    Task<List<AvailableSurveyDto>> GetAvailableSurveys(string userId);
    Task<int> GetAvailableCount(string userId);
    Task<Result> SubmitSurvey(string userId, SurveySubmissionDto submission);
    Task<Result> RefuseSurvey(string userId, int surveyId);
}

public class SurveyService(IDbContextFactory<ApplicationDbContext> _factory, ILogger<SurveyService> _logger) : ISurveyService
{
    public async Task<List<AvailableSurveyDto>> GetAvailableSurveys(string userId)
    {
        if (string.IsNullOrWhiteSpace(userId))
        {
            return [];
        }

        using var context = _factory.CreateDbContext();

        var surveys = await AvailableTo(context, userId)
            .AsNoTracking()
            .Include(s => s.Questions).ThenInclude(q => ((ChoiceQuestion)q).Options)
            .OrderByDescending(s => s.CreatedAt)
            .ThenByDescending(s => s.Id)
            .ToListAsync();

        return [.. surveys.Select(s => s.ToDto())];
    }

    public async Task<int> GetAvailableCount(string userId)
    {
        if (string.IsNullOrWhiteSpace(userId))
        {
            return 0;
        }

        using var context = _factory.CreateDbContext();

        return await AvailableTo(context, userId).CountAsync();
    }

    public async Task<Result> SubmitSurvey(string userId, SurveySubmissionDto submission)
    {
        if (submission is null || string.IsNullOrWhiteSpace(userId))
        {
            return Result.Failure(SurveyErrors.Unavailable);
        }

        try
        {
            using var context = _factory.CreateDbContext();

            var survey = await context.Surveys
                .AsNoTracking()
                .Include(s => s.Questions).ThenInclude(q => ((ChoiceQuestion)q).Options)
                .FirstOrDefaultAsync(s => s.Id == submission.SurveyId);

            if (survey is null || survey.Status != SurveyStatus.Active)
            {
                return Result.Failure(SurveyErrors.Unavailable);
            }

            var earlier = await FindEarlierDecision(context, userId, survey.Id);
            if (earlier is not null)
            {
                return Result.Failure(earlier);
            }

            var invalid = ValidateAndBuildAnswers(survey, submission, out var answers);
            if (invalid is not null)
            {
                return Result.Failure(invalid);
            }

            context.SurveyResponses.Add(new SurveyResponse
            {
                SurveyId = survey.Id,
                AppUserId = userId,
                SubmittedAt = DateTimeOffset.UtcNow,
                Answers = answers
            });

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                context.ChangeTracker.Clear();
                if (await context.SurveyResponses.AnyAsync(r => r.SurveyId == survey.Id && r.AppUserId == userId))
                {
                    return Result.Failure(SurveyErrors.AlreadySubmitted);
                }

                throw;
            }

            return Result.Success(new Success(SurveyErrorCodes.Submitted, "Thanks for your feedback!"));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to submit survey {SurveyId} for user {UserId}", submission.SurveyId, userId);
            return Result.Failure(SurveyErrors.Unexpected("sending your answers"));
        }
    }

    public async Task<Result> RefuseSurvey(string userId, int surveyId)
    {
        if (string.IsNullOrWhiteSpace(userId))
        {
            return Result.Failure(SurveyErrors.Unavailable);
        }

        try
        {
            using var context = _factory.CreateDbContext();

            var isActive = await context.Surveys.AnyAsync(s => s.Id == surveyId && s.Status == SurveyStatus.Active);
            if (!isActive)
            {
                return Result.Failure(SurveyErrors.Unavailable);
            }

            var earlier = await FindEarlierDecision(context, userId, surveyId);
            if (earlier is not null)
            {
                return Result.Failure(earlier);
            }

            context.SurveyRefusals.Add(new SurveyRefusal
            {
                SurveyId = surveyId,
                AppUserId = userId,
                RefusedAt = DateTimeOffset.UtcNow
            });

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                context.ChangeTracker.Clear();
                if (await context.SurveyRefusals.AnyAsync(r => r.SurveyId == surveyId && r.AppUserId == userId))
                {
                    return Result.Failure(SurveyErrors.AlreadyRefused);
                }

                throw;
            }

            return Result.Success(new Success(SurveyErrorCodes.Refused, "You won't see this survey again."));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to refuse survey {SurveyId} for user {UserId}", surveyId, userId);
            return Result.Failure(SurveyErrors.Unexpected("hiding the survey"));
        }
    }

    private static IQueryable<Survey> AvailableTo(ApplicationDbContext context, string userId) =>
        context.Surveys.Where(s =>
            s.Status == SurveyStatus.Active &&
            !context.SurveyResponses.Any(r => r.SurveyId == s.Id && r.AppUserId == userId) &&
            !context.SurveyRefusals.Any(r => r.SurveyId == s.Id && r.AppUserId == userId));

    private static async Task<Error?> FindEarlierDecision(ApplicationDbContext context, string userId, int surveyId)
    {
        if (await context.SurveyResponses.AnyAsync(r => r.SurveyId == surveyId && r.AppUserId == userId))
        {
            return SurveyErrors.AlreadySubmitted;
        }

        if (await context.SurveyRefusals.AnyAsync(r => r.SurveyId == surveyId && r.AppUserId == userId))
        {
            return SurveyErrors.AlreadyRefused;
        }

        return null;
    }

    private static Error? ValidateAndBuildAnswers(Survey survey, SurveySubmissionDto submission, out List<SurveyAnswer> answers)
    {
        answers = [];
        var given = submission.Answers ?? [];
        var questionIds = survey.Questions.Select(q => q.Id).ToHashSet();

        if (given.Any(a => !questionIds.Contains(a.QuestionId)))
        {
            return SurveyErrors.UnknownQuestion;
        }

        if (given.GroupBy(a => a.QuestionId).Any(g => g.Count() > 1))
        {
            return SurveyErrors.DuplicateAnswer;
        }

        var byQuestion = given.ToDictionary(a => a.QuestionId);

        foreach (var question in survey.Questions.OrderBy(q => q.Order))
        {
            var definition = SurveyQuestionRegistry.Get(question.Type);
            var answer = byQuestion.GetValueOrDefault(question.Id);

            if (!SurveyQuestionRegistry.IsAnswered(question.Type, answer))
            {
                if (question.IsRequired)
                {
                    return SurveyErrors.RequiredAnswerMissing(question.Text);
                }

                continue;
            }

            var invalid = definition.ValidateAnswer(question, answer);
            if (invalid is not null)
            {
                return invalid;
            }

            answers.Add(definition.CreateAnswer(question, answer));
        }

        return null;
    }
}
