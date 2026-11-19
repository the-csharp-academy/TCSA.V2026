using TCSA.V2026.Data.Enums;
using TCSA.V2026.Helpers;

namespace TCSA.V2026.Data.DTOs;

public class SurveyResultsDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public SurveyStatus Status { get; set; }
    public int ResponseCount { get; set; }
    public List<QuestionResultDto> Questions { get; set; } = [];

    public int RequiredQuestionCount => Questions.Count(q => q.IsRequired);
}

public class QuestionResultDto
{
    public int QuestionId { get; set; }
    public string Text { get; set; } = string.Empty;
    public SurveyQuestionType Type { get; set; }
    public bool IsRequired { get; set; }
    public int AnswerCount { get; set; }
    public double? Average { get; set; }

    /// <summary>
    /// One bucket per option (rating: 1 to 5, yes/no: Yes and No, choice: each option in order). Empty for free text,
    /// which is paged separately.
    /// </summary>
    public List<ResultBucketDto> Buckets { get; set; } = [];
}

public class ResultBucketDto
{
    public string Label { get; set; } = string.Empty;
    public int Count { get; set; }
    public double Percentage { get; set; }
}

public class FreeTextResultDto
{
    public int ResponseId { get; set; }
    public string UserId { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string? UserDisplayName { get; set; }
    public string Text { get; set; } = string.Empty;
    public DateTimeOffset SubmittedAt { get; set; }

    public string AuthorLabel => UserDisplayNameHelper.GetDisplayName(UserDisplayName, UserName);
}

public class SurveyRespondentDto
{
    public int ResponseId { get; set; }
    public string UserId { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string? UserDisplayName { get; set; }
    public string Email { get; set; } = string.Empty;
    public DateTimeOffset SubmittedAt { get; set; }

    public string Label => UserDisplayNameHelper.GetDisplayName(UserDisplayName, UserName);
}

public class RespondentAnswersDto
{
    public SurveyRespondentDto Respondent { get; set; } = new();
    public List<RespondentAnswerDto> Answers { get; set; } = [];
}

public class RespondentAnswerDto
{
    public int QuestionId { get; set; }
    public string QuestionText { get; set; } = string.Empty;
    public SurveyQuestionType Type { get; set; }
    public bool IsRequired { get; set; }

    /// <summary>The answer as plain text. Null when an optional question was skipped.</summary>
    public string? Answer { get; set; }

    public bool Skipped => Answer is null;
}
