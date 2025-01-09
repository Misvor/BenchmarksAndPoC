using Microsoft.AspNetCore.Mvc;

namespace LightweightApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        //private readonly IGitHubApi _api;
        
        private int countCalled = 0;
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("Nothing")]
        public long GetNothing()
        {
            Task.Delay(1500);
            return DateTimeOffset.Now.ToUnixTimeSeconds();
        }
        [HttpGet("Something")]
        public long GetSomething()
        {
            //var result = _api.GetUser(string.Empty);
            return 1;
        }
        
        [HttpPost("LargeString")]
        public long GetSomething([FromBody]string largeObject)
        {
           // var result = _api.GetUser(string.Empty);
            return largeObject.Length;
            return 1;
        }
    }
}