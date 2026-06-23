namespace TCSA.V2026.Services;

public class OnboardingStateService
{
    public event Func<Task>? OnChange;

    public async Task NotifyChangedAsync()
    {
        if (OnChange != null)
            await OnChange.Invoke();
    }
}
