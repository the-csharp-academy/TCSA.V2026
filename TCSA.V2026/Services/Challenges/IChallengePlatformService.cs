using TCSA.V2026.Data.DTOs;
using TCSA.V2026.Data.Models.Responses;

namespace TCSA.V2026.Services.Challenges;

public interface IChallengePlatformService
{
    public Task<BaseResponse> SyncChallenge(SyncChallengeRequest request);
    public Task MarkChallengeAsCompleted(MarkChallengeCompletedRequest request);
}
