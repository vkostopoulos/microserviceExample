using BOL;
using DAL;
using DAL.Repository;
using Helpers;
using JWTMicroNetCore.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace JWTMicroNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IRepository<User> _userRepository;
        private readonly ITokenBuilder _tokenBuilder;

        public AuthenticationController(IRepository<User> userRepository, ITokenBuilder tokenBuilder)
        {
            _userRepository = userRepository;
            _tokenBuilder   = tokenBuilder;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]User user)
        {
            var dbUser = (await _userRepository.GetAllAsync())
                .SingleOrDefault(u => u.Username == user.Username);

            if (dbUser == null)
            {
                return NotFound("User not found.");
            }

            CryptoHelper cryptoHelper = new CryptoHelper();
            var isValid = cryptoHelper.Decrypt(dbUser.Password) == user.Password;

            if (!isValid)
            {
                return BadRequest("Could not authenticate user.");
            }

            var token = _tokenBuilder.BuildToken(user.Username);

            return Ok(token);
        }

        [HttpGet("verify")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> VerifyToken()
        {
            var username = User
                .Claims
                .SingleOrDefault();

            if (username == null)
            {
                return Unauthorized();
            }

            var userExists = (await _userRepository.GetAllAsync())
                .Any(u => u.Username == username.Value);

            if (!userExists)
            {
                return Unauthorized();
            }

            return NoContent();
        }
    }
}