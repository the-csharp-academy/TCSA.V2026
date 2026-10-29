using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TCSA.V2026.Data;
using TCSA.V2026.Data.DTOs;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Data.Models.Responses;
using TCSA.V2026.Helpers.Constants;

namespace TCSA.V2026.Services;

public interface IFeedbackAdminService
{
    Task<PaginatedList<FeedbackAdminItemDto>> GetItems(FeedbackAdminFilter filter, int pageNumber, int pageSize = PagingConstants.AdminFeedbackPageSize);
    Task<Result<FeedbackAdminItemDto>> GetItem(int id);
    Task<Result> DeleteItem(int id);
}

public class FeedbackAdminService(IDbContextFactory<ApplicationDbContext> _factory, ILogger<FeedbackAdminService> _logger) : IFeedbackAdminService
{
    public async Task<PaginatedList<FeedbackAdminItemDto>> GetItems(FeedbackAdminFilter filter, int pageNumber, int pageSize = PagingConstants.AdminFeedbackPageSize)
    {
        pageNumber = Math.Max(pageNumber, 1);
        pageSize = Math.Max(pageSize, 1);

        using var context = _factory.CreateDbContext();

        var query = ApplyFilter(context.FeedbackItems.AsNoTracking(), filter);
        var totalItems = await query.CountAsync();

        var items = await query
            .OrderByDescending(f => f.CreatedAt)
            .ThenByDescending(f => f.Id)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .Select(ToDto)
            .ToListAsync();

        return new PaginatedList<FeedbackAdminItemDto>(items, totalItems, pageNumber, pageSize);
    }

    public async Task<Result<FeedbackAdminItemDto>> GetItem(int id)
    {
        using var context = _factory.CreateDbContext();

        var item = await context.FeedbackItems
            .AsNoTracking()
            .Where(f => f.Id == id)
            .Select(ToDto)
            .FirstOrDefaultAsync();

        return item is null ? Result.Failure<FeedbackAdminItemDto>(NotFound) : Result.Success(item);
    }

    public async Task<Result> DeleteItem(int id)
    {
        try
        {
            using var context = _factory.CreateDbContext();

            var item = await context.FeedbackItems.FirstOrDefaultAsync(f => f.Id == id);
            if (item is null)
            {
                return Result.Failure(NotFound);
            }

            context.FeedbackItems.Remove(item);
            await context.SaveChangesAsync();

            return Result.Success(new Success(FeedbackErrorCodes.Deleted, "Feedback deleted."));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to delete feedback item {FeedbackId}", id);
            return Result.Failure(new Error(FeedbackErrorCodes.Unexpected, "Something went wrong while deleting the feedback."));
        }
    }

    private static readonly Error NotFound = new(FeedbackErrorCodes.NotFound, "That feedback item no longer exists.");

    private static IQueryable<FeedbackItem> ApplyFilter(IQueryable<FeedbackItem> query, FeedbackAdminFilter filter)
    {
        if (filter.Category is { } category)
        {
            query = query.Where(f => f.Category == category);
        }

        if (filter.ReviewState is { } reviewState)
        {
            query = query.Where(f => f.ReviewState == reviewState);
        }

        if (filter.Area is { } area)
        {
            query = query.Where(f => f.Area == area);
        }

        if (filter.From is { } from)
        {
            query = query.Where(f => f.CreatedAt >= from);
        }

        if (filter.To is { } to)
        {
            query = query.Where(f => f.CreatedAt < to);
        }

        if (!string.IsNullOrWhiteSpace(filter.Search))
        {
            var term = filter.Search.Trim().ToLower();
            query = query.Where(f =>
                f.Body.ToLower().Contains(term) ||
                f.OriginUrl.ToLower().Contains(term) ||
                (f.ReportedPage != null && f.ReportedPage.ToLower().Contains(term)));
        }

        return query;
    }

    private static readonly Expression<Func<FeedbackItem, FeedbackAdminItemDto>> ToDto = f => new FeedbackAdminItemDto
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
    };
}
