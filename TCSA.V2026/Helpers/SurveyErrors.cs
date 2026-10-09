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

    public static readonly Error Unavailable = new(SurveyErrorCodes.Unavailable, "This survey is no longer available.");

    public static readonly Error AlreadySubmitted = new(SurveyErrorCodes.AlreadySubmitted, "You have already answered this survey.");

    public static readonly Error AlreadyRefused = new(SurveyErrorCodes.AlreadyRefused, "You chose not to see this survey again.");

    public static readonly Error InvalidRating = new(SurveyErrorCodes.InvalidRating, $"A rating must be a whole number from {SurveyLimits.MinRating} to {SurveyLimits.MaxRating}.");

    public static readonly Error InvalidYesNo = new(SurveyErrorCodes.InvalidYesNo, "A yes/no answer must be yes or no.");

    public static readonly Error AnswerTooLong = new(SurveyErrorCodes.AnswerTooLong, $"An answer can be at most {SurveyLimits.FreeTextAnswerMaxLength} characters.");

    public static readonly Error UnknownQuestion = new(SurveyErrorCodes.UnknownQuestion, "An answer refers to a question that is not part of this survey.");

    public static readonly Error DuplicateAnswer = new(SurveyErrorCodes.DuplicateAnswer, "A question can only be answered once.");

    public static Error RequiredAnswerMissing(string questionText) => new(SurveyErrorCodes.RequiredAnswerMissing, $"\"{questionText}\" needs an answer.");

    public static Error InvalidChoiceCount(string questionText) => new(SurveyErrorCodes.InvalidChoiceCount, $"\"{questionText}\" needs exactly one option.");

    public static Error OptionNotInQuestion(string questionText) => new(SurveyErrorCodes.OptionNotInQuestion, $"An option chosen for \"{questionText}\" does not belong to that question.");

    public static bool IsFinal(Reason reason) =>
        reason.Code is SurveyErrorCodes.Unavailable or SurveyErrorCodes.AlreadySubmitted or SurveyErrorCodes.AlreadyRefused;

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
