using TCSA.V2026.Services;

namespace TCSA.V2026.Services.Challenges;

public class DailyChallengeJob(IServiceScopeFactory scopeFactory) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var timer = new PeriodicTimer(TimeSpan.FromDays(1));

        while (await timer.WaitForNextTickAsync(stoppingToken))
        {
            using var scope = scopeFactory.CreateScope();
            var fetchers = scope.ServiceProvider.GetServices<IDailyChallengeFetchService>();
            var challengeService = scope.ServiceProvider.GetRequiredService<IChallengeService>();

            foreach (var fetcher in fetchers)
            {
                var challenge = await fetcher.FetchDailyChallenge();
                if (challenge is not null)
                    await challengeService.AddChallenge(challenge);
            }
        }
    }
}
