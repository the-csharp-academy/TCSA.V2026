using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using TCSA.V2026.Data;
using TCSA.V2026.Data.DTOs;
using TCSA.V2026.Helpers;
using TCSA.V2026.Helpers.Constants;

namespace TCSA.V2026.Services;

public interface ILeaderboardService
{
    Task<int> GetUserRanking(string userId);
    Task<int> GetTotalPages();
    Task<List<UserLeaderboardDisplay>> GetUsersForLeaderboard(int pageNumber);
    Task<List<UserReviewLeaderboardDisplay>> GetUserForReviewLeaderboard();
    Task<List<AppStatisticsCountries>> GetCountriesForAppStatistics();
    Task<int> GetNumberCountries();
}
public class LeaderboardService(IDbContextFactory<ApplicationDbContext> _factory) : ILeaderboardService
{
    public async Task<List<AppStatisticsCountries>> GetCountriesForAppStatistics()
    {
        var result = new List<AppStatisticsCountries>();
        try
        {
            using (var context = _factory.CreateDbContext())
            {
                result = await context.Users
                    .GroupBy(u => u.Country)
                    .Select(g => new AppStatisticsCountries
                    {
                        CountryName = g.Key,
                        UsersCount = g.Count()
                    })
                    .OrderByDescending(x => x.UsersCount)
                    .ToListAsync();

                var index = 1;
                foreach (var country in result)
                {
                    country.Ranking = index;
                    index++;
                }
            }
        }
        catch (Exception ex)
        {
            return null;
        }
        return result;
    }

    public async Task<List<UserReviewLeaderboardDisplay>> GetUserForReviewLeaderboard()
    {
        var result = new List<UserReviewLeaderboardDisplay>();

        try
        {
            using var context = _factory.CreateDbContext();
            var users = await context.Users
                .Where(u => u.ReviewExperiencePoints > 0)
                .OrderByDescending(u => u.ReviewExperiencePoints)
                .Take(PagingConstants.LeaderboardPageSize)
                .Select(u => new
                {
                    u.Id,
                    u.Country,
                    u.DisplayName,
                    u.UserName,
                    TotalXp = u.ReviewExperiencePoints,
                    ReviewsNumber = u.CodeReviewProjects.Count(),
                }).ToListAsync();

            int position = 1;
            foreach (var user in users)
            {
                var userForLeaderboard = new UserReviewLeaderboardDisplay
                {
                    Id = user.Id,
                    Country = user.Country,
                    DisplayName = UserDisplayNameHelper.GetDisplayName(user.DisplayName, user.UserName),
                    TotalXp = user.TotalXp,
                    ReviewsNumber = user.ReviewsNumber,
                    Ranking = position
                };

                result.Add(userForLeaderboard);
                position++;
            }

            return result;
        }
        catch (Exception)
        {
            return [];
        }
    }

    public async Task<List<UserLeaderboardDisplay>> GetUsersForLeaderboard(int pageNumber)
    {
        var result = new List<UserLeaderboardDisplay>();
        var index = (pageNumber - 1) * PagingConstants.LeaderboardPageSize;

        try
        {
            using var context = _factory.CreateDbContext();
            var users = await context.Users
            .Where(x => x.ExperiencePoints > 0)
            .OrderByDescending(x => x.ExperiencePoints)
            .ThenBy(x => x.FirstName)
            .ThenBy(x => x.LastName)
            .Skip((pageNumber - 1) * PagingConstants.LeaderboardPageSize)
            .Take(PagingConstants.LeaderboardPageSize)
            .Select(u => new
            {
                u.Id,
                u.Country,
                u.Level,
                u.DisplayName,
                u.UserName,
                u.ExperiencePoints,
                u.GithubUsername,
                u.LinkedInUrl
            })
            .ToListAsync();

            foreach (var user in users)
            {
                index++;
                var userForLeaderboard = new UserLeaderboardDisplay
                {
                    Id = user.Id,
                    Country = user.Country,
                    Level = user.Level,
                    DisplayName = UserDisplayNameHelper.GetDisplayName(user.DisplayName, user.UserName),
                    ExperiencePoints = user.ExperiencePoints,
                    Ranking = index
                };

                userForLeaderboard.GithubUsername = user.GithubUsername ?? string.Empty;
                userForLeaderboard.LinkedInUrl = user.LinkedInUrl ?? string.Empty;

                result.Add(userForLeaderboard);
            }

            return result;
        }
        catch (Exception)
        {
            return [];
        }
    }

    public async Task<int> GetNumberCountries()
    {
        try
        {
            using (var context = _factory.CreateDbContext())
            {
                var count = await context.Users
                    .Where(x => x.Country != null)
                    .Select(x => x.Country)
                    .Distinct()
                    .CountAsync();
                return count;
            }
        }
        catch (Exception ex)
        {
            return 0;
        }
    }

    public async Task<int> GetUserRanking(string userId)
    {
        try
        {
            using (var context = _factory.CreateDbContext())
            {
                var rankingParameter = new SqlParameter("ranking", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };

                var parameters = new[]
                {
                    new SqlParameter("userId", userId),
                    rankingParameter
                };

                context.Database.ExecuteSqlRaw("EXEC GetRanking @userId, @ranking OUT", parameters);

                if (rankingParameter.Value != DBNull.Value)
                {
                    return (int)rankingParameter.Value;
                }

                return -1;
            }
        }
        catch (Exception ex)
        {
            return 0;
        }
    }

    public async Task<int> GetTotalPages()
    {
        try
        {
            using (var context = _factory.CreateDbContext())
            {
                var count = await context.Users
                    .CountAsync(x => x.ExperiencePoints > 0);

                return (int)Math.Ceiling((double)count / PagingConstants.LeaderboardPageSize);
            }
        }
        catch (Exception ex)
        {
            return 0;
        }
    }
}
