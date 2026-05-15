using TCSA.V2026.Data.Curriculum;
using TCSA.V2026.Data.DTOs;
using TCSA.V2026.Data.Enums;
using TCSA.V2026.Data.Models;

namespace TCSA.V2026.Helpers;

public static class PeerReviewHelpers
{
    public static List<int> DetermineReviewableProjectIds(Level level, IEnumerable<int> completedProjects)
    {
        var beginnerProjects = new List<int>
        {
            (int)ArticleName.Calculator,
            (int)ArticleName.HabitLogger,
            (int)ArticleName.CodingTracker
        };

        if (level > Level.Yellow)
        {
            beginnerProjects.AddRange(new List<int>
            {
                (int) ArticleName.Flashcards,
                (int) ArticleName.Drinks,
                (int) ArticleName.PhoneBook,
                (int) ArticleName.ShiftsLogger
            });
        }

        if (level > Level.Red)
        {
            beginnerProjects.AddRange(new List<int>
            {
                (int) ArticleName.Ecommerce,
                (int) ArticleName.ExcelReader,
                (int) ArticleName.SportsResults,
                (int) ArticleName.UnitTesting
            });

            List<int> advancedProjects = GetAvailableAdvancedProjects(completedProjects);
            beginnerProjects.AddRange(advancedProjects);
        }

        return beginnerProjects;
    }

    private static List<int> GetAvailableAdvancedProjects(IEnumerable<int> completedProjects)
    {
        var result = new List<int>();
        var completedAreas = RoadmapHelper.GetFullStackAreasCompleted(completedProjects.ToList());

        if (completedAreas == null) { return result; }

        if (completedAreas.Contains(Area.Angular))
        {
            result.AddRange(RoadmapHelper.angularProjects.Where(p => p != (int)ArticleName.Quizgame));
        }

        if (completedAreas.Contains(Area.React))
        {
            result.AddRange(RoadmapHelper.reactProjects.Where(p => p != (int)ArticleName.FriendsManager));
        }

        if (completedAreas.Contains(Area.MVC))
        {
            result.AddRange(RoadmapHelper.mvcProjects.Where(p => p != (int)ArticleName.Budget));
        }

        if (completedAreas.Contains(Area.Blazor))
        {
            result.AddRange(RoadmapHelper.blazorProjects.Where(p => p != (int)ArticleName.SportsStatistics));
        }

        return result;
    }

    public static List<PeerReviewDisplay> MapPeerReviewDisplays(List<DashboardProject> dashboardProjects, HashSet<int> reviewedDashboardProjectIds)
    {
        var result = new List<PeerReviewDisplay>();
        var projects = ProjectHelper.GetProjects();

        foreach (var dp in dashboardProjects)
        {
            var project = projects.FirstOrDefault(p => p.Id == dp.ProjectId);
            result.Add(new PeerReviewDisplay
            {
                DashboardProjectId = dp.Id,
                IsAssigned = reviewedDashboardProjectIds.Contains(dp.Id),
                Title = project.Title,
                IconUrl = project.IconUrl,
                ProjectId = dp.ProjectId,
                ProjectSlug = project.Slug,
                Name = GetRevieweeName(dp.AppUser),
                ExperiencePoints = project.ExperiencePoints,
                GithubUrl = dp.GithubUrl,
                DurationOpen = DateTime.UtcNow - dp.DateSubmitted
            });
        }

        return result;
    }

    public static string GetRevieweeName(ApplicationUser user)
    {
        var displayName =
            string.IsNullOrEmpty(user.DisplayName)
            ? user.FirstName + " " + user.LastName
            : user.DisplayName;

        var githubUsername = string.IsNullOrEmpty(user.GithubUsername) ? "" : user.GithubUsername;

        return displayName == " " ? githubUsername : displayName;
    }
}
