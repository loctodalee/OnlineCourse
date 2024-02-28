using OnlineCourse.Data.Model.Course;
using OnlineCourse.Data.Model.Course.Request;

namespace OnlineCourse.Services.Course.Interface
{
    public interface ICourseService
    {
        Task<List<CourseModel>> GetAll();
        Task<CourseModel> GetById(string id);
        Task<CourseModel> CreateCourse(RequestCreateCourseModel model);
        Task UpdateCourse(CourseModel model);
        Task DeleteCourse(string id);
    }
}
