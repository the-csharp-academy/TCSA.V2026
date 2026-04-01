using Humanizer;

namespace TCSA.V2026.Helpers;

public static class TimeSpanFormatter
{
    public static string FormatDurationOpen(TimeSpan duration)
    {
        var days = duration.Days;
        var hours = duration.Hours;
        var minutes = duration.Minutes;

        var formattedDuration = duration switch
        {
            { Hours: > 0, Days: > 0 } => $"{"day".ToQuantity(days)} {"hour".ToQuantity(hours)} ago",
            { Days: > 0 } => $"{"day".ToQuantity(days)} ago",
            { Minutes: > 0, Hours: > 0 } => $"{"hour".ToQuantity(hours)} {"minute".ToQuantity(minutes)} ago",
            { Hours: > 0 } => $"{"hour".ToQuantity(hours)} ago",
            { Minutes: > 0 } => $"{"minute".ToQuantity(minutes)} ago",
            _ => "just now"
        };

        return formattedDuration;
    }

    public static string FormatReviewTime(TimeSpan time)
    {
        if (time <= TimeSpan.Zero)
            return "N/A";

        return time.Humanize(precision: 1);
    }
}
