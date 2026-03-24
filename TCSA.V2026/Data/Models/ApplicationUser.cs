using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using TCSA.V2026.Data.Enums;

namespace TCSA.V2026.Data.Models;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? DiscordAlias { get; set; }
    public string? CodeWarsUsername { get; set; }
    public string? LeetCodeUsername { get; set; }
    public string? LinkedInUrl { get; set; }
    public string? GithubUsername { get; set; }
    public string? DisplayName { get; set; }
    public string Country { get; set; }
    public int ExperiencePoints { get; set; }
    public int ReviewExperiencePoints { get; set; }
    public int ReviewedProjects { get; set; }
    public bool HasPendingBeltNotification { get; set; }
    public bool HasUnreviewableProjectNotification { get; set; }
    public bool GithubLogin { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
    public Level Level { get; set; }
    public virtual DailyStreak DailyStreak { get; set; } = new();
    public List<AppUserActivity> UserActivity { get; set; } = new();
    public List<DashboardProject> DashboardProjects { get; set; } = new();
    public List<UserReview> CodeReviewProjects { get; set; } = new();
    public List<CommunityIssue> Issues { get; set; } = new();
    public virtual ICollection<UserChallenge> UserChallenges { get; set; } = new List<UserChallenge>();
    public virtual ICollection<ShowcaseItem> ShowcaseItems { get; set; } = new List<ShowcaseItem>();
}