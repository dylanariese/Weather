using System.Threading.Tasks;
using Weather.Data.Dto;

namespace Weather.Data.Interfaces
{
    public interface IWeatherService
    {
        Task<WeatherDto> GetAsync(WeatherDto model);

        Task PostAsync(WeatherDto model);
    }
}
