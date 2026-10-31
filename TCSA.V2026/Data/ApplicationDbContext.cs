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
    public virtual DbSet<Comments> Comments { get; set; }
    public virtual DbSet<Badge> Badges { get; set; }
    public virtual DbSet<GameScore> GameScores { get; set; }
    public virtual DbSet<Game> Games { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Game>().HasKey(game => game.Slug);
        modelBuilder.Entity<Game>().Property(game => game.Slug).HasMaxLength(100);
        modelBuilder.Entity<Game>().Property(game => game.Title).HasMaxLength(200).IsRequired();
        modelBuilder.Entity<Game>().Property(game => game.Description).IsRequired();
        modelBuilder.Entity<Game>().Property(game => game.Url).HasMaxLength(2048).IsRequired();
        modelBuilder.Entity<Game>().Property(game => game.TimesPlayed).IsConcurrencyToken();

        modelBuilder.Entity<GameScore>()
            .HasOne<Game>()
            .WithMany()
            .HasForeignKey(score => score.GameId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<GameScore>()
            .HasKey(gs => new { gs.GameId, gs.UserId });

        modelBuilder.Entity<GameScore>()
            .Property(gs => gs.GameId)
            .HasMaxLength(100);

        modelBuilder.Entity<GameScore>()
            .HasOne<ApplicationUser>()
            .WithMany()
            .HasForeignKey(gs => gs.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Badge>()
            .HasKey(b => new { b.BadgeId, b.UserId });

        modelBuilder.Entity<Badge>()
            .HasOne<ApplicationUser>()
            .WithMany()
            .HasForeignKey(b => b.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<AppUserActivity>()
            .HasOne(aua => aua.ApplicationUser)
            .WithMany(u => u.UserActivity)
            .HasForeignKey(aua => aua.AppUserId)
            .OnDelete(DeleteBehavior.Cascade);

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
            .HasForeignKey(uc => uc.ChallengeId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<UserChallenge>()
            .HasOne(uc => uc.User)
            .WithMany(u => u.UserChallenges)
            .HasForeignKey(uc => uc.UserId)
            .OnDelete(DeleteBehavior.Cascade);

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
            .HasForeignKey(si => si.AppUserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ShowcaseItem>()
            .HasOne(si => si.DashboardProject)
            .WithOne()
            .HasForeignKey<ShowcaseItem>(si => si.DashboardProjectId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Comments>()
            .HasOne(c => c.AppUser)
            .WithMany(u => u.Comments)
            .HasForeignKey(c => c.AppUserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Comments>()
            .HasIndex(c => new { c.ArticleId, c.IsReviewed, c.Date });
    }
}
