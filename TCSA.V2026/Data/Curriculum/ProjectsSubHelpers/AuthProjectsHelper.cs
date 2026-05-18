using TCSA.V2026.Data.Curriculum;
using TCSA.V2026.Data.Enums;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Data.Models.LanguageModels;
using TCSA.V2026.Helpers;

namespace TCSA.V2026.Data.Helpers.ProjectsSubHelpers;

internal static class AuthProjectsHelper
{
    internal static List<Project> GetProjects()
    {
        return new List<Project>
        {
             new Project
             {
                Id = (int)ArticleName.Auth,
                Title = "Authentication and Authorization",
                IconUrl = "icons8-safe-ok-480.png",
                BannerUrl = "auth-banner.jpg",
                LanguageHeadings = new EnglishHeadings(),
                Slug = "authentication-and-authorization",
                Description = "Learn how to secure your app with ASP.NET Core Identity",
                Area = Area.Auth,
                Level = Level.Brown,
                ExperiencePoints = 50,
                Difficulty = Difficulty.Intermediate,
                RepositoryLink = "https://github.com/TheCSharpAcademy/CodeReviews.Auth.AuthenticationAndAuthorization",
                Introduction = new List<Paragraph>
                {
                    new Paragraph
                    {
                        Body="So far we’ve learned how to build a full-stack app but we’ll never be able to deploy it without securing it. If you publish a form that talks to a database and allow anyone to use it, it will eventually be found by bots designed to find database vulnerabilities. If you pay for your data server as you use it, the result will be a massive bill. 😟"
                    },
                    new Paragraph
                    {
                        Body="In principle, creating a custom authentication and authorisation system is fairly easy. You can try it yourself with the knowledge you already have. Simply create a ‘user’ table with login and password and create a registration form that will insert a new user and a login form that will check the user input against that table. If the input password matches the one stored in the database they're 'authenticated' and 'authorized' to view your page. If not, redirect them to the login/registration area."
                    },
                    new Paragraph
                    {
                        Body = "The reality is a little bit more complex though. Not only this simple approach is easy to hack, but any real A&A system will need to support functionalities like changing password, managing an account, confirming a registration, just to name a few. There are several battle-tested enterprise level approaches for this task. Since this is a .NET/C# course we'll be using an approach that's part of the .NET ecosystem: <b>ASP.NET Core Identity</b> offers scaffolding for dozens of these operations, shipping fully-functioning front and back-end solutions. And they’re customisable too! Let’s see how it works."
                    }
                },
                Requirements = new List<string>
                {
                    "In this project, you'll have two tasks. In a first moment you'll create a new Web App project with Identity as part of it.",
                    "In a second moment you'll scaffold Identity into the one of the Blazor or MVC apps you created before. If you chose the Angular or React paths, you'll have to learn how to create and run a basic Blazor or MVC or Razor Pages project to complete this task. ",
                    "You need to use Entity Framework, raw SQL isn't allowed.",
                    "You need to seed test data.",
                    "You need to use EF's EnsureCreated method so the database and tables are created automatically.",
                    "You need to add logging logic to your app and save logs to your database when errors occur.",
                    "You don't need to handle auth scenarios such as e-mail confirmation, password recovery, etc. These will be addressed in future projects.",
                    CurriculumConstants.ReadMeRequirement
                },
                ResourcesIntro = "Here are a few resources that might be helpful.",
                Resources = new List<string>
                {
                    "<a target='blank' href='https://learn.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-9.0&tabs=visual-studio'>Introduction to Identity</a>",
                    "<a target='blank' href='https://docs.microsoft.com/en-us/aspnet/core/security/authentication/scaffold-identity?view=aspnetcore-6.0&tabs=visual-studio'>Scaffolding Identity into Existing App</a>",
                },
                Tips = new List<string>
                {
                    "If your front-end choice is React or Angular, you might want to go back and complete the first couple of projects of the Blazor or MVC areas first. Don't worry, it's fairly straightforward. And it won't be a waste of time. Even if you never work with these technologies again, this exposure to ASP.NET Core technologies and the .NET scaffolding system will make you a more well-rounded developer.",
                    "After wiring Identity up, you need to apply it to the controller you want to protect.",
                    "You'll only submit one project for review, however it's important to complete both tasks. Creating an app with identity from the beginning, and then scaffolding identity into an existing app. These are two different beasts and it's important to have exposure to both."
                }
             },
             new Project
             {
                Id = (int)ArticleName.ProductManagement,
                Title = "Product Management System",
                IconUrl = "icons8-products-96.png",
                BannerUrl = "banner-productmanagement.jpg",
                LanguageHeadings = new EnglishHeadings(),
                Slug = "product-management-system",
                Description = "Learn role-based authentication with ASP.NET Core Identity",
                Area = Area.Auth,
                Level = Level.Brown,
                ExperiencePoints = 100,
                Difficulty = Difficulty.Intermediate,
                RepositoryLink = "https://github.com/TheCSharpAcademy/CodeReviews.Auth.ProductManagementSystem",
                Introduction = new List<Paragraph>
                {
                    new Paragraph
                    {
                        Body="A very common scenario in web development is having different sections authorized to different roles within an organization. In this app we'll learn how to secure an app based on the user's position in the system, using ASP.NET Core Identity."
                    },
                    new Paragraph
                    {
                        Body="On top of that we will provide functionalities such as e-mail confirmation and passwords resetting and recovery. These can be difficult to implement but the good news is that you can find solutions out of the box by using ASP.NET core scaffolding tools."
                    },
                    new Paragraph
                    {
                        Body = "But as always, let's talk less and code more. Roll up your sleeves!"
                    }
                },
                Requirements = new List<string>
                {
                    "This is back-of-store app where users will manage products. Feel free to choose any industry",
                    "You can use any ASP.NET front-end solution (Razor Pages, MVC, Blazor)",
                    "You need to use ASP.NET Core Identity",
                    "Users should be able to add, delete, update and view products",
                    "Products should have at least the following products: IsActive, DateAdded, Price",
                    "You don't need to add relational data (i.e. product categories, orders)",
                    "The app needs to have an admin area that will only be accessible to users with the 'Admin' role",
                    "In the Admin area, admin staff will be able to add, update, delete and view staff",
                    "New staff should be able to register themselves. Registration should be confirmed by e-mail",
                    "Staff should be able to reset their password",
                    "Staff should be able to recover their forgotten password",
                    "You need to implement an e-mail service for account confirmation and password functionalities",
                    "You need to seed test data",
                    "You need to use EF's EnsureCreated method so the database and tables are created automatically",
                    "You need to add logging logic to your app and save logs to your database when errors occur",
                },
                ResourcesIntro = "On top of the resources available for the <a href='https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-6.0&tabs=visual-studio'>Introduction to Identity</a> project, you can use:",
                Resources = new List<string>
                {
                    "<a target='blank' href='https://learn.microsoft.com/en-us/aspnet/core/security/authorization/roles?view=aspnetcore-7.0'>Role-based authorization in ASP.NET Core</a>",
                    "<a target='blank' href='https://learn.microsoft.com/en-us/aspnet/identity/overview/features-api/account-confirmation-and-password-recovery-with-aspnet-identity'>Account confirmation and password recovery with ASP.NET Identity</a>",
                     "<a target='blank' href='https://code-maze.com/aspnetcore-send-email/'>How to Send an Email in ASP.NET Core</a>",
                     "<a target='_blank' href='https://github.com/ChangemakerStudios/Papercut-SMTP'>Papercut - Use it for local Email SMTP testing</a>"
                }
             },
             new Project
             {
                Id = (int)ArticleName.ExternalAuth,
                Title = "External Auth",
                IconUrl = "icons8-fingerprint-error-96.png",
                Slug = "external-auth",
                BannerUrl = "banner-externalauth.jpg",
                LanguageHeadings = new EnglishHeadings(),
                Description = "Learn to authorize a self-hosted ASP.NET Identity app with an external service.",
                Area = Area.Auth,
                Level = Level.Brown,
                ExperiencePoints = 100,
                Difficulty = Difficulty.Intermediate,
                RepositoryLink = "https://github.com/TheCSharpAcademy/CodeReviews.Auth.ExternalAuth",
                Introduction = new List<Paragraph>
                {
                    new Paragraph
                    {
                        Body="These days, most web and native applications offer registration using a third-party service. The most common are Gmail, Microsoft, Facebook and Twitter. Enabling users to sign in with their existing credentials is convenient and shifts many of the complexities of managing the sign-in process onto a third party provider."
                    }
                },
                Requirements = new List<string>
                {
                    "You can use one of the previous Auth projects apps for this project.",
                    "Users should be able to register/login into your website using Facebook, Gmail, Github, Windows and Twitter. All five are necessary for the project to be approved.",
                    "User should also be able to register using the existing registration form.",
                    "Existing users should be able to link their account to one of the services above.",
                },
                Resources = new List<string>
                {
                    "<a target='blank' href='https://learn.microsoft.com/en-us/aspnet/core/security/authentication/social/?view=aspnetcore-7.0&tabs=visual-studio'>External provider authentication in ASP.NET Core</a>",
                },
                Tips = new List<string>
                {
                    "Initially, wire up external auth to a brand new app. Once the integration with external services is understood in isolation, it might be easier to apply it to an existing project.",
                },
                 Challenges = new List<string>
                {
                    "You can add many other services as options for the user. <a target='blank' href='https://learn.microsoft.com/en-us/aspnet/core/security/authentication/social/other-logins?view=aspnetcore-7.0'>Check this list</a>.",
                     "You can use aditional claims from the external provider. <a target='blank' href='https://learn.microsoft.com/en-us/aspnet/core/security/authentication/social/additional-claims?view=aspnetcore-7.0'>Check this article</a>."
                }
             },
             new Project
             {
                 Id = (int)ArticleName.Auth0,
                 Title = "Auth0 Integration",
                 IconUrl = "icons8-login-96.png",
                 BannerUrl = "banner-auth0.jpg",
                 LanguageHeadings = new EnglishHeadings(),
                 Slug = "auth0-integration",
                 Description = "Learn how to integrate an ASP.NET Core application with Auth0",
                 Area = Area.Auth,
                 Level = Level.Brown,
                 ExperiencePoints = 100,
                 Difficulty = Difficulty.Intermediate,
                 RepositoryLink = "https://github.com/TheCSharpAcademy/CodeReviews.Auth.Auth0Integration",
                 Introduction = new List<Paragraph>
                 {
                     new Paragraph
                     {
                         Body = "In the previous Auth projects, we learned how to secure ASP.NET Core applications using Identity, roles, account confirmation, password recovery and external login providers. These are essential skills, especially when working with applications that own and manage their own user data."
                     },
                     new Paragraph
                     {
                         Body = "In many professional environments, however, companies don't want every application to manage authentication on its own. Instead, they use an identity provider such as Auth0 to centralize login, registration, social providers, user management, multi-factor authentication and token issuing."
                     },
                     new Paragraph
                     {
                         Body = "In this project, you'll integrate an ASP.NET Core application with Auth0. The objective is to understand how a hosted identity platform fits into a .NET application, how login/logout flows work, how claims are received by your app, and how protected pages or API endpoints can be secured using Auth0."
                     }
                 },
                 Requirements = new List<string>
                 {
                     "You need to create a new ASP.NET Core MVC, Razor Pages or Blazor app.",
                     "You need to create an Auth0 account and configure an Auth0 application for your project.",
                     "Users should be able to register, log in and log out using Auth0.",
                     "Your app should display basic user profile information after login, such as name, e-mail and profile picture when available.",
                     "You need to protect at least one page, controller action or component so it can only be accessed by authenticated users.",
                     "You need to configure callback and logout URLs correctly for local development.",
                     "You need to store Auth0 configuration values such as Domain, ClientId and ClientSecret in configuration files or user secrets. These values should not be hard-coded.",
                     "You need to add role-based or claim-based authorization to protect at least one admin-only area or feature.",
                     "You need to document the Auth0 setup steps in your README, including the required dashboard configuration. The reviewer will follow these steps to review your project using the integration.",
                     "You need to explain in your README the difference between ASP.NET Core Identity and using an external identity provider such as Auth0.",
                     CurriculumConstants.ReadMeRequirement
                 },
                 ResourcesIntro = "Here are a few resources that might be helpful.",
                 Resources = new List<string>
                 {
                     "<a target='blank' href='https://auth0.com/docs/quickstart/webapp/aspnet-core'>Auth0 ASP.NET Core Web App Quickstart</a>",
                     "<a target='blank' href='https://auth0.com/docs/quickstart/backend/aspnet-core-webapi'>Auth0 ASP.NET Core Web API Quickstart</a>",
                     "<a target='blank' href='https://auth0.com/blog/exploring-auth0-aspnet-core-authentication-sdk/'>Exploring the Auth0 ASP.NET Core Authentication SDK</a>",
                     "<a target='blank' href='https://github.com/auth0-samples/auth0-aspnetcore-mvc-samples'>Auth0 ASP.NET Core MVC Samples</a>",
                     "<a target='blank' href='https://auth0.github.io/auth0-aspnetcore-authentication/'>Auth0 ASP.NET Core Authentication SDK Docs</a>"
                 },
                 Tips = new List<string>
                 {
                     "Start with a brand new ASP.NET Core MVC or Razor Pages app before integrating Auth0 into an existing project. Once the login and logout flow is clear, apply it to a previous Auth project.",
                     "Use User Secrets for local development so you don't accidentally commit sensitive Auth0 values to GitHub.",
                     "Pay close attention to callback URLs, logout URLs and allowed web origins in the Auth0 dashboard. Small mistakes in these settings are one of the most common causes of integration issues.",
                     "After logging in, inspect the user's claims and write notes about what Auth0 sends back to your application.",
                     "Make sure you understand the difference between authentication handled by Auth0 and application data that still belongs in your own database."
                 },
                 Challenges = new List<string>
                 {
                     "Create a protected ASP.NET Core Web API and call it from your web app using an access token issued by Auth0.",
                     "Add Auth0 roles or permissions and use them to protect different areas of your application.",
                     "Add social login through Auth0, such as Google or GitHub, instead of configuring each provider directly in ASP.NET Core.",
                     "Add a custom claim to the user's profile and use it inside your application.",
                     "Create a simple admin page that displays the logged-in user's claims so you can better understand the authentication flow."
                 }
             },
        };
    }
}
