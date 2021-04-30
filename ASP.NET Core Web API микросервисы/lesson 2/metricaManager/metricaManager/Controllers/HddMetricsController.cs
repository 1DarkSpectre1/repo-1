using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace metricaManager.Controllers
{
    [Route("api/metrics/hdd")]
    [ApiController]
    public class HddMetricsController : ControllerBase
    {
        [HttpGet("left/{remainingMemory}")]
        public IActionResult GetMetricsFromAgent([FromRoute] int remainingMemory)
        {
            return Ok();
        }
    }
}
