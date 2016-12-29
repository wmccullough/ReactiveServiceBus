using ReactiveServiceBus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactiveServiceBus
{
    public interface IServiceBus
    {
        IObservable<ServiceBusMessage> MessagePublished { get; }
        Task Publish(string publisher, string topic, string message);
    }
}
