using CleanArchitecture.Core.Application.Services.WeatherForecast.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.WebUI.Controllers;

public class WeatherForecastController : ApiControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<WeatherForecastDto>> Get()
    {
        return await Mediator.Send(new GetWeatherForecastQuery());
    }
}