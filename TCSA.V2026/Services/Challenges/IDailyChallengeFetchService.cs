using TCSA.V2026.Data.Models;

namespace TCSA.V2026.Services.Challenges;

public interface IDailyChallengeFetchService
{
    Task<Challenge?> FetchDailyChallenge();
}
