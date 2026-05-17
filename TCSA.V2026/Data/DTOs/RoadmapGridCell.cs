namespace TCSA.V2026.Data.DTOs;

public class RoadmapGridCell
{
    public int Row { get; set; }
    public int Column { get; set; }

    public string Title { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;

    public bool ConnectTop { get; set; }
    public bool ConnectRight { get; set; }
    public bool ConnectBottom { get; set; }
    public bool ConnectLeft { get; set; }
}
