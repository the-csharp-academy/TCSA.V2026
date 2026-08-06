using System.Net;

namespace TCSA.V2026.IntegrationTests;

internal class MockHttpMessageHandler : HttpMessageHandler
{
    private readonly string? _json;
    private readonly HttpStatusCode _statusCode;

    public MockHttpMessageHandler(string? json, HttpStatusCode statusCode = HttpStatusCode.OK)
    {
        _json = json;
        _statusCode = statusCode;
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var response = new HttpResponseMessage(_statusCode);
        if (_json is not null)
            response.Content = new StringContent(_json, System.Text.Encoding.UTF8, "application/json");
        return Task.FromResult(response);
    }
}
