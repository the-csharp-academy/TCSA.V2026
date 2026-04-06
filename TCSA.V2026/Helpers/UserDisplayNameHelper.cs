namespace TCSA.V2026.Helpers;

public static class UserDisplayNameHelper
{
    public static string GetDisplayName(string? displayName, string? userName)
    {
        if (!string.IsNullOrWhiteSpace(displayName))
            return displayName;

        if (!string.IsNullOrWhiteSpace(userName))
        {
            int atIndex = userName.IndexOf('@');
            return atIndex > 0 ? userName[..atIndex] : userName;
        }

        return "Anonymous";
    }
}
