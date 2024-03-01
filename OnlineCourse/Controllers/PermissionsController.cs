using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineCourse.Data.Model.Auth;
using OnlineCourse.Data.Model.Auth.Request;
using OnlineCourse.Services.Auth.Interface;

namespace OnlineCourse.Controllers
{
    [Route("api/permission")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        private IPermissionService permissionService;

        public PermissionsController(IServiceProvider serviceProvider)
        {
            permissionService = serviceProvider.GetRequiredService<IPermissionService>();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPermission()
        {
            try
            {
                var result = await permissionService.GetPermissionsAsync();
                return Ok(result);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPermission([FromRoute]string id)
        {
            try
            {
                var result = await permissionService.GetPermissionByIdAsync(id);
                return Ok(result);
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreatePermission(RequestCreatePermissionModel model)
        {
            try
            {
                var result = await permissionService.CreatePermission(model);
                return Ok(result);
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePermission(PermissionModel model)
        {
            try
            {
                await permissionService.UpdatePermission(model);
                return Ok("Success");
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePermission(string id)
        {
            try
            {
                await permissionService.DeletePermissionAsync(id);
                return Ok("Success");
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
