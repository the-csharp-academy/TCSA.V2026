using TCSA.V2026.Data.DTOs;
using TCSA.V2026.Data.Enums;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Data.Models.Responses;

namespace TCSA.V2026.Helpers.SurveyQuestions;

/// <summary>
/// Everything the app knows about one question type: how it is presented in the builder, how a draft of it is
/// validated and turned into a <see cref="SurveyQuestion"/>, and how a stored one is re-checked on activation.
/// To add a question type, add an enum value, a <see cref="SurveyQuestion"/> subclass with its
/// <c>HasValue</c> mapping, and a definition registered in <see cref="SurveyQuestionRegistry"/>.
/// </summary>
public abstract class SurveyQuestionDefinition
{
    public abstract SurveyQuestionType Type { get; }
    public abstract string Label { get; }
    public abstract string Icon { get; }

    public virtual string Hint => string.Empty;

    public virtual bool UsesOptions => false;

    /// <summary>
    /// The marker shown beside each option in the builder. Only meaningful when <see cref="UsesOptions"/> is true.
    /// </summary>
    public virtual string? OptionIcon => null;

    /// <summary>
    /// Reshapes a draft so it carries exactly the data this type needs, for example when its type is switched.
    /// </summary>
    public virtual void PrepareDraft(SurveyQuestionDraftDto draft) => draft.Options = [];

    /// <summary>
    /// The rules specific to this type. Text rules shared by every type live in <see cref="SurveyDraftValidator"/>.
    /// </summary>
    public virtual Error? ValidateDraft(SurveyQuestionDraftDto draft) => null;

    /// <summary>
    /// Builds the question from a draft that has already passed validation.
    /// </summary>
    public abstract SurveyQuestion Create(SurveyQuestionDraftDto draft, int order);

    /// <summary>
    /// Re-checks a stored question before its survey is activated.
    /// </summary>
    public virtual Error? ValidateStored(SurveyQuestion question) => null;
}
