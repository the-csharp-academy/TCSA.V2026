using System.Text.Json.Serialization;
using TCSA.V2026.Data.Enums;
using TCSA.V2026.Helpers.Constants;

namespace TCSA.V2026.Data.Models;

public abstract class SurveyAnswer
{
    protected SurveyAnswer(SurveyQuestionType type)
    {
        Type = type;
    }

    public int Id { get; private set; }
    public int SurveyResponseId { get; private set; }
    public int SurveyQuestionId { get; private set; }

    public SurveyQuestionType Type { get; private set; }
    public SurveyResponse Response { get; private set; } = null!;
    public SurveyQuestion Question { get; private set; } = null!;

    protected void Initialize(int questionId)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(questionId);

        SurveyQuestionId = questionId;
    }
}

public sealed class RatingAnswer : SurveyAnswer
{
    private RatingAnswer() : base(SurveyQuestionType.Rating) { }

    public int Rating { get; private set; }

    public static RatingAnswer Create(int questionId, int rating)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(rating, SurveyLimits.MinRating);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(rating, SurveyLimits.MaxRating);

        var answer = new RatingAnswer { Rating = rating };
        answer.Initialize(questionId);
        return answer;
    }
}

public sealed class YesNoAnswer : SurveyAnswer
{
    private YesNoAnswer() : base(SurveyQuestionType.YesNo) { }

    public bool IsYes { get; private set; }

    public static YesNoAnswer Create(int questionId, bool isYes)
    {
        var answer = new YesNoAnswer { IsYes = isYes };
        answer.Initialize(questionId);
        return answer;
    }
}

public sealed class FreeTextAnswer : SurveyAnswer
{
    private FreeTextAnswer() : base(SurveyQuestionType.FreeText) { }

    public string Text { get; private set; } = string.Empty;

    public static FreeTextAnswer Create(int questionId, string text)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(text);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(text.Length, SurveyLimits.FreeTextAnswerMaxLength, nameof(text));

        var answer = new FreeTextAnswer { Text = text };
        answer.Initialize(questionId);
        return answer;
    }
}

public abstract class ChoiceAnswer : SurveyAnswer
{
    private readonly List<SurveyAnswerOption> _selectedOptions = [];

    protected ChoiceAnswer(SurveyQuestionType type) : base(type) { }

    public IReadOnlyList<SurveyAnswerOption> SelectedOptions => _selectedOptions;

    protected void Initialize(int questionId, IEnumerable<int> optionIds)
    {
        Initialize(questionId);

        var ids = optionIds.Distinct().ToList();
        ArgumentOutOfRangeException.ThrowIfLessThan(ids.Count, 1, nameof(optionIds));

        _selectedOptions.AddRange(ids.Select(SurveyAnswerOption.Create));
    }
}

public sealed class SingleChoiceAnswer : ChoiceAnswer
{
    private SingleChoiceAnswer() : base(SurveyQuestionType.SingleChoice) { }

    public static SingleChoiceAnswer Create(int questionId, int optionId)
    {
        var answer = new SingleChoiceAnswer();
        answer.Initialize(questionId, [optionId]);
        return answer;
    }
}

public sealed class MultipleChoiceAnswer : ChoiceAnswer
{
    private MultipleChoiceAnswer() : base(SurveyQuestionType.MultipleChoice) { }

    public static MultipleChoiceAnswer Create(int questionId, IEnumerable<int> optionIds)
    {
        var answer = new MultipleChoiceAnswer();
        answer.Initialize(questionId, optionIds);
        return answer;
    }
}

public class SurveyAnswerOption
{
    private SurveyAnswerOption() { }

    public int Id { get; private set; }
    public int SurveyAnswerId { get; private set; }
    public int SurveyOptionId { get; private set; }

    [JsonIgnore]
    public ChoiceAnswer Answer { get; private set; } = null!;

    [JsonIgnore]
    public SurveyOption Option { get; private set; } = null!;

    public static SurveyAnswerOption Create(int optionId)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(optionId);

        return new SurveyAnswerOption { SurveyOptionId = optionId };
    }
}
