using ApplicationSecurityProvider.AuthenticationServices.Jwt;
using ApplicationSecurityProvider.Models.Jwt;

namespace Leapspark.Auth.Services.Auth
{
    public interface IAuthService
    {
        public Task <JwtTokenResponse> GenerateJwtAsync(TokenRequest tokenRequest, string subject);

    }
}
