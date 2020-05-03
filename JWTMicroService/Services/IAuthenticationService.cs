using BOL;
using System.Threading.Tasks;

namespace JWTMicroService.Services
{
    public interface IAuthenticationService
    {
        public Task<string> Login(User user);

        public Task<bool> VerifyToken(System.Security.Claims.Claim user);
    }
}
