using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineCourse.Data.Model.Auth;
using OnlineCourse.Data.Model.Auth.Request;
using OnlineCourse.Data.Model.Email;
using OnlineCourse.Services.Auth.Interface;

namespace OnlineCourse.Controllers
{
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        public UsersController(IServiceProvider serviceProvider)
        {
            _userService = serviceProvider.GetRequiredService<IUserService>();
        }

        [HttpGet("/api/[controller]/get-all-users")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Add Course")]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var result = await _userService.GetUsers();
                return Ok(result);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("/api/[controller]/create-user-by-admin")]
        public async Task<IActionResult> CreateUser(RequestCreateUserModel model)
        {
            try
            {
                var result = await _userService.CreateUser(model);
                return Ok(result);
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("/api/[controller]/register")]
        public async Task<IActionResult> Register(RequestCreateUserModel model)
        {
            try
            {
                var result = await _userService.RegisterUser(model);
                return Ok(result);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("/api/[controller]/verify-email")]
        public async Task<IActionResult> VerifyEmail(RequestVerifyModel model)
        {
            try
            {
                await _userService.VerifyEmail(model);
                return Ok("Success");
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("/api/[controller]/update-user")]
        public async Task<IActionResult> UpdateUser(UserModel model)
        {
            try
            {
                await _userService.UpdateUser(model);
                return Ok("Success");
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("/api/[controller]/delete-user")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            try
            {
                await _userService.DeleteUser(id);
                return Ok("Success");
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
