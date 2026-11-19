using TCSA.V2026.Data.DTOs;
using TCSA.V2026.Data.Models;

namespace TCSA.V2026.Helpers;

public static class FeedbackItemExtensions
{
    public static IQueryable<FeedbackAdminItemDto> ToDto(this IQueryable<FeedbackItem> items) =>
        items.Select(f => new FeedbackAdminItemDto
        {
            Id = f.Id,
            Category = f.Category,
            Area = f.Area,
            ReportedPage = f.ReportedPage,
            OriginUrl = f.OriginUrl,
            Body = f.Body,
            ReviewState = f.ReviewState,
            CreatedAt = f.CreatedAt,
            UserId = f.AppUserId,
            UserName = f.AppUser.UserName ?? string.Empty,
            UserDisplayName = f.AppUser.DisplayName
        });
}
