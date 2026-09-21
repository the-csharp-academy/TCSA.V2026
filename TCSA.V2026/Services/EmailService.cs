using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using System.Net.Http.Json;
using Microsoft.Extensions.Options;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Data.Models.Options;

namespace TCSA.V2026.Services;

public interface ICustomEmailSender : IEmailSender<ApplicationUser>
{
    Task SendEmailAsync(string toEmail, string subject, string message);
    Task SendConfirmationLinkAsync(ApplicationUser user, string email, string confirmationLink);
    Task SendPasswordResetLinkAsync(ApplicationUser user, string email, string resetLink);
    Task SendPasswordResetCodeAsync(ApplicationUser user, string email, string resetCode);
}

public class EmailSender : ICustomEmailSender
{
    private readonly BrevoOptions _options;
    private readonly IHttpClientFactory _httpClientFactory;

    public EmailSender(IOptions<BrevoOptions> options, IHttpClientFactory httpClientFactory)
    {
        _options = options.Value;
        _httpClientFactory = httpClientFactory;
    }

    public async Task SendEmailAsync(string toEmail, string subject, string message)
    {
        using var client = _httpClientFactory.CreateClient();
        using var request = new HttpRequestMessage(HttpMethod.Post, "https://api.brevo.com/v3/smtp/email");
        request.Headers.Add("api-key", _options.ApiKey);
        request.Content = JsonContent.Create(new
        {
            sender = new { email = _options.SenderEmail, name = _options.SenderName },
            to = new[] { new { email = toEmail } },
            replyTo = new { email = _options.ReplyToEmail },
            subject,
            htmlContent = message
        });

        using var response = await client.SendAsync(request);
        if (!response.IsSuccessStatusCode)
        {
            var errorBody = await response.Content.ReadAsStringAsync();
            throw new HttpRequestException(
                $"Brevo rejected the email ({(int)response.StatusCode}): {errorBody}",
                null,
                response.StatusCode);
        }
    }
    public Task SendConfirmationLinkAsync(ApplicationUser user, string email, string confirmationLink)
    {
        throw new NotImplementedException();
    }

    public async Task SendPasswordResetLinkAsync(ApplicationUser user, string email, string resetLink)
    {
        await SendEmailAsync(email, "Reset your password", $"Please reset your password by <a href='{resetLink}'>clicking here</a>.");

    }


    public Task SendPasswordResetCodeAsync(ApplicationUser user, string email, string resetCode) =>
        SendEmailAsync(email, "Reset your password", $"Please reset your password using the following code: {resetCode}");
}

public class CustomEmailConfirmationTokenProvider<TUser>
                              : DataProtectorTokenProvider<TUser> where TUser : class
{
    public CustomEmailConfirmationTokenProvider(
        IDataProtectionProvider dataProtectionProvider,
        IOptions<EmailConfirmationTokenProviderOptions> options,
        ILogger<DataProtectorTokenProvider<TUser>> logger)
                                       : base(dataProtectionProvider, options, logger)
    {

    }
}
public class EmailConfirmationTokenProviderOptions : DataProtectionTokenProviderOptions
{
    public EmailConfirmationTokenProviderOptions()
    {
        Name = "EmailDataProtectorTokenProvider";
        TokenLifespan = TimeSpan.FromHours(20);
    }
}
