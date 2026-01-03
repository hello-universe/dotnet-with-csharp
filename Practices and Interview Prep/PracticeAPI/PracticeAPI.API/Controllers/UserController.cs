using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticeAPI.API.Models;
using EnvironmentName = Microsoft.AspNetCore.Hosting.EnvironmentName;

namespace PracticeAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private List<User> _users = new List<User>()
        {
            new User() { Name = "Amit", Email = "amit@sample.com" },
            new User() { Name = "John", Email = "john@sample.com" }
        };
        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
            // _logger.LogTrace("User Controller started.."); // This will not be logged because default log level is information
            _logger.LogInformation("User Controller started..");
        }

        [HttpGet]
        public List<User> Get()
        {
            _logger.LogInformation("Executing UserController.Get Method");
            return _users;
        }
    }
}
