using AutoMapper;
using Weather.Data.Dto;
using Weather.Data.Resolvers;
using Weather.Data.View;

namespace Weather.Data.Profiles
{
    public class WeatherProfile : Profile
    {
        public WeatherProfile()
        {
            CreateMap<WeatherViewModel, WeatherDto>()
              .ForMember(x => x.WeatherServiceUrl, x => x.MapFrom<WeatherUrlResolver>())
              .ReverseMap();
        }
    }
}