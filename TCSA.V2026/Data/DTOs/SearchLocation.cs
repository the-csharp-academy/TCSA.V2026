namespace TCSA.V2026.Data.DTOs;

public readonly record struct SearchLocation(int ArticleId, string? AnchorId)
{
    public bool IsDefault => AnchorId is null;
}
