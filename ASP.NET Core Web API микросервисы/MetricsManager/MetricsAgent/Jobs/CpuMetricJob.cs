using System.Threading.Tasks;
using Quartz;
using MetricsAgent.DAL;
using System.Diagnostics;
using System;

namespace MetricsAgent.Jobs
{
    public class CpuMetricJob : IJob
    {
        private ICpuMetricsRepository _repository;
        private PerformanceCounter _cpuCounter;

        public CpuMetricJob(ICpuMetricsRepository repository)
        {
            _repository = repository;
            _cpuCounter = new PerformanceCounter("Processor Information", "% Processor Time", "_Total");
        }

        public Task Execute(IJobExecutionContext context)
        {
            // получаем значение занятости CPU
            var cpuUsageInPercents = Convert.ToInt32(_cpuCounter.NextValue());

            // узнаем когда мы сняли значение метрики.
            var time = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            _repository.Create(new Entities.CpuMetric { Time = time, Value = cpuUsageInPercents });

            return Task.CompletedTask;
        }
    }
}