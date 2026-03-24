using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TCSA.V2026.Data.Enums;
using TCSA.V2026.Data.Models;

namespace TCSA.V2026.Data;

public static class SeedData
{
    public static async Task Seed(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<ApplicationDbContext>>();
        await using var context = await contextFactory.CreateDbContextAsync();

        await context.Database.EnsureDeletedAsync();
        await context.Database.EnsureCreatedAsync();

        await SeedChallenges(context);
        await SeedUsers(context);
    }

    private static async Task SeedUsers(ApplicationDbContext context)
    {
        var hasher = new PasswordHasher<ApplicationUser>();

        var user1 = new ApplicationUser
        {

            Id = Guid.NewGuid().ToString(),
            UserName = "user1@example.com",
            NormalizedUserName = "USER1@EXAMPLE.COM",
            Email = "user1@example.com",
            NormalizedEmail = "USER1@EXAMPLE.COM",
            FirstName = "John",
            LastName = "Doe",
            Country = "USA",
            ExperiencePoints = 1000,
            ReviewExperiencePoints = 500,
            CodeWarsUsername = "Dejmenek",
            LeetCodeUsername = "Dejmenek",
            ReviewedProjects = 5,
            EmailConfirmed = true,
            GithubLogin = false,
            Level = Level.Orange,
            DashboardProjects = new List<DashboardProject>
            {
                new DashboardProject
                {
                    ProjectId = 5,
                    GithubUrl = string.Empty,
                    IsCompleted = true,
                    IsArchived = false,
                    IsPendingNotification = false,
                    IsPendingReview = false,
                    DateSubmitted = new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)),
                    DateCompleted = new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)),
                    DateRequestedChange = DateTimeOffset.MinValue,
                },
                new DashboardProject
                {
                    ProjectId = 6,
                    GithubUrl = string.Empty,
                    IsCompleted = true,
                    IsArchived = false,
                    IsPendingNotification = false,
                    IsPendingReview = false,
                    DateSubmitted = new DateTimeOffset(new DateTime(2025, 1, 2, 0, 0, 0, DateTimeKind.Utc)),
                    DateCompleted = new DateTimeOffset(new DateTime(2025, 1, 2, 0, 0, 0, DateTimeKind.Utc)),
                    DateRequestedChange = DateTimeOffset.MinValue,
                },
                new DashboardProject
                {
                    ProjectId = 7,
                    GithubUrl = string.Empty,
                    IsCompleted = true,
                    IsArchived = false,
                    IsPendingNotification = false,
                    IsPendingReview = false,
                    DateSubmitted = new DateTimeOffset(new DateTime(2025, 1, 3, 0, 0, 0, DateTimeKind.Utc)),
                    DateCompleted = new DateTimeOffset(new DateTime(2025, 1, 3, 0, 0, 0, DateTimeKind.Utc)),
                    DateRequestedChange = DateTimeOffset.MinValue,
                },
                new DashboardProject
                {
                    ProjectId = 8,
                    GithubUrl = string.Empty,
                    IsCompleted = true,
                    IsArchived = false,
                    IsPendingNotification = false,
                    IsPendingReview = false,
                    DateSubmitted = new DateTimeOffset(new DateTime(2025, 1, 4, 0, 0, 0, DateTimeKind.Utc)),
                    DateCompleted = new DateTimeOffset(new DateTime(2025, 1, 4, 0, 0, 0, DateTimeKind.Utc)),
                    DateRequestedChange = DateTimeOffset.MinValue,
                }
            },
            UserActivity = new List<AppUserActivity>
            {
                new AppUserActivity
                {
                    ProjectId = 5,
                    ChallengeId = 0,
                    DateSubmitted = new DateTimeOffset(new DateTime(2025, 1, 1, 0, 1, 0, DateTimeKind.Utc)),
                    ActivityType = ActivityType.ArticleRead,
                },
                new AppUserActivity
                {
                    ProjectId = 6,
                    ChallengeId = 0,
                    DateSubmitted = new DateTimeOffset(new DateTime(2025, 1, 2, 0, 1, 0, DateTimeKind.Utc)),
                    ActivityType = ActivityType.ArticleRead,
                },
                new AppUserActivity
                {
                    ProjectId = 7,
                    ChallengeId = 0,
                    DateSubmitted = new DateTimeOffset(new DateTime(2025, 1, 3, 0, 1, 0, DateTimeKind.Utc)),
                    ActivityType = ActivityType.ArticleRead,
                },
                new AppUserActivity
                {
                    ProjectId = 8,
                    ChallengeId = 0,
                    DateSubmitted = new DateTimeOffset(new DateTime(2025, 1, 4, 0, 1, 0, DateTimeKind.Utc)),
                    ActivityType = ActivityType.ArticleRead,
                }
            }
        };
        user1.PasswordHash = hasher.HashPassword(user1, "Password123!");

        var user2 = new ApplicationUser
        {
            Id = Guid.NewGuid().ToString(),
            UserName = "user2@example.com",
            NormalizedUserName = "USER2@EXAMPLE.COM",
            Email = "user2@example.com",
            NormalizedEmail = "USER2@EXAMPLE.COM",
            FirstName = "Jane",
            LastName = "Smith",
            Country = "Canada",
            ExperiencePoints = 1500,
            ReviewExperiencePoints = 700,
            ReviewedProjects = 8,
            EmailConfirmed = true,
            GithubLogin = false,
            Level = Level.Green
        };
        user2.PasswordHash = hasher.HashPassword(user2, "Password124!");

        var user3 = new ApplicationUser
        {
            Id = Guid.NewGuid().ToString(),
            UserName = "user3@example.com",
            NormalizedUserName = "USER3@EXAMPLE.COM",
            Email = "user3@example.com",
            NormalizedEmail = "USER3@EXAMPLE.COM",
            FirstName = "Jane",
            LastName = "Doe",
            Country = "AUS",
            ExperiencePoints = 1000,
            ReviewExperiencePoints = 500,
            ReviewedProjects = 9,
            EmailConfirmed = true,
            GithubLogin = false,
            Level = Level.OliveGreen,

            UserActivity = new List<AppUserActivity>
            {
                new AppUserActivity
                {
                    ProjectId = 9,
                    ChallengeId = 0,
                    DateSubmitted = new DateTimeOffset(new DateTime(2025, 1, 1, 0, 1, 0, DateTimeKind.Utc)),
                    ActivityType = ActivityType.ArticleRead,
                },
                new AppUserActivity
                {
                    ProjectId = 10,
                    ChallengeId = 0,
                    DateSubmitted = new DateTimeOffset(new DateTime(2025, 1, 2, 0, 1, 0, DateTimeKind.Utc)),
                    ActivityType = ActivityType.ArticleRead,
                },
                new AppUserActivity
                {
                    ProjectId = 11,
                    ChallengeId = 0,
                    DateSubmitted = new DateTimeOffset(new DateTime(2025, 1, 3, 0, 1, 0, DateTimeKind.Utc)),
                    ActivityType = ActivityType.ArticleRead,
                },
                new AppUserActivity
                {
                    ProjectId = 12,
                    ChallengeId = 0,
                    DateSubmitted = new DateTimeOffset(new DateTime(2025, 1, 4, 0, 1, 0, DateTimeKind.Utc)),
                    ActivityType = ActivityType.ArticleRead,
                },
                new AppUserActivity
                {
                    ProjectId = 13,
                    ChallengeId = 0,
                    DateSubmitted = new DateTimeOffset(new DateTime(2025, 1, 4, 0, 1, 0, DateTimeKind.Utc)),
                    ActivityType = ActivityType.ArticleRead,
                }
            },

            DashboardProjects = new List<DashboardProject>
            {
                new DashboardProject
                {
                    ProjectId = 9,
                    GithubUrl = string.Empty,
                    IsCompleted = true,
                    IsArchived = false,
                    IsPendingNotification = false,
                    IsPendingReview = false,
                    DateSubmitted = new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)),
                    DateCompleted = new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)),
                    DateRequestedChange = DateTimeOffset.MinValue,
                },
                new DashboardProject
                {
                    ProjectId = 10,
                    GithubUrl = string.Empty,
                    IsCompleted = true,
                    IsArchived = false,
                    IsPendingNotification = false,
                    IsPendingReview = false,
                    DateSubmitted = new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)),
                    DateCompleted = new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)),
                    DateRequestedChange = DateTimeOffset.MinValue,
                },
                new DashboardProject
                {
                    ProjectId = 11,
                    GithubUrl = string.Empty,
                    IsCompleted = true,
                    IsArchived = false,
                    IsPendingNotification = false,
                    IsPendingReview = false,
                    DateSubmitted = new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)),
                    DateCompleted = new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)),
                    DateRequestedChange = DateTimeOffset.MinValue,
                },
                new DashboardProject
                {
                    ProjectId = 12,
                    GithubUrl = "https://github.com/TheCSharpAcademy/CodeReviews.Console.Calculator/pull/392",
                    IsCompleted = true,
                    IsArchived = false,
                    IsPendingNotification = false,
                    IsPendingReview = true,
                    DateSubmitted = new DateTimeOffset(new DateTime(2025, 8, 10, 15, 0, 0, DateTimeKind.Utc)
                    ),
                },
                new DashboardProject
                {
                    ProjectId = 13,
                    GithubUrl = "https://github.com/TheCSharpAcademy/CodeReviews.Console.Calculator/pull/391",
                    IsCompleted = true,
                    IsArchived = false,
                    IsPendingNotification = false,
                    IsPendingReview = true,
                    DateSubmitted = new DateTimeOffset(new DateTime(2025, 8, 12, 0, 1, 0, DateTimeKind.Utc)
                    ),
                },
                new DashboardProject
                {
                    ProjectId = 14,
                    GithubUrl = string.Empty,
                    IsCompleted = true,
                    IsArchived = false,
                    IsPendingNotification = false,
                    IsPendingReview = false,
                    DateSubmitted = new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)),
                    DateCompleted = new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)),
                    DateRequestedChange = DateTimeOffset.MinValue,
                },
                new DashboardProject
                {
                    ProjectId = 15,
                    GithubUrl = string.Empty,
                    IsCompleted = true,
                    IsArchived = false,
                    IsPendingNotification = false,
                    IsPendingReview = false,
                    DateSubmitted = new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)),
                    DateCompleted = new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)),
                    DateRequestedChange = DateTimeOffset.MinValue,
                },
                new DashboardProject
                {
                    ProjectId = 16,
                    GithubUrl = string.Empty,
                    IsCompleted = true,
                    IsArchived = false,
                    IsPendingNotification = false,
                    IsPendingReview = false,
                    DateSubmitted = new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)),
                    DateCompleted = new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)),
                    DateRequestedChange = DateTimeOffset.MinValue,
                },
                new DashboardProject
                {
                    ProjectId = 17,
                    GithubUrl = string.Empty,
                    IsCompleted = true,
                    IsArchived = false,
                    IsPendingNotification = false,
                    IsPendingReview = false,
                    DateSubmitted = new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)),
                    DateCompleted = new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)),
                    DateRequestedChange = DateTimeOffset.MinValue,
                },
            }

        };
        user3.PasswordHash = hasher.HashPassword(user3, "Password123!");

        var user4 = new ApplicationUser
        {
            Id = Guid.NewGuid().ToString(),
            UserName = "user4@example.com",
            NormalizedUserName = "USER4@EXAMPLE.COM",
            Email = "user4@example.com",
            NormalizedEmail = "USER4@EXAMPLE.COM",
            FirstName = "Hulk",
            LastName = "Hogan",
            Country = "AUS",
            ExperiencePoints = 1000,
            ReviewExperiencePoints = 500,
            ReviewedProjects = 3,
            EmailConfirmed = true,
            GithubLogin = false,
            Level = Level.OliveGreen,

            UserActivity = new List<AppUserActivity>
            {
                new AppUserActivity
                {
                    ProjectId = 14,
                    ChallengeId = 0,
                    DateSubmitted = new DateTimeOffset(new DateTime(2025, 1, 1, 0, 1, 0, DateTimeKind.Utc)),
                    ActivityType = ActivityType.ArticleRead,
                },
                new AppUserActivity
                {
                    ProjectId = 15,
                    ChallengeId = 0,
                    DateSubmitted = new DateTimeOffset(new DateTime(2025, 1, 2, 0, 1, 0, DateTimeKind.Utc)),
                    ActivityType = ActivityType.ArticleRead,
                },
                new AppUserActivity
                {
                    ProjectId = 16,
                    ChallengeId = 0,
                    DateSubmitted = new DateTimeOffset(new DateTime(2025, 1, 3, 0, 1, 0, DateTimeKind.Utc)),
                    ActivityType = ActivityType.ArticleRead,
                },
                new AppUserActivity
                {
                    ProjectId = 17,
                    ChallengeId = 0,
                    DateSubmitted = new DateTimeOffset(new DateTime(2025, 1, 4, 0, 1, 0, DateTimeKind.Utc)),
                    ActivityType = ActivityType.ArticleRead,
                },
                new AppUserActivity
                {
                    ProjectId = 18,
                    ChallengeId = 0,
                    DateSubmitted = new DateTimeOffset(new DateTime(2025, 1, 4, 0, 1, 0, DateTimeKind.Utc)),
                    ActivityType = ActivityType.ArticleRead,
                }
            },

            DashboardProjects = new List<DashboardProject>
            {
                new DashboardProject
                {
                    ProjectId = 18,
                    GithubUrl = string.Empty,
                    IsCompleted = true,
                    IsArchived = false,
                    IsPendingNotification = false,
                    IsPendingReview = false,
                    DateSubmitted = new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)),
                    DateCompleted = new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)),
                    DateRequestedChange = DateTimeOffset.MinValue,
                },
                new DashboardProject
                {
                    ProjectId = 19,
                    GithubUrl = string.Empty,
                    IsCompleted = true,
                    IsArchived = false,
                    IsPendingNotification = false,
                    IsPendingReview = false,
                    DateSubmitted = new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)),
                    DateCompleted = new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)),
                    DateRequestedChange = DateTimeOffset.MinValue,
                },
                new DashboardProject
                {
                    ProjectId = 20,
                    GithubUrl = string.Empty,
                    IsCompleted = true,
                    IsArchived = false,
                    IsPendingNotification = false,
                    IsPendingReview = false,
                    DateSubmitted = new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)),
                    DateCompleted = new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)),
                    DateRequestedChange = DateTimeOffset.MinValue,
                },
                new DashboardProject
                {
                    ProjectId = 21,
                    GithubUrl = string.Empty,
                    IsCompleted = true,
                    IsArchived = false,
                    IsPendingNotification = false,
                    IsPendingReview = false,
                    DateSubmitted = new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)),
                    DateCompleted = new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)),
                    DateRequestedChange = DateTimeOffset.MinValue,
                },
                new DashboardProject
                {
                    ProjectId = 22,
                    GithubUrl = string.Empty,
                    IsCompleted = true,
                    IsArchived = false,
                    IsPendingNotification = false,
                    IsPendingReview = false,
                    DateSubmitted = new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)),
                    DateCompleted = new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)),
                    DateRequestedChange = DateTimeOffset.MinValue,
                },
                new DashboardProject
                {
                    ProjectId = 23,
                    GithubUrl = string.Empty,
                    IsCompleted = true,
                    IsArchived = false,
                    IsPendingNotification = false,
                    IsPendingReview = false,
                    DateSubmitted = new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)),
                    DateCompleted = new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)),
                    DateRequestedChange = DateTimeOffset.MinValue,
                },
                new DashboardProject
                {
                    ProjectId = 24,
                    GithubUrl = string.Empty,
                    IsCompleted = true,
                    IsArchived = false,
                    IsPendingNotification = false,
                    IsPendingReview = false,
                    DateSubmitted = new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)),
                    DateCompleted = new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)),
                    DateRequestedChange = DateTimeOffset.MinValue,
                },
                new DashboardProject
                {
                    ProjectId = 25,
                    GithubUrl = string.Empty,
                    IsCompleted = true,
                    IsArchived = false,
                    IsPendingNotification = false,
                    IsPendingReview = false,
                    DateSubmitted = new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)),
                    DateCompleted = new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)),
                    DateRequestedChange = DateTimeOffset.MinValue,
                },
                new DashboardProject
                {
                    ProjectId = 26,
                    GithubUrl = string.Empty,
                    IsCompleted = true,
                    IsArchived = false,
                    IsPendingNotification = false,
                    IsPendingReview = false,
                    DateSubmitted = new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)),
                    DateCompleted = new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)),
                    DateRequestedChange = DateTimeOffset.MinValue,
                },
                new DashboardProject
                {
                    ProjectId = 27,
                    GithubUrl = string.Empty,
                    IsCompleted = false,
                    IsArchived = false,
                    IsPendingNotification = false,
                    IsPendingReview = true,
                    DateSubmitted = new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)),
                    DateCompleted = new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)),
                    DateRequestedChange = DateTimeOffset.MinValue,
                }
            }

        };
        user4.PasswordHash = hasher.HashPassword(user4, "Password123!");

        var user5 = new ApplicationUser
        {
            Id = Guid.NewGuid().ToString(),
            UserName = "user5@example.com",
            NormalizedUserName = "USER5@EXAMPLE.COM",
            Email = "user5@example.com",
            NormalizedEmail = "USER5@EXAMPLE.COM",
            FirstName = "Walter",
            LastName = "White",
            Country = "Germany",
            ExperiencePoints = 723,
            ReviewExperiencePoints = 500,
            ReviewedProjects = 0,
            EmailConfirmed = true,
            GithubLogin = false,
            Level = Level.Green,

            UserActivity = new List<AppUserActivity>
            {
                new AppUserActivity
                {
                    ProjectId = 19,
                    ChallengeId = 0,
                    DateSubmitted = new DateTimeOffset(new DateTime(2025, 1, 4, 0, 1, 0, DateTimeKind.Utc)
                    ),
                    ActivityType = ActivityType.ProjectCompleted,
                },
                new AppUserActivity
                {
                    ProjectId = 20,
                    ChallengeId = 0,
                    DateSubmitted = new DateTimeOffset(new DateTime(2025, 1, 4, 0, 1, 0, DateTimeKind.Utc)
                    ),
                    ActivityType = ActivityType.ProjectCompleted,
                },
                new AppUserActivity
                {
                    ProjectId = 21,
                    ChallengeId = 0,
                    DateSubmitted = new DateTimeOffset(new DateTime(2025, 1, 4, 0, 1, 0, DateTimeKind.Utc)
                    ),
                    ActivityType = ActivityType.ProjectSubmitted,
                },
            },

            DashboardProjects = new List<DashboardProject>
            {
                new DashboardProject
                {
                    ProjectId = 28,
                    GithubUrl = string.Empty,
                    IsCompleted = true,
                    IsArchived = false,
                    IsPendingNotification = false,
                    IsPendingReview = false,
                    DateSubmitted = new DateTimeOffset(new DateTime(2025, 8, 10, 15, 0, 0, DateTimeKind.Utc)
                    ),
                    DateCompleted = new DateTimeOffset(new DateTime(2025, 8, 10, 16, 0, 0, DateTimeKind.Utc)
                    ),
                },
                new DashboardProject
                {
                    ProjectId = 29,
                    GithubUrl = string.Empty,
                    IsCompleted = true,
                    IsArchived = false,
                    IsPendingNotification = false,
                    IsPendingReview = false,
                    DateSubmitted = new DateTimeOffset(new DateTime(2025, 8, 12, 0, 1, 0, DateTimeKind.Utc)
                    ),
                    DateCompleted = new DateTimeOffset(new DateTime(2025, 8, 10, 15, 0, 0, DateTimeKind.Utc)
                    ),
                },
                new DashboardProject
                {
                    ProjectId = 30,
                    GithubUrl = string.Empty,
                    IsCompleted = true,
                    IsArchived = false,
                    IsPendingNotification = false,
                    IsPendingReview = false,
                    DateSubmitted = new DateTimeOffset(new DateTime(2025, 8, 13, 7, 15, 0, DateTimeKind.Utc)
                    ),
                    DateCompleted = new DateTimeOffset(new DateTime(2025, 8, 13, 15, 02, 0, DateTimeKind.Utc)
                    ),
                },
                new DashboardProject
                {
                    ProjectId = 31,
                    GithubUrl =
                        "https://github.com/TheCSharpAcademy/CodeReviews.Console.Calculator/pull/379",
                    IsCompleted = false,
                    IsArchived = false,
                    IsPendingNotification = false,
                    IsPendingReview = true,
                    DateSubmitted = new DateTimeOffset(new DateTime(2025, 8, 12, 0, 1, 0, DateTimeKind.Utc)
                    ),
                },
            },
        };
        user5.PasswordHash = hasher.HashPassword(user5, "Password123!");

        await context.Users.AddRangeAsync(user1, user2, user3, user4, user5);
        await context.SaveChangesAsync();
    }

    private static async Task SeedChallenges(ApplicationDbContext context)
    {
        var challenges = new List<Challenge>
        {
            // CodeWars Challenges
            new Challenge
            {
                ExternalId = "514b92a657cdc65150000006",
                Name = "Multiples of 3 or 5",
                Description = "If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23. Finish the solution so that it returns the sum of all the multiples of 3 or 5 below the number passed in.",
                Keywords = "algorithms, mathematics, numbers",
                ReleaseDate = new DateTime(2013, 3, 19, 0, 0, 0, DateTimeKind.Utc),
                ExperiencePoints = 10,
                Platform = ChallengePlatform.CodeWars,
                Category = ChallengeCategory.CSharp,
                Level = Level.White
            },
            new Challenge
            {
                ExternalId = "5265326f5fda8eb1160004c8",
                Name = "Convert a Number to a String!",
                Description = "We need a function that can transform a number (integer) into a string. What ways of achieving this do you know?",
                Keywords = "fundamentals, strings, numbers",
                ReleaseDate = new DateTime(2013, 10, 20, 0, 0, 0, DateTimeKind.Utc),
                ExperiencePoints = 5,
                Platform = ChallengePlatform.CodeWars,
                Category = ChallengeCategory.CSharp,
                Level = Level.White
            },
            new Challenge
            {
                ExternalId = "55685cd7ad70877c23000102",
                Name = "Return Negative",
                Description = "In this simple assignment you are given a number and have to make it negative. But maybe the number is already negative?",
                Keywords = "fundamentals, numbers",
                ReleaseDate = new DateTime(2015, 5, 29, 0, 0, 0, DateTimeKind.Utc),
                ExperiencePoints = 5,
                Platform = ChallengePlatform.CodeWars,
                Category = ChallengeCategory.CSharp,
                Level = Level.White
            },
            new Challenge
            {
                ExternalId = "5715eaedb436cf5606000381",
                Name = "Sum of Positive",
                Description = "You get an array of numbers, return the sum of all of the positives ones.",
                Keywords = "arrays, fundamentals, lists",
                ReleaseDate = new DateTime(2014, 7, 28, 0, 0, 0, DateTimeKind.Utc),
                ExperiencePoints = 5,
                Platform = ChallengePlatform.CodeWars,
                Category = ChallengeCategory.CSharp,
                Level = Level.White
            },
            new Challenge
            {
                ExternalId = "5168bb5dfe9a00b126000018",
                Name = "Reversed Strings",
                Description = "Complete the solution so that it reverses the string passed into it.",
                Keywords = "strings, fundamentals",
                ReleaseDate = new DateTime(2013, 4, 13, 0, 0, 0, DateTimeKind.Utc),
                ExperiencePoints = 5,
                Platform = ChallengePlatform.CodeWars,
                Category = ChallengeCategory.CSharp,
                Level = Level.White
            },
            new Challenge
            {
                ExternalId = "583f158ea20cfcbeb400000a",
                Name = "Make a function that does arithmetic!",
                Description = "Given an array of integers. Return an array, where the first element is the count of positives numbers and the second element is sum of negative numbers.",
                Keywords = "arrays, fundamentals",
                ReleaseDate = new DateTime(2016, 4, 18, 0, 0, 0, DateTimeKind.Utc),
                ExperiencePoints = 10,
                Platform = ChallengePlatform.CodeWars,
                Category = ChallengeCategory.CSharp,
                Level = Level.White
            },
            new Challenge
            {
                ExternalId = "52fba66badcd10859f00097e",
                Name = "Disemvowel Trolls",
                Description = "Trolls are attacking your comment section! Remove all vowels from their comments.",
                Keywords = "strings, fundamentals, regex",
                ReleaseDate = new DateTime(2014, 9, 22, 0, 0, 0, DateTimeKind.Utc),
                ExperiencePoints = 15,
                Platform = ChallengePlatform.CodeWars,
                Category = ChallengeCategory.CSharp,
                Level = Level.Yellow
            },
            new Challenge
            {
                ExternalId = "54da5a58ea159efa38000836",
                Name = "Find the odd int",
                Description = "Given an array of integers, find the one that appears an odd number of times.",
                Keywords = "fundamentals, arrays, algorithms",
                ReleaseDate = new DateTime(2015, 2, 9, 0, 0, 0, DateTimeKind.Utc),
                ExperiencePoints = 20,
                Platform = ChallengePlatform.CodeWars,
                Category = ChallengeCategory.CSharp,
                Level = Level.Yellow
            },
            new Challenge
            {
                ExternalId = "5264d2b162488dc400000001",
                Name = "Stop gninnipS My sdroW!",
                Description = "Write a function that takes in a string of one or more words, and returns the same string, but with all five or more letter words reversed.",
                Keywords = "strings, algorithms",
                ReleaseDate = new DateTime(2013, 10, 21, 0, 0, 0, DateTimeKind.Utc),
                ExperiencePoints = 20,
                Platform = ChallengePlatform.CodeWars,
                Category = ChallengeCategory.CSharp,
                Level = Level.Yellow
            },
            new Challenge
            {
                ExternalId = "523f5d21c841566fde000009",
                Name = "Array.diff",
                Description = "Your goal in this kata is to implement a difference function, which subtracts one list from another and returns the result.",
                Keywords = "arrays, fundamentals, algorithms",
                ReleaseDate = new DateTime(2013, 9, 21, 0, 0, 0, DateTimeKind.Utc),
                ExperiencePoints = 20,
                Platform = ChallengePlatform.CodeWars,
                Category = ChallengeCategory.CSharp,
                Level = Level.Yellow
            },
            new Challenge
            {
                ExternalId = "51c8e37cee245da6b40000bd",
                Name = "Strip Comments",
                Description = "Complete the solution so that it strips all text that follows any of a set of comment markers passed in.",
                Keywords = "strings, algorithms, parsing",
                ReleaseDate = new DateTime(2015, 10, 23, 0, 0, 0, DateTimeKind.Utc),
                ExperiencePoints = 30,
                Platform = ChallengePlatform.CodeWars,
                Category = ChallengeCategory.CSharp,
                Level = Level.Orange
            },
            new Challenge
            {
                ExternalId = "52597aa56021e91c93000cb0",
                Name = "Moving Zeros To The End",
                Description = "Write an algorithm that takes an array and moves all of the zeros to the end, preserving the order of the other elements.",
                Keywords = "arrays, sorting, algorithms",
                ReleaseDate = new DateTime(2013, 10, 12, 0, 0, 0, DateTimeKind.Utc),
                ExperiencePoints = 30,
                Platform = ChallengePlatform.CodeWars,
                Category = ChallengeCategory.CSharp,
                Level = Level.Orange
            },
            
            // LeetCode Challenges
            new Challenge
            {
                ExternalId = "two-sum",
                Name = "Two Sum",
                Description = "Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target. You may assume that each input would have exactly one solution, and you may not use the same element twice.",
                Keywords = "array, hash table",
                ReleaseDate = new DateTime(2015, 6, 15, 0, 0, 0, DateTimeKind.Utc),
                ExperiencePoints = 10,
                Platform = ChallengePlatform.LeetCode,
                Category = ChallengeCategory.CSharp,
                Level = Level.White
            },
            new Challenge
            {
                ExternalId = "search-insert-position",
                Name = "Search Insert Position",
                Description = "Given a sorted array of distinct integers and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.",
                Keywords = "array, binary search",
                ReleaseDate = new DateTime(2015, 8, 20, 0, 0, 0, DateTimeKind.Utc),
                ExperiencePoints = 10,
                Platform = ChallengePlatform.LeetCode,
                Category = ChallengeCategory.CSharp,
                Level = Level.White
            },
            new Challenge
            {
                ExternalId = "first-bad-version",
                Name = "First Bad Version",
                Description = "You are a product manager and currently leading a team to develop a new product. Since each version is developed based on the previous version, all the versions after a bad version are also bad. Suppose you have n versions [1, 2, ..., n] and you want to find out the first bad one.",
                Keywords = "binary search, interactive",
                ReleaseDate = new DateTime(2015, 9, 25, 0, 0, 0, DateTimeKind.Utc),
                ExperiencePoints = 10,
                Platform = ChallengePlatform.LeetCode,
                Category = ChallengeCategory.CSharp,
                Level = Level.White
            },
            new Challenge
            {
                ExternalId = "guess-number-higher-or-lower",
                Name = "Guess Number Higher or Lower",
                Description = "We are playing the Guess Game. The game is as follows: I pick a number from 1 to n. You have to guess which number I picked. Every time you guess wrong, I will tell you whether the number I picked is higher or lower than your guess.",
                Keywords = "binary search, interactive",
                ReleaseDate = new DateTime(2016, 3, 10, 0, 0, 0, DateTimeKind.Utc),
                ExperiencePoints = 10,
                Platform = ChallengePlatform.LeetCode,
                Category = ChallengeCategory.CSharp,
                Level = Level.White
            },
            new Challenge
            {
                ExternalId = "baseball-game",
                Name = "Baseball Game",
                Description = "You are keeping score for a baseball game with strange rules. The game consists of several rounds, where the scores of past rounds may affect future rounds' scores. At the beginning of the game, you start with an empty record.",
                Keywords = "array, stack, simulation",
                ReleaseDate = new DateTime(2017, 5, 15, 0, 0, 0, DateTimeKind.Utc),
                ExperiencePoints = 10,
                Platform = ChallengePlatform.LeetCode,
                Category = ChallengeCategory.CSharp,
                Level = Level.White
            },
            new Challenge
            {
                ExternalId = "longest-substring-without-repeating-characters",
                Name = "Longest Substring Without Repeating Characters",
                Description = "Given a string s, find the length of the longest substring without repeating characters.",
                Keywords = "hash table, string, sliding window",
                ReleaseDate = new DateTime(2014, 6, 5, 0, 0, 0, DateTimeKind.Utc),
                ExperiencePoints = 20,
                Platform = ChallengePlatform.LeetCode,
                Category = ChallengeCategory.CSharp,
                Level = Level.White
            }
        };

        await context.Challenges.AddRangeAsync(challenges);
        await context.SaveChangesAsync();
    }
}
