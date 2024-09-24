using ApplicationSecurityProvider.AuthenticationServices.Jwt;
using ApplicationSecurityProvider.Models.Jwt;
using Leapspark.Auth.Events;
using Leapspark.Bootstrap.Services.MessageQueue;

namespace Leapspark.Auth.Services.Auth
{
    public class AuthService: IAuthService
    {
        private readonly IImeJwtAuthenticationService imeJwtAuthenticationService;
        private readonly Events.Events events;

        public AuthService(
            IImeJwtAuthenticationService imeJwtAuthenticationService,
            Events.Events events)
        {
            this.imeJwtAuthenticationService = imeJwtAuthenticationService;
            this.events = events;
        }

        public async Task<JwtTokenResponse> GenerateJwtAsync(TokenRequest tokenRequest, string subject)
        {
            var token = await imeJwtAuthenticationService.GenerateJwtAsync(tokenRequest);

            events.TokenIssued(this, token, subject);

            return token;
        }



    }
}
