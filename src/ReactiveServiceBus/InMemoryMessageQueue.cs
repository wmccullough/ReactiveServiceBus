using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactiveServiceBus
{
    public class InMemoryMessageQueue : IMessageQueue
    {
        public InMemoryMessageQueue()
        {
            _queue = new ConcurrentQueue<string>();
        }

        private ConcurrentQueue<string> _queue;

        public async Task<string> DeQueue()
        {
            var result = await Task.Factory.StartNew<string>(() =>
            {
                if (_queue.TryDequeue(out string message))
                {
                    return message;
                }
                else
                {
                    return string.Empty;
                }
            });

            return result;
        }

        public async Task Enqueue(string json)
        {
            await Task.Factory.StartNew(() =>
            {
                _queue.Enqueue(json);
            });
        }
    }
}
