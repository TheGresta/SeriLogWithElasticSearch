using Microsoft.AspNetCore.Mvc;
using Serilog;
using ILogger = Serilog.ILogger;

namespace WebAPI.Services
{
    public class WeatherService
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger _logger;

        public WeatherService(ILogger logger)
        {
            _logger = logger;
        }

        public async Task<IEnumerable<WeatherForecast>> GetWeatherForCityAsync(string city, int days)
        {
            await Task.Delay(Random.Shared.Next(1, 15));

            try
            {
                Random rng = new ();

                int num = rng.Next(0, 5);

                if (num < 4)
                    throw new Exception($"Opps! Error code -> {num}");
            }
            catch(Exception ex){

                _logger.Error(ex, "Something bad happen {CustomProperty}", 50);
            }

            return Enumerable.Range(1, days).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToArray();
        }
    }
}
