using MediatR;

namespace CleanArchitecture.Core.Application.Services.WeatherForecast.Queries;

public record GetWeatherForecastQuery : IRequest<IEnumerable<WeatherForecastDto>>;

public class GetWeatherForecastQueryHandler : RequestHandler<GetWeatherForecastQuery, IEnumerable<WeatherForecastDto>>
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    protected override IEnumerable<WeatherForecastDto> Handle(GetWeatherForecastQuery request)
    {
        var rng = new Random();

        return Enumerable.Range(1, 5).Select(index => new WeatherForecastDto
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = rng.Next(-20, 55),
            Summary = Summaries[rng.Next(Summaries.Length)]
        });
    }
}