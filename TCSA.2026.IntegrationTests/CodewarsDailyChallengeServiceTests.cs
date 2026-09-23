using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using System.Net;
using TCSA.V2026.Data.Enums;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Services.Challenges;

namespace TCSA.V2026.IntegrationTests;

public class CodewarsDailyChallengeServiceTests
{
    [Test]
    public async Task FetchDailyChallenges_BothCategoriesHaveNewKatas_ReturnsBothChallenges()
    {
        // Arrange
        var responses = new Dictionary<string, string>
        {
            ["/kata/csharp"] = BuildListPage("csharp-kata-id", "Sum of Two Numbers", "6 kyu", ["fundamentals", "numbers"]),
            ["/api/v1/code-challenges/csharp-kata-id"] = BuildDetailsJson("Given two numbers, return their sum."),
            ["/kata/sql"] = BuildListPage("sql-kata-id", "Select Active Users", "5 kyu", ["sql"]),
            ["/api/v1/code-challenges/sql-kata-id"] = BuildDetailsJson("Select all active users from the table.")
        };
        var service = CreateService(responses);

        // Act
        var challenges = (await service.FetchDailyChallenges()).ToList();

        // Assert
        Assert.That(challenges, Has.Count.EqualTo(2));

        var csharpChallenge = challenges.Single(c => c.Category == ChallengeCategory.CSharp);
        Assert.That(csharpChallenge.ExternalId, Is.EqualTo("csharp-kata-id"));
        Assert.That(csharpChallenge.Name, Is.EqualTo("Sum of Two Numbers"));
        Assert.That(csharpChallenge.Level, Is.EqualTo(Level.OliveGreen));
        Assert.That(csharpChallenge.ExperiencePoints, Is.EqualTo(9));
        Assert.That(csharpChallenge.Platform, Is.EqualTo(ChallengePlatform.CodeWars));

        var sqlChallenge = challenges.Single(c => c.Category == ChallengeCategory.SQL);
        Assert.That(sqlChallenge.ExternalId, Is.EqualTo("sql-kata-id"));
        Assert.That(sqlChallenge.Name, Is.EqualTo("Select Active Users"));
        Assert.That(sqlChallenge.Level, Is.EqualTo(Level.Yellow));
        Assert.That(sqlChallenge.ExperiencePoints, Is.EqualTo(11));
        Assert.That(sqlChallenge.Platform, Is.EqualTo(ChallengePlatform.CodeWars));
    }

    [Test]
    public async Task FetchDailyChallenges_OnlyOneCategoryHasKataNode_ReturnsOnlyThatChallenge()
    {
        // Arrange
        var responses = new Dictionary<string, string>
        {
            ["/kata/csharp"] = BuildListPage("csharp-kata-id", "Sum of Two Numbers", "6 kyu", []),
            ["/api/v1/code-challenges/csharp-kata-id"] = BuildDetailsJson("Given two numbers, return their sum."),
            ["/kata/sql"] = "<html><body>no kata here</body></html>"
        };
        var service = CreateService(responses);

        // Act
        var challenges = (await service.FetchDailyChallenges()).ToList();

        // Assert
        Assert.That(challenges, Has.Count.EqualTo(1));
        Assert.That(challenges[0].Category, Is.EqualTo(ChallengeCategory.CSharp));
    }

    [Test]
    public async Task FetchDailyChallenges_KataNodeMissingIdAndTitle_SkipsThatCategoryOnly()
    {
        // Arrange
        var malformedListPage = """
            <html><body>
              <div class="list-item-kata">
                <div class="inner-small-hex"><span>6 kyu</span></div>
              </div>
            </body></html>
            """;
        var responses = new Dictionary<string, string>
        {
            ["/kata/csharp"] = malformedListPage,
            ["/kata/sql"] = BuildListPage("sql-kata-id", "Select Active Users", "5 kyu", []),
            ["/api/v1/code-challenges/sql-kata-id"] = BuildDetailsJson("Select all active users.")
        };
        var service = CreateService(responses);

        // Act
        var challenges = (await service.FetchDailyChallenges()).ToList();

        // Assert
        Assert.That(challenges, Has.Count.EqualTo(1));
        Assert.That(challenges[0].Category, Is.EqualTo(ChallengeCategory.SQL));
    }

    [Test]
    public async Task FetchDailyChallenges_DetailsApiResponseMissingDescription_ReturnsChallengeWithEmptyDescription()
    {
        // Arrange
        var responses = new Dictionary<string, string>
        {
            ["/kata/csharp"] = BuildListPage("csharp-kata-id", "No Description Kata", "5 kyu", []),
            ["/api/v1/code-challenges/csharp-kata-id"] = "{}"
        };
        var service = CreateService(responses);

        // Act
        var challenges = (await service.FetchDailyChallenges()).ToList();

        // Assert
        Assert.That(challenges, Has.Count.EqualTo(1));
        Assert.That(challenges[0].Description, Is.Empty);
    }

    [Test]
    public async Task FetchDailyChallenges_OneCategoryListPageRequestFails_SkipsOnlyThatCategory()
    {
        // Arrange: the SQL list page isn't registered, so its request 404s.
        var responses = new Dictionary<string, string>
        {
            ["/kata/csharp"] = BuildListPage("csharp-kata-id", "Sum of Two Numbers", "6 kyu", []),
            ["/api/v1/code-challenges/csharp-kata-id"] = BuildDetailsJson("Given two numbers, return their sum.")
        };
        var service = CreateService(responses);

        // Act
        var challenges = (await service.FetchDailyChallenges()).ToList();

        // Assert
        Assert.That(challenges, Has.Count.EqualTo(1));
        Assert.That(challenges[0].Category, Is.EqualTo(ChallengeCategory.CSharp));
    }

    [Test]
    public async Task FetchDailyChallenges_DetailsApiRequestFails_SkipsThatCategory()
    {
        // Arrange: the list page resolves a kata, but the details API 404s for it.
        var responses = new Dictionary<string, string>
        {
            ["/kata/csharp"] = BuildListPage("csharp-kata-id", "Sum of Two Numbers", "6 kyu", [])
        };
        var service = CreateService(responses);

        // Act
        var challenges = await service.FetchDailyChallenges();

        // Assert
        Assert.That(challenges, Is.Empty);
    }

    private static CodewarsDailyChallengeService CreateService(IDictionary<string, string> responsesByPath)
    {
        var factory = new Mock<IHttpClientFactory>();
        factory.Setup(f => f.CreateClient(It.IsAny<string>()))
               .Returns(new HttpClient(new MockHttpMessageHandler(request =>
               {
                   var path = request.RequestUri!.AbsolutePath;
                   if (responsesByPath.TryGetValue(path, out var body))
                   {
                       var contentType = path.StartsWith("/api/") ? "application/json" : "text/html";
                       return new HttpResponseMessage(HttpStatusCode.OK)
                       {
                           Content = new StringContent(body, System.Text.Encoding.UTF8, contentType)
                       };
                   }

                   return new HttpResponseMessage(HttpStatusCode.NotFound);
               })));
        return new CodewarsDailyChallengeService(factory.Object, NullLogger<CodewarsDailyChallengeService>.Instance);
    }

    private static string BuildListPage(string id, string title, string kyuRank, string[] keywords)
    {
        var keywordTags = string.Join("\n", keywords.Select(k => $"""<div class="keyword-tag"><a>{k}</a></div>"""));
        return $"""
            <html><body>
              <div class="list-item-kata" id="{id}" data-title="{title}">
                <div class="inner-small-hex"><span>{kyuRank}</span></div>
                {keywordTags}
              </div>
            </body></html>
            """;
    }

    private static string BuildDetailsJson(string description)
    {
        return $$"""{"description": "{{description}}"}""";
    }
}
