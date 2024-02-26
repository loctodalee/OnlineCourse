using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineCourse.Data.Model.Auth.Request;
using OnlineCourse.Services.Auth.Interface;

namespace OnlineCourse.Controllers
{
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticationService _authenticationService;
        public AuthenticationController(IServiceProvider serviceProvider)
        {
            _authenticationService = serviceProvider.GetRequiredService<IAuthenticationService>();
        }
        [HttpPost("/api/[controller]/login")]
        public async Task<IActionResult> Login(RequestLoginModel model)
        {
            try
            {
                var result = await _authenticationService.Authenticator(model);
                return Ok(result);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("/api/[controller]/refreshToken")]
        public async Task<IActionResult> RefreshToken(string token)
        {
            try
            {
                var result = await _authenticationService.RefreshToken(token);
                return Ok(result);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
