using MetricsAgent.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetricsAgent.Responses;

namespace MetricsAgent
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CpuMetric, MetricDto>();   
            CreateMap<DotNetMetric, MetricDto>();
            CreateMap<HddMetric, MetricDto>();
            CreateMap<RamMetric, MetricDto>();
            CreateMap<NetworkMetric, MetricDto>();
        }
    }
}
