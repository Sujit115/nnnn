using ApplicationSecurityProvider.AuthenticationServices.Jwt;
using ApplicationSecurityProvider.Helpers.Structs;
using ApplicationSecurityProvider.Models.Jwt;
using IMERepositories.Common.DeviceDetector;
using Leapspark.Auth.Services.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UtilityServiceProvider.ApiResponse;

namespace Leapspark.Auth.Controllers.Api.V1
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost("jwt/authToken")]
        public async Task<IActionResult> GenerateJwtToken(TokenRequest request)
        {
            var apiRes = new ApiResult<JwtTokenResponse>();
            try
            {
                var token = await authService.GenerateJwtAsync(request, "system");

                apiRes.responseHeader = new ResponseHeader()
                {
                    ResponseCode = "0",
                    ResponseMessage = "Success"
                };
                apiRes.responseBody = token;
                return Ok(apiRes);
            }
            catch (Exception ex)
            {
                return Ok(ResponseHeader.TechnicalErrorResponse());
            }
        }
    }
}
