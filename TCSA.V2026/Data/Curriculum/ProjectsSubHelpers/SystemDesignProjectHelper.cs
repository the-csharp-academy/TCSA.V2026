using TCSA.V2026.Data.Enums;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Data.Models.LanguageModels;
using TCSA.V2026.Helpers;

namespace TCSA.V2026.Data.Curriculum.ProjectsSubHelpers;

public class SystemDesignProjectHelper
{
    internal static List<Project> GetProjects()
    {
        return new List<Project>
        {
            new Project
            {
                Id = (int)ArticleName.SystemDesignCleanArchitectureReservations,
                Title = "Clean Architecture Restaurant Reservations",
                IconUrl = "icons8-archit-64.png",
                BannerUrl = "cleanarchitecture-banner.png",
                Slug = "system-design-clean-architecture-reservations",
                LanguageHeadings = new EnglishHeadings(),
                Description = "Learn Clean Architecture by building a reservation system with real business rules",
                Area = Area.SystemDesign,
                Level = Level.Black,
                ExperiencePoints = 50,
                Difficulty = Difficulty.Advanced,
                DisplayOrder = 1,
                RepositoryLink = "https://github.com/TheCSharpAcademy/CodeReviews.SystemDesign.CleanArchitectureReservations",
                Introduction = new List<Paragraph>
                {
                    new Paragraph
                    {
                        Body = "Welcome to your first Systems Design project! Before learning microservices, queues, caching and other advanced topics, you need to understand how to protect business logic from frameworks, databases and external tools."
                    },
                    new Paragraph
                    {
                        Body = "In this project, you'll build a Restaurant Reservation API using Clean Architecture. This is a great domain for learning architecture because it contains real business rules: tables have limited capacity, reservations can conflict, restaurants have opening hours and invalid bookings need to be rejected."
                    },
                    new Paragraph
                    {
                        Body = "The goal is not to build a huge application. The goal is to understand boundaries, dependency direction and how business rules can live in the core of your application instead of being scattered across controllers and database code."
                    }
                },
                Requirements = new List<string>
                {
                    "You need to create an ASP.NET Core Web API application.",
                    "The application should allow users to create, read, update and cancel restaurant reservations.",
                    "A reservation should have at least a customer name, customer contact information, reservation date, reservation time, party size and status.",
                    "The system should contain restaurant tables with table number and seating capacity.",
                    "A reservation should be assigned to a table that has enough capacity for the party size.",
                    "The system should prevent double-booking the same table at the same time.",
                    "The system should reject reservations outside the restaurant's opening hours.",
                    "The system should reject reservations with invalid party sizes.",
                    "Your solution must contain separate projects or clearly separated folders for Domain, Application, Infrastructure and API.",
                    "The Domain layer should contain your core entities and business rules.",
                    "The Application layer should contain use cases, interfaces, DTOs and validation.",
                    "The Infrastructure layer should contain Entity Framework Core, database configuration and repository implementations.",
                    "The API layer should contain controllers, middleware and dependency injection setup.",
                    "Dependencies should point inward. Domain should not depend on Application, Infrastructure or API.",
                    "Entity Framework Core should only be used in the Infrastructure layer.",
                    "Controllers should call Application services or use cases, not repositories directly.",
                    "You need to use DTOs for requests and responses.",
                    "You need to add validation so invalid reservations can't be created.",
                    "You need to add global error handling so the application doesn't crash unexpectedly.",
                    "You need to add logging for important operations and errors.",
                    "You need to add Open API documentation.",
                    "You should seed sample tables so the application can be tested immediately.",
                    "You should include a README explaining Clean Architecture, dependency direction and how a reservation request flows through your application.",
                    "You need to containerize the application using Docker.",
                    "You need to create a Dockerfile for the API project.",
                    "You need to use Docker Compose to run the API and database together.",
                    "The application should be fully runnable with a single docker compose up command.",
                    "You should include instructions in the README explaining how to run the project with Docker.",
                },
                ResourcesIntro = "Here are a few resources that might be helpful.",
                Resources = new List<string>
                {
                    "<a target='_blank' href='https://learn.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures'>Microsoft Docs: Common Web Application Architectures</a>",

                    "<a target='_blank' href='https://learn.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/architectural-principles'>Microsoft Docs: Architectural Principles</a>",

                    "<a target='_blank' href='https://learn.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/'>Microsoft Docs: Architecting Modern Web Applications with ASP.NET Core and Azure</a>",

                    "<a target='_blank' href='https://www.youtube.com/watch?v=NzcZcim9tp8'>Milan Jovanović - Pragmatic Clean Architecture</a>",

                    "<a target='_blank' href='https://learn.microsoft.com/en-us/dotnet/core/docker/build-container?tabs=windows&pivots=dotnet-9-0'>Microsoft Docs: Containerize a .NET App with Docker</a>"
                },
                Tips = new List<string>
                {
                    "Keep the user interface simple. The objective is backend architecture and business rules.",
                    "Don't treat Clean Architecture as a folder naming exercise. Focus on dependency direction and protecting business rules.",
                    "Avoid putting Entity Framework types in your Domain or Application layers.",
                    "Use interfaces only when they protect your core application from infrastructure concerns.",
                    "Think carefully about where each rule belongs. For example, table capacity and booking conflicts should not be handled directly inside controllers.",
                    "Your README is very important in this project. Explain why each layer exists and what should not go inside it."
                },
                Challenges = new List<string>
                {
                    "Add unit tests for the Application layer.",
                    "Add health checks.",
                    "Add pagination to the reservation list endpoint.",
                    "Add filtering by date, status or customer name.",
                    "Add a rule that reservations can only be made a certain number of days in advance.",
                    "Add a simple in-memory cache through an interface defined in the Application layer."
                }
            },
            new Project
            {
                Id = (int)ArticleName.SystemDesignModularReservationSystem,
                Title = "Modular Restaurant Management System",
                Description = "Expand the reservation system into a modular monolith with bookings, tables, customers and schedules",
                DisplayOrder = 2
            },
            new Project
            {
                Id = (int)ArticleName.SystemDesignReservationApiGateway,
                Title = "Distributed Restaurant Reservation Platform",
                Description = "Split the restaurant system into multiple APIs and route traffic through an API Gateway",
                DisplayOrder = 3
            },
            new Project
            {
                Id = (int)ArticleName.SystemDesignReservationBackgroundJobs,
                Title = "Restaurant Reservation Background Jobs",
                Description = "Add asynchronous processing for reminders, cancellations, reports and waiting-list notifications",
                DisplayOrder = 4
            }
        };
    }
}
