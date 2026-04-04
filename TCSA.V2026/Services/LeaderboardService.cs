using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using TCSA.V2026.Data;
using TCSA.V2026.Data.DTOs;
using TCSA.V2026.Data.Models;
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
        var users = new List<ApplicationUser>();
        var result = new List<UserReviewLeaderboardDisplay>();
        var index = 1;

        try
        {
            using (var context = _factory.CreateDbContext())
            {
                users = await context.Users
                .Include(x => x.CodeReviewProjects)
                .Where(x => x.ReviewExperiencePoints > 0)
                .ToListAsync();

                foreach (ApplicationUser user in users)
                {
                    var userForLeaderboard = new UserReviewLeaderboardDisplay
                    {
                        Id = user.Id,
                        Country = user.Country,
                        DisplayName = UserDisplayNameHelper.GetDisplayName(user.DisplayName, user.UserName),
                        TotalXp = user.ReviewExperiencePoints,
                        ReviewsNumber = user.CodeReviewProjects.Count()
                    };

                    result.Add(userForLeaderboard);
                }

                result = result
                    .OrderByDescending(x => x.TotalXp)
                    .Take(PagingConstants.LeaderboardPageSize)
                    .ToList();

                foreach (var user in result)
                {
                    user.Ranking = index;
                    index++;
                }
                return result;
            }
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public async Task<List<UserLeaderboardDisplay>> GetUsersForLeaderboard(int pageNumber)
    {
        var users = new List<ApplicationUser>();
        var result = new List<UserLeaderboardDisplay>();
        var index = (pageNumber - 1) * PagingConstants.LeaderboardPageSize;

        try
        {
            using (var context = _factory.CreateDbContext())
            {
                users = await context.Users
                .Where(x => x.ExperiencePoints > 0)
                .OrderByDescending(x => x.ExperiencePoints)
                .ThenBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .Skip((pageNumber - 1) * PagingConstants.LeaderboardPageSize)
                .Take(PagingConstants.LeaderboardPageSize)
                .ToListAsync();
            }
        }
        catch (Exception ex)
        {
            return null;
        }

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
