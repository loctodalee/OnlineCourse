using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineCourse.Data.Model.Auth;
using OnlineCourse.Data.Model.Auth.Request;
using OnlineCourse.Services.Auth.Interface;

namespace OnlineCourse.Controllers
{
    [ApiController]
    public class PermissionActionController : ControllerBase
    {
        private IPerActionService _perActionService;

        public PermissionActionController(IServiceProvider serviceProvider)
        {
            _perActionService = serviceProvider.GetRequiredService<IPerActionService>();
        }

        [HttpGet("/api/[controller]/get-all-permission-action")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _perActionService.GetAll();
                return Ok(result);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/api/[controller]/get-by-permissionId/{id}")]
        public async Task<IActionResult> GetById([FromRoute]string id)
        {
            try
            {
                var result = await _perActionService.GetByPermissionId(id);
                return Ok(result);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("/api/[controller]/create-permission-action")]
        public async Task<IActionResult> CreatePermissionAction(RequestCreatePerActionModel model)
        {
            try
            {
                var result = await _perActionService.CreatePerAction(model);
                return Ok(result);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("/api/[controller]/delete-permission-action")]
        public async Task<IActionResult> DeletePermissionAction(PermissionActionModel model)
        {
            try
            {
                await _perActionService.DeletePerAction(model);
                return Ok("Success");
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
