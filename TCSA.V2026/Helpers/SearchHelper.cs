using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using TCSA.V2026.Data.Curriculum;
using TCSA.V2026.Data.DTOs;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Helpers.Constants;

namespace TCSA.V2026.Helpers;

public static partial class SearchHelper
{
    private const int QuickSearchLimit = 10;
    private const int ExactMatchWeight = 200;
    private const int PartialMatchWeight = 50;
    private static readonly Dictionary<string, HashSet<SearchLocation>> _index = [];
    private static readonly Dictionary<SearchLocation, string> _snippetLookup = [];
    private static readonly List<Article> _allArticles = [.. ArticleHelper.GetArticles(), .. ProjectHelper.GetProjects()];
    private static readonly Dictionary<string, string> _aliases = new()
    {
        ["c#"] = "csharp",
        ["f#"] = "fsharp",
        ["asp.net"] = "aspnet",
        [".net"] = "dotnet"
    };

    private static readonly Dictionary<string, string> _reverseAliases =
        _aliases.ToDictionary(kvp => kvp.Value, kvp => kvp.Key);

    [GeneratedRegex("<[^>]+>", RegexOptions.Compiled)]
    private static partial Regex HtmlTagRegex();

    [GeneratedRegex("[^a-z0-9]+", RegexOptions.Compiled)]
    private static partial Regex TokenizeRegex();

    static SearchHelper()
    {
        foreach (var article in ArticleHelper.GetArticles())
            IndexArticle(article);

        foreach (var project in ProjectHelper.GetProjects())
            IndexArticle(project);
    }

    private static void IndexArticle(Article article)
    {
        IndexField(article.Id, ContentAnchors.ArticleTitleId, article.Title);
        IndexField(article.Id, ContentAnchors.ArticleDescriptionId, article.Description);

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

    private static void IndexField(int articleId, string anchorId, string? text)
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
        return TokenizeRegex().Split(Normalize(text))
            .Distinct()
            .Where(t => t.Length > 1);
    }

    public static Task<IEnumerable<SearchItem>> QuickSearch(string? value, CancellationToken token)
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
                    if (!matchStrength.TryGetValue(location, out var existing) || ExactMatchWeight > existing)
                        matchStrength[location] = ExactMatchWeight;
                    if (!matchedTokens.ContainsKey(location))
                        matchedTokens[location] = [];

                    matchedTokens[location].Add(stringToken);
                }
            }

            foreach (var (indexedToken, locations) in _index)
                if (indexedToken != stringToken && indexedToken.StartsWith(stringToken))
                {
                    foreach (var location in locations)
                    {
                        if (!matchStrength.TryGetValue(location, out var existing) || PartialMatchWeight > existing)
                            matchStrength[location] = PartialMatchWeight;
                        if (!matchedTokens.ContainsKey(location))
                            matchedTokens[location] = [];

                        matchedTokens[location].Add(stringToken);
        }
                }
        }

        if (matchStrength.Count == 0)
            return Task.FromResult(Enumerable.Empty<SearchItem>());

        return Task.FromResult(matchStrength.Keys
            .OrderByDescending(l => matchedTokens[l].Count)
            .ThenByDescending(l => GetWeight(l.AnchorId) * matchStrength[l])
            .Select(location =>
            {
                var article = _allArticles.First(a => a.Id == location.ArticleId);
                var baseUrl = article is Project project
                    ? $"/project/{project.Id}/{project.Slug}"
                    : $"/article/{article.Id}/{article.Slug}";

                _snippetLookup.TryGetValue(location, out var text);
                var snippet = text != null ? ExtractSnippet(text, value) : null;
                return new SearchItem(article.Title, $"{baseUrl}#{location.AnchorId}", article.IconUrl, snippet);
            })
            .Take(QuickSearchLimit));
    }

    private static string ExtractSnippet(string text, string query, int contextChars = 20)
    {
        var index = text.IndexOf(query, StringComparison.OrdinalIgnoreCase);
        var matchTerm = query;

        if (index < 0)
        {
            matchTerm = Tokenize(query).FirstOrDefault() ?? query;
            if (!_reverseAliases.TryGetValue(matchTerm, out var original))
                original = _reverseAliases.FirstOrDefault(kvp => kvp.Key.StartsWith(matchTerm)).Value;
            if (original != null)
                matchTerm = original;
            index = text.IndexOf(matchTerm, StringComparison.OrdinalIgnoreCase);
            if (index < 0)
                return text.Length > contextChars ? text[..contextChars] + "..." : text;
        }

        var start = Math.Max(0, index - contextChars);
        var end = Math.Min(text.Length, index + matchTerm.Length + contextChars);
        var snippet = text[start..end];
        var prefix = start > 0 ? "..." : "";
        var suffix = end < text.Length ? "..." : "";

        var matchInSnippet = snippet.IndexOf(matchTerm, StringComparison.OrdinalIgnoreCase);
        if (matchInSnippet >= 0)
        {
            var actualMatch = snippet.Substring(matchInSnippet, matchTerm.Length);
            snippet = snippet[..matchInSnippet] + $"<mark>{actualMatch}</mark>" + snippet[(matchInSnippet + matchTerm.Length)..];
        }

        return prefix + snippet + suffix;
    }

    private static string StripHtml(string? html)
    {
        if (string.IsNullOrEmpty(html)) return string.Empty;
        return HtmlTagRegex().Replace(html, " ").Trim();
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
