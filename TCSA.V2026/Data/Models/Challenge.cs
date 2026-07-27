using System.ComponentModel.DataAnnotations;
using TCSA.V2026.Data.Enums;

namespace TCSA.V2026.Data.Models;

public class Challenge
{
    public int Id { get; set; }

    [Required(ErrorMessage = "External ID is required.")]
    public string ExternalId { get; set; }

    [Required(ErrorMessage = "Description is required.")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Keywords are required.")]
    public string Keywords { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Release Date is required.")]
    public DateTime ReleaseDate { get; set; }

    [Required(ErrorMessage = "Experience Points are required.")]
    public int ExperiencePoints { get; set; }

    [Required(ErrorMessage = "Platform is required.")]
    public ChallengePlatform Platform { get; set; }

    [Required(ErrorMessage = "Challenge Type is required")]
    public ChallengeCategory Category { get; set; }

    [Required(ErrorMessage = "Level is required.")]
    public Level Level { get; set; }

    public virtual ICollection<UserChallenge> UserChallenges { get; set; }
}

public class DailyStreak
{
    public string AppUserId { get; set; }
    public ApplicationUser User { get; set; }
    public int CurrentStreak { get; set; }
    public int LongestStreak { get; set; }
    public DateTime LastCompletedDate { get; set; }
}


public class UserChallenge
{
    public int ChallengeId { get; set; }
    public Challenge Challenge { get; set; }
    public string UserId { get; set; }
    public ApplicationUser User { get; set; }
    public DateTime CompletedAt { get; set; }
}

public enum ChallengePlatform
{
    CodeWars = 1,
    LeetCode,
    HackerRank
}

public enum ChallengeCategory
{
    Unknown = 0,
    [Display(Name = "C#")]
    CSharp,
    SQL
}
