namespace TCSA.V2026.Data.Models.Responses;

public abstract record Reason(string Code, string Description);

public sealed record Success(string Code, string Description) : Reason(Code, Description);

public sealed record Error(string Code, string Description) : Reason(Code, Description);
