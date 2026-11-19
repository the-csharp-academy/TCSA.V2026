using System.Diagnostics.CodeAnalysis;
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
}
