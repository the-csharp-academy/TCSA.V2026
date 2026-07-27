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

    protected async Task CompleteOnboardingFlowAsync()
    {
        var dialog = Page.Locator(".mud-dialog");
        await dialog.WaitForAsync();

        var getStartedButton = dialog.GetByRole(AriaRole.Button, new() { Name = "Get Started" });
        var nextButton = dialog.GetByRole(AriaRole.Button, new() { Name = "Next" });

        while (!await getStartedButton.IsVisibleAsync())
        {
            await nextButton.ClickAsync();
        }
        await getStartedButton.ClickAsync();

        var tour = Page.Locator(".shepherd-element");
        await tour.WaitForAsync();

        var finishButton = tour.GetByRole(AriaRole.Button, new() { Name = "Finish" });
        var tourNextButton = tour.GetByRole(AriaRole.Button, new() { Name = "Next" });

        while (!await finishButton.IsVisibleAsync())
        {
            await tourNextButton.ClickAsync();
        }
        await finishButton.ClickAsync();
    }
}
