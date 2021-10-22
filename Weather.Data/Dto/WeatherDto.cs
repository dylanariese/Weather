using System;

namespace Weather.Data.Dto
{
    public class WeatherDto
    {
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public DateTime TimeStamp { get; set; }
        public string WeatherServiceUrl { get; set; }
    }
}
