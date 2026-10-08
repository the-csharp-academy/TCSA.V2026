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
    Task<Result> AddCommentAsync(int articleId, string appUserId, string comment);
    Task<Result> ApproveCommentAsync(int commentId);
    Task<Result> UpdateCommentAsync(int commentId, string requesterAppUserId, string comment);
    Task<Result> DeleteCommentAsync(int commentId, string requesterAppUserId);
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

    public async Task<Result> AddCommentAsync(int articleId, string appUserId, string comment)
    {
        var commentText = comment.Trim();

        if (articleId <= 0 || string.IsNullOrWhiteSpace(appUserId) || string.IsNullOrWhiteSpace(commentText))
        {
            return Result.Failure(new Error("Comment.InvalidRequest", "A valid article, user, and comment are required."));
        }

        if (commentText.Length > 2000)
        {
            return Result.Failure(new Error("Comment.TooLong", "Comments cannot be longer than 2,000 characters."));
        }

        try
        {
            await using var context = await factory.CreateDbContextAsync();

            var user = await context.AspNetUsers
                .SingleOrDefaultAsync(user => user.Id == appUserId);

            if (user is null)
            {
                return Result.Failure(new Error("Comment.NotLoggedIn", "You must be logged in to post a comment."));
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

            return Result.Success();
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "Unable to add a comment to article {ArticleId}", articleId);

            return Result.Failure(new Error("Comment.SaveFailed", "The comment could not be saved. Please try again."));
        }
    }

    public async Task<Result> ApproveCommentAsync(int commentId)
    {
        await using var context = await factory.CreateDbContextAsync();
        var comment = await context.Comments.FindAsync(commentId);

        if (comment is null)
        {
            return Result.Failure(new Error("Comment.NotFound", "Comment not found."));
        }

        comment.IsReviewed = true;
        await context.SaveChangesAsync();

        return Result.Success();
    }

    public async Task<Result> UpdateCommentAsync(
        int commentId,
        string requesterAppUserId,
        string comment)
    {
        var commentText = comment.Trim();
        if (string.IsNullOrWhiteSpace(requesterAppUserId) || string.IsNullOrWhiteSpace(commentText))
        {
            return Result.Failure(new Error("Comment.InvalidRequest", "A logged-in user and comment are required."));
        }

        if (commentText.Length > 2000)
        {
            return Result.Failure(new Error("Comment.TooLong", "Comments cannot be longer than 2,000 characters."));
        }

        await using var context = await factory.CreateDbContextAsync();
        var existingComment = await context.Comments.FindAsync(commentId);
        if (existingComment is null)
        {
            return Result.Failure(new Error("Comment.NotFound", "Comment not found."));
        }

        var isAdmin = await IsAdminAsync(context, requesterAppUserId);
        if (existingComment.AppUserId != requesterAppUserId && !isAdmin)
        {
            return Result.Failure(new Error("Comment.EditForbidden", "You cannot edit this comment."));
        }

        existingComment.Comment = commentText;
        if (!isAdmin)
        {
            existingComment.IsReviewed = false;
        }

        await context.SaveChangesAsync();
        return Result.Success();
    }

    public async Task<Result> DeleteCommentAsync(int commentId, string requesterAppUserId)
    {
        if (string.IsNullOrWhiteSpace(requesterAppUserId))
        {
            return Result.Failure(new Error("Comment.NotLoggedIn", "You must be logged in to delete a comment."));
        }

        await using var context = await factory.CreateDbContextAsync();
        var comment = await context.Comments.FindAsync(commentId);
        if (comment is null)
        {
            return Result.Failure(new Error("Comment.NotFound", "Comment not found."));
        }

        var isAdmin = await IsAdminAsync(context, requesterAppUserId);
        if (comment.AppUserId != requesterAppUserId && !isAdmin)
        {
            return Result.Failure(new Error("Comment.DeleteForbidden", "You cannot delete this comment."));
        }

        context.Comments.Remove(comment);
        await context.SaveChangesAsync();
        return Result.Success();
    }

    private static Task<bool> IsAdminAsync(ApplicationDbContext context, string appUserId)
    {
        return (from userRole in context.UserRoles
                join role in context.Roles on userRole.RoleId equals role.Id
                where userRole.UserId == appUserId && role.NormalizedName == "ADMIN"
                select userRole)
            .AnyAsync();
    }
}
