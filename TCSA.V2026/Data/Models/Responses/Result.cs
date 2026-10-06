using System.Diagnostics.CodeAnalysis;

namespace TCSA.V2026.Data.Models.Responses;

public class Result
{
    private static readonly Success DefaultSuccess = new("Success", "");

    internal static readonly Error NullValue = new("Result.NullValue", "Value cannot be null.");

    public Reason Reason { get; }
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public string Message => Reason.Description;

    protected Result(Reason reason)
    {
        ArgumentNullException.ThrowIfNull(reason);
        ArgumentException.ThrowIfNullOrWhiteSpace(reason.Code, nameof(reason));

        Reason = reason;
        IsSuccess = reason is Success;
    }

    public static Result Success() => new(DefaultSuccess);
    public static Result Success(Success success) => new(success);
    public static Result<TValue> Success<TValue>(TValue value) => Success(value, DefaultSuccess);
    public static Result<TValue> Success<TValue>(TValue value, Success success)
    {
        if (value is null) throw new ArgumentNullException(nameof(value));
        return new(value, success);
    }

    public static Result Failure(Error error) => new(error);
    public static Result<TValue> Failure<TValue>(Error error) => new(default, error);
}

public class Result<TValue> : Result
{
    private readonly TValue? _value;

    [NotNull]
    public TValue Value
    {
        get
        {
            if (IsFailure) throw new InvalidOperationException("Cannot access the value of a failure result.");
            return _value!;
        }
    }

    internal Result(TValue? value, Reason reason) : base(reason)
    {
        _value = value;
    }

    public static implicit operator Result<TValue>(TValue? value) =>
        value is not null ? Success(value) : Failure<TValue>(NullValue);
}
