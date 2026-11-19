using TCSA.V2026.Data.Enums;
using TCSA.V2026.Helpers;

namespace TCSA.V2026.Data.DTOs;

public class FeedbackAdminFilter
{
    public FeedbackCategory? Category { get; set; }
    public FeedbackReviewState? ReviewState { get; set; }
    public FeedbackArea? Area { get; set; }
    public string? Search { get; set; }
    public DateTimeOffset? From { get; set; }
    public DateTimeOffset? To { get; set; }

    public bool IsActive =>
        Category is not null || ReviewState is not null || Area is not null ||
        From is not null || To is not null || !string.IsNullOrWhiteSpace(Search);
}

public class FeedbackAdminItemDto
{
    public int Id { get; set; }
    public FeedbackCategory Category { get; set; }
    public FeedbackArea? Area { get; set; }
    public string? ReportedPage { get; set; }
    public string OriginUrl { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
    public FeedbackReviewState? ReviewState { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public string UserId { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string? UserDisplayName { get; set; }

    public string UserLabel => UserDisplayNameHelper.GetDisplayName(UserDisplayName, UserName);

    public string Location => !string.IsNullOrEmpty(ReportedPage) ? ReportedPage : OriginUrl;
}
