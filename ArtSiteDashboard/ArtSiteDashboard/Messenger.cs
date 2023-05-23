using System.Collections.Generic;

namespace ArtSiteDashboard; 

public class Messenger : IMessenger {
    private List<ISubscriber> _subscriber = new();

    public void AddSubscriber(ISubscriber subscriber) {
        _subscriber.Add(subscriber);
    }

    public void NotifySubscriber(object data) {
        foreach (var subscriber in _subscriber) {
            subscriber.Notify(data);
        }
    }
}

public interface ISubscriber {
    void Notify(object data);
}

public interface IMessenger {
    void AddSubscriber(ISubscriber subscriber);
    void NotifySubscriber(object data);
}
