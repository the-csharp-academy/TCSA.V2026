namespace TCSA.V2026.Data.DTOs;

public record SyncChallengeRequest(UserPlatformCredentials PlatformCredentials, int ChallengeId, string ExternalId, string UserId);
