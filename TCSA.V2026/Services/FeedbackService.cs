using Microsoft.EntityFrameworkCore;
using TCSA.V2026.Data;
using TCSA.V2026.Data.DTOs;
using TCSA.V2026.Data.Enums;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Data.Models.Responses;
using TCSA.V2026.Helpers;
using TCSA.V2026.Helpers.Constants;

namespace TCSA.V2026.Services;

public interface IFeedbackService
{
    Task<Result> Submit(string userId, FeedbackSubmissionDto submission);
}

public class FeedbackService(IDbContextFactory<ApplicationDbContext> _factory, ILogger<FeedbackService> _logger) : IFeedbackService
{
    public async Task<Result> Submit(string userId, FeedbackSubmissionDto submission)
    {
        var invalid = Validate(userId, submission);
        if (invalid is not null)
        {
            return Result.Failure(invalid);
        }

        try
        {
            using var context = _factory.CreateDbContext();

            var now = DateTimeOffset.UtcNow;
            var windowStart = now - FeedbackLimits.RateLimitWindow;
            var recentCount = await context.FeedbackItems
                .CountAsync(f => f.AppUserId == userId && f.CreatedAt >= windowStart);

            if (recentCount >= FeedbackLimits.RateLimitMaxSubmissions)
            {
                return Result.Failure(new Error(FeedbackErrorCodes.RateLimited,
                    "You've sent a lot of feedback in a short time. Please try again in a few minutes."));
            }

            var isBug = submission.Category == FeedbackCategory.Bug;

            var item = new FeedbackItem
            {
                AppUserId = userId,
                Category = submission.Category,
                Body = submission.Description!.Trim(),
                OriginUrl = Truncate(FeedbackPageHelper.Normalize(submission.OriginUrl), FeedbackLimits.OriginUrlMaxLength),
                Area = isBug ? submission.Area : null,
                ReportedPage = isBug ? FeedbackPageHelper.Normalize(submission.Page) : null,
                ReviewState = EntersReviewQueue(submission.Category) ? FeedbackReviewState.New : null,
                CreatedAt = now
            };

            context.FeedbackItems.Add(item);
            await context.SaveChangesAsync();

            return Result.Success(new Success(FeedbackErrorCodes.Submitted, "Thanks for your feedback!"));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to save feedback for user {UserId}", userId);
            return Result.Failure(new Error(FeedbackErrorCodes.Unexpected, "Something went wrong while sending your feedback. Please try again."));
        }
    }

    private static Error? Validate(string userId, FeedbackSubmissionDto submission)
    {
        if (string.IsNullOrWhiteSpace(userId))
        {
            return new Error(FeedbackErrorCodes.UserRequired, "You need to be signed in to send feedback.");
        }

        if (!Enum.IsDefined(submission.Category))
        {
            return new Error(FeedbackErrorCodes.CategoryInvalid, "Please choose a valid feedback category.");
        }

        var descriptionLength = submission.Description?.Trim().Length ?? 0;
        if (descriptionLength < FeedbackLimits.DescriptionMinLength || descriptionLength > FeedbackLimits.DescriptionMaxLength)
        {
            return new Error(FeedbackErrorCodes.DescriptionLength,
                $"Please write between {FeedbackLimits.DescriptionMinLength} and {FeedbackLimits.DescriptionMaxLength} characters.");
        }

        if (submission.Category != FeedbackCategory.Bug)
        {
            return null;
        }

        if (submission.Area is not { } area || !Enum.IsDefined(area))
        {
            return new Error(FeedbackErrorCodes.AreaRequired, "Please choose the area the bug is in.");
        }

        if (string.IsNullOrWhiteSpace(submission.Page))
        {
            return new Error(FeedbackErrorCodes.PageRequired, "Please tell us which page the bug is on.");
        }

        if (FeedbackPageHelper.Normalize(submission.Page).Length > FeedbackLimits.PageMaxLength)
        {
            return new Error(FeedbackErrorCodes.PageTooLong, $"The page can be at most {FeedbackLimits.PageMaxLength} characters.");
        }

        return null;
    }

    private static bool EntersReviewQueue(FeedbackCategory category) =>
        category is FeedbackCategory.Bug or FeedbackCategory.Idea;

    private static string Truncate(string value, int maxLength) =>
        value.Length <= maxLength ? value : value[..maxLength];
}
