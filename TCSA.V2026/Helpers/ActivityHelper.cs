using TCSA.V2026.Data.Curriculum;
using TCSA.V2026.Data.DTOs;
using TCSA.V2026.Data.Models;

namespace TCSA.V2026.Helpers;

public static class ActivityHelper
{
    public static List<ActivityDisplay> GetActivityDisplay(ApplicationUser user)
    {
        var activityDisplay = new List<ActivityDisplay>();
        var currentXP = user.ExperiencePoints;

        List<Article> articles = ArticleHelper.GetArticles();
        List<Project> projects = ProjectHelper.GetProjects();
        List<Course> courses = CourseHelper.GetCourses();
        int currentPoints = user.ExperiencePoints;
        var currentBelt = user.Level;

        var activity = user.UserActivity.OrderByDescending(x => x.DateSubmitted).ToList();
        for (int i = 0; i < activity.Count(); i++)
        {
            AppUserActivity item = activity[i];

            var activityToAdd = new ActivityDisplay();
            activityToAdd.ActivityType = item.ActivityType;
            activityToAdd.Date = item.DateSubmitted;

            if (item.ActivityType == ActivityType.ArticleRead)
            {
                var article = articles.FirstOrDefault(a => a.Id == item.ProjectId);

                if (article != null)
                {
                    activityToAdd.Description = $"You read the article <b>{article.Title}</b>";
                    activityToAdd.ExperiencePoints = article.ExperiencePoints;
                }

                var course = courses.FirstOrDefault(c => c.Articles.Any(a => a.Id == item.ProjectId));

                if (course != null)
                {
                    article = course.Articles.FirstOrDefault(a => a.Id == item.ProjectId);
                    activityToAdd.Description = $"You read the article <b>{article.Title}</b>";
                    activityToAdd.ExperiencePoints = article.ExperiencePoints;
                }

                if (article == null && course == null)
                {
                    throw new InvalidDataException("Article can't be found");
                }
            }

            if (item.ActivityType == ActivityType.ProjectSubmitted)
            {
                activityToAdd.Description = $"You submitted the project <b>{projects.FirstOrDefault(x => x.Id == item.ProjectId)?.Title}</b> for review.";
            }

            if (item.ActivityType == ActivityType.ProjectCompleted)
            {
                var project = projects.FirstOrDefault(x => x.Id == item.ProjectId);
                activityToAdd.Description = project == null
                    ? $"You completed the issue <b>{user.Issues.FirstOrDefault(x => x.ProjectId == item.ProjectId)?.Title}</b>."
                    : $"You completed the project <b>{projects.FirstOrDefault(x => x.Id == item.ProjectId)?.Title}</b>.";

                activityToAdd.ExperiencePoints = project == null
                    ? user.Issues.FirstOrDefault(x => x.ProjectId == item.ProjectId).ExperiencePoints
                    : project.ExperiencePoints;
            }

            if (item.ActivityType == ActivityType.IssueSubmitted)
            {
                activityToAdd.Description = $"You submitted the issue <b>{user.Issues.FirstOrDefault(x => x.ProjectId == item.ProjectId)?.Title}</b>.";
            }

            if (item.ActivityType == ActivityType.ChallengeCompleted)
            {
                var challenge = user.UserChallenges.FirstOrDefault(x => x.ChallengeId == item.ChallengeId).Challenge;
                activityToAdd.Description = $"You completed the challenge <b>{challenge.Name}</b>.";
                activityToAdd.ExperiencePoints = challenge.ExperiencePoints;

            }

            if (item.ActivityType == ActivityType.CodeReviewCompleted)
            {
                var project = projects.FirstOrDefault(x => x.Id == item.ProjectId);
                activityToAdd.Description = $"You completed a <b>{project.Title} review.</b>";
                activityToAdd.ExperiencePoints = project.ExperiencePoints;
            }

            if (item.ActivityType == ActivityType.NewBelt)
            {
                activityToAdd.Description = $"You achieved {currentBelt} belt!";
                currentBelt = currentBelt - 1;
            }

            currentPoints = i == 0 ? currentPoints : currentPoints - activityDisplay[i - 1].ExperiencePoints;
            activityToAdd.CurrentExperiencePoints = currentPoints;
            activityToAdd.ActivityId = item.Id;
            activityDisplay.Add(activityToAdd);
        }

        activityDisplay = CheckForDupes(activityDisplay);

        return activityDisplay;
    }
    public static List<ActivityDisplay> CheckForDupes(List<ActivityDisplay> activities)
    {
        var activitySet = new HashSet<string>();
        foreach (var activity in activities)
        {
            string activityKey = $"{activity.Description}";
            if (activitySet.Contains(activityKey))
            {
                activity.IsDuplicate = true;
            }
            else
            {
                activitySet.Add(activityKey);
            }
        }
        return activities;
    }
}
