using TCSA.V2026.Data.DTOs;
using TCSA.V2026.Data.Models;

namespace TCSA.V2026.Helpers;

public static class SurveyDtoExtensions
{
    public static AvailableSurveyDto ToDto(this Survey survey) => new()
    {
        Id = survey.Id,
        Title = survey.Title,
        Description = survey.Description,
        Questions =
        [
            .. survey.Questions.OrderBy(q => q.Order).Select(q => new SurveyQuestionDto
            {
                Id = q.Id,
                Text = q.Text,
                Type = q.Type,
                IsRequired = q.IsRequired,
                Options = q is ChoiceQuestion choice
                    ? [.. choice.Options.OrderBy(o => o.Order).Select(o => new SurveyOptionDto { Id = o.Id, Text = o.Text })]
                    : []
            })
        ]
    };

    public static SurveyAnswerDto ToDto(this SurveyAnswer answer) => answer switch
    {
        RatingAnswer rating => new SurveyAnswerDto { QuestionId = rating.SurveyQuestionId, NumericValue = rating.Rating },
        YesNoAnswer yesNo => new SurveyAnswerDto { QuestionId = yesNo.SurveyQuestionId, NumericValue = yesNo.IsYes ? 1 : 0 },
        FreeTextAnswer text => new SurveyAnswerDto { QuestionId = text.SurveyQuestionId, TextValue = text.Text },
        ChoiceAnswer choice => new SurveyAnswerDto
        {
            QuestionId = choice.SurveyQuestionId,
            OptionIds = [.. choice.SelectedOptions.Select(o => o.SurveyOptionId)]
        },
        _ => new SurveyAnswerDto { QuestionId = answer.SurveyQuestionId }
    };
}
