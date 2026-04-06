using TCSA.V2026.Data.Enums;
using TCSA.V2026.Data.Models;

namespace TCSA.V2026.Data.DTOs;

public class FeedDisplay
{
    public int? ProjectId { get; set; }
    public string UserId { get; set; } = string.Empty;
    public string? DisplayName { get; set; }
    public string? UserName { get; set; }
    public ActivityType ActivityType { get; set; }
    public string? ProjectName { get; set; }
    public string? ProjectIconUrl { get; set; }
    public Level? Level { get; set; }
    public DateTimeOffset Date { get; set; }
}
