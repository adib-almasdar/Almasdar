using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        // GET: api/<TestController>
        [HttpGet("GetEnvironementVariable")]
        public IActionResult GetEnvironementVariable()
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
                  ?? "Development";

            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: false)
                .Build();
            var env = configuration["Environment"];
            return Ok(configuration["Environment"]);
        }
        [HttpGet("GetUserDetails")]
        public IActionResult GetUserDetails()
        {
            return Ok(new
            {
                Name = "Vineet Kumar",
                EmailId = "Vineet.kumar@abc.com",
                PhoneNo = "1234567890",
                Country = "India",
                City = "Hyderabad",
            });
        }
    }
}
