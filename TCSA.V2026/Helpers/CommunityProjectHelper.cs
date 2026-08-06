using TCSA.V2026.Data.Enums;

namespace TCSA.V2026.Helpers;

public static class CommunityProjectHelper
{
    public static string GetDisplayName(int communityProjectId) => communityProjectId switch
    {
        (int)CommunityProject.TCSA => "Academy 2026",
        (int)CommunityProject.KnowTheCity => "Know The City",
        _ => throw new ArgumentException("Invalid community project.", nameof(communityProjectId))
    };
}
