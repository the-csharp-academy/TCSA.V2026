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
            var challenges = await fetcher.FetchDailyChallenges();
            foreach (var challenge in challenges)
                await challengeService.AddChallenge(challenge);
        }
    }
}
