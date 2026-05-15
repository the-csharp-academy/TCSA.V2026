using Microsoft.Extensions.Caching.Hybrid;
using TCSA.V2026.Data.DTOs;

namespace TCSA.V2026.Services;

public class CachingStatisticsService : IStatisticsService
{
    private readonly IStatisticsService _statisticsService;
    private readonly HybridCache _cache;

    public CachingStatisticsService(IStatisticsService statisticsService, HybridCache cache)
    {
        _statisticsService = statisticsService;
        _cache = cache;
    }

    public async Task<HomePageStatistics> GetHomePageStatisticsAsync()
    {
        var key = "HomePageStatistics";

        return await _cache.GetOrCreateAsync(
            key: key,
            factory: async _ => await _statisticsService.GetHomePageStatisticsAsync(),
            options: new HybridCacheEntryOptions
            {
                LocalCacheExpiration = TimeSpan.FromMinutes(5),
            }
        );
    }
}
