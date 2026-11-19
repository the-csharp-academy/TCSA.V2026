using System.Diagnostics.CodeAnalysis;
using TCSA.V2026.Data.DTOs;
using TCSA.V2026.Data.Enums;

namespace TCSA.V2026.Helpers.SurveyQuestions;

public static class SurveyQuestionRegistry
{
    private static readonly SurveyQuestionDefinition[] Definitions =
    [
        new RatingQuestionDefinition(),
        new SingleChoiceQuestionDefinition(),
        new MultipleChoiceQuestionDefinition(),
        new FreeTextQuestionDefinition(),
        new YesNoQuestionDefinition()
    ];

    private static readonly Dictionary<SurveyQuestionType, SurveyQuestionDefinition> ByType =
        Definitions.ToDictionary(d => d.Type);

    public static IReadOnlyList<SurveyQuestionDefinition> All => Definitions;

    public static bool TryGet(SurveyQuestionType type, [NotNullWhen(true)] out SurveyQuestionDefinition? definition) =>
        ByType.TryGetValue(type, out definition);

    public static SurveyQuestionDefinition Get(SurveyQuestionType type) =>
        ByType.TryGetValue(type, out var definition)
            ? definition
            : throw new InvalidOperationException($"No survey question definition is registered for '{type}'.");

    /// <summary>
    /// The one rule for whether an answer counts as given. Used by the dialog to gate Next and Submit, and by the
    /// server to decide whether a required question is missing.
    /// </summary>
    public static bool IsAnswered(SurveyQuestionType type, [NotNullWhen(true)] SurveyAnswerDto? answer) =>
        answer is not null && !Get(type).IsBlank(answer);
}
