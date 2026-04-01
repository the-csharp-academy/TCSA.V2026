using TCSA.V2026.Data.Curriculum;
using TCSA.V2026.Data.DTOs;

namespace TCSA.V2026.Helpers;

public static class SearchHelper
{
    public static List<SearchItem> GetSearchItems()
    {
        var articles = ArticleHelper.GetArticles()
            .Where(a => !string.IsNullOrEmpty(a.Slug))
            .Select(a => new SearchItem(a.Title, $"/article/{a.Id}/{a.Slug}", a.IconUrl));

        var projects = ProjectHelper.GetProjects()
            .Where(p => !string.IsNullOrEmpty(p.Slug))
            .Select(p => new SearchItem(p.Title, $"/project/{p.Id}/{p.Slug}", p.IconUrl));

        return [.. articles, .. projects];
    }

    public static Task<IEnumerable<SearchItem>> Search(string? value, CancellationToken token)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Task.FromResult(Enumerable.Empty<SearchItem>());

        var searchItems = GetSearchItems();
        return Task.FromResult(searchItems.Where(item => item.Title.Contains(value, StringComparison.OrdinalIgnoreCase))
            .Take(10));
    }
}
