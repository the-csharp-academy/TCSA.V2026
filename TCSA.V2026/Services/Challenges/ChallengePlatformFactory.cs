using TCSA.V2026.Data.Models;

namespace TCSA.V2026.Services.Challenges;

public class ChallengePlatformFactory : IChallengePlatformFactory
{
    private readonly IServiceProvider _serviceProvider;
    public ChallengePlatformFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IChallengePlatformService GetCodingPlatformService(ChallengePlatform challengePlatform)
    {
        return _serviceProvider.GetRequiredKeyedService<IChallengePlatformService>(challengePlatform);
    }
}
