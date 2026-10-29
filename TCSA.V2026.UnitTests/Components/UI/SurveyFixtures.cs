using TCSA.V2026.Data.DTOs;
using TCSA.V2026.Data.Enums;

namespace TCSA.V2026.UnitTests.Components.UI;

internal static class SurveyFixtures
{
    public static SurveyQuestionDto Question(int id, SurveyQuestionType type, bool required, params string[] options) => new()
    {
        Id = id,
        Text = $"Question {id}",
        Type = type,
        IsRequired = required,
        Options = [.. options.Select((text, i) => new SurveyOptionDto { Id = id * 100 + i, Text = text })]
    };

    /// <summary>
    /// One question of each type: two required, three optional.
    /// </summary>
    public static AvailableSurveyDto MixedSurvey() => new()
    {
        Id = 7,
        Title = "Course feedback",
        Description = "Tell us",
        Questions =
        [
            Question(1, SurveyQuestionType.Rating, true),
            Question(2, SurveyQuestionType.SingleChoice, true, "Videos", "Projects"),
            Question(3, SurveyQuestionType.MultipleChoice, false, "Community", "Reviews", "Articles"),
            Question(4, SurveyQuestionType.FreeText, false),
            Question(5, SurveyQuestionType.YesNo, false)
        ]
    };

    /// <summary>
    /// Two yes/no questions, the first required and the second optional.
    /// </summary>
    public static AvailableSurveyDto TwoQuestionSurvey() => new()
    {
        Id = 3,
        Title = "Course feedback",
        Description = "Tell us how the course went",
        Questions =
        [
            new() { Id = 10, Text = "Is it clear?", Type = SurveyQuestionType.YesNo, IsRequired = true },
            new() { Id = 11, Text = "Anything else?", Type = SurveyQuestionType.YesNo, IsRequired = false }
        ]
    };
}
