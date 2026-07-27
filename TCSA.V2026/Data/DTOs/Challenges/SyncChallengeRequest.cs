namespace TCSA.V2026.Data.DTOs.Challenges;

public record SyncChallengeRequest(UserPlatformCredentials PlatformCredentials, int ChallengeId, string ExternalId, string UserId);
