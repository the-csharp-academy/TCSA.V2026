namespace TCSA.V2026.Data.DTOs.PublicProfile;

public record PublicProfilePullRequestDetailsResponse(
    DateTimeOffset? CompletedAt,
    string IssueTitle,
    string PullRequestUrl,
    int CommunityProjectId
);
