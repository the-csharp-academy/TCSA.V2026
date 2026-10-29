namespace TCSA.V2026.Services;

/// <summary>
/// Tells the navigation menu to reload its count of available surveys after the user submits or refuses one.
/// </summary>
public class SurveyBadgeState
{
    public event Func<Task>? OnChange;

    public async Task NotifyChangedAsync()
    {
        if (OnChange == null) return;

        foreach (var handler in OnChange.GetInvocationList())
        {
            if (handler is Func<Task> asyncHandler)
            {
                await asyncHandler.Invoke();
            }
        }
    }
}
