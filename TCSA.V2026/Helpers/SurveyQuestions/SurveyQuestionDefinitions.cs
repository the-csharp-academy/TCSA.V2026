using MudBlazor;
using TCSA.V2026.Data.DTOs;
using TCSA.V2026.Data.Enums;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Data.Models.Responses;
using TCSA.V2026.Helpers.Constants;

namespace TCSA.V2026.Helpers.SurveyQuestions;

public sealed class RatingQuestionDefinition : SurveyQuestionDefinition
{
    public override SurveyQuestionType Type => SurveyQuestionType.Rating;
    public override string Label => "Rating";
    public override string Icon => Icons.Material.Outlined.StarOutline;
    public override string Hint => "Respondents pick 1 to 5 stars.";

    public override SurveyQuestion Create(SurveyQuestionDraftDto draft, int order) =>
        RatingQuestion.Create(draft.NormalizedText, draft.IsRequired, order);
}

public sealed class YesNoQuestionDefinition : SurveyQuestionDefinition
{
    public override SurveyQuestionType Type => SurveyQuestionType.YesNo;
    public override string Label => "Yes / No";
    public override string Icon => Icons.Material.Outlined.ToggleOn;
    public override string Hint => "Respondents answer Yes or No.";

    public override SurveyQuestion Create(SurveyQuestionDraftDto draft, int order) =>
        YesNoQuestion.Create(draft.NormalizedText, draft.IsRequired, order);
}

public sealed class FreeTextQuestionDefinition : SurveyQuestionDefinition
{
    public override SurveyQuestionType Type => SurveyQuestionType.FreeText;
    public override string Label => "Free text";
    public override string Icon => Icons.Material.Outlined.Notes;
    public override string Hint => $"Respondents type up to {SurveyLimits.FreeTextAnswerMaxLength} characters.";

    public override SurveyQuestion Create(SurveyQuestionDraftDto draft, int order) =>
        FreeTextQuestion.Create(draft.NormalizedText, draft.IsRequired, order);
}

public abstract class ChoiceQuestionDefinition : SurveyQuestionDefinition
{
    public override bool UsesOptions => true;

    public override void PrepareDraft(SurveyQuestionDraftDto draft)
    {
        draft.Options ??= [];

        while (draft.Options.Count < SurveyLimits.MinOptions)
        {
            draft.Options.Add(string.Empty);
        }
    }

    public override Error? ValidateDraft(SurveyQuestionDraftDto draft)
    {
        var text = draft.NormalizedText;
        var options = draft.NonBlankOptions().ToList();

        if (options.Count < SurveyLimits.MinOptions)
        {
            return SurveyErrors.TooFewOptions(text);
        }

        if (options.Count > SurveyLimits.MaxOptions)
        {
            return SurveyErrors.TooManyOptions(text);
        }

        if (options.Any(o => o.Length > SurveyLimits.OptionMaxLength))
        {
            return SurveyErrors.OptionTextTooLong;
        }

        return null;
    }

    public override Error? ValidateStored(SurveyQuestion question) =>
        question is ChoiceQuestion { Options.Count: < SurveyLimits.MinOptions }
            ? SurveyErrors.TooFewOptions(question.Text)
            : null;
}

public sealed class SingleChoiceQuestionDefinition : ChoiceQuestionDefinition
{
    public override SurveyQuestionType Type => SurveyQuestionType.SingleChoice;
    public override string Label => "Single choice";
    public override string Icon => Icons.Material.Outlined.RadioButtonChecked;
    public override string? OptionIcon => Icons.Material.Outlined.RadioButtonUnchecked;

    public override SurveyQuestion Create(SurveyQuestionDraftDto draft, int order) =>
        SingleChoiceQuestion.Create(draft.NormalizedText, draft.IsRequired, order, draft.NonBlankOptions());
}

public sealed class MultipleChoiceQuestionDefinition : ChoiceQuestionDefinition
{
    public override SurveyQuestionType Type => SurveyQuestionType.MultipleChoice;
    public override string Label => "Multiple choice";
    public override string Icon => Icons.Material.Outlined.CheckBox;
    public override string? OptionIcon => Icons.Material.Outlined.CheckBoxOutlineBlank;

    public override SurveyQuestion Create(SurveyQuestionDraftDto draft, int order) =>
        MultipleChoiceQuestion.Create(draft.NormalizedText, draft.IsRequired, order, draft.NonBlankOptions());
}
