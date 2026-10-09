using Humanizer;
using TCSA.V2026.Data.Enums;
using TCSA.V2026.Helpers.Constants;

namespace TCSA.V2026.Data.DTOs;

public class AvailableSurveyDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<SurveyQuestionDto> Questions { get; set; } = [];

    public int QuestionCount => Questions.Count;

    public string QuestionCountLabel => "question".ToQuantity(QuestionCount);

    public int EstimatedMinutes => Math.Max(1, (int)Math.Ceiling(QuestionCount * SurveyLimits.SecondsPerQuestion / 60.0));
}

public class SurveyQuestionDto
{
    public int Id { get; set; }
    public string Text { get; set; } = string.Empty;
    public SurveyQuestionType Type { get; set; }
    public bool IsRequired { get; set; }
    public List<SurveyOptionDto> Options { get; set; } = [];
}

public class SurveyOptionDto
{
    public int Id { get; set; }
    public string Text { get; set; } = string.Empty;
}

public class SurveySubmissionDto
{
    public int SurveyId { get; set; }
    public List<SurveyAnswerDto> Answers { get; set; } = [];
}

public class SurveyAnswerDto
{
    public int QuestionId { get; set; }
    public int? NumericValue { get; set; }
    public string? TextValue { get; set; }
    public List<int> OptionIds { get; set; } = [];
}
