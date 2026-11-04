using TCSA.V2026.Data.Enums;
using TCSA.V2026.Data.Models.Responses;
using TCSA.V2026.Helpers.Constants;

namespace TCSA.V2026.Helpers;

public static class SurveyErrors
{
    public static readonly Error NotFound = new(SurveyErrorCodes.NotFound, "That survey no longer exists.");

    public static readonly Error Conflict = new(SurveyErrorCodes.Conflict, "This survey changed while you were looking at it. The list has been refreshed, so please try again.");

    public static readonly Error NoQuestions = new(SurveyErrorCodes.NoQuestions, "This survey has no questions, so it cannot be activated.");

    public static readonly Error DeleteActive = new(SurveyErrorCodes.DeleteActive, "Deactivate this survey before deleting it.");

    public static readonly Error TitleRequired = new(SurveyErrorCodes.TitleRequired, "Please give the survey a title.");

    public static readonly Error TitleTooLong = new(SurveyErrorCodes.TitleTooLong, $"The title can be at most {SurveyLimits.TitleMaxLength} characters.");

    public static readonly Error DescriptionTooLong = new(SurveyErrorCodes.DescriptionTooLong, $"The description can be at most {SurveyLimits.DescriptionMaxLength} characters.");

    public static readonly Error DraftHasNoQuestions = new(SurveyErrorCodes.NoQuestions, "Add at least one question.");

    public static readonly Error TooManyQuestions = new(SurveyErrorCodes.TooManyQuestions, $"A survey can have at most {SurveyLimits.MaxQuestions} questions.");

    public static readonly Error QuestionTypeInvalid = new(SurveyErrorCodes.QuestionTypeInvalid, "Please choose a valid question type.");

    public static readonly Error QuestionTextRequired = new(SurveyErrorCodes.QuestionTextRequired, "Every question needs some text.");

    public static readonly Error QuestionTextTooLong = new(SurveyErrorCodes.QuestionTextTooLong, $"A question can be at most {SurveyLimits.QuestionMaxLength} characters.");

    public static readonly Error OptionTextTooLong = new(SurveyErrorCodes.OptionTextTooLong, $"An option can be at most {SurveyLimits.OptionMaxLength} characters.");

    public static Error Unexpected(string action) => new(SurveyErrorCodes.Unexpected, $"Something went wrong while {action}.");

    public static Error InvalidTransition(SurveyStatus from, SurveyStatus to) => new(SurveyErrorCodes.InvalidTransition,
        to == SurveyStatus.Active
            ? $"This survey is already {from.ToString().ToLowerInvariant()}. Refresh the list to see its current status."
            : "Only an active survey can be deactivated. Refresh the list to see its current status.");

    public static Error TooFewOptions(string questionText) => new(SurveyErrorCodes.TooFewOptions,
        $"\"{questionText}\" needs at least {SurveyLimits.MinOptions} non-empty options (blank options are ignored).");

    public static Error TooManyOptions(string questionText) => new(SurveyErrorCodes.TooManyOptions,
        $"\"{questionText}\" can have at most {SurveyLimits.MaxOptions} options.");
}
