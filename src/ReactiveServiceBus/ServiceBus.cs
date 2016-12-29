using ReactiveServiceBus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;

namespace ReactiveServiceBus
{
    public class ServiceBus : IServiceBus
    {

        private Subject<ServiceBusMessage> _messagePublished = new Subject<ServiceBusMessage>();

        public IObservable<ServiceBusMessage> MessagePublished
        {
            get => _messagePublished.AsObservable();
        }

        public async Task Publish(string publisher, string topic, string message)
        {
            await Task.Factory.StartNew(() => { _messagePublished.OnNext(new ServiceBusMessage(publisher, topic, message)); });
        }
    }
}
