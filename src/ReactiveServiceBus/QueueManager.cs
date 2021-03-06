﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;

namespace ReactiveServiceBus
{
    public class QueueManager
    {
        public QueueManager()
        {
            _queues = new Dictionary<string, IMessageQueue>();
        }

        private Dictionary<string, IMessageQueue> _queues;
        private Subject<KeyValuePair<string, string>> _messageEnqueued = new Subject<KeyValuePair<string, string>>();

        public IObservable<KeyValuePair<string, string>> MessageEnqueued
        {
            get => _messageEnqueued.AsObservable();
        }

        public async Task Enqueue(string topic, string message)
        {
            if (_queues.ContainsKey(topic) && _queues[topic] == null)
            {
                _queues[topic] = new InMemoryMessageQueue();
            }
            else if (!_queues.ContainsKey(topic))
            {
                _queues.Add(topic, new InMemoryMessageQueue());
            }

            await _queues[topic].Enqueue(message);
            _messageEnqueued.OnNext(new KeyValuePair<string, string>(topic, message));
        }

        public async Task<string> DeQueue(string topic)
        {
            var result = (_queues.ContainsKey(topic)) ? await _queues[topic].DeQueue() : throw new InvalidOperationException("Topic not found in queues");
            return result;
        }
    }
}
