using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReactiveServiceBus.Controllers.V1
{
    [Route("v1/api/[controller]")]
    public class QueuesController : Controller
    {
        public QueuesController(QueueManager queueManager)
        {
            QueueManager = queueManager;
        }

        protected QueueManager QueueManager { get; private set; }

        [HttpGet("{topic}")]
        public async Task<string> Get(string topic)
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
        public async Task Post(string topic, [FromBody]JObject json)
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
