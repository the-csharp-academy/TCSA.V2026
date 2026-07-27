using TCSA.V2026.Data.Models;
using TCSA.V2026.Helpers;

namespace TCSA.V2026.Data.DTOs;

public class AdminActivity
{
    public string Title { get; set; }
    public string Date { get; set; }
    public ProjectType ProjectType { get; set; }
    public string AppUserId { get; set; }
    public string ActivityName { get; set; }
    public string? GithubUrl { get; set; }
    public int? DashboardProjectId { get; set; }
    public int? ProjectId { get; set; }
    public bool IsCompleted { get; set; }
    public bool IsPending { get; set; }
    public bool IsArchived { get; set; }
    public string? ChangesRequested { get; set; }
}
