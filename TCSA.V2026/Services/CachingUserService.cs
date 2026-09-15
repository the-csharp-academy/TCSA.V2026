using Microsoft.Extensions.Caching.Hybrid;
using TCSA.V2026.Data.DTOs;
using TCSA.V2026.Data.DTOs.PublicProfile;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Data.Models.Responses;

namespace TCSA.V2026.Services;

public class CachingUserService : IUserService
{
    private readonly IUserService _userService;
    private readonly HybridCache _cache;

    public CachingUserService(IUserService userService, HybridCache cache)
    {
        _userService = userService;
        _cache = cache;
    }

    public Task<ApplicationUser> GetUserById(string userId) => _userService.GetUserById(userId);
    public Task<ApplicationUser> GetUserForDashboard(string userId) => _userService.GetUserForDashboard(userId);
    public Task<ApplicationUser> GetDetailedUserById(string userId) => _userService.GetDetailedUserById(userId);
    public Task<ApplicationUser> GetUserProfileById(string userId) => _userService.GetUserProfileById(userId);
    public Task<BaseResponse> SaveProfile(ApplicationUser user) => _userService.SaveProfile(user);
    public Task<BaseResponse> ResetAccount(ApplicationUser user) => _userService.ResetAccount(user);
    public Task<BaseResponse> DeleteAccount(ApplicationUser user) => _userService.DeleteAccount(user);
    public Task<ApplicationUser?> GetUserByIdWithShowcaseItems(string? userid) => _userService.GetUserByIdWithShowcaseItems(userid);
    public Task<List<ApplicationUser>> GetRecentlyJoinedUsers(int count) => _userService.GetRecentlyJoinedUsers(count);
    public Task<BaseResponse> AcknowledgeBeltNotification(string userId) => _userService.AcknowledgeBeltNotification(userId);
    public Task<OnboardingStatusDto> GetOnboardingStatus(string userId) => _userService.GetOnboardingStatus(userId);
    public Task<BaseResponse> MarkWelcomeSeen(string userId) => _userService.MarkWelcomeSeen(userId);
    public Task<BaseResponse> MarkTourCompleted(string userId) => _userService.MarkTourCompleted(userId);
    public Task<BaseResponse> MarkChecklistDismissed(string userId) => _userService.MarkChecklistDismissed(userId);
    public Task<BaseResponse> RestartOnboarding(string userId) => _userService.RestartOnboarding(userId);
    public Task<BaseResponse> ResumeChecklist(string userId) => _userService.ResumeChecklist(userId);

    public async Task<BaseResponse> GetPublicProfile(string userId)
    {
        var key = $"public-profile-{userId}";

        var profile = await _cache.GetOrCreateAsync(
            key: key,
            factory: async _ =>
            {
                var response = await _userService.GetPublicProfile(userId);
                return response.Status == ResponseStatus.Success
                    ? response.Data as PublicProfileResponse
                    : null;
            },
            options: new HybridCacheEntryOptions
            {
                LocalCacheExpiration = TimeSpan.FromMinutes(5),
            }
        );

        if (profile != null)
        {
            return new BaseResponse { Status = ResponseStatus.Success, Data = profile };
        }

        return await _userService.GetPublicProfile(userId);
    }
}
