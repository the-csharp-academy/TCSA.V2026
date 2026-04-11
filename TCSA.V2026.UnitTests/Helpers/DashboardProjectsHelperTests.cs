using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using TCSA.V2026.Data.Curriculum;
using TCSA.V2026.Data.Helpers;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Helpers;
using TaskStatus = TCSA.V2026.Data.DTOs.TaskStatus;

namespace TCSA.V2026.UnitTests.Helpers;

[TestFixture]
public class DashboardProjectsHelperTests
{
    [SetUp]
    public void SetUp()
    {
        var mockConfig = new Mock<IConfiguration>();
        mockConfig.Setup(c => c["LinkProvider:DiscordLink"]).Returns("https://discord.gg/test");

        ServiceProviderAccessor.ServiceProvider = new ServiceCollection()
            .AddSingleton(mockConfig.Object)
            .BuildServiceProvider();
    }

    [Test]
    public void GetTaskStatus_ShouldReturnPendingReviewStatus_WhenProjectIsPending()
    {
        // Arrange
        var projectId = 4;
        var completedProjects = new List<int> { 1, 2, 3 };
        var pendingReviewProjects = new List<int> { 4 };

        // Act
        var status = DashboardProjectsHelpers.GetTaskStatus(projectId, completedProjects, pendingReviewProjects);

        // Assert
        Assert.That(status, Is.EqualTo(TaskStatus.PendingReview));
    }

    [Test]
    public void GetTaskStatus_ShouldReturnCompletedStatus_WhenProjectIsCompleted()
    {
        // Arrange
        var projectId = 3;
        var completedProjects = new List<int> { 1, 2, 3 };
        var pendingReviewProjects = new List<int> { 4 };

        // Act
        var status = DashboardProjectsHelpers.GetTaskStatus(projectId, completedProjects, pendingReviewProjects);

        // Assert
        Assert.That(status, Is.EqualTo(TaskStatus.Completed));
    }

    [Test]
    public void GetTaskStatus_ShouldReturnNotCompletedStatus_WhenProjectIsNotCompleted()
    {
        // Arrange
        var projectId = 5;
        var completedProjects = new List<int> { 1, 2, 3 };
        var pendingReviewProjects = new List<int> { 4 };

        // Act
        var status = DashboardProjectsHelpers.GetTaskStatus(projectId, completedProjects, pendingReviewProjects);

        // Assert
        Assert.That(status, Is.EqualTo(TaskStatus.NotCompleted));
    }

    [TestCase(Area.StartHere, (int)ArticleName.StartHere, "start-here")]
    [TestCase(Area.StartHere, (int)ArticleName.GettingHelp, "getting-help")]
    [TestCase(Area.StartHere, (int)ArticleName.SettingUp, "setting-up")]
    [TestCase(Area.StartHere, (int)ArticleName.Foundations, "foundations")]
    [TestCase(Area.StartHere, (int)ArticleName.ImportanceOfConsole, "the-importance-of-console-applictions")]
    public void GetUrl_ShouldReturnArticleUrl_ForStartHereArea(Area area, int taskId, string taskSlug)
    {
        // Act
        var url = DashboardProjectsHelpers.GetUrl(area, taskId, taskSlug);

        // Assert
        Assert.That(url, Is.EqualTo($"article/{taskId}/{taskSlug}"));
    }

    [Test]
    public void GetUrl_ShouldReturnProjectUrl_ForFreecodeCampCertification()
    {
        // Arrange
        var area = Area.StartHere;
        var taskId = (int)ArticleName.FreecodeCamp;
        var taskSlug = "freecodecamp-certification";

        // Act
        var url = DashboardProjectsHelpers.GetUrl(area, taskId, taskSlug);

        // Assert
        Assert.That(url, Is.EqualTo($"project/{taskId}/{taskSlug}"));
    }

    [Test]
    public void GetUrl_ShouldReturnProjectUrl_ForOtherAreas()
    {
        // Arrange
        var area = Area.MVC;
        var taskId = 24;
        var taskSlug = "water-logger";

        // Act
        var url = DashboardProjectsHelpers.GetUrl(area, taskId, taskSlug);

        // Assert
        Assert.That(url, Is.EqualTo($"project/{taskId}/{taskSlug}"));
    }

    [TestCase(Area.React, new[] { (int)ArticleName.ExternalApi, (int)ArticleName.ShoppingList, (int)ArticleName.FriendsManager })]
    [TestCase(Area.StartApplying, new[] { (int)ArticleName.Resume })]
    [TestCase(Area.SQL, new[] { (int)ArticleName.Sql2, (int)ArticleName.Sql3 })]
    [TestCase(Area.MVC, new[] { (int)ArticleName.TodoList, (int)ArticleName.Budget })]
    [TestCase(Area.Auth, new[] { (int)ArticleName.ProductManagement, (int)ArticleName.ExternalAuth })]
    [TestCase(Area.Angular, new[] { (int)ArticleName.CoffeeTracker, (int)ArticleName.SleepTracker, (int)ArticleName.Quizgame })]
    [TestCase(Area.Blazor, new[] { (int)ArticleName.MemoryGame, (int)ArticleName.FoodJournal, (int)ArticleName.SportsStatistics })]
    [TestCase(Area.MAUI, new[] { (int)ArticleName.Books, (int)ArticleName.Monkeys, (int)ArticleName.Warehouse })]
    [TestCase(Area.Azure, new[] { (int)ArticleName.DeployFullStack, (int)ArticleName.DeployFramework, (int)ArticleName.AzureFunctions })]
    [TestCase(Area.Docker, new int[0])]
    [TestCase(Area.MonthlyChallenge, new int[0])]
    [TestCase(Area.GraduationProject, new int[0])]
    public void CheckIfAreaIsCompleted_ShouldReturnFalse_WhenOtherAreaThanStartHereIsNotCompleted(
        Area area,
        int[] completedProjects)
    {
        // Arrange
        var articles = ArticleHelper.GetArticles();
        var projects = ProjectHelper.GetProjects().Where(x => x.IsClosed == false);

        // Act
        var isCompleted = DashboardProjectsHelpers.CheckIfAreaIsCompleted(projects, articles, completedProjects.ToList(), area, null);

        // Assert
        Assert.That(isCompleted, Is.False);
    }

    [TestCase(Area.React, new[] { (int)ArticleName.TicTacToe, (int)ArticleName.ExternalApi, (int)ArticleName.ShoppingList, (int)ArticleName.FriendsManager })]
    [TestCase(Area.StartApplying, new[] { (int)ArticleName.Portfolio, (int)ArticleName.Resume })]
    [TestCase(Area.SQL, new[] { (int)ArticleName.Sql1, (int)ArticleName.Sql2, (int)ArticleName.Sql3 })]
    [TestCase(Area.MVC, new[] { (int)ArticleName.WaterLogger, (int)ArticleName.Movies, (int)ArticleName.TodoList, (int)ArticleName.Budget })]
    [TestCase(Area.Auth, new[] { (int)ArticleName.Auth, (int)ArticleName.ProductManagement, (int)ArticleName.ExternalAuth })]
    [TestCase(Area.Angular, new[] { (int)ArticleName.TourOfHeroes, (int)ArticleName.CoffeeTracker, (int)ArticleName.SleepTracker, (int)ArticleName.Quizgame })]
    [TestCase(Area.Blazor, new[] { (int)ArticleName.WardrobeInventory, (int)ArticleName.MemoryGame, (int)ArticleName.FoodJournal, (int)ArticleName.SportsStatistics })]
    [TestCase(Area.MAUI, new[] { (int)ArticleName.MauiMath, (int)ArticleName.Books, (int)ArticleName.Monkeys, (int)ArticleName.Warehouse })]
    [TestCase(Area.Azure, new[] { (int)ArticleName.DeploySimpleApp, (int)ArticleName.DeployFullStack, (int)ArticleName.DeployFramework, (int)ArticleName.AzureFunctions })]
    [TestCase(Area.Docker, new[] { (int)ArticleName.DockerIntro })]
    [TestCase(Area.MonthlyChallenge, new[] { (int)ArticleName.BreweryApi, (int)ArticleName.BuildAGame })]
    [TestCase(Area.GraduationProject, new[] { (int)ArticleName.Flagship })]
    public void CheckIfAreaIsCompleted_ShouldReturnTrue_WhenOtherAreaThanStartHereIsCompleted(
        Area area,
        int[] completedProjects)
    {
        // Arrange
        var articles = ArticleHelper.GetArticles();
        var projects = ProjectHelper.GetProjects().Where(x => x.IsClosed == false);

        // Act
        var isCompleted = DashboardProjectsHelpers.CheckIfAreaIsCompleted(projects, articles, completedProjects.ToList(), area, null);

        // Assert
        Assert.That(isCompleted, Is.True);
    }

    [Test]
    public void CheckIfAreaIsCompleted_ShouldReturnTrue_WhenStartHereAreaIsCompleted()
    {
        // Arrange
        var area = Area.StartHere;
        var completedProjects = new List<int>
        {
            (int)ArticleName.StartHere,
            (int)ArticleName.GettingHelp,
            (int)ArticleName.SettingUp,
            (int)ArticleName.Foundations,
            (int)ArticleName.ImportanceOfConsole,
            (int)ArticleName.FreecodeCamp
        };

        var articles = ArticleHelper.GetArticles();
        var projects = ProjectHelper.GetProjects().Where(x => x.IsClosed == false);

        // Act
        var isCompleted = DashboardProjectsHelpers.CheckIfAreaIsCompleted(projects, articles, completedProjects, area, null);

        // Assert
        Assert.That(isCompleted, Is.True);
    }

    [Test]
    public void CheckIfAreaIsCompleted_ShouldReturnFalse_WhenStartHereAreaIsNotCompleted()
    {
        // Arrange
        var area = Area.StartHere;
        var completedProjects = new List<int>
        {
            (int)ArticleName.StartHere,
            (int)ArticleName.GettingHelp,
            (int)ArticleName.SettingUp,
            (int)ArticleName.Foundations
        };

        var articles = ArticleHelper.GetArticles();
        var projects = ProjectHelper.GetProjects().Where(x => x.IsClosed == false);

        // Act
        var isCompleted = DashboardProjectsHelpers.CheckIfAreaIsCompleted(projects, articles, completedProjects, area, null);

        // Assert
        Assert.That(isCompleted, Is.False);
    }

    [TestCase(Area.Console, Difficulty.Beginner, new[] { (int)ArticleName.MathGame, (int)ArticleName.Calculator, (int)ArticleName.HabitLogger, (int)ArticleName.CodingTracker })]
    [TestCase(Area.Console, Difficulty.Intermediate, new[] { (int)ArticleName.Flashcards, (int)ArticleName.Drinks, (int)ArticleName.PhoneBook, (int)ArticleName.ShiftsLogger })]
    [TestCase(Area.Console, Difficulty.Advanced, new[] { (int)ArticleName.Ecommerce, (int)ArticleName.SportsResults, (int)ArticleName.ExcelReader, (int)ArticleName.UnitTesting })]
    public void CheckIfAreaIsCompleted_ShouldReturnTrue_WhenConsoleAreaWithDifficultyIsCompleted(
        Area area, Difficulty difficulty, int[] completedProjects)
    {
        // Arrange
        var articles = ArticleHelper.GetArticles();
        var projects = ProjectHelper.GetProjects().Where(x => x.IsClosed == false);

        // Act
        var isCompleted = DashboardProjectsHelpers.CheckIfAreaIsCompleted(projects, articles, completedProjects.ToList(), area, difficulty);

        // Assert
        Assert.That(isCompleted, Is.True);
    }

    [TestCase(Area.Console, Difficulty.Beginner, new[] { (int)ArticleName.Calculator, (int)ArticleName.HabitLogger, (int)ArticleName.CodingTracker })]
    [TestCase(Area.Console, Difficulty.Intermediate, new[] { (int)ArticleName.Drinks, (int)ArticleName.PhoneBook, (int)ArticleName.ShiftsLogger })]
    [TestCase(Area.Console, Difficulty.Advanced, new[] { (int)ArticleName.SportsResults, (int)ArticleName.ExcelReader, (int)ArticleName.UnitTesting })]
    public void CheckIfAreaIsCompleted_ShouldReturnFalse_WhenConsoleAreaWithDifficultyIsNotCompleted(
        Area area, Difficulty difficulty, int[] completedProjects)
    {
        // Arrange
        var articles = ArticleHelper.GetArticles();
        var projects = ProjectHelper.GetProjects().Where(x => x.IsClosed == false);

        // Act
        var isCompleted = DashboardProjectsHelpers.CheckIfAreaIsCompleted(projects, articles, completedProjects.ToList(), area, difficulty);

        // Assert
        Assert.That(isCompleted, Is.False);
    }

    [Test]
    public void GetAreas_StartHereDescriptionIsCorrect_WithFreeCodeCamp()
    {
        // Arrange
        var completedProjects = new List<int>
        {
            (int)ArticleName.StartHere,
            (int)ArticleName.GettingHelp,
            (int)ArticleName.SettingUp,
            (int)ArticleName.Foundations,
            (int)ArticleName.ImportanceOfConsole,
            (int)ArticleName.FreecodeCamp
        };

        var areas = DashboardProjectsHelpers.GetAreas(completedProjects, []);

        // Act
        var description = areas.First(a => a.Area == Area.StartHere).Description;

        // Assert
        Assert.That(description, Is.EqualTo("6 out of 6 tasks completed"));
    }

    [Test]
    public void GetAreas_StartHereDescriptionIsCorrect_WithoutFreeCodeCamp()
    {
        // Arrange
        var completedProjects = new List<int>
        {
            (int)ArticleName.StartHere,
            (int)ArticleName.GettingHelp,
            (int)ArticleName.SettingUp,
            (int)ArticleName.Foundations,
            (int)ArticleName.ImportanceOfConsole
        };

        var areas = DashboardProjectsHelpers.GetAreas(completedProjects, []);

        // Act
        var description = areas.First(a => a.Area == Area.StartHere).Description;

        // Assert
        Assert.That(description, Is.EqualTo("5 out of 6 tasks completed"));
    }

    [TestCase(new int[] { (int)ArticleName.Sql1, (int)ArticleName.Sql2, (int)ArticleName.Sql3 }
             , "3 out of 3 tasks completed")]
    [TestCase(new int[] { (int)ArticleName.Sql1, (int)ArticleName.Sql2 }
             , "2 out of 3 tasks completed")]
    public void GetAreas_SqlDescriptionIsCorrect(int[] completedProjects, string expected)
    {
        // Arrange
        var areas = DashboardProjectsHelpers.GetAreas(completedProjects.ToList(), []);

        // Act
        var description = areas.First(a => a.CardName == "SQL").Description;

        // Assert
        Assert.That(description, Is.EqualTo(expected));
    }

    [TestCase(new int[] { (int)ArticleName.Flagship }, "1 out of 1 tasks completed")]
    [TestCase(new int[] { }, "0 out of 1 tasks completed")]
    public void GetAreas_GraduationProjectDescriptionIsCorrect(int[] completedProjects, string expected)
    {
        // Arrange
        var areas = DashboardProjectsHelpers.GetAreas(completedProjects.ToList(), []);

        // Act
        var description = areas.First(a => a.CardName == "Flagship Project").Description;

        // Assert
        Assert.That(description, Is.EqualTo(expected));
    }

    [TestCase(new int[] { (int)ArticleName.MathGame, (int)ArticleName.Calculator, (int)ArticleName.HabitLogger, (int)ArticleName.CodingTracker }
             , "4 out of 4 tasks completed")]
    [TestCase(new int[] { (int)ArticleName.MathGame, (int)ArticleName.Calculator, (int)ArticleName.HabitLogger }
             , "3 out of 4 tasks completed")]
    public void GetAreas_BeginnerConsoleDescriptionIsCorrect(int[] completedProjects, string expected)
    {
        // Arrange
        var areas = DashboardProjectsHelpers.GetAreas(completedProjects.ToList(), []);

        // Act
        var description = areas.First(a => a.CardName == "Beginner Console").Description;

        // Assert
        Assert.That(description, Is.EqualTo(expected));
    }

    [TestCase(new int[] { (int)ArticleName.Flashcards, (int)ArticleName.Drinks, (int)ArticleName.PhoneBook, (int)ArticleName.ShiftsLogger }
             , "4 out of 4 tasks completed")]
    [TestCase(new int[] { (int)ArticleName.Flashcards, (int)ArticleName.Drinks, (int)ArticleName.PhoneBook }
            , "3 out of 4 tasks completed")]
    public void GetAreas_IntermediateConsoleDescriptionIsCorrect(int[] completedProjects, string expected)
    {
        // Arrange
        var areas = DashboardProjectsHelpers.GetAreas(completedProjects.ToList(), []);

        // Act
        var description = areas.First(a => a.CardName == "Intermediate Console").Description;

        // Assert
        Assert.That(description, Is.EqualTo(expected));
    }

    [TestCase(new int[] { (int)ArticleName.Ecommerce, (int)ArticleName.SportsResults, (int)ArticleName.ExcelReader, (int)ArticleName.UnitTesting }
             , "4 out of 4 tasks completed")]
    [TestCase(new int[] { (int)ArticleName.Ecommerce, (int)ArticleName.SportsResults, (int)ArticleName.ExcelReader }
             , "3 out of 4 tasks completed")]
    public void GetAreas_AdvancedConsoleDescriptionIsCorrect(int[] completedProjects, string expected)
    {
        // Arrange
        var areas = DashboardProjectsHelpers.GetAreas(completedProjects.ToList(), []);

        // Act
        var description = areas.First(a => a.CardName == "Advanced Console").Description;

        // Assert
        Assert.That(description, Is.EqualTo(expected));
    }

    [TestCase(new int[] { (int)ArticleName.TicTacToe, (int)ArticleName.ExternalApi, (int)ArticleName.ShoppingList, (int)ArticleName.FriendsManager }
             , "4 out of 4 tasks completed", "React")]
    [TestCase(new int[] { (int)ArticleName.TicTacToe, (int)ArticleName.ExternalApi, (int)ArticleName.ShoppingList }
             , "3 out of 4 tasks completed", "React")]
    [TestCase(new int[] { (int)ArticleName.Portfolio, (int)ArticleName.Resume }
             , "2 out of 2 tasks completed", "Start Applying")]
    [TestCase(new int[] { (int)ArticleName.Resume }, "1 out of 2 tasks completed", "Start Applying")]
    [TestCase(new int[] { (int)ArticleName.WaterLogger, (int)ArticleName.Movies, (int)ArticleName.TodoList, (int)ArticleName.Budget }
             , "4 out of 4 tasks completed", "ASP.NET Core MVC")]
    [TestCase(new int[] { (int)ArticleName.WaterLogger, (int)ArticleName.Movies, (int)ArticleName.TodoList }
             , "3 out of 4 tasks completed", "ASP.NET Core MVC")]
    public void GetAreas_OthersDescriptionIsCorrect(int[] completedProjects, string expected, string areaName)
    {
        // Arrange
        var areas = DashboardProjectsHelpers.GetAreas(completedProjects.ToList(), []);

        // Act
        var description = areas.First(a => a.CardName == areaName).Description;

        // Assert
        Assert.That(description, Is.EqualTo(expected));
    }
}
