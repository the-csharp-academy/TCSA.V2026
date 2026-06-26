namespace TCSA.V2026.EndToEndTests;

[NonParallelizable]
[TestFixture]
public class RegisterPageTests : EndToEndTestsBase
{
    [Test]
    public async Task Register_DoubleSubmit_ShouldStillRedirectToHome()
    {
        var email = $"e2e-register-{Guid.NewGuid():N}@example.com";

        await Page.GotoAsync($"{BaseUrl}/Account/Register");

        await Page.GetByLabel("DisplayName").FillAsync("E2E User");
        await Page.GetByLabel("Email").FillAsync(email);
        await Page.GetByLabel("Password", new() { Exact = true }).FillAsync("Password123!");
        await Page.GetByLabel("Confirm Password", new() { Exact = true }).FillAsync("Password123!");

        await Page.Locator("#country-select .custom-select-trigger").ClickAsync();
        await Page.Locator("#country-options .custom-select-option").First.ClickAsync();

        var registerButton = Page.Locator("form [type='submit']").First;

        await registerButton.DblClickAsync();

        await Expect(Page).ToHaveURLAsync($"{BaseUrl}/");
        await Expect(Page.GetByText("An account with this email already exists.")).Not.ToBeVisibleAsync();
    }

    [Test]
    public async Task NewUser_AfterRegistration_CompletesOnboardingFlow()
    {
        var email = $"e2e-onboarding-{Guid.NewGuid():N}@example.com";

        await Page.GotoAsync($"{BaseUrl}/Account/Register");

        await Page.GetByLabel("DisplayName").FillAsync("Onboarding User");
        await Page.GetByLabel("Email").FillAsync(email);
        await Page.GetByLabel("Password", new() { Exact = true }).FillAsync("Password123!");
        await Page.GetByLabel("Confirm Password", new() { Exact = true }).FillAsync("Password123!");

        await Page.Locator("#country-select .custom-select-trigger").ClickAsync();
        await Page.Locator("#country-options .custom-select-option").First.ClickAsync();

        await Page.Locator("form [type='submit']").First.ClickAsync();
        await Page.WaitForURLAsync($"{BaseUrl}/");

        await CompleteOnboardingFlowAsync();

        await Expect(Page.Locator(".shepherd-element")).Not.ToBeVisibleAsync();
    }
}
