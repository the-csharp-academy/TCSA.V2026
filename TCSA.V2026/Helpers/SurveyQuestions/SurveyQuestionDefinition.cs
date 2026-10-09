using TCSA.V2026.Data.DTOs;
using TCSA.V2026.Data.Enums;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Data.Models.Responses;

namespace TCSA.V2026.Helpers.SurveyQuestions;

/// <summary>
/// Everything the app knows about one question type: how it is presented in the builder, how a draft of it is
/// validated and turned into a <see cref="SurveyQuestion"/>, how a stored one is re-checked on activation, and how
/// an answer is described on the review step.
/// To add a question type, add an enum value, a <see cref="SurveyQuestion"/> subclass and a
/// <see cref="SurveyAnswer"/> subclass, each with its <c>HasValue</c> mapping, and a definition registered in
/// <see cref="SurveyQuestionRegistry"/>. The input control also needs a case in <c>TCSASurveyQuestionInput.razor</c>,
/// which is also where the rule that a rating of 0 clears the answer lives.
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
    /// True when nothing was given for this type of question. For an optional question that means it was skipped.
    /// </summary>
    public abstract bool IsBlank(SurveyAnswerDto answer);

    /// <summary>
    /// Checks a non-blank answer to this type of question. Blank answers are handled before this is called.
    /// </summary>
    public abstract Error? ValidateAnswer(SurveyQuestion question, SurveyAnswerDto answer);

    /// <summary>
    /// Builds the stored answer from one that has already passed <see cref="ValidateAnswer"/>, keeping only the
    /// fields this type uses.
    /// </summary>
    public abstract SurveyAnswer CreateAnswer(SurveyQuestion question, SurveyAnswerDto answer);

    /// <summary>
    /// The human-readable form of a non-blank answer, shown on the review step.
    /// </summary>
    public abstract string DescribeAnswer(SurveyQuestionDto question, SurveyAnswerDto answer);

    /// <summary>
    /// Re-checks a stored question before its survey is activated.
    /// </summary>
    public virtual Error? ValidateStored(SurveyQuestion question) => null;
}
