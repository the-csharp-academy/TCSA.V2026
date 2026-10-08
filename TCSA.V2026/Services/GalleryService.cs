using Microsoft.EntityFrameworkCore;
using TCSA.V2026.Data;
using TCSA.V2026.Data.DTOs;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Data.Models.Responses;
using TCSA.V2026.Helpers;
using TCSA.V2026.Helpers.Constants;

namespace TCSA.V2026.Services;

public interface IGalleryService
{
    Task<PaginatedList<ShowcaseItemDTO>?> GetItems(int pageNumber, List<int> projectIds);
    Task<Result> AddItem(ShowcaseItemDTO newItem);
    Task<Result> DeleteItem(ShowcaseItemDTO itemToDelete);
}

public class GalleryService(IDbContextFactory<ApplicationDbContext> _factory) : IGalleryService
{
    public async Task<Result> AddItem(ShowcaseItemDTO newItem)
    {
        var showcaseItem = new ShowcaseItem
        {
            DashboardProjectId = newItem.DashboardProjectId,
            AppUserId = newItem.ApplicationUserId,
            VideoUrl = newItem.VideoUrl,
            GithubUrl = newItem.GithubUrl,
        };

        try
        {
            using var context = _factory.CreateDbContext();
            await context.ShowcaseItems.AddAsync(showcaseItem);
            var result = await context.SaveChangesAsync();

            newItem.Id = showcaseItem.Id;

            if (result == 0)
            {
                return Result.Failure(new Error("Gallery.ItemNotAdded", "Item could not be added (no changes made)."));
            }

            return Result.Success(new Success("Gallery.ItemAdded", "Item added successfully"));
        }
        catch (Exception ex)
        {
            return Result.Failure(new Error("Gallery.Unexpected", $"An error occurred while adding the item: {ex.Message}"));
        }
    }

    public async Task<Result> DeleteItem(ShowcaseItemDTO itemToDelete)
    {
        try
        {
            using var context = _factory.CreateDbContext();
            var showcaseItem = await context.ShowcaseItems.FirstOrDefaultAsync(x => x.Id == itemToDelete.Id);
            context.ShowcaseItems.Remove(showcaseItem);

            var result = await context.SaveChangesAsync();
            if (result == 0)
            {
                return Result.Failure(new Error("Gallery.ItemNotDeleted", "Project could not be deleted (not found or no changes)."));
            }

            return Result.Success(new Success("Gallery.ItemDeleted", "Project deleted successfully"));
        }
        catch (Exception ex)
        {
            return Result.Failure(new Error("Gallery.Unexpected", $"An error occurred while deleting the project: {ex.Message}"));
        }
    }

    public async Task<PaginatedList<ShowcaseItemDTO>?> GetItems(int pageNumber, List<int> projectIds)
    {
        using var context = _factory.CreateDbContext();
        try
        {
            var query = context.ShowcaseItems
                .Include(x => x.ApplicationUser)
                .Include(x => x.DashboardProject)
                .AsNoTracking();

            if (projectIds.Any())
            {
                query = query.Where(i => projectIds.Contains(i.DashboardProject.ProjectId));
            }

            var orderedQuery = query.OrderByDescending(i => i.DateCreated).ThenBy(i => i.Id);

            var totalItems = await orderedQuery.CountAsync();

            var items = await orderedQuery
                .Skip((pageNumber - 1) * PagingConstants.GalleryPageSize)
                .Take(PagingConstants.GalleryPageSize)
            .ToListAsync();

            var itemDTOs = items.Select(x => GalleryHelper.ConvertToDTO(x)).ToList();

            return new PaginatedList<ShowcaseItemDTO>(itemDTOs, totalItems, pageNumber, PagingConstants.GalleryPageSize);
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}
