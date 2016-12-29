using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactiveServiceBus.Controllers.V1
{
    [Route("v1/api/[controller]")]
    public class MessagesController : Controller
    {
        public MessagesController(IServiceBus serviceBus)
        {
            ServiceBus = serviceBus;
        }

        protected IServiceBus ServiceBus { get; private set; }

        [HttpPost("{publisher}/topic")]
        public async Task Post(string publisher, string topic, [FromBody]JObject message)
        {
            await ServiceBus.Publish(publisher, topic, message.ToString());
        }
    }
}
