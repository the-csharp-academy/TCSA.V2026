using TCSA.V2026.Data.DTOs;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Data.Models.Responses;

namespace TCSA.V2026.Services.Challenges;

public class ChallengeManager
{
    private readonly IChallengePlatformFactory _challengePlatformFactory;

    public ChallengeManager(IChallengePlatformFactory challengePlatformFactory)
    {
        _challengePlatformFactory = challengePlatformFactory;
    }

    public async Task<BaseResponse> Sync(SyncChallengeRequest request, ChallengePlatform platform)
    {
        var platformService = _challengePlatformFactory.GetCodingPlatformService(platform);
        return await platformService.SyncChallenge(request);
    }
}
