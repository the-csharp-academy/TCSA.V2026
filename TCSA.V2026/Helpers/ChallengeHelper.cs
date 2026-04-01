using TCSA.V2026.Data.Models;
using TCSA.V2026.Helpers.Constants;

namespace TCSA.V2026.Helpers;

public static class ChallengeHelper
{
    public static string GetChallengeUrl(string externalId, ChallengePlatform platform)
    {
        return platform switch
        {
            ChallengePlatform.CodeWars => $"{ChallengePlatformConstants.CodeWars.KataUrl}{externalId}",
            ChallengePlatform.LeetCode => $"{ChallengePlatformConstants.LeetCode.ProblemsUrl}{externalId}",
            _ => throw new ArgumentOutOfRangeException(nameof(platform), platform, null)
        };
    }
}
