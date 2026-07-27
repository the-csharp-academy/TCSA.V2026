namespace TCSA.V2026.Data.Models.Responses;

public sealed class EnableAccountabilityResponse
{
    public string StripeCustomerId { get; init; } = default!;
    public string CheckoutSessionId { get; init; } = default!;
    public string? CheckoutUrl { get; init; }
}