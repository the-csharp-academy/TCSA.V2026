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
    public FeedbackClusterKey? Cluster { get; set; }

    public bool IsActive =>
        Category is not null || ReviewState is not null || Area is not null ||
        From is not null || To is not null || Cluster is not null || !string.IsNullOrWhiteSpace(Search);
}

public record FeedbackClusterKey(FeedbackCategory Category, string Page);

public class FeedbackClusterDto
{
    public FeedbackCategory Category { get; set; }
    public string Page { get; set; } = string.Empty;
    public int Count { get; set; }
    public int NewCount { get; set; }
    public DateTimeOffset FirstSeen { get; set; }
    public DateTimeOffset LastSeen { get; set; }

    public string SampleBody { get; set; } = string.Empty;

    public FeedbackClusterKey Key => new(Category, Page);
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

    public FeedbackClusterKey ClusterKey => new(Category, ReportedPage ?? OriginUrl);
}
