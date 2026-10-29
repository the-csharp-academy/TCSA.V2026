using TCSA.V2026.Data.Enums;
using TCSA.V2026.Helpers.SurveyQuestions;

namespace TCSA.V2026.Data.DTOs;

public class SurveyDraftDto
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<SurveyQuestionDraftDto> Questions { get; set; } = [];
}

public class SurveyQuestionDraftDto
{
    public string Text { get; set; } = string.Empty;
    public SurveyQuestionType Type { get; set; } = SurveyQuestionType.Rating;
    public bool IsRequired { get; set; } = true;
    public List<string> Options { get; set; } = [];

    public string NormalizedText => Text?.Trim() ?? string.Empty;

    public bool HasOptions => SurveyQuestionRegistry.TryGet(Type, out var definition) && definition.UsesOptions;

    public IEnumerable<string> NonBlankOptions() =>
        (Options ?? []).Where(o => !string.IsNullOrWhiteSpace(o)).Select(o => o.Trim());
}

public class SurveyListItemDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public SurveyStatus Status { get; set; }
    public int QuestionCount { get; set; }
    public int ResponseCount { get; set; }
    public DateTimeOffset CreatedAt { get; set; }

    public bool CanActivate => Status is SurveyStatus.Draft or SurveyStatus.Inactive;
    public bool CanDeactivate => Status is SurveyStatus.Active;
    public bool CanDelete => Status is SurveyStatus.Draft or SurveyStatus.Inactive;
}
