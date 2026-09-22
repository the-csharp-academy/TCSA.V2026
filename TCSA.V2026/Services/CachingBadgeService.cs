using Microsoft.Extensions.Caching.Hybrid;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Data.Models.Responses;

namespace TCSA.V2026.Services;

public class CachingBadgeService : IBadgeService
{
    private readonly IBadgeService _badgeService;
    private readonly HybridCache _cache;

    public CachingBadgeService(IBadgeService badgeService, HybridCache cache)
    {
        _badgeService = badgeService;
        _cache = cache;
    }

    public Task<IEnumerable<Badge>> GetRecentAwardedBadges(string userId, DateTimeOffset since) => _badgeService.GetRecentAwardedBadges(userId, since);
    public Task<BaseResponse> AwardBadge(string userId, int badgeId) => _badgeService.AwardBadge(userId, badgeId);
    public Task AwardPlatformBuilderBadges(string userId) => _badgeService.AwardPlatformBuilderBadges(userId);
    public Task AwardReviewBadges(string userId, int reviewedProjectsCount) => _badgeService.AwardReviewBadges(userId, reviewedProjectsCount);
    public Task<BaseResponse> AcknowledgeBadgeNotifications(string userId) => _badgeService.AcknowledgeBadgeNotifications(userId);
    public Task AwardMissingBadges(string userId) => _badgeService.AwardMissingBadges(userId);

    public async Task<IEnumerable<Badge>> GetUserAwardedBadges(string userId)
    {
        var key = $"user-awarded-badges-{userId}";

        return await _cache.GetOrCreateAsync(
            key: key,
            factory: async _ => await _badgeService.GetUserAwardedBadges(userId),
            options: new HybridCacheEntryOptions
            {
                LocalCacheExpiration = TimeSpan.FromMinutes(5),
            }
        );
    }
}
