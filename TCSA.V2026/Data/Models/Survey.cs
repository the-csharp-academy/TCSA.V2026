using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TCSA.V2026.Data.Enums;
using TCSA.V2026.Helpers.Constants;

namespace TCSA.V2026.Data.Models;

public class Survey
{
    public int Id { get; set; }

    [Required]
    [MaxLength(SurveyLimits.TitleMaxLength)]
    public string Title { get; set; } = string.Empty;

    [MaxLength(SurveyLimits.DescriptionMaxLength)]
    public string Description { get; set; } = string.Empty;

    public SurveyStatus Status { get; set; } = SurveyStatus.Draft;

    public DateTimeOffset CreatedAt { get; set; }

    public List<SurveyQuestion> Questions { get; set; } = [];
}

public class SurveyOption
{
    private SurveyOption() { }

    public int Id { get; private set; }
    public int SurveyQuestionId { get; private set; }

    [Required]
    [MaxLength(SurveyLimits.OptionMaxLength)]
    public string Text { get; private set; } = string.Empty;

    public int Order { get; private set; }

    [JsonIgnore]
    public ChoiceQuestion Question { get; private set; } = null!;

    public static SurveyOption Create(string text, int order)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(text);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(text.Length, SurveyLimits.OptionMaxLength, nameof(text));
        ArgumentOutOfRangeException.ThrowIfNegative(order);

        return new SurveyOption { Text = text, Order = order };
    }
}
