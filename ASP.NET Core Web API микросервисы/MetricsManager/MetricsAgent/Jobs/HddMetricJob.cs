using System.Threading.Tasks;
using Quartz;
using MetricsAgent.DAL;
using System.Diagnostics;
using System;

namespace MetricsAgent.Jobs
{
    public class HddMetricJob : IJob
    {
        private IHddMetricsRepository _repository;
        private PerformanceCounter _hddCounter;

        public HddMetricJob(IHddMetricsRepository repository)
        {
            _repository = repository;
            _hddCounter = new PerformanceCounter("PhysicalDisk", "Disk Bytes/sec", "_Total");
        }

        public Task Execute(IJobExecutionContext context)
        {
            // получаем значение занятости Hdd
            var hddUsageInPercents = Convert.ToInt32(_hddCounter.NextValue());

            // узнаем когда мы сняли значение метрики.
            var time = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            _repository.Create(new Entities.HddMetric { Time = time, Value = hddUsageInPercents });

            return Task.CompletedTask;
        }
    }
}