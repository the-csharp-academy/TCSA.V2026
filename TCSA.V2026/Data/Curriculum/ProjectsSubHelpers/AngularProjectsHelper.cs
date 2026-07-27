using TCSA.V2026.Data.Models;
using TCSA.V2026.Data.Models.LanguageModels;
using TCSA.V2026.Helpers;

namespace TCSA.V2026.Data.Helpers.ProjectsSubHelpers;

internal static class AngularProjectsHelper
{
    private static readonly IConfiguration Configuration;
    private static readonly string DiscordLink;

    static AngularProjectsHelper()
    {
        Configuration = ServiceProviderAccessor.ServiceProvider.GetService<IConfiguration>();
        DiscordLink = Configuration["LinkProvider:DiscordLink"];
    }

    internal static List<Project> GetProjects()
    {
        return new List<Project>
        {
            new Project
            {
                Id = 31,
                Title = "Real Estate App",
                IconUrl = "icons8-real-estate-100.png",
                BannerUrl = "pexels-binyaminmellish-1396132.jpg",
                LanguageHeadings = new EnglishHeadings(),
                Slug = "Real Estate App",
                Description = "Learn the basics of Angular by building a purely front-end app using the documentation",
                Area = Area.Angular,
                ExperiencePoints = 50,
                Difficulty = Difficulty.Beginner,
                RepositoryLink = "https://github.com/TheCSharpAcademy/CodeReviews.Angular.HomesApp",
                Introduction = new List<Paragraph>
                {
                    new Paragraph
                    {
                        Body="Welcome to the world of front-end frameworks! You should be excited, you’re about to take your first step in learning one of most required technologies of our time. Most job applications require knowledge of a Javascript front-end solutions, tried and tested tools for building scalable, interactive web applications."
                    },
                    new Paragraph
                    {
                        Body="Ideally, prior to learning a complex front-end framework, you'd have basic knowledge of HTML, CSS and Javascript. We are providing resources for these in the resources area. If, however, you decide to jump straight into Angular, no big deal. It's still possible, since this is an <b>'opinionated'</b> framework, meaning it offers straight-out-of-the-box solutions for common web-development problems. Just keep in mind that to get to a truly advanced level in Angular, you'll have to close knowledge gaps later in your journey."
                    },
                    new Paragraph
                    {
                        Body="When learning JS Frameworks, be it Angular, React, Vue, Svelte, there’s a fair amount of complexity and the learning curve is definitely steep. So be patient, you won’t become an expert overnight. However, these frameworks are very welcoming to beginners. Building simple apps with them is somewhat straightforward, so be careful not to get caught into unnecessary complexities early on. We'll start by building a simple app without a back end, and progressively increase the difficulty up to a comprehensive full-stack app. 🤩"
                    }
                },
                RequirementsIntro="From Angular’s documentation page: 'The lessons in this tutorial create an Angular app that lists houses for rent and shows the details of individual houses. This app uses features that are common to many Angular apps.'",
                Requirements = new List<string>
                {
                    "This project has only one requirement: You should complete the \"Home's\" app in Angular's documentation page."
                },
                ResourcesIntro = "Angular uses Typescript. If you decide you want to jump straight onto Angular, but don't have Typescript experience, we recommend you go to the third last link, which gives you a quick intro to this flavour of Javascript. Once that is finished you can do the tutorial in the two last links, which are a quick intro to Angular, followed by the Home's App mentioned in the requirements above. ",

                Resources = new List<string>
                {
                    "<a target='_blank' href='https://www.youtube.com/watch?v=p0bGHP-PXD4'>HTML + CSS Crash Course.</a>",
                    "<a target='_blank' href='https://www.youtube.com/watch?v=hdI2bqOjy3c&t=5493s'>Javascript Crash Course</a>",
                    "<a target='_blank' href='https://www.youtube.com/watch?v=0ik6X4DJKCc'>Javascript DOM Manipulation - Part 1</a>",
                    "<a target='_blank' href='https://www.youtube.com/watch?v=mPd2aJXCZ2g'>Javascript DOM Manipulation - Part 2</a>",
                    "<a target='_blank' href='https://www.youtube.com/watch?v=BCg4U1FzODs'>Typescript crash course</a>",
                    "<a target='_blank' href='https://angular.dev/tutorials/learn-angular'>Learn Angular in Your Browser</a>",
                    "<a target='_blank' href='https://angular.dev/tutorials/first-app'>Angular Docs: Tour of Heroes Beginner’s Tutorial</a>"
                },
                ResourcesConclusion = "Since this is your first Angular project, we will keep it very simple. There won’t be any .NET or C# this time, you’ll focus on Angular only. And the documentation will provide everything you need for your first application.",
                Tips = new List<string>
                {
                    "If you haven't seen any HTML before we highly recommend you go through the HTML + CSS crash course first, or you'll end up getting lost.",
                    "Don't rush, everything here will be new, so take your time to understand each line of code.",
                    "Make notes. There are three major types of notes you can take: 1. Lists of steps to build things; 2. Concepts you're first learning about; 3. Things you find interesting and likely to use in the future. Keep your notes short.",
                    "If you feel you didn't retain much, you could redo the app and/or modify it and/or create a different app based on the gained knowledge. Tweaking projects goes a long way for content retention."
                }
            },
            new Project
            {
                Id = 32,
                Title = "Coffee Tracker",
                IconUrl = "icons8-coffee-mug-128.png",
                BannerUrl = "pexels-apgpotr-683039.jpg",
                LanguageHeadings = new EnglishHeadings(),
                Slug = "Coffee Tracker",
                Description = "Track your coffee consumption with a C# Web Api and Angular",
                Area = Area.Angular,
                Difficulty = Difficulty.Beginner,
                ExperiencePoints = 50,
                RepositoryLink = "https://github.com/TheCSharpAcademy/CodeReviews.Angular.CoffeeTracker",
                Introduction = new List<Paragraph>
                {
                    new Paragraph
                    {
                        Body="Now that you’re familiar with Angular, let’s combine it with .NET! And what a powerful combination that is. The limit of what you can build using these two is only the limit of your imagination. We will be creating two separate applications: An Angular front-end and an ASP.NET Core Web Api. The front-end will call the api, similarly to what you’ve done before in our Shifts Logger project."
                    }
                },
                Requirements = new List<string>
                {
                    "This is an application where you should record sales in a coffee shop.",
                    "You can choose a different type of shop, if you're not a coffee person 🤓.",
                    "You should create two projects: A.NET WebApi and an Angular app.",
                    "You should have a filter functionality, so users can select records per date.",
                    "Make sure validation is user-friendly so the users know exactly what's wrong with their input."
                },
                Resources = new List<string>
                {
                    "<a target='_blank' href='https://www.itsolutionstuff.com/post/angular-12-crud-application-tutorial-exampleexample.html'>Angular CRUD Tutorial</a>",
                    "<a target='_blank' href='https://www.youtube.com/watch?v=S5dzfuh3t8U'>Angular + C# Web Api Youtube Tutorial</a>",
                    "<a target='_blank' href='https://stackoverflow.com/questions/65082452/cors-is-not-working-with-net-core-api-and-angular-frontend'>Dealing With CORS (Cross Origin Resource Sharing)</a>"
                },
                ResourcesConclusion = $"Since this is your first full-stack Angular project, make sure you look up everything you don’t know. Try not to let any keyword, method or concept left-behind. This is the moment to build your foundation. And don’t forget to reach out on our <a  target='_blank' href='{DiscordLink}'>Discord community</a> if you have questions!",
                Tips = new List<string>
                {
                    "Angular has changed quite a bit over the years. Make sure you follow the latest documentation and tutorials, otherwise you might end up learning deprecated ways of doing things.",
                    "Your main objective is to call your API from the Angular App. Everything else is just moving data around and styling.",
                    "There are two ways to approach the construction of this app: Finishing the API first and then building the UI, or building each method end-to-end (ex: GetRecords method in the back-end plus list of records in the front-end). Choose one and stick to it.",
                    "We suggest you don't use UI libraries (such as Angular Material) in this project. Angular alone can be challenging enough and adding a rich library early on might overwhelm you. Also, you'll appreciate Angular Material more if you built applications without it first."
                },
                Challenges = new List<string>
                {
                    "Can you add integration with a real coffee api?",
                    "Enhance your app with other types of products sold in a cafe. 🍰",
                    "If you're comfortable with Angular, add complexity to your ecommerce with more entities: Products, Employees, Orders, Stock"
                }
            },
            new Project
            {
                Id = 33,
                Title = "Sleep Tracker",
                IconUrl = "icons8-sleeping-512.png",
                BannerUrl = "pexels-whitedragonflymedia-1716753.jpg",
                LanguageHeadings = new EnglishHeadings(),
                Slug = "sleep-tracker",
                Description = "Build on your Angular foundation with an app to log and generate reports about your sleep",
                Area = Area.Angular,
                ExperiencePoints = 50,
                Difficulty = Difficulty.Beginner,
                RepositoryLink = "https://github.com/TheCSharpAcademy/CodeReviews.Angular.SleepTracker",
                Introduction = new List<Paragraph>
                {
                    new Paragraph
                    {
                        Body="Your second Angular project has the objective of solidifying the knowledge you gained from the Coffee Tracker. Even though Angular is a beginner-friendly framework, it’s still a lot to take in, and if you’re coming from a C# background, there are a few things to get used to. But don’t worry! You will still be challenged. We’re building on the first project with two extra challenges."
                    },
                     new Paragraph
                    {
                        Body="In this project you’ll log data about your sleep, either manually inputting your time in bed or using a timer to automatically log it. Dealing with time is always a challenge and great practice. Also, you’ll be using Angular Material, a powerful UI component library ubiquitous in enterprise Angular projects. This is a massive library that does take some time to learn, but once you master it, it becomes extremely easy to build interesting and great-looking UI components. You’ll be saying goodbye to Bootstrap! "
                    }
                },
                Requirements = new List<string>
                {
                    "This is an application where you should record sleep time.",
                    "You should create two projects: An ASP.NET Core/EntityFramework WebApi and an Angular app.",
                    "You need to use Angular Material.",
                    "You should have a filter functionality, so I can show records per type and or date.",
                    "Your database should have a single 'Records' table.The objective is to focus on Angular, so we should avoid the complexities of relational data.",
                    "This app needs to have a timer that will log your sleep once stopped and saved.",
                    "Users should also be able to input their sleep time using a form.",
                    "Every action performed in the app should prompt a 'Toast' notification indicating success or failure.",
                    "Your list of sleep records should have pagination, so you're not loading all records every time you visualise the list.",
                    "This app should be mobile-first, since realistically , most users will use it from their phones.",
                    "Your app should contain integration tests for the services that are interacting with the database, and unit tests where you find applicable.",
                    "Your repository should contain a Postman collection with all endpoints documented for easy testing."
                },
                Resources = new List<string>
                {
                    "<a target='_blank' href='https://material.angular.io/'>Angular Material Docs</a>",
                    "<a target='_blank' href='https://material.angular.io/guide/getting-started'>Getting Started With Angular Material</a>",
                    "<a target='_blank' href='https://www.youtube.com/watch?v=jGbP620NahE'>Angular Material CRUD Tutorial</a>"
                },
                ResourcesConclusion = $"Angular Material can be tricky at first, but trust us, you’ll learn to love it and once you master it, you will never look back. But as always, reach out in our <a  target='_blank' href='{DiscordLink}'>Discord community</a> if you get stuck!",
                Tips = new List<string>
                {
                    "When building your timer, I suggest you have a pause, play, stop and save buttons for better user experience.",
                    "If you get stuck implementing Angular Material in your project, take a step back and build a couple of simple purely front-end projects from Youtube tutorials.",
                    "Since tests are part of the requirements, we suggest you write the tests as you go, instead of leaving it to the end. The tests will help you write more clean and maintainable code and it can be hard (technically and psychologically) to refactor your web api after it's finished."
                }
            },
            new Project
            {
                Id = 34,
                Title = "Quiz Game",
                IconUrl = "icons8-quiz-game-contestants-480.png",
                BannerUrl = "angular-quiz-banner.png",
                LanguageHeadings = new EnglishHeadings(),
                Slug = "quiz-game",
                Description = "Build a highly interactive Quiz Game with Angular and Angular Material",
                Area = Area.Angular,
                Difficulty = Difficulty.Beginner,
                ExperiencePoints = 100,
                RepositoryLink = "https://github.com/TheCSharpAcademy/CodeReviews.Angular.QuizGame",
                Introduction = new List<Paragraph>
                {
                    new Paragraph
                    {
                        Body="Now you’ve completed two projects with Angular and hopefully you’re starting to get comfortable with it. This next project will have a slightly more complex design and will stimulate your creativity while reinforcing your knowledge of Angular. We’ll once again practice a more complex data relationship scenario. This project will keep you busy for a while, but you’ll learn a lot from it. "
                    }
                },
                Requirements = new List<string>
                {
                    "This is an application where you will create and play quiz games.",
                    "The app should contain two main areas: one for management of quizzes and one for playing the games.",
                    "The relationship between questions and quizzes should be a many-to-many. Questions could be part of many quizzes.",
                    "You should create two projects: An ASP.NET Core WebApi and an Angular app.",
                    "You should use Entity Framework.",
                    "Your app needs to support multiple users.",
                    "Your UI needs to have a vibrant color scheme.",
                    "You need to secure your application so that users have to register and login to use it.",
                },
                Resources = new List<string>
                {
                    "<a href='https://blog.devart.com/types-of-relationships-in-sql-server-database.html#:~:text=So%2C%20what%20is%20one%2Dto,one%20record%20in%20table%201.'>Relationships in SQL</a>",
                    "<a href='https://www.entityframeworktutorial.net/code-first/configure-one-to-many-relationship-in-code-first.aspx'>One-to-many relationship Entity Framework</a>",
                    "<a href='https://material.angular.io/components/table/overview'>Tables and Pagination in Angular Material</a>"
                },
                ResourcesIntro = "The resourced from the previous Angular projects can be used for the completion of this project, plus these: ",
                Tips = new List<string>
                {
                    "Plan your database scheme carefully. Many-to-many relationships can get tricky if not well thought out.",
                    "This project has loose design requirements, so search for quiz game designs on Google for inspiration, when you're planning your app.",
                    "Try to work with a couple of UI elements you haven't used before, for practice. In Angular Material's Documentation, if you click on Components, you'll see a large list of components on the left side of the screen. Grab one or two that you think can fit the project.",
                    "This is a very strong portfolio project, so make sure you pay attention to details, don't leave any stone unturned and ask for feedback in our community."
                },
                Challenges = new List<string>
                {
                    "Integrate with Stripe and make it so that users can only create three quizzes for free. Any more than that, they'll need to purchase a subscription.",
                    "Add multi-player support so users can play against each other online."
                }
            },
        };
    }
}