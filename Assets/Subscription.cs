using System;


public class Subscription<TEvent> : ISubscription<IEvent>
{
    private readonly Action<TEvent> _action;
    public object SubscriptionToken
    {
        get { return _action; }
    }
    public Subscription(Action<TEvent> action)
    {
        if (action == null)
            throw new ArgumentNullException("action");

        _action = action;
    }


    public void Publish(IEvent eventItem)
    {
        if (!(eventItem is TEvent))
        {
            throw new ArgumentException("Incorrect event type");
        }

        _action.Invoke((TEvent)eventItem);
    }
}



