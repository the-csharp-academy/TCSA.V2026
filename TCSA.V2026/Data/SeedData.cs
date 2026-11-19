using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TCSA.V2026.Data.Enums;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Models;

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
            DailyStreak = new DailyStreak
            {
                CurrentStreak = 3,
                LongestStreak = 7,
                LastCompletedDate = DateTime.UtcNow.Date,
            },
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
                },
                new DashboardProject
                {
                    ProjectId = 207,
                    GithubUrl = "https://github.com/TheCSharpAcademy/TCSA.V2/pull/501",
                    IsCompleted = true,
                    IsArchived = false,
                    IsPendingNotification = false,
                    IsPendingReview = false,
                    DateSubmitted = new DateTimeOffset(new DateTime(2025, 8, 15, 10, 0, 0, DateTimeKind.Utc)),
                    DateCompleted = new DateTimeOffset(new DateTime(2025, 8, 16, 12, 0, 0, DateTimeKind.Utc)),
                    DateRequestedChange = DateTimeOffset.MinValue,
                },
                // Freestyle project
                new DashboardProject
                {
                    ProjectId = 100001,
                    GithubUrl = "https://github.com/TheCSharpAcademy/CodeReviews.Freestyle/pull/1",
                    IsCompleted = true,
                    IsArchived = true,
                    IsPendingNotification = false,
                    IsPendingReview = false,
                    DateSubmitted = new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, DateTimeKind.Utc)),
                    DateCompleted = new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, DateTimeKind.Utc)),
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
                    ActivityType = ActivityType.ProjectCompleted,
                },
                new AppUserActivity
                {
                    ProjectId = 12,
                    ChallengeId = 0,
                    DateSubmitted = new DateTimeOffset(new DateTime(2025, 1, 4, 0, 1, 0, DateTimeKind.Utc)),
                    ActivityType = ActivityType.ProjectSubmitted,
                },
                new AppUserActivity
                {
                    ProjectId = 13,
                    ChallengeId = 0,
                    DateSubmitted = new DateTimeOffset(new DateTime(2025, 1, 4, 0, 1, 0, DateTimeKind.Utc)),
                    ActivityType = ActivityType.ProjectCompleted,
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
                    IsCompleted = false,
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
                    ActivityType = ActivityType.ProjectCompleted,
                },
                new AppUserActivity
                {
                    ProjectId = 15,
                    ChallengeId = 0,
                    DateSubmitted = new DateTimeOffset(new DateTime(2025, 1, 2, 0, 1, 0, DateTimeKind.Utc)),
                    ActivityType = ActivityType.ProjectCompleted,
                },
                new AppUserActivity
                {
                    ProjectId = 16,
                    ChallengeId = 0,
                    DateSubmitted = new DateTimeOffset(new DateTime(2025, 1, 3, 0, 1, 0, DateTimeKind.Utc)),
                    ActivityType = ActivityType.ProjectCompleted,
                },
                new AppUserActivity
                {
                    ProjectId = 17,
                    ChallengeId = 0,
                    DateSubmitted = new DateTimeOffset(new DateTime(2025, 1, 4, 0, 1, 0, DateTimeKind.Utc)),
                    ActivityType = ActivityType.ProjectCompleted,
                },
                new AppUserActivity
                {
                    ProjectId = 18,
                    ChallengeId = 0,
                    DateSubmitted = new DateTimeOffset(new DateTime(2025, 1, 4, 0, 1, 0, DateTimeKind.Utc)),
                    ActivityType = ActivityType.ProjectCompleted,
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

        var adminRole = new IdentityRole
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Admin",
            NormalizedName = "ADMIN"
        };

        var admin = new ApplicationUser
        {
            Id = Guid.NewGuid().ToString(),
            UserName = "admin@example.com",
            NormalizedUserName = "ADMIN@EXAMPLE.COM",
            Email = "admin@example.com",
            NormalizedEmail = "ADMIN@EXAMPLE.COM",
            FirstName = "Admin",
            LastName = "User",
            Country = "USA",
            ExperiencePoints = 0,
            ReviewExperiencePoints = 0,
            ReviewedProjects = 0,
            EmailConfirmed = true,
            GithubLogin = false,
            Level = Level.White
        };
        admin.PasswordHash = hasher.HashPassword(admin, "Password123!");

        var adminUserRole = new IdentityUserRole<string>
        {
            RoleId = adminRole.Id,
            UserId = admin.Id
        };

        await context.Roles.AddAsync(adminRole);
        await context.Users.AddRangeAsync(user1, user2, user3, user4, user5, admin);
        await context.UserRoles.AddAsync(adminUserRole);

        await context.SaveChangesAsync();

        await SeedCommunityIssues(context, user1.Id);
        await SeedBadges(context, user1.Id, user2.Id, user3.Id, user4.Id);
        await SeedResetAccountData(context, user1.Id, user3.Id);
        await SeedDeleteAccountData(context, user2.Id, user3.Id);
        await SeedSurvey(context, user1.Id, user2.Id, user3.Id, user4.Id);
        await SeedFeedback(context, user1.Id, user2.Id, user3.Id, user4.Id, user5.Id);
    }

    // Separate user with a row in every user-linked table, so DeleteAccount can be tried without losing the ResetAccount data on user1
    private static async Task SeedDeleteAccountData(ApplicationDbContext context, string reviewerId, string reviewedUserId)
    {
        var hasher = new PasswordHasher<ApplicationUser>();

        var user = new ApplicationUser
        {
            Id = Guid.NewGuid().ToString(),
            UserName = "delete@example.com",
            NormalizedUserName = "DELETE@EXAMPLE.COM",
            Email = "delete@example.com",
            NormalizedEmail = "DELETE@EXAMPLE.COM",
            FirstName = "Delete",
            LastName = "Me",
            Country = "USA",
            ExperiencePoints = 300,
            ReviewExperiencePoints = 100,
            ReviewedProjects = 1,
            EmailConfirmed = true,
            GithubLogin = false,
            Level = Level.Yellow,
            DailyStreak = new DailyStreak
            {
                CurrentStreak = 2,
                LongestStreak = 4,
                LastCompletedDate = DateTime.UtcNow.Date,
            },
            DashboardProjects = new List<DashboardProject>
            {
                new DashboardProject
                {
                    ProjectId = 5,
                    GithubUrl = string.Empty,
                    IsCompleted = true,
                    DateSubmitted = new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)),
                    DateCompleted = new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)),
                    DateRequestedChange = DateTimeOffset.MinValue,
                },
                new DashboardProject
                {
                    ProjectId = 6,
                    GithubUrl = "https://github.com/TheCSharpAcademy/CodeReviews.Console.Calculator/pull/500",
                    IsPendingReview = true,
                    DateSubmitted = new DateTimeOffset(new DateTime(2025, 1, 2, 0, 0, 0, DateTimeKind.Utc)),
                },
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
            },
            Issues = new List<CommunityIssue>
            {
                new CommunityIssue
                {
                    Title = "Add dark mode to the Statistics page",
                    ProjectId = 207,
                    CommunityProjectId = (int)CommunityProject.TCSA,
                    ExperiencePoints = 10,
                    Type = IssueType.Feature,
                    GithubUrl = "https://github.com/TheCSharpAcademy/TCSA.V2/issues/510",
                    IconUrl = "icons8-construction-64.png",
                    IsClosed = true,
                },
            },
            Comments = new List<Comments>
            {
                new Comments
                {
                    ArticleId = 5,
                    Comment = "Great article, thanks!",
                    Date = new DateTimeOffset(new DateTime(2025, 1, 1, 0, 2, 0, DateTimeKind.Utc)),
                    IsReviewed = true,
                },
            },
        };
        user.PasswordHash = hasher.HashPassword(user, "Password123!");

        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();

        var challengeId = await context.Challenges.OrderBy(c => c.Id).Select(c => c.Id).FirstAsync();
        var ownProject = user.DashboardProjects.First(dp => dp.IsCompleted);
        var ownPendingProject = user.DashboardProjects.First(dp => dp.IsPendingReview);
        var reviewedProject = await context.DashboardProjects
            .FirstAsync(dp => dp.AppUserId == reviewedUserId && dp.IsPendingReview);

        await context.Badges.AddAsync(new Badge
        {
            BadgeId = (int)BadgeId.CodeReviewer,
            UserId = user.Id,
            DateAwarded = new DateTimeOffset(new DateTime(2025, 1, 10, 0, 0, 0, DateTimeKind.Utc)),
        });
        await context.UserChallenges.AddAsync(new UserChallenge
        {
            ChallengeId = challengeId,
            UserId = user.Id,
            CompletedAt = new DateTime(2025, 1, 5, 0, 0, 0, DateTimeKind.Utc),
        });
        await context.ShowcaseItems.AddAsync(new ShowcaseItem
        {
            AppUserId = user.Id,
            DashboardProjectId = ownProject.Id,
            VideoUrl = "https://www.youtube.com/watch?v=dQw4w9WgXcQ",
            GithubUrl = "https://github.com/TheCSharpAcademy/CodeReviews.Console.Calculator/pull/2",
        });
        // One review done by the user and one done on the user's project
        await context.UserReviews.AddRangeAsync(
            new UserReview { AppUserId = user.Id, DashboardProjectId = reviewedProject.Id },
            new UserReview { AppUserId = reviewerId, DashboardProjectId = ownPendingProject.Id });

        await context.UserStripe.AddAsync(new UserStripe
        {
            AppUserId = user.Id,
            StripeCustomerId = "cus_seed_delete",
            StripePaymentMethodId = "pm_seed_delete",
            Status = AccountabilityStatus.Active,
        });
        await context.UserAccountabilityProjects.AddAsync(new UserAccountabilityProject
        {
            AppUserId = user.Id,
            ProjectId = 6,
            DeadLineUtc = DateTime.UtcNow.AddDays(14),
            PledgeCents = 1000,
            StripePaymentIntentId = "pi_seed_delete_pledge",
        });
        await context.UserDonations.AddAsync(new UserDonation
        {
            AppUserId = user.Id,
            AmountCents = 500,
            Status = DonationStatus.Succeeded,
            PaidUtc = DateTime.UtcNow,
            StripeCheckoutSessionId = "cs_seed_delete",
            StripePaymentIntentId = "pi_seed_delete_donation",
        });
        // Not linked to a user, seeded only so every DbSet has a row
        await context.WebhookDebugLog.AddAsync(new WebhookDebugLog
        {
            Log = "Seed webhook log",
            DateTime = DateTime.UtcNow,
            LogType = LogType.Success,
        });

        await context.SaveChangesAsync();
    }

    // Gives user1 a row in every table ResetAccount clears that isn't seeded elsewhere
    private static async Task SeedResetAccountData(ApplicationDbContext context, string userId, string reviewedUserId)
    {
        var challengeIds = await context.Challenges
            .OrderBy(c => c.Id)
            .Take(2)
            .Select(c => c.Id)
            .ToListAsync();

        var userChallenges = challengeIds.Select(challengeId => new UserChallenge
        {
            ChallengeId = challengeId,
            UserId = userId,
            CompletedAt = new DateTime(2025, 1, 5, 0, 0, 0, DateTimeKind.Utc),
        });

        var showcasedProject = await context.DashboardProjects
            .FirstAsync(dp => dp.AppUserId == userId && dp.ProjectId == 5);

        var reviewedProject = await context.DashboardProjects
            .FirstAsync(dp => dp.AppUserId == reviewedUserId && dp.IsPendingReview);

        await context.UserChallenges.AddRangeAsync(userChallenges);
        await context.ShowcaseItems.AddAsync(new ShowcaseItem
        {
            AppUserId = userId,
            DashboardProjectId = showcasedProject.Id,
            VideoUrl = "https://www.youtube.com/watch?v=dQw4w9WgXcQ",
            GithubUrl = "https://github.com/TheCSharpAcademy/CodeReviews.Console.Calculator/pull/1",
        });
        await context.UserReviews.AddAsync(new UserReview
        {
            AppUserId = userId,
            DashboardProjectId = reviewedProject.Id,
        });

        await context.SaveChangesAsync();
    }

    // Widget feedback covering every category and review state, with a few clusters (same category and page) of different sizes.
    private static async Task SeedFeedback(ApplicationDbContext context, string user1Id, string user2Id, string user3Id, string user4Id, string user5Id)
    {
        static DateTimeOffset At(int month, int day, int hour, int minute = 0) =>
            new(new DateTime(2026, month, day, hour, minute, 0, DateTimeKind.Utc));

        static FeedbackItem Item(
            string userId, FeedbackCategory category, string body, string originUrl, DateTimeOffset createdAt,
            FeedbackReviewState state = FeedbackReviewState.New, FeedbackArea? area = null, string? reportedPage = null) =>
            new()
            {
                AppUserId = userId,
                Category = category,
                Body = body,
                OriginUrl = originUrl,
                ReportedPage = reportedPage,
                Area = area,
                ReviewState = state,
                CreatedAt = createdAt
            };

        var longBody = """
            When I open the peer review page on my phone the review cards overflow the screen and I have to scroll sideways to reach the Approve button.

            Steps to reproduce:
            1. Open /dashboard/peer-reviews on a phone (360px wide)
            2. Open any assigned review
            3. Try to tap Approve

            I expected the buttons to wrap under the description instead.
            """;

        var items = new List<FeedbackItem>
        {
            // Bug cluster on the profile page: 4 items, 3 still New.
            Item(user1Id, FeedbackCategory.Bug, "Saving my profile shows a success message but the GitHub username is not updated.",
                "/dashboard/profile", At(10, 2, 9, 10), area: FeedbackArea.Profile, reportedPage: "/dashboard/profile"),
            Item(user2Id, FeedbackCategory.Bug, "Profile save does nothing when I change my display name.",
                "/dashboard/profile", At(10, 3, 14, 5), area: FeedbackArea.Profile, reportedPage: "/dashboard/profile"),
            Item(user3Id, FeedbackCategory.Bug, "The avatar does not refresh after saving the profile.",
                "/dashboard", At(10, 4, 18, 40), FeedbackReviewState.Reviewed, FeedbackArea.Profile, "/dashboard/profile"),
            Item(user4Id, FeedbackCategory.Bug, "Profile page throws an error when the bio contains an emoji.",
                "/dashboard/profile", At(10, 6, 7, 55), area: FeedbackArea.Profile, reportedPage: "/dashboard/profile"),

            // Bug cluster on another page, reported from a different page than the one it concerns.
            Item(user2Id, FeedbackCategory.Bug, "Submit project dialog closes without submitting when I press Enter in the repo URL field.",
                "/dashboard", At(10, 5, 11, 30), area: FeedbackArea.Projects, reportedPage: "/dashboard/projects"),
            Item(user5Id, FeedbackCategory.Bug, "The Submit button stays disabled after I fix the repo URL.",
                "/dashboard/projects", At(10, 7, 20, 15), area: FeedbackArea.Projects, reportedPage: "/dashboard/projects"),

            // Fully handled cluster: it stays in All Feedback but not in Needs Review.
            Item(user1Id, FeedbackCategory.Bug, "Leaderboard shows the wrong rank for users with equal XP.",
                "/dashboard/leaderboard", At(9, 20, 10, 0), FeedbackReviewState.Actioned, FeedbackArea.Leaderboard, "/dashboard/leaderboard"),
            Item(user4Id, FeedbackCategory.Bug, "Ties on the leaderboard are ordered randomly between page loads.",
                "/dashboard/leaderboard", At(9, 22, 16, 20), FeedbackReviewState.Actioned, FeedbackArea.Leaderboard, "/dashboard/leaderboard"),

            // A bug with a long, multi-line body.
            Item(user3Id, FeedbackCategory.Bug, longBody,
                "/dashboard/peer-reviews", At(10, 8, 13, 45), area: FeedbackArea.PeerReviews, reportedPage: "/dashboard/peer-reviews"),

            // Idea cluster from the dashboard.
            Item(user1Id, FeedbackCategory.Idea, "It would be great to filter the roadmap by technology.",
                "/dashboard/roadmap", At(10, 1, 8, 30)),
            Item(user3Id, FeedbackCategory.Idea, "Add a dark theme preview to the theme toggle.",
                "/dashboard/roadmap", At(10, 3, 19, 0), FeedbackReviewState.Reviewed),
            Item(user5Id, FeedbackCategory.Idea, "Let me sort the roadmap by the XP I would earn.",
                "/dashboard/roadmap", At(10, 7, 9, 5)),
            Item(user2Id, FeedbackCategory.Idea, "Email me when someone finishes reviewing my project.",
                "/dashboard/peer-reviews", At(10, 5, 22, 10), FeedbackReviewState.Archived),

            // Help / Confusion.
            Item(user4Id, FeedbackCategory.Help, "I do not understand how belts and XP are connected. Where is this explained?",
                "/dashboard", At(10, 2, 21, 30)),
            Item(user5Id, FeedbackCategory.Help, "How do I get a reviewer assigned to my project?",
                "/dashboard/projects", At(10, 6, 15, 50), FeedbackReviewState.Actioned),

            // Compliments.
            Item(user2Id, FeedbackCategory.Compliment, "The courses are fantastic. I finished the SQL course in a week.",
                "/dashboard/courses", At(10, 4, 12, 0)),
            Item(user1Id, FeedbackCategory.Compliment, "Thank you to everyone who reviewed my first project so quickly!",
                "/dashboard/peer-reviews", At(10, 8, 17, 25), FeedbackReviewState.Reviewed),

            // User text with markup and an unbroken string: both must render as inert, wrapped plain text.
            Item(user3Id, FeedbackCategory.Idea, "<script>alert('xss')</script><b>Bold</b> & <img src=x onerror=alert(1)>",
                "/dashboard/community", At(10, 9, 10, 15)),
            Item(user4Id, FeedbackCategory.Help, new string('x', 400),
                "/dashboard/challenges", At(10, 9, 11, 30)),
        };

        await context.FeedbackItems.AddRangeAsync(items);
        await context.SaveChangesAsync();
    }

    // user5 is left without a response so the survey stays available to submit.
    private static async Task SeedSurvey(ApplicationDbContext context, string user1Id, string user2Id, string user3Id, string user4Id)
    {
        var survey = new Survey
        {
            Title = "Platform feedback 2026",
            Description = "Tell us how the Academy is working for you. Twelve questions, most of them optional.",
            Status = SurveyStatus.Active,
            CreatedAt = new DateTimeOffset(new DateTime(2026, 9, 1, 9, 0, 0, DateTimeKind.Utc)),
            Questions =
            [
                RatingQuestion.Create("How would you rate your overall experience on the Academy?", true, 0),
                YesNoQuestion.Create("Would you recommend the Academy to a friend?", true, 1),
                SingleChoiceQuestion.Create("How often do you work on Academy projects?", true, 2,
                    ["Daily", "A few times a week", "Weekly", "Less than weekly"]),
                MultipleChoiceQuestion.Create("Which parts of the platform do you use?", false, 3,
                    ["Projects", "Peer reviews", "Courses", "Challenges", "Community issues", "Leaderboard"]),
                FreeTextQuestion.Create("What is the one thing we should improve first?", false, 4),
                RatingQuestion.Create("How helpful are the peer reviews you receive?", false, 5),
                FreeTextQuestion.Create("What would make peer reviews more useful?", false, 6),
                YesNoQuestion.Create("Have you contributed to a community project?", false, 7),
                SingleChoiceQuestion.Create("How did you hear about the Academy?", false, 8,
                    ["YouTube", "Search engine", "A friend", "Discord", "Other"]),
                MultipleChoiceQuestion.Create("Which technologies do you want more content on?", true, 9,
                    ["ASP.NET Core", "Blazor", "Entity Framework", "Testing", "Cloud and Azure", "Desktop (WPF, MAUI)", "Game development"]),
                FreeTextQuestion.Create("Think about the last project you completed from start to finish, including the reading, the coding, the submission and the peer review. Which step slowed you down the most, and what would have helped you move through it faster?", false, 10),
                FreeTextQuestion.Create("Anything else you want to tell us?", false, 11),
            ]
        };

        await context.Surveys.AddAsync(survey);
        await context.SaveChangesAsync();

        var questions = await context.SurveyQuestions
            .OfType<ChoiceQuestion>()
            .Include(q => q.Options)
            .Where(q => q.SurveyId == survey.Id)
            .ToListAsync();
        var questionIds = await context.SurveyQuestions
            .Where(q => q.SurveyId == survey.Id)
            .ToDictionaryAsync(q => q.Order, q => q.Id);

        int Q(int order) => questionIds[order];
        int Option(int order, int index) => questions.Single(q => q.Id == Q(order)).Options.OrderBy(o => o.Order).ElementAt(index).Id;

        var longText = """
            The reading material is great, but the gap between finishing the code and getting a review is where I lose momentum.

            Things that would help:
            - an estimate of how long a review usually takes
            - a reminder when a reviewer has not replied after a few days
            - a way to see which projects are waiting for a reviewer

            I also lost a full evening to a setup problem that was not in the instructions, so a short troubleshooting section on each project page would save a lot of time.
            """;
        var unbrokenText = new string('x', 300);

        var responses = new List<SurveyResponse>
        {
            // user1: answered everything, with long multi-line text and an unbroken string that must wrap.
            new()
            {
                SurveyId = survey.Id,
                AppUserId = user1Id,
                SubmittedAt = new DateTimeOffset(new DateTime(2026, 9, 3, 18, 30, 0, DateTimeKind.Utc)),
                Answers =
                [
                    RatingAnswer.Create(Q(0), 4),
                    YesNoAnswer.Create(Q(1), true),
                    SingleChoiceAnswer.Create(Q(2), Option(2, 1)),
                    MultipleChoiceAnswer.Create(Q(3), [Option(3, 0), Option(3, 1), Option(3, 2), Option(3, 3), Option(3, 4), Option(3, 5)]),
                    FreeTextAnswer.Create(Q(4), "Faster peer review turnaround."),
                    RatingAnswer.Create(Q(5), 3),
                    FreeTextAnswer.Create(Q(6), unbrokenText),
                    YesNoAnswer.Create(Q(7), true),
                    SingleChoiceAnswer.Create(Q(8), Option(8, 0)),
                    MultipleChoiceAnswer.Create(Q(9), [Option(9, 0), Option(9, 1), Option(9, 3)]),
                    FreeTextAnswer.Create(Q(10), longText),
                    FreeTextAnswer.Create(Q(11), "Thanks for the Academy."),
                ]
            },
            // user2: only the required questions, so every optional one shows as skipped.
            new()
            {
                SurveyId = survey.Id,
                AppUserId = user2Id,
                SubmittedAt = new DateTimeOffset(new DateTime(2026, 9, 4, 8, 15, 0, DateTimeKind.Utc)),
                Answers =
                [
                    RatingAnswer.Create(Q(0), 5),
                    YesNoAnswer.Create(Q(1), true),
                    SingleChoiceAnswer.Create(Q(2), Option(2, 0)),
                    MultipleChoiceAnswer.Create(Q(9), [Option(9, 2)]),
                ]
            },
            // user3: answered everything with short answers.
            new()
            {
                SurveyId = survey.Id,
                AppUserId = user3Id,
                SubmittedAt = new DateTimeOffset(new DateTime(2026, 9, 5, 21, 45, 0, DateTimeKind.Utc)),
                Answers =
                [
                    RatingAnswer.Create(Q(0), 2),
                    YesNoAnswer.Create(Q(1), false),
                    SingleChoiceAnswer.Create(Q(2), Option(2, 3)),
                    MultipleChoiceAnswer.Create(Q(3), [Option(3, 0)]),
                    FreeTextAnswer.Create(Q(4), "Clearer project instructions."),
                    RatingAnswer.Create(Q(5), 1),
                    FreeTextAnswer.Create(Q(6), "Reviewers should leave more detail."),
                    YesNoAnswer.Create(Q(7), false),
                    SingleChoiceAnswer.Create(Q(8), Option(8, 4)),
                    MultipleChoiceAnswer.Create(Q(9), [Option(9, 6), Option(9, 5)]),
                    FreeTextAnswer.Create(Q(10), "Waiting for a review."),
                    FreeTextAnswer.Create(Q(11), "No."),
                ]
            },
            // user4: required questions plus a scattering of optional ones.
            new()
            {
                SurveyId = survey.Id,
                AppUserId = user4Id,
                SubmittedAt = new DateTimeOffset(new DateTime(2026, 9, 6, 12, 0, 0, DateTimeKind.Utc)),
                Answers =
                [
                    RatingAnswer.Create(Q(0), 3),
                    YesNoAnswer.Create(Q(1), true),
                    SingleChoiceAnswer.Create(Q(2), Option(2, 2)),
                    MultipleChoiceAnswer.Create(Q(3), [Option(3, 1), Option(3, 5)]),
                    YesNoAnswer.Create(Q(7), true),
                    MultipleChoiceAnswer.Create(Q(9), [Option(9, 1), Option(9, 4)]),
                    FreeTextAnswer.Create(Q(11), "More Blazor content, please."),
                ]
            },
        };

        await context.SurveyResponses.AddRangeAsync(responses);
        await context.SaveChangesAsync();
    }

    private static async Task SeedBadges(ApplicationDbContext context, string user1Id, string user2Id, string user3Id, string user4Id)
    {
        var badges = new List<Badge>
        {
            // user1: merged a community PR, completed their first peer review, and just now reached Trusted Reviewer (pending notification)
            new Badge { BadgeId = (int)BadgeId.PlatformBuilder, UserId = user1Id, DateAwarded = new DateTimeOffset(new DateTime(2025, 8, 16, 12, 0, 0, DateTimeKind.Utc)) },
            new Badge { BadgeId = (int)BadgeId.CodeReviewer, UserId = user1Id, DateAwarded = new DateTimeOffset(new DateTime(2025, 1, 10, 0, 0, 0, DateTimeKind.Utc)) },
            new Badge { BadgeId = (int)BadgeId.TrustedReviewer, UserId = user1Id, DateAwarded = DateTimeOffset.UtcNow.AddDays(-2), IsPendingNotification = true },

            // user2: progressed to Trusted Reviewer
            new Badge { BadgeId = (int)BadgeId.CodeReviewer, UserId = user2Id, DateAwarded = new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, DateTimeKind.Utc)) },
            new Badge { BadgeId = (int)BadgeId.TrustedReviewer, UserId = user2Id, DateAwarded = new DateTimeOffset(new DateTime(2025, 4, 15, 0, 0, 0, DateTimeKind.Utc)) },

            // user3: progressed to Master Reviewer, merged their first community PR, and just now jumped to Platform Contributor + Platform Architect (two pending notifications at once)
            new Badge { BadgeId = (int)BadgeId.CodeReviewer, UserId = user3Id, DateAwarded = new DateTimeOffset(new DateTime(2025, 1, 15, 0, 0, 0, DateTimeKind.Utc)) },
            new Badge { BadgeId = (int)BadgeId.TrustedReviewer, UserId = user3Id, DateAwarded = new DateTimeOffset(new DateTime(2025, 3, 20, 0, 0, 0, DateTimeKind.Utc)) },
            new Badge { BadgeId = (int)BadgeId.MasterReviewer, UserId = user3Id, DateAwarded = new DateTimeOffset(new DateTime(2025, 7, 1, 0, 0, 0, DateTimeKind.Utc)) },
            new Badge { BadgeId = (int)BadgeId.PlatformBuilder, UserId = user3Id, DateAwarded = new DateTimeOffset(new DateTime(2025, 6, 1, 0, 0, 0, DateTimeKind.Utc)) },
            new Badge { BadgeId = (int)BadgeId.PlatformContributor, UserId = user3Id, DateAwarded = DateTimeOffset.UtcNow.AddDays(-1), IsPendingNotification = true },
            new Badge { BadgeId = (int)BadgeId.PlatformArchitect, UserId = user3Id, DateAwarded = DateTimeOffset.UtcNow.AddDays(-1), IsPendingNotification = true },

            // user4: maxed out every badge family
            new Badge { BadgeId = (int)BadgeId.PlatformBuilder, UserId = user4Id, DateAwarded = new DateTimeOffset(new DateTime(2025, 3, 1, 0, 0, 0, DateTimeKind.Utc)) },
            new Badge { BadgeId = (int)BadgeId.PlatformContributor, UserId = user4Id, DateAwarded = new DateTimeOffset(new DateTime(2025, 6, 15, 0, 0, 0, DateTimeKind.Utc)) },
            new Badge { BadgeId = (int)BadgeId.PlatformArchitect, UserId = user4Id, DateAwarded = new DateTimeOffset(new DateTime(2025, 9, 10, 0, 0, 0, DateTimeKind.Utc)) },
            new Badge { BadgeId = (int)BadgeId.CodeReviewer, UserId = user4Id, DateAwarded = new DateTimeOffset(new DateTime(2025, 2, 10, 0, 0, 0, DateTimeKind.Utc)) },
            new Badge { BadgeId = (int)BadgeId.TrustedReviewer, UserId = user4Id, DateAwarded = new DateTimeOffset(new DateTime(2025, 5, 5, 0, 0, 0, DateTimeKind.Utc)) },
            new Badge { BadgeId = (int)BadgeId.MasterReviewer, UserId = user4Id, DateAwarded = new DateTimeOffset(new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc)) },

            // user5 intentionally has no badges yet — demonstrates the fully-locked state
        };

        await context.Badges.AddRangeAsync(badges);
        await context.SaveChangesAsync();
    }
    private static async Task SeedCommunityIssues(ApplicationDbContext context, string userId)
    {
        var issues = new List<CommunityIssue>
        {
            new CommunityIssue
            {
                Title = "Add pagination to the community feed",
                AppUserId = userId,
                ProjectId = 207,
                CommunityProjectId = (int)CommunityProject.TCSA,
                ExperiencePoints = 20,
                Type = IssueType.Feature,
                GithubUrl = "https://github.com/TheCSharpAcademy/TCSA.V2/issues/498",
                IconUrl = "icons8-construction-64.png",
                IsClosed = true,
            },
            new CommunityIssue
            {
                Title = "Fix broken link on the Contact page",
                AppUserId = userId,
                ProjectId = 207,
                CommunityProjectId = (int)CommunityProject.TCSA,
                ExperiencePoints = 10,
                Type = IssueType.Bugfix,
                GithubUrl = "https://github.com/TheCSharpAcademy/TCSA.V2/issues/480",
                IconUrl = "icons8-construction-64.png",
                IsClosed = true,
            },
            new CommunityIssue
            {
                Title = "Translate the Privacy page to Portuguese",
                AppUserId = userId,
                ProjectId = 207,
                CommunityProjectId = (int)CommunityProject.TCSA,
                ExperiencePoints = 15,
                Type = IssueType.Translation,
                GithubUrl = "https://github.com/TheCSharpAcademy/TCSA.V2/issues/462",
                IconUrl = "icons8-construction-64.png",
                IsClosed = true,
            },
        };

        await context.Issues.AddRangeAsync(issues);
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
