using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TCSA.V2026.Data;
using TCSA.V2026.Data.DTOs;
using TCSA.V2026.Data.Enums;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Data.Models.Responses;
using TCSA.V2026.Helpers;
using TCSA.V2026.Helpers.Constants;

namespace TCSA.V2026.Services;

public interface IFeedbackAdminService
{
    Task<PaginatedList<FeedbackAdminItemDto>> GetItems(FeedbackAdminFilter filter, int pageNumber, int pageSize = PagingConstants.AdminFeedbackPageSize);
    Task<Result<FeedbackAdminItemDto>> GetItem(int id);
    Task<Result> DeleteItem(int id);
    Task<int> GetNewCount();
    Task<List<FeedbackClusterDto>> GetQueue();
    Task<List<FeedbackClusterKey>> SearchClusterKeys(string? search, int take = 20);
    Task<List<FeedbackAdminItemDto>> GetClusterItems(FeedbackClusterKey cluster);
    Task<FeedbackClusterDto?> GetCluster(FeedbackClusterKey cluster);
    Task<Result> SetItemState(int id, FeedbackReviewState state);
    Task<Result<int>> SetClusterState(FeedbackClusterKey cluster, FeedbackReviewState state, int expectedNewCount);
    Task<Result<int>> DeleteCluster(FeedbackClusterKey cluster, int expectedCount);
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
        catch (DbUpdateConcurrencyException)
        {
            return Result.Failure(Conflict);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to delete feedback item {FeedbackId}", id);
            return Result.Failure(new Error(FeedbackErrorCodes.Unexpected, "Something went wrong while deleting the feedback."));
        }
    }

    public async Task<int> GetNewCount()
    {
        using var context = _factory.CreateDbContext();

        return await context.FeedbackItems.CountAsync(f => f.ReviewState == FeedbackReviewState.New);
    }

    public async Task<List<FeedbackClusterDto>> GetQueue()
    {
        using var context = _factory.CreateDbContext();

        var clusters = await Clusters(context.FeedbackItems.AsNoTracking())
            .Where(c => c.NewCount > 0)
            .OrderByDescending(c => c.NewCount)
            .ThenByDescending(c => c.LastSeen)
            .ThenBy(c => c.Page)
            .ToListAsync();

        await AttachSamples(context, clusters);
        return clusters;
    }

    public async Task<List<FeedbackClusterKey>> SearchClusterKeys(string? search, int take = 20)
    {
        take = Math.Max(take, 1);
        var term = search?.Trim() ?? string.Empty;

        using var context = _factory.CreateDbContext();

        var items = context.FeedbackItems.AsNoTracking();

        if (term.Length > 0)
        {
            var lowered = term.ToLower();
            var categories = Enum.GetValues<FeedbackCategory>()
                .Where(c => FeedbackLabelHelper.CategoryLabel(c).Contains(term, StringComparison.OrdinalIgnoreCase))
                .ToList();

            items = items.Where(f => categories.Contains(f.Category) || (f.ReportedPage ?? f.OriginUrl).ToLower().Contains(lowered));
        }

        var keys = await items
            .Select(f => new { f.Category, Page = f.ReportedPage ?? f.OriginUrl })
            .Distinct()
            .OrderBy(k => k.Category)
            .ThenBy(k => k.Page)
            .Take(take)
            .ToListAsync();

        return [.. keys.Select(k => new FeedbackClusterKey(k.Category, k.Page))];
    }

    public async Task<List<FeedbackAdminItemDto>> GetClusterItems(FeedbackClusterKey cluster)
    {
        using var context = _factory.CreateDbContext();

        return await InCluster(context.FeedbackItems.AsNoTracking(), cluster)
            .OrderByDescending(f => f.ReviewState == FeedbackReviewState.New)
            .ThenByDescending(f => f.CreatedAt)
            .ThenByDescending(f => f.Id)
            .Select(ToDto)
            .ToListAsync();
    }

    public async Task<FeedbackClusterDto?> GetCluster(FeedbackClusterKey cluster)
    {
        using var context = _factory.CreateDbContext();

        var found = await Clusters(InCluster(context.FeedbackItems.AsNoTracking(), cluster)).FirstOrDefaultAsync();

        if (found is not null)
        {
            await AttachSamples(context, [found]);
        }

        return found;
    }

    public async Task<Result> SetItemState(int id, FeedbackReviewState state)
    {
        if (!Enum.IsDefined(state))
        {
            return Result.Failure(InvalidState);
        }

        try
        {
            using var context = _factory.CreateDbContext();

            var item = await context.FeedbackItems.FirstOrDefaultAsync(f => f.Id == id);
            if (item is null)
            {
                return Result.Failure(NotFound);
            }

            item.ReviewState = state;
            await context.SaveChangesAsync();

            return Result.Success(new Success(FeedbackErrorCodes.Updated, $"Marked as {state}."));
        }
        catch (DbUpdateConcurrencyException)
        {
            return Result.Failure(Conflict);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to set state {State} on feedback item {FeedbackId}", state, id);
            return Result.Failure(new Error(FeedbackErrorCodes.Unexpected, "Something went wrong while updating the feedback."));
        }
    }

    public async Task<Result<int>> SetClusterState(FeedbackClusterKey cluster, FeedbackReviewState state, int expectedNewCount)
    {
        if (!Enum.IsDefined(state))
        {
            return Result.Failure<int>(InvalidState);
        }

        try
        {
            using var context = _factory.CreateDbContext();

            var items = await InCluster(context.FeedbackItems, cluster).ToListAsync();
            if (items.Count == 0)
            {
                return Result.Failure<int>(NotFound);
            }

            var toChange = items.Where(f => f.ReviewState == FeedbackReviewState.New).ToList();
            if (toChange.Count != expectedNewCount)
            {
                return Result.Failure<int>(Conflict);
            }

            foreach (var item in toChange)
            {
                item.ReviewState = state;
            }

            await context.SaveChangesAsync();

            return Result.Success(toChange.Count, new Success(FeedbackErrorCodes.Updated, $"Marked {toChange.Count} as {state}."));
        }
        catch (DbUpdateConcurrencyException)
        {
            return Result.Failure<int>(Conflict);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to set state {State} on feedback cluster {Category} {Page}", state, cluster.Category, cluster.Page);
            return Result.Failure<int>(new Error(FeedbackErrorCodes.Unexpected, "Something went wrong while updating the feedback."));
        }
    }

    public async Task<Result<int>> DeleteCluster(FeedbackClusterKey cluster, int expectedCount)
    {
        try
        {
            using var context = _factory.CreateDbContext();

            var items = await InCluster(context.FeedbackItems, cluster).ToListAsync();
            if (items.Count == 0)
            {
                return Result.Failure<int>(NotFound);
            }

            if (items.Count != expectedCount)
            {
                return Result.Failure<int>(Conflict);
            }

            context.FeedbackItems.RemoveRange(items);
            await context.SaveChangesAsync();

            return Result.Success(items.Count, new Success(FeedbackErrorCodes.Deleted, $"Deleted {items.Count} feedback items."));
        }
        catch (DbUpdateConcurrencyException)
        {
            return Result.Failure<int>(Conflict);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to delete feedback cluster {Category} {Page}", cluster.Category, cluster.Page);
            return Result.Failure<int>(new Error(FeedbackErrorCodes.Unexpected, "Something went wrong while deleting the feedback."));
        }
    }

    private static readonly Error InvalidState = new(FeedbackErrorCodes.StateInvalid, "That is not a valid review state.");

    private static readonly Error Conflict = new(FeedbackErrorCodes.Conflict, "This feedback changed while you were looking at it. The list has been refreshed, so please review it and try again.");

    private static IQueryable<FeedbackClusterDto> Clusters(IQueryable<FeedbackItem> items) =>
        items
            .GroupBy(f => new { f.Category, Page = f.ReportedPage ?? f.OriginUrl })
            .Select(g => new FeedbackClusterDto
            {
                Category = g.Key.Category,
                Page = g.Key.Page,
                Count = g.Count(),
                NewCount = g.Count(f => f.ReviewState == FeedbackReviewState.New),
                FirstSeen = g.Min(f => f.CreatedAt),
                LastSeen = g.Max(f => f.CreatedAt)
            });

    private static IQueryable<FeedbackItem> InCluster(IQueryable<FeedbackItem> query, FeedbackClusterKey cluster) =>
        query.Where(f => f.Category == cluster.Category &&
            ((f.ReportedPage != null && f.ReportedPage == cluster.Page) ||
             (f.ReportedPage == null && f.OriginUrl == cluster.Page)));

    private static async Task AttachSamples(ApplicationDbContext context, List<FeedbackClusterDto> clusters)
    {
        if (clusters.Count == 0)
        {
            return;
        }

        var categories = clusters.Select(c => c.Category).Distinct().ToList();
        var pages = clusters.Select(c => c.Page).Distinct().ToList();

        var candidates = await context.FeedbackItems.AsNoTracking()
            .Where(f => categories.Contains(f.Category) && pages.Contains(f.ReportedPage ?? f.OriginUrl))
            .Select(f => new
            {
                f.Id,
                f.Category,
                Page = f.ReportedPage ?? f.OriginUrl,
                IsNew = f.ReviewState == FeedbackReviewState.New,
                f.CreatedAt
            })
            .ToListAsync();

        var sampleIds = clusters.ToDictionary(
            c => c.Key,
            c => candidates
                .Where(f => f.Category == c.Category && f.Page == c.Page)
                .OrderByDescending(f => f.IsNew)
                .ThenByDescending(f => f.CreatedAt)
                .ThenByDescending(f => f.Id)
                .First().Id);

        var ids = sampleIds.Values.ToList();
        var bodies = await context.FeedbackItems.AsNoTracking()
            .Where(f => ids.Contains(f.Id))
            .ToDictionaryAsync(f => f.Id, f => f.Body);

        foreach (var cluster in clusters)
        {
            cluster.SampleBody = bodies[sampleIds[cluster.Key]];
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

        if (filter.Cluster is { } cluster)
        {
            query = InCluster(query, cluster);
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
