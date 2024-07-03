using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthController : Controller
    {
        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult GetHealth()
        {
            var healthStatus = new
            {
                status = "Healthy",
                message = "API is running"
            };

            return Ok(healthStatus);
        }
    }
}
