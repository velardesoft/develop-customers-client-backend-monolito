using Cortex.Mediator.Notifications;
using u20211c221.Shared.Domain.Model.Events;

namespace u20211c221.Shared.Application.Internal.EventHandlers;

public interface IEventHandler<in TEvent> : INotificationHandler<TEvent> where TEvent : IEvent
{
    
}