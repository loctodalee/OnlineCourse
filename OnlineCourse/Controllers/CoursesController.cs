using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineCourse.Services.Course.Interface;

namespace OnlineCourse.Controllers
{
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private ICourseService _courseService;

        public CoursesController(IServiceProvider serviceProvider)
        {
            _courseService = serviceProvider.GetRequiredService<ICourseService>();
        }

        [HttpGet("/api/[controller]/get-all-course")]
        public async Task<IActionResult> GetAllCourse()
        {
            try
            {
                var result = await _courseService.GetAll();
                return Ok(result);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
    }
}
