using TCSA.V2026.Data.Enums;
using TCSA.V2026.Data.Models;

namespace TCSA.V2026.Data.DTOs;

public class UserLeaderboardDisplay
{
    public string Id { get; set; }
    public string? DisplayName { get; set; }
    public string Country { get; set; }
    public string LinkedInUrl { get; set; }
    public string GithubUsername { get; set; }
    public Level Level { get; set; }
    public int ExperiencePoints { get; set; }
    public int Ranking { get; set; }
}

public class UserReviewLeaderboardDisplay
{
    public string Id { get; set; }
    public string? DisplayName { get; set; }
    public int? TotalXp { get; set; }
    public int ReviewsNumber { get; set; }
    public int Ranking { get; set; }
    public string Country { get; set; }
}