namespace TCSA.V2026.Data.Models;

public class GameScore
{
    public string GameId { get; set; } = null!;
    public string UserId { get; set; } = null!;
    public int BestScore { get; set; }
    public DateTimeOffset BestScoreAchievedAt { get; set; }
}
