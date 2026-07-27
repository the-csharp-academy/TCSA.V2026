using System.Text.RegularExpressions;
using TCSA.V2026.Data.Enums;
using TCSA.V2026.Helpers.Constants;

namespace TCSA.V2026.Helpers;

public static class UrlHelper
{
    public static bool IsValidCommunityProjectIssueUrl(string url, CommunityProject communityProject)
    {
        var communityProjectRepositoryIssuesUrl = communityProject switch
        {
            CommunityProject.TCSA => UrlConstants.TCSARepositoryIssuesUrl,
            CommunityProject.KnowTheCity => UrlConstants.KnowTheCityRepositoryIssuesUrl,
            _ => throw new ArgumentException("Invalid community project.")
        };

        var escapedCommunityProjectRepositoryIssuesUrl = Regex.Escape(communityProjectRepositoryIssuesUrl);

        return Regex.IsMatch(
            url,
            $@"^{escapedCommunityProjectRepositoryIssuesUrl}/\d+$",
            RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
    }

    public static bool IsValidCommunityProjectPrUrl(string url, CommunityProject communityProject)
    {
        var communityProjectRepositoryPullUrl = communityProject switch
        {
            CommunityProject.TCSA => UrlConstants.TCSARepositoryPullUrl,
            CommunityProject.KnowTheCity => UrlConstants.KnowTheCityRepositoryPullUrl,
            _ => throw new ArgumentException("Invalid community project.")
        };

        var escapedCommunityProjectRepositoryPullUrl = Regex.Escape(communityProjectRepositoryPullUrl);

        return Regex.IsMatch(
            url,
            $@"^{escapedCommunityProjectRepositoryPullUrl}/\d+$",
            RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
    }
}
