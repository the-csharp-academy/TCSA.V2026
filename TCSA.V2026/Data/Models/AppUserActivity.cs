using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TCSA.V2026.Data.Enums;

namespace TCSA.V2026.Data.Models;

public class AppUserActivity
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public int ChallengeId { get; set; }
    public string AppUserId { get; set; }
    public DateTimeOffset DateSubmitted { get; set; }
    public ActivityType ActivityType { get; set; }
    public Level? Level { get; set; }

    [JsonIgnore]
    public ApplicationUser ApplicationUser { get; set; }
    public DashboardProject? DashboardProject { get; set; }
}

public enum ActivityType
{
    [Display(Name = "Article Read")]
    ArticleRead,

    [Display(Name = "Project Submitted")]
    ProjectSubmitted,

    [Display(Name = "Project Completed")]
    ProjectCompleted,

    [Display(Name = "Code Review Completed")]
    CodeReviewCompleted,

    [Display(Name = "Issue Submitted")]
    IssueSubmitted,

    [Display(Name = "Challenge Completed")]
    ChallengeCompleted,

    [Display(Name = "New Belt")]
    NewBelt,

    [Display(Name = "New User")]
    NewUser
}