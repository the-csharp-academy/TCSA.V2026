using System.Text.Json.Serialization;
using TCSA.V2026.Data.Models;

namespace TCSA.V2026.Data.Models;

public class UserReview
{
    public int Id { get; set; }

    [JsonIgnore]
    public ApplicationUser User { get; set; }
    public DashboardProject DashboardProject { get; set; }
    public string AppUserId { get; set; }
    public int DashboardProjectId { get; set; }
}
