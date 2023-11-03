namespace PhotoGallery_BackEnd.Controllers.Test
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }
        //[HttpGet(Name = "GetWeatherForecast"), Authorize(Roles = "superadmin,admin,user")]

        [HttpGet(Name = "GetWeatherForecast")]
        public ActionResult<ServiceResponse<List<WeatherForecast>>> Get()
        {
            ServiceResponse<List<WeatherForecast>> response = new ServiceResponse<List<WeatherForecast>>();
            response.Data = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToList();
            response.Success = true;
            response.Message = "Server ok :D";
            _logger.LogInformation("User GetWeatherForecast.");
            return Ok(response); // Return the response object
        }
    }
}
