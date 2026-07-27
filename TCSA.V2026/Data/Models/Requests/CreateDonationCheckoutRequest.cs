namespace TCSA.V2026.Data.Models.Requests;

public sealed class CreateDonationCheckoutRequest
{
    public string AppUserId { get; set; } = string.Empty;
    public int AmountDollars { get; set; }
    public string Currency { get; set; } = "usd";
    public string Email { get; set; } = string.Empty;
}
