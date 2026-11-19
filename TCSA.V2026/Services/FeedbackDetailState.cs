using TCSA.V2026.Data.DTOs;

namespace TCSA.V2026.Services;

/// <summary>
/// Connects the All Feedback page to the detail drawer. The drawer lives in the LayoutControls island
/// (so it can sit over the app bar and footer like the navigation drawer), outside the page's component tree.
/// </summary>
public class FeedbackDetailState
{
    public FeedbackAdminItemDto? Selected { get; private set; }

    public event Action? OnChange;
    public event Func<int, Task>? OnDeleted;

    public void Open(FeedbackAdminItemDto item)
    {
        Selected = item;
        OnChange?.Invoke();
    }

    public void Close()
    {
        if (Selected is null) return;

        Selected = null;
        OnChange?.Invoke();
    }

    public async Task NotifyDeletedAsync(int id)
    {
        Close();

        if (OnDeleted is null) return;

        foreach (var handler in OnDeleted.GetInvocationList())
        {
            await ((Func<int, Task>)handler).Invoke(id);
        }
    }
}
