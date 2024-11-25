using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;
using TestEMI.Application.DTO_s;
using TestEMI.Application.IServices;

namespace TestEMI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtTokenFactory _jwtTokenFactory;

        public AuthenticationController(IJwtTokenFactory jwtTokenFactory, IUserService userService)
        {
            _jwtTokenFactory = jwtTokenFactory;
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUser request)
        {
            request.Password = Convert.ToBase64String(
            System.Security.Cryptography.SHA256.Create().ComputeHash(
                Encoding.UTF8.GetBytes(request.Password)));

            await _userService.CreateUser(request);
            return Ok(new { Message = "User registered successfully." });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthRequest request)
        {
            var user = await _userService.GetUserByUserName(request.Username);

            if (user == null)
            {
                return Unauthorized(new { Message = "Invalid username." });
            }

            var passwordHash = Convert.ToBase64String(
            System.Security.Cryptography.SHA256.Create().ComputeHash(
                Encoding.UTF8.GetBytes(request.Password)));

            if (user.Password != passwordHash)
            {
                return Unauthorized(new { Message = "Invalid password." });
            }

            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, user.Username),
                new(ClaimTypes.Role, user.Role)
            };

            var token = _jwtTokenFactory.GenerateToken(user.Username, claims);

            return Ok(new { Token = token });
        }
    }
}
