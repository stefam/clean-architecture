using MediatR;

namespace CleanArchitecture.Core.Application.Services.WeatherForecast.Queries;

public record GetWeatherForecastQuery : IRequest<IEnumerable<WeatherForecast>>;

public class GetWeatherForecastQueryHandler : RequestHandler<GetWeatherForecastQuery, IEnumerable<WeatherForecast>>
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    protected override IEnumerable<WeatherForecast> Handle(GetWeatherForecastQuery request)
    {
        var rng = new Random();

        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = rng.Next(-20, 55),
            Summary = Summaries[rng.Next(Summaries.Length)]
        });
    }
}