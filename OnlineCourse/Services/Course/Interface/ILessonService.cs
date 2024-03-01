using OnlineCourse.Data.Model.Course;
using OnlineCourse.Data.Model.Course.Request;

namespace OnlineCourse.Services.Course.Interface
{
    public interface ILessonService
    {
        Task<List<LessonModel>> GetAll();
        Task<List<LessonModel>> GetAllLessonByCourseId(string courseId);
        Task<LessonModel> GetLessonById(string courseId);
        Task<LessonModel> CreateLesson(string priviousLessonId,RequestCreateLessonModel model);
        Task UpdateLesson(LessonModel model);
        Task DeleteLesson(string id);
    }
}
