using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TCSA.V2026.Data.Enums;
using TCSA.V2026.Helpers.Constants;

namespace TCSA.V2026.Data.Models;

public abstract class SurveyQuestion
{
    protected SurveyQuestion(SurveyQuestionType type)
    {
        Type = type;
    }

    public int Id { get; private set; }
    public int SurveyId { get; private set; }

    [Required]
    [MaxLength(SurveyLimits.QuestionMaxLength)]
    public string Text { get; private set; } = string.Empty;

    public SurveyQuestionType Type { get; private set; }

    public int Order { get; private set; }

    public bool IsRequired { get; private set; }

    [JsonIgnore]
    public Survey Survey { get; private set; } = null!;

    protected void Initialize(string text, bool isRequired, int order)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(text);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(text.Length, SurveyLimits.QuestionMaxLength, nameof(text));
        ArgumentOutOfRangeException.ThrowIfNegative(order);

        Text = text;
        IsRequired = isRequired;
        Order = order;
    }
}

public sealed class RatingQuestion : SurveyQuestion
{
    private RatingQuestion() : base(SurveyQuestionType.Rating) { }

    public static RatingQuestion Create(string text, bool isRequired, int order)
    {
        var question = new RatingQuestion();
        question.Initialize(text, isRequired, order);
        return question;
    }
}

public sealed class YesNoQuestion : SurveyQuestion
{
    private YesNoQuestion() : base(SurveyQuestionType.YesNo) { }

    public static YesNoQuestion Create(string text, bool isRequired, int order)
    {
        var question = new YesNoQuestion();
        question.Initialize(text, isRequired, order);
        return question;
    }
}

public sealed class FreeTextQuestion : SurveyQuestion
{
    private FreeTextQuestion() : base(SurveyQuestionType.FreeText) { }

    public static FreeTextQuestion Create(string text, bool isRequired, int order)
    {
        var question = new FreeTextQuestion();
        question.Initialize(text, isRequired, order);
        return question;
    }
}

public abstract class ChoiceQuestion : SurveyQuestion
{
    private readonly List<SurveyOption> _options = [];

    protected ChoiceQuestion(SurveyQuestionType type) : base(type) { }

    public IReadOnlyList<SurveyOption> Options => _options;

    protected void Initialize(string text, bool isRequired, int order, IEnumerable<string> options)
    {
        Initialize(text, isRequired, order);

        var optionTexts = options.ToList();
        ArgumentOutOfRangeException.ThrowIfLessThan(optionTexts.Count, SurveyLimits.MinOptions, nameof(options));
        ArgumentOutOfRangeException.ThrowIfGreaterThan(optionTexts.Count, SurveyLimits.MaxOptions, nameof(options));

        _options.AddRange(optionTexts.Select(SurveyOption.Create));
    }
}

public sealed class SingleChoiceQuestion : ChoiceQuestion
{
    private SingleChoiceQuestion() : base(SurveyQuestionType.SingleChoice) { }

    public static SingleChoiceQuestion Create(string text, bool isRequired, int order, IEnumerable<string> options)
    {
        var question = new SingleChoiceQuestion();
        question.Initialize(text, isRequired, order, options);
        return question;
    }
}

public sealed class MultipleChoiceQuestion : ChoiceQuestion
{
    private MultipleChoiceQuestion() : base(SurveyQuestionType.MultipleChoice) { }

    public static MultipleChoiceQuestion Create(string text, bool isRequired, int order, IEnumerable<string> options)
    {
        var question = new MultipleChoiceQuestion();
        question.Initialize(text, isRequired, order, options);
        return question;
    }
}
