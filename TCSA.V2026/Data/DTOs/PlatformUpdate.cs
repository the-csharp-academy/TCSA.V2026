namespace TCSA.V2026.Data.DTOs;

public enum PlatformUpdateType
{
    Platform,
    Course,
    Article,
    Project
}

public record PlatformUpdate(DateOnly Date, string Title, PlatformUpdateType Type, string Description);
