using TCSA.V2026.Data.Enums;
using TCSA.V2026.Data.Models.Responses;

namespace TCSA.V2026.UnitTests.Models;

[TestFixture]
public class ResultTests
{
    private static readonly Error NotFound = new("User.NotFound", "User not found.");

    [Test]
    public void Success_ShouldBeSuccessWithEmptyMessage()
    {
        var result = Result.Success();

        Assert.Multiple(() =>
        {
            Assert.That(result.IsSuccess, Is.True);
            Assert.That(result.IsFailure, Is.False);
            Assert.That(result.Reason, Is.TypeOf<Success>());
            Assert.That(result.Message, Is.Empty);
        });
    }

    [Test]
    public void Success_WithReason_ShouldExposeCodeAndMessage()
    {
        var result = Result.Success(new Success("Profile.Updated", "Profile updated successfully."));

        Assert.Multiple(() =>
        {
            Assert.That(result.IsSuccess, Is.True);
            Assert.That(result.Reason.Code, Is.EqualTo("Profile.Updated"));
            Assert.That(result.Message, Is.EqualTo("Profile updated successfully."));
        });
    }

    [Test]
    public void Failure_ShouldBeFailureWithErrorDetails()
    {
        var result = Result.Failure(NotFound);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsSuccess, Is.False);
            Assert.That(result.IsFailure, Is.True);
            Assert.That(result.Reason, Is.SameAs(NotFound));
            Assert.That(result.Message, Is.EqualTo("User not found."));
        });
    }

    [Test]
    public void Failure_WithEmptyDescription_ShouldNotThrow()
    {
        var result = Result.Failure(new Error("External.Failed", ""));

        Assert.That(result.IsFailure, Is.True);
    }

    [TestCase("")]
    [TestCase("  ")]
    [TestCase(null)]
    public void Failure_WithBlankCode_ShouldThrow(string? code)
    {
        Assert.Catch<ArgumentException>(() => Result.Failure(new Error(code!, "description")));
    }

    [Test]
    public void Failure_WithNullError_ShouldThrow()
    {
        Assert.Throws<ArgumentNullException>(() => Result.Failure(null!));
    }

    [Test]
    public void SuccessOfT_ShouldExposeValue()
    {
        var result = Result.Success(5);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsSuccess, Is.True);
            Assert.That(result.Value, Is.EqualTo(5));
        });
    }

    [Test]
    public void SuccessOfT_WithReason_ShouldExposeValueAndMessage()
    {
        var result = Result.Success("item", new Success("Gallery.ItemAdded", "Item added successfully"));

        Assert.Multiple(() =>
        {
            Assert.That(result.Value, Is.EqualTo("item"));
            Assert.That(result.Message, Is.EqualTo("Item added successfully"));
        });
    }

    [Test]
    public void SuccessOfT_WithNullValue_ShouldThrow()
    {
        Assert.Throws<ArgumentNullException>(() => Result.Success<string>(null!));
    }

    [Test]
    public void FailureOfT_ShouldThrowWhenValueIsAccessed()
    {
        var result = Result.Failure<int>(NotFound);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsFailure, Is.True);
            Assert.That(result.Message, Is.EqualTo("User not found."));
            Assert.Throws<InvalidOperationException>(() => _ = result.Value);
        });
    }

    [Test]
    public void FailureOfT_ShouldBeUsableAsNonGenericResult()
    {
        Result result = Result.Failure<int>(NotFound);

        Assert.That(result.Reason, Is.SameAs(NotFound));
    }

    [Test]
    public void ImplicitConversion_FromValue_ShouldCreateSuccess()
    {
        Result<string> result = "hello";

        Assert.Multiple(() =>
        {
            Assert.That(result.IsSuccess, Is.True);
            Assert.That(result.Value, Is.EqualTo("hello"));
        });
    }

    [Test]
    public void ImplicitConversion_FromNull_ShouldCreateFailure()
    {
        string? value = null;

        Result<string> result = value;

        Assert.Multiple(() =>
        {
            Assert.That(result.IsFailure, Is.True);
            Assert.That(result.Reason.Code, Is.EqualTo("Result.NullValue"));
        });
    }

    [Test]
    public void ImplicitConversion_FromDefaultValueType_ShouldCreateSuccess()
    {
        Result<int> result = 0;

        Assert.Multiple(() =>
        {
            Assert.That(result.IsSuccess, Is.True);
            Assert.That(result.Value, Is.Zero);
        });
    }

    [Test]
    public void Reasons_ShouldHaveValueEquality()
    {
        var error = new Error("A", "b");

        Assert.Multiple(() =>
        {
            Assert.That(error, Is.EqualTo(new Error("A", "b")));
            Assert.That((Reason)error, Is.Not.EqualTo(new Success("A", "b")));
        });
    }

    [Test]
    public void Error_WithoutType_ShouldDefaultToFailure()
    {
        var error = new Error("A", "b");

        Assert.That(error.Type, Is.EqualTo(ErrorType.Failure));
    }

    [Test]
    public void ValidationError_ShouldExposeErrorsAndValidationType()
    {
        var fieldError = new Error("User.InvalidLinkedInUrl", "Invalid.", ErrorType.Validation);

        var validationError = ValidationError.FromErrors([fieldError]);

        Assert.Multiple(() =>
        {
            Assert.That(validationError.Code, Is.EqualTo("Validation.General"));
            Assert.That(validationError.Type, Is.EqualTo(ErrorType.Validation));
            Assert.That(validationError.Errors, Is.EqualTo(new[] { fieldError }));
        });
    }

    [Test]
    public void ValidationFailure_ShouldBeFailureWithValidationError()
    {
        var fieldError = new Error("User.InvalidLinkedInUrl", "Invalid.", ErrorType.Validation);

        var result = Result.ValidationFailure(ValidationError.FromErrors([fieldError]));

        Assert.Multiple(() =>
        {
            Assert.That(result.IsFailure, Is.True);
            Assert.That(result.Reason, Is.InstanceOf<ValidationError>());
            Assert.That(((ValidationError)result.Reason).Errors, Is.EqualTo(new[] { fieldError }));
        });
    }

    [Test]
    public void ValidationFailureOfT_ShouldBeFailureAndThrowWhenValueIsAccessed()
    {
        var result = Result.ValidationFailure<int>(ValidationError.FromErrors([]));

        Assert.Multiple(() =>
        {
            Assert.That(result.IsFailure, Is.True);
            Assert.That(result.Reason, Is.InstanceOf<ValidationError>());
            Assert.Throws<InvalidOperationException>(() => _ = result.Value);
        });
    }
}
