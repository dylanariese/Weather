using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using Weather.Data.Dto;
using Weather.Data.Interfaces;
using Weather.Services;

namespace Weather.Tests
{
    [TestFixture]
    public class Tests
    {
        private WeatherDto dto;
        private Mock<IHttpClient> client;

        [OneTimeSetUp]
        public void Setup()
        {
            client = new Mock<IHttpClient>();

            dto = new WeatherDto
            {
                Latitude = 5m,
                Longitude = 10m,
                TimeStamp = new DateTime(2017, 8, 22),
                WeatherServiceUrl = string.Empty
            };

            client.Setup(x => x.GetAsync(string.Empty))
                   .Returns(async () => await Task.FromResult(JsonConvert.SerializeObject(dto)));
        }

        [Test]
        public async Task Get_WeatherInfo_ReturnsWeatherDto()
        {
            var service = new Mock<WeatherService>(client.Object);

            var response = await service.Object.GetAsync(dto);

            Assert.AreEqual(5m, response.Latitude);
            Assert.AreEqual(10m, response.Longitude);
            Assert.AreEqual(new DateTime(2017, 8, 22), response.TimeStamp);
        }
    }
}