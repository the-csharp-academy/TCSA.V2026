using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TCSA.V2026.Data.Enums;
using TCSA.V2026.Helpers.Constants;

namespace TCSA.V2026.Data.Models;

public class FeedbackItem
{
    public int Id { get; set; }
    public string AppUserId { get; set; } = string.Empty;
    public FeedbackCategory Category { get; set; }
    public FeedbackArea? Area { get; set; }

    [MaxLength(FeedbackLimits.PageMaxLength)]
    public string? ReportedPage { get; set; }

    [Required]
    [MaxLength(FeedbackLimits.OriginUrlMaxLength)]
    public string OriginUrl { get; set; } = string.Empty;

    [Required]
    [MaxLength(FeedbackLimits.DescriptionMaxLength)]
    public string Body { get; set; } = string.Empty;

    public FeedbackReviewState? ReviewState { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    [JsonIgnore]
    public ApplicationUser AppUser { get; set; } = null!;
}
