namespace TCSA.V2026.Services.Challenges;

public class DailyChallengeJob(
    IEnumerable<IDailyChallengeFetchService> fetchers,
    IChallengeService challengeService
)
{
    public async Task RunAsync()
    {
        foreach (var fetcher in fetchers)
        {
            var challenge = await fetcher.FetchDailyChallenge();
            if (challenge is not null)
                await challengeService.AddChallenge(challenge);
        }
    }
}
