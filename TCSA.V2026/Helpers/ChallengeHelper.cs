using System.Net;
using System.Text.RegularExpressions;
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

    public static string ExtractFirstSentence(string html)
    {
        var plain = Regex.Replace(html, "<[^>]+>", " ");
        plain = WebUtility.HtmlDecode(Regex.Replace(plain, @"\s+", " ").Trim());
        var end = plain.IndexOfAny(['.', '!', '?']);
        return end >= 0 ? plain[..(end + 1)].Trim() : plain[..Math.Min(200, plain.Length)].Trim();
    }
}
