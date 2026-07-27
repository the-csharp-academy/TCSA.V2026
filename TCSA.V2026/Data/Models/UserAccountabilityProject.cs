using TCSA.V2026.Data.Enums;

namespace TCSA.V2026.Models;

public sealed class UserAccountabilityProject
{
    public int Id { get; set; }
    public string AppUserId { get; set; }
    public int ProjectId { get; set; }
    public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;
    public DateTime DeadLineUtc { get; set; }
    public DateTime? CompletedUtc { get; set; }
    public AccountabilityProjectStatus Status { get; set; } = AccountabilityProjectStatus.Active;
    public string? StripePaymentIntentId { get; set; }
    public DateTime? ChargedUtc { get; set; }
    public string Currency { get; set; } = "usd";
    public int PledgeCents { get; set; }
    public DateTime? PaymentMethodConfirmedUtc { get; set; }
}