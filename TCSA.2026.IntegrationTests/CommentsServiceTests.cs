using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.AspNetCore.Identity;
using TCSA.V2026.Data.Curriculum;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Services;

namespace TCSA.V2026.IntegrationTests;

[TestFixture]
public class CommentsServiceTests : IntegrationTestsBase
{
    private CommentsService _service = null!;

    [SetUp]
    public void Setup()
    {
        _service = new CommentsService(
            DbContextFactory,
            NullLogger<CommentsService>.Instance);
    }

    [Test]
    public async Task AddCommentAsync_ShouldPersistCommentWithExpectedDefaults()
    {
        var beforeSave = DateTimeOffset.UtcNow;

        var response = await _service.AddCommentAsync(53, "user1", "  Helpful project!  ");

        using var context = DbContextFactory.CreateDbContext();
        var savedComment = context.Comments.Single();

        Assert.Multiple(() =>
        {
            Assert.That(response.IsSuccessful, Is.True);
            Assert.That(savedComment.ArticleId, Is.EqualTo(53));
            Assert.That(savedComment.AppUserId, Is.EqualTo("user1"));
            Assert.That(savedComment.Comment, Is.EqualTo("Helpful project!"));
            Assert.That(savedComment.Date, Is.GreaterThanOrEqualTo(beforeSave));
            Assert.That(savedComment.IsReviewed, Is.False);
        });
    }

    [Test]
    public async Task AddCommentAsync_ShouldAutoReviewCommentsFromGreenBeltAndAbove()
    {
        var response = await _service.AddCommentAsync(53, "orangeuser", "No moderation needed");

        using var context = DbContextFactory.CreateDbContext();
        var savedComment = context.Comments.Single();

        Assert.Multiple(() =>
        {
            Assert.That(response.IsSuccessful, Is.True);
            Assert.That(savedComment.IsReviewed, Is.True);
        });
    }

    [Test]
    public async Task AddCommentAsync_ShouldAutoReviewCommentsFromAdminsBelowGreenBelt()
    {
        await MakeUserAdmin("user1");

        var response = await _service.AddCommentAsync(53, "user1", "Admin comment");

        using var context = DbContextFactory.CreateDbContext();
        var savedComment = context.Comments.Single();

        Assert.Multiple(() =>
        {
            Assert.That(response.IsSuccessful, Is.True);
            Assert.That(savedComment.IsReviewed, Is.True);
        });
    }

    [Test]
    public async Task GetCommentsAsync_ShouldReturnOnlyRequestedArticleNewestFirstWithUsers()
    {
        using (var context = DbContextFactory.CreateDbContext())
        {
            var older = CreateComment(12, "user1", "Older", DateTimeOffset.UtcNow.AddHours(-2));
            var newer = CreateComment(12, "user2", "Newer", DateTimeOffset.UtcNow.AddHours(-1));
            var differentArticle = CreateComment(13, "user1", "Different article", DateTimeOffset.UtcNow);
            older.IsReviewed = true;
            newer.IsReviewed = true;
            differentArticle.IsReviewed = true;

            context.Comments.AddRange(older, newer, differentArticle);

            await context.SaveChangesAsync();
        }

        var comments = await _service.GetCommentsAsync(12, "orangeuser");

        Assert.Multiple(() =>
        {
            Assert.That(comments, Has.Count.EqualTo(2));
            Assert.That(comments.Select(c => c.Comment), Is.EqualTo(new[] { "Newer", "Older" }));
            Assert.That(comments.All(c => c.ArticleId == 12), Is.True);
            Assert.That(comments[0].AppUser, Is.Not.Null);
            Assert.That(comments[0].AppUser.UserName, Is.EqualTo("testuser2"));
        });
    }

    [TestCase("")]
    [TestCase("   ")]
    public async Task AddCommentAsync_ShouldRejectEmptyComments(string comment)
    {
        var response = await _service.AddCommentAsync(12, "user1", comment);

        using var context = DbContextFactory.CreateDbContext();

        Assert.Multiple(() =>
        {
            Assert.That(response.IsSuccessful, Is.False);
            Assert.That(context.Comments, Is.Empty);
        });
    }

    [Test]
    public async Task AddCommentAsync_ShouldRejectCommentsOverTwoThousandCharacters()
    {
        var response = await _service.AddCommentAsync(12, "user1", new string('a', 2001));

        using var context = DbContextFactory.CreateDbContext();

        Assert.Multiple(() =>
        {
            Assert.That(response.IsSuccessful, Is.False);
            Assert.That(context.Comments, Is.Empty);
        });
    }

    [Test]
    public async Task CourseArticle_ShouldAllowComments()
    {
        var courseArticle = CourseHelper.GetCourses()
            .SelectMany(course => course.Articles)
            .First();

        var response = await _service.AddCommentAsync(
            courseArticle.Id,
            "user1",
            "Comment on a course article");

        var comments = await _service.GetCommentsAsync(courseArticle.Id, "user1");

        Assert.Multiple(() =>
        {
            Assert.That(response.IsSuccessful, Is.True);
            Assert.That(comments, Has.Count.EqualTo(1));
            Assert.That(comments[0].ArticleId, Is.EqualTo(courseArticle.Id));
            Assert.That(comments[0].Comment, Is.EqualTo("Comment on a course article"));
        });
    }

    [Test]
    public async Task GetCommentsAsync_ShouldOnlyShowApprovedCommentsToAnonymousAndWhiteBeltUsers()
    {
        using (var context = DbContextFactory.CreateDbContext())
        {
            var approved = CreateComment(12, "user1", "Approved", DateTimeOffset.UtcNow);
            approved.IsReviewed = true;

            context.Comments.AddRange(
                approved,
                CreateComment(12, "user2", "Pending", DateTimeOffset.UtcNow.AddMinutes(1)));
            await context.SaveChangesAsync();
        }

        var anonymousComments = await _service.GetCommentsAsync(12);
        var whiteBeltComments = await _service.GetCommentsAsync(12, "user1");

        Assert.Multiple(() =>
        {
            Assert.That(anonymousComments.Select(c => c.Comment), Is.EqualTo(new[] { "Approved" }));
            Assert.That(whiteBeltComments.Select(c => c.Comment), Is.EqualTo(new[] { "Approved" }));
        });
    }

    [Test]
    public async Task GetCommentsAsync_ShouldOnlyShowPendingCommentToItsAuthor()
    {
        using (var context = DbContextFactory.CreateDbContext())
        {
            context.Comments.Add(CreateComment(12, "user1", "Pending", DateTimeOffset.UtcNow));
            await context.SaveChangesAsync();
        }

        var authorComments = await _service.GetCommentsAsync(12, "user1");
        var otherUserComments = await _service.GetCommentsAsync(12, "orangeuser");

        Assert.Multiple(() =>
        {
            Assert.That(authorComments.Select(c => c.Comment), Is.EqualTo(new[] { "Pending" }));
            Assert.That(otherUserComments, Is.Empty);
        });
    }

    [Test]
    public async Task AddCommentAsync_ShouldRejectUnknownUsers()
    {
        var response = await _service.AddCommentAsync(12, "not-a-logged-in-user", "Hello");

        using var context = DbContextFactory.CreateDbContext();

        Assert.Multiple(() =>
        {
            Assert.That(response.IsSuccessful, Is.False);
            Assert.That(context.Comments, Is.Empty);
        });
    }

    [Test]
    public async Task ApproveCommentAsync_ShouldApproveAndMarkCommentAsReviewed()
    {
        int commentId;
        using (var context = DbContextFactory.CreateDbContext())
        {
            var comment = CreateComment(12, "user1", "Pending", DateTimeOffset.UtcNow);
            context.Comments.Add(comment);
            await context.SaveChangesAsync();
            commentId = comment.Id;
        }

        var response = await _service.ApproveCommentAsync(commentId);

        using var verifyContext = DbContextFactory.CreateDbContext();
        var approvedComment = verifyContext.Comments.Single(c => c.Id == commentId);

        Assert.Multiple(() =>
        {
            Assert.That(response.IsSuccessful, Is.True);
            Assert.That(approvedComment.IsReviewed, Is.True);
        });
    }

    [Test]
    public async Task GetPendingCommentsAsync_ShouldOnlyReturnUnreviewedComments()
    {
        using (var context = DbContextFactory.CreateDbContext())
        {
            var reviewed = CreateComment(12, "user1", "Reviewed", DateTimeOffset.UtcNow);
            reviewed.IsReviewed = true;

            context.Comments.AddRange(
                reviewed,
                CreateComment(12, "user2", "Pending", DateTimeOffset.UtcNow.AddMinutes(1)));
            await context.SaveChangesAsync();
        }

        var pendingComments = await _service.GetPendingCommentsAsync();

        Assert.That(pendingComments.Select(c => c.Comment), Is.EqualTo(new[] { "Pending" }));
    }

    [Test]
    public async Task UpdateCommentAsync_ShouldAllowOwnerAndResetReviewedState()
    {
        var commentId = await SeedComment("user1", isReviewed: true);

        var response = await _service.UpdateCommentAsync(commentId, "user1", "  Updated by owner  ");

        using var context = DbContextFactory.CreateDbContext();
        var comment = context.Comments.Single(c => c.Id == commentId);

        Assert.Multiple(() =>
        {
            Assert.That(response.IsSuccessful, Is.True);
            Assert.That(comment.Comment, Is.EqualTo("Updated by owner"));
            Assert.That(comment.IsReviewed, Is.False);
        });
    }

    [Test]
    public async Task UpdateCommentAsync_ShouldRejectNonOwner()
    {
        var commentId = await SeedComment("user1", isReviewed: true);

        var response = await _service.UpdateCommentAsync(commentId, "orangeuser", "Not allowed");

        using var context = DbContextFactory.CreateDbContext();
        Assert.Multiple(() =>
        {
            Assert.That(response.IsSuccessful, Is.False);
            Assert.That(context.Comments.Single().Comment, Is.EqualTo("Original"));
        });
    }

    [Test]
    public async Task DeleteCommentAsync_ShouldAllowOwner()
    {
        var commentId = await SeedComment("user1");

        var response = await _service.DeleteCommentAsync(commentId, "user1");

        using var context = DbContextFactory.CreateDbContext();
        Assert.Multiple(() =>
        {
            Assert.That(response.IsSuccessful, Is.True);
            Assert.That(context.Comments, Is.Empty);
        });
    }

    [Test]
    public async Task DeleteCommentAsync_ShouldRejectNonOwner()
    {
        var commentId = await SeedComment("user1");

        var response = await _service.DeleteCommentAsync(commentId, "orangeuser");

        using var context = DbContextFactory.CreateDbContext();
        Assert.Multiple(() =>
        {
            Assert.That(response.IsSuccessful, Is.False);
            Assert.That(context.Comments.Count(), Is.EqualTo(1));
        });
    }

    [Test]
    public async Task Admin_ShouldSeeEditAndDeleteAnyPendingComment()
    {
        await MakeUserAdmin("user2");
        var firstCommentId = await SeedComment("user1");
        var secondCommentId = await SeedComment("orangeuser");

        var visibleComments = await _service.GetCommentsAsync(12, "user2");
        var updateResponse = await _service.UpdateCommentAsync(firstCommentId, "user2", "Admin edit");
        var deleteResponse = await _service.DeleteCommentAsync(secondCommentId, "user2");

        using var context = DbContextFactory.CreateDbContext();
        Assert.Multiple(() =>
        {
            Assert.That(visibleComments, Has.Count.EqualTo(2));
            Assert.That(updateResponse.IsSuccessful, Is.True);
            Assert.That(deleteResponse.IsSuccessful, Is.True);
            Assert.That(context.Comments.Single().Comment, Is.EqualTo("Admin edit"));
        });
    }

    private async Task<int> SeedComment(string appUserId, bool isReviewed = false)
    {
        using var context = DbContextFactory.CreateDbContext();
        var comment = CreateComment(12, appUserId, "Original", DateTimeOffset.UtcNow);
        comment.IsReviewed = isReviewed;
        context.Comments.Add(comment);
        await context.SaveChangesAsync();
        return comment.Id;
    }

    private async Task MakeUserAdmin(string appUserId)
    {
        using var context = DbContextFactory.CreateDbContext();
        var role = new IdentityRole
        {
            Id = "admin-role",
            Name = "Admin",
            NormalizedName = "ADMIN"
        };

        context.Roles.Add(role);
        context.UserRoles.Add(new IdentityUserRole<string>
        {
            UserId = appUserId,
            RoleId = role.Id
        });
        await context.SaveChangesAsync();
    }

    private static Comments CreateComment(
        int articleId,
        string appUserId,
        string text,
        DateTimeOffset date)
    {
        return new Comments
        {
            ArticleId = articleId,
            AppUserId = appUserId,
            Comment = text,
            Date = date,
            IsReviewed = false
        };
    }
}
