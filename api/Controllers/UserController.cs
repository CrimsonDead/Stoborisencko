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

        [HttpGet("getAll", Name = "GetUsers")]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            try
            {
                List<User> comments = _signInManager.UserManager.Users.ToList();
                if (comments.Count == 0)
                {
                    _logger.LogInformation("User list is clear");
                    return Ok(comments);
                }
                else if (comments == null)
                {
                    _logger.LogInformation("User list is null");
                    return Ok(comments);
                }
                _logger.LogInformation("User list is successfully receive");
                return Ok(comments);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get User list");
                return BadRequest(ex);
            }
        }

        [HttpGet("getById", Name = "User")]
        public ActionResult<User> GetUserById([FromForm] string id)
        {
            try
            {
                User user = _signInManager.UserManager.Users.FirstOrDefault(u => u.Id == id);
                if (user == null)
                {
                    _logger.LogInformation("User item is null");
                    return Ok(user);
                }
                _logger.LogInformation("User is successfully receive");
                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get User");
                return BadRequest(ex);
            }
        }

        [HttpPost("register", Name = "RegisterUser")]
        public async Task<ActionResult> CreateUserAsync([FromForm] User user, [FromForm] string password)
        {
            try
            {
                var result = await _signInManager.UserManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, true);
                    _logger.LogInformation("User successfully registered");
                    return Ok();
                }
                else
                {
                    List<string> errors = new List<string>();
                    _logger.LogError("Failed to register user");
                    foreach (var error in result.Errors)
                    {
                        _logger.LogError(error.Description);
                        errors.Add(error.Description);
                    }
                    return BadRequest(errors);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to register user");
                return BadRequest(ex);
            }
        }

        [HttpPost("login", Name = "LoginUser")]
        public async Task<ActionResult> LoginUserAsync([FromForm] string userName, [FromForm] string password)
        {
            try
            {
                var result = await _signInManager.PasswordSignInAsync(userName, password, true, false);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User successfully login");
                    return Ok();
                }
                else
                {
                    return BadRequest("Invalid username or password");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to login user");
                return BadRequest(ex);
            }
        }

        [HttpPost("logout", Name = "Logout")]
        public async Task<ActionResult> LogoutUser()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logout");
            return Ok();
        }

        [HttpPut("change", Name = "ChangeUser")]
        public async Task<ActionResult> UpdateUserAsync([FromForm] User newUser)
        {
            try
            {
                var targetUser = _signInManager.UserManager.Users.FirstOrDefault(u => u.Id == newUser.Id);
                targetUser.UserName = newUser.UserName;
                targetUser.Email = newUser.Email;
                targetUser.PhoneNumber = newUser.PhoneNumber;
                var result = await _signInManager.UserManager.UpdateAsync(targetUser);
                if (!result.Succeeded)
                {
                    _logger.LogInformation("Failed to update user");
                    foreach (var error in result.Errors)
                        _logger.LogInformation(error.Description);
                    return BadRequest(result.Errors);
                }
                _logger.LogInformation("Comment is successfully change");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to update User");
                return BadRequest(ex);
            }
        }

        [HttpDelete("delete", Name = "DeleteUser")]
        public async Task<ActionResult> DeleteUserAsync([FromForm] string id)
        {
            try
            {
                var targetUser = _signInManager.UserManager.Users.FirstOrDefault(u => u.Id == id);
                var result = await _signInManager.UserManager.DeleteAsync(targetUser);
                if (!result.Succeeded)
                {
                    _logger.LogInformation("Failed to delete user");
                    foreach (var error in result.Errors)
                        _logger.LogInformation(error.Description);
                    return BadRequest(result.Errors);
                }
                _logger.LogInformation("User is successfully delete");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to delete User");
                return BadRequest(ex);
            }
        }

    }
}