using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Stripe;
using Stripe.Checkout;       // UserStripe (you said you already have it)
using TCSA.V2026.Data;
using TCSA.V2026.Data.Enums;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Data.Models.Options;
using TCSA.V2026.Data.Models.Requests;
using TCSA.V2026.Data.Models.Responses;

namespace TCSA.V2026.Services;

public interface IDonateService
{
    Task<ServiceResponse<CreateDonationCheckoutResponse>> CreateCheckoutAsync(CreateDonationCheckoutRequest request);
    Task<ServiceResponse<List<UserDonation>>> GetDonationsAsync();
}

public sealed class DonateService : IDonateService
{
    private readonly IDbContextFactory<ApplicationDbContext> _factory;
    private readonly IStripeClient _stripeClient;
    private readonly StripeOptions _stripeOptions;
    private readonly ILogger<DonateService> _logger;

    public DonateService(
        IDbContextFactory<ApplicationDbContext> factory,
        IStripeClient stripeClient,
        IOptions<StripeOptions> stripeOptions,
        ILogger<DonateService> logger)
    {
        _factory = factory;
        _stripeClient = stripeClient;
        _stripeOptions = stripeOptions.Value;
        _logger = logger;
    }

    public async Task<ServiceResponse<CreateDonationCheckoutResponse>> CreateCheckoutAsync(CreateDonationCheckoutRequest request)
    {
        var response = ValidateDonationRequest(request);
        if (!response.IsSuccessful) return response;

        var currency = NormalizeCurrency(request.Currency);
        var amountCents = checked(request.AmountDollars * 100);

        await using var db = await _factory.CreateDbContextAsync();

        var userStripe = await GetOrCreateUserStripeAsync(db, request.AppUserId);
        await EnsureStripeCustomerAsync(db, userStripe, request.Email);

        var donation = new UserDonation
        {
            AppUserId = request.AppUserId,
            AmountCents = amountCents,
            Currency = currency,
            Status = DonationStatus.Created,
            CreatedUtc = DateTime.UtcNow,
        };

        db.UserDonations.Add(donation);
        await db.SaveChangesAsync();

        var session = await CreateDonationCheckoutSessionAsync(userStripe.StripeCustomerId, donation, currency);

        donation.StripeCheckoutSessionId = session.Id;
        await db.SaveChangesAsync();

        return new ServiceResponse<CreateDonationCheckoutResponse>
        {
            IsSuccessful = true,
            Message = "Redirect the user to Stripe Checkout to complete the contribution.",
            Data = new CreateDonationCheckoutResponse
            {
                CheckoutSessionId = session.Id,
                CheckoutUrl = session.Url
            }
        };
    }

    public async Task<ServiceResponse<List<UserDonation>>> GetDonationsAsync()
    {
        var response = new ServiceResponse<List<UserDonation>>();

        await using var db = await _factory.CreateDbContextAsync();

        var donations = await db.UserDonations
            .AsNoTracking()
            .Where(d => d.PaidUtc.HasValue)
            .OrderByDescending(x => x.CreatedUtc)
            .ToListAsync();

        response.IsSuccessful = true;
        response.Data = donations;
        return response;
    }

    private ServiceResponse<CreateDonationCheckoutResponse> ValidateDonationRequest(CreateDonationCheckoutRequest request)
    {
        if (request is null)
            return new ServiceResponse<CreateDonationCheckoutResponse> { IsSuccessful = false, Message = "Request cannot be null." };

        if (string.IsNullOrWhiteSpace(request.AppUserId))
            return new ServiceResponse<CreateDonationCheckoutResponse> { IsSuccessful = false, Message = "AppUserId is required." };

        if (request.AmountDollars < 1 || request.AmountDollars > 500)
            return new ServiceResponse<CreateDonationCheckoutResponse> { IsSuccessful = false, Message = "Contribution amount must be between $1 and $500." };

        if (string.IsNullOrWhiteSpace(request.Email))
            return new ServiceResponse<CreateDonationCheckoutResponse> { IsSuccessful = false, Message = "Email is required." };

        return new ServiceResponse<CreateDonationCheckoutResponse> { IsSuccessful = true };
    }

    private static string NormalizeCurrency(string? currency)
        => string.IsNullOrWhiteSpace(currency) ? "usd" : currency.Trim().ToLowerInvariant();

    private async Task<UserStripe> GetOrCreateUserStripeAsync(ApplicationDbContext db, string appUserId)
    {
        var map = await db.UserStripe.FirstOrDefaultAsync(x => x.AppUserId == appUserId);

        if (map is not null) return map;

        map = new UserStripe
        {
            AppUserId = appUserId,
            Status = AccountabilityStatus.Pending,
            CreatedUtc = DateTime.UtcNow,
            UpdatedUtc = DateTime.UtcNow
        };

        db.UserStripe.Add(map);
        await db.SaveChangesAsync();

        return map;
    }

    private async Task EnsureStripeCustomerAsync(ApplicationDbContext db, UserStripe map, string? email)
    {
        if (!string.IsNullOrWhiteSpace(map.StripeCustomerId))
            return;

        var customerService = new CustomerService(_stripeClient);

        var customer = await customerService.CreateAsync(new CustomerCreateOptions
        {
            Email = email,
            Metadata = new Dictionary<string, string>
            {
                ["app_user_id"] = map.AppUserId,
                ["purpose"] = "tcsa_contribution"
            }
        });

        map.StripeCustomerId = customer.Id;
        map.UpdatedUtc = DateTime.UtcNow;

        await db.SaveChangesAsync();
    }

    private async Task<Session> CreateDonationCheckoutSessionAsync(string stripeCustomerId, UserDonation donation, string currency)
    {
        var sessionService = new SessionService(_stripeClient);

        var successUrl = $"{_stripeOptions.BaseUrl}/contribute/success?session_id={{CHECKOUT_SESSION_ID}}";
        var cancelUrl = $"{_stripeOptions.BaseUrl}/contribute/cancel";

        return await sessionService.CreateAsync(new SessionCreateOptions
        {
            Mode = "payment",
            Customer = stripeCustomerId,
            SuccessUrl = successUrl,
            CancelUrl = cancelUrl,

            LineItems = new List<SessionLineItemOptions>
            {
                new SessionLineItemOptions
                {
                    Quantity = 1,
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        Currency = currency,
                        UnitAmount = donation.AmountCents,
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = "Support The C# Academy"
                        }
                    }
                }
            },

            Metadata = new Dictionary<string, string>
            {
                ["type"] = "contribution",
                ["contribution_id"] = donation.Id.ToString(),
                ["app_user_id"] = donation.AppUserId,
                ["amount_cents"] = donation.AmountCents.ToString(),
                ["currency"] = currency
            }
        });
    }
}
