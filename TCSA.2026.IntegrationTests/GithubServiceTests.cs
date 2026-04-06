using Moq;
using TCSA.V2026.Data.DTOs;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Data.Models.Responses;
using TCSA.V2026.Services;
using TCSA.V2026.Webhooks;

namespace TCSA.V2026.IntegrationTests;

public class GithubServiceTests : IntegrationTestsBase
{
    private GithubService _service;
    private GithubWebhookController _controller;

    [SetUp]
    public void Setup()
    {
        BaseSetup();
        var httpClientFactoryMock = new Mock<IHttpClientFactory>();
        httpClientFactoryMock
            .Setup(f => f.CreateClient(It.IsAny<string>()))
            .Returns(new HttpClient());
        _service = new GithubService(DbContextFactory);

        _controller = new GithubWebhookController(_service);
    }

    [TearDown]
    public void TearDown()
    {
        BaseTearDown();
        _controller.Dispose();
    }

    [Test]
    public async Task ActionNotOpenedReturnFail()
    {
        var pullRequestDto = new PullRequestDto
        {
            Action = "closed",
            Repository = new Repository
            {
                Id = 573911382
            }
        };

        var result = await _service.ProcessPullRequest(pullRequestDto);

        Assert.That(result.Message.Equals("Pull request action is not 'opened'."));

    }

    [Test]
    public async Task ProcessPullRequestCantMapReturnsError()
    {
        var pullRequestDto = new PullRequestDto
        {
            Action = "opened",
            Repository = new Repository
            {
                Id = 9999
            }
        };

        var result = await _service.ProcessPullRequest(pullRequestDto);

        Assert.That(result.Status.Equals(ResponseStatus.Fail));

    }

    [Test]
    public async Task ProcessPullRequestUserNotFoundReturnsError()
    {
        var pullRequestDto = new PullRequestDto
        {
            Action = "opened",
            Repository = new Repository
            {
                Id = 573911382
            },
            PullRequest = new PullRequest
            {
                User = new User
                {
                    Login = "NonExistantInTheDb"
                }
            }
        };

        var result = await _service.ProcessPullRequest(pullRequestDto);

        Assert.That(result.Message.Equals("No user found with the provided GitHub username."));

    }

    [Test]
    public async Task ProcessPullRequestDataOkProjectAdded()
    {
        var pullRequestDto = new PullRequestDto
        {
            Action = "opened",
            Repository = new Repository
            {
                Id = 573911382
            },
            PullRequest = new PullRequest
            {
                HtmlUrl = "test_pull_request/777",
                User = new User
                {
                    Login = "TheCSharpAcademy"
                }
            }
        };

        var result = await _service.ProcessPullRequest(pullRequestDto);

        using var assertContext = DbContextFactory.CreateDbContext();

        var project = assertContext.DashboardProjects
            .FirstOrDefault(p => p.AppUserId.Equals("user1"));

        var activity = assertContext.UserActivity
            .FirstOrDefault(p => p.AppUserId.Equals("user1"));

        Assert.That(project.GithubUrl.Equals("test_pull_request/777"));
        Assert.That(activity.ActivityType == ActivityType.ProjectSubmitted);
    }

    [Test]
    public async Task ProcessReviewNotApprovedReturnFail()
    {
        var pullRequestDto = new PullRequestReviewDto
        {
            Action = "changes_requested",

            Review = new Review
            {
                State = "changes_requested"
            },

            Repository = new Repository
            {
                Id = 573911382
            }
        };

        var result = await _service.MarkAsCompleted(pullRequestDto);

        Assert.That(result.Message.Equals("Pull request action is not 'approved'."));

    }


    [Test]
    public async Task Receive_WhenCanFindRepo_ProjectCompleted()
    {
        using (var seedContext = DbContextFactory.CreateDbContext())
        {
            seedContext.DashboardProjects.Add(new DashboardProject
            {
                Id = 1,
                AppUserId = "user1",
                ProjectId = (int)ArticleName.Calculator,
                IsArchived = false,
                IsPendingNotification = false,
                IsPendingReview = true,
                IsCompleted = false,
                DateSubmitted = DateTime.Now.AddDays(-10),
                GithubUrl = "test_pull_request/777"
            });

            seedContext.UserReviews.Add(new UserReview
            {
                Id = 1,
                DashboardProjectId = 1,
                AppUserId = "user2"
            });

            await seedContext.SaveChangesAsync();
        }

        var pullRequestReviewDto = new PullRequestReviewDto
        {
            Review = new Review
            {
                State = "approved"
            },
            Repository = new Repository
            {
                Id = 573911382
            },
            PullRequest = new PullRequest
            {
                Number = 777
            }
        };

        var result = await _service.MarkAsCompleted(pullRequestReviewDto);

        using var assertContext = DbContextFactory.CreateDbContext();

        var project = assertContext.DashboardProjects
            .First(p => p.Id == 1);

        var reviewer = assertContext.Users
            .First(u => u.Id == "user2");

        var reviewee = assertContext.Users
            .First(u => u.Id == "user1");

        Assert.That(project.IsCompleted.Equals(true));
        Assert.That(reviewer.ExperiencePoints.Equals(110));
        Assert.That(reviewee.ExperiencePoints.Equals(10));
    }
}
