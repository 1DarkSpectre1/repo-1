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
            CreateMap<CpuMetric, MetricDto>()
                .ForMember(d => d.Time, opt => opt.ConvertUsing(new DateTimeOffsetFormatter(), src => src.Time));
            CreateMap<DotNetMetric, MetricDto>()
                .ForMember(d => d.Time, opt => opt.ConvertUsing(new DateTimeOffsetFormatter(), src => src.Time));
            CreateMap<HddMetric, MetricDto>()
                .ForMember(d => d.Time, opt => opt.ConvertUsing(new DateTimeOffsetFormatter(), src => src.Time));
            CreateMap<NetworkMetric, MetricDto>()
                .ForMember(d => d.Time, opt => opt.ConvertUsing(new DateTimeOffsetFormatter(), src => src.Time));
            CreateMap<RamMetric, MetricDto>()
                .ForMember(d => d.Time, opt => opt.ConvertUsing(new DateTimeOffsetFormatter(), src => src.Time));

        }

        public static IMapper GetMapper()
        {
            var mapperConfiguration = new MapperConfiguration(mp => mp.AddProfile(new MapperProfile()));
            return mapperConfiguration.CreateMapper();
        }

        public class DateTimeOffsetFormatter : IValueConverter<long, DateTimeOffset>
        {
            public DateTimeOffset Convert(long sourceMember, ResolutionContext context) => DateTimeOffset.FromUnixTimeSeconds(sourceMember);
        }

        public class LongFormatter : IValueConverter<DateTimeOffset, long>
        {
            public long Convert(DateTimeOffset sourceMember, ResolutionContext context) => sourceMember.ToUnixTimeSeconds();
        }
    }
}
