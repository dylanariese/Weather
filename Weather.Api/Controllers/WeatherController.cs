using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Weather.Data.Dto;
using Weather.Data.Interfaces;
using Weather.Data.View;

namespace Weather.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWeatherService weatherService;
        private readonly IValidator<WeatherViewModel> validator;

        public WeatherController(IMapper mapper, IWeatherService weatherService, IValidator<WeatherViewModel> validator)
        {
            this.mapper = mapper;
            this.weatherService = weatherService;
            this.validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] WeatherViewModel model)
        {
            var validated = await validator.ValidateAsync(model);

            if (!(validated.IsValid))
            {
                return BadRequest(string.Join(";", validated.Errors.Select(x => x.ErrorMessage)));
            }

            var dto = mapper.Map<WeatherDto>(model);

            var response = await weatherService.GetAsync(dto);

            var responseDto = mapper.Map<WeatherViewModel>(response);

            return Ok(responseDto);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] WeatherViewModel model)
        {
            var validated = await validator.ValidateAsync(model);

            if (!(validated.IsValid))
            {
                return BadRequest(string.Join(";", validated.Errors.Select(x => x.ErrorMessage)));
            }

            var dto = mapper.Map<WeatherDto>(model);

            await weatherService.PostAsync(dto);

            return Ok();
        }
    }
}
