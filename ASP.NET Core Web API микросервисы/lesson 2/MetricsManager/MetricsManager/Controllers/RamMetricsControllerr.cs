using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace metricaManager.Controllers
{
    [Route("api/metrics/ram")]
    [ApiController]
    public class RamMetricsControllerr : ControllerBase
    {
        [HttpGet("available/{freeMemory}")]
        public IActionResult GetMetricsFromAgent([FromRoute] int freeMemory)
        {
            return Ok();
        }
    }
}
