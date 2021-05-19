using AutoMapper;
using MetricsAgent.DAL;
using MetricsAgent.Entities;
using MetricsAgent.Requests;
using MetricsAgent.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Controllers
{
    [Route("api/metrics/hdd")]
    [ApiController]
    public class HddMetricsAgentController : ControllerBase
    {
        private readonly ILogger<HddMetricsAgentController> _logger;

        private IHddMetricsRepository _repository;

        private readonly IMapper _mapper;

        public HddMetricsAgentController(IMapper mapper, ILogger<HddMetricsAgentController> logger, IHddMetricsRepository repository)
        {
            _mapper = mapper;
            _logger = logger;
            _repository = repository;
            _logger.LogDebug(1, "NLog встроен в HddMetricsAgentController");
        }
        [HttpPost("create")]
        public IActionResult Create([FromBody] MetricCreateRequest request)
        {
            _repository.Create(new HddMetric
            {
                Time = request.Time,
                Value = request.Value
            });

            return Ok();
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var metrics = _repository.GetAll();

            var response = new MetricsResponse()
            {
                Metrics = new List<MetricDto>()
            };

            foreach (var metric in metrics)
            {
                response.Metrics.Add(_mapper.Map<MetricDto>(metric));
            }

            return Ok(response);
        }

        [HttpGet("from")]
        public IActionResult GetMetricsFromAgent([FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime)
        {
            _logger.LogInformation("Запущен GetMetricsFromAgent в HddMetricsAgentController.В него были переданы параметры fromTime:{0} и toTime:{1}", fromTime, toTime);
            var metrics = _repository.GetAll();

            var response = new MetricsResponse()
            {
                Metrics = new List<MetricDto>()
            };

            foreach (var metric in metrics)
            {
                response.Metrics.Add(_mapper.Map<MetricDto>(metric));
            }
            return Ok(response);
        }
        [HttpGet("left")]
        public IActionResult GetMetricsFromAgent()
        {
            _logger.LogInformation("Запущен GetMetricsFromAgent в HddMetricsAgentController.");
            return Ok();
        }
    }
}
