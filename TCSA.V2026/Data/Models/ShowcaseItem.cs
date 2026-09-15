using System.Text.Json.Serialization;

namespace TCSA.V2026.Data.Models;

public class ShowcaseItem
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string AppUserId { get; set; }

    [JsonIgnore]
    public ApplicationUser ApplicationUser { get; set; }
    public int DashboardProjectId { get; set; }
    public DashboardProject DashboardProject { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.Now;
    public string VideoUrl { get; set; }
    public string GithubUrl { get; set; }
}

