using TCSA.V2026.Data.Enums;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Data.Models.LanguageModels;
using TCSA.V2026.Helpers;

namespace TCSA.V2026.Data.Helpers.ProjectsSubHelpers;

public class ConsoleProjectsHelper
{
    private static readonly IConfiguration Configuration;
    private static readonly string DiscordLink;

    static ConsoleProjectsHelper()
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
                Id = 53,
                Title = "Math Game",
                IconUrl = "icons8-maths-376.png",
                BannerUrl = "math-banner.jpg",
                BannerV2 = "mathgame",
                LanguageHeadings = new EnglishHeadings(),
                Slug = "math-game",
                Description = "In your first project, you’ll create a math game to reinforce what you've learned in the Foundations area",
                Area = Area.Console,
                Level = Level.Green,
                ExperiencePoints = 10,
                Difficulty = Difficulty.Beginner,
                DisplayOrder= 1,
                RepositoryLink = "https://github.com/the-csharp-academy/CodeReviews.Console.MathGame",
                Introduction = new List<Paragraph>
                {
                    new Paragraph
                    {
                        Body="In your first project you’ll build a very simple Math Game app. If this is your first time building a project indepentently, I recommend making use of the C# Academy's <a target='blank' href='https://www.youtube.com/watch?v=YUc5NZZVtjA&list=PL4G0MUH8YWiD1p5ySamqNWAaWlnwp1Vip'> series from our C# Foundation area</a>.This series will guide you through the process of creating a console app from the ground up, while explaining crucial C# concepts. If you have already watched it, or if you have prior experience creating C# applications, this project will be a breeze. But it’s still helpful to reinforce your knowledge."
                    },
                    new Paragraph
                    {
                        Body="You'll find challenges at the end of this project and all other projects in The C# Academy. These challenges aren't requirements. Your project will still be approved and you'll gain the correspondent experience points. However, the challenges will reinforce what you've learned. Although you might not get extra points for completing them, you'll become a better developer each time you finish a challenge."
                    }
                },
                Requirements = new List<string>
                {
                    @"You need to create a game that consists of asking the player what's the result of a math question (i.e. 9 x 9 = ?), collecting the input and adding a point in case of a correct answer.",
                    @"A game needs to have at least 5 questions.",
                    @"The divisions should result on INTEGERS ONLY and dividends should go from 0 to 100. Example: Your app shouldn't present the division 7/2 to the user, since it doesn't result in an integer.",
                    @"Users should be presented with a menu to choose an operation",
                    @"You should record previous games in a List and there should be an option in the menu for the user to visualize a history of previous games.",
                    @"You don't need to record results on a database. Once the program is closed the results will be deleted."
                },
                Resources = new List<string>
                {
                    "<a target='_blank' href='https://www.youtube.com/watch?v=iLByqqLGYEc&list=PL4G0MUH8YWiD1p5ySamqNWAaWlnwp1Vip'>Math Game Tutorial with Visual Studio</a>",
                    "<a target='_blank' href='https://www.youtube.com/watch?v=nnDNeJX-uBE'>Math Game Tutorial with Visual Studio Code</a>",
                },
                ResourcesIntro = "If you have previous C# experience, you might be able to complete this project without any help. If you don't, here are two tutorials you can follow if you get stuck. The first is using Visual Studio and not only creates a console app, but also a Desktop version, using .NET MAUI. The second uses Visual Studio Code and might be more suitable if you prefer it or don't have access to Visual Studio. ",
                ResourcesConclusion = "You don't need to watch the second part of this tutorial (Building a .NET Maui app), to complete this project. Only the Console App is required",
                Tips = new List<string>
                {
                    "Don't forget to ALWAYS, I mean ALWAYS have your code saved on Github (or whatever source control you use). This way you won't lose your work, and you can always refer back to it in the future. You're building a library of your own!",
                    "Don't rush through the steps, even if this tutorial is easy for you. Make sure you understand EACH WORD of the code. Leave no stone unturned.",
                    "If there's anything you don't understand, hover over the code, and you'll get an explanation of what the term means. If you still can't understand it, google is your best friend. You'll find explanations about pretty much everything in forums like stackoverflow.com.",
                    "If this is your first project, I recommend doing it twice. You'll be surprised at how much your retention increases, and how many gaps were left in the first time.",
                    $"Upon completion of your project, go to our <a target='_blank' href='{DiscordLink}'>Discord community</a> and brag about it! It's a very important step to complete a project and you should celebrate."
                },
                Challenges = new List<string>
                {
                    "Try to implement levels of difficulty.",
                    "Add a timer to track how long the user takes to finish the game.",
                    "Create a 'Random Game' option where the players will be presented with questions from random operations",
                    "To follow the <a href='/article/30006/dry-principle-csharp' target='_blank'>DRY Principle</a>, try using just one method for all games. Additionally, double check your project and try to find opportunities to achieve the same functionality with less code, avoiding repetition when possible."
                },
                Blocks = new List<Block>
                {
                    new Block
                    {
                        Title = "Source Control",
                        ImgUrl = "icons8-git-96.png",
                        Paragraphs = new List<Paragraph>
                        {
                            new Paragraph
                            {
                                Body = "If this is your first tutorial, you might be tempted to skip this step and start coding. Don’t do it or you’ll learn the hard way. One day after working for many hours on a difficult problem you won’t save your work on a source control repository and for whatever reason all of it will be lost."
                            },
                            new Paragraph
                            {
                                Body = "Get into the habit of saving every line of code you ever write. I promise it will save you from many headaches. All serious developers save their work on a backup repository. The most commonly used is Github. Create an account if you haven’t yet. "
                            },
                            new Paragraph
                            {
                                Body="1. In Visual Studio, go to Git > Create Git Repository<br>2. Enter your Login Details<br>3. Click on Create and Push. "
                            },
                            new Paragraph
                            {
                                Body="✅ Done! Your repository is good to go. Don’t forget to commit and push your changes after every step!"
                            }, new Paragraph
                            {
                                Body="You can take further step and learn how to integrate Github with Visual Studio watching this tutorial:"
                            },
                            new Paragraph
                            {
                                IsVideo = true,
                                VideoUrl = "https://www.youtube.com/embed/oCvb-Q5lXb8"
                            }
                        }
                    },
                    new Block
                    {
                        Title = "Code Review",
                        ImgUrl= "icons8-code-review-64.png",
                        Paragraphs = new List<Paragraph>
                        {
                            new Paragraph
                            {
                                Body = "If you want your code to be reviewed by a member of the C# Academy, instead of creating your own repository, <a href='article/52/code-reviews' target='blank'>follow this article</a>, where you’ll learn how to create a fork from our base review repository."
                            }
                        }
                    },
                }
            },
             new Project
            {
                Id = 11,
                Title = "Calculator",
                IconUrl = "icons8-calculator-512.png",
                Slug = "calculator",
                BannerUrl = "pexels-ian-panelo-5491023.jpg",
                BannerV2 = "calculator",
                LanguageHeadings = new EnglishHeadings(),
                Level = Level.OliveGreen,
                Description = "This you’ll create a calculator with the help of Microsoft's Documentation",
                Area = Area.Console,
                Difficulty = Difficulty.Beginner,
                ExperiencePoints = 10,
                DisplayOrder = 2,
                RepositoryLink = "https://github.com/the-csharp-academy/CodeReviews.Console.Calculator",
                Introduction = new List<Paragraph>
                {
                    new Paragraph
                    {
                        Body="For your second project you'll build a Console Calculator App with the help of Microsoft’s Documentation. This project shouldn't be more difficult than the first, but you'll learn important skills such as having multiple projects in a solution, writing to files, and debugging. It will also serve as practice in a very important skill: following written documentation. This is something you’ll be doing on a regular basis as a professional developer, so it’s essential that you’re comfortable applying text-based instructions when developing software."
                    }
                },
                Requirements = new List<string>
                {
                    @"Complete the following tutorial (parts 1 and 2): <a href='https://docs.microsoft.com/en-us/visualstudio/get-started/csharp/tutorial-console?view=vs-2022'>Create a Calculator App (Microsoft Docs)</a>. You can find a link to part two at the bottom of the page."
                },
                RequirementsIntro = "This project has only one requirement:",
                Resources = new List<string>
                {
                    "<a href='https://docs.microsoft.com/en-us/dotnet/core/tutorials/with-visual-studio-mac'>Visual Studio For Mac</a>",
                    "<a href='https://docs.microsoft.com/en-us/dotnet/core/tutorials/with-visual-studio-code?pivots=dotnet-6-0'>Visual Studio Code</a>"
                },
                ResourcesIntro = "The instructions for this project are based on Visual Studio for Windows. The code you will write will be the same regardless of the code editor, but the process of creating a new project will differ. Here are links about how to create a console app with different editors: ",
                Tips = new List<string>
                {
                    "Don't rush through the steps, even if this tutorial is easy for you. Make sure you understand EACH WORD of the code. Leave no stone unturned.",
                    "If there's anything you don't understand, hover over the code, and you'll get an explanation of what the term means. If you still can't understand it, google and chat gpt are your best friends. And you can find thorough explanations about pretty much everything in forums like stackoverflow.com.",
                    "Don't skip the debugging section in Part II. This is one of the most important skills you'll learn in this tutorial and it will be vital for future projects."
                },
                 Challenges = new List<string>
                {
                    "Create a functionality that will count the amount of times the calculator was used.",
                    "Store a list with the latest calculations. And give the users the ability to delete that list.",
                    "Allow the users to use the results in the list above to perform new calculations.",
                    "Add extra calculations: Square Root, Taking the Power, 10x, Trigonometry functions.",
                },
                 Blocks = new List<Block>
                {
                     new Block
                    {
                        Title = "AI Challenge",
                        ImgUrl= "icons8-artificial-intelligence-64.png",
                        Paragraphs = new List<Paragraph>
                        {
                            new Paragraph
                            {
                                Body = "This is a slightly more advanced project but it taps into the future of programming: Artificial intelligence. Can you make it so the users can make calculations using their voice? For this you'll use Azure's Language Services. You can find a step-by-step tutorial below:"
                            },
                            new Paragraph
                            {
                                IsVideo = true,
                                VideoUrl = "https://www.youtube.com/embed/XMJS-eQ4Y48?si=Bwbn0UZUe-thB8md"
                            }
                        }
                    },
                    new Block
                    {

                        Title = "Code Review",
                        ImgUrl= "icons8-code-review-64.png",
                        Paragraphs = new List<Paragraph>
                        {
                            new Paragraph
                            {
                                Body = "If you want your code to be reviewed by a member of the C# Academy, instead of creating your own repository, <a href='article/52/code-reviews' target='blank'>follow this article</a>, where you’ll learn how to create a fork from our base review repository."
                            }
                        }
                    }
                }

            },
             new Project
            {
                Id = 12,
                Title = "Habit Logger",
                IconUrl = "icons8-calendar-plus-96.png",
                BannerUrl = "pexels-polina-kovaleva-5717413.jpg",
                LanguageHeadings = new EnglishHeadings(),
                Slug = "habit-logger",
                Description = "Build a logger for a habit of choice. Learn how to interact with a database using SQLite and to get and validate user input",
                Area = Area.Console,
                Level = Level.OliveGreen,
                ExperiencePoints = 10,
                Difficulty = Difficulty.Beginner,
                DisplayOrder = 3,
                RepositoryLink = "https://github.com/the-csharp-academy/CodeReviews.Console.HabitTracker",
                Introduction = new List<Paragraph>
                {
                    new Paragraph
                    {
                        Body="It's time to learn how to integrate C# code with a database! In this very simple task you'll build a very simple app that will teach you how to perform <a target='_blank' href='https://en.wikipedia.org/wiki/Create,_read,_update_and_delete'>CRUD operations</a> against a real database. These operations are the base of web-development and you’ll be using them throughout your career in most applications. For this reason, we think it’s very important to do it from the start of your journey."
                    },
                    new Paragraph
                    {
                        Body="For that you’ll have to learn very simple <a target='_blank' href='https://en.wikipedia.org/wiki/SQL'>SQL commands</a>. I know it sounds scary, but you’ll be amazed about how little SQL knowledge you need to build a full-stack app. Don’t worry, we will take you by the hand and by the end you’ll have completed your first fully functioning CRUD app. The most common ways of calling a SQL database with C# are through <a target='_blank' href='https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/'>ADO.NET</a>, Dapper and Entity Framework. We will start by using ADO.NET, because it’s the closest to raw SQL."
                    },
                    new Paragraph
                    {
                        Body="If you think this project is too hard for you and you have no idea where to even start, you’re probably right. You might need an extra hand to build a real application on your own. If that’s the case, <a target='_blank' href='https://youtu.be/d1JIJdDVFjs'>watch the video tutorial for this project</a> and then come back and try it again on your own. It’s perfectly ok to feel lost, since most beginner courses don’t actually teach you how to build something. "
                    },
                    new Paragraph
                    {
                        Body="So let’s go!"
                    }
                },
                Requirements = new List<string>
                {
                    "This is an application where you’ll log occurrences of a habit.",
                    "This habit can't be tracked by time (ex. hours of sleep), only by quantity (ex. number of water glasses a day)",
                    "Users need to be able to input the date of the occurrence of the habit",
                    "The application should store and retrieve data from a real database",
                    "When the application starts, it should create a sqlite database, if one isn’t present.",
                    "It should also create a table in the database, where the habit will be logged.",
                    "The users should be able to insert, delete, update and view their logged habit.",
                    "You should handle all possible errors so that the application never crashes.",
                    "You can only interact with the database using ADO.NET. You can’t use mappers such as Entity Framework or Dapper.",
                    "Follow the <a href='/article/30006/dry-principle-csharp' target='_blank'>DRY Principle</a>, and avoid code repetition.",
                    "Your project needs to contain a Read Me file where you'll explain how your app works and tell a little bit about your thought progress. What was hard? What was easy? What have you learned? Here's a nice example:"
                },
                RequirementsConclusion = "<a target='_blank' href='https://github.com/thags/ConsoleTimeLogger'>Github project with an example of a tidy Read Me file.</a>",

                Tips = new List<string>
                {
                    "Read <a target='_blank' href='https://www.bytehide.com/blog/kiss-principle-csharp' target='_blank'>this article about the KISS principle</a> and try to apply it to this project.",
                    "Test your SQL commands on DB Browser before using them in your program.",
                    "To improve the user's experience, when asking for a date input, give the option to type a simple command to add today's date",
                    "You can keep all of the code in one single class if you wish. We'll deal with Object Oriented Programming in the next project",
                    "Don't forget the user input's validation: Check for incorrect dates. What happens if a menu option is chosen that's not available? What happens if the users input a string instead of a number?"
                },
                 Challenges = new List<string>
                {
                    "If you already have a bit of experience with programming, we highly recommend you get into the habit of <b>writing unit tests</b> for a few methods in your project. Any method that outputs data and doesn't talk to a database (those are tested in <b>integration tests</b>) can be unit tested. A good example is any method that deals with validation. <a href='/article/30009/unit-testing-for-beginners' target='_blank'>Here's a quick tutorial.</a> ",
                    "If you haven't, <a target='_blank' href='https://reintech.io/blog/mastering-parameterized-queries-ado-net' target='_blank'>try using parameterized queries</a> to make your application more secure.",
                    "Let the users create their own habits to track. That will require that you let them choose the unit of measurement of each habit. Hot tip: <b>You should not create a table for each habit</b>.",
                    "Seed Data into the database automatically when the database gets created for the first time, generating a few habits and inserting a hundred records with randomly generated values. This is specially helpful during development so you don't have to reinsert data every time you create the database. ",
                },
                Blocks = new List<Block>
                {
                    new Block
                    {
                        Title = "AI Challenge",
                        ImgUrl= "icons8-artificial-intelligence-64.png",
                        Paragraphs = new List<Paragraph>
                        {
                            new Paragraph
                            {
                                Body = "Since this is a slightly more advanced challenge <b>you'll be rewarded with 20 extra points</b>. It taps into the future of programming: Artificial intelligence. Can you let the users add records using their voice? For this you'll use Azure's Language Services. You can find a step-by-step tutorial below:"
                            },
                            new Paragraph
                            {
                                IsVideo = true,
                                VideoUrl = "https://www.youtube.com/embed/XMJS-eQ4Y48?si=Bwbn0UZUe-thB8md"
                            }
                        }
                    },
                    new Block
                    {
                        Title = "Changing Your Working Directory",
                        ImgUrl = "icons8-folder-100.png",
                        Paragraphs = new List<Paragraph>
                        {
                            new Paragraph
                            {
                                Body = "This way .NET will build your project in your main folder. By default it builds your project in a bin folder and just to keep things simple we want to avoid that. That will create a Properties folder with a <b>launchsettings.json</b> file containing your configuration information. This is an important step only for applications that use Sqlite because you want the database to be created in the same folder of the application to avoid confusion."
                            },
                            new Paragraph
                            {
                                Body = "For that, click on the chevron next to the name of your app on the top menu, click on {nameoftheapp} Debug Properties and copy the path of your directory to the 'Working Directory' field. To find out what your path is, you can right click on your project in the Solution Explorer and on “Copy Full Path” or look it up in your Files Explorer. If you’re using Mac/Visual Studio Code, reach out and I’ll tell you how to do it. "
                            },
                            new Paragraph
                            {
                                IsPicture = true,
                                PictureUrl = "working-directory-1.png"
                            },
                            new Paragraph
                            {
                                IsPicture = true,
                                PictureUrl = "working-directory-2.png"
                            }
                        }
                    },
                    new Block
                    {
                        Title = "Video Tutorial",
                        ImgUrl = "external-video-tutorial-online-learning-photo3ideastudio-flat-photo3ideastudio-300x300.png",
                        Paragraphs = new List<Paragraph>
                        {
                            new Paragraph
                            {
                                Body = "If you’re feeling totally lost, it’s perfectly ok to watch a video tutorial to get you going. Here you’ll learn to connect all the pieces to build a real application. Once you finish it, make sure you try it again on your own without the help of the video so you internalise the newly acquired knowledge. "
                            },
                            new Paragraph
                            {
                                IsVideo = true,
                                VideoUrl = "https://www.youtube.com/embed/d1JIJdDVFjs"
                            },
                        }
                    }
                }
            },
             new Project
             {
                Id = 13,
                Title = "Coding Tracker",
                IconUrl = "icons8-smart-watch-96.png",
                BannerUrl = "pexels-divinetechygirl-1181244.jpg",
                LanguageHeadings = new EnglishHeadings(),
                Slug = "coding-tracker",
                Level = Level.OliveGreen,
                Description = "Track your coding hours. Learn how to deal with dates, to use separation of concerns and use your first external library to enhance your application",
                Area = Area.Console,
                ExperiencePoints = 10,
                Difficulty = Difficulty.Beginner,
                DisplayOrder = 4,
                RepositoryLink = "https://github.com/the-csharp-academy/CodeReviews.Console.CodingTracker",
                Introduction = new List<Paragraph>
                {
                    new Paragraph
                    {
                        Body="This app should be very similar to the <a href='project/12/habit-logger' target='blank'>Habit Logger</a> you’ve previously completed. It will serve the purpose of reinforcing what you’ve learned with a bit of repetition and building on that knowledge with slightly more challenging requirements. "
                    },
                    new Paragraph
                    {
                        Body="This time you’ll have to deal with the complexity of handling dates and times, which is a real challenge in any application. You’ll also be using your first external library. Often in professional environments programmers don’t reinvent the wheel and save time by using public solutions provided by other coders. That’s the beauty of the internet. You have access to an amazing coding community! "
                    },
                    new Paragraph
                    {
                        Body="In the first app we also didn’t have requirements for coding organization. This time you’ll have to use <a href='article/30005/separation-of-concerns-csharp' target='_blank'>Separation of Concerns</a>, one of the most important principles in modern programming. We recommend you go through our <a href='course/1/article/2/500000/false' target='_blank'>Object Oriented Programming Crash Course</a> prior to completing this project so you're better equipped to make your code more organized."
                    }
                },
                Requirements = new List<string>
                {
                    "This application has the same requirements as the previous project, except that now you'll be logging your daily coding time.",
                    "To show the data on the console, you should use the <b>Spectre.Console</b> library.",
                    "You're required to have separate classes in different files (i.e. UserInput.cs, Validation.cs, CodingController.cs)",
                    "You should tell the user the <b>specific format</b> you want the date and time to be logged and not allow any other format.",
                    "You'll need to create a configuration file called <b>appsettings.json</b>, which will contain your database path and connection strings (and any other configs you might need).",
                    "You'll need to create a <b>CodingSession</b> class in a separate file. It will contain the properties of your coding session: Id, StartTime, EndTime, Duration. When reading from the database, you can't use an anonymous object, you have to read your table into a <b>List of CodingSession</b>.",
                    "The user shouldn't input the duration of the session. It should be calculated based on the Start and End times",
                    "The user should be able to input the start and end times manually.",
                    "You need to use <b>Dapper ORM</b> for the data access instead of ADO.NET. (This requirement was included in Feb/2024)",
                    "Follow the <a href='/article/30006/dry-principle-csharp' target='_blank'>DRY Principle</a>, and avoid code repetition.",
                    "Don't forget the <b>ReadMe</b> explaining your thought process."
                },
                Resources = new List<string>
                {
                    "<a target='_blank' href='https://spectreconsole.net/'>Spectre Console</a> documentation</a>.",
                    "<a target='_blank' href='https://www.learndapper.com/'>Dapper Tutorial</a>.",
                },
                ResourcesIntro = "If you have learned the basics of C# following the <a href='article/8/foundations' target='blank'>C# Foundations</a> article, and completed the <a href='project/12/habit-logger' target='blank'>Habit Logger</a> project, you should know all the basic techniques needed to complete this project. Here’s a list of extra resources you might need:",
                Tips = new List<string>
                {
                    "It's up to you the order in which you'll build, but we recommend you do it in this order: configuration file, model, database/table creation, CRUD controller (where the operations will happen), TableVisualisationEngine and finally: validation of data.",
                    "Sqlite doesn't support dates. We recommend you store the datetime as a string in the database and then parse it using C#. You'll need to parse it to calculate the duration of your sessions.",
                    "Don't forget the user input's validation: Check for incorrect dates. What happens if a menu option is chosen that's not available? What happens if the users input a string instead of a number? Remember that the end date can't be before the start date."
                },
                 Challenges = new List<string>
                {
                    "Add the possibility of tracking the coding time via a stopwatch so the user can track the session as it happens.",
                    "Let the users filter their coding records per period (weeks, days, years) and/or order ascending or descending.",
                    "If you already have a bit of experience with programming, we highly recommend you get into the habit of <b>writing unit tests</b> for a few methods in your project. Any method that outputs data and doesn't talk to a database (those are tested in <b>integration tests</b>) can be unit tested. A good example is any method that deals with validation and testing your data-retrieving methods with different filters. <a href='/article/30009/unit-testing-for-beginners' target='_blank'>Here's a quick tutorial.</a>"
                },
                 Blocks = new List<Block>
                {
                     new Block
                    {
                        Title = "AI Challenge",
                        ImgUrl= "icons8-artificial-intelligence-64.png",
                        Paragraphs = new List<Paragraph>
                        {
                            new Paragraph
                            {
                                Body = "This is a slightly more advanced project but it taps into the future of programming: Artificial intelligence. Can you let the users add records using their voice? For this you'll use Azure's Language Services. You can find a step-by-step tutorial below:"
                            },
                            new Paragraph
                            {
                                IsVideo = true,
                                VideoUrl = "https://www.youtube.com/embed/XMJS-eQ4Y48?si=Bwbn0UZUe-thB8md"
                            }
                        }
                    },
                    new Block
                    {
                        Title = "Creating a Desktop App",
                        ImgUrl = "icons8-desktop-computer-512.png",
                        Paragraphs = new List<Paragraph>
                        {
                            new Paragraph
                            {
                                Body = $"If you have watched the <a href='https://www.youtube.com/watch?v=o81wpRuOGjE&list=PL4G0MUH8YWiAMypwveH2LlLK_o8Jto9CE'>entire C# Foundation course</a>, you have already created a Math Game Desktop app using the amazing .NET MAUI. It will be great practice to build a desktop Coding Tracker App with the same functionality you’ve created for this console app. There will be some challenges, especially if you want to create a timer, but you’ve already got all the skills necessary. And remember, if you get stuck, reach out on our <a  target='_blank' href='{DiscordLink}'>Discord community</a> and we will help!"
                            }
                        }
                    }
                }
            },
             new Project
            {
                Id = 14,
                Title = "Flashcards",
                IconUrl = "icons8-quizlet-96.png",
                BannerUrl = "pexels-ron-lach-8035283.jpg",
                LanguageHeadings = new EnglishHeadings(),
                Slug = "flashcards",
                Level = Level.Yellow,
                Description = "Building stacks of flashcards and a study functionality. Learn to deal with linked databases using SQL Server and to use Data Transfer Objects",
                Area = Area.Console,
                ExperiencePoints = 20,
                Difficulty = Difficulty.Intermediate,
                RepositoryLink = "https://github.com/the-csharp-academy/CodeReviews.Console.Flashcards",
                Introduction = new List<Paragraph>
                {
                    new Paragraph
                    {
                        Body="After the first two projects, you should be somewhat comfortable with how things work in C#. It’s time to make things slightly more complex. You’ll be using <b>SQL Server</b> for the first time. We could continue using SQLite, as it does everything needed for most small applications, but SQL Server is heavily used in the industry and the sooner we get familiar with it, the better."
                    },
                    new Paragraph
                    {
                        Body="This time the database will be a little more complex as well. We will have two tables linked by a foreign key. And for the first time we will be working with  <a href='https://www.codeproject.com/Articles/1050468/Data-Transfer-Object-Design-Pattern-in-Csharp' target='_blank'>DTOs (Data Transfer Objects)</a>, which will help us use the same object in different ways."
                    },
                    new Paragraph
                    {
                        Body="Time to get started!"
                    }
                },
                Requirements = new List<string>
                {
                    "This is an application where the users will create Stacks of Flashcards.",
                    "You'll need two different tables for stacks and flashcards. The tables should be linked by a foreign key.",
                    "Stacks should have a unique name.",
                    "Every flashcard needs to be part of a stack. If a stack is deleted, the same should happen with the flashcard.",
                    "You should use DTOs to show the flashcards to the user without the Id of the stack it belongs to.",
                    "When showing a stack to the user, the flashcard Ids should always start with 1 without gaps between them. If you have 10 cards and number 5 is deleted, the table should show Ids from 1 to 9.",
                    "After creating the flashcards functionalities, create a \"Study Session\" area, where the users will study the stacks. All study sessions should be stored, with date and score.",
                    "The study and stack tables should be linked. If a stack is deleted, it's study sessions should be deleted.",
                    "The project should contain a call to the study table so the users can see all their study sessions. This table receives insert calls upon each study session, but there shouldn't be update and delete calls to it."
                },
                Tips = new List<string>
                {
                    "Before starting to code, try creating tables and running a few CRUD queries in SQL Server to get familiar with SQL Server Studio.",
                    "For management of stacks, let the user choose the stack by name.",
                    "Think of the \"stacks\" and \"study\" areas almost as separate applications. The study area is merely using data from the stacks area."
                },
                LearningIntro = "If you have learned the basics of C# following the  <a href='https://www.youtube.com/watch?v=o81wpRuOGjE&list=PL4G0MUH8YWiAMypwveH2LlLK_o8Jto9CE' target='_blank'>C# Foundations </a> article, you should know all the basic techniques needed to complete this project. Here’s a list of the things you’ll need to fulfil the requirements:",
                LearningItems = new List<string>
                 {
                     "Using SQL Server.",
                     "Creating linked tables with SQL.",
                     "Using DTOs to create different versions of classes.",
                     "<a href='https://www.youtube.com/watch?v=bNetxDl40pM' target='_blank'>Pivoting Tables in SQL</a>"
                 },
                Blocks = new List<Block>
                {
                    new Block
                    {
                        Title = "Installing SQL Server",
                        ImgUrl = "icons8-sql-server-64.png",
                        Paragraphs = new List<Paragraph>
                        {
                            new Paragraph
                            {
                                Body = "This is the first project in the academy where we’ll be using SQL Server. <a href='https://docs.microsoft.com/en-us/sql/tools/visual-studio-code/sql-server-develop-use-vscode?view=sql-server-ver15'> You can work with SQL Server using Visual Studio.</a>. But I recommend you start using Microsoft SQL Server Management Studio. For this app, don’t use SQL Server EXPRESS, but only LOCAL DB. <a href='https://www.youtube.com/watch?v=QsXWszvjMBM'> Here’s a tutorial on how to install the studio</a>. And here’s a tutorial on <a href='https://www.youtube.com/watch?v=M5DhHYQlnq8'> how to connect to your localdb</a> "
                            }
                        }
                    },
                    new Block
                    {
                        Title = "Challenge",
                        ImgUrl = "icons8-courage-96.png",
                        Paragraphs = new List<Paragraph>
                        {
                            new Paragraph
                            {
                                Body = "If you want to expand on this project, here’s an idea. Try to create a report system where you can see the number of sessions per month per stack. And another one with the average score per month per stack. This is not an easy challenge if you’re just getting started with databases, but it will teach you all the power of SQL and the possibilities it gives you to ask interesting questions from your tables."
                            },
                            new Paragraph
                            {
                                Body = "Below’s a screenshot with an example of the finished report. You’ll need to learn about Pivoting Tables to complete this challenge. Reach out if you need help! "
                            },
                            new Paragraph
                            {
                                IsPicture = true,
                                PictureUrl = "flashcards-8.png"
                            }
                        }
                    }
                },
                Screenshots = new List<string>
                {
                    "flashcards-1.png",
                    "flashcards-2.png",
                    "flashcards-3.png",
                    "flashcards-4.png",
                    "flashcards-5.png",
                    "flashcards-6.png",
                    "flashcards-7.png"
                }
            },
             new Project
            {
                Id = 15,
                Title = "Drinks Info",
                IconUrl = "drinks.png",
                BannerUrl = "pexels-energepic-com-27411-110472.jpg",
                LanguageHeadings = new EnglishHeadings(),
                Slug = "drinks",
                Description = "Build a console app to consume an external API with HTTP Requests with C#",
                Area = Area.Console,
                Level = Level.Yellow,
                ExperiencePoints = 20,
                Difficulty = Difficulty.Intermediate,
                RepositoryLink = "https://github.com/the-csharp-academy/CodeReviews.Console.Drinks",
                Introduction = new List<Paragraph>
                {
                    new Paragraph
                    {
                        Body="Software developers frequently build systems that rely on third-party data. A common method for accessing this data is by making requests to external vendors <b>Web APIs (Application Programming Interfaces)</b>. Once the data is retrieved, it can be processed and integrated into the application to meet specific requirements. Another typical scenario involves organizations with multiple independent applications that need to communicate with each other, <a href='https://en.wikipedia.org/wiki/Microservices'>often using a technique known as microservices</a>. Later we will build our own APIs and Microservices, but first we need to learn how to <b>consume a Web Api</b>."
                    },
                    new Paragraph
                    {
                        Body="In this application we will learn how to connect to an external API through HTTP requests using .NET’s class library. It‘s easier than you imagine! Luckily there are many public APIs out there. <a href='https://github.com/public-apis/public-apis'> Here’s a great list of public APIs for practice.</a>"
                    }
                },
                Requirements = new List<string>
                {
                    "You were hired by restaurant to create a solution for their drinks menu.",
                    "Their drinks menu is provided by an external company. All the data about the drinks is in the companies database, accessible through an API.",
                    "Your job is to create a system that allows the restaurant employee to pull data from any drink in the database.",
                    "You don't need SQL here, as you won't be operating the database. All you need is to create a user-friendly way to present the data to the users (the restaurant employees)",
                    "When the users open the application, they should be presented with the Drinks Category Menu and invited to choose a category. Then they'll have the chance to choose a drink and see information about it.",
                    "When the users visualise the drink detail, there shouldn't be any properties with empty values.",
                    "You should handle errors so that if the API is down, the application doesn't crash."
                },
                ResourcesIntro = "Here are the links for using HTTP calls with C# and to the Drinks API documentation:",
                Resources = new List<string>
                {
                    "<a href='https://www.thecocktaildb.com/api.php' target='_blank'>Cocktail Database</a>",
                    "<a href='https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/console-webapiclient' target='_blank'>Microsoft Docs: Http Requests</a>",
                    "<a href='https://www.youtube.com/watch?v=fc7peZ-FHs4' target='_blank'>Video: Drinks Info App (FULL PROJECT)</a>"
                },
                Tips = new List<string>
                {
                    "Try calling the API using Postman or your browser before starting to code.",
                    "The UI in the youtube tutorial above is a bit ugly. We suggest you use Spectre Console for a better UX/UI."
                },
                Challenges = new List<string>
                {
                    "Add a 'Favorite Drinks' functionality",
                    "Find a way to show a picture of the drinks",
                    "Add a view count functionality so the users know which drinks have been visualized the most.",
                    "If you followed the tutorial in the resources, you noticed we used Rest Client for the handling of the HTTP requests. Try using .NET's HTTP client instead, as it's more commonly used in the industry."
                }
            },
             new Project
            {
                Id = 16,
                Title = "Phone Book",
                IconUrl = "icons8-contact-book-512-150x150.png",
                BannerUrl = "phonebook.jpg",
                LanguageHeadings = new EnglishHeadings(),
                Slug = "phonebook",
                Description = "Now you have basic understanding of SQL, it’s time to learn the basics of Entity Framework with a CRUD Phone Book Console App",
                Area = Area.Console,
                Level = Level.Yellow,
                ExperiencePoints = 20,
                Difficulty = Difficulty.Intermediate,
                RepositoryLink = "https://github.com/the-csharp-academy/CodeReviews.Console.Phonebook",
                Introduction = new List<Paragraph>
                {
                    new Paragraph
                    {
                        Body="In the .NET ecosystem you’ll come across <a href='https://stackoverflow.com/questions/1279613/what-is-an-orm-how-does-it-work-and-how-should-i-use-one'>ORMs (Object-Relational Mappers)</a>, which helps you to deal with databases using objects. If you have searched for C# tutorials you’ve probably encountered technologies such as Dapper and Entity Framework. You’ll definitely be using one when you start working as a developer."
                    },
                    new Paragraph
                    {
                        Body="In this tutorial we’ll implement a very simple Phone Book so you can learn the basics of Entity Framework, the most popular ORM. Even though we at The C# Academy strongly believe C# students should learn raw SQL first and foremost, most .NET C# job applications demand Entity Framework. The good news is that EF’s basic operations are very simple to learn and you’ll be up and running very quickly. Let’s go!"
                    }
                },
                Requirements = new List<string>
                {
                    "This is an application where you should record contacts with their phone numbers.",
                    "Users should be able to Add, Delete, Update and Read from a database, using the console.",
                    "You need to use Entity Framework. ADO.NET, Dapper and any other ORM aren't allowed.",
                    "Your code should contain a base Contact class with <b>at least</b> name, email and phone number properties.",
                    "You should validate e-mails and phone numbers and let the user know what formats are expected.",
                    "Make sure you handle errors so the app doesn't crash unexpectedly in case EF or the database have problems.",
                    "You should use Code-First Approach, which means EF will create the database schema for you.",
                    "You should seed data using Entity Framework so the user has some contacts to start with.",
                },
                ResourcesIntro = "Here are a few resources that might be helpful.",
                Resources = new List<string>
                {
                    "<a href='https://learn.microsoft.com/en-us/ef/core/'>Entity Framework: Microsoft Learn</a>",
                    "<a href='https://www.youtube.com/watch?v=tDiJdthMs1Q&list=PL4G0MUH8YWiDcv8EUWTbDxDlkSndfh-T0'>CRUD Console APP with EF on Youtube</a>"
                },
                ResourcesConclusion = "There are many other Youtube videos and blog articles about Entity Framework everything else you need. Don’t be ashamed to use Google! If you use AI, make sure you understand each line that's being suggested 🤓",
                Tips = new List<string>
                {
                    "Before starting the phone book app, finish the program in the Microsoft Documentation article without any changes and store in your Github repository for reference. Make sure you understand most of the code before you get started.",
                    "For each interaction with the DB with Entity Framework, print the correspondent SQL queries so you learn what your EF queries are translated into.",
                },
                Challenges = new List<string>
                {
                    "Create a functionality that allows users to add the contact's e-mail address and send an e-mail message from the app.",
                    "Expand the app by creating categories of contacts (i.e. Family, Friends, Work, etc).",
                    "What if you want to send not only e-mails but SMS?",
                    "Create a unit tests project and test your validation methods. Pass several invalid and valid inputs to make sure your validation works as expected."
                }
            },
             new Project
            {
                Id = 17,
                Title = "Shifts Logger",
                IconUrl = "icons8-nurse-256.png",
                BannerUrl = "pexels-rdne-6129507.jpg",
                LanguageHeadings = new EnglishHeadings(),
                Slug="shifts-logger",
                Description = "Build an App for shift workers to log their hours. In this app you’ll learn how to build a Web API and consume it with a Console App",
                Area = Area.Console,
                Level = Level.Yellow,
                ExperiencePoints = 20,
                Difficulty = Difficulty.Intermediate,
                RepositoryLink = "https://github.com/the-csharp-academy/CodeReviews.Console.ShiftsLogger",
                Introduction = new List<Paragraph>
                {
                    new Paragraph
                    {
                        Body="If you’ve been learning to code for more than five minutes, you probably heard about <a href='https://developer.mozilla.org/en-US/docs/Learn/JavaScript/Client-side_web_APIs/Introduction'><b>APIs</b></a>. They’re at the core of back-end programming. In web development, their main job will be to communicate with databases using <b>endpoints</b>. From now on you’ll be creating Web APIs all the time and this acronym will forever be part of your vocabulary. "
                    },
                    new Paragraph
                    {
                        Body="In the <a href='project/15/drinks' target='blank'>Drinks Info App</a> you created a program that consumed an external API. This time <b>you will track a worker’s shifts</b>. We’ll create an API and the console app that will consume it. When using Microsoft’s Documentation, often you’ll come across Web APIs being developed with Entity Framework, which acts as layer between the endpoints and the actual database. "
                    },
                    new Paragraph
                    {
                        Body="This stack (Web API/EF) is very common in enterprise applications, but it’s important to know that Web Apis can be developed using ADO.NET and Dapper. These data access solutions have the advantage of giving the developers more control over the SQL queries. In the end, all solutions are valid. Each has pros and cons and it comes down to personal preference. For this project, we will be using Entity Framework, as it takes care the basic CRUD operations that we need as beginners. "
                    },
                    new Paragraph
                    {
                        Body="This project has as a requirement the use of Web APIs testing tools. In development you need a way to quickly test your endpoints without having to create a UI. <b>Postman</b> is a free, very comprehensive professional tool with a user interface that makes it very easy to store tests for later use, which saves a lot of development time. "
                    }
                },
                Requirements = new List<string>
                {
                    "This is an application where you should record a worker's shifts.",
                    "You need to create two applications: the Web API and the UI that will call it.",
                    "All validation and user input should happen in the UI app.",
                    "Your API's controller should be lean. Any logic should be handled in a separate \"service\".",
                    "You should use the \"code first\" approach to create your database, using Entity Framework's migrations tool.",
                    "Your front-end project needs to have try-catch blocks around the API calls so it handles unexpected errors (i.e. the API isn't running or returns a 500 error.)"
                },
                ResourcesIntro = "Here are a few resources that might be helpful.",
                Resources = new List<string>
                {
                    "<a href='https://www.thecsharpacademy.com/course/3/article/1/500050/false'>ASP.NET Core Web API Crash Course</a>",
                    "<a href='https://developer.mozilla.org/en-US/docs/Learn/JavaScript/Client-side_web_APIs/Introduction'>What are APIs?</a>",
                    "<a href='https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-6.0&tabs=visual-studio'>Web API Docs</a>",
                    "<a href='https://learn.microsoft.com/en-us/shows/beginners-series-to-web-apis/what-are-web-apis-1-of-18--beginners-series-to-web-apis'>Web API Beginner's Series (Microsoft Learn)</a>",
                    "<a href='https://www.youtube.com/watch?v=IYWOWxw7dys'>Testing Web APIs with Swagger</a>",
                    "<a href='https://www.youtube.com/watch?v=FjgYtQK_zLE'>Postman Youtube Tutorial</a>"

                },
                Tips = new List<string>
                {
                    "If this is your first contact with .NET Web API, follow the tutorial closely using the Todo List data model and http-repl for testing. In a second moment, follow the tutorial one more time, this time following the project's requirements.",
                    "First, create the Web API project, then use Swagger and Postman to test it. Only then create the UI project.",
                    "You might be tempted to skip testing with Postman. Don't make that mistake. These tools are essential for working with web apis in enterprise and your hiring managers will be unimpressed if you are not familiar with them.",
                    "Calculate the duration of the shift based on its start and end. Don't forget to validate the end date.",
                    "In .NET's Web API template, there's a lot of code you might not have seen before, particularly in Program.cs and in the controllers. Study the code carefully so you understand each keyword. Don't hesitate to ask AI what's happening behind the scenes."
                }
            },
             new Project
             {
                Id = 18,
                Title = "Ecommerce API",
                IconUrl = "icons8-shop-94.png",
                BannerUrl = "pexels-olly-3769747.jpg",
                LanguageHeadings = new EnglishHeadings(),
                Slug="ecommerce-api",
                Description = "Reinforce your knowledge of Web APIs with intermediate level features.",
                Area = Area.Console,
                Level = Level.Orange,
                ExperiencePoints = 30,
                Difficulty = Difficulty.Advanced,
                RepositoryLink = "https://github.com/the-csharp-academy/CodeReviews.Console.EcommerceApi",
                Introduction = new List<Paragraph>
                {
                    new Paragraph
                    {
                        Body="In your first ASP.NET Core Web API project you had a first taste of creating, configuring and exposing endpoints and creating a client to consume them. We will now expand on this knowledge with requirements that are aligned with the demands of enterprise development. So far we have worked predominantly in personal apps. This time we will dive into a common business case in enterprise: an ecommerce API that supports a retail business.</a>."
                    },
                    new Paragraph
                    {
                        Body="The business case itself will be fairly loose, you can create an ecommerce for whatever type of product you want, which will help you exercise your creativity and focus on the technical specifications.</b>"
                    }
                },
                Requirements = new List<string>
                {
                    "Your project needs to be an ASP.NET Core Web API, with Entity Framework and your choice between SQL Server and Sqlite.",
                    "Your api needs to use Dependency Injection.",
                    "You should have at least three tables: Products, Categories and Sales.",
                    "Products and Sales need to have a many-to-many relationship, meaning products can have multiple sales, and sales can have multiple products.",
                    "Products need to have a price. Multiple products can be sold in the same sale.",
                    "You need to provide a Postman Collection with all possible requests for your API. It's a json file that needs to be included in your PR.",
                    "You don't need to create a UI to consume your API.",
                    "Your GetProducts and GetSales endpoints need to have pagination capabilities.",
                    "In retail it's good practice to prevent deletion of records. Feel free to add soft-deletes.",
                    "You shouldn't update products prices. What would happen if you made a sale and later updated the price of that product?"
                },
                ResourcesIntro = "Here are a few resources that might be helpful.",
                Resources = new List<string>
                {
                    "<a target='blank' href='https://learn.microsoft.com/en-us/ef/core/modeling/relationships/many-to-many'>Many to Many tutorial Microsoft</a>",
                    "<a target='blank' href='https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection-usage'>Dependency Injection Tutorial Microsoft</a>",
                    "<a target='blank' href='https://thecsharpacademy.com/course/6/article/1/500150/False'>Dependency Injection Tutorial The C# Academy</a>",
                    "<a target='blank' href='https://www.c-sharpcorner.com/article/implementing-pagination-and-filtering-in-asp-net-core-8-0-api/'>Pagination Tutorial C# Corner</a>",
                    "<a target='blank' href='https://medium.com/@bpst.blog/understanding-rest-and-restful-apis-constraints-methods-and-examples-76b2d1b63003'>Rest APIs Article</a>"
                },
                Tips = new List<string>
                {
                    "Seed data from the beginning so you don't need to create records manually.",
                    "This project can get overwhelming very quickly. Use a step-by-step approach, creating one end-point at a time and making sure everything works before moving to the next one.",
                    "Start using Postman from the start to tests your requests. It will save you a lot of time.",
                    "Think about the business case and what endpoints it will actually. Not all tables need all CRUD operations. For example, you might not need to delete or update products, but you will need to create them and read them.",
                },
                Challenges = new List<string>
                {
                    "Add filtering and sorting  capabilities to your endpoints",
                    "Create a Console UI to consume your Web API.",
                    "After completing the project, read the <b>Rest APIs Article</b> listed in the resources and check what could be missing. Pay particular attention to status codes and endpoints signatures."
                }
            },
             new Project
             {
                Id = 19,
                Title = "Sports Results Notifier",
                IconUrl = "icons8-sports-96.png",
                BannerUrl = "webcrawler.jpg",
                LanguageHeadings = new EnglishHeadings(),
                Slug="sports-results",
                Description = "Learn how to create a web crawler and send e-mails using C#",
                Area = Area.Console,
                ExperiencePoints = 30,
                Difficulty = Difficulty.Advanced,
                Level = Level.Orange,
                RepositoryLink = "https://github.com/the-csharp-academy/CodeReviews.Console.SportsResults",
                Introduction = new List<Paragraph>
                {
                    new Paragraph
                    {
                        Body="You’re getting close to the end of our beginner C# program. But before your graduation from this first phase you need to learn two very important tasks in programming: The ability to harvest data from non-api sources and the ability to send e-mails. Let’s create an application that will combine these two tasks."
                    }
                },
                Requirements = new List<string>
                {
                    "This is an application where you should read sports data from a website once a day and send it to a specific e-mail address.",
                    "You don't need any interaction with the program. It will be a service that runs automatically.",
                    "The data should be collected from the Basketball Reference Website in the resources area.",
                    "You should use the Agility Pack library for scrapping."
                },
                ResourcesIntro = "Here are a few resources that might be helpful.",
                Resources = new List<string>
                {
                    "<a target='_blank' href='https://html-agility-pack.net/'>Agility Pack Docs</a>",
                    "<a target='_blank' href='https://www.c-sharpcorner.com/blogs/send-email-using-gmail-smtp'>Send An Email Using Gmail SMTP and C#</a>",
                    "<a target='_blank' href='https://www.youtube.com/watch?v=oMM0yzyi4Do'>Agility Pack Tutorial</a>",
                    "<a target='_blank' href='https://www.youtube.com/watch?v=wbBuB7-BaXw'>Another Agility Pack Tutorial</a>",
                    "<a target='_blank' href='https://www.basketball-reference.com/boxscores/'>Basketball Reference</a>",
                    "<a target='_blank' href='https://github.com/ChangemakerStudios/Papercut-SMTP'>Papercut - Use it for local Email SMTP testing</a>"
                },
                ResourcesConclusion = "There are many other Youtube videos and blog articles about scrapping and sending an e-mail with C#. Google is your best friend! 🙂",
                Tips = new List<string>
                {
                    "Don't forget to create a Github repository for your project from the beginning.",
                    "After the completion of this project, try to create your own scrapper from a different source and with a different business case.",
                    "Bear in mind that some websites don't authorise scrapping.",
                    "It's not simple to scrap data from websites generated dynamically with the help of Javascript frameworks. When you create your own project, be aware that it's easier to scrape from more traditional, simple, server-based ones."
                }
            },
             new Project
             {
                Id = 20,
                Title = "Document Processor",
                IconUrl = "excel.png",
                Slug="document-processor",
                BannerUrl = "pngtree-magnified-finance-documents-and-charts-on-black-background-picture-image_2730841.jpg",
                LanguageHeadings = new EnglishHeadings(),
                Description = "Learn how to work with documents using C#.",
                Area = Area.Console,
                Level = Level.Orange,
                ExperiencePoints = 30,
                Difficulty = Difficulty.Advanced,
                RepositoryLink = "https://github.com/the-csharp-academy/CodeReviews.Console.DocumentProcessor",
                Introduction = new List<Paragraph>
                {
                    new Paragraph
                    {
                        Body="Now  that you have an initial foundation of C#, it’s time to tackle a very important task in programming: The ability to work with files. When working in a company, all sorts of documents will be generated using a variety of file types: .doc, .xls, .pdf, .csv, just to name a few of the most commonly used. "
                    },
                    new Paragraph
                    {
                        Body="Your job as a programmer is to create applications that will manipulate data “to and from” these files. In this project, we seed data from one of our previous applications from a spreadsheet and generate reports to a pdf file."
                    }
                },
                Requirements = new List<string>
                {
                    "In this project you'll seed data either into the Phone Book app or the Ecommerce app you've created before as part of the roadmap. The spreadsheet can have .xls, xlsx or csv formats.",
                    "You can use any package or library you need, just make sure you provide enough information on how to set it up in your readme.",
                    "When the application starts, if there's no data it should populate the database with data from the spreadsheet. ",
                    "Once the database is populated, you'll fetch data from it and show it in the console.",
                    "Your app needs to have a report functionality that exports data into a pdf file in your computer.",
                    "Handle errors so that a file is corrupted or the path is wrong, the app doesn't crash."
                },
                Challenges = new List<string>
                {
                    "Give the user the option to import/export data using different formats.",
                    "Add the ability to read from other types of files, i.e. csv, pdf, doc.",
                    "Create a functionality that creates reports periodically.",
                    "Import/Export to an Azure Blob for further processing."
                }
            },
             new Project
             {
                Id = 21,
                Title = "Testing",
                IconUrl = "icons8-test-tube-100.png",
                BannerUrl = "",
                LanguageHeadings = new EnglishHeadings(),
                Slug="unit-testing",
                Description = "The last piece of the puzzle before moving on to  front-end. Learn to test the business logic of your applications",
                Area = Area.Console,
                Level = Level.Orange,
                ExperiencePoints = 30,
                Difficulty = Difficulty.Advanced,
                RepositoryLink = "https://github.com/the-csharp-academy/CodeReviews.Console.UnitTests",
                Introduction = new List<Paragraph>
                {
                    new Paragraph
                    {
                        Body="We’re almost there! It’s been a long way and it’s almost time to celebrate your graduation from the Console Apps area. But there’s one final step: Unit Tests."
                    },
                    new Paragraph
                    {
                        Body="More likely than not (and hopefully) the organisation you’ll work will have systems that use automated testing. They make sure everything is running properly before each deployment. The code covered by those tests won’t need to be tested manually every time a change is made, which is prone to errors and very expensive. A strong suite of tests helps developers code that's more maintainable and reliable. So let's jump into it!"
                    }
                },
                Requirements = new List<string>
                {
                    "In this project, you'll create tests for the PhoneBook App, the second project in the course.",
                    "You'll need to create a PhoneBook.UnitTests project and a PhoneBook.IntegrationTests project, all under the same solution as the Phonebook app.",
                    "Your unit tests should test <b>at least</b> the input validation methods, making sure the app correctly prevents the user from inserting incorrect data.",
                    "Your integration tests cannot use InMemoryDatabase, as it doesn't mimick the behavior of a SQL database correctly. If your project uses SQL Server, using SQLite for the tests is still acceptable",
                    "You can user whatever testing library you want. The most popular are NUnit and Xunit.",
                    "You should test both correct and incorrect inputs."
                },
                ResourcesIntro = "Here are a few resources that might be helpful.",
                Resources = new List<string>
                {
                    "<a href='https://www.accelq.com/blog/unit-testing/'>The Importance of Unit Testing</a>",
                    "<a href='https://dev.to/tkarropoulos/unit-testing-in-net-tools-and-techniques-nei'>C# Testing Essentials</a>",
                    "<a href='https://www.youtube.com/watch?v=HYrXogLj7vg'>Unit Testing C# Code on Youtube</a>",
                    "<a href='https://www.youtube.com/watch?v=RXSPCIrrjHc'>Learn Integration Testing in C# in 25 minutes.</a>"
                },
                Tips = new List<string>
                {
                    "Naming your tests properly is almost as important as writing them. Make sure your tests express their intent clearly as they serve as documentation. Don't be afraid of being verbose. \"WhenQuantityInputIsPositive_DataIsPersistedCorrectly\" is a good name, while \"QuantityTest\" doesn't have enough information.",
                    "In your test, you'll have to mock the tested service and call it's methods. Think of all possibilities of correct and incorrect inputs and test if the application handles them.",
                    "Mocking dependencies in integration testing can be very frustrating. If you're struggling to create testable methods, try breaking them down so they do only one thing. That's the best way to make your code more testable and maintanable.",
                    "Sometimes it's good to create one method that runs all tests for a specific functionality. This way you can be sure that all edge cases are covered without having to run each test individually."
                },
                Challenges = new List<string>
                {
                    "From now on you'll be required to write tests in many projects. To get a bit more practice before moving on, try going back and writing tests for more apps. The Shifts Logger and the Document Processor could be significantly enhanced with a good testing suite."
                }
            },
        };
    }
}
