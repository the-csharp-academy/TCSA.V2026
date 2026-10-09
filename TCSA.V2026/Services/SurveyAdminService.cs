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

public interface ISurveyAdminService
{
    Task<Result<int>> CreateSurvey(SurveyDraftDto draft);
    Task<List<SurveyListItemDto>> GetSurveys();
    Task<Result> ActivateSurvey(int id);
    Task<Result> DeactivateSurvey(int id);
    Task<Result> DeleteSurvey(int id);
}

public class SurveyAdminService(IDbContextFactory<ApplicationDbContext> _factory, ILogger<SurveyAdminService> _logger) : ISurveyAdminService
{
    public async Task<Result<int>> CreateSurvey(SurveyDraftDto draft)
    {
        var invalid = SurveyDraftValidator.Validate(draft).FirstOrDefault();
        if (invalid is not null)
        {
            return Result.Failure<int>(invalid);
        }

        try
        {
            using var context = _factory.CreateDbContext();

            var survey = new Survey
            {
                Title = draft.Title.Trim(),
                Description = draft.Description?.Trim() ?? string.Empty,
                Status = SurveyStatus.Draft,
                CreatedAt = DateTimeOffset.UtcNow,
                Questions = [.. draft.Questions.Select((q, index) => SurveyQuestionRegistry.Get(q.Type).Create(q, index))]
            };

            context.Surveys.Add(survey);
            await context.SaveChangesAsync();

            return Result.Success(survey.Id, new Success(SurveyErrorCodes.Created, "Survey saved as a draft."));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to create survey {Title}", draft.Title);
            return Result.Failure<int>(SurveyErrors.Unexpected("saving the survey"));
        }
    }

    public async Task<List<SurveyListItemDto>> GetSurveys()
    {
        using var context = _factory.CreateDbContext();

        return await context.Surveys
            .AsNoTracking()
            .OrderByDescending(s => s.CreatedAt)
            .ThenByDescending(s => s.Id)
            .Select(s => new SurveyListItemDto
            {
                Id = s.Id,
                Title = s.Title,
                Description = s.Description,
                Status = s.Status,
                QuestionCount = s.Questions.Count,
                ResponseCount = 0,
                CreatedAt = s.CreatedAt
            })
            .ToListAsync();
    }

    public async Task<Result> ActivateSurvey(int id)
    {
        try
        {
            using var context = _factory.CreateDbContext();

            var survey = await context.Surveys
                .Include(s => s.Questions).ThenInclude(q => ((ChoiceQuestion)q).Options)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (survey is null)
            {
                return Result.Failure(SurveyErrors.NotFound);
            }

            if (survey.Status is not (SurveyStatus.Draft or SurveyStatus.Inactive))
            {
                return Result.Failure(SurveyErrors.InvalidTransition(survey.Status, SurveyStatus.Active));
            }

            var invalid = SurveyActivationValidator.Validate(survey);
            if (invalid is not null)
            {
                return Result.Failure(invalid);
            }

            survey.Status = SurveyStatus.Active;
            await context.SaveChangesAsync();

            return Result.Success(new Success(SurveyErrorCodes.Activated, "Survey activated. It is now available to every user."));
        }
        catch (DbUpdateConcurrencyException)
        {
            return Result.Failure(SurveyErrors.Conflict);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to activate survey {SurveyId}", id);
            return Result.Failure(SurveyErrors.Unexpected("activating the survey"));
        }
    }

    public async Task<Result> DeactivateSurvey(int id)
    {
        try
        {
            using var context = _factory.CreateDbContext();

            var survey = await context.Surveys.FirstOrDefaultAsync(s => s.Id == id);
            if (survey is null)
            {
                return Result.Failure(SurveyErrors.NotFound);
            }

            if (survey.Status != SurveyStatus.Active)
            {
                return Result.Failure(SurveyErrors.InvalidTransition(survey.Status, SurveyStatus.Inactive));
            }

            survey.Status = SurveyStatus.Inactive;
            await context.SaveChangesAsync();

            return Result.Success(new Success(SurveyErrorCodes.Deactivated, "Survey deactivated. Its responses are kept."));
        }
        catch (DbUpdateConcurrencyException)
        {
            return Result.Failure(SurveyErrors.Conflict);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to deactivate survey {SurveyId}", id);
            return Result.Failure(SurveyErrors.Unexpected("deactivating the survey"));
        }
    }

    public async Task<Result> DeleteSurvey(int id)
    {
        try
        {
            using var context = _factory.CreateDbContext();

            var survey = await context.Surveys
                .Include(s => s.Questions).ThenInclude(q => ((ChoiceQuestion)q).Options)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (survey is null)
            {
                return Result.Failure(SurveyErrors.NotFound);
            }

            if (survey.Status == SurveyStatus.Active)
            {
                return Result.Failure(SurveyErrors.DeleteActive);
            }

            context.SurveyOptions.RemoveRange(survey.Questions.OfType<ChoiceQuestion>().SelectMany(q => q.Options));
            context.SurveyQuestions.RemoveRange(survey.Questions);
            context.Surveys.Remove(survey);
            await context.SaveChangesAsync();

            return Result.Success(new Success(SurveyErrorCodes.Deleted, "Survey deleted."));
        }
        catch (DbUpdateConcurrencyException)
        {
            return Result.Failure(SurveyErrors.Conflict);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to delete survey {SurveyId}", id);
            return Result.Failure(SurveyErrors.Unexpected("deleting the survey"));
        }
    }
}
