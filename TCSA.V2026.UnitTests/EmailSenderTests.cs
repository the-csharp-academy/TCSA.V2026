using System.Net;
using System.Text.Json;
using Microsoft.Extensions.Options;
using TCSA.V2026.Data.Models.Options;
using Moq;
using TCSA.V2026.Services;

namespace TCSA.V2026.UnitTests;

public class EmailSenderTests
{
    [TestCase(HttpStatusCode.Created)]
    [TestCase(HttpStatusCode.Unauthorized)]
    public async Task SendEmailAsync_UsesBrevoAndPropagatesRejection(HttpStatusCode status)
    {
        var handler = new RecordingHandler(status);
        var factory = new Mock<IHttpClientFactory>();
        factory.Setup(f => f.CreateClient(It.IsAny<string>())).Returns(() => new HttpClient(handler));
        var options = Options.Create(new BrevoOptions
        {
            ApiKey = "test-key",
            SenderEmail = "noreply@example.com",
            SenderName = "Academy",
            ReplyToEmail = "support@example.com"
        });
        var sender = new EmailSender(options, factory.Object);

        if (status == HttpStatusCode.Created)
            await sender.SendEmailAsync("student@example.com", "Reset", "<a href='https://example.com/reset'>Reset</a>");
        else
        {
            var error = Assert.ThrowsAsync<HttpRequestException>(() =>
                sender.SendEmailAsync("student@example.com", "Reset", "<a href='https://example.com/reset'>Reset</a>"));
            Assert.That(error!.StatusCode, Is.EqualTo(status));
            Assert.That(error.Message, Does.Contain("credit limit"));
        }

        Assert.That(handler.Uri, Is.EqualTo("https://api.brevo.com/v3/smtp/email"));
        Assert.That(handler.ApiKey, Is.EqualTo("test-key"));
        using var body = JsonDocument.Parse(handler.Body!);
        Assert.That(body.RootElement.GetProperty("sender").GetProperty("email").GetString(), Is.EqualTo("noreply@example.com"));
        Assert.That(body.RootElement.GetProperty("replyTo").GetProperty("email").GetString(), Is.EqualTo("support@example.com"));
        Assert.That(body.RootElement.GetProperty("to")[0].GetProperty("email").GetString(), Is.EqualTo("student@example.com"));
        Assert.That(body.RootElement.GetProperty("htmlContent").GetString(), Does.Contain("https://example.com/reset"));
    }

    private sealed class RecordingHandler(HttpStatusCode status) : HttpMessageHandler
    {
        public string? Uri { get; private set; }
        public string? ApiKey { get; private set; }
        public string? Body { get; private set; }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Uri = request.RequestUri!.ToString();
            ApiKey = request.Headers.GetValues("api-key").Single();
            Body = await request.Content!.ReadAsStringAsync(cancellationToken);
            return new HttpResponseMessage(status) { Content = new StringContent("{\"message\":\"credit limit\"}") };
        }
    }
}
