using TCSA.V2026.Data.Enums;
using TCSA.V2026.Data.Models;

namespace TCSA.V2026.Data.DTOs.Challenges;

public record ChallengeDetails(
    int Id,
    string ExternalId,
    bool IsCompleted,
    Level Level,
    string Name,
    string Description,
    ChallengeCategory Category,
    ChallengePlatform Platform,
    int ExperiencePoints);
