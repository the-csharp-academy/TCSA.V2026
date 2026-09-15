using System.Text.Json.Serialization;

namespace TCSA.V2026.Data.Models;

public class CommunityIssue
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? AppUserId { get; set; }

    [JsonIgnore]
    public ApplicationUser? AppUser { get; set; }
    public int ProjectId { get; set; }
    public int CommunityProjectId { get; set; }
    public int ExperiencePoints { get; set; }
    public IssueType Type { get; set; }
    public string GithubUrl { get; set; }
    public string IconUrl { get; set; }
    public bool IsClosed { get; set; }
    public string? Reference { get; set; }
}

public enum IssueType
{
    Bugfix,
    Feature,
    Infrastructure,
    Translation
}
