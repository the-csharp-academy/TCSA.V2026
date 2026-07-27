namespace TCSA.V2026.Services;

public class OnboardingStateService
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
