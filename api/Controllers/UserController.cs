using datalayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly SignInManager<User> _signInManager;
        public UserController(ILogger<UserController> logger, SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
            _logger = logger;

        }
    }
}