using TCSA.V2026.Data.DTOs;

namespace TCSA.V2026.Services;

/// <summary>
/// Connects the admin survey respondents table to the answers drawer.
/// </summary>
public class SurveyRespondentDetailState
{
    public SurveyRespondentDto? Selected { get; private set; }

    public event Action? OnChange;

    public void Open(SurveyRespondentDto respondent)
    {
        Selected = respondent;
        OnChange?.Invoke();
    }

    public void Close()
    {
        if (Selected is null) return;

        Selected = null;
        OnChange?.Invoke();
    }
}
