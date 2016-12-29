using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactiveServiceBus
{
    public class SubscriptionManager
    {
        public SubscriptionManager()
        {
            _subscribers = new Dictionary<string, List<string>>();
        }

        private Dictionary<string, List<string>> _subscribers;

        public void Subscribe(string topic, string callbackUri)
        {
            if (!_subscribers.ContainsKey(topic))
            {
                _subscribers[topic] = new List<string>();
            }

            if (!_subscribers[topic].Contains(callbackUri))
            {
                _subscribers[topic].Add(callbackUri);
            }
        }

        public void Unsubscribe(string topic, string callbackUri)
        {
            if (_subscribers.ContainsKey(topic) && _subscribers[topic].Contains(callbackUri))
            {
                _subscribers[topic].Remove(callbackUri);
            }
        }

        public void BroadcastMessage(string topic)
        {
            foreach (var keyValuePair in _subscribers.Where(s => s.Key.Equals(topic)))
            {
                //TODO: Do broadcast here
            }
        }
    }
}
