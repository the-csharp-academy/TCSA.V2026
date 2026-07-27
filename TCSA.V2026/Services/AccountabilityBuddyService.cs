using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Stripe;
using Stripe.Checkout;
using TCSA.V2026.Data;
using TCSA.V2026.Data.Enums;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Data.Models.Options;
using TCSA.V2026.Data.Models.Responses;
using TCSA.V2026.Models;

namespace TCSA.V2026.Services;

public interface IAccountabilityBuddyService
{
    Task<ServiceResponse<EnableAccountabilityResponse>> EnableAsync(EnableAccountabilityRequest request);
    Task<ServiceResponse<UserAccountabilityProject>> GetUserAccountability(string userId, int projectId);
}

public class AccountabilityBuddyService : IAccountabilityBuddyService
{
    private readonly IDbContextFactory<ApplicationDbContext> _factory;
    private readonly IStripeClient _stripeClient;
    IOptions<StripeOptions> _stripeOptions;

    public AccountabilityBuddyService(
        IDbContextFactory<ApplicationDbContext> factory,
        IOptions<StripeOptions> stripeOptions,
        IHttpClientFactory httpClientFactory,
        IStripeClient stripeClient)
    {
        _stripeOptions = stripeOptions;
        _stripeClient = stripeClient;
        _factory = factory;
    }

    public async Task<ServiceResponse<UserAccountabilityProject>> GetUserAccountability(string userId, int projectId)
    {
        var response = new ServiceResponse<UserAccountabilityProject>();

        using var _context = await _factory.CreateDbContextAsync();
        var accountability = await _context.UserAccountabilityProjects
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.AppUserId == userId && x.ProjectId == projectId);

        if (accountability is null)
        {
            response.IsSuccessful = true;
            response.Message = "No accountability found for the specified user and project.";
            return response;
        }

        response.IsSuccessful = true;
        response.Data = accountability;
        return response;
    }

    public async Task<ServiceResponse<EnableAccountabilityResponse>> EnableAsync(EnableAccountabilityRequest request)
    {
        var serviceResponse = ValidateRequest(request);
        if (!serviceResponse.IsSuccessful) return serviceResponse;

        using var _context = await _factory.CreateDbContextAsync();

        // 1) Ensure mapping row exists
        var account = await _context.UserStripe.FirstOrDefaultAsync(x => x.AppUserId == request.TcsaUserId);
        if (account is null)
        {
            account = new UserStripe
            {
                AppUserId = request.TcsaUserId,
                Status = AccountabilityStatus.Pending,
                CreatedUtc = DateTime.UtcNow,
                UpdatedUtc = DateTime.UtcNow
            };

            _context.UserStripe.Add(account);
            await _context.SaveChangesAsync();
        }

        // 2) Ensure Stripe customer exists
        if (string.IsNullOrWhiteSpace(account.StripeCustomerId))
        {
            var customerService = new CustomerService(_stripeClient);

            var customer = await customerService.CreateAsync(new CustomerCreateOptions
            {
                Email = request.Email,
                Metadata = new Dictionary<string, string>
                {
                    ["app_user_id"] = request.TcsaUserId.ToString()
                }
            });

            account.StripeCustomerId = customer.Id;
            account.UpdatedUtc = DateTime.UtcNow;
            await _context.SaveChangesAsync();
        }

        var accountability = new UserAccountabilityProject
        {
            AppUserId = request.TcsaUserId.ToString(),
            ProjectId = request.ProjectId,
            CreatedUtc = DateTime.UtcNow,
            DeadLineUtc = DateTime.UtcNow.AddDays(request.DeadlineDays),
            Status = AccountabilityProjectStatus.Active,
            Currency = "usd",
            PledgeCents = request.PledgeAmount * 100
        };

        _context.UserAccountabilityProjects.Add(accountability);
        await _context.SaveChangesAsync(); // <-- generates accountability.Id

        // 4) If payment method already saved, no redirect needed
        if (!string.IsNullOrWhiteSpace(account.StripePaymentMethodId))
        {
            account.Status = AccountabilityStatus.Active;
            account.UpdatedUtc = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            return new ServiceResponse<EnableAccountabilityResponse>
            {
                IsSuccessful = true,
                Message = "Accountability Buddy activated.",
                Data = new EnableAccountabilityResponse
                {
                    StripeCustomerId = account.StripeCustomerId,
                    CheckoutSessionId = null,
                    CheckoutUrl = null
                }
            };
        }

        var sessionService = new SessionService(_stripeClient);

        var session = await sessionService.CreateAsync(new SessionCreateOptions
        {
            Mode = "setup",
            Customer = account.StripeCustomerId,
            Currency = "usd",
            ClientReferenceId = request.TcsaUserId.ToString(),

            ConsentCollection = new SessionConsentCollectionOptions
            {
                PaymentMethodReuseAgreement = new SessionConsentCollectionPaymentMethodReuseAgreementOptions
                {
                    Position = "auto"
                }
            },

            SetupIntentData = new SessionSetupIntentDataOptions
            {
                Description = "TCSA AccountabilityMate - save payment method",
                Metadata = new Dictionary<string, string>
                {
                    ["app_user_id"] = request.TcsaUserId.ToString(),
                    ["purpose"] = "accountability_setup",
                    ["accountability_project_id"] = accountability.Id.ToString(),
                    ["project_id"] = request.ProjectId.ToString(),
                    ["pledge_cents"] = accountability.PledgeCents.ToString(),
                    ["deadline_utc"] = accountability.DeadLineUtc.ToString("O")
                }
            },
            SuccessUrl = $"{_stripeOptions.Value.BaseUrl}/billing/success?session_id={{CHECKOUT_SESSION_ID}}",
            CancelUrl = $"{_stripeOptions.Value.BaseUrl}/billing/cancel",
        });

        account.Status = AccountabilityStatus.Pending;
        account.UpdatedUtc = DateTime.UtcNow;
        await _context.SaveChangesAsync();

        return new ServiceResponse<EnableAccountabilityResponse>
        {
            IsSuccessful = true,
            Message = "Redirect the user to Stripe Checkout to save a payment method.",
            Data = new EnableAccountabilityResponse
            {
                StripeCustomerId = account.StripeCustomerId,
                CheckoutSessionId = session.Id,
                CheckoutUrl = session.Url
            }
        };
    }

    private ServiceResponse<EnableAccountabilityResponse> ValidateRequest(EnableAccountabilityRequest request)
    {
        var result = new ServiceResponse<EnableAccountabilityResponse>();

        if (request is null)
        {
            result.IsSuccessful = false;
            result.Message = "Request cannot be null.";
            return result;
        }

        if (string.IsNullOrWhiteSpace(request.TcsaUserId))
        {
            result.IsSuccessful = false;
            result.Message = "TcsaUserId is required.";
            return result;
        }

        result.IsSuccessful = true;

        return result;
    }
}