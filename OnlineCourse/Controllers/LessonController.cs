using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineCourse.Data.Model.Course;
using OnlineCourse.Data.Model.Course.Request;
using OnlineCourse.Services.Course.Interface;
using System.Reflection.Metadata.Ecma335;

namespace OnlineCourse.Controllers
{
    [Route("api/lessons")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly ILessonService _lessonService;

        public LessonController(IServiceProvider serviceProvider)
        {
            _lessonService = serviceProvider.GetRequiredService<ILessonService>();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLessons()
        {
            try
            {
                var lessonList = await _lessonService.GetAll();
                if (lessonList.Count == 0)
                {
                    return NotFound("Empty list");
                }
                return Ok(lessonList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("by-lesson-id/{id}")]
        public async Task<IActionResult> GetLessonByID(string id)
        {
            try
            {
                var lesson = await _lessonService.GetLessonById(id);
                if (lesson == null)
                {
                    return NotFound("Don't exist lesson with given ID");
                }
                return Ok(lesson);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("by-course-id/{id}")]
        public async Task<IActionResult> GetLessonByCourseID(string id)
        {
            try
            {
                var lessonList = await _lessonService.GetAllLessonByCourseId(id);
                if (lessonList.Count == 0)
                {
                    return NotFound("Empty list");
                }
                return Ok(lessonList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> CreateLesson(string? previousLessonID, RequestCreateLessonModel model)
        {
            try
            {
                var lesson = await _lessonService.CreateLesson(previousLessonID, model);
                return Ok(new
                {
                    Message = "Create successfully!",
                    Data = lesson
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLesson(LessonModel newModel)
        {
            try
            {
                var result = await _lessonService.UpdateLesson(newModel);
                return Ok(new
                {
                    Message = "Update successfully!",
                    Data = result
                });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLesson(string id)
        {
            try
            {
                await _lessonService.DeleteLesson(id);
                return Ok(new
                {
                    Message = "Delete successfully!"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
