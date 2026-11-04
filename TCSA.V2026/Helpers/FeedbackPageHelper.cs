namespace TCSA.V2026.Helpers;

public static class FeedbackPageHelper
{
    private const string Root = "/";

    public static bool IsAdminPath(string? page) => Normalize(page).StartsWith("/admin");

    public static string Normalize(string? page)
    {
        var path = page?.Trim() ?? string.Empty;

        if (Uri.TryCreate(path, UriKind.Absolute, out var absolute) && absolute.Scheme is "http" or "https")
        {
            path = absolute.AbsolutePath;
        }

        var cut = path.IndexOfAny(['?', '#']);
        if (cut >= 0)
        {
            path = path[..cut];
        }

        path = path.ToLowerInvariant().TrimEnd('/');

        if (path.Length == 0)
        {
            return Root;
        }

        return path.StartsWith('/') ? path : $"/{path}";
    }
}
