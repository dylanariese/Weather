using AutoMapper;
using Microsoft.Extensions.Configuration;
using Weather.Data.Dto;
using Weather.Data.View;

namespace Weather.Data.Resolvers
{
    public class WeatherUrlResolver : IValueResolver<WeatherViewModel, WeatherDto, string>
    {
        private readonly string url;
        private readonly string key;


        public WeatherUrlResolver(IConfiguration configuration)
        {
            url = configuration["Weather:BaseUrl"];
            key = configuration["Weather:ApiKey"];
        }

        public string Resolve(WeatherViewModel source, WeatherDto target, string destMember, ResolutionContext context)
        {
            return $"{url}{source.Latitude}," +
                   $"{source.Longitude}/{source.TimeStamp:s}Z.json?appid={key}";
        }
    }
}
