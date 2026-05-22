namespace TCSA.V2026.Data.DTOs;

public class ChecklistTaskDto
{
    public string Label { get; set; } = string.Empty;
    public string? NavigationUrl { get; set; }
    public string? NavigationUrlLabel { get; set; }
    public bool IsCompleted { get; set; }
}
