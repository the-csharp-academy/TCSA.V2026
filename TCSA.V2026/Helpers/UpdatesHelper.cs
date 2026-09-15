using TCSA.V2026.Data.DTOs;

namespace TCSA.V2026.Helpers;

public static class UpdatesHelper
{
    private static readonly List<PlatformUpdate> _updates =
    [
        new(new DateOnly(2026, 8, 20), "Daily LeetCode challenges are now automated",
            PlatformUpdateType.Platform,
            "The Challenges page pulls a new LeetCode problem every day."),

        new(new DateOnly(2026, 8, 6), "New course: C# for Unity",
            PlatformUpdateType.Course,
            "Add new mechanics to an existing 2D game using C#."),

        new(new DateOnly(2026, 7, 22), "The blog has moved onto the platform",
            PlatformUpdateType.Article,
            "Older C# Academy blog posts are now available as articles alongside the rest of the curriculum."),

        new(new DateOnly(2026, 7, 18), "New course: LINQ Fundamentals",
            PlatformUpdateType.Course,
            "Learn to query collections in C# the declarative way."),

        new(new DateOnly(2026, 5, 23), "New System Design project: Clean Architecture Restaurant Reservations",
            PlatformUpdateType.Project,
            "Design and build a restaurant reservation system using clean architecture."),
    ];

    public static List<PlatformUpdate> GetLatestUpdates(int count = 5) =>
        [.. _updates.OrderByDescending(u => u.Date).Take(count)];
}
