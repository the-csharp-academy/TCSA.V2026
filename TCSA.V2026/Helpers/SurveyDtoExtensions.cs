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
}
