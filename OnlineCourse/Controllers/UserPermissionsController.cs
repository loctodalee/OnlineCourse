using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineCourse.Data.Model.Auth;
using OnlineCourse.Data.Model.Auth.Request;
using OnlineCourse.Services.Auth.Interface;

namespace OnlineCourse.Controllers
{
    [Route("api/user-permission")]
    [ApiController]
    public class UserPermissionsController : ControllerBase
    {
        private IUserPerService _userPerService;

        public UserPermissionsController(IServiceProvider serviceProvider)
        {
            _userPerService = serviceProvider.GetRequiredService<IUserPerService>();
        }

        [HttpGet]
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            try
            {
                var result = await _userPerService.GetByUserId(id);
                return Ok(result);
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
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


        [HttpDelete]
        public async Task<IActionResult> DeleteUserPermission(UserPermissionModel model)
        {
            try
            {
                await _userPerService.DeleteUserPer(model); return Ok("Success");
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
    }
}
