using TCSA.V2026.Data.Models;

namespace TCSA.V2026.Helpers;
public enum GithubRepository : long
{
    MathGame = 587597495,
    Calculator = 595782828,
    HabitLogger = 595789853,
    CodingTracker = 573911543,
    Flashcards = 573911617,
    Drinks = 573911726,
    PhoneBook = 573911920,
    ShiftsLogger = 573912212,
    Ecommerce = 573912286,
    SportsResults = 675864949,
    ExcelReader = 573912431,
    UnitTesting = 573912512,
    
    WaterLogger = 588421551,
    Movies = 574254791,
    TodoList = 574088282,
    Budget = 576746593
}
public static class GithubHelper
{
    private static readonly Dictionary<GithubRepository, int> RepoToArticleMap = new()
    {
        { GithubRepository.MathGame, (int)ArticleName.MathGame },
        { GithubRepository.Calculator, (int)ArticleName.Calculator },
        { GithubRepository.HabitLogger, (int)ArticleName.HabitLogger },
        { GithubRepository.CodingTracker, (int)ArticleName.CodingTracker },
        { GithubRepository.Flashcards, (int)ArticleName.Flashcards },
        { GithubRepository.Drinks, (int)ArticleName.Drinks },
        { GithubRepository.PhoneBook, (int)ArticleName.PhoneBook },
        { GithubRepository.ShiftsLogger, (int)ArticleName.ShiftsLogger },
        { GithubRepository.Ecommerce, (int)ArticleName.Ecommerce },
        { GithubRepository.SportsResults, (int)ArticleName.SportsResults },
        { GithubRepository.ExcelReader, (int)ArticleName.ExcelReader },
        { GithubRepository.UnitTesting, (int)ArticleName.UnitTesting },
        { GithubRepository.WaterLogger, (int)ArticleName.WaterLogger },
        { GithubRepository.Movies, (int)ArticleName.UnitTesting },
        { GithubRepository.TodoList, (int)ArticleName.TodoList },
        { GithubRepository.Budget, (int)ArticleName.Budget },
    };

    public static int GetProjectId(long repositoryId)
    {
        var projectId = 0;
        if (!Enum.IsDefined(typeof(GithubRepository), repositoryId))
        {
            return 0;
        }

        var repo = (GithubRepository)repositoryId;
        if (!RepoToArticleMap.TryGetValue(repo, out projectId))
        {
            return 0;
        }

        return projectId;
    }
}
