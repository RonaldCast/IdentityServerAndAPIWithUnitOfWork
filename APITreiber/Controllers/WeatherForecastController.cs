
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace APITreiber.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]

   [Route("api/v{version:apiVersion}/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

     
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            return Ok("Hello");
        }
    }
}