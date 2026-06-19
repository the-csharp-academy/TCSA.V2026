using TCSA.V2026.Data.Curriculum;
using TCSA.V2026.Data.DTOs;
using TCSA.V2026.Data.Enums;
using TCSA.V2026.Data.Models;

namespace TCSA.V2026.Helpers;

public static class RoadmapHelper
{
    private static List<Article>? Articles = ArticleHelper.GetArticles();
    private static List<Project>? Projects = ProjectHelper.GetProjects();
    private static Project FlagshipProject = Projects.Single(x => x.Id == 139);

    #region projectRequirements
    public static readonly int[] GreenRequirements = {
        (int) ArticleName.StartHere,
        (int) ArticleName.GettingHelp,
        (int) ArticleName.SettingUp,
        (int) ArticleName.Foundations,
        (int) ArticleName.FreecodeCamp,
        (int) ArticleName.MathGame
    };

    public static readonly int[] OliveGreenRequirements = {
        (int) ArticleName.Calculator,
        (int) ArticleName.HabitLogger,
        (int) ArticleName.CodingTracker
    };

    public static readonly int[] YellowRequirements = {
        (int) ArticleName.Flashcards,
        (int) ArticleName.Drinks,
        (int) ArticleName.PhoneBook,
        (int) ArticleName.ShiftsLogger
    };

    public static readonly int[] OrangeRequirements = {
       (int) ArticleName.Ecommerce,
       (int) ArticleName.SportsResults,
       (int) ArticleName.ExcelReader,
       (int) ArticleName.UnitTesting
    };

    public static readonly int[] RedRequirements = {
        (int) ArticleName.Portfolio,
        (int) ArticleName.Resume,
    };

    public static readonly int[] GreyAndBlackRequirements = {
        (int)ArticleName.Flagship,
    };

    public static readonly int[] AspNetRequirements = {
        (int) ArticleName.WaterLogger,
        (int) ArticleName.Movies,
        (int) ArticleName.TodoList,
        (int) ArticleName.Budget,
    };

    public static readonly int[] AngularRequirements = {
        (int) ArticleName.TourOfHeroes,
        (int) ArticleName.CoffeeTracker,
        (int) ArticleName.SleepTracker,
        (int) ArticleName.Quizgame
    };

    public static readonly int[] ReactRequirements = {
        (int)ArticleName.TicTacToe,
        (int)ArticleName.ExternalApi,
        (int)ArticleName.ShoppingList,
        (int)ArticleName.FriendsManager
    };

    public static readonly int[] BlazorRequirements = {
        (int) ArticleName.WardrobeInventory,
        (int) ArticleName.MemoryGame,
        (int) ArticleName.FoodJournal,
        (int) ArticleName.SportsStatistics
    };

    public static readonly int[] MauiRequirements = {
        (int) ArticleName.MauiMath,
        (int) ArticleName.Books,
        (int) ArticleName.Monkeys,
        (int) ArticleName.Warehouse
    };

    public static readonly int[] AuthRequirements = {
        (int) ArticleName.Auth,
        (int) ArticleName.ProductManagement,
        (int) ArticleName.ExternalAuth,
        (int) ArticleName.Auth0
    };

    public static readonly int[] SqlRequirements = {
        (int) ArticleName.Sql1,
        (int) ArticleName.Sql2,
        (int) ArticleName.Sql3
    };

    public static readonly int[] AzureRequirements = {
        (int) ArticleName.DeploySimpleApp,
        (int) ArticleName.DeployFullStack,
        (int) ArticleName.DeployFramework,
    };

    public static readonly int[][] FullStackAreas = {
        AspNetRequirements,
        AngularRequirements,
        ReactRequirements,
        BlazorRequirements, MauiRequirements
    };

    public static readonly int[][] AspNetAreas = {
        AspNetRequirements,
        BlazorRequirements,
        MauiRequirements
    };
    #endregion

    public static List<int> completedProjects = new();
    public static List<int> mauiProjects = ProjectHelper.GetProjects().Where(x => x.Area == Area.MAUI).Select(x => x.Id).ToList();
    public static List<int> angularProjects = ProjectHelper.GetProjects().Where(x => x.Area == Area.Angular).Select(x => x.Id).ToList();
    public static List<int> blazorProjects = ProjectHelper.GetProjects().Where(x => x.Area == Area.Blazor).Select(x => x.Id).ToList();
    public static List<int> reactProjects = ProjectHelper.GetProjects().Where(x => x.Area == Area.React).Select(x => x.Id).ToList();
    public static List<int> mvcProjects = ProjectHelper.GetProjects().Where(x => x.Area == Area.MVC).Select(x => x.Id).ToList();

    public static string GetUrl(RoadmapTask task)
    {
        if (task.Id == 0) return string.Empty;

        var taskType = task.IsProject ? "project" : "article";
        return $"{taskType}/{task.Id}/{task.Slug}";

    }

    public static string GetExpectedBelt(List<int> completedProjects, int issues, int reviews)
    {
        var level = Level.White;

        level = GreenRequirements.All(completedProjects.Contains) ? Level.Green : level;
        level = (level >= Level.Green && OliveGreenRequirements.All(completedProjects.Contains)) ? Level.OliveGreen : level;
        level = (level >= Level.OliveGreen && YellowRequirements.All(completedProjects.Contains)) ? Level.Yellow : level;
        level = (level >= Level.Yellow && OrangeRequirements.All(completedProjects.Contains)) ? Level.Orange : level;

        if (level >= Level.Orange
            && RedRequirements.All(completedProjects.Contains)
            && issues >= 1
            && reviews >= 2)
        {
            level = Level.Red;
        }

        int fullStackAreas = GetFullStackAreasCompleted(completedProjects).Count;

        if (level >= Level.Red
            && fullStackAreas >= 1
            && issues >= 2
            && reviews >= 4)
        {
            level = Level.Purple;
        }

        if (level >= Level.Purple
            && AuthRequirements.All(completedProjects.Contains)
            && issues >= 4
            && reviews >= 7)
        {
            level = Level.Brown;
        }

        if (level >= Level.Brown
            && SqlRequirements.All(completedProjects.Contains)
            && completedProjects.Contains(139)
            && issues >= 7
            && reviews >= 12)
        {
            level = Level.Grey;
        }

        if (level >= Level.Grey
            && AzureRequirements.All(completedProjects.Contains)
            && issues >= 10
            && reviews >= 17)
        {
            level = Level.Blue;
        }

        if (level >= Level.Blue
            && fullStackAreas >= 2
            && issues >= 15
            && reviews >= 25)
        {
            level = Level.Black;
        }

        return level.ToString();
    }

    public static RoadmapResult GetRoadmap(Level level, List<int> completedProjects, int reviewsCount, int issuesCount)
    {
        var stages = new List<RoadmapStage>
        {
            GetGreenBeltTasks(completedProjects),
            GetOliveGreenBeltTasks(level, completedProjects),
            GetYellowBeltTasks(level, completedProjects),
            GetOrangeBeltTasks(level, completedProjects),
            GetRedBeltTasks(level, completedProjects, reviewsCount, issuesCount),
            GetPurpleBeltTasks(level, completedProjects, reviewsCount, issuesCount),
            GetBrownBeltTasks(level, completedProjects, reviewsCount, issuesCount),
            GetGreyBeltTasks(level, completedProjects, reviewsCount, issuesCount),
            GetBlueBeltTasks(level, completedProjects, reviewsCount, issuesCount),
            GetBlackBeltTasks(level, completedProjects, reviewsCount, issuesCount),
        };

        Level nextLevel = level < Level.Black ? level + 1 : Level.Black;
        RoadmapStage? nextStage = nextLevel switch
        {
            Level.Green => stages[0],
            Level.OliveGreen => stages[1],
            Level.Yellow => stages[2],
            Level.Orange => stages[3],
            Level.Red => stages[4],
            Level.Purple => stages[5],
            Level.Brown => stages[6],
            Level.Grey => stages[7],
            Level.Blue => stages[8],
            Level.Black => stages[9],
            _ => null
        };

        var missingTasks = nextStage?.Tasks
            .Where(x => !x.IsCompleted)
            .ToList() ?? new List<RoadmapTask>();

        return new RoadmapResult
        {
            Stages = stages,
            MissingTasksForNextBelt = missingTasks
        };
    }
    public static RoadmapStage GetGreenBeltTasks(List<int> completedProjects)
    {
        var result = new RoadmapStage();
        result.Class = "custom-color-green";

        var tasks = Articles
        .Where(x => x.Level == Level.Green)
        .Select(x => new RoadmapTask
        {
            Id = x.Id,
            IconUrl = x.IconUrl,
            Name = x.Title,
            Slug = x.Slug,
            IsArticle = true,
            IsCompleted = completedProjects.Contains(x.Id),
            Tooltip = $"Read {x.Title} article"
        })
            .ToList();

        var greenBeltProjectTasks = Projects
        .Where(x => x.Level == Level.Green)
        .Select(x => new RoadmapTask
        {
            Id = x.Id,
            IconUrl = x.IconUrl,
            Name = x.Title,
            Slug = x.Slug,
            IsProject = true,
            IsCompleted = completedProjects.Contains(x.Id),
            Tooltip = $"Complete {x.Title}"
        })
            .ToList();

        tasks.AddRange(greenBeltProjectTasks);

        result.Tasks = tasks;

        return result;
    }
    public static RoadmapStage GetOliveGreenBeltTasks(Level userLevel, List<int> completedProjects)
    {
        var result = new RoadmapStage();
        result.Class = "custom-color-olivegreen";

        var tasks = Projects
        .Where(x => x.Level == Level.OliveGreen)
        .Select(x => new RoadmapTask
        {
            Id = x.Id,
            IconUrl = x.IconUrl,
            Name = x.Title,
            Slug = x.Slug,
            IsProject = true,
            IsCompleted = completedProjects.Contains(x.Id),
            Tooltip = $"Complete {x.Title}"
        })
            .ToList();

        result.Tasks = tasks;
        return result;
    }
    public static RoadmapStage GetYellowBeltTasks(Level userLevel, List<int> completedProjects)
    {
        var result = new RoadmapStage();
        result.Class = "custom-color-yellow";

        var tasks = Projects
        .Where(x => x.Level == Level.Yellow)
        .Select(x => new RoadmapTask
        {
            Id = x.Id,
            IconUrl = x.IconUrl,
            Name = x.Title,
            Slug = x.Slug,
            IsProject = true,
            IsCompleted = completedProjects.Contains(x.Id),
            Tooltip = $"Complete {x.Title}"
        })
            .ToList();

        result.Tasks = tasks;
        return result;
    }
    public static RoadmapStage GetOrangeBeltTasks(Level userLevel, List<int> completedProjects)
    {
        var result = new RoadmapStage();
        result.Class = "custom-color-orange";

        var tasks = Projects
        .Where(x => x.Level == Level.Orange)
        .Select(x => new RoadmapTask
        {
            Id = x.Id,
            IconUrl = x.IconUrl,
            Name = x.Title,
            Slug = x.Slug,
            IsProject = true,
            IsCompleted = completedProjects.Contains(x.Id),
            Tooltip = $"Complete {x.Title}"
        })
            .ToList();

        result.Tasks = tasks;
        return result;
    }
    public static RoadmapStage GetRedBeltTasks(Level userLevel, List<int> completedProjects, int reviewsCount, int issuesCount)
    {
        var result = new RoadmapStage();
        result.Class = "custom-color-red";

        var tasks = Projects
        .Where(x => x.Level == Level.Red)
        .Select(x => new RoadmapTask
        {
            Id = x.Id,
            IconUrl = x.IconUrl,
            Name = x.Title,
            Slug = x.Slug,
            IsProject = true,
            IsCompleted = completedProjects.Contains(x.Id),
            Tooltip = $"Complete {x.Title}"
        })
            .ToList();

        tasks.AddRange(new List<RoadmapTask> {
            new RoadmapTask {
                IconUrl = "icons8-magnifying-glass-64.png",
                Name = "Code Review 1",
                IsCompleted = reviewsCount >= 1,
                Tooltip = "Complete Code Review 1 of 2"
            },
            new RoadmapTask {
                IconUrl = "icons8-magnifying-glass-64.png",
                Name = "Code Review 2",
                IsCompleted = reviewsCount >= 2,
                Tooltip = "Complete Code Review 2 of 2"
            },
            new RoadmapTask {
                IconUrl = "icons8-community-96.png",
                Name = "Community Project Issue 1",
                IsCompleted = issuesCount >= 1,
                Tooltip = "Complete 1 Community Project Issue"
            }
        });

        result.Tasks = tasks;
        return result;
    }
    public static RoadmapStage GetPurpleBeltTasks(Level userLevel, List<int> completedProjects, int reviewsCount, int issuesCount)
    {
        var result = new RoadmapStage();
        result.Class = "custom-color-purple";

        bool isFullStackCompleted =
            mvcProjects.All(x => completedProjects.Contains(x)) ||
            reactProjects.All(x => completedProjects.Contains(x)) ||
            angularProjects.All(x => completedProjects.Contains(x)) ||
            blazorProjects.All(x => completedProjects.Contains(x));

        var tasks = new List<RoadmapTask>();

        tasks.AddRange(new List<RoadmapTask> {
            new RoadmapTask
            {
                IconUrl = "fullstack.png",
                Name = "Complete any Full-stack Area",
                IsCompleted = isFullStackCompleted,
                Tooltip = "Complete all projects in one full-stack area (MVC, React, Angular, Blazor or MAUI)"
            },
            new RoadmapTask {
                IconUrl = "icons8-magnifying-glass-64.png",
                Name = "Code Review 3",
                IsCompleted = reviewsCount >= 3,
                Tooltip = "Complete Code Review 1 of 2"
            },
            new RoadmapTask {
                IconUrl = "icons8-magnifying-glass-64.png",
                Name = "Code Review 4",
                IsCompleted = reviewsCount >= 4,
                Tooltip = "Complete Code Review 2 of 2"
            },
            new RoadmapTask {
                IconUrl = "icons8-community-96.png",
                Name = "Community Project Issue 2",
                IsCompleted = issuesCount >= 2,
                Tooltip = "Complete 1 Community Project Issue"
            }
        });

        result.Tasks = tasks;
        return result;
    }
    public static RoadmapStage GetBrownBeltTasks(Level userLevel, List<int> completedProjects, int reviewsCount, int issuesCount)
    {
        var result = new RoadmapStage();
        result.Class = "custom-color-brown";

        var tasks = Projects
        .Where(x => x.Level == Level.Brown)
        .Select(x => new RoadmapTask
        {
            Id = x.Id,
            IconUrl = x.IconUrl,
            Name = x.Title,
            Slug = x.Slug,
            IsProject = true,
            IsCompleted = completedProjects.Contains(x.Id),
            Tooltip = $"Complete {x.Title}"
        })
            .ToList();

        tasks.AddRange(new List<RoadmapTask> {
            new RoadmapTask {
                IconUrl = "icons8-magnifying-glass-64.png",
                Name = "Code Review 5",
                IsCompleted = reviewsCount >= 5,
                Tooltip = "Complete Code Review 1 of 3"
            },
            new RoadmapTask {
                IconUrl = "icons8-magnifying-glass-64.png",
                Name = "Code Review 6",
                IsCompleted = reviewsCount >= 6,
                Tooltip = "Complete Code Review 2 of 3"
            },
            new RoadmapTask {
                IconUrl = "icons8-magnifying-glass-64.png",
                Name = "Code Review 7",
                IsCompleted = reviewsCount >= 7,
                Tooltip = "Complete Code Review 3 of 3"
            },
            new RoadmapTask {
                IconUrl = "icons8-community-96.png",
                Name = "Community Project Issue 3",
                IsCompleted = issuesCount >= 3,
                Tooltip = "Complete Community Project Issue 1 of 2"
            },
            new RoadmapTask {
                IconUrl = "icons8-community-96.png",
                Name = "Community Project Issue 4",
                IsCompleted = issuesCount >= 4,
                Tooltip = "Complete Community Project Issue 2 of 2"
            }
        });

        result.Tasks = tasks;
        return result;
    }
    public static RoadmapStage GetGreyBeltTasks(Level userLevel, List<int> completedProjects, int reviewsCount, int issuesCount)
    {
        var result = new RoadmapStage();
        result.Class = "custom-color-gray";

        var tasks = Projects
            .Where(x => x.Level == Level.Grey)
            .Select(x => new RoadmapTask
            {
                Id = x.Id,
                IconUrl = x.IconUrl,
                Name = x.Title,
                Slug = x.Slug,
                IsProject = true,
                IsCompleted = completedProjects.Contains(x.Id),
                Tooltip = $"Complete {x.Title}"
            })
            .ToList();

        tasks.Add(new RoadmapTask
        {
            IconUrl = FlagshipProject.IconUrl,
            Name = FlagshipProject.Title,
            IsCompleted = false,
            Tooltip = "Submit a PR with Readme and Systems Design For Flagship Project"
        });

        tasks.AddRange(new List<RoadmapTask> {
            new RoadmapTask {
                IconUrl = "icons8-magnifying-glass-64.png",
                Name = "Code Review 8",
                IsCompleted = reviewsCount >= 8,
                Tooltip = "Complete Code Review 1 of 5"
            },
            new RoadmapTask {
                IconUrl = "icons8-magnifying-glass-64.png",
                Name = "Code Review 9",
                IsCompleted = reviewsCount >= 9,
                Tooltip = "Complete Code Review 2 of 5"
            },
            new RoadmapTask {
                IconUrl = "icons8-magnifying-glass-64.png",
                Name = "Code Review 10",
                IsCompleted = reviewsCount >= 10,
                Tooltip = "Complete Code Review 3 of 5"
            },
            new RoadmapTask {
                IconUrl = "icons8-magnifying-glass-64.png",
                Name = "Code Review 11",
                IsCompleted = reviewsCount >= 11,
                Tooltip = "Complete Code Review 4 of 5"
            },
            new RoadmapTask {
                IconUrl = "icons8-magnifying-glass-64.png",
                Name = "Code Review 12",
                IsCompleted = reviewsCount >= 12,
                Tooltip = "Complete Code Review 5 of 5"
            },
            new RoadmapTask {
                IconUrl = "icons8-community-96.png",
                Name = "Community Project Issue 5",
                IsCompleted = issuesCount >= 5,
                Tooltip = "Complete Community Project Issue 1 of 3"
            },
            new RoadmapTask {
                IconUrl = "icons8-community-96.png",
                Name = "Community Project Issue 6",
                IsCompleted = issuesCount >= 6,
                Tooltip = "Complete Community Project Issue 2 of 3"
            },
            new RoadmapTask {
                IconUrl = "icons8-community-96.png",
                Name = "Community Project Issue 7",
                IsCompleted = issuesCount >= 7,
                Tooltip = "Complete Community Project Issue 3 of 3"
            },
        });

        result.Tasks = tasks;
        return result;
    }
    public static RoadmapStage GetBlueBeltTasks(Level userLevel, List<int> completedProjects, int reviewsCount, int issuesCount)
    {
        var result = new RoadmapStage();
        result.Class = "custom-color-blue";

        var tasks = Projects
       .Where(x => x.Level == Level.Blue)
       .Select(x => new RoadmapTask
       {
           Id = x.Id,
           IconUrl = x.IconUrl,
           Name = x.Title,
           Slug = x.Slug,
           IsProject = true,
           IsCompleted = completedProjects.Contains(x.Id),
           Tooltip = $"Complete {x.Title}"
       })
           .ToList();

        tasks.AddRange(new List<RoadmapTask> {
            new RoadmapTask {
                IconUrl = "icons8-magnifying-glass-64.png",
                Name = "Code Review 13",
                IsCompleted = reviewsCount >= 13,
                Tooltip = "Complete Code Review 1 of 5"
            },
            new RoadmapTask {
                IconUrl = "icons8-magnifying-glass-64.png",
                Name = "Code Review 14",
                IsCompleted = reviewsCount >= 14,
                Tooltip = "Complete Code Review 2 of 5"
            },
            new RoadmapTask {
                IconUrl = "icons8-magnifying-glass-64.png",
                Name = "Code Review 15",
                IsCompleted = reviewsCount >= 15,
                Tooltip = "Complete Code Review 3 of 5"
            },
            new RoadmapTask {
                IconUrl = "icons8-magnifying-glass-64.png",
                Name = "Code Review 16",
                IsCompleted = reviewsCount >= 16,
                Tooltip = "Complete Code Review 4 of 5"
            },
            new RoadmapTask {
                IconUrl = "icons8-magnifying-glass-64.png",
                Name = "Code Review 17",
                IsCompleted = reviewsCount >= 17,
                Tooltip = "Complete Code Review 5 of 5"
            },
            new RoadmapTask {
                IconUrl = "icons8-community-96.png",
                Name = "Community Project Issue 8",
                IsCompleted = issuesCount >= 8,
                Tooltip = "Complete Community Project Issue 1 of 3"
            },
            new RoadmapTask {
                IconUrl = "icons8-community-96.png",
                Name = "Community Project Issue 9",
                IsCompleted = issuesCount >= 9,
                Tooltip = "Complete Community Project Issue 2 of 3"
            },
            new RoadmapTask {
                IconUrl = "icons8-community-96.png",
                Name = "Community Project Issue 10",
                IsCompleted = issuesCount >= 10,
                Tooltip = "Complete Community Project Issue 3 of 3"
            },
        });

        result.Tasks = tasks;
        return result;
    }
    public static RoadmapStage GetBlackBeltTasks(Level userLevel, List<int> completedProjects, int reviewsCount, int issuesCount)
    {
        var result = new RoadmapStage();
        result.Class = "custom-color-black";

        int fullStackCompleted = GetFullStackAreasCompleted(completedProjects).Count;

        var tasks = new List<RoadmapTask>();

        tasks.AddRange(new List<RoadmapTask> {
            new RoadmapTask
            {
                IconUrl = "fullstack2.png",
                Name = "Complete any 2 Full-stack Areas",
                IsCompleted = fullStackCompleted >= 2,
                Tooltip = "Complete all projects in two full-stack areas (MVC, React, Angular, Blazor or MAUI)"
            },
            new RoadmapTask {
                IconUrl = "icons8-magnifying-glass-64.png",
                Name = "Code Review 18",
                IsCompleted = reviewsCount >= 18,
                Tooltip = "Complete Code Review 1 of 8"
            },
            new RoadmapTask {
                IconUrl = "icons8-magnifying-glass-64.png",
                Name = "Code Review 19",
                IsCompleted = reviewsCount >= 19,
                Tooltip = "Complete Code Review 2 of 8"
            },
            new RoadmapTask {
                IconUrl = "icons8-magnifying-glass-64.png",
                Name = "Code Review 20",
                IsCompleted = reviewsCount >= 20,
                Tooltip = "Complete Code Review 3 of 8"
            },
            new RoadmapTask {
                IconUrl = "icons8-magnifying-glass-64.png",
                Name = "Code Review 21",
                IsCompleted = reviewsCount >= 21,
                Tooltip = "Complete Code Review 4 of 8"
            },
            new RoadmapTask {
                IconUrl = "icons8-magnifying-glass-64.png",
                Name = "Code Review 22",
                IsCompleted = reviewsCount >= 22,
                Tooltip = "Complete Code Review 5 of 8"
            },
            new RoadmapTask {
                IconUrl = "icons8-magnifying-glass-64.png",
                Name = "Code Review 23",
                IsCompleted = reviewsCount >= 23,
                Tooltip = "Complete Code Review 6 of 8"
            },
            new RoadmapTask {
                IconUrl = "icons8-magnifying-glass-64.png",
                Name = "Code Review 24",
                IsCompleted = reviewsCount >= 24,
                Tooltip = "Complete Code Review 7 of 8"
            },
            new RoadmapTask {
                IconUrl = "icons8-magnifying-glass-64.png",
                Name = "Code Review 25",
                IsCompleted = reviewsCount >= 25,
                Tooltip = "Complete Code Review 8 of 8"
            },
            new RoadmapTask {
                IconUrl = "icons8-community-96.png",
                Name = "Community Project Issue 11",
                IsCompleted = issuesCount >= 11,
                Tooltip = "Complete Community Project Issue 1 of 5"
            },
            new RoadmapTask {
                IconUrl = "icons8-community-96.png",
                Name = "Community Project Issue 12",
                IsCompleted = issuesCount >= 12,
                Tooltip = "Complete Community Project Issue 2 of 5"
            },
            new RoadmapTask {
                IconUrl = "icons8-community-96.png",
                Name = "Community Project Issue 13",
                IsCompleted = issuesCount >= 13,
                Tooltip = "Complete Community Project Issue 3 of 5"
            },
            new RoadmapTask {
                IconUrl = "icons8-community-96.png",
                Name = "Community Project Issue 14",
                IsCompleted = issuesCount >= 14,
                Tooltip = "Complete Community Project Issue 4 of 5"
            },
            new RoadmapTask {
                IconUrl = "icons8-community-96.png",
                Name = "Community Project Issue 15",
                IsCompleted = issuesCount >= 15,
                Tooltip = "Complete Community Project Issue 5 of 5"
            },
        });

        tasks.Add(new RoadmapTask
        {
            IconUrl = FlagshipProject.IconUrl,
            Name = FlagshipProject.Title,
            IsCompleted = false,
            Tooltip = "Complete Flagship Project"
        });

        result.Tasks = tasks;
        return result;
    }

    public static List<Area> GetFullStackAreasCompleted(List<int> completedProjects)
    {
        List<Area> fullStackAreas = new();

        if (mvcProjects.All(x => completedProjects.Contains(x))) fullStackAreas.Add(Area.MVC);
        if (reactProjects.All(x => completedProjects.Contains(x))) fullStackAreas.Add(Area.React);
        if (angularProjects.All(x => completedProjects.Contains(x))) fullStackAreas.Add(Area.Angular);
        if (blazorProjects.All(x => completedProjects.Contains(x))) fullStackAreas.Add(Area.Blazor);
        if (mauiProjects.All(x => completedProjects.Contains(x))) fullStackAreas.Add(Area.MAUI);

        return fullStackAreas;
    }

    public static List<RoadmapGridCell> GetCellsForPublicRoadmap(Area area1, Area area2)
    {
        var cells = new List<RoadmapGridCell>();
        var defaultCells = new List<RoadmapGridCell>
        {
            new RoadmapGridCell
            {
                Row = 0,
                Column = 0,
                Title = "White Belt",
                Icon = "white-belt.png",
                Content = "This is the starting point of your roadmap.",
                ConnectRight = true
            },
            new RoadmapGridCell
            {
                Row = 0,
                Column = 1,
                Title = "Start Here",
                Icon = "icons8-door-80.png",
                Content = "A quick read with an introduction to the C# Academy.",
                ConnectRight = true,
                ConnectLeft = true
            },
            new RoadmapGridCell
            {
                Row = 0,
                Column = 2,
                Title = "Getting Help",
                Icon = "icons8-helping-96.png",
                Content = "Find out how to get unstuck when learning.",
                ConnectRight = true,
                ConnectLeft = true
            },
            new RoadmapGridCell
            {
                Row = 0,
                Column = 3,
                Title = "Setting Up",
                Icon = "icons8-project-setup-96-1.png",
                Content = "Learn how to set up your dev environment.",
                ConnectRight = true,
                ConnectLeft = true
            },
            new RoadmapGridCell
            {
                Row = 0,
                Column = 4,
                Title = "Foundations",
                Icon = "icons8-sharp-94.png",
                Content = "Time to start learning.",
                ConnectLeft = true,
                ConnectBottom = true,
            },
            new RoadmapGridCell
            {
                Row = 1,
                Column = 4,
                Title = "Freecodecamp",
                Icon = "freecodecamp.jpg",
                Content = "Dive into the code.",
                ConnectTop = true,
                ConnectLeft = true,
            },
            new RoadmapGridCell
            {
                Row = 1,
                Column = 3,
                Title = "Math Game",
                Icon = "icons8-maths-376.png",
                Content = "Your first project.",
                ConnectRight = true,
                ConnectLeft = true,
            },
            new RoadmapGridCell
            {
                Row = 1,
                Column = 2,
                Title = "Green Belt",
                Icon = "green-belt.png",
                Content = "You've earned your first belt",
                ConnectRight = true,
                ConnectLeft = true,
            },
            new RoadmapGridCell
            {
                Row = 1,
                Column = 1,
                Title = "Calculator",
                Icon = "icons8-calculator-512.png",
                Content = "This is the starting point of your roadmap.",
                ConnectRight = true,
                ConnectLeft = true
            },
            new RoadmapGridCell
            {
                Row = 1,
                Column = 0,
                Title = "Habit Logger",
                Icon = "icons8-calendar-plus-96.png",
                Content = "A quick read with an introduction to the C# Academy.",
                ConnectRight = true,
                ConnectBottom = true
            },
            new RoadmapGridCell
            {
                Row = 2,
                Column = 0,
                Title = "Coding Tracker",
                Icon = "icons8-smart-watch-96.png",
                Content = "Find out how to get unstuck when learning.",
                ConnectRight = true,
                ConnectTop = true
            },
            new RoadmapGridCell
            {
                Row = 2,
                Column = 1,
                Title = "Olive Green Belt",
                Icon = "olivegreen-belt.png",
                Content = "You've earned your first belt",
                ConnectRight = true,
                ConnectLeft = true,
            },
            new RoadmapGridCell
            {
                Row = 2,
                Column = 2,
                Title = "Flashcards",
                Icon = "icons8-quizlet-96.png",
                Content = "Learn how to set up your dev environment.",
                ConnectRight = true,
                ConnectLeft = true
            },
            new RoadmapGridCell
            {
                Row = 2,
                Column = 3,
                Title = "Cocktail App",
                Icon = "drinks.png",
                Content = "Time to start learning.",
                ConnectLeft = true,
                ConnectRight = true,
            },
            new RoadmapGridCell
            {
                Row = 2,
                Column = 4,
                Title = "Phone Book",
                Icon = "icons8-contact-book-512-150x150.png",
                Content = "Dive into the code.",
                ConnectBottom = true,
                ConnectLeft = true,
            },
            new RoadmapGridCell
            {
                Row = 3,
                Column = 4,
                Title = "Shifts Logger",
                Icon = "icons8-nurse-256.png",
                Content = "Your first project.",
                ConnectTop = true,
                ConnectLeft = true,
            },
            new RoadmapGridCell
            {
                Row = 3,
                Column = 3,
                Title = "Yellow Belt",
                Icon = "yellow-belt.png",
                Content = "Your first project.",
                ConnectRight = true,
                ConnectLeft = true,
            },
            new RoadmapGridCell
            {
                Row = 3,
                Column = 2,
                Title = "Ecommerce API",
                Icon = "icons8-shop-94.png",
                Content = "Your first project.",
                ConnectRight = true,
                ConnectLeft = true,
            },
            new RoadmapGridCell
            {
                Row = 3,
                Column = 1,
                Title = "Sports Results",
                Icon = "icons8-sports-96.png",
                Content = "Your first project.",
                ConnectRight = true,
                ConnectLeft = true,
            },
            new RoadmapGridCell
            {
                Row = 3,
                Column = 0,
                Title = "Document Processor",
                Icon = "excel.png",
                Content = "Your first project.",
                ConnectRight = true,
                ConnectBottom = true,
            },
            new RoadmapGridCell
            {
                Row = 4,
                Column = 0,
                Title = "Unit Testing",
                Icon = "icons8-test-tube-100.png",
                Content = "Your first project.",
                ConnectRight = true,
                ConnectTop = true,
            },
            new RoadmapGridCell
            {
                Row = 4,
                Column = 1,
                Title = "Orange Belt",
                Icon = "orange-belt.png",
                Content = "Your first project.",
                ConnectRight = true,
                ConnectTop = true,
            },
            new RoadmapGridCell
            {
                Row = 4,
                Column = 2,
                Title = "Portfolio",
                Icon = "icons8-portfolio-512.png",
                Content = "Your first project.",
                ConnectRight = true,
                ConnectLeft = true,
            },
            new RoadmapGridCell
            {
                Row = 4,
                Column = 3,
                Title = "Resume",
                Icon = "icons8-resume-512.png",
                Content = "Your first project.",
                ConnectRight = true,
                ConnectLeft = true,
            },
            new RoadmapGridCell
            {
                Row = 4,
                Column = 4,
                Title = "Red Belt",
                Icon = "red-belt.png",
                Content = "Your first project.",
                ConnectBottom = true,
                ConnectLeft = true,
            },
            new RoadmapGridCell
            {
                Row = 4,
                Column = 4,
                Title = "Red Belt",
                Icon = "red-belt.png",
                Content = "Your first project.",
                ConnectBottom = true,
                ConnectLeft = true,
            },
            new RoadmapGridCell
            {
                Row = 5,
                Column = 0,
                Title = "Purple Belt",
                Icon = "purple-belt.png",
                Content = "Your first project.",
                ConnectBottom = true,
                ConnectRight = true,
            },
        };

        var area1Cells = GetAreaCells(area1);
        //var area2Cells = GetAreaCells(area2);

        cells.AddRange(defaultCells);
        cells.AddRange(area1Cells);
        //cells.AddRange(area2Cells);

        return cells;
    }

    public static List<RoadmapGridCell> GetAreaCells(Area area1)
    {
        var blazorCells = new List<RoadmapGridCell>
        {
            new RoadmapGridCell
            {
                Row = 5,
                Column = 4,
                Title = "Wardrobe Inventory",
                Icon = "icons8-wardrobe-392.png",
                Content = "This is the starting point of your roadmap.",
                ConnectRight = true
            },
            new RoadmapGridCell
            {
                Row = 5,
                Column = 3,
                Title = "Memory Game",
                Icon = "icons8-memory-512.png",
                Content = "A quick read with an introduction to the C# Academy.",
                ConnectRight = true,
                ConnectLeft = true
            },
            new RoadmapGridCell
            {
                Row = 5,
                Column = 2,
                Title = "Food Journal",
                Icon = "icons8-helping-96.png",
                Content = "Find out how to get unstuck when learning.",
                ConnectRight = true,
                ConnectLeft = true
            },
            new RoadmapGridCell
            {
                Row = 5,
                Column = 1,
                Title = "Sports Statistics",
                Icon = "icons8-football-team-470.png",
                Content = "Learn how to set up your dev environment.",
                ConnectRight = true,
                ConnectLeft = true
            }
        };
        var reactCells = new List<RoadmapGridCell>
        {
            new RoadmapGridCell
            {
                Row = 0,
                Column = 0,
                Title = "White Belt",
                Icon = "white-belt.png",
                Content = "This is the starting point of your roadmap.",
                ConnectRight = true
            },
            new RoadmapGridCell
            {
                Row = 0,
                Column = 1,
                Title = "Start Here",
                Icon = "icons8-door-80.png",
                Content = "A quick read with an introduction to the C# Academy.",
                ConnectRight = true,
                ConnectLeft = true
            },
            new RoadmapGridCell
            {
                Row = 0,
                Column = 2,
                Title = "Getting Help",
                Icon = "icons8-helping-96.png",
                Content = "Find out how to get unstuck when learning.",
                ConnectRight = true,
                ConnectLeft = true
            },
            new RoadmapGridCell
            {
                Row = 0,
                Column = 3,
                Title = "Setting Up",
                Icon = "icons8-project-setup-96-1.png",
                Content = "Learn how to set up your dev environment.",
                ConnectRight = true,
                ConnectLeft = true
            }
        };
        var angularCells = new List<RoadmapGridCell>
        {
            new RoadmapGridCell
            {
                Row = 0,
                Column = 0,
                Title = "White Belt",
                Icon = "white-belt.png",
                Content = "This is the starting point of your roadmap.",
                ConnectRight = true
            },
            new RoadmapGridCell
            {
                Row = 0,
                Column = 1,
                Title = "Start Here",
                Icon = "icons8-door-80.png",
                Content = "A quick read with an introduction to the C# Academy.",
                ConnectRight = true,
                ConnectLeft = true
            },
            new RoadmapGridCell
            {
                Row = 0,
                Column = 2,
                Title = "Getting Help",
                Icon = "icons8-helping-96.png",
                Content = "Find out how to get unstuck when learning.",
                ConnectRight = true,
                ConnectLeft = true
            },
            new RoadmapGridCell
            {
                Row = 0,
                Column = 3,
                Title = "Setting Up",
                Icon = "icons8-project-setup-96-1.png",
                Content = "Learn how to set up your dev environment.",
                ConnectRight = true,
                ConnectLeft = true
            }
        };
        var mvcCells = new List<RoadmapGridCell>
        {
            new RoadmapGridCell
            {
                Row = 0,
                Column = 0,
                Title = "White Belt",
                Icon = "white-belt.png",
                Content = "This is the starting point of your roadmap.",
                ConnectRight = true
            },
            new RoadmapGridCell
            {
                Row = 0,
                Column = 1,
                Title = "Start Here",
                Icon = "icons8-door-80.png",
                Content = "A quick read with an introduction to the C# Academy.",
                ConnectRight = true,
                ConnectLeft = true
            },
            new RoadmapGridCell
            {
                Row = 0,
                Column = 2,
                Title = "Getting Help",
                Icon = "icons8-helping-96.png",
                Content = "Find out how to get unstuck when learning.",
                ConnectRight = true,
                ConnectLeft = true
            },
            new RoadmapGridCell
            {
                Row = 0,
                Column = 3,
                Title = "Setting Up",
                Icon = "icons8-project-setup-96-1.png",
                Content = "Learn how to set up your dev environment.",
                ConnectRight = true,
                ConnectLeft = true
            }
        };
        var mauiCells = new List<RoadmapGridCell>
        {
            new RoadmapGridCell
            {
                Row = 0,
                Column = 0,
                Title = "White Belt",
                Icon = "white-belt.png",
                Content = "This is the starting point of your roadmap.",
                ConnectRight = true
            },
            new RoadmapGridCell
            {
                Row = 0,
                Column = 1,
                Title = "Start Here",
                Icon = "icons8-door-80.png",
                Content = "A quick read with an introduction to the C# Academy.",
                ConnectRight = true,
                ConnectLeft = true
            },
            new RoadmapGridCell
            {
                Row = 0,
                Column = 2,
                Title = "Getting Help",
                Icon = "icons8-helping-96.png",
                Content = "Find out how to get unstuck when learning.",
                ConnectRight = true,
                ConnectLeft = true
            },
            new RoadmapGridCell
            {
                Row = 0,
                Column = 3,
                Title = "Setting Up",
                Icon = "icons8-project-setup-96-1.png",
                Content = "Learn how to set up your dev environment.",
                ConnectRight = true,
                ConnectLeft = true
            }
        };

        return blazorCells;
    }
}
