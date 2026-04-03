using TCSA.V2026.Data.Models;

namespace TCSA.V2026.Helpers;

public static class StatisticsHelper
{
    public static TimeSpan CalculateAverageReviewTime(IList<DashboardProject> projects, DateTimeOffset now)
    {
        if (projects == null || projects.Count == 0)
            return TimeSpan.Zero;

        var durations = new List<TimeSpan>();

        foreach (var project in projects)
        {
            durations.Add(now - project.DateSubmitted);
        }

        if (durations.Count == 0)
            return TimeSpan.Zero;

        var averageTicks = (long)durations.Average(d => d.Ticks);
        return TimeSpan.FromTicks(averageTicks);
    }
}
