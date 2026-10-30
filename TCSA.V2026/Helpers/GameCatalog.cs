namespace TCSA.V2026.Helpers;

public sealed record GameInfo(string Slug, string Title, string Description, string Url);

public static class GameCatalog
{
    public static IReadOnlyList<GameInfo> Games { get; } = Array.AsReadOnly<GameInfo>(
    [
        new("button-challenge", "Button Challenge",
            "Click as many target buttons as you can within 30 seconds. Each hit earns a point.",
            "https://the-csharp-academy.github.io/Games.Unity.ButtonGame/Web/")
    ]);
}
