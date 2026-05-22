namespace TCSA.V2026.Data.DTOs;

public class ChecklistTaskDto
{
    public string Label { get; set; } = string.Empty;
    public string NavigationUrl { get; set; } = "/dashboard/profile";
    public bool IsCompleted { get; set; }
}
