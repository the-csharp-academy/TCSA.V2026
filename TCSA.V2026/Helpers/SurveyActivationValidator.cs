using TCSA.V2026.Data.Models;
using TCSA.V2026.Data.Models.Responses;
using TCSA.V2026.Helpers.SurveyQuestions;

namespace TCSA.V2026.Helpers;

public static class SurveyActivationValidator
{
    public static Error? Validate(Survey survey)
    {
        if (survey.Questions.Count == 0)
        {
            return SurveyErrors.NoQuestions;
        }

        return survey.Questions
            .Select(q => SurveyQuestionRegistry.Get(q.Type).ValidateStored(q))
            .OfType<Error>()
            .FirstOrDefault();
    }
}
