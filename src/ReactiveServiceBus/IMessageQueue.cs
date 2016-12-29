using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactiveServiceBus
{
    public interface IMessageQueue
    {
        Task Enqueue(string json);
        Task<string> DeQueue();
    }
}
