using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Controllers
{
    [Route("api/metrics/ram")]
    [ApiController]
    public class RamMetricsControllerr : ControllerBase
    {
        [HttpGet("agent/{agentId}/available")]
        public IActionResult GetMetricsFromAgent()
        {
            return Ok();
        }
    }
}
