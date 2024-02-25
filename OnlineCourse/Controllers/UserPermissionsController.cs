using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineCourse.Data.Model.Auth;
using OnlineCourse.Data.Model.Auth.Request;
using OnlineCourse.Services.Auth.Interface;

namespace OnlineCourse.Controllers
{
    [ApiController]
    public class UserPermissionsController : ControllerBase
    {
        private IUserPerService _userPerService;

        public UserPermissionsController(IServiceProvider serviceProvider)
        {
            _userPerService = serviceProvider.GetRequiredService<IUserPerService>();
        }

        [HttpGet("/api/[controller]/get-all-user-permission")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _userPerService.GetAll();
                return Ok(result);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/api/[controller]/get-user-permission-by-id/{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            try
            {
                var result = await _userPerService.GetById(id);
                return Ok(result);
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("/api/[controller]/create-user-permission")]
        public async Task<IActionResult> CreateUserPermission(RequestCreateUserPerModel model)
        {
            try
            {
                var result = await _userPerService.CreateUserPer(model);
                return Ok(result);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("/api/[controller]/update-user-permission")]
        public async Task<IActionResult> UpdateUserPermission(UserPermissionModel model)
        {
            try
            {
                await _userPerService.UpdateUserPer(model);
                return Ok("Success");
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("/api/[controller]/delete-user-permission")]
        public async Task<IActionResult> DeleteUserPermission(string id)
        {
            try
            {
                await _userPerService.DeleteUserPer(id); return Ok("Success");
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
    }
}
