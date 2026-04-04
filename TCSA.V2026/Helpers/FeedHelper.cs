using TCSA.V2026.Data.Curriculum;
using TCSA.V2026.Data.DTOs;
using TCSA.V2026.Data.Models;

namespace TCSA.V2026.Helpers;

public static class FeedHelper
{
    public static FeedDisplay MapUserToFeedDisplay(ApplicationUser user)
    {
        return new FeedDisplay
        {
            UserId = user.Id,
            DisplayName = user.DisplayName,
            UserName = user.UserName,
            ActivityType = ActivityType.NewUser,
            Date = user.CreatedDate
        };
    }

    public static FeedDisplay MapActivityToFeedDisplay(AppUserActivity activity)
    {
        return new FeedDisplay
        {
            ProjectId = activity.ProjectId,
            UserId = activity.ApplicationUser.Id,
            DisplayName = activity.ApplicationUser.DisplayName,
            UserName = activity.ApplicationUser.UserName,
            ActivityType = activity.ActivityType,
            Date = activity.DateSubmitted,
            Level = activity.Level,
            ProjectIconUrl = ProjectHelper.GetProjectIconUrl(activity.ProjectId),
            ProjectName = ProjectHelper.GetProjectName(activity.ProjectId)
        };
    }
}
