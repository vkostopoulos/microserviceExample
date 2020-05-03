using BOL;
using JWTMicroService.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace JWTMicroNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]User user)
        {
            string token = await _authenticationService.Login(user);
            if (string.IsNullOrEmpty(token))
            {
                return BadRequest("Could not authenticate user.");
            }
            return Ok(token);
        }

        [HttpGet("verify")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> VerifyToken()
        {
            bool itsOK = await _authenticationService.VerifyToken(User.Claims.SingleOrDefault());
            if (!itsOK)
            {
                return Unauthorized();
            }

            return NoContent();
        }
    }
}