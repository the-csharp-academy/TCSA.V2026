using MudBlazor;
using TCSA.V2026.Data.Enums;

namespace TCSA.V2026.Helpers;

public static class FeedbackLabelHelper
{
    private const int ExcerptLength = 90;

    private sealed record CategoryStyle(string Label, string Icon, Color Color);

    private static readonly Dictionary<FeedbackCategory, CategoryStyle> CategoryStyles = new()
    {
        [FeedbackCategory.Bug] = new("Bug", Icons.Material.Filled.BugReport, Color.Error),
        [FeedbackCategory.Idea] = new("Idea", Icons.Material.Filled.Lightbulb, Color.Warning),
        [FeedbackCategory.Help] = new("Help / Confusion", Icons.Material.Filled.HelpOutline, Color.Info),
        [FeedbackCategory.Compliment] = new("Compliment", Icons.Material.Filled.Favorite, Color.Success)
    };

    public static readonly FeedbackReviewState[] HandledStates =
        [FeedbackReviewState.Reviewed, FeedbackReviewState.Actioned, FeedbackReviewState.Archived];

    public static string AreaLabel(FeedbackArea area) => area switch
    {
        FeedbackArea.CoursesArticles => "Courses/Articles",
        FeedbackArea.PeerReviews => "Peer Reviews",
        _ => area.ToString()
    };

    public static string CategoryLabel(FeedbackCategory category) =>
        CategoryStyles.TryGetValue(category, out var style) ? style.Label : category.ToString();

    public static string CategoryIcon(FeedbackCategory category) =>
        CategoryStyles.TryGetValue(category, out var style) ? style.Icon : Icons.Material.Filled.Feedback;

    public static Color CategoryColor(FeedbackCategory category) =>
        CategoryStyles.TryGetValue(category, out var style) ? style.Color : Color.Default;

    public static string ReviewStateLabel(FeedbackReviewState? state) =>
        state is { } value ? value.ToString() : "Not in queue";

    public static Color ReviewStateColor(FeedbackReviewState? state) => state switch
    {
        FeedbackReviewState.New => Color.Error,
        FeedbackReviewState.Reviewed => Color.Info,
        FeedbackReviewState.Actioned => Color.Success,
        FeedbackReviewState.Archived => Color.Default,
        _ => Color.Default
    };

    public static string Excerpt(string body)
    {
        var flat = body.ReplaceLineEndings(" ");
        return flat.Length <= ExcerptLength ? flat : flat[..ExcerptLength].TrimEnd() + "…";
    }
}
