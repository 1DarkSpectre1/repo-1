using System.Threading.Tasks;
using Quartz;
using MetricsAgent.DAL;
using System.Diagnostics;
using System;

namespace MetricsAgent.Jobs
{
    public class NetworkMetricJob : IJob
    {
        private INetworkMetricsRepository _repository;
        private PerformanceCounter _networkCounter;

        public NetworkMetricJob(INetworkMetricsRepository repository)
        {
            _repository = repository;
            _networkCounter = new PerformanceCounter("Network Interface", "Bytes Total/sec", "Intel[R] Ethernet Connection [2] I219-LM");
        }

        public Task Execute(IJobExecutionContext context)
        {
            // получаем значение занятости Network
            var networkUsageInPercents = Convert.ToInt32(_networkCounter.NextValue());

            // узнаем когда мы сняли значение метрики.
            var time = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            _repository.Create(new Entities.NetworkMetric { Time = time, Value = networkUsageInPercents });

            return Task.CompletedTask;
        }
    }
}