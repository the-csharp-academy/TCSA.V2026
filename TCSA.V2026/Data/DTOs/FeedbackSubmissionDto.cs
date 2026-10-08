using TCSA.V2026.Data.Enums;

namespace TCSA.V2026.Data.DTOs;

public class FeedbackSubmissionDto
{
    public FeedbackCategory Category { get; set; }
    public string? Description { get; set; }

    public string? OriginUrl { get; set; }

    public FeedbackArea? Area { get; set; }
    public string? Page { get; set; }
}
