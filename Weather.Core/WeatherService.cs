using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using Weather.Data.Dto;
using Weather.Data.Interfaces;

namespace Weather.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IHttpClient client;

        public WeatherService(IHttpClient client)
        {
            this.client = client;
        }

        public async Task<WeatherDto> GetAsync(WeatherDto dto)
        {
            var content = await client.GetAsync(dto.WeatherServiceUrl);

            var deserialized = JsonConvert.DeserializeObject<WeatherDto>(content);

            return deserialized;
        }

        public async Task PostAsync(WeatherDto dto)
        {
            var content = JsonConvert.SerializeObject(dto);

            await client.PostAsync(dto.WeatherServiceUrl, new StringContent(content));
        }
    }
}