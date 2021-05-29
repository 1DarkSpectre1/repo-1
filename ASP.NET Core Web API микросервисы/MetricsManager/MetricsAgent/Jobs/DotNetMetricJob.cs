using System.Threading.Tasks;
using Quartz;
using MetricsAgent.DAL;
using System.Diagnostics;
using System;

namespace MetricsAgent.Jobs
{
    public class DotNetMetricJob : IJob
    {
        private IDotNetMetricsRepository _repository;
        private PerformanceCounter _dotNetCounter;

        public DotNetMetricJob(IDotNetMetricsRepository repository)
        {
            _repository = repository;
            _dotNetCounter = new PerformanceCounter(".NET CLR Memory", "# Bytes in all Heaps", "_Global_");
        }

        public Task Execute(IJobExecutionContext context)
        {
            var dotNetUsageInPercents = Convert.ToInt32(_dotNetCounter.NextValue());

            // узнаем когда мы сняли значение метрики.
            var time = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            _repository.Create(new Entities.DotNetMetric { Time = time, Value = dotNetUsageInPercents });

            return Task.CompletedTask;
        }
    }
}