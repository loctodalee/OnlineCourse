using OnlineCourse.Data.Model.Course;
using OnlineCourse.Data.Model.Course.Request;

namespace OnlineCourse.Services.Course.Interface
{
    public interface ICourseUserService
    {
        Task<List<CourseUserModel>> GetAll();
        Task<List<CourseUserModel>> GetByUserId(string id);
        Task<CourseUserModel> CreateCourseUser(RequestCreateCourseUserModel model);
        Task DeleteCourseUser(CourseUserModel model);
    }
}
