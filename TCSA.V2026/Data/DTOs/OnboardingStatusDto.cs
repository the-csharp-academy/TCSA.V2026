namespace TCSA.V2026.Data.DTOs;

public class OnboardingStatusDto
{
    public bool ShowWelcome { get; set; }
    public bool ShowTour { get; set; }
    public bool ShowChecklist { get; set; }
    public List<ChecklistTaskDto> Tasks { get; set; } = new();
}
