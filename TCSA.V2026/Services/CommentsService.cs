using Microsoft.EntityFrameworkCore;
using TCSA.V2026.Data;
using TCSA.V2026.Data.Enums;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Data.Models.Responses;

namespace TCSA.V2026.Services;

public interface ICommentsService
{
    Task<List<Comments>> GetCommentsAsync(int articleId, string? viewerAppUserId = null);
    Task<List<Comments>> GetPendingCommentsAsync();
    Task<ServiceResponse> AddCommentAsync(int articleId, string appUserId, string comment);
    Task<ServiceResponse> ApproveCommentAsync(int commentId);
    Task<ServiceResponse> UpdateCommentAsync(int commentId, string requesterAppUserId, string comment);
    Task<ServiceResponse> DeleteCommentAsync(int commentId, string requesterAppUserId);
}

public class CommentsService(
    IDbContextFactory<ApplicationDbContext> factory,
    ILogger<CommentsService> logger) : ICommentsService
{
    public async Task<List<Comments>> GetCommentsAsync(int articleId, string? viewerAppUserId = null)
    {
        await using var context = await factory.CreateDbContextAsync();

        var isAdmin = !string.IsNullOrWhiteSpace(viewerAppUserId)
            && await IsAdminAsync(context, viewerAppUserId);

        var query = context.Comments
            .AsNoTracking()
            .Include(c => c.AppUser)
            .Where(c => c.ArticleId == articleId);

        if (!isAdmin)
        {
            query = query.Where(c => c.IsReviewed || c.AppUserId == viewerAppUserId);
        }

        return await query
            .OrderByDescending(c => c.Date)
            .ToListAsync();
    }

    public async Task<List<Comments>> GetPendingCommentsAsync()
    {
        await using var context = await factory.CreateDbContextAsync();

        return await context.Comments
            .AsNoTracking()
            .Include(c => c.AppUser)
            .Where(c => !c.IsReviewed)
            .OrderBy(c => c.Date)
            .ToListAsync();
    }

    public async Task<ServiceResponse> AddCommentAsync(int articleId, string appUserId, string comment)
    {
        var commentText = comment.Trim();

        if (articleId <= 0 || string.IsNullOrWhiteSpace(appUserId) || string.IsNullOrWhiteSpace(commentText))
        {
            return new ServiceResponse
            {
                IsSuccessful = false,
                Message = "A valid article, user, and comment are required."
            };
        }

        if (commentText.Length > 2000)
        {
            return new ServiceResponse
            {
                IsSuccessful = false,
                Message = "Comments cannot be longer than 2,000 characters."
            };
        }

        try
        {
            await using var context = await factory.CreateDbContextAsync();

            var user = await context.AspNetUsers
                .SingleOrDefaultAsync(user => user.Id == appUserId);

            if (user is null)
            {
                return new ServiceResponse
                {
                    IsSuccessful = false,
                    Message = "You must be logged in to post a comment."
                };
            }

            context.Comments.Add(new Comments
            {
                ArticleId = articleId,
                AppUserId = appUserId,
                Comment = commentText,
                Date = DateTimeOffset.UtcNow,
                IsReviewed = user.Level >= Level.Green || await IsAdminAsync(context, appUserId)
            });

            await context.SaveChangesAsync();

            return new ServiceResponse { IsSuccessful = true };
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "Unable to add a comment to article {ArticleId}", articleId);

            return new ServiceResponse
            {
                IsSuccessful = false,
                Message = "The comment could not be saved. Please try again."
            };
        }
    }

    public async Task<ServiceResponse> ApproveCommentAsync(int commentId)
    {
        await using var context = await factory.CreateDbContextAsync();
        var comment = await context.Comments.FindAsync(commentId);

        if (comment is null)
        {
            return new ServiceResponse
            {
                IsSuccessful = false,
                Message = "Comment not found."
            };
        }

        comment.IsReviewed = true;
        await context.SaveChangesAsync();

        return new ServiceResponse { IsSuccessful = true };
    }

    public async Task<ServiceResponse> UpdateCommentAsync(
        int commentId,
        string requesterAppUserId,
        string comment)
    {
        var commentText = comment.Trim();
        if (string.IsNullOrWhiteSpace(requesterAppUserId) || string.IsNullOrWhiteSpace(commentText))
        {
            return Failure("A logged-in user and comment are required.");
        }

        if (commentText.Length > 2000)
        {
            return Failure("Comments cannot be longer than 2,000 characters.");
        }

        await using var context = await factory.CreateDbContextAsync();
        var existingComment = await context.Comments.FindAsync(commentId);
        if (existingComment is null)
        {
            return Failure("Comment not found.");
        }

        var isAdmin = await IsAdminAsync(context, requesterAppUserId);
        if (existingComment.AppUserId != requesterAppUserId && !isAdmin)
        {
            return Failure("You cannot edit this comment.");
        }

        existingComment.Comment = commentText;
        if (!isAdmin)
        {
            existingComment.IsReviewed = false;
        }

        await context.SaveChangesAsync();
        return new ServiceResponse { IsSuccessful = true };
    }

    public async Task<ServiceResponse> DeleteCommentAsync(int commentId, string requesterAppUserId)
    {
        if (string.IsNullOrWhiteSpace(requesterAppUserId))
        {
            return Failure("You must be logged in to delete a comment.");
        }

        await using var context = await factory.CreateDbContextAsync();
        var comment = await context.Comments.FindAsync(commentId);
        if (comment is null)
        {
            return Failure("Comment not found.");
        }

        var isAdmin = await IsAdminAsync(context, requesterAppUserId);
        if (comment.AppUserId != requesterAppUserId && !isAdmin)
        {
            return Failure("You cannot delete this comment.");
        }

        context.Comments.Remove(comment);
        await context.SaveChangesAsync();
        return new ServiceResponse { IsSuccessful = true };
    }

    private static Task<bool> IsAdminAsync(ApplicationDbContext context, string appUserId)
    {
        return (from userRole in context.UserRoles
                join role in context.Roles on userRole.RoleId equals role.Id
                where userRole.UserId == appUserId && role.NormalizedName == "ADMIN"
                select userRole)
            .AnyAsync();
    }

    private static ServiceResponse Failure(string message)
    {
        return new ServiceResponse { IsSuccessful = false, Message = message };
    }
}
