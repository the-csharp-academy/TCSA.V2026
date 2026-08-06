using TCSA.V2026.Data.Enums;

namespace TCSA.V2026.Data.DTOs.PublicProfile;

public record PublicProfileIdentityResponse(
    int ExperiencePoints,
    int ReviewExperiencePoints,
    Level Level,
    DateTimeOffset CreatedDate,
    string? UserName,
    string? DisplayName,
    string Country,
    string? FirstName,
    string? LastName,
    string? LinkedInUrl,
    string? CodeWarsUsername,
    string? LeetCodeUsername,
    long? LeaderboardRank,
    long? ReviewLeaderboardRank
);
