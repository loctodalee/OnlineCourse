using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineCourse.Data.Model.Course;
using OnlineCourse.Data.Model.Course.Request;
using OnlineCourse.Services.Course.Interface;

namespace OnlineCourse.Controllers
{
    [Route("api/courses")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private ICourseService _courseService;

        public CoursesController(IServiceProvider serviceProvider)
        {
            _courseService = serviceProvider.GetRequiredService<ICourseService>();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCourse()
        {
            try
            {
                var result = await _courseService.GetAll();
                if (result.Count == 0)
                {
                    return Ok(new
                    {
                        Message = "Empty list"
                    });
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseByID(string id)
        {
            try
            {
                var course = await _courseService.GetById(id);
                if (course == null)
                {
                    return Ok(new
                    {
                        message = "Don't exist course with given ID"
                    });
                }
                return Ok(course);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse(RequestCreateCourseModel course)
        {
            try
            {
                var c = await _courseService.CreateCourse(course);
                return Ok(new
                {
                    Message = "Create successfully!",
                    Data = c
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCourse(CourseModel courseNew)
        {
            try
            {
                await _courseService.UpdateCourse(courseNew);
                return Ok(new
                {
                    Message = "Update successfully!",
                    Data = courseNew
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(string id)
        {
            try
            {
                await _courseService.DeleteCourse(id);
                return Ok("Delete successfully!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
