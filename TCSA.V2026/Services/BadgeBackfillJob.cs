namespace TCSA.V2026.Services;

public class BadgeBackfillJob(IUserService userService, IBadgeService badgeService)
{
    private const int BatchSize = 100;

    public async Task RunAsync()
    {
        var pendingUserIds = await userService.GetUserIdsPendingBackfill(BatchSize);

        foreach (var userId in pendingUserIds)
        {
            await badgeService.AwardMissingBadges(userId);
        }
    }
}
