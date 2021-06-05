using System.Threading.Tasks;
using Quartz;
using MetricsAgent.DAL;
using System.Diagnostics;
using System;

namespace MetricsAgent.Jobs
{
    public class RamMetricJob : IJob
    {
        private IRamMetricsRepository _repository;
        private PerformanceCounter _ramCounter;

        public RamMetricJob(IRamMetricsRepository repository)
        {
            _repository = repository;
            _ramCounter = new PerformanceCounter("Memory", "Available MBytes");
        }

        public Task Execute(IJobExecutionContext context)
        {
            // получаем значение занятости Ram
            var ramUsageInPercents = Convert.ToInt32(_ramCounter.NextValue());

            // узнаем когда мы сняли значение метрики.
            var time = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            _repository.Create(new Entities.RamMetric { Time = time, Value = ramUsageInPercents });

            return Task.CompletedTask;
        }
    }
}