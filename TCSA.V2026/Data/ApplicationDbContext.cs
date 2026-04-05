using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Models;

namespace TCSA.V2026.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public virtual DbSet<ApplicationUser> AspNetUsers { get; set; }
    public virtual DbSet<AppUserActivity> UserActivity { get; set; }
    public virtual DbSet<DashboardProject> DashboardProjects { get; set; }
    public virtual DbSet<CommunityIssue> Issues { get; set; }
    public virtual DbSet<Challenge> Challenges { get; set; }
    public virtual DbSet<UserChallenge> UserChallenges { get; set; }
    public virtual DbSet<DailyStreak> DailyStreaks { get; set; }
    public virtual DbSet<ShowcaseItem> ShowcaseItems { get; set; }
    public virtual DbSet<UserReview> UserReviews { get; set; }
    public virtual DbSet<UserStripe> UserStripe { get; set; }
    public virtual DbSet<UserAccountabilityProject> UserAccountabilityProjects { get; set; }
    public virtual DbSet<UserDonation> UserDonations { get; set; }
    public virtual DbSet<WebhookDebugLog> WebhookDebugLog { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<AppUserActivity>()
            .HasOne(aua => aua.DashboardProject)
            .WithMany()
            .HasForeignKey(aua => aua.ProjectId)
            .HasPrincipalKey(dp => dp.ProjectId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<AppUserActivity>()
            .HasOne(aua => aua.ApplicationUser)
            .WithMany(u => u.UserActivity)
            .HasForeignKey(aua => aua.AppUserId);

        modelBuilder.Entity<AppUserActivity>()
            .HasIndex(aua => new { aua.DateSubmitted, aua.AppUserId })
            .IsDescending();

        modelBuilder.Entity<ApplicationUser>()
            .HasIndex(u => new { u.CreatedDate, u.Id })
            .IsDescending();

        modelBuilder.Entity<UserReview>()
            .HasOne(ur => ur.User)
            .WithMany(u => u.CodeReviewProjects)
            .HasForeignKey(ur => ur.AppUserId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        modelBuilder.Entity<Challenge>()
            .HasIndex(c => c.ExternalId)
            .IsUnique();

        modelBuilder.Entity<Challenge>()
            .Property(c => c.Name)
            .IsRequired();

        modelBuilder.Entity<Challenge>()
            .HasAlternateKey(c => c.Name)
            .HasName("AlternateKey_Name");

        modelBuilder.Entity<UserChallenge>()
            .HasKey(uc => new { uc.ChallengeId, uc.UserId });

        modelBuilder.Entity<UserChallenge>()
            .HasOne(uc => uc.Challenge)
            .WithMany(c => c.UserChallenges)
            .HasForeignKey(uc => uc.ChallengeId);

        modelBuilder.Entity<UserChallenge>()
            .HasOne(uc => uc.User)
            .WithMany(u => u.UserChallenges)
            .HasForeignKey(uc => uc.UserId);

        modelBuilder.Entity<DailyStreak>()
            .HasKey(ds => ds.AppUserId);

        modelBuilder.Entity<DailyStreak>()
            .HasOne(ds => ds.User)
            .WithOne(u => u.DailyStreak)
            .HasForeignKey<DailyStreak>(ds => ds.AppUserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ShowcaseItem>()
            .HasOne(si => si.ApplicationUser)
            .WithMany(au => au.ShowcaseItems)
            .HasForeignKey(si => si.AppUserId);

        modelBuilder.Entity<ShowcaseItem>()
            .HasOne(si => si.DashboardProject)
            .WithOne()
            .HasForeignKey<ShowcaseItem>(si => si.DashboardProjectId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}