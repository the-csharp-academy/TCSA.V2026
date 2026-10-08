using TCSA.V2026.Data.DTOs;

namespace TCSA.V2026.Services;

/// <summary>
/// Connects the admin Feedback page (All feedback and Needs review) to the detail drawer.
/// </summary>
public class FeedbackDetailState
{
    public FeedbackAdminItemDto? Selected { get; private set; }

    public event Action? OnChange;
    public event Func<int, Task>? OnDeleted;
    public event Func<Task>? OnStateChanged;
    public event Func<FeedbackClusterKey, Task>? OnClusterRequested;

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

    /// <summary>Keeps the drawer open on the updated item and tells the page to reload its lists.</summary>
    public Task NotifyStateChangedAsync(FeedbackAdminItemDto updated)
    {
        Selected = updated;
        OnChange?.Invoke();

        return InvokeAllAsync(OnStateChanged, handler => handler());
    }

    /// <summary>Asks the page to show every item of a cluster in All feedback.</summary>
    public Task RequestClusterAsync(FeedbackClusterKey cluster)
    {
        Close();

        return InvokeAllAsync(OnClusterRequested, handler => handler(cluster));
    }

    public Task NotifyDeletedAsync(int id)
    {
        Close();

        return InvokeAllAsync(OnDeleted, handler => handler(id));
    }

    /// <summary>Awaits each subscriber in turn; a plain event invocation would only await the last one.</summary>
    private static async Task InvokeAllAsync<THandler>(THandler? handlers, Func<THandler, Task> invoke) where THandler : Delegate
    {
        if (handlers is null) return;

        foreach (var handler in handlers.GetInvocationList().Cast<THandler>())
        {
            await invoke(handler);
        }
    }
}
