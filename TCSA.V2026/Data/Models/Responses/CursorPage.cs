namespace TCSA.V2026.Data.Models.Responses;

public class CursorPage<T>
{
    public List<T> Items { get; init; } = [];
    public string? NextCursor { get; init; }
}
