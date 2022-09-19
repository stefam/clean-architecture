using CleanArchitecture.Core.Application.Services.WeatherForecast.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.WebUI.Controllers;

public class WeatherForecastController : ApiControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<WeatherForecast>> Get()
    {
        return await Mediator.Send(new GetWeatherForecastQuery());
    }
}