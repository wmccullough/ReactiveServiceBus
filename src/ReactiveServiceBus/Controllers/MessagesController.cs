using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactiveServiceBus.Controllers
{
    [Route("v1/api/messages")]
    public class MessagesController : Controller
    {
        public MessagesController(QueueManager queueManager)
        {
            QueueManager = queueManager;
        }

        protected QueueManager QueueManager { get; private set; }

        [HttpGet("{topic}")]
        public async Task<string> GetMessage(string topic)
        {
            try
            {
                return await QueueManager.DeQueue(topic);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost("{topic}")]
        public async Task PostMessage(string topic, [FromBody]JObject json)
        {
            try
            {
                await QueueManager.Enqueue(topic, json.ToString());
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
