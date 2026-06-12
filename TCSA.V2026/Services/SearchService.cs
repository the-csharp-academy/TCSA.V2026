using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using TCSA.V2026.Data.DTOs;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Helpers.Constants;

namespace TCSA.V2026.Services;

public interface ISearchService
{
    Task<IEnumerable<SearchItem>> QuickSearch(string? value, CancellationToken token);
    IReadOnlyCollection<string> GetHighlightTerms(string query);
}

public class SearchService : ISearchService
{
    private const int QuickSearchLimit = 10;
    private const int ExactMatchWeight = 200;
    private const int PartialMatchWeight = 50;

    private static readonly Regex _htmlTagRegex = new("<[^>]+>", RegexOptions.Compiled);
    private static readonly Regex _tokenizeRegex = new("[^a-z0-9]+", RegexOptions.Compiled);
    private static readonly Dictionary<string, string> _aliases = new()
    {
        ["c#"] = "csharp",
        ["f#"] = "fsharp",
        ["asp.net"] = "aspnet",
        [".net"] = "dotnet"
    };
    private static readonly Dictionary<string, string> _reverseAliases =
        _aliases.ToDictionary(kvp => kvp.Value, kvp => kvp.Key);

    private readonly Dictionary<string, HashSet<SearchLocation>> _index = [];
    private readonly Dictionary<SearchLocation, string> _snippetLookup = [];
    private readonly List<Article> _allArticles;

    public SearchService(IEnumerable<Article> articles)
    {
        _allArticles = [..articles];
        foreach (var article in _allArticles)
            IndexArticle(article);
    }

    private void IndexArticle(Article article)
    {
        IndexField(article.Id, ContentAnchors.ArticleTitleId, article.Title);

        if (article is Project project)
        {
            IndexField(article.Id, ContentAnchors.ProjectRequirementsIntroId, project.RequirementsIntro);
            IndexField(article.Id, ContentAnchors.ProjectRequirementsConclusionId, project.RequirementsConclusion);
            IndexField(article.Id, ContentAnchors.ProjectResourcesIntroId, project.ResourcesIntro);
            IndexField(article.Id, ContentAnchors.ProjectResourcesConclusionId, project.ResourcesConclusion);
            IndexField(article.Id, ContentAnchors.ProjectLearningIntroId, project.LearningIntro);

            if (project.Requirements != null)
                for (var i = 0; i < project.Requirements.Count; i++)
                    IndexField(article.Id, ContentAnchors.ProjectRequirementId(i), project.Requirements[i]);

            if (project.Introduction != null)
                for (var i = 0; i < project.Introduction.Count; i++)
                {
                    if (string.IsNullOrEmpty(project.Introduction[i].Body)) continue;
                    IndexField(article.Id, ContentAnchors.ProjectIntroductionParagraphId(i), project.Introduction[i].Body);
                }

            if (project.Resources != null)
                for (var i = 0; i < project.Resources.Count; i++)
                    IndexField(article.Id, ContentAnchors.ProjectResourceId(i), project.Resources[i]);

            if (project.Tips != null)
                for (var i = 0; i < project.Tips.Count; i++)
                    IndexField(article.Id, ContentAnchors.ProjectTipId(i), project.Tips[i]);

            if (project.Challenges != null)
                for (var i = 0; i < project.Challenges.Count; i++)
                    IndexField(article.Id, ContentAnchors.ProjectChallengeId(i), project.Challenges[i]);

            if (project.LearningItems != null)
                for (var i = 0; i < project.LearningItems.Count; i++)
                    IndexField(article.Id, ContentAnchors.ProjectLearningItemId(i), project.LearningItems[i]);
        }

        if (article.Blocks is null) return;

        for (var bi = 0; bi < article.Blocks.Count; bi++)
        {
            var block = article.Blocks[bi];
            IndexField(article.Id, ContentAnchors.ArticleBlockTitleId(bi), block.Title);

            if (block.Paragraphs is null) continue;

            for (var pi = 0; pi < block.Paragraphs.Count; pi++)
            {
                if (string.IsNullOrEmpty(block.Paragraphs[pi].Body)) continue;
                IndexField(article.Id, ContentAnchors.ArticleBlockParagraphId(bi, pi), block.Paragraphs[pi].Body);
            }
        }
    }

    private void IndexField(int articleId, string anchorId, string? text)
    {
        if (string.IsNullOrWhiteSpace(text)) return;

        var stripped = StripHtml(text);
        var location = new SearchLocation(articleId, anchorId);
        _snippetLookup.TryAdd(location, stripped);
        foreach (var token in Tokenize(stripped))
        {
            if (!_index.TryGetValue(token, out var locations))
            {
                locations = [];
                _index[token] = locations;
            }
            locations.Add(location);
        }
    }

    private static string Normalize(string text)
    {
        var result = text.ToLowerInvariant();
        foreach (var (original, normalized) in _aliases)
            result = result.Replace(original, normalized);
        return result;
    }

    private static IEnumerable<string> Tokenize(string text)
    {
        return _tokenizeRegex.Split(Normalize(text))
            .Distinct()
            .Where(t => t.Length > 1);
    }

    public Task<IEnumerable<SearchItem>> QuickSearch(string? value, CancellationToken token)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length < 2)
            return Task.FromResult(Enumerable.Empty<SearchItem>());

        var tokens = Tokenize(value).ToList();
        if (tokens.Count == 0)
            return Task.FromResult(Enumerable.Empty<SearchItem>());

        var matchStrength = new Dictionary<SearchLocation, int>();
        var matchedTokens = new Dictionary<SearchLocation, HashSet<string>>();

        foreach (var stringToken in tokens)
        {
            if (_index.TryGetValue(stringToken, out var exactLocations))
            {
                foreach (var location in exactLocations)
                {
                    matchStrength[location] = matchStrength.GetValueOrDefault(location) + ExactMatchWeight;
                    if (!matchedTokens.TryGetValue(location, out var tokenList))
                    {
                        tokenList = [];
                        matchedTokens[location] = tokenList;
                    }
                    tokenList.Add(stringToken);
                }
            }

            foreach (var (indexedToken, locations) in _index)
                if (indexedToken != stringToken && indexedToken.StartsWith(stringToken))
                    foreach (var location in locations)
                        matchStrength[location] = matchStrength.GetValueOrDefault(location) + PartialMatchWeight;
        }

        if (matchStrength.Count == 0)
            return Task.FromResult(Enumerable.Empty<SearchItem>());

        return Task.FromResult(matchStrength.Keys
            .OrderByDescending(l => matchedTokens.GetValueOrDefault(l)?.Count ?? 0)
            .ThenByDescending(l => GetWeight(l.AnchorId) * matchStrength[l])
            .Select(location =>
            {
                var article = _allArticles.First(a => a.Id == location.ArticleId);
                var baseUrl = article is Project p
                    ? $"/project/{p.Id}/{p.Slug}"
                    : $"/article/{article.Id}/{article.Slug}";

                _snippetLookup.TryGetValue(location, out var text);
                var snippet = text != null ? ExtractSnippet(text, value) : null;
                return new SearchItem(article.Title, $"{baseUrl}#{location.AnchorId}", article.IconUrl, snippet);
            })
            .Take(QuickSearchLimit));
    }

    public IReadOnlyCollection<string> GetHighlightTerms(string query)
    {
        var terms = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        foreach (var token in Tokenize(query))
        {
            terms.Add(token);
            if (_reverseAliases.TryGetValue(token, out var original))
                terms.Add(original);
        }
        return terms;
    }

    private string ExtractSnippet(string text, string query, int contextRadius = 40)
    {
        if (string.IsNullOrEmpty(text))
            return string.Empty;

        var terms = GetHighlightTerms(query);

        var ranges = new List<(int Start, int End)>();
        foreach (var term in terms)
        {
            var at = text.IndexOf(term, StringComparison.OrdinalIgnoreCase);
            if (at >= 0)
                ranges.Add((at, at + term.Length));
        }

        if (ranges.Count == 0)
        {
            if (text.Length <= contextRadius)
                return WebUtility.HtmlEncode(text);

            var cut = text.IndexOf(' ', contextRadius);
            var head = cut > 0 ? text[..cut] : text[..contextRadius];
            return WebUtility.HtmlEncode(head) + "...";
        }

        ranges.Sort((a, b) => a.Start.CompareTo(b.Start));

        var (Start, End) = ranges[0];
        var start = Math.Max(0, Start - contextRadius);
        var end = Math.Min(text.Length, End + contextRadius);

        if (start > 0)
        {
            var boundary = text.LastIndexOf(' ', start);
            if (boundary >= 0) start = boundary + 1;
        }
        if (end < text.Length)
        {
            var boundary = text.IndexOf(' ', end);
            if (boundary >= 0) end = boundary;
        }

        var prefix = start > 0 ? "..." : "";
        var suffix = end < text.Length ? "..." : "";

        var sb = new StringBuilder(prefix);
        var cursor = start;

        foreach (var (mStart, mEnd) in ranges)
        {
            if (mStart < cursor || mStart < start || mEnd > end) continue;

            sb.Append(WebUtility.HtmlEncode(text[cursor..mStart]));
            sb.Append("<mark>");
            sb.Append(WebUtility.HtmlEncode(text[mStart..mEnd]));
            sb.Append("</mark>");
            cursor = mEnd;
        }

        sb.Append(WebUtility.HtmlEncode(text[cursor..end]));
        sb.Append(suffix);

        return sb.ToString();
    }

    private static string StripHtml(string? html)
    {
        if (string.IsNullOrEmpty(html)) return string.Empty;
        return _htmlTagRegex.Replace(html, " ").Trim();
    }

    private static int GetWeight(string anchorId) => anchorId switch
    {
        ContentAnchors.ArticleTitleId => 100,
        ContentAnchors.ProjectRequirementsIntroId => 80,
        ContentAnchors.ProjectRequirementsConclusionId => 80,
        ContentAnchors.ProjectResourcesIntroId => 80,
        ContentAnchors.ProjectResourcesConclusionId => 80,
        ContentAnchors.ProjectLearningIntroId => 80,
        _ when anchorId.StartsWith("article-block-title") => 70,
        _ when anchorId.StartsWith("article-block") => 50,
        _ when anchorId.StartsWith("project-requirement") => 60,
        _ when anchorId.StartsWith("project-resource") => 60,
        _ when anchorId.StartsWith("project-tip") => 60,
        _ when anchorId.StartsWith("project-challenge") => 60,
        _ when anchorId.StartsWith("project-learning-item") => 60,
        _ when anchorId.StartsWith("project-introduction-paragraph") => 60,
        _ => 40
    };
}
