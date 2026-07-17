namespace TCSA.V2026.Helpers;

public static class CourseContentHelper
{
    public const string ExerciseBlockClass = "course-exercise-block";

    private const string RedDotListStyle = "list-style-type: none; padding-left: 0; margin: 0;";
    private const string RedDotListItemStyle = "display: flex; gap: 0.75rem; align-items: flex-start; margin-bottom: 0.75rem;";
    private const string RedDotMarkerStyle = "min-width: 0.65rem; height: 0.65rem; margin-top: 0.45rem; border-radius: 999px; background: #a63a3a; box-shadow: 0 0 0 0.25rem #f8e9e9;";
    private const string AmberSquareMarkerStyle = "min-width: 0.62rem; height: 0.62rem; margin-top: 0.45rem; border-radius: 0.12rem; background: #b7791f; box-shadow: 0 0 0 0.25rem #fff3d6;";

    public static string RedDotList(params string[] items)
    {
        var listItems = items.Select(item =>
            $"    <li style='{RedDotListItemStyle}'><span style='{RedDotMarkerStyle}'></span><span>{item}</span></li>");

        return $"<ul style='{RedDotListStyle}'>\r\n{string.Join("\r\n", listItems)}\r\n</ul>";
    }

    public static string ExerciseList(params string[] items)
    {
        var listItems = items.Select(item =>
            $"    <li style='{RedDotListItemStyle}'><span style='{AmberSquareMarkerStyle}'></span><span>{item}</span></li>");

        return $"<ul style='{RedDotListStyle}'>\r\n{string.Join("\r\n", listItems)}\r\n</ul>";
    }
}
