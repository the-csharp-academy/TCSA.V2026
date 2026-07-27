using System.Collections.Concurrent;
using TCSA.V2026.Data.Events;

namespace TCSA.V2026.Services;

public interface IPeerReviewPublisher
{
    Guid Subscribe(Func<ReviewCompletedEvent, Task> handler);
    void Unsubscribe(Guid subscriptionId);
    Task Publish(ReviewCompletedEvent @event);
}

public class PeerReviewPublisher : IPeerReviewPublisher
{
    private readonly ConcurrentDictionary<Guid, Func<ReviewCompletedEvent, Task>> _subscribers = new();
    private readonly ILogger<PeerReviewPublisher> _logger;

    public PeerReviewPublisher(ILogger<PeerReviewPublisher> logger)
    {
        _logger = logger;
    }

    public Guid Subscribe(Func<ReviewCompletedEvent, Task> handler)
    {
        var id = Guid.NewGuid();
        _subscribers[id] = handler;
        return id;
    }

    public void Unsubscribe(Guid subscriptionId)
        => _subscribers.TryRemove(subscriptionId, out _);

    public async Task Publish(ReviewCompletedEvent @event)
    {
        foreach (var handler in _subscribers.Values)
        {
            try
            {
                await handler(@event);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while publishing the review completed event for reviewer {ReviewerId}", @event.ReviewerId);
            }
        }
    }
}
