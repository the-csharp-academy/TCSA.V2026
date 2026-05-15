using Microsoft.Playwright;
using System.Text;

namespace TCSA.V2026.EndToEndTests;

[TestFixture]
[NonParallelizable]
public class PeerReviewAutoRefreshTests : EndToEndTestsBase
{
    private const long HabitLoggerRepoId = 573675655;
    private const int HabitLoggerPrNumber = 392;

    [Test]
    public async Task PeerReviewPage_AutoRefreshes_WhenGithubWebhookApprovesAssignedProject()
    {
        // Arrange
        await LoginAsTestUserAsync("user1@example.com", "Password123!");
        await Page.GotoAsync($"{BaseUrl}/dashboard/reviews");

        var habitLoggerCard = Page.Locator(".peer-review-card").Filter(new() { HasText = "Habit Logger" });
        await habitLoggerCard.GetByRole(AriaRole.Button, new() { Name = "Pick" }).ClickAsync();
        await Expect(habitLoggerCard.GetByRole(AriaRole.Button, new() { Name = "Tick" })).ToBeVisibleAsync();

        // Act
        await SendGithubPullRequestWebhook(HabitLoggerRepoId, HabitLoggerPrNumber);

        // Assert
        await Expect(habitLoggerCard).Not.ToBeVisibleAsync();
    }

    private async Task SendGithubPullRequestWebhook(long repoId, int prNumber)
    {
        using var client = Factory.CreateClient();
        var request = new HttpRequestMessage(HttpMethod.Post, "/api/github")
        {
            Content = new StringContent(
                $$"""
                {
                    "action": "submitted",
                    "repository": {
                        "id": {{repoId}}
                    },
                    "review": {
                        "state": "approved"
                    },
                    "pull_request": {
                        "number": {{prNumber}},
                        "html_url": "",
                        "user": {
                            "login": ""
                        }
                    }
                }
                """,
                Encoding.UTF8,
                "application/json")
        };
        request.Headers.Add("X-GitHub-Event", "pull_request_review");
        await client.SendAsync(request);
    }
}
