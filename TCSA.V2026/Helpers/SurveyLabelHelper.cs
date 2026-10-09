using MudBlazor;
using TCSA.V2026.Data.Enums;

namespace TCSA.V2026.Helpers;

public static class SurveyLabelHelper
{
    public static Color StatusColor(SurveyStatus status) => status switch
    {
        SurveyStatus.Active => Color.Success,
        SurveyStatus.Inactive => Color.Warning,
        _ => Color.Default
    };
}
