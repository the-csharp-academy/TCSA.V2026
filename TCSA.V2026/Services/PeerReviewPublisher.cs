using System.Collections.Concurrent;
using TCSA.V2026.Data.Events;

namespace TCSA.V2026.Services;

public interface IPeerReviewPublisher
{
    void Subscribe(string userId, Func<ReviewCompletedEvent, Task> handler);
    void Unsubscribe(string userId);
    Task Publish(ReviewCompletedEvent @event);
}

public class PeerReviewPublisher : IPeerReviewPublisher
{
    private readonly ConcurrentDictionary<string, Func<ReviewCompletedEvent, Task>> _subscribers = new();
    private readonly ILogger<PeerReviewPublisher> _logger;

    public PeerReviewPublisher(ILogger<PeerReviewPublisher> logger)
    {
        _logger = logger;
    }

    public void Subscribe(string userId, Func<ReviewCompletedEvent, Task> handler)
        => _subscribers[userId] = handler;

    public void Unsubscribe(string userId)
        => _subscribers.TryRemove(userId, out _);

    public async Task Publish(ReviewCompletedEvent @event)
    {
        if (_subscribers.TryGetValue(@event.ReviewerId, out var handler))
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
