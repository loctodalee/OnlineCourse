﻿using Microsoft.AspNetCore.Mvc;
using OnlineCourse.Data.Model.Auth;
using OnlineCourse.Data.Model.Auth.Request;
using OnlineCourse.Services.Auth.NewFolder;

namespace OnlineCourse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActController : ControllerBase
    {
        public IActService ActionService;

        public ActController(IServiceProvider serviceProvider) 
        {
           ActionService = serviceProvider.GetRequiredService<IActService>();
        }

        [HttpGet("/api/[controller]/get-all")]
        public async Task<IActionResult> GetAllActions()
        {
            var result = await ActionService.GetActions();
            return Ok(result);
        }

        [HttpPost("/api/[controller]/create-new-action")]
        public async Task<IActionResult> CreateNewAction(RequestCreateActionModel model)
        {
            try
            {
                var result = await ActionService.CreateAction(model);
                return Ok(result);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/api/[controller]/get-action-byId/{id}")]
        public async Task<IActionResult> GetActionById([FromRoute]string id)
        {
            try
            {
                var result = await ActionService.GetActionById(id);
                return Ok(result);
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("/api/[controller]/update-action")]
        public async Task<IActionResult> UpdateAction(ActModel model)
        {
            try
            {
                var result = await ActionService.UpdateAction(model);
                return Ok(result);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("/api/[controller]/delete-action")]
        public async Task<IActionResult> DeleteAction(string id)
        {
            try
            {
                await ActionService.DeleteAction(id);
                return Ok("Success");
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
