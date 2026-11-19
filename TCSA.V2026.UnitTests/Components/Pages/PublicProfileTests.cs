using Bunit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using MudBlazor;
using MudBlazor.Services;
using TCSA.V2026.Components.Pages;
using TCSA.V2026.Data.DTOs.PublicProfile;
using TCSA.V2026.Data.Enums;
using TCSA.V2026.Data.Helpers;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Data.Models.Responses;
using TCSA.V2026.Services;

namespace TCSA.V2026.UnitTests.Components.Pages;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class PublicProfileTests : BunitContext
{
    private readonly Mock<IUserService> _userServiceMock = new();
    private readonly Mock<IBadgeService> _badgeServiceMock = new();
    private readonly Mock<ISnackbar> _snackbarMock = new();

    private const string TestUserId = "test-user-id";

    private static readonly PublicProfileIdentityResponse TestIdentity = new(
        ExperiencePoints: 100,
        ReviewExperiencePoints: 0,
        Level: Level.Yellow,
        CreatedDate: new DateTimeOffset(2025, 1, 1, 0, 0, 0, TimeSpan.Zero),
        UserName: "testuser",
        DisplayName: "Test User",
        Country: "USA",
        FirstName: "Test",
        LastName: "User",
        LinkedInUrl: null,
        CodeWarsUsername: null,
        LeetCodeUsername: null,
        LeaderboardRank: null,
        ReviewLeaderboardRank: null);

    [SetUp]
    public void SetUp()
    {
        JSInterop.Mode = JSRuntimeMode.Loose;

        var mockConfig = new Mock<IConfiguration>();
        mockConfig.Setup(c => c["LinkProvider:DiscordLink"]).Returns("https://discord.gg/test");

        ServiceProviderAccessor.ServiceProvider = new ServiceCollection()
            .AddSingleton(mockConfig.Object)
            .BuildServiceProvider();

        AddAuthorization();
        Services.AddMudServices();
        Services.AddSingleton(_userServiceMock.Object);
        Services.AddSingleton(_badgeServiceMock.Object);
        Services.AddSingleton(_snackbarMock.Object);

        _badgeServiceMock
            .Setup(s => s.GetUserAwardedBadges(It.IsAny<string>()))
            .ReturnsAsync(Enumerable.Empty<Badge>());
    }

    [Test]
    public void PublicProfile_ShouldDisplay_PointOfSalePullRequest_WithDisplayName()
    {
        // Arrange
        var pointOfSalePullRequest = new PublicProfilePullRequestDetailsResponse(
            CompletedAt: new DateTimeOffset(2025, 9, 2, 0, 0, 0, TimeSpan.Zero),
            IssueTitle: "Add product search to the checkout",
            PullRequestUrl: "https://github.com/TheCSharpAcademy/PointOfSale/pull/1",
            CommunityProjectId: (int)CommunityProject.PointOfSale);

        _userServiceMock
            .Setup(s => s.GetPublicProfile(TestUserId))
            .ReturnsAsync(Result.Success(new PublicProfileResponse(
                TestIdentity,
                [pointOfSalePullRequest],
                [])));

        // Act
        var cut = Render<PublicProfile>(parameters => parameters.Add(p => p.UserId, TestUserId));

        // Assert
        cut.WaitForAssertion(() =>
        {
            Assert.That(cut.Markup, Does.Contain("Add product search to the checkout"));
            Assert.That(cut.Markup, Does.Contain("Point of Sale"));
        });
    }
}
