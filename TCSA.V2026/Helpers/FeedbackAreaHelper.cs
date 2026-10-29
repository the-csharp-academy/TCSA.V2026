using TCSA.V2026.Data.Enums;

namespace TCSA.V2026.Helpers;

public static class FeedbackAreaHelper
{
    private static readonly (string Prefix, FeedbackArea Area)[] RoutePrefixes =
    [
        ("/dashboard/reviews", FeedbackArea.PeerReviews),
        ("/dashboard/leaderboard", FeedbackArea.Leaderboard),
        ("/dashboard/community", FeedbackArea.Community),
        ("/feed", FeedbackArea.Community),
        ("/dashboard/challenges", FeedbackArea.Challenges),
        ("/dashboard/profile", FeedbackArea.Profile),
        ("/profile", FeedbackArea.Profile),
        ("/dashboard/courses", FeedbackArea.CoursesArticles),
        ("/course", FeedbackArea.CoursesArticles),
        ("/article", FeedbackArea.CoursesArticles),
        ("/articles", FeedbackArea.CoursesArticles),
        ("/project", FeedbackArea.Projects),
        ("/gallery", FeedbackArea.Projects),
        ("/dashboard", FeedbackArea.Dashboard),
    ];

    public static FeedbackArea FromPath(string? path)
    {
        var normalized = FeedbackPageHelper.Normalize(path);

        foreach (var (prefix, area) in RoutePrefixes)
        {
            if (normalized == prefix || normalized.StartsWith($"{prefix}/"))
            {
                return area;
            }
        }

        return FeedbackArea.Other;
    }
}
