using MudBlazor;
using TCSA.V2026.Data.Enums;

namespace TCSA.V2026.Data.Models;

public class Article
{
    public int Id { get; set; }
    public ArticleReference Reference { get; set; }
    public int ExperiencePoints { get; set; }
    public int? CourseDisplayId { get; set; }
    public string Title { get; set; }
    public string Slug { get; set; }
    public string Description { get; set; }
    public string IconUrl { get; set; }
    public string BannerUrl { get; set; }
    public string BannerV2 { get; set; }
    public string NextSlug { get; set; }
    public string CardImgUrl { get; set; }
    public string Author { get; set; }
    public string? Url { get; set; }
    public bool IsClosed { get; set; }
    public Area Area { get; set; }
    public Level Level { get; set; }
    public DateTime ReleaseDate { get; set; } // TODO move this to project
    public List<Block> Blocks { get; set; }
}

public class Block
{
    public bool IsCourseCodePage {  get; set; }
    public string? Title { get; set; }
    public string? ImgUrl { get; set; }
    public string? BookImgUrl { get; set; }
    public List<Paragraph> Paragraphs { get; set; }
    public List<MudText> MudParagraphs { get; set; }
}

public class Paragraph
{
    public string? FontColor { get; set; }  
    public string? BackgroundColor { get; set; }
    public string? PictureUrl { get; set; }
    public string? VideoUrl { get; set; }
    public string? Body { get; set; }
    public bool IsPicture { get; set; } = false;
    public bool IsVideo { get; set; } = false;
    public bool IsCode { get; set; } = false;

}

public enum Area
{
    HowItWorks,
    StartHere,
    Console,
    StartApplying,
    MVC,
    Angular,
    React,
    Blazor,
    MAUI,
    Azure,
    FullStack,
    StandAlone,
    OpenSource,
    MonthlyChallenge,
    SQL,
    Auth,
    GraduationProject,
    FreestyleProject,
    Blog, 
    Principles, 
    Course,
    Docker
}

public enum ArticleName
{
    StartHere = 5,
    GettingHelp = 6,
    SettingUp = 7,
    Foundations = 8,
    ImportanceOfConsole = 9,

    FreecodeCamp = 75,
    MathGame = 53,
    Calculator = 11,
    HabitLogger = 12,
    CodingTracker = 13,

    Flashcards = 14,
    Drinks = 15,
    PhoneBook = 16,
    ShiftsLogger = 17,

    Ecommerce = 18,
    SportsResults = 19,
    ExcelReader = 20,
    UnitTesting = 21,

    Portfolio = 22,
    Resume = 23,

    WaterLogger = 24,
    Movies = 25,
    TodoList = 26,
    Budget = 27,

    TourOfHeroes = 31,
    CoffeeTracker = 32,
    SleepTracker = 33,
    Quizgame = 34,

    TicTacToe = 35,
    ExternalApi = 36, 
    ShoppingList = 37, 
    FriendsManager = 38,

    WardrobeInventory = 39,
    MemoryGame = 40, 
    FoodJournal = 41, 
    SportsStatistics = 42, 

    MauiMath = 43,
    Books = 44,
    Monkeys = 45, 
    Warehouse = 46,

    Auth = 28,
    ProductManagement = 72,
    ExternalAuth = 74,
    Auth0 = 100004,

    Sql1 = 76, 
    Sql2 = 77, 
    Sql3 = 78,

    DeploySimpleApp = 47,
    DeployFullStack = 48,
    DeployFramework = 49,
    AzureFunctions = 100000,

    BreweryApi = 64,
    Flagship = 139,
    BuildAGame = 100003,

    DockerIntro = 100002,

    ConsoleGraduation = 10,
    Roadmap = 51,
    SubmitCodeReviews = 52,
    PeerReviews = 57,
    CodeConventions = 58,
    IntroGuide = 20000,

    SeparationOfConcerns = 30005,

    CoursesOopFirst = 500000,
    CoursesOopLast = 500025,
    CoursesWebApiFirst = 500050,
    CoursesWebApiLast = 500063,
    CoursesSQLFirst = 500070,
    CoursesSQLLast = 500086,
    CoursesWpfFirst = 500100, 
    CoursesWpfLast = 500116,
    CoursedDIFirst = 500150,
    CoursesDILast = 500161,
    CoursesReactFirst = 500200
}

public enum ArticleReference
{
    StartFromScratch = 1,
    LearnByDoing = 2,
    CommunityBased = 3,
    GetJobReady = 4,
    StartHere = 5,
    GettingHelp = 6,
    SettingUp = 7,
    Foundations = 8,
    ImportanceOfConsole = 9,
    ConsoleGraduation = 10,
    Roadmap = 51,
    SubmitCodeReviews = 52,
    PeerReviews = 57,
    CodeConventions = 58,
    IntroGuide = 20000,
    SeparationOfConcerns = 30005,
    DryPrinciple = 30006,
    DotnetNames = 30007,
    ContributingToAcademy = 30008,
    UnitTesting = 30009,
    AccountabilityBuddy = 30010
}
