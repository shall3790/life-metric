using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetricApi.Models;
using MetricApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace MetricApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetricsController : ControllerBase
    {
        private readonly IMetricService _metricService;

        public MetricsController(IMetricService metricService) {
            this._metricService = metricService;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var foo = this._metricService.Get();
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        [Route("groups")]
        public IEnumerable<MetricGroup> GetMetricGroups()
        {
        // public ActionResult<IEnumerable<Metricgroup>> GetGroups() {
            var groups = this._metricService.GetGroups();
            return groups;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
