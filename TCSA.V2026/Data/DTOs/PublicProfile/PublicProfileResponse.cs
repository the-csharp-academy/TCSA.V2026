namespace TCSA.V2026.Data.DTOs.PublicProfile;

public record PublicProfileResponse(
    PublicProfileIdentityResponse ProfileIdentity,
    IReadOnlyCollection<PublicProfilePullRequestDetailsResponse> ProfilePullRequests,
    IReadOnlyCollection<int> CompletedProjectIds
);
