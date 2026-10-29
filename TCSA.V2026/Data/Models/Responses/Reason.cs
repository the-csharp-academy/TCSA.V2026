using TCSA.V2026.Data.Enums;

namespace TCSA.V2026.Data.Models.Responses;

public abstract record Reason(string Code, string Description);

public sealed record Success(string Code, string Description) : Reason(Code, Description);

public record Error(string Code, string Description, ErrorType Type = ErrorType.Failure) : Reason(Code, Description);
