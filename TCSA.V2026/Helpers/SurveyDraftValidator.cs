using TCSA.V2026.Data.DTOs;
using TCSA.V2026.Data.Models.Responses;
using TCSA.V2026.Helpers.Constants;
using TCSA.V2026.Helpers.SurveyQuestions;

namespace TCSA.V2026.Helpers;

public static class SurveyDraftValidator
{
    public static List<Error> Validate(SurveyDraftDto draft)
    {
        var errors = new List<Error>();

        var title = draft.Title?.Trim() ?? string.Empty;
        if (title.Length == 0)
        {
            errors.Add(SurveyErrors.TitleRequired);
        }
        else if (title.Length > SurveyLimits.TitleMaxLength)
        {
            errors.Add(SurveyErrors.TitleTooLong);
        }

        if ((draft.Description?.Trim().Length ?? 0) > SurveyLimits.DescriptionMaxLength)
        {
            errors.Add(SurveyErrors.DescriptionTooLong);
        }

        var questions = draft.Questions ?? [];

        if (questions.Count == 0)
        {
            errors.Add(SurveyErrors.DraftHasNoQuestions);
        }
        else if (questions.Count > SurveyLimits.MaxQuestions)
        {
            errors.Add(SurveyErrors.TooManyQuestions);
        }

        errors.AddRange(questions.Select(ValidateQuestion).OfType<Error>());

        return errors;
    }

    public static Error? ValidateQuestion(SurveyQuestionDraftDto question)
    {
        if (!SurveyQuestionRegistry.TryGet(question.Type, out var definition))
        {
            return SurveyErrors.QuestionTypeInvalid;
        }

        var text = question.NormalizedText;
        if (text.Length == 0)
        {
            return SurveyErrors.QuestionTextRequired;
        }

        if (text.Length > SurveyLimits.QuestionMaxLength)
        {
            return SurveyErrors.QuestionTextTooLong;
        }

        return definition.ValidateDraft(question);
    }
}
