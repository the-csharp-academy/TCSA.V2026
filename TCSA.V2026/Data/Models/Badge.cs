namespace TCSA.V2026.Data.Models;

public class Badge
{
    public int BadgeId { get; set; }
    public string UserId { get; set; } = null!;
    public DateTimeOffset DateAwarded { get; set; }
    public bool IsPendingNotification { get; set; }
}
