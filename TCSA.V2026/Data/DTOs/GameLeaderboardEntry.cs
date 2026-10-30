using TCSA.V2026.Data.Enums;

namespace TCSA.V2026.Data.DTOs;

public class GameLeaderboardEntry
{
    public string UserId { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public Level Level { get; set; }
    public int Score { get; set; }
    public int Ranking { get; set; }
}
