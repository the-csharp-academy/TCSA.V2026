using Microsoft.EntityFrameworkCore;
using TCSA.V2026.Data;
using TCSA.V2026.Data.DTOs;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Helpers;

namespace TCSA.V2026.Services;

public interface IStatisticsService
{
    Task<HomePageStatistics> GetHomePageStatisticsAsync();
}

public class StatisticsService : IStatisticsService
{
    private readonly IDbContextFactory<ApplicationDbContext> _factory;

    public StatisticsService(IDbContextFactory<ApplicationDbContext> factory)
    {
        _factory = factory;
    }

    public async Task<HomePageStatistics> GetHomePageStatisticsAsync()
    {
        var now = DateTimeOffset.UtcNow;
        var currentYear = now.Year;
        var thirtyDaysAgo = now.AddDays(-30);

        try
        {
            using var context = _factory.CreateDbContext();

            var userStats = await context.AspNetUsers
                .AsNoTracking()
                .GroupBy(u => 1)
                .Select(g => new
                {
                    AllUsers = g.Count(),
                    CurrentYearUsers = g.Count(u => u.CreatedDate.Year == currentYear)
                })
                .SingleOrDefaultAsync();

            var reviewStats = await context.DashboardProjects
                .AsNoTracking()
                .GroupBy(dp => 1)
                .Select(g => new
                {
                    AllReviewedProjects = g.Count(dp => dp.IsCompleted && dp.DateCompleted.HasValue),
                    CurrentYearReviewedProjects = g.Count(dp => dp.IsCompleted
                        && dp.DateCompleted.HasValue
                        && dp.DateCompleted.Value.Year == currentYear)
                })
                .SingleOrDefaultAsync();

            var reviewTimeProjects = await context.DashboardProjects
                .AsNoTracking()
                .Where(dp => dp.IsPendingReview)
                .Select(dp => new DashboardProject
                {
                    IsCompleted = dp.IsCompleted,
                    IsPendingReview = dp.IsPendingReview,
                    DateCompleted = dp.DateCompleted,
                    DateSubmitted = dp.DateSubmitted
                })
                .ToListAsync();

            var averageReviewTime = StatisticsHelper.CalculateAverageReviewTime(reviewTimeProjects, now);

            return new HomePageStatistics(
                userStats?.AllUsers ?? 0,
                userStats?.CurrentYearUsers ?? 0,
                reviewStats?.AllReviewedProjects ?? 0,
                reviewStats?.CurrentYearReviewedProjects ?? 0,
                currentYear,
                averageReviewTime
            );
        }
        catch (Exception)
        {
            return new HomePageStatistics(0, 0, 0, 0, currentYear, TimeSpan.Zero);
        }
    }
}
