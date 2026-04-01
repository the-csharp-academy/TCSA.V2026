using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using TCSA.V2026.Data.Helpers;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Helpers;

namespace TCSA.V2026.UnitTests.Helpers;

[TestFixture]
public class BeltTests
{
    #region requirements
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
    #endregion

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
    public void GreenNotCompleteShouldReturnWhite()
    {
        var result = RoadmapHelper.GetExpectedBelt(new List<int>(), 0, 0);
        Assert.That(result, Is.EqualTo("White"));
    }

    [Test]
    public void GreenCompleteShouldReturnGreen()
    {
        var result = RoadmapHelper.GetExpectedBelt([.. GreenRequirements], 0, 0);
        Assert.That(result, Is.EqualTo("Green"));
    }

    [Test]
    public void HabitCompletedShouldStillReturnGreen()
    {
        var result = RoadmapHelper.GetExpectedBelt(new List<int>
        (
            [.. GreenRequirements, (int)ArticleName.HabitLogger]
        ), 0, 0);
        Assert.That(result, Is.EqualTo("Green"));
    }

    [Test]
    public void CodingCompletedShouldStillReturnGreen()
    {
        var result = RoadmapHelper.GetExpectedBelt(new List<int>(
            [.. GreenRequirements, (int)ArticleName.HabitLogger, (int)ArticleName.CodingTracker]
        ), 0, 0);
        Assert.That(result, Is.EqualTo("Green"));
    }

    [Test]
    public void OliveGreenCompleteShouldReturnOliveGreen()
    {
        var result = RoadmapHelper.GetExpectedBelt(new List<int>(
            [.. GreenRequirements, .. OliveGreenRequirements]
        ), 0, 0);
        Assert.That(result, Is.EqualTo("OliveGreen"));
    }

    [Test]
    public void FlashcardsCompleteShouldReturnOliveGreen()
    {
        var result = RoadmapHelper.GetExpectedBelt(new List<int>(
            [.. GreenRequirements, .. OliveGreenRequirements, (int)ArticleName.Flashcards]
        ), 0, 0);
        Assert.That(result, Is.EqualTo("OliveGreen"));
    }

    [Test]
    public void DrinksCompleteShouldReturnOliveGreen()
    {
        var result = RoadmapHelper.GetExpectedBelt(new List<int>(
            [.. GreenRequirements, .. OliveGreenRequirements, (int)ArticleName.Flashcards, (int)ArticleName.Drinks]
        ), 0, 0);
        Assert.That(result, Is.EqualTo("OliveGreen"));
    }

    [Test]
    public void PhonebookCompleteShouldReturnOliveGreen()
    {
        var result = RoadmapHelper.GetExpectedBelt(new List<int>(
            [.. GreenRequirements, .. OliveGreenRequirements,
            (int)ArticleName.Flashcards, (int)ArticleName.Drinks, (int)ArticleName.PhoneBook]
        ), 0, 0);
        Assert.That(result, Is.EqualTo("OliveGreen"));
    }

    [Test]
    public void ShiftsCompleteShouldReturnYellow()
    {
        var result = RoadmapHelper.GetExpectedBelt(new List<int>(
            [.. GreenRequirements, .. OliveGreenRequirements, .. YellowRequirements]
        ), 0, 0);
        Assert.That(result, Is.EqualTo("Yellow"));
    }

    [Test]
    public void ExerciseCompleteShouldReturnYellow()
    {
        var result = RoadmapHelper.GetExpectedBelt(new List<int>(
            [.. GreenRequirements, .. OliveGreenRequirements, .. YellowRequirements, (int)ArticleName.Ecommerce]
        ), 0, 0);
        Assert.That(result, Is.EqualTo("Yellow"));
    }

    [Test]
    public void SportsCompleteShouldReturnYellow()
    {
        var result = RoadmapHelper.GetExpectedBelt(new List<int>(
            [.. GreenRequirements, .. OliveGreenRequirements, .. YellowRequirements,
            (int)ArticleName.Ecommerce, (int) ArticleName.SportsResults]
        ), 0, 0);
        Assert.That(result, Is.EqualTo("Yellow"));
    }

    [Test]
    public void ExcelCompleteShouldReturnYellow()
    {
        var result = RoadmapHelper.GetExpectedBelt(new List<int>
        (
            [..GreenRequirements, ..OliveGreenRequirements, ..YellowRequirements,
            (int)ArticleName.Ecommerce, (int)ArticleName.SportsResults, (int)ArticleName.ExcelReader]
        ), 0, 0);
        Assert.That(result, Is.EqualTo("Yellow"));
    }

    [Test]
    public void TestingCompleteShouldReturnOrange()
    {
        var result = RoadmapHelper.GetExpectedBelt(new List<int>(
            [.. GreenRequirements, .. OliveGreenRequirements, .. YellowRequirements, .. OrangeRequirements]
        ), 0, 0);
        Assert.That(result, Is.EqualTo("Orange"));
    }

    [Test]
    public void PortfolioCompleteShouldReturnOrange()
    {
        var result = RoadmapHelper.GetExpectedBelt(new List<int>(
            [.. GreenRequirements, .. OliveGreenRequirements, .. YellowRequirements, .. OrangeRequirements,
            (int)ArticleName.Portfolio]
        ), 0, 0);
        Assert.That(result, Is.EqualTo("Orange"));
    }

    [Test]
    public void ResumeCompleteShouldReturnOrange()
    {
        var result = RoadmapHelper.GetExpectedBelt(new List<int>(
            [.. GreenRequirements, .. OliveGreenRequirements, .. YellowRequirements, .. OrangeRequirements,
            (int) ArticleName.Resume]
        ), 0, 0);
        Assert.That(result, Is.EqualTo("Orange"));
    }

    [Test]
    public void OneReviewShouldReturnOrange()
    {
        var result = RoadmapHelper.GetExpectedBelt(new List<int>(
            [.. GreenRequirements, .. OliveGreenRequirements, .. YellowRequirements, .. OrangeRequirements,
            .. RedRequirements]
        ), 0, 1);
        Assert.That(result, Is.EqualTo("Orange"));
    }

    [Test]
    public void OneIssueShouldReturnOrange()
    {
        var result = RoadmapHelper.GetExpectedBelt(new List<int>(
            [.. GreenRequirements, .. OliveGreenRequirements, .. YellowRequirements, .. OrangeRequirements,
            .. RedRequirements]
        ), 1, 0);
        Assert.That(result, Is.EqualTo("Orange"));
    }

    [Test]
    public void OneIssueAndReviewShouldReturnOrange()
    {
        var result = RoadmapHelper.GetExpectedBelt(new List<int>(
            [.. GreenRequirements, .. OliveGreenRequirements, .. YellowRequirements, .. OrangeRequirements,
            .. RedRequirements]
        ), 1, 1);
        Assert.That(result, Is.EqualTo("Orange"));
    }

    [Test]
    public void OneIssueAndTwoReviewsShouldReturnRed()
    {
        var result = RoadmapHelper.GetExpectedBelt(new List<int>(
            [.. GreenRequirements, .. OliveGreenRequirements, .. YellowRequirements, .. OrangeRequirements,
            .. RedRequirements]
        ), 1, 2);
        Assert.That(result, Is.EqualTo("Red"));
    }

    [Test]
    public void TwoIssuesAndFourReviewsShouldReturnRed()
    {
        var result = RoadmapHelper.GetExpectedBelt(new List<int>(
            [.. GreenRequirements, .. OliveGreenRequirements, .. YellowRequirements, .. OrangeRequirements,
            .. RedRequirements]
        ), 2, 4);
        Assert.That(result, Is.EqualTo("Red"));
    }

    [Test]
    public void AspNetCoreCompleteShouldReturnPurple()
    {
        var result = RoadmapHelper.GetExpectedBelt(new List<int>(
            [.. GreenRequirements, .. OliveGreenRequirements, .. YellowRequirements, .. OrangeRequirements,
            .. RedRequirements, .. AspNetRequirements]
        ), 2, 4);
        Assert.That(result, Is.EqualTo("Purple"));
    }

    [Test]
    public void AspNetCoreCompleteButNotEnoughReviewsShouldReturnRed()
    {
        var result = RoadmapHelper.GetExpectedBelt(new List<int>(
            [.. GreenRequirements, .. OliveGreenRequirements, .. YellowRequirements, .. OrangeRequirements,
            .. RedRequirements, .. AspNetRequirements]
        ), 2, 3);
        Assert.That(result, Is.EqualTo("Red"));
    }

    [Test]
    public void AspNetCoreCompleteButNotEnoughIssuesShouldReturnRed()
    {
        var result = RoadmapHelper.GetExpectedBelt(new List<int>(
            [.. GreenRequirements, .. OliveGreenRequirements, .. YellowRequirements, .. OrangeRequirements,
            .. RedRequirements, .. AspNetRequirements]
        ), 1, 4);
        Assert.That(result, Is.EqualTo("Red"));
    }

    [Test]
    public void ReactCompleteShouldReturnPurple()
    {
        var result = RoadmapHelper.GetExpectedBelt(new List<int>(
            [.. GreenRequirements, .. OliveGreenRequirements, .. YellowRequirements, .. OrangeRequirements,
            .. RedRequirements, .. ReactRequirements]
        ), 2, 4);
        Assert.That(result, Is.EqualTo("Purple"));
    }

    [Test]
    public void AngularCompleteShouldReturnPurple()
    {
        var result = RoadmapHelper.GetExpectedBelt(new List<int>(
            [.. GreenRequirements, .. OliveGreenRequirements, .. YellowRequirements, .. OrangeRequirements,
            .. RedRequirements, .. AngularRequirements]
        ), 2, 4);
        Assert.That(result, Is.EqualTo("Purple"));
    }

    [Test]
    public void BlazorCompleteShouldReturnPurple()
    {
        var result = RoadmapHelper.GetExpectedBelt(new List<int>(
            [.. GreenRequirements, .. OliveGreenRequirements, .. YellowRequirements, .. OrangeRequirements,
            .. RedRequirements, .. BlazorRequirements]
        ), 2, 4);
        Assert.That(result, Is.EqualTo("Purple"));
    }

    [Test]
    public void MauiCompleteShouldReturnPurple()
    {
        var result = RoadmapHelper.GetExpectedBelt(new List<int>(
            [.. GreenRequirements, .. OliveGreenRequirements, .. YellowRequirements, .. OrangeRequirements,
            .. RedRequirements, .. MauiRequirements]
        ), 2, 4);
        Assert.That(result, Is.EqualTo("Purple"));
    }

    [Test]
    public void JumpingAroundShouldReturnRed()
    {
        var result = RoadmapHelper.GetExpectedBelt(new List<int>(
            [.. GreenRequirements, .. OliveGreenRequirements, .. YellowRequirements, .. OrangeRequirements,
            .. RedRequirements,
            (int) ArticleName.MauiMath, (int) ArticleName.Books, (int) ArticleName.Monkeys,
            (int) ArticleName.WardrobeInventory, (int) ArticleName.MemoryGame, (int) ArticleName.FoodJournal,
            (int) ArticleName.TourOfHeroes, (int) ArticleName.CoffeeTracker, (int) ArticleName.SleepTracker,
            (int) ArticleName.TicTacToe, (int) ArticleName.ExternalApi, (int) ArticleName.ShoppingList,
            (int) ArticleName.WaterLogger, (int) ArticleName.Movies, (int)ArticleName.TodoList]
        ), 2, 4);
        Assert.That(result, Is.EqualTo("Red"));
    }

    [Test]
    public void FCCMissingShouldReturnWhite()
    {
        var result = RoadmapHelper.GetExpectedBelt(new List<int>(
            [(int)ArticleName.StartHere, (int)ArticleName.GettingHelp, (int)ArticleName.SettingUp, (int)ArticleName.Foundations,
            (int)ArticleName.MathGame,
            .. OliveGreenRequirements,
            .. YellowRequirements,
            .. OrangeRequirements,
            .. RedRequirements,
            .. MauiRequirements,
            (int)ArticleName.WardrobeInventory, (int)ArticleName.MemoryGame, (int)ArticleName.FoodJournal,
            (int)ArticleName.TourOfHeroes, (int)ArticleName.CoffeeTracker, (int)ArticleName.SleepTracker,
            (int)ArticleName.TicTacToe, (int)ArticleName.ExternalApi, (int)ArticleName.ShoppingList,
            (int)ArticleName.WaterLogger, (int)ArticleName.Movies, (int)ArticleName.TodoList]
        ), 2, 4);
        Assert.That(result, Is.EqualTo("White"));
    }

    [Test]
    public void MathMissingShouldReturnWhite()
    {
        var result = RoadmapHelper.GetExpectedBelt(new List<int>(
            [(int)ArticleName.StartHere, (int)ArticleName.GettingHelp, (int)ArticleName.SettingUp, (int)ArticleName.Foundations,
            (int)ArticleName.FreecodeCamp,
            .. OliveGreenRequirements,
            .. YellowRequirements,
            .. OrangeRequirements,
            .. RedRequirements,
            .. MauiRequirements,
            (int)ArticleName.WardrobeInventory, (int)ArticleName.MemoryGame, (int)ArticleName.FoodJournal,
            (int)ArticleName.TourOfHeroes, (int)ArticleName.CoffeeTracker, (int)ArticleName.SleepTracker,
            (int)ArticleName.TicTacToe, (int)ArticleName.ExternalApi, (int)ArticleName.ShoppingList,
            (int)ArticleName.WaterLogger, (int)ArticleName.Movies, (int)ArticleName.TodoList]
        ), 2, 4);
        Assert.That(result, Is.EqualTo("White"));
    }

    [Test]
    public void AuthCompleteShouldReturnPurple()
    {
        var result = RoadmapHelper.GetExpectedBelt(new List<int>(
            [.. GreenRequirements, .. OliveGreenRequirements, .. YellowRequirements, .. OrangeRequirements,
            .. RedRequirements, .. MauiRequirements, .. AuthRequirements]
        ), 2, 4);
        Assert.That(result, Is.EqualTo("Purple"));
    }

    [Test]
    public void AuthCompleteShouldReturnBrown()
    {
        var result = RoadmapHelper.GetExpectedBelt(new List<int>(
            [.. GreenRequirements, .. OliveGreenRequirements, .. YellowRequirements, .. OrangeRequirements,
            .. RedRequirements, .. MauiRequirements, .. AuthRequirements]
        ), 5, 7);
        Assert.That(result, Is.EqualTo("Brown"));
    }

    [Test]
    public void SQLCompleteShouldReturnBrown()
    {
        var result = RoadmapHelper.GetExpectedBelt(new List<int>(
            [..GreenRequirements, ..OliveGreenRequirements, ..YellowRequirements, ..OrangeRequirements,
            ..RedRequirements, ..MauiRequirements, ..AuthRequirements, .. SqlRequirements]
        ), 5, 7);
        Assert.That(result, Is.EqualTo("Brown"));
    }

    [Test]
    public void NoFlagshipShouldReturnBrown()
    {
        var result = RoadmapHelper.GetExpectedBelt(new List<int>(
            [..GreenRequirements, ..OliveGreenRequirements, ..YellowRequirements, ..OrangeRequirements,
            ..RedRequirements, ..MauiRequirements, ..AuthRequirements, .. SqlRequirements]
        ), 7, 12);
        Assert.That(result, Is.EqualTo("Brown"));
    }

    [Test]
    public void FlagshipShouldReturnGrey()
    {
        var result = RoadmapHelper.GetExpectedBelt(new List<int>
        (
            [..GreenRequirements, ..OliveGreenRequirements, ..YellowRequirements, ..OrangeRequirements,
            ..RedRequirements, ..MauiRequirements, ..AuthRequirements, ..SqlRequirements,
            (int)ArticleName.Flagship]
        ), 7, 12);
        Assert.That(result, Is.EqualTo("Grey"));
    }

    [Test]
    public void AzureShouldReturnGrey()
    {
        var result = RoadmapHelper.GetExpectedBelt(new List<int>
        (
            [..GreenRequirements, ..OliveGreenRequirements, ..YellowRequirements, ..OrangeRequirements,
            ..RedRequirements, ..MauiRequirements, ..AuthRequirements, ..SqlRequirements, ..AzureRequirements,
            (int)ArticleName.Flagship]
        ), 7, 12);
        Assert.That(result, Is.EqualTo("Grey"));
    }

    [Test]
    public void AzureShouldReturnBlue()
    {
        var result = RoadmapHelper.GetExpectedBelt(new List<int>
        (
            [..GreenRequirements, ..OliveGreenRequirements, ..YellowRequirements, ..OrangeRequirements,
            ..RedRequirements, ..MauiRequirements, ..AuthRequirements, ..SqlRequirements, ..AzureRequirements,
            (int)ArticleName.Flagship]
        ), 10, 17);
        Assert.That(result, Is.EqualTo("Blue"));
    }

    [Test]
    public void TwoFullStacksShouldReturnBlue()
    {
        var result = RoadmapHelper.GetExpectedBelt(new List<int>
        (
            [..GreenRequirements, ..OliveGreenRequirements, ..YellowRequirements, ..OrangeRequirements,
            ..RedRequirements, ..MauiRequirements, ..AngularRequirements, ..AuthRequirements, ..SqlRequirements,
            ..AzureRequirements,
            (int)ArticleName.Flagship]
        ), 10, 17);
        Assert.That(result, Is.EqualTo("Blue"));
    }

    [Test]
    public void TwoFullStacksShouldReturnBlack()
    {
        var result = RoadmapHelper.GetExpectedBelt(new List<int>
        (
            [..GreenRequirements, ..OliveGreenRequirements, ..YellowRequirements, ..OrangeRequirements,
            ..RedRequirements, ..MauiRequirements, ..AngularRequirements, ..AuthRequirements, ..SqlRequirements,
            ..AzureRequirements,
            (int)ArticleName.Flagship]
        ), 15, 25);
        Assert.That(result, Is.EqualTo("Black"));
    }

    [TestCaseSource(nameof(FullStackAreaTestCases))]
    public void GetFullStackAreasCompletedReturnsExpectedAreas(List<int> completedProjects, List<Area> expectedAreas)
    {
        var result = RoadmapHelper.GetFullStackAreasCompleted(completedProjects);
        Assert.That(result, Is.EquivalentTo(expectedAreas));
    }

    private static IEnumerable<TestCaseData> FullStackAreaTestCases()
    {
        yield return new TestCaseData(AspNetRequirements.ToList(), new List<Area> { Area.MVC }).SetName("MVC only");
        yield return new TestCaseData(ReactRequirements.ToList(), new List<Area> { Area.React }).SetName("React only");
        yield return new TestCaseData(AngularRequirements.ToList(), new List<Area> { Area.Angular }).SetName("Angular only");
        yield return new TestCaseData(BlazorRequirements.ToList(), new List<Area> { Area.Blazor }).SetName("Blazor only");
        yield return new TestCaseData(MauiRequirements.ToList(), new List<Area> { Area.MAUI }).SetName("MAUI only");
        yield return new TestCaseData(
            new List<int>([.. AspNetRequirements, .. ReactRequirements]), new List<Area> { Area.MVC, Area.React }).SetName("MVC and React");
        yield return new TestCaseData(new List<int>(), new List<Area>()).SetName("None completed");
    }
}