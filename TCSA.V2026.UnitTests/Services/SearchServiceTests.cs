using TCSA.V2026.Data.Models;
using TCSA.V2026.Helpers.Constants;
using TCSA.V2026.Services;

namespace TCSA.V2026.UnitTests.Services;

[TestFixture]
public class SearchServiceTests
{
    [Test]
    public async Task QuickSearch_ReturnsEmpty_WhenQueryIsTooShort()
    {
        var sut = new SearchService([]);

        var results = await sut.QuickSearch("a", CancellationToken.None);

        Assert.That(results, Is.Empty);
    }

    [Test]
    public async Task QuickSearch_ReturnsEmpty_WhenQueryIsNull()
    {
        var sut = new SearchService([]);

        var results = await sut.QuickSearch(null, CancellationToken.None);

        Assert.That(results, Is.Empty);
    }

    [Test]
    public async Task QuickSearch_ReturnsEmpty_WhenQueryIsEmpty()
    {
        var sut = new SearchService([]);

        var results = await sut.QuickSearch(string.Empty, CancellationToken.None);

        Assert.That(results, Is.Empty);
    }

    [Test]
    public async Task QuickSearch_ReturnsEmpty_WhenQueryIsWhitespace()
    {
        var sut = new SearchService([]);

        var results = await sut.QuickSearch("   ", CancellationToken.None);

        Assert.That(results, Is.Empty);
    }

    [Test]
    public async Task QuickSearch_ReturnsEmpty_WhenAllTokensAreSingleChar()
    {
        var sut = new SearchService([]);

        var results = await sut.QuickSearch("a b", CancellationToken.None);

        Assert.That(results, Is.Empty);
    }

    [Test]
    public async Task QuickSearch_ReturnsEmpty_WhenNoMatchFound()
    {
        var sut = new SearchService([
            new Article { Id = 1, Title = "Introduction to C#", Slug = "intro-to-csharp", Blocks = null }
        ]);

        var results = await sut.QuickSearch("python", CancellationToken.None);

        Assert.That(results, Is.Empty);
    }

    [Test]
    public async Task QuickSearch_ReturnsResult_WhenTitleMatchesExactly()
    {
        var sut = new SearchService([
            new Project { Id = 1, Title = "Build a Calculator", Slug = "build-a-calculator", Blocks = null }
        ]);

        var results = (await sut.QuickSearch("calculator", CancellationToken.None)).ToList();

        Assert.That(results, Is.Not.Empty);
        Assert.That(results[0].Title, Is.EqualTo("Build a Calculator"));
    }

    [Test]
    public async Task QuickSearch_ReturnsResult_WhenQueryMatchesParagraphBody()
    {
        var sut = new SearchService([
            new Article
            {
                Id = 1,
                Title = "Introduction to C#",
                Slug = "intro-to-csharp",
                Blocks = [new Block { Paragraphs = [new Paragraph { Body = "C# is a strongly typed language." }] }]
            }
        ]);

        var results = (await sut.QuickSearch("strongly typed", CancellationToken.None)).ToList();

        Assert.That(results, Is.Not.Empty);
        Assert.That(results.Any(r => r.Title == "Introduction to C#"), Is.True);
    }

    [Test]
    public async Task QuickSearch_ReturnsResult_WhenQueryMatchesPartially()
    {
        var sut = new SearchService([
            new Project { Id = 1, Title = "Build a Calculator", Slug = "build-a-calculator", Blocks = null }
        ]);

        var results = (await sut.QuickSearch("calc", CancellationToken.None)).ToList();

        Assert.That(results, Is.Not.Empty);
    }

    [Test]
    public async Task QuickSearch_UsesProjectUrl_ForProjectResults()
    {
        var sut = new SearchService([
            new Project { Id = 3, Title = "Build a Calculator", Slug = "build-a-calculator", Blocks = null }
        ]);

        var results = (await sut.QuickSearch("calculator", CancellationToken.None)).ToList();

        var hit = results.First(r => r.Title == "Build a Calculator");
        Assert.That(hit.PageUrl, Does.StartWith("/project/3/build-a-calculator"));
    }

    [Test]
    public async Task QuickSearch_UsesArticleUrl_ForArticleResults()
    {
        var sut = new SearchService([
            new Article { Id = 1, Title = "Introduction to C#", Slug = "intro-to-csharp", Blocks = null }
        ]);

        var results = (await sut.QuickSearch("introduction", CancellationToken.None)).ToList();

        var hit = results.First(r => r.Title == "Introduction to C#");
        Assert.That(hit.PageUrl, Does.StartWith("/article/1/intro-to-csharp"));
    }

    [Test]
    public async Task QuickSearch_ResolvesCSharpAlias()
    {
        var sut = new SearchService([
            new Article { Id = 1, Title = "Introduction to C#", Slug = "intro-to-csharp", Blocks = null }
        ]);

        var results = (await sut.QuickSearch("c#", CancellationToken.None)).ToList();

        Assert.That(results, Is.Not.Empty);
        Assert.That(results.Any(r => r.Title == "Introduction to C#"), Is.True);
    }

    [Test]
    public async Task QuickSearch_ResolvesAspNetAlias()
    {
        var sut = new SearchService([
            new Article { Id = 1, Title = "Getting Started with ASP.NET", Slug = "aspnet-getting-started", Blocks = null }
        ]);

        var results = (await sut.QuickSearch("asp.net", CancellationToken.None)).ToList();

        Assert.That(results, Is.Not.Empty);
        Assert.That(results.Any(r => r.Title == "Getting Started with ASP.NET"), Is.True);
    }

    [Test]
    public async Task QuickSearch_PageUrl_ContainsArticleTitleAnchor()
    {
        var sut = new SearchService([
            new Project { Id = 3, Title = "Build a Calculator", Slug = "build-a-calculator", Blocks = null }
        ]);

        var results = (await sut.QuickSearch("calculator", CancellationToken.None)).ToList();

        Assert.That(results.Any(r => r.PageUrl == $"/project/3/build-a-calculator#{ContentAnchors.ArticleTitleId}"), Is.True);
    }

    [Test]
    public async Task QuickSearch_PageUrl_ContainsBlockTitleAnchor()
    {
        var sut = new SearchService([
            new Article
            {
                Id = 1,
                Title = "Introduction to C#",
                Slug = "intro-to-csharp",
                Blocks = [new Block { Title = "Variables and Types", Paragraphs = [] }]
            }
        ]);

        var results = (await sut.QuickSearch("variables", CancellationToken.None)).ToList();

        var hit = results.First(r => r.Title == "Introduction to C#");
        Assert.That(hit.PageUrl, Does.Contain($"#{ContentAnchors.ArticleBlockTitleId(0)}"));
    }

    [Test]
    public async Task QuickSearch_PageUrl_ContainsBlockParagraphAnchor()
    {
        var sut = new SearchService([
            new Article
            {
                Id = 1,
                Title = "Introduction to C#",
                Slug = "intro-to-csharp",
                Blocks = [new Block { Paragraphs = [new Paragraph { Body = "C# is a strongly typed language." }] }]
            }
        ]);

        var results = (await sut.QuickSearch("strongly", CancellationToken.None)).ToList();

        Assert.That(results.Any(r => r.PageUrl.EndsWith($"#{ContentAnchors.ArticleBlockParagraphId(0, 0)}")), Is.True);
    }

    [Test]
    public async Task QuickSearch_PageUrl_ContainsRequirementAnchor()
    {
        var sut = new SearchService([
            new Project
            {
                Id = 3,
                Title = "Build a Calculator",
                Slug = "build-a-calculator",
                Requirements = ["Handle addition", "Handle subtraction"],
                Blocks = null
            }
        ]);

        var results = (await sut.QuickSearch("addition", CancellationToken.None)).ToList();

        Assert.That(results.Any(r => r.PageUrl.EndsWith($"#{ContentAnchors.ProjectRequirementId(0)}")), Is.True);
    }

    [Test]
    public async Task QuickSearch_Snippet_IsNotNull_WhenMatchFound()
    {
        var sut = new SearchService([
            new Project { Id = 1, Title = "Build a Calculator", Slug = "build-a-calculator", Blocks = null }
        ]);

        var results = (await sut.QuickSearch("calculator", CancellationToken.None)).ToList();

        Assert.That(results.First().Snippet, Is.Not.Null);
    }

    [Test]
    public async Task QuickSearch_Snippet_ContainsMarkTag_AroundMatchedTerm()
    {
        var sut = new SearchService([
            new Article
            {
                Id = 1,
                Title = "Introduction to C#",
                Slug = "intro-to-csharp",
                Blocks = [new Block { Paragraphs = [new Paragraph { Body = "C# is a strongly typed language." }] }]
            }
        ]);

        var results = (await sut.QuickSearch("strongly", CancellationToken.None)).ToList();

        var hit = results.First();
        Assert.That(hit.Snippet, Does.Contain("<mark>"));
        Assert.That(hit.Snippet, Does.Contain("</mark>"));
    }

    [Test]
    public async Task QuickSearch_Snippet_HasEllipsisPrefix_WhenMatchIsFarFromStart()
    {
        var sut = new SearchService([
            new Article
            {
                Id = 1,
                Title = "Test article",
                Slug = "test",
                Blocks = [new Block
                {
                    Paragraphs = [new Paragraph
                    {
                        Body = "This is a long introductory sentence that comes before the keyword located right here"
                    }]
                }]
            }
        ]);

        var results = (await sut.QuickSearch("keyword", CancellationToken.None)).ToList();

        Assert.That(results, Is.Not.Empty);
        Assert.That(results.First().Snippet, Does.StartWith("..."));
    }

    [Test]
    public async Task QuickSearch_Snippet_HasEllipsisSuffix_WhenTextContinuesPastWindow()
    {
        var sut = new SearchService([
            new Article
            {
                Id = 1,
                Title = "Test article",
                Slug = "test",
                Blocks = [new Block
                {
                    Paragraphs = [new Paragraph
                    {
                        Body = "Target word at the beginning then many more words that extend well beyond the forty character window here"
                    }]
                }]
            }
        ]);

        var results = (await sut.QuickSearch("target", CancellationToken.None)).ToList();

        Assert.That(results, Is.Not.Empty);
        Assert.That(results.First().Snippet, Does.EndWith("..."));
    }

    [Test]
    public async Task QuickSearch_Snippet_DoesNotProduceOverlappingMarkTags()
    {
        var sut = new SearchService([
            new Article
            {
                Id = 1,
                Title = "Test article",
                Slug = "test",
                Blocks = [new Block
                {
                    Paragraphs = [new Paragraph { Body = "Introduction to something interesting" }]
                }]
            }
        ]);

        var results = (await sut.QuickSearch("intro introduction", CancellationToken.None)).ToList();

        Assert.That(results, Is.Not.Empty);
        var snippet = results.First().Snippet;
        Assert.That(snippet, Does.Not.Contain("<mark><mark>"));
        Assert.That(snippet, Does.Not.Contain("</mark></mark>"));
    }

    [Test]
    public async Task QuickSearch_TitleMatch_RankedAbove_BlockBodyMatch()
    {
        var sut = new SearchService([
            new Article { Id = 1, Title = "Zebra article", Slug = "zebra-a", Blocks = null },
            new Article
            {
                Id = 2,
                Title = "Other article",
                Slug = "other-a",
                Blocks = [new Block { Paragraphs = [new Paragraph { Body = "The zebra is an animal" }] }]
            }
        ]);

        var results = (await sut.QuickSearch("zebra", CancellationToken.None)).ToList();

        Assert.That(results[0].Title, Is.EqualTo("Zebra article"));
    }

    [Test]
    public async Task QuickSearch_MoreMatchedTokens_RankedFirst()
    {
        var sut = new SearchService([
            new Article { Id = 1, Title = "Hello world tutorial", Slug = "hwt", Blocks = null },
            new Article { Id = 2, Title = "Hello basics", Slug = "hb", Blocks = null }
        ]);

        var results = (await sut.QuickSearch("hello world", CancellationToken.None)).ToList();

        Assert.That(results[0].Title, Is.EqualTo("Hello world tutorial"));
    }

    [Test]
    public async Task QuickSearch_ExactMatch_RankedAbove_PrefixMatch()
    {
        var sut = new SearchService([
            new Article { Id = 1, Title = "calc helper", Slug = "ch", Blocks = null },
            new Article { Id = 2, Title = "Calculator app", Slug = "ca", Blocks = null }
        ]);

        var results = (await sut.QuickSearch("calc", CancellationToken.None)).ToList();

        Assert.That(results[0].Title, Is.EqualTo("calc helper"));
    }

    [Test]
    public async Task QuickSearch_MatchesInProjectRequirementsIntro()
    {
        var sut = new SearchService([
            new Project
            {
                Id = 3,
                Title = "Build a Calculator",
                Slug = "build-a-calculator",
                RequirementsIntro = "Build a console calculator application.",
                Blocks = null
            }
        ]);

        var results = (await sut.QuickSearch("console", CancellationToken.None)).ToList();

        var hit = results.First(r => r.Title == "Build a Calculator");
        Assert.That(hit.PageUrl, Does.Contain($"#{ContentAnchors.ProjectRequirementsIntroId}"));
    }

    [Test]
    public async Task QuickSearch_MatchesInProjectTip()
    {
        var sut = new SearchService([
            new Project
            {
                Id = 1,
                Title = "Some project",
                Slug = "some-project",
                Tips = ["Use recursion for better performance"],
                Blocks = null
            }
        ]);

        var results = (await sut.QuickSearch("recursion", CancellationToken.None)).ToList();

        Assert.That(results, Is.Not.Empty);
        Assert.That(results.Any(r => r.PageUrl.Contains($"#{ContentAnchors.ProjectTipId(0)}")), Is.True);
    }

    [Test]
    public async Task QuickSearch_MatchesInProjectChallenge()
    {
        var sut = new SearchService([
            new Project
            {
                Id = 1,
                Title = "Some project",
                Slug = "some-project",
                Challenges = ["Implement undo functionality"],
                Blocks = null
            }
        ]);

        var results = (await sut.QuickSearch("undo", CancellationToken.None)).ToList();

        Assert.That(results, Is.Not.Empty);
        Assert.That(results.Any(r => r.PageUrl.Contains($"#{ContentAnchors.ProjectChallengeId(0)}")), Is.True);
    }

    [Test]
    public async Task QuickSearch_MatchesInProjectLearningItem()
    {
        var sut = new SearchService([
            new Project
            {
                Id = 1,
                Title = "Some project",
                Slug = "some-project",
                LearningItems = ["Understand dependency injection"],
                Blocks = null
            }
        ]);

        var results = (await sut.QuickSearch("dependency", CancellationToken.None)).ToList();

        Assert.That(results, Is.Not.Empty);
        Assert.That(results.Any(r => r.PageUrl.Contains($"#{ContentAnchors.ProjectLearningItemId(0)}")), Is.True);
    }

    [TestCase("f#", "F# fundamentals", "fsharp-fundamentals")]
    [TestCase(".net", ".NET runtime overview", "dotnet-overview")]
    public async Task QuickSearch_ResolvesForwardAlias(string query, string articleTitle, string slug)
    {
        var sut = new SearchService([
            new Article { Id = 1, Title = articleTitle, Slug = slug, Blocks = null }
        ]);

        var results = (await sut.QuickSearch(query, CancellationToken.None)).ToList();

        Assert.That(results, Is.Not.Empty);
        Assert.That(results.Any(r => r.Title == articleTitle), Is.True);
    }

    [Test]
    public async Task QuickSearch_IconUrl_IsPassedThrough()
    {
        var sut = new SearchService([
            new Article { Id = 1, Title = "Test article", Slug = "test", IconUrl = "test-icon.png", Blocks = null }
        ]);

        var results = (await sut.QuickSearch("test", CancellationToken.None)).ToList();

        Assert.That(results.First().IconUrl, Is.EqualTo("test-icon.png"));
    }

    [Test]
    public async Task PagedSearch_ReturnsEmpty_WhenQueryIsNull()
    {
        var sut = new SearchService([]);

        var result = await sut.PagedSearch(null, 1, CancellationToken.None);

        Assert.That(result.TotalItems, Is.Zero);
        Assert.That(result.Items, Is.Empty);
    }

    [Test]
    public async Task PagedSearch_ReturnsEmpty_WhenQueryIsTooShort()
    {
        var sut = new SearchService([]);

        var result = await sut.PagedSearch("a", 1, CancellationToken.None);

        Assert.That(result.TotalItems, Is.Zero);
        Assert.That(result.Items, Is.Empty);
    }

    [Test]
    public async Task PagedSearch_ReturnsEmpty_WhenNoMatchFound()
    {
        var sut = new SearchService([
            new Article { Id = 1, Title = "Introduction to C#", Slug = "intro-to-csharp", Blocks = null }
        ]);

        var result = await sut.PagedSearch("python", 1, CancellationToken.None);

        Assert.That(result.TotalItems, Is.Zero);
        Assert.That(result.Items, Is.Empty);
    }

    [Test]
    public async Task PagedSearch_TotalCount_ReflectsAllMatches_NotJustCurrentPage()
    {
        var articles = Enumerable.Range(1, PagingConstants.SearchPageSize + 5)
            .Select(i => new Article { Id = i, Title = $"Test article {i}", Slug = $"test-{i}", Blocks = null })
            .ToList<Article>();
        var sut = new SearchService(articles);

        var result = await sut.PagedSearch("test", 1, CancellationToken.None);

        Assert.That(result.TotalItems, Is.EqualTo(PagingConstants.SearchPageSize + 5));
        Assert.That(result.Items.Count, Is.EqualTo(PagingConstants.SearchPageSize));
        Assert.That(result.TotalPages, Is.EqualTo(2));
    }

    [Test]
    public async Task PagedSearch_ReturnsFirstPage_WhenPageIsNegative()
    {
        var sut = new SearchService([
            new Article { Id = 1, Title = "Test article", Slug = "test", Blocks = null }
        ]);

        var result = await sut.PagedSearch("test", -5, CancellationToken.None);

        Assert.That(result.PageNumber, Is.EqualTo(1));
    }

    [Test]
    public async Task PagedSearch_TotalPages_IsOne_WhenResultsLessThanPageSize()
    {
        var sut = new SearchService([
            new Article { Id = 1, Title = "Test article", Slug = "test", Blocks = null },
            new Article { Id = 2, Title = "Test two", Slug = "test-two", Blocks = null },
            new Article { Id = 3, Title = "Test three", Slug = "test-three", Blocks = null }
        ]);

        var result = await sut.PagedSearch("test", 1, CancellationToken.None);

        Assert.That(result.TotalPages, Is.EqualTo(1));
    }

    [Test]
    public async Task PagedSearch_TotalItems_IsZero_WhenNoResults()
    {
        var sut = new SearchService([
            new Article { Id = 1, Title = "Introduction to C#", Slug = "intro-to-csharp", Blocks = null }
        ]);

        var result = await sut.PagedSearch("python", 1, CancellationToken.None);

        Assert.That(result.TotalItems, Is.Zero);
    }

    [Test]
    public async Task PagedSearch_Items_HaveCorrectPageUrl()
    {
        var sut = new SearchService([
            new Project { Id = 5, Title = "Test project", Slug = "test-project", Blocks = null }
        ]);

        var result = await sut.PagedSearch("test", 1, CancellationToken.None);

        Assert.That(result.Items[0].PageUrl, Does.StartWith("/project/5/test-project"));
    }

    [Test]
    public async Task PagedSearch_RankingIsPreservedAcrossPages()
    {
        var articles = new List<Article>
        {
            new Article { Id = 1, Title = "Blazor overview", Slug = "blazor-overview", Blocks = null }
        };
        for (var i = 2; i <= PagingConstants.SearchPageSize + 2; i++)
        {
            articles.Add(new Article
            {
                Id = i,
                Title = $"Article {i}",
                Slug = $"article-{i}",
                Blocks = [new Block { Paragraphs = [new Paragraph { Body = "Blazor is a framework." }] }]
            });
        }
        var sut = new SearchService(articles);

        var result = await sut.PagedSearch("blazor", 1, CancellationToken.None);

        Assert.That(result.Items[0].Title, Is.EqualTo("Blazor overview"));
    }

}
