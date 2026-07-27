using Microsoft.CodeAnalysis;
using TCSA.V2026.Data.Curriculum;
using TCSA.V2026.Data.DTOs;
using TCSA.V2026.Data.Models;
using Project = TCSA.V2026.Data.Models.Project;
using TaskStatus = TCSA.V2026.Data.DTOs.TaskStatus;

namespace TCSA.V2026.Helpers;

public static class DashboardProjectsHelpers
{
    public static IEnumerable<Article> Articles = ArticleHelper.GetArticles();
    public static IEnumerable<Project> Projects = ProjectHelper.GetProjects().Where(x => x.IsClosed == false);

    private static string GetNotCompletedMessage(Area? area, Difficulty? difficulty, List<int> completedProjects)
    {
        var count = 0;
        var completedProjectsCount = 0;
        List<int> ids = new();

        if (area == Area.StartHere)
        {
            count = Articles.Where(x => x.Area == area).Count() + 1; // adding fcc 
            ids = Articles.Where(x => x.Area == area).Select(x => x.Id).ToList();

            foreach (int id in ids)
            {
                if (completedProjects != null && completedProjects.Contains(id))
                {
                    completedProjectsCount += 1;
                }
            }

            if (completedProjects.Contains(75))
            {
                completedProjectsCount += 1;
            }
        }

        else if (area == Area.SQL)
        {
            count = Projects.Where(x => x.Area == Area.SQL && !x.IsClosed).Count();
            ids = Projects.Where(x => x.Area == Area.SQL).Select(x => x.Id).ToList();

            foreach (int id in ids)
            {
                if (completedProjects != null && completedProjects.Contains(id))
                {
                    completedProjectsCount += 1;
                }
            }
        }
        else if (area == Area.GraduationProject)
        {
            count = 1;
            ids = Projects.Where(x => x.Area == Area.GraduationProject).Select(x => x.Id).ToList();

            foreach (int id in ids)
            {
                if (completedProjects != null && completedProjects.Contains(id))
                {
                    completedProjectsCount += 1;
                }
            }
        }
        else
        {
            if (difficulty != null)
            {
                count = Projects.Where(x => x.Area == area && x.Difficulty == difficulty).Count();
                ids = Projects.Where(x => x.Area == area && x.Difficulty == difficulty).Select(x => x.Id).ToList();
            }
            else
            {
                count = Projects.Where(x => x.Area == area).Count();
                ids = Projects.Where(x => x.Area == area).Select(x => x.Id).ToList();
            }

            foreach (int id in ids)
            {
                if (completedProjects != null && completedProjects.Contains(id))
                {
                    completedProjectsCount += 1;
                }
            }
        }

        return $"{completedProjectsCount} out of {count} tasks completed";
    }

    public static Article GetProject(int projectId)
    {
        return ArticleHelper.GetArticles().FirstOrDefault(a => a.Id == projectId)
            ?? ProjectHelper.GetProjects().FirstOrDefault(p => p.Id == projectId)
            ?? CourseHelper.GetCourses().SelectMany(x => x.Articles).FirstOrDefault(a => a.Id == projectId);
    }

    public static TaskStatus GetTaskStatus(int projectId, List<int> completedProjects, List<int> pendingProjects)
    {
        if (pendingProjects.Contains(projectId))
        {
            return TaskStatus.PendingReview;
        }
        if (completedProjects.Contains(projectId))
        {
            return TaskStatus.Completed;
        }
        return TaskStatus.NotCompleted;
    }

    public static List<DashboardAreaInfo> GetAreas(List<int> completedProjects, List<int> pendingProjects)
    {
        return new List<DashboardAreaInfo>
        {
            new DashboardAreaInfo
            {
                Area = Area.StartHere,
                CardName = "Start Here",
                ImgUrl = "icons8-baby-app-96.png",
                Tasks = Articles.Where(x => x.Area == Area.StartHere).Select(a => new DashboardTaskDisplay
                {
                    Id = a.Id,
                    IconUrl = a.IconUrl,
                    Title = a.Title,
                    Status = GetTaskStatus(a.Id, completedProjects, pendingProjects),
                    Slug = a.Slug,
                    Area = a.Area,
                    IsReadOnly = a.Id != 75
                }).ToList(),
                Description = GetNotCompletedMessage(Area.StartHere, null, completedProjects),
                IsCompleted = CheckIfAreaIsCompleted(Projects, Articles, completedProjects, Area.StartHere, null),
            },
            new DashboardAreaInfo
            {
                CardName = "Beginner Console",
                ImgUrl = "icons8-mommy-and-me-classes-96.png",
                Tasks = Projects
                .Where(x => x.Area == Area.Console && x.Difficulty == Difficulty.Beginner)
                .Select(a => new DashboardTaskDisplay
                {
                    Id = a.Id,
                    IconUrl = a.IconUrl,
                    Title = a.Title,
                    Status = GetTaskStatus(a.Id, completedProjects, pendingProjects),
                    Slug = a.Slug,
                    Area = a.Area
                }).ToList(),
                Description = GetNotCompletedMessage(Area.Console, Difficulty.Beginner, completedProjects),
                IsCompleted = CheckIfAreaIsCompleted(Projects, Articles, completedProjects, Area.Console, Difficulty.Beginner),
            },
            new DashboardAreaInfo
            {
                CardName = "Intermediate Console",
                ImgUrl = "icons8-teenager-64.png",
                Tasks = Projects
                .Where(x => x.Area == Area.Console && x.Difficulty == Difficulty.Intermediate)
                .Select(a => new DashboardTaskDisplay
                {
                    Id = a.Id,
                    IconUrl = a.IconUrl,
                    Title = a.Title,
                    Status = GetTaskStatus(a.Id, completedProjects, pendingProjects),
                    Slug = a.Slug,
                    Area = a.Area
                }).ToList(),
                Description = GetNotCompletedMessage(Area.Console, Difficulty.Intermediate, completedProjects),
                IsCompleted = CheckIfAreaIsCompleted(Projects, Articles,
                        completedProjects, Area.Console, Difficulty.Intermediate)
            },
            new DashboardAreaInfo
            {
                CardName = "Advanced Console",
                ImgUrl = "icons8-executive-64.png",
                Tasks = Projects
                .Where(x => x.Area == Area.Console && x.Difficulty == Difficulty.Advanced)
                .Select(a => new DashboardTaskDisplay
                {
                    Id = a.Id,
                    IconUrl = a.IconUrl,
                    Title = a.Title,
                    Status = GetTaskStatus(a.Id, completedProjects, pendingProjects),
                    Slug = a.Slug,
                    Area = a.Area
                }).ToList(),
                Description = GetNotCompletedMessage(Area.Console, Difficulty.Advanced, completedProjects),
                IsCompleted = CheckIfAreaIsCompleted(Projects, Articles, completedProjects, Area.Console, Difficulty.Advanced)
            },
            new DashboardAreaInfo
            {
                CardName = "Start Applying",
                ImgUrl = "icons8-permanent-job-96.png",
                Tasks = Projects
                .Where(x => x.Area == Area.StartApplying)
                .Select(a => new DashboardTaskDisplay
                {
                    Id = a.Id,
                    IconUrl = a.IconUrl,
                    Title = a.Title,
                    Status = GetTaskStatus(a.Id, completedProjects, pendingProjects),
                    Slug = a.Slug,
                    Area = a.Area
                }).ToList(),
                Description = GetNotCompletedMessage(Area.StartApplying, null, completedProjects),
                IsCompleted = CheckIfAreaIsCompleted(Projects, Articles, completedProjects, Area.StartApplying, null)
            },
            new DashboardAreaInfo
            {
                CardName = "SQL",
                ImgUrl = "icons8-sql-server-64.png",
                Tasks = Projects
                .Where(x => x.Area == Area.SQL)
                .Select(a => new DashboardTaskDisplay
                {
                    Id = a.Id,
                    IconUrl = a.IconUrl,
                    Title = a.Title,
                    Status = GetTaskStatus(a.Id, completedProjects, pendingProjects),
                    Slug = a.Slug,
                    Area = a.Area
                }).ToList(),
                Description = GetNotCompletedMessage(Area.SQL, null, completedProjects),
                IsCompleted = CheckIfAreaIsCompleted(Projects, Articles, completedProjects, Area.SQL, null)
            },
            new DashboardAreaInfo
            {
                CardName = "ASP.NET Core MVC",
                ImgUrl = "mvc.png",
                Tasks = Projects
                .Where(x => x.Area == Area.MVC)
                .Select(a => new DashboardTaskDisplay
                {
                    Id = a.Id,
                    IconUrl = a.IconUrl,
                    Title = a.Title,
                    Status = GetTaskStatus(a.Id, completedProjects, pendingProjects),
                    Slug = a.Slug,
                    Area = a.Area
                }).ToList(),
                Description = GetNotCompletedMessage(Area.MVC, null, completedProjects),
                IsCompleted = CheckIfAreaIsCompleted(Projects, Articles,completedProjects, Area.MVC, null)
            },
            new DashboardAreaInfo
            {
                CardName = "Auth Area",
                ImgUrl = "icons8-authentication-100.png",
                Tasks = Projects
                .Where(x => x.Area == Area.Auth)
                .Select(a => new DashboardTaskDisplay
                {
                    Id = a.Id,
                    IconUrl = a.IconUrl,
                    Title = a.Title,
                    Status = GetTaskStatus(a.Id, completedProjects, pendingProjects),
                    Slug = a.Slug,
                    Area = a.Area
                }).ToList(),
                Description = GetNotCompletedMessage(Area.Auth, null, completedProjects),
                IsCompleted = CheckIfAreaIsCompleted(Projects, Articles,
                          completedProjects, Area.Auth, null)
            },
            new DashboardAreaInfo
            {
                CardName = "React",
                ImgUrl = "icons8-react-80.png",
                Tasks = Projects
                .Where(x => x.Area == Area.React)
                .Select(a => new DashboardTaskDisplay
                {
                    Id = a.Id,
                    IconUrl = a.IconUrl,
                    Title = a.Title,
                    Status = GetTaskStatus(a.Id, completedProjects, pendingProjects),
                    Slug = a.Slug,
                    Area = a.Area
                }).ToList(),
                Description = GetNotCompletedMessage(Area.React, null, completedProjects),
                IsCompleted = CheckIfAreaIsCompleted(Projects, Articles,
                        completedProjects, Area.React, null)
            },
            new DashboardAreaInfo
            {
                CardName = "Angular",
                ImgUrl = "icons8-angularjs-96.png",
                Tasks = Projects
                .Where(x => x.Area == Area.Angular)
                .Select(a => new DashboardTaskDisplay
                {
                    Id = a.Id,
                    IconUrl = a.IconUrl,
                    Title = a.Title,
                    Status = GetTaskStatus(a.Id, completedProjects, pendingProjects),
                    Slug = a.Slug,
                    Area = a.Area
                }).ToList(),
                Description = GetNotCompletedMessage(Area.Angular, null, completedProjects),
                IsCompleted = CheckIfAreaIsCompleted(Projects, Articles,
                        completedProjects, Area.Angular, null)
            },
            new DashboardAreaInfo
            {
                CardName = "Blazor",
                ImgUrl = "blazor.png",
                Tasks = Projects.Where(x => x.Area == Area.Blazor)
                .Select(a => new DashboardTaskDisplay
                {
                    Id = a.Id,
                    IconUrl = a.IconUrl,
                    Title = a.Title,
                    Status = GetTaskStatus(a.Id, completedProjects, pendingProjects),
                    Slug = a.Slug,
                    Area = a.Area
                }).ToList(),
                Description = GetNotCompletedMessage(Area.Blazor, null, completedProjects),
                IsCompleted = CheckIfAreaIsCompleted(Projects, Articles,
                        completedProjects, Area.Blazor, null)
            },
            new DashboardAreaInfo
            {
                CardName = "MAUI",
                ImgUrl = "maui.png",
                Tasks = Projects
                .Where(x => x.Area == Area.MAUI)
                .Select(a => new DashboardTaskDisplay
                {
                    Id = a.Id,
                    IconUrl = a.IconUrl,
                    Title = a.Title,
                    Status = GetTaskStatus(a.Id, completedProjects, pendingProjects),
                    Slug = a.Slug,
                    Area = a.Area
                }).ToList(),
                Description = GetNotCompletedMessage(Area.MAUI, null, completedProjects),
                IsCompleted = CheckIfAreaIsCompleted(Projects, Articles,
                        completedProjects, Area.MAUI, null)
            },
            new DashboardAreaInfo
            {
                CardName = "Cloud Development",
                ImgUrl = "icons8-cloud-connection-480.png",
                Tasks = Projects
                .Where(x => x.Area == Area.Azure)
                .Select(a => new DashboardTaskDisplay
                {
                    Id = a.Id,
                    IconUrl = a.IconUrl,
                    Title = a.Title,
                    Status = GetTaskStatus(a.Id, completedProjects, pendingProjects),
                    Slug = a.Slug,
                    Area = a.Area
                }).ToList(),
                Description = GetNotCompletedMessage(Area.Azure, null, completedProjects),
                IsCompleted = CheckIfAreaIsCompleted(Projects, Articles,
                        completedProjects, Area.Azure, null)
            },
            new DashboardAreaInfo
            {
                CardName = "Flagship Project",
                ImgUrl = "flagship.png",
                Tasks = Projects
                .Where(x => x.Area == Area.GraduationProject).Take(1)
                .Select(a => new DashboardTaskDisplay
                {
                    Id = a.Id,
                    IconUrl = a.IconUrl,
                    Title = a.Title,
                    Status = GetTaskStatus(a.Id, completedProjects, pendingProjects),
                    Slug = a.Slug,
                    Area = a.Area
                }).ToList(),
                Description = GetNotCompletedMessage(Area.GraduationProject, null, completedProjects),
                IsCompleted = CheckIfAreaIsCompleted(Projects, Articles, completedProjects, Area.GraduationProject, null)
            },
            new DashboardAreaInfo
            {
                CardName = "Docker",
                ImgUrl = "icons8-docker-logo-96.png",
                Tasks = Projects
                .Where(x => x.Area == Area.Docker)
                .Select(a => new DashboardTaskDisplay
                {
                    Id = a.Id,
                    IconUrl = a.IconUrl,
                    Title = a.Title,
                    Status = GetTaskStatus(a.Id, completedProjects, pendingProjects),
                    Slug = a.Slug,
                    Area = a.Area
                }).ToList(),
                Description = GetNotCompletedMessage(Area.Docker, null, completedProjects),
                IsCompleted = CheckIfAreaIsCompleted(Projects, Articles,
                        completedProjects, Area.Docker, null)
            },
            new DashboardAreaInfo
            {
                CardName = "Systems Design",
                ImgUrl = "icons8-archit-64.png",
                Tasks = Projects
                .Where(x => x.Area == Area.SystemDesign)
                .Select(a => new DashboardTaskDisplay
                {
                    Id = a.Id,
                    IconUrl = a.IconUrl,
                    Title = a.Title,
                    Status = GetTaskStatus(a.Id, completedProjects, pendingProjects),
                    Slug = a.Slug,
                    Area = a.Area
                }).ToList(),
                Description = GetNotCompletedMessage(Area.SystemDesign, null, completedProjects),
                IsCompleted = CheckIfAreaIsCompleted(Projects, Articles, completedProjects, Area.SystemDesign, null)
            },
            new DashboardAreaInfo
            {
                CardName = "Challenge Projects",
                ImgUrl = "icons8-challenge-64.png",
                Tasks = Projects
                .Where(x => x.Area == Area.MonthlyChallenge)
                .Select(a => new DashboardTaskDisplay
                {
                    Id = a.Id,
                    IconUrl = a.IconUrl,
                    Title = a.Title,
                    Status = GetTaskStatus(a.Id, completedProjects, pendingProjects),
                    Slug = a.Slug,
                    Area = a.Area
                }).ToList(),
                Description = GetNotCompletedMessage(Area.MonthlyChallenge, null, completedProjects),
                IsCompleted = CheckIfAreaIsCompleted(Projects, Articles,
                    completedProjects, Area.MonthlyChallenge, null)
            },
            new DashboardAreaInfo
            {
                CardName = "FreeStyle Project",
                ImgUrl = "icons8-creativity-512.png",
                Tasks = Projects
                .Where(x => x.Area == Area.FreestyleProject)
                .Select(a => new DashboardTaskDisplay
                {
                    Id = a.Id,
                    IconUrl = a.IconUrl,
                    Title = a.Title,
                    Status = GetTaskStatus(a.Id, completedProjects, pendingProjects),
                    Slug = a.Slug,
                    Area = a.Area
                }).ToList(),
                Description = "You can submit as many freestyle projects as you want.",
                IsCompleted = false
            },
        };
    }

    public static string GetUrl(Area area, int taskId, string taskSlug)
    {
        var firstPart = area == Area.StartHere && taskId != 75 ? "article" : "project";
        return $"{firstPart}/{taskId}/{taskSlug}";
    }

    public static bool CheckIfAreaIsCompleted(
       IEnumerable<Project> projects,
       IEnumerable<Article> articles,
       List<int> completedProjects,
       Area area,
       Difficulty? difficulty)
    {
        if (difficulty != null)
        {
            var ids = projects
                .Where(x => x.Area == area && x.Difficulty == difficulty)
                .Select(x => x.Id)
                .ToList();

            foreach (int id in ids)
            {
                if (completedProjects != null && !completedProjects.Contains(id))
                {
                    return false;
                }
            }

            return true;
        }

        if (area != Area.StartHere)
        {
            var projectIds = projects
                .Where(x => x.Area == area)
                .Select(x => x.Id);

            foreach (int id in projectIds)
            {
                if (completedProjects != null && !completedProjects.Contains(id))
                {
                    return false;
                }
            }
        }
        else
        {
            if (!completedProjects.Contains(75) || !completedProjects.Contains(9))
            {
                return false;
            }

            var articleIds = articles
                .Where(x => x.Area == Area.StartHere)
                .Select(x => x.Id);

            foreach (int id in articleIds)
            {
                if (completedProjects != null && !completedProjects.Contains(id))
                {
                    return false;
                }
            }
        }

        return true;
    }
}
