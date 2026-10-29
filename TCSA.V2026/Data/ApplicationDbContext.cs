using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TCSA.V2026.Data.Enums;
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
    public virtual DbSet<FeedbackItem> FeedbackItems { get; set; }
    public virtual DbSet<Survey> Surveys { get; set; }
    public virtual DbSet<SurveyQuestion> SurveyQuestions { get; set; }
    public virtual DbSet<SurveyOption> SurveyOptions { get; set; }
    public virtual DbSet<SurveyResponse> SurveyResponses { get; set; }
    public virtual DbSet<SurveyAnswer> SurveyAnswers { get; set; }
    public virtual DbSet<SurveyAnswerOption> SurveyAnswerOptions { get; set; }
    public virtual DbSet<SurveyRefusal> SurveyRefusals { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

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

        modelBuilder.Entity<FeedbackItem>()
            .HasIndex(f => new { f.CreatedAt, f.Id })
            .IsDescending(true, true);

        modelBuilder.Entity<FeedbackItem>()
            .HasIndex(f => new { f.Category, f.ReportedPage, f.OriginUrl })
            .IncludeProperties(f => new { f.ReviewState, f.CreatedAt });

        // ReviewState is the only column edited after submission. Treating it as the concurrency token makes a
        // review change fail instead of silently overwriting another admin's change to the same item.
        modelBuilder.Entity<FeedbackItem>()
            .Property(f => f.ReviewState)
            .IsConcurrencyToken();

        modelBuilder.Entity<FeedbackItem>()
            .HasOne(f => f.AppUser)
            .WithMany()
            .HasForeignKey(f => f.AppUserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Survey>()
            .HasMany(s => s.Questions)
            .WithOne(q => q.Survey)
            .HasForeignKey(q => q.SurveyId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ChoiceQuestion>()
            .HasMany(q => q.Options)
            .WithOne(o => o.Question)
            .HasForeignKey(o => o.SurveyQuestionId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Survey>()
            .Property(s => s.Status)
            .IsConcurrencyToken();

        modelBuilder.Entity<SurveyQuestion>(question =>
        {
            question.HasDiscriminator(q => q.Type)
                .HasValue<RatingQuestion>(SurveyQuestionType.Rating)
                .HasValue<SingleChoiceQuestion>(SurveyQuestionType.SingleChoice)
                .HasValue<MultipleChoiceQuestion>(SurveyQuestionType.MultipleChoice)
                .HasValue<FreeTextQuestion>(SurveyQuestionType.FreeText)
                .HasValue<YesNoQuestion>(SurveyQuestionType.YesNo);

            question.Property(q => q.Type)
                .HasConversion<string>()
                .HasMaxLength(30);

            question.HasIndex(q => new { q.SurveyId, q.Order }).IsUnique();
        });

        modelBuilder.Entity<SurveyOption>()
            .HasIndex(o => new { o.SurveyQuestionId, o.Order })
            .IsUnique();

        modelBuilder.Entity<SurveyResponse>(response =>
        {
            response.HasIndex(r => new { r.SurveyId, r.AppUserId }).IsUnique();

            response.HasOne(r => r.Survey)
                .WithMany()
                .HasForeignKey(r => r.SurveyId)
                .OnDelete(DeleteBehavior.Cascade);

            response.HasOne(r => r.AppUser)
                .WithMany()
                .HasForeignKey(r => r.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);

            response.HasMany(r => r.Answers)
                .WithOne(a => a.Response)
                .HasForeignKey(a => a.SurveyResponseId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<SurveyAnswer>(answer =>
        {
            answer.HasDiscriminator(a => a.Type)
                .HasValue<RatingAnswer>(SurveyQuestionType.Rating)
                .HasValue<SingleChoiceAnswer>(SurveyQuestionType.SingleChoice)
                .HasValue<MultipleChoiceAnswer>(SurveyQuestionType.MultipleChoice)
                .HasValue<FreeTextAnswer>(SurveyQuestionType.FreeText)
                .HasValue<YesNoAnswer>(SurveyQuestionType.YesNo);

            answer.Property(a => a.Type)
                .HasConversion<string>()
                .HasMaxLength(30);

            answer.HasOne(a => a.Question)
                .WithMany()
                .HasForeignKey(a => a.SurveyQuestionId)
                .OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<ChoiceAnswer>()
            .HasMany(a => a.SelectedOptions)
            .WithOne(o => o.Answer)
            .HasForeignKey(o => o.SurveyAnswerId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<SurveyAnswerOption>()
            .HasOne(o => o.Option)
            .WithMany()
            .HasForeignKey(o => o.SurveyOptionId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<SurveyRefusal>(refusal =>
        {
            refusal.HasIndex(r => new { r.SurveyId, r.AppUserId }).IsUnique();

            refusal.HasOne(r => r.Survey)
                .WithMany()
                .HasForeignKey(r => r.SurveyId)
                .OnDelete(DeleteBehavior.Cascade);

            refusal.HasOne(r => r.AppUser)
                .WithMany()
                .HasForeignKey(r => r.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}
