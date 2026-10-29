using TCSA.V2026.Data.Enums;

namespace TCSA.V2026.Data.Models.Responses;

public sealed record ValidationError : Error
{
    public Error[] Errors { get; }

    public ValidationError(Error[] errors)
        : base("Validation.General", "One or more validation errors occurred.", ErrorType.Validation)
    {
        Errors = errors;
    }

    public static ValidationError FromErrors(Error[] errors) => new(errors);
}
