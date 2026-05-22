using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Playwright;
using TCSA.V2026.Data;

namespace TCSA.V2026.EndToEndTests;

public class EndToEndTestsBase : PageTest
{
    protected EndToEndTestFactory Factory => AssemblySetup.Factory;
    protected string BaseUrl => Factory.ClientOptions.BaseAddress.ToString().TrimEnd('/');

    [SetUp]
    public async Task SetUp()
    {
        await SeedData.Seed(Factory.Services);
    }

    protected async Task LoginAsTestUserAsync(string email, string password)
    {
        await Page.GotoAsync($"{BaseUrl}/Account/Login");
        await Page.GetByLabel("Email").FillAsync(email);
        await Page.GetByLabel("Password").FillAsync(password);
        await Page.GetByRole(AriaRole.Button, new() { Name = "Log in", Exact = true }).ClickAsync();
        await Page.WaitForURLAsync($"{BaseUrl}/");
    }
}
