using FoodCourt.DTO;
using FoodCourt.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace OnlineFoodDeliveryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthoController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthoController(IUserService userService)
        {
            _userService = userService;
        }

        // POST: api/autho/register
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var registeredUser = await _userService.RegisterAsync(model);
                return Ok(registeredUser);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // POST: api/autho/login
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO loginModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Authenticate user
            var user = await _userService.AuthenticateAsync(loginModel.Email, loginModel.Password);
            if (user == null)
            {
                return Unauthorized(new { message = "Invalid credentials" });
            }

            // Generate JWT Token
            var token = _userService.GenerateToken(user);
            return Ok(new { token });
        }
    }
}
