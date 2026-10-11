using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();

app.UseRouting();
app.MapControllers();

app.Run();

[ApiController]
[Route("weather")]
public class WeatherController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Сонячно", "Хмарно", "Дощ", "Мряка", "Сніг", "Вітряно", "Спекотно"
    };

    [HttpGet("today")]
    public IActionResult GetTodayWeather()
    {
        var rng = new Random();
        var weather = new
        {
            Date = DateTime.Now.ToShortDateString(),
            TemperatureC = rng.Next(-10, 35),
            Summary = Summaries[rng.Next(Summaries.Length)]
        };

        return Ok(weather);
    }

    [HttpGet("{city}")]
    public IActionResult GetCityWeather(string city)
    {
        var rng = new Random();
        var weather = new
        {
            City = city,
            Date = DateTime.Now.ToShortDateString(),
            TemperatureC = rng.Next(-10, 35),
            Summary = Summaries[rng.Next(Summaries.Length)]
        };

        return Ok(weather);
    }
}
