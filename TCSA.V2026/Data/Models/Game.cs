namespace TCSA.V2026.Data.Models;

public class Game
{
    public string Slug { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Url { get; set; } = null!;
    public long TimesPlayed { get; set; }
}
