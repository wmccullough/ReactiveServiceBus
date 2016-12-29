using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactiveServiceBus.Models
{
    public class ServiceBusMessage
    {
        public ServiceBusMessage(string publisher, string topic, string message)
        {
            Publisher = publisher;
            Topic = topic;
            Message = message;
        }

        public string Publisher { get; set; }
        public string Topic { get; set; }
        public string Message { get; set; }
    }
}
