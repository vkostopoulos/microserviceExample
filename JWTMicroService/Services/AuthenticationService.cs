using BOL;
using DAL.Repository;
using Helpers;
using JWTMicroNetCore.Services;
using System.Linq;
using System.Threading.Tasks;

namespace JWTMicroService.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IRepository<User> _userRepository;
        private readonly ITokenBuilder _tokenBuilder;

        public AuthenticationService(IRepository<User> userRepository, ITokenBuilder tokenBuilder)
        {
            _userRepository = userRepository;
            _tokenBuilder = tokenBuilder;
        }

        public async Task<string> Login(User user)
        {
            var dbUser = (await _userRepository.GetAllAsync())
                .SingleOrDefault(u => u.Username == user.Username);

            if (dbUser == null)
            {
                return string.Empty;
            }

            CryptoHelper cryptoHelper = new CryptoHelper();
            var isValid = cryptoHelper.Decrypt(dbUser.Password) == user.Password;

            if (!isValid)
            {
                return string.Empty;
            }

            var token = _tokenBuilder.BuildToken(user.Username);

            return token;
        }

        public async Task<bool> VerifyToken(System.Security.Claims.Claim claim)
        {
            var username = claim;

            if (username == null)
            {
                return false;
            }

            var userExists = (await _userRepository.GetAllAsync())
                .Any(u => u.Username == username.Value);

            if (!userExists)
            {
                return false;
            }

            return true;
        }
    }
}