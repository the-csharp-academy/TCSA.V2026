using TCSA.V2026.Data.Models;

namespace TCSA.V2026.Data.Curriculum;

public class WebApiCourse
{
    public static Course GetWebApiCourse()
    {
        return new Course
        {
            Id = 3,
            Title = "Introduction to ASP.NET Core Web APIs",
            Description = "Master speech capabilities in Azure AI for dynamic, voice-driven applications!",
            ImgUrl = "icons8-internet-64.png",
            Articles = new List<Article>
                {
                    new Article
                    {
                        Id = 500050,
                        CourseDisplayId = 1,
                        Title = "Introduction",
                        Slug = "asp-net-core-webapi-introduction",
                        Description = "",
                        Area = Area.Course,
                        ExperiencePoints = 1,
                        Blocks = new List<Block>
                        {
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "Welcome to the ASP.NET Core Web APIs Course for Beginners! We are thrilled to have you join us on this exciting course, designed to provide you with a comprehensive introduction to  building robust and scalable Web APIs." },
                                    new Paragraph {
                                       Body = "<b>Web APIs are the backbone of modern web applications</b>. They allow different systems to communicate and exchange data, enabling rich, dynamic user experiences. Understanding how to build and interact with Web APIs is crucial for creating modern web applications that are responsive and scalable." },
                                    new Paragraph
                                    {
                                        IsPicture = true,
                                        PictureUrl = "c3-ch1-webapis-flight-api-banner.png"
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "What are We APIs?",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       Body = "Web APIs, or <b>Web Application Programming Interfaces</b>, are sets of rules and protocols that allow different software applications to communicate with each other over the internet. They serve as intermediaries, enabling applications to request and exchange data seamlessly." },
                                    new Paragraph {
                                       Body = "In simple terms, when you think about a Web API, imagine it as <b>a bridge between two applications</b>. For instance, when you use a weather app on your smartphone, the app communicates with a web service that provides weather data. This communication happens through a Web API. The app <b>sends a request</b> to the API, which then fetches the weather data from a database and sends it back to the app in a structured format." },
                                    new Paragraph {
                                       Body = "Web APIs use standard web protocols like <b>HTTP/HTTPS</b> for communication, making them <b>accessible via URLs</b>. They typically handle requests and responses in formats such as JSON or XML, which are easy for both humans and machines to read and process." },
                                }
                            },
                            new Block
                            {
                                Title = "Modern Web",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       Body = "All major platforms you use every day, such as Google, Facebook, Twitter, Instagram, Discord, Reddit and online games offer Web APIs that allow third-party developers to <b>integrate their services</b> into other applications. This means you can see integrations with these serves from on a variety of platforms, not just on the original website or app." },
                                    new Paragraph {
                                       Body = "In essence, Web APIs are crucial for creating <b>interconnected systems</b> where different applications can work together, share data, and enhance functionality. <b>They are the foundation of the modern web</b>, enabling the creation of complex, dynamic, and integrated digital experiences." }
                                }
                            },
                            new Block
                            {
                                Title = "Who's this course for? ",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       Body = "➡️<b>Beginners</b>: Those who already know a little C# and want to build a solid foundation in ASP.NET Core. However if this is your first time with the language, this course isn't for you. You should try The C# Foundations Course first." },
                                    new Paragraph {
                                       Body = "➡️<b>Developers</b>: Individuals with some programming experience looking to expand their skill set into web APIs." },
                                     new Paragraph {
                                       Body = "➡️<b>Students</b>: Learners who are studying computer science or related fields and need practical experience with web technologies." },
                                    new Paragraph {
                                       Body = "This course is <b>not for absolute beginners</b> in C#. If you're still learning the basics, we recommend you follow our roadmap <a href='project/53/math-game' target='_blank'>starting from this project</a>." },
                                }
                            },
                            new Block
                            {
                                Title = "What You'll Learn",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       Body = "Throughout this course, you will:<br>☑️\r\n<b>Understand the Basics</b>: Get acquainted with the fundamental concepts of ASP.NET Core Web APIs and RESTful services.<br>☑️\r\n<b>Set Up Your Development Environment</b>: Learn how to install and configure the tools you need to build ASP.NET Core applications.<br>☑️\r\n    <b>Create Your First Web API</b>: Step-by-step guidance on creating a simple yet functional Web API from scratch.<br>☑️\r\n     <b>Routing and Controllers</b>: Dive deep into routing mechanisms and how controllers handle HTTP requests.<br>☑️\r\n     <b>Work with Data</b>: Connecting to databases using Entity Framework Core.<br>☑️\r\n     <b>Implement CRUD Operations</b>: Master the essential Create, Read, Update, and Delete operations in your API.<br>☑️\r\n     <b>Testing</b>: Testing Web APIs with the industry-standard Postman tool\r\n" }
                                }
                            },
                            new Block
                            {
                                Title = "Course Structure",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       Body = "As with all tutorials in the academy, this course is practical. We'll learn while developing a Flight Data API, tracking information about aiports, planes and seats. It's a great complex real world application that will provide the right complex to learn about Web APIs." },
                                    new Paragraph {
                                       Body = "At the end of each lesson that contains new code, you'll see a link to the branch in the project's Github repository, containing the code for the current stage of the project." }
                                }
                            },
                             new Block
                            {
                                Title = "Video Course",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "We also have a paid video version of this tutorial. The video version already contains a part 2, with the intermediate content.:<br><br>\r\n<b>Option 1</b>: Purchase the course <a href='https://thecsharpschool.getlearnworlds.com/course/aspnet-core-web-apis' target='_blank'>individually for $4.99</a>.<br>\r\n<b>Option 2</b>: Subscribe to the <b>VIP Membership</b> and have access to <a href='https://thecsharpschool.getlearnworlds.com/payment?product_id=the-c-academy-membership&type=subscription' target='_blank'>all our courses for $4.99/month</a><br>\r\n<b>Option 3</b>: Subscribe to the <b>VIP Mentorship</b> for <a href='https://thecsharpschool.getlearnworlds.com/payment?product_id=net-accelerator-mentorship&type=subscription' target='_blank'>all courses and 1-on-1 mentorship for 39.99/month</a>" }
                                }
                            },
                        }
                    },
                    new Article
                    {
                        Id = 500051,
                        CourseDisplayId = 2,
                        Title = "Creating the Project",
                        Slug = "asp-net-core-webapi-project",
                        Description = "",
                        Area = Area.Course,
                        ExperiencePoints = 1,
                        Blocks = new List<Block>
                        {
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "Let's start by creating our project. In Visual Studio, choose the ASP.NET Core Web API option. We're calling it TCSA.WebAPIs.FlightsData. Feel free to choose another name if you'd like. In the screen that follows you can keep all default configurations, but untick 'Create Controllers'. That will create a Minimal API as a starting point. We will see what that means later." +
                                    "" },
                                    new Paragraph {
                                        IsPicture = true,
                                        PictureUrl = "c3-ch2-webapis-coursecreation.png"
                                    },
                                    new Paragraph { Body = "Once your project is created, you'll see the following folders and files:" },
                                    new Paragraph {
                                        IsPicture = true,
                                        PictureUrl = "c3-ch2-webapis-project-template.png"
                                    },
                                },
                            },
                            new Block
                            {
                                Title = "Examine The Project Files",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       Body = "The template generated upon project creation is a Minimal API that serves data about the weather. This is what each file does:" },
                                    new Paragraph {
                                       Body = "➡️ <b>Program.cs:</b> Serves as the entry point and main configuration file for the application. Configures the web application, adds services such as Swagger for API documentation, sets up middleware, and defines endpoints."
                                    },
                                    new Paragraph {
                                       Body = "➡️ <b>appsettings.json</b>: Stores configuration settings for the application.  Initially contains logging configuration and allowed hosts."
                                    },
                                    new Paragraph {
                                       Body = "➡️ <b>appsettings.Development.json</b> :  Overrides settings in appsettings.json when the application runs in the development environment."
                                    },
                                    new Paragraph {
                                       Body = "➡️ <b>launchsettings.json</b> : Typically found in the Properties folder. Defines profiles for launching the application in different environments (e.g., development, production). Specifies the environment variables, command-line arguments, and other settings for running the application."
                                    },
                                    new Paragraph {
                                       Body = "➡️ <b>TCSA.WebAPI.FlightData.http:</b>  Used for testing API endpoints directly from within the code editor, often Visual Studio Code, which supports HTTP request files through extensions like REST Client. It allows developers to send HTTP requests to their API without needing to use external tools. However, in this tutorial we will use Postman for testing our endpoints."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Clean Up",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       Body = "Let's convert our project from a Minimal API to a Controller-Based Web API. In Program.cs, start by removing the following snippets."
                                    },
                                    new Paragraph {
                                        IsCode = true,
                                       Body = "app.UseHttpsRedirection();\r\nvar summaries = new[]\r\n{\r\n    \"Freezing\", \"Bracing\", \"Chilly\", \"Cool\", \"Mild\", \"Warm\", \"Balmy\", \"Hot\", \"Sweltering\", \"Scorching\"\r\n};\r\n\r\napp.MapGet(\"/weatherforecast\", () =>\r\n{\r\n    var forecast = Enumerable.Range(1, 5).Select(index =>\r\n        new WeatherForecast\r\n        (\r\n            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),\r\n            Random.Shared.Next(-20, 55),\r\n            summaries[Random.Shared.Next(summaries.Length)]\r\n        ))\r\n        .ToArray();\r\n    return forecast;\r\n})\r\n.WithName(\"GetWeatherForecast\")\r\n.WithOpenApi();\r\n\r\ninternal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)\r\n{\r\n    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);\r\n}\r\n"
                                    },
                                    new Paragraph {
                                       Body = "Upon cleaning up, we will add two lines to support the use of controller. You can see them in the commented lines below. After the modifications your file should look like this:"
                                    },
                                    new Paragraph {
                                        IsCode = true,
                                        Body = "var builder = WebApplication.CreateBuilder(args);\r\n\r\nbuilder.Services.AddEndpointsApiExplorer(); //swagger\r\nbuilder.Services.AddSwaggerGen(); // swagger\r\nbuilder.Services.AddControllers(); //added code \r\n\r\nvar app = builder.Build();\r\n\r\nif (app.Environment.IsDevelopment())\r\n{\r\n    app.UseSwagger();\r\n    app.UseSwaggerUI();\r\n}\r\n\r\napp.MapControllers(); //added code\r\n\r\napp.Run();\r\n"
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Program.cs explained",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       Body = "Let's see what the code in <b>Program.cs</b> is doing:" },
                                    new Paragraph {
                                       Body = "<b>In line 1</b>, we create an instance of the <b>WebApplicationBuilder</b> class. This class is part of the new minimal API feature introduced in ASP.NET Core 6, which provides a simplified way to create lightweight web applications, particularly for building APIs." },
                                    new Paragraph {
                                       Body = "<b>In line 5</b>, builder.Services.AddControllers() sets up the necessary infrastructure for <b>handling HTTP requests</b> with controllers in an ASP.NET Core application. It's a critical step in configuring the application's behavior and enabling the implementation of RESTful APIs or web endpoints." },
                                     new Paragraph {
                                       Body = "<b>In line 15</b>, app.MapControllers() sets up routing and request handling. It integrates with the framework's routing and <b>middleware infrastructure</b> to provide a mechanism for building web APIs and web applications." },
                                     new Paragraph {
                                       Body = "<b>In lines 3,4 and 9 to 13</b> we can see the registration and configuration of Swagger, a UI that facilitates testing ASP.NET Core Web APIs without the need for external apps." },
                                }
                            },
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       BackgroundColor="#1C236D",
                                       FontColor="#FFF",
                                       Body = "You can find the code for the current state of this project <a href='https://github.com/TheCSharpAcademy/TCSA.Course.WebAPI.FlightData/tree/1.Creating-Project' target='_blank' style='color:white;'>in this link</a>." }
                                }
                            }
                        }
                    },
                    new Article
                    {
                        Id = 500052,
                        CourseDisplayId = 3,
                        Title = "Minimal APIs",
                        Slug = "asp-net-core-minimal-apis",
                        Description = "",
                        Area = Area.Course,
                        ExperiencePoints = 1,
                        Blocks = new List<Block>
                        {
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "When we created our project, we've chosen to untick the 'Add Controllers' box. This means that the initial template provided was for a <b>Minimal API</b> instead of traditional ASP.NET Core Web API." }
                                }
                            },
                            new Block
                            {
                                Title = "How are They Different?",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "Minimal APIs and traditional APIs in C# differ primarily in their structure and design philosophy. Minimal APIs, introduced in .NET 6, aim to simplify API development by <b>reducing boilerplate code</b>. They enable developers to create API endpoints with minimal configuration, often using a single file to define routes, services, and middleware. This approach contrasts with traditional APIs, where the use of controllers, multiple files, and a more layered architecture is common. The goal of minimal APIs is to speed up development, making it more accessible for <b>small projects or microservices that don't require the full features</b> of traditional ASP.NET Core."}
                                }
                            },
                            new Block
                            {
                                Title = "Traditional APIs",
                                Paragraphs = new List<Paragraph>
                                {
                                      new Paragraph { Body = "In traditional APIs, controllers are used to group related actions together, following the <b>Model-View-Controller (MVC)</b> pattern. Each controller inherits from <b>ControllerBase</b>, and routing is conventionally handled using attributes on methods. This approach offers a well-structured way to <b>separate concerns</b> and manage complex applications, making it <b>suitable for larger projects</b> where organization and modularity are key. Traditional APIs also support a rich set of features out of the box, such as model binding, validation, and filters, which help manage concerns like error handling and authorization." }
                                }
                            },
                            new Block
                            {
                                Title = "Minimal APIs",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       Body = "Minimal APIs, on the other hand, take a more functional approach, allowing developers to define routes <b>directly in the Program.cs</b> file or similar entry points. The use of <b>lambda expressions</b> for defining endpoints makes the syntax concise, but may sacrifice some of the organization and readability found in traditional controllers. Since minimal APIs do not rely on the MVC pattern, they are less opinionated about the application's structure, giving developers the freedom to set up the project as needed. This flexibility comes at the cost of some built-in features, though it is possible to manually add these as needed." }
                                }
                            },
                            new Block
                            {
                                Title = "Which One Should You Choose?",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       Body = "The decision to use minimal APIs or traditional APIs ultimately <b>depends on the project's requirements</b>. Minimal APIs are well-suited for simple or microservice-based applications, where rapid development and minimal configuration are priorities. In contrast, traditional APIs are a better choice for larger, enterprise-level applications where a more robust architecture and advanced features are necessary. It's important to notice that <b>both approaches can be present within the same application</b>, allowing developers to choose the appropriate style for different components of the project." }
                                }
                            }
                        }
                    },
                    new Article
                    {
                        Id = 500053,
                        CourseDisplayId = 4,
                        Title = "Installing Entity Framework",
                        Slug = "asp-net-core-minimal-ef-core",
                        Description = "",
                        Area = Area.Course,
                        ExperiencePoints = 1,
                        Blocks = new List<Block>
                        {
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "Entity Framework (EF) is an <b>Object-Relational Mapper (ORM)</b> that allows .NET developers to work with a database using <b>C# objects</b>. It eliminates the need for most of the data-access code that developers usually need to write. ASP.NET Core is a cross-platform, high-performance framework for building modern, cloud-based, internet-connected applications. When used together, Entity Framework Core and ASP.NET Core provide a powerful stack for building RESTful APIs. If you've never used Entity Framework before, we recommend you go through our <a href='https://www.thecsharpacademy.com/project/16/phonebook' target='_blank'>phone book project</a> to get acquainted. Learning EF and Web APIs at the same time might be overwhelming." }
                                }
                            },
                            new Block
                            {
                                Title = "EF in Our Curriculum",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "In the C# Academy curriculum we use ADO.NET in the \r\n<a href='https://www.thecsharpacademy.com/project/12/habit-logger' target='_blank'>Habit Logger</a> and Dapper in the \r\n<a href='https://www.thecsharpacademy.com/project/13/coding-tracker' target='_blank'>Coding Tracker</a> projects, before learning EF in the Phone Book app. This is because ADO.NET and Dapper give you more exposure to SQL, the language ultimately used by all data access solutions to communicate with databases."}
                                }
                            },
                            new Block
                            {
                                Title = "Sqlite",
                                Paragraphs = new List<Paragraph>
                                {
                                      new Paragraph { Body = "In this project we will use the <b>Sqlite database engine</b>. SQLite is a self-contained, serverless, zero-configuration, transactional SQL database engine. It is widely used for its simplicity and efficiency, making it an excellent choice for embedded systems, mobile applications, and small to medium-sized projects. Unlike traditional database management systems that require a separate server process, SQLite operates through a <b>single library that interacts directly with the database file</b>, which simplifies setup and administration, making it ideal for our course." },
                                      new Paragraph { Body = "SQLite stores the entire database, including tables, indexes, and the data itself, <b>in a single file</b>, enhancing portability and ease of use. It supports most of the SQL standard, including transactions, joins, views, and triggers, providing rich functionality without the overhead of a more complex system." }
                                },
                            },
                            new Block
                            {
                                Title = "NuGet Packages",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       Body = "To use EF in our project we've installed the following packages:<br>➡️<b>Microsoft.EntityFrameworkCore.Design</b>: Provides design-time tools for scaffolding and migrations.<br>➡️<b>Microsoft.EntityFrameworkCore.Sqlite</b>: Enables the use of SQLite as the database engine in EF Core.<br>➡️<b>Microsoft.EntityFrameworkCore.Tools</b>: Includes command-line tools for managing database migrations and schema updates." }
                                }
                            },
                            new Block
                            {
                                Title = "In a new folder called Data, create a new class called FlightsDbContext with the following code:",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       IsCode = true,
                                       Body = "public class FlightsDbContext: DbContext\r\n    {\r\n        public FlightsDbContext(DbContextOptions options) : base(options)\r\n        {\r\n            \r\n        }\r\n    }" },
                                    new Paragraph {
                                       Body = "<b>FlightsDbContext : DbContext</b>. This means our class inherits from DbContext class, which is part of the EF Core library and represents a session with the database, enabling querying and saving of data." },
                                    new Paragraph {
                                       Body = "<b>public FlightsDbContext(DbContextOptions options) : base(options)</b>. This is a constructor for the FlightsDbContext class. It takes a parameter of type DbContextOptions and passes it to the base class constructor (DbContext) using the <b>base(options)</b> call. This means we're implementing the constructor of the class we're inherting from." },
                                     new Paragraph {
                                       Body = "<b>DbContextOptions Parameter</b>: This class is used to configure the DbContext. It typically includes settings such as the database provider, connection string, and other configuration options." },
                                    new Paragraph {
                                       Body = "The call to <b>base(options)</b> in the constructor is crucial. It passes the configuration options up to the DbContext base class so that the EF Core can use these options to <b>set up the database context </b>appropriately." }
                                },
                            },
                            new Block{
                                Title = "Connection string",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "Before connecting to the database we have to add a connection string to <b>appsettings.json</b> file."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "{\r\n   \"ConnectionStrings\": {\r\n        \"DefaultConnection\": \"Data Source=Flights.db\"\r\n   },\r\n  \"Logging\":{\r\n   //ommited for brevity...\r\n}"
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Program.cs",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       IsCode = true,
                                       Body = "var builder = WebApplication.CreateBuilder(args);\r\n\r\nbuilder.Services.AddEndpointsApiExplorer();\r\nbuilder.Services.AddSwaggerGen();\r\nbuilder.Services.AddControllers();\r\n\r\n//NEW \r\nbuilder.Services.AddDbContext&lt;FlightsDbContext&gt(opt => opt.UseSqlite(builder.Configuration.GetConnectionString(\"DefaultConnection\")));\r\n\r\nvar app = builder.Build();\r\n\r\nif (app.Environment.IsDevelopment())\r\n{\r\n    app.UseSwagger();\r\n    app.UseSwaggerUI();\r\n}\r\n\r\napp.MapControllers();\r\n\r\napp.Run();" },
                                    new Paragraph {
                                       Body = "<b>AddDbContext()</b> adds the FlightsDbContext to the <b>Dependency Injection container</b>, making it available for injection into controllers and other services where it’s needed." },
                                     new Paragraph {
                                       Body = "<b>opt => opt.UseSqlite(...):</b> This part is a lambda expression used to configure options for the FlightsDbContext class. The opt parameter represents an instance of DbContextOptionsBuilder, which we've seen when creating the context." },
                                      new Paragraph {
                                       Body = "<b>UseSqlite()</b> configures FlightsDbContext to use SQLite as its database provider, using the connection string obtained in <b>appsettings.json</b>" },
                                       new Paragraph {
                                       Body = "With this in place we have everything we need to start creating our API with the help of EF Core!" }
                                }
                            },
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       BackgroundColor="#1C236D",
                                       FontColor="#FFF",
                                       Body = "You can find the code for the current state of this project <a href='https://github.com/TheCSharpAcademy/TCSA.Course.WebAPI.FlightData/tree/2.Installing-Entity-Framework' target='_blank' style='color:white;'>in this link</a>." }
                                }
                            }
                        }
                    },
                    new Article
                    {
                        Id = 500054,
                        CourseDisplayId = 5,
                        Title = "Code-First Approach",
                        Slug = "ef-core-code-first",
                        Description = "",
                        Area = Area.Course,
                        ExperiencePoints = 1,
                        Blocks = new List<Block>
                        {
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "EF Core follows a <b>code-first approach</b>, where you define your <b>data model</b> using C# classes (your entity classes) and then generate the corresponding database schema from those classes. When you <b>run a migration</b>, Entity Framework Core compares the current state of your entity classes to the previous state (recorded in the migration history) to determine what changes need to be made to the database schema to bring it in sync with the current state of your entity classes." },
                                    new Paragraph { Body = "An alternative would be the <b>database-first approach</b> where you begin with an existing database schema that has been designed and implemented independently of EF Core." }
                                },

                            },
                            new Block
                            {
                                Title = "DbSet",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                        Body = "In our DbContext we will use a <b>DbSet&lt;T&gt</b> class <b>(line 8)</b>, which is used for interactions with the database. The use of 'T' indicates a <b>generic type</b> parameter that allows DbSet to work with any specific type of entity in a strongly-typed manner. In this case we will be working with the <b>Flight</b> custom type we'll define next."
                                    },
                                    new Paragraph {
                                        IsCode = true,
                                        Body = "public class FlightsDbContext: DbContext\r\n    {\r\n        public FlightsDbContext(DbContextOptions options) : base(options)\r\n        {\r\n            \r\n        }\r\n\r\n        public DbSet&lt;Flight&gt Flights { get; set; }\r\n    }"
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Flight Model",
                                Paragraphs = new List<Paragraph>
                                {
                                      new Paragraph { Body = "Next create a class called Flight inside a new folder called Models, with the following code:" },
                                      new Paragraph {
                                          IsCode = true,
                                          Body = "public class Flight\r\n{\r\n    public int Id { get; set; }\r\n    public int FlightNumber { get; set; }\r\n    public string AirlineName { get; set; } = string.Empty;\r\n    public string DepartureAirportCode { get; set; } = string.Empty;\r\n    public string ArrivalAirportCode { get; set; } = string.Empty;\r\n    public DateTime DepartureDateTime { get; set; }\r\n    public DateTime ArrivalDateTime { get; set; }\r\n    public int PassengerCapacity { get; set; }\r\n}"
                                      },
                                       new Paragraph { Body = "This class represents a <b>flight in the database</b>, and each of these properties correspond to a column in the Flights table." },
                                        new Paragraph { Body = "If you've never used a Model before in C#, we recommend <a href='https://www.thecsharpacademy.com/course/1/article/1/500025/false' target='_blank'>you do our Object Oriented Programming Crash Course</a> first. You might need to close some knowledge gaps before learning about Web APIs." },
                                },
                            },
                            new Block
                            {
                                Title = "String.Empty",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       Body = "Initializing strings with <b>string.Empty</b> instead of null or an empty string literal (\"\") offers several benefits. First, it provides clarity and intent, making it explicit that the string is intended to be empty, which enhances code readability and reduces ambiguity. Second, it establishes consistency across the codebase, making the code easier to understand and maintain. Third, it helps avoid null reference exceptions by ensuring that the string reference is never null, making the code more reliable." }
                                }
                            },
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       BackgroundColor="#1C236D",
                                       FontColor="#FFF",
                                       Body = "You can find the code for the current state of this project <a href='https://github.com/TheCSharpAcademy/TCSA.Course.WebAPI.FlightData/tree/3.Code-First-Approach' target='_blank' style='color:white;'>in this link</a>." }
                                }
                            }
                        }
                    },
                    new Article
                    {
                        Id = 500055,
                        CourseDisplayId = 6,
                        Title = "First Migration",
                        Slug = "ef-core-first-migration",
                        Description = "",
                        Area = Area.Course,
                        ExperiencePoints = 1,
                        Blocks = new List<Block>
                        {
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "A migration in EF Core is a way to apply incremental changes to your database schema based on changes to your data model. Migrations allow you to evolve your database schema over time, <b>keeping it in sync with the application’s data model</b> while preserving the existing data." },
                                    new Paragraph { Body = "They provide a systematic and controlled way to manage database schema changes over the lifecycle of an application. By capturing and applying schema changes incrementally, migrations help ensure that the database remains coherent with the code changes, supporting ongoing development and deployment processes" }
                                },

                            },
                            new Block
                            {
                                Title = "Entity Framework Command Line Tool",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                        Body = "The command-line tool is a utility that assists with managing EF Core tasks in .NET projects. It specifically helps with tasks related to database schema management and migrations, from the command line."
                                    },
                                    new Paragraph {
                                        Body = "This is the tool of choice for Visual Studio Code users. Visual Studio programmers can also use the command line tool but have the option to use the <b>NuGet Package Manager Console</b>. Keep in mind that the commands differ from one to the other."
                                    },
                                    new Paragraph {
                                        Body = "If using the command line, run the following commands to install the tool, add your first migration inside a <b>Data/Migrations</b> directory and update the database accordingly."
                                    },
                                    new Paragraph {
                                          IsCode = true,
                                          Body = "dotnet tool install dotnet-ef --global\r\ndotnet ef migrations add InitialCreate -o Data/Migrations\r\ndotnet ef database update"
                                      },
                                     new Paragraph {
                                        Body = "If using the Package Manager in Visual Studio, run the following commands."
                                    },
                                    new Paragraph {
                                          IsCode = true,
                                          Body = "Add-Migration InitialCreate\r\nUpdate-Database"
                                      },
                                    new Paragraph {
                                        Body = "When running your first migration you'll see the following code in the terminal:"
                                    },
                                    new Paragraph {
                                          IsPicture = true,
                                          PictureUrl = "c3-ch6-webapis-migration.png"
                                      },
                                     new Paragraph {
                                        Body = "This is because EF commands ultimately <b>translate into SQL</b>. When you run a migration command (such as dotnet ef database update), EF Core logs the SQL commands being executed against the database. This helps you understand what changes are being applied to the database schema and troubleshoot any issues that may arise during migration execution."
                                    },
                                }
                            },
                            new Block
                            {
                                Title = "Migration Files",
                                Paragraphs = new List<Paragraph>
                                {
                                      new Paragraph { Body = "Upon creating our migration, the following files were generated:" },
                                      new Paragraph {
                                          IsPicture = true,
                                          PictureUrl = "c3-ch6-webapis-migration-files-db.png"
                                      },
                                       new Paragraph { Body = "<b>These auto-generated files should be left alone</b>. Editing this file manually can lead to inconsistencies between your code and the database schema. EF Core uses the information in these to generate SQL scripts for applying and rolling back migrations. About these files:" },
                                        new Paragraph {
                                       Body = "➡️ <b>20241027111757_initial:</b> Contains C# code representing the migration. The name of the file is a combination of the the migration's name and the timestamp of the moment of its creation."
                                    },
                                    new Paragraph {
                                       Body = "➡️ <b>FlightsDbContextModelSnapshot</b>: Captures the current state of the data model."
                                    }
                                },
                            },
                            new Block
                            {
                                Title = "Database File",
                                Paragraphs = new List<Paragraph>
                                {
                                      new Paragraph { Body = "In the picture above we can also see a <b>Flights.db</b> file. This is an Sqlite database file. You can visualise its contents using an external app such as <a href='https://www.thecsharpacademy.com/course/1/article/1/0/false' target='_blank'>DB Browser</a>." },
                                      new Paragraph { Body = "Then open the file using Db Browser. You should see the created tables:" },
                                      new Paragraph {
                                          IsPicture = true,
                                          PictureUrl = "c3-ch6-webapis-db-file.png"
                                      },
                                       new Paragraph { Body = "Examine the Flight table's columns. The <b>__EFMigrationsHistory</b> table simply keeps a history of the migrations." }
                                },
                            },
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       BackgroundColor="#1C236D",
                                       FontColor="#FFF",
                                       Body = "You can find the code for the current state of this project <a href='https://github.com/TheCSharpAcademy/TCSA.Course.WebAPI.FlightData/tree/3.Code-First-Approach' target='_blank' style='color:white;'>in this link</a>." }
                                }
                            }
                        }
                    },
                    new Article
                    {
                        Id = 500056,
                        CourseDisplayId = 7,
                        Title = "Flight Service",
                        Slug = "web-api-flight-service",
                        Description = "",
                        Area = Area.Course,
                        ExperiencePoints = 1,
                        Blocks = new List<Block>
                        {
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "In ASP.NET Core, a service is a class that will be <b>available throughout the application's lifetime</b>. Services in ASP.NET Core are typically added using <b>dependency injection (DI)</b>, allowing you to inject them where needed, which makes the code modular and testable." }
                                },

                            },
                            new Block
                            {
                                Title = "Dependency Inversion",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                        Body = "An <b>interface</b> in programming is a way to define a contract or a set of rules that a class must follow. It's like a blueprint for classes, specifying what methods should be implemented, but typically it doesn't provide the implementation details itself. If you haven't worked with C# interfaces before, we recommend <a href='https://www.thecsharpacademy.com/course/1/article/1/500025/false' target='_blank'>you do our Object Oriented Programming Crash Course</a>."
                                    },
                                    new Paragraph {
                                        Body = "Although <a href='https://stackoverflow.com/questions/6802573/interfaces-whats-the-point' target='_blank'>there's a lot of debate about the necessity and importance of using interfaces</a>, it can't be disputed that they are an important part of C# design, being applied in several design patterns. In our app we will be using the <b>Dependency Inversion Principle (DIP)</b>, which is one of the five <b>SOLID principles</b> of object-oriented programming."
                                    },
                                    new Paragraph {
                                        Body = "The DIP states that <b>high-level modules should not depend on low-level modules</b>, but both should depend on abstractions. In your example, FlightService depends on the abstraction provided by the IFlightService interface rather than directly on concrete implementations."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "IFlightService",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "Let's create a new class called FlightService, inside a new <b>Services folder</b>. Above the class declaration, declare the following interface:" },
                                      new Paragraph {
                                          IsCode = true,
                                          Body = "public interface IFlightService\r\n    {\r\n        public List&lt;Flight&gt GetAllFlights();\r\n        public Flight? GetFlightById(int id);\r\n        public Flight CreateFlight(Flight flight);\r\n        public Flight UpdateFlight(int id, Flight updatedFlight);\r\n        public string? DeleteFlight(int id);\r\n    }" },
                                       new Paragraph { Body = "This interface <b>serves as a contract</b> defining the functionality that any class implementing IFlightService must provide. It allows for different implementations of flight-related services while ensuring consistency in the methods exposed by those implementations. In this specific case, we're using methods for executing <b>CRUD (Create, Read, Update, Delete) operations</b> against a data table. " }
                                },
                            },
                             new Block
                            {
                                Title = "Flight Service",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       Body = "Now let's declare that FlightService inherits from the interface. Modify FlightService using the following:"
                                    },
                                     new Paragraph {
                                         IsCode = true,
                                         Body = "    public class FlightService : IFlightService\r\n    { \r\n        private readonly FlightsDbContext _dbContext;\r\n\r\n        public FlightService(FlightsDbContext dbContext)\r\n        {\r\n            _dbContext = dbContext;\r\n        }\r\n    }" },
                                     new Paragraph {
                                       Body = "In this snippet we're using Dependency Injection. DbContext is <b>injected via the constructor</b>, making it available for any method in the scope of the class."
                                    },
                                },
                            },
                            new Block
                            {
                                Title = "Service Registration",
                                Paragraphs = new List<Paragraph>
                                {
                                      new Paragraph { Body = "In Program.cs, let's register FlightService in the <b>Dependency Injection Container</b>, in line 7:" },
                                      new Paragraph {
                                          IsCode = true,
                                          Body = "var builder = WebApplication.CreateBuilder(args);\r\n\r\nbuilder.Services.AddEndpointsApiExplorer();\r\nbuilder.Services.AddSwaggerGen();\r\nbuilder.Services.AddControllers();\r\nbuilder.Services.AddDbContext<FlightsDbContext>(opt => opt.UseSqlite(builder.Configuration.GetConnectionString(\"DefaultConnection\")));\r\nbuilder.Services.AddScoped&lt;IFlightService, FlightService&gt();\r\n\r\nvar app = builder.Build();\r\n" },
                                },
                            },
                             new Block
                            {
                                Title = "Service Lifetimes",
                                Paragraphs = new List<Paragraph>
                                {
                                      new Paragraph { Body = "When registering our FlightService, we are using the <b>AddScoped</b> method. Let's have a quick look at Service Lifetimes in ASP.NET Core:" },
                                      new Paragraph { Body = "➡️ <b>Scoped (AddScoped)</b>: A new instance of the service is created once per request within the scope. In a web application, a scope is typically a single HTTP request." },
                                      new Paragraph { Body = "➡️ <b>Singleton (AddSingleton)</b>: A single instance of the service is created and shared throughout the application's lifetime." },
                                      new Paragraph { Body = "➡️ <b>Transient (AddTransient)</b>: A new instance of the service is created each time it is requested." },
                                      new Paragraph { Body = "<b>Scoped lifetime is recommended for Entity Framework (EF) DbContext</b> in ASP.NET Core applications primarily to ensure that the DbContext instance is <b>used within a single request</b> and disposed of properly after the request is completed. This ensures proper resource management, prevents concurrency issues, and leverages EF's change tracking and caching mechanisms efficiently." },
                                },
                            },
                             new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       BackgroundColor="#1C236D",
                                       FontColor="#FFF",
                                       Body = "You can find the code for the current state of this project <a href='https://github.com/TheCSharpAcademy/TCSA.Course.WebAPI.FlightData/tree/4.Flight-Service' target='_blank' style='color:white;'>in this link</a>." }
                                }
                            }
                        }
                    },
                    new Article
                    {
                        Id = 500057,
                        CourseDisplayId = 8,
                        Title = "Service Implementation",
                        Slug = "web-api-service-implementation",
                        Description = "",
                        Area = Area.Course,
                        ExperiencePoints = 1,
                        Blocks = new List<Block>
                        {
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                     new Paragraph { Body = "In FlightsService, under the constructor, let's implement the method for creation of a flight:" },
                                    new Paragraph {
                                        IsCode = true,
                                        Body = "public Flight Createflight(Flight flight)\r\n    {\r\n        var savedFlight = _dbContext.Flights.Add(flight);\r\n        _dbContext.SaveChanges();\r\n        return savedFlight.Entity;\r\n    }"
                                    },
                                    new Paragraph { Body = "In CreateFlight we're adding a flight to the table. The <b>Add() method</b> adds the entity to the context, but it doesn't immediately send the command to the database. Instead, it stages the entity to be added to the database when <b>SaveChanges</b> is called. The object returned by this operation is <b>EntityEntry&lt;Flight&gt</b> and represents the entity (Flight) being tracked by the DbContext. It provides access to information about the entity and its state within the context. This includes properties such as Entity, which represents the entity itself, and various methods and properties for working with the entity's state, tracking changes, etc." },
                                },

                            },
                            new Block
                            {
                                Title = "Delete Flight",
                                Paragraphs = new List<Paragraph>
                                {
                                      new Paragraph {
                                          IsCode = true,
                                          Body = "public string? DeleteFlight(int id)\r\n    {\r\n        Flight savedFlight = _dbContext.Flights.Find(id);\r\n\r\n        if (savedFlight == null)\r\n        {\r\n            return null;\r\n        }\r\n\r\n        _dbContext.Flights.Remove(savedFlight);\r\n        _dbContext.SaveChanges();\r\n\r\n        return $\"Successfully deleted flight with id: {id}\";\r\n    }" },
                                       new Paragraph { Body = "When deleting a flight we first check if it exists. If it doesn't we return null and let the caller deal with it. We then return a meaningful message in case the operation is successful." }
                                },
                            },
                             new Block
                            {
                                Title = "Get All Flights",
                                Paragraphs = new List<Paragraph>
                                {
                                     new Paragraph {
                                         IsCode = true,
                                         Body = "public List&lt;Flight&gt GetAllFlights()\r\n    {\r\n        return _dbContext.Flights.ToList();\r\n    }" },
                                     new Paragraph {
                                       Body = "This implementation is self-explanatory. However, it's important to note that calling ToList() in GetAllFlights executes the query <b>immediately and loads all data into memory</b>, which might not be efficient for large datasets. We'll show how to deal with issue later in the course"
                                    },
                                },
                            },
                             new Block
                            {
                                Title = "Get Flight by Id",
                                Paragraphs = new List<Paragraph>
                                {
                                     new Paragraph {
                                         IsCode = true,
                                         Body = "public Flight? GetFlightById(int id)\r\n    {\r\n        Flight savedFlight = _dbContext.Flights.Find(id);\r\n        return savedFlight;\r\n    }" },
                                     new Paragraph {
                                       Body = "Here we're looking for a Flight with the id provided and the entity is returned which can be null if it's not found."
                                    },
                                },
                            },
                            new Block
                            {
                                Title = "Update Flight",
                                Paragraphs = new List<Paragraph>
                                {
                                      new Paragraph {
                                          IsCode = true,
                                          Body = "public Flight UpdateFlight(int id, Flight flight)\r\n    {\r\n        Flight savedFlight = _dbContext.Flights.Find(id);\r\n\r\n        if (savedFlight == null)\r\n        {\r\n            return null;\r\n        }\r\n\r\n        _dbContext.Entry(savedFlight).CurrentValues.SetValues(flight);\r\n        _dbContext.SaveChanges();\r\n\r\n        return savedFlight;\r\n    }" },
                                       new Paragraph {
                                           Body = "Similarly to GetFlightById(), we're looking for a flight with the given id, returning null if none is found. <b>Context.Entry(savedFlight)</b> gets the DbEntityEntry for savedFlight, which represents its entry in the Entity Framework context. <b>CurrentValues.SetValues(flight)</b> copies the properties from the provided flight object into savedFlight. Essentially, this line takes all values from flight and updates savedFlight with those values."
                                       },
                                },
                            },
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       BackgroundColor="#1C236D",
                                       FontColor="#FFF",
                                       Body = "You can find the code for the current state of this project <a href='https://github.com/TheCSharpAcademy/TCSA.Course.WebAPI.FlightData/tree/4.Flight-Service' target='_blank' style='color:white;'>in this link</a>." }
                                }
                            }
                        }
                    },
                    new Article
                    {
                        Id = 500058,
                        CourseDisplayId = 9,
                        Title = "Flights Controller",
                        Slug = "web-api-controller",
                        Description = "",
                        Area = Area.Course,
                        ExperiencePoints = 1,
                        Blocks = new List<Block>
                        {
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "In ASP.NET Core Web API, controllers are essential components that <b>handle incoming HTTP requests and generate responses</b>. They are part of the MVC (Model-View-Controller) architecture, where they serve as the \"C\" or the controller layer. A controller class is typically derived from ControllerBase and decorated with attributes to define routes and actions." },
                                },
                            },
                            new Block
                            {
                                Title = "Flights Controller",
                                Paragraphs = new List<Paragraph>
                                {
                                     new Paragraph {
                                         Body = "In a new <b>Controllers folder</b> create a <b>FlightsController</b> class with the following code:"
                                     },
                                      new Paragraph {
                                          IsCode = true,
                                          Body = "    [ApiController]\r\n    [Route(\"api/[controller]\")]\r\n    //example: http://localhost:5609/api/flight/\r\n    public class FlightsController : ControllerBase\r\n    {\r\n        private readonly IFlightService _flightService;\r\n        public FlightController(IFlightService flightService)\r\n        {\r\n            _flightService = flightService;\r\n        }\r\n    }" },
                                       new Paragraph {
                                         Body = "The <b>[Route(\"api/[controller]\")]</b> attribute specifies the routing pattern for the controller. The <b>[controller]</b> placeholder is replaced with the name of the controller, minus the \"Controller\" suffix. So, for FlightController, the route becomes <b>api/flight</b>. We'll expand on the subject of routing later in this lesson."
                                     },
                                        new Paragraph {
                                         Body = "<b>ControllerBase</b> serves as a base class from which your API controllers can derive. It provides a range of functionalities and helper methods that make it easier to handle HTTP requests and responses."
                                     },
                                        new Paragraph {
                                         Body = "Similarly to FlightService, where we inject the DBContext, here we're injecting the FlightService through Dependency Injection <b>via the constructor</b>."
                                     },
                                }
                            },
                            new Block
                            {
                                Title = "Routing",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       Body = "Routing in ASP.NET Core is a powerful mechanism for <b>mapping HTTP requests</b> to the corresponding controller actions. It defines how URL paths are matched to actions in your controllers. There are multiple ways to configure routing, each suitable for different scenarios. Below is a quick overview of the routing system in ASP.NET Core:"
                                    },
                                     new Paragraph {
                                       Body = "<b>Attribute routing</b> uses attributes to define routes directly on controller actions. This approach offers fine-grained control over the routes and is highly readable and maintainable. This is the type we're using in this tutorial."
                                    },
                                      new Paragraph {
                                       Body = "<b>Convention-Based Routing</b> is configured in the Program.cs file, typically using the <b>UseEndpoints</b> method. This method allows you to define a global routing scheme that applies to all controllers"
                                    },
                                       new Paragraph {
                                       Body = "<b>Attribute routing and convention-based routing can be combined</b> within the same application. This allows you to use convention-based routing for general routes and attribute routing for more specific cases."
                                    },
                                        new Paragraph {
                                       Body = "<b>Endpoint Routing</b>, introduced in ASP.NET Core 3.0, is a unified routing system that allows you to define routes using middleware. It provides better performance and more flexibility."
                                    },
                                         new Paragraph {
                                       Body = "<b>Route parameters</b> allow you to capture values from the URL and pass them to controller actions. Example: In the route <b>api/products/{id}</b>, {id} is a route parameter that captures the product ID from the URL."
                                    },
                                          new Paragraph {
                                       Body = "<b>Route constraints</b> restrict how URL parameters can be matched. Constraints are specified in the route template. Example: In the route <b>api/products/{id:int}</b>, :int is a route constraint that specifies the id parameter must be an integer."
                                    },
                                           new Paragraph {
                                       Body = "<b>Custom route handlers</b> can be created for advanced routing scenarios where the built-in routing mechanisms are not sufficient. An example would entail the creation of a class that implements the <b>IRouter</b> interface. This interface defines methods for routing HTTP requests. Custom handlers are out of the scope of this course."
                                    },

                                    new Paragraph {
                                       Body = "Don't worry about memorizing the above. It's just important to keep in mind that although we'll be using attribute routing, you might come across these other approaches in tutorials or when studying other ASP.NET Core Web APIs."
                                    },
                                },
                            }
                        }
                    },
                    new Article
                    {
                        Id = 500059,
                        CourseDisplayId = 10,
                        Title = "Endpoints",
                        Slug = "web-api-endpoints",
                        Description = "",
                        Area = Area.Course,
                        ExperiencePoints = 1,
                        Blocks = new List<Block>
                        {
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                     new Paragraph {
                                         Body = "Endpoints are <b>specific paths in an API</b> that allow clients to interact with the server. Each endpoint is associated with a specific HTTP method (e.g., GET, POST, PUT, DELETE) and a URL path. In the context of a web API, <b>endpoints are the points of interaction where clients can make requests to the server</b> to perform various operations such as retrieving data, creating new entries, updating existing entries, or deleting entries. In FlightsController.cs, after the constructor, add these endpoints:"
                                     },
                                      new Paragraph {
                                          IsCode = true,
                                          Body = " [HttpGet]\r\n        public ActionResult&lt;List&lt;Flight&gt&gt GetAllFlights()\r\n        {\r\n            return Ok(_flightService.GetAllFlights());\r\n        }\r\n\r\n        [HttpGet(\"{id}\")]\r\n        public ActionResult&lt;Flight&gt GetFlightById(int id)\r\n        {\r\n            return Ok(_flightService.GetFlightById(id));\r\n        }\r\n\r\n        [HttpPost]\r\n        public ActionResult&lt;Flight&gt CreateFlight(Flight flight) \r\n        {\r\n            return Ok(_flightService.CreateFlight(flight));\r\n        }\r\n\r\n        [HttpPut(\"{id}\")]\r\n        public ActionResult&lt;Flight&gt UpdateFlight(int id, Flight updatedFlight) \r\n        {\r\n             return Ok(_flightService.UpdateFlight(id, updatedFlight));    \r\n        }\r\n\r\n        [HttpDelete(\"{id}\")]\r\n        public ActionResult&lt;string&gt DeleteFlight (int id) \r\n        {\r\n             return Ok(_flightService.DeleteFlight(id));\r\n        }" },
                                        new Paragraph {
                                         Body = "<b>GetAllFlights:</b> <span style='color:blue'>URL Path: /api/flights</span> . This endpoint retrieves a list of all flights. It uses the HttpGet attribute, meaning it handles GET requests. Returns an <b>HTTP 200 OK</b> response with a list of Flight objects."
                                     },
                                         new Paragraph {
                                         Body = "<b>DeleteFlight</b>: <span style='color:blue'>URL Path: /api/flights/{id}</span>. Deletes a specific flight by its ID. Handles DELETE requests with an ID parameter. The method returns an HTTP 200 OK response with a message indicating the deletion status."
                                     },
                                          new Paragraph {
                                         Body = "<b>GetFlightById</b>: <span style='color:blue'>URL Path: /api/flights/{id}</span>. Retrieves a specific flight by its ID. Handles GET requests with an ID parameter. The method returns an <b>HTTP 200 OK</b> response with the Flight object corresponding to the given ID."
                                     },
                                           new Paragraph {
                                         Body = "<b>CreateFlight</b>: <span style='color:blue'>URL Path: /api/flights</span> Creates a new flight. Handles POST requests. The method takes a Flight object as input and returns an <b>HTTP 200 OK</b> response with the created Flight object."
                                     },
                                            new Paragraph {
                                         Body = "<b>UpdateFlight</b>: <span style='color:blue'>URL Path: /api/flights/{id}</span>. Updates an existing flight by its ID. Handles PUT requests with an ID parameter. The method takes an ID and an updated Flight object as input, and returns an <b>HTTP 200 OK</b> response with the updated Flight object."
                                     }
                                }
                            },
                            new Block
                            {
                                Title = "ActionResult",
                                Paragraphs = new List<Paragraph>
                                {
                                       new Paragraph {
                                         Body = "In ASP.NET Core, the ActionResult type is used in controller actions to <b>represent various HTTP responses</b> returned to clients. Controllers in ASP.NET Core act as intermediaries, handling client requests and determining the appropriate responses. When using ActionResult, developers can return a range of HTTP status codes and payloads, helping clients understand the request's success or failure."
                                     },
                                        new Paragraph {
                                         Body = "The <b>ActionResult&lt;T&gt</b> type allows developers to specify a more descriptive response by using a generic type, like ActionResult&lt;Flight&gt. In the example, ActionResult&lt;List&lt;Flight&gt&gt and ActionResult&lt;Flight&gt indicate that the expected result is a List&lt;Flight&gt or a single Flight object, respectively, wrapped in an <b>HTTP response</b>. When a controller action returns Ok(), it sends a <b>200 OK status code</b> along with the specified object. This approach is beneficial for API design because it not only informs clients of the successful response but also provides the requested data in a straightforward, expected structure."
                                     }
                                }
                            },
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       BackgroundColor="#1C236D",
                                       FontColor="#FFF",
                                       Body = "You can find the code for the current state of this project <a href='https://github.com/TheCSharpAcademy/TCSA.Course.WebAPI.FlightData/tree/5.Flight-Controller' target='_blank' style='color:white;'>in this link</a>." }
                                }
                            }
                        }
                    },
                    new Article
                    {
                        Id = 500060,
                        CourseDisplayId = 11,
                        Title = "Response Codes",
                        Slug = "web-api-response-codes",
                        Description = "",
                        Area = Area.Course,
                        ExperiencePoints = 1,
                        Blocks = new List<Block>
                        {
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                     new Paragraph {
                                         Body = "Response codes in web APIs, often referred to as HTTP status codes, are <b>three-digit numbers returned by servers to indicate the result</b> of a client's request. These codes are standardized by the Internet Engineering Task Force (IETF) and are an integral part of the HTTP protocol. They help the client understand the outcome of the request and act accordingly. Here’s an overview of the main categories and some common codes within each:"
                                     }
                                }
                            },
                            new Block
                            {
                                Title = "Informational",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                         Body = "These codes indicate that the server has received the request and is continuing the process:"
                                     },
                                       new Paragraph {
                                         Body = "<b>100 Continue:</b> The server has received the request headers, and the client should proceed to send the request body."
                                     },
                                        new Paragraph {
                                         Body = "<b>101 Switching Protocols:</b> The server is switching protocols as requested by the client."
                                     }
                                }
                            },
                            new Block
                            {
                                Title = "Success",
                                Paragraphs = new List<Paragraph>
                                {
                                       new Paragraph {
                                         Body = "These codes signify that the client's request was successfully received, understood, and accepted:"
                                     },
                                        new Paragraph {
                                         Body = "<b>200 OK</b>: The request was successful, and the server returned the requested resource."
                                     },
                                        new Paragraph {
                                         Body = "<b>201 Created</b>: The request was successful, and a new resource was created as a result."
                                     },
                                        new Paragraph {
                                         Body = "<b>204 No Content</b>: The request was successful, but there is no content to send in the response."
                                     }
                                }
                            },
                            new Block
                            {
                                Title = "Redirection",
                                Paragraphs = new List<Paragraph>
                                {
                                       new Paragraph {
                                         Body = "These codes indicate that further action is needed to complete the request:"
                                     },
                                        new Paragraph {
                                         Body = "<b>301 Moved Permanently</b>: The requested resource has been permanently moved to a new URL."
                                     },
                                        new Paragraph {
                                         Body = "<b>302 Found</b>: The requested resource resides temporarily under a different URL."
                                     },
                                        new Paragraph {
                                         Body = "<b>304 Not Modified</b>: The resource has not been modified since the last request, so the client can use a cached version."
                                     }
                                }
                            },
                            new Block
                            {
                                Title = "Client Errors",
                                Paragraphs = new List<Paragraph>
                                {
                                       new Paragraph {
                                         Body = "These codes indicate that there was an error with the request from the client’s side:"
                                     },
                                        new Paragraph {
                                         Body = "<b>400 Bad Request</b>: The server could not understand the request due to invalid syntax."
                                     },
                                         new Paragraph {
                                         Body = "<b>401 Not Authorized</b>: The client must authenticate itself to get the requested response."
                                     },
                                        new Paragraph {
                                         Body = "<b>403 Forbidden</b>: The client does not have access rights to the content."
                                     },
                                        new Paragraph {
                                         Body = "<b>404 Not Found</b>: The server cannot find the requested resource."
                                     },
                                        new Paragraph {
                                         Body = "<b>405 Method Not Allowed</b>: The request method is known by the server but has been disabled and cannot be used."
                                     }
                                }
                            },
                            new Block
                            {
                                Title = "Server Errors",
                                Paragraphs = new List<Paragraph>
                                {
                                       new Paragraph {
                                         Body = "These codes indicate that the server failed to fulfill a valid request:"
                                     },
                                        new Paragraph {
                                         Body = "<b>500 Internal Server Error</b>: The server encountered an unexpected condition that prevented it from fulfilling the request."
                                     },
                                        new Paragraph {
                                         Body = "<b>501 Not Implemented</b>: The server does not support the functionality required to fulfill the request."
                                     },
                                        new Paragraph {
                                         Body = "<b>502 Bad Gateway</b>: The server, while acting as a gateway or proxy, received an invalid response from the upstream server."
                                     },
                                        new Paragraph {
                                         Body = "<b>503 Service Unavailable</b>: The server is not ready to handle the request, often due to being overloaded or down for maintenance."
                                     },
                                        new Paragraph {
                                         Body = "Here's a list of <a href='https://developer.mozilla.org/en-US/docs/Web/HTTP/Status' target='_blank'>all HTTP response status codes</a>"
                                     },

                                }
                            },
                            new Block
                            {
                                Title = "Using 404 Not Found",
                                Paragraphs = new List<Paragraph>
                                {
                                       new Paragraph {
                                         Body = "Let's apply our knowledge of response codes with a small modification in our controller. Modify the following endpoints to return a Not Found response when the requested flight isn't found:"
                                     },
                                        new Paragraph {
                                         IsCode = true,
                                         Body = "    [HttpGet(\"{id}\")]\r\n    public ActionResult&lt;Flight&gt GetFlightById(int id)\r\n    {\r\n        var result = _flightService.GetFlightById(id);\r\n\r\n        if (result == null)\r\n        {\r\n            return NotFound();\r\n        }\r\n\r\n        return Ok(result);\r\n    }\r\n\r\n\r\n    [HttpPut]\r\n    public ActionResult&lt;Flight&gt UpdateFlight(int id, Flight updatedFlight)\r\n    {\r\n        var result = _flightService.UpdateFlight(id, updatedFlight);\r\n\r\n        if (result == null)\r\n        {\r\n            return NotFound();\r\n        }\r\n\r\n        return Ok(result);\r\n    }\r\n\r\n    [HttpDelete(\"{id}\")]\r\n    public ActionResult&lt;Flight&gt DeleteFlight(int id)\r\n    {\r\n        var result = _flightService.DeleteFlight(id);\r\n\r\n        if (result == null)\r\n        {\r\n            return NotFound();\r\n        }\r\n\r\n        return Ok(result);\r\n    }"
                                     }
                                }
                            },
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       BackgroundColor="#1C236D",
                                       FontColor="#FFF",
                                       Body = "You can find the code for the current state of this project <a href='https://github.com/TheCSharpAcademy/TCSA.Course.WebAPI.FlightData/tree/6.Response-Codes' target='_blank' style='color:white;'>in this link</a>." }
                                }
                            }
                        }
                    },
                    new Article
                    {
                        Id = 500061,
                        CourseDisplayId = 12,
                        Title = "Testing With Swagger",
                        Slug = "web-api-test-swaggeron",
                        Description = "",
                        Area = Area.Course,
                        ExperiencePoints = 1,
                        Blocks = new List<Block>
                        {
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                     new Paragraph {
                                         Body = "It's time to finally test our Flights API! For this we'll use two testing tools: Swagger and Postman."
                                     }
                                }
                            },
                            new Block
                            {
                                Title = "What is Swagger?",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                         Body = "Swagger is an open-source tool used in ASP.NET Core to automatically generate interactive documentation for APIs. By integrating Swagger into an ASP.NET Core project, developers can easily visualize, explore, and test their API endpoints without needing to write extensive documentation manually. Here's how it works:"
                                     },
                                       new Paragraph {
                                         Body = "<b>Automatic API Documentation:</b> Swagger reads the metadata from your ASP.NET Core API and creates documentation based on your controllers, routes, and models. This documentation includes descriptions of endpoints, HTTP methods, parameters, and response types."
                                     },
                                        new Paragraph {
                                         Body = "<b>Interactive UI:</b> Swagger UI provides a web interface where you can view and interact with API endpoints. You can execute HTTP requests (like GET, POST, etc.) directly from the browser, test responses, and see results in real-time."
                                     },
                                         new Paragraph {
                                         Body = "<b>Supports OpenAPI:</b> Swagger implements the <b>OpenAPI Specification (OAS)</b>, making it a standard for describing REST APIs. This makes it compatible with various tools and can be used to generate client SDKs or API documentation in different formats."
                                     }
                                }
                            },
                            new Block
                            {
                                Title = "Testing With Swagger",
                                Paragraphs = new List<Paragraph>
                                {
                                      new Paragraph {
                                          Body = "Before you run the app, make sure you've got launchBrowser and launchUrl properties like shown below in your launchSettings.json file."
                                     },
                                       new Paragraph {
                                          IsCode = true,
                                          Body = "{\r\n  \"$schema\": \"https://json.schemastore.org/launchsettings.json\",\r\n  \"profiles\": {\r\n    \"http\": {\r\n      \"commandName\": \"Project\",\r\n      \"dotnetRunMessages\": true,\r\n      \"launchBrowser\": true,\r\n      \"launchUrl\": \"swagger\"\r\n      // Omitted for brevity ...\r\n  }\r\n}"
                                     },

                                        new Paragraph {
                                          Body = "Once we run the app, your browser should open with this interface:"
                                     },
                                        new Paragraph {
                                            IsPicture = true,
                                         PictureUrl = "c3-ch12-webapis-swagger-interface.png"
                                     },
                                        new Paragraph {
                                         Body = "Let's start testing the creation of a flight. Expand the Post endpoint, click on <b>Try it Out</b> and fill the inputs for each property of the flight. <b>You don't need to provide the Id</b>, as it's populated by the database itself. <b>Click on Execute</b>. If the request is correct you'll see this:"
                                     },
                                        new Paragraph {
                                            IsPicture = true,
                                         PictureUrl = "c3-ch12-webapis-swagger-create.png"
                                     },
                                        new Paragraph {
                                         Body = "Repeat the process and create a second flight, modifying the data as you wish. Next let's test the GetAll method. Click on Try it out and Execute. You should see something like this:"
                                     },
                                         new Paragraph {
                                            IsPicture = true,
                                         PictureUrl = "c3-ch12-webapis-swagger-getall.png"
                                     },
                                          new Paragraph {
                                         Body = "Proceed to test GetById, Delete and Put. For any of these methods, if you use an id that doesn't exist in the database you'll get a 404 response:"
                                     },
                                         new Paragraph {
                                            IsPicture = true,
                                         PictureUrl = "c3-ch12-webapis-swagger-notfound.png"
                                     },
                                }
                            }
                        }
                    },
                    new Article
                    {
                        Id = 500062,
                        CourseDisplayId = 13,
                        Title = "Testing With Postman",
                        Slug = "web-api-test-postman",
                        Description = "",
                        Area = Area.Course,
                        ExperiencePoints = 1,
                        Blocks = new List<Block>
                        {
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                     new Paragraph {
                                         Body = "Although ASP.NET Core Web APIs can be easily configured to work with Swagger, The C# Academy's recommendeds Postman, a popular API development and testing tool that simplifies the process of working with web APIs. Here are some key points about Postman and why it's widely used:"
                                     },
                                    new Paragraph {
                                         Body = "✅ <b>User-Friendly Interface</b>: Postman offers an intuitive and easy-to-use graphical interface, allowing developers to create and manage API requests without needing to write code for each request."
                                     },
                                    new Paragraph {
                                         Body = "✅ <b>Comprehensive Features</b>: It provides a robust set of features including request building, testing, documentation, and monitoring of APIs."
                                     },
                                    new Paragraph {
                                         Body = "✅ <b>Cross-Platform</b>: Postman is available on Windows, macOS, and Linux, making it accessible to a wide range of developers."
                                     },
                                    new Paragraph {
                                         Body = "✅ <b>Collaboration Tools</b>: Postman allows team collaboration through shared workspaces, collections, and environment configurations, making it easier to work on APIs in a collaborative setting."
                                     }
                                }
                            },
                            new Block
                            {
                                Title = "Postman's Main Features",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                         Body = "➡️ <b>Request Building</b>: You can easily create and configure HTTP requests (GET, POST, PUT, DELETE, etc.) with headers, parameters, and body content."
                                     },
                                       new Paragraph {
                                         Body = "➡️ <b>Environment Management</b>: Postman allows you to create different environments (e.g., development, staging, production) and switch between them seamlessly. This helps in managing different configurations for different stages of API development.\r\n"
                                     },
                                        new Paragraph {
                                         Body = "➡️ <b>Automated Testing</b>: Postman supports automated testing through its built-in scripting environment. You can write tests using JavaScript to validate the responses of your API requests."
                                     },
                                         new Paragraph {
                                         Body = "➡️ <b>Mock Servers</b>: Postman can create mock servers to simulate API responses, which is useful for testing and developing against APIs that are still in development or not always available.\r\n"
                                     },
                                         new Paragraph {
                                         Body = "➡️ <b>Documentation</b>: Postman can generate API documentation automatically from your collections, which can be shared with your team or clients."
                                     },
                                         new Paragraph {
                                         Body = "➡️ <b>Monitoring</b>: You can set up monitors to run your collections at scheduled intervals to check the health and performance of your APIs."
                                     }
                                }
                            },
                            new Block
                            {
                                Title = "Using Postman",
                                Paragraphs = new List<Paragraph>
                                {
                                       new Paragraph {
                                         Body = "Navigate to <a href='https://www.postman.com/' target='_blank'>Postman's website</a> download the app and create an account. You can use it without registering but an account allows you to save your collections of requests for future use, one of the main advantages of using Postman. "
                                     },
                                        new Paragraph {
                                         Body = "Once logged in, click on <b>Workspaces > My Workspaces</b>. You'll see the window you can send requests from. Let's start with GetAll. Copy and paste your endpoint's URL and <b>click on Send</b>, as per the picture below. Keep in mind your localhost might be using a different port: "
                                     },
                                        new Paragraph {
                                            IsPicture = true,
                                         PictureUrl = "c3-ch13-webapis-postman-interface.png"
                                     },
                                        new Paragraph {
                                         Body = "To create a post request we will need to send a <b>json object as a payload</b>. For this change the type of request to Post (at the left of the URL), click Body and check the \"raw\" option as per the picture below. To speed things up you can use the provided json: \r\n"
                                     },
                                         new Paragraph {
                                            IsCode = true,
                                         Body = "{\r\n    \"FlightNumber\": 650,\r\n    \"AirlineName\": \"C# Airlines\",\r\n    \"DepartureAirportCode\": \"LAX\",\r\n    \"ArrivalAirportCode\": \"JFK\",\r\n    \"DepartureDateTime\": \"2024-12-04T07:00:00\",\r\n    \"ArrivalDateTime\":\"2024-12-04T11:00:00\",\r\n    \"PassengerCapacity\": 150\r\n}"
                                     },
                                         new Paragraph {
                                            IsPicture = true,
                                         PictureUrl = "c3-ch13-webapis-postman-post.png"
                                     },
                                          new Paragraph {
                                         Body = "To delete, update or get a record you'll need to pass the id in the query as per picture:"
                                     },
                                         new Paragraph {
                                            IsPicture = true,
                                         PictureUrl = "c3-ch13-webapis-postman-parameter.png"
                                     },
                                }
                            },
                            new Block
                            {
                                Title = "Saving a Collection",
                                Paragraphs = new List<Paragraph>
                                {
                                       new Paragraph {
                                         Body = "To Create a new Collection and Save your requests for future use, click on the plus sign on the top left, choose Blank Collection. Click on the three dots near the \"New Collection\" created and rename it to Flights API. You can now click on Save on the right top and choose to save your request in the collection you desire."
                                     },
                                      new Paragraph {
                                         IsPicture = true,
                                         PictureUrl = "c3-ch13-webapis-swagger-collections.png"
                                     },
                                }
                            }
                        }
                    },
                    new Article
                    {
                        Id = 500063,
                        CourseDisplayId = 14,
                        Title = "Conclusion",
                        Slug = "oop-conclusion",
                        Description = "Let's create the console app, install a package and write some code!",
                        Area = Area.Course,
                        ExperiencePoints = 1,
                        Blocks = new List<Block>
                        {
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "Congratulations! You've completed the Intro to ASP.NET Core Web APIs course! You should now be familiar with one of the most important parts of ASP.NET Core. Understanding Web APIs means knowing how applications reach each other via HTTP requests, which is at the core of how the internet works." },
                                }
                            },
                            new Block
                            {
                                Title = "What To Do Now",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "We recommend you write down a reflection about what you've just learned. What did you think of the course? What are sub-topics you still feel you don't understand well? What feels more clear to you now?" },
                                    new Paragraph {
                                       Body = "If you're following our roadmap, there are several projects that have a Web Api as a requirement, starting with the Shifts Logger. Several projects in the Angular and React areas involve building APIs. You can also submit a Freestyle Project, if you have an idea that's not covered in our curriculum. " },
                                    new Paragraph {
                                       Body = "You can also revisit this course at any time. Each time you repeat a course, you'll find that you'll learn something new or see the same topic from a new perspective, no matter how many times you do it." },
                                    new Paragraph { Body = "Keep in mind that this is an intro course covering the basics of Web APIs. We're working on an intermediate and an advanced course, covering topics for students that are already very comfortable with the material in this course. Stay tuned and once again, Congratulations!" }
                                }
                            },
                            new Block
                            {
                                Title = "Video Course",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "We also have a paid video version of this tutorial. The video version already contains a part 2, with the intermediate content:<br><br>\r\n<b>Option 1</b>: Purchase the course <a href='https://thecsharpschool.getlearnworlds.com/course/aspnet-core-web-apis' target='_blank'>individually for $4.99</a>.<br>\r\n<b>Option 2</b>: Subscribe to the <b>VIP Membership</b> and have access to <a href='https://thecsharpschool.getlearnworlds.com/payment?product_id=the-c-academy-membership&type=subscription' target='_blank'>all our courses for $4.99/month</a><br>\r\n<b>Option 3</b>: Subscribe to the <b>VIP Mentorship</b> for <a href='https://thecsharpschool.getlearnworlds.com/payment?product_id=net-accelerator-mentorship&type=subscription' target='_blank'>all courses and 1-on-1 mentorship for $39.99/month</a>" }
                                }
                            },
                        }
                    }
                }
        };
    }
}
