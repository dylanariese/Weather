using FluentValidation;
using System;
using Weather.Data.View;

namespace Weather.Data.Validators
{
    public class WeatherViewModelValidator : AbstractValidator<WeatherViewModel>
    {
        public WeatherViewModelValidator()
        {            
            RuleFor(x => x.Latitude)
                .Must(latitude => { return !string.IsNullOrEmpty(latitude); })
                .Must(latitude => { decimal.TryParse(latitude, out decimal parsedLatitude); return parsedLatitude > -90 && parsedLatitude < 90; })
                .WithMessage(x => $"Latitude is: { x.Latitude }, but has to bigger than -90 and smaller than 90");

            RuleFor(x => x.Longitude)
                .Must(longitude => { return !string.IsNullOrEmpty(longitude); })
                .Must(longitude => { decimal.TryParse(longitude, out decimal parsedLongitude); return parsedLongitude > -180 && parsedLongitude < 180; })
                .WithMessage(x => $"Longitude is: { x.Longitude }, but has to bigger than -180 and smaller than 180");

            RuleFor(x => x.TimeStamp)
                .Must(timestamp => { return timestamp > default(DateTime); })
                .WithMessage(x => $"Timestamp is: { x.TimeStamp }, but has to bigger than the default value");

            //the rest ...
        }
    }
}