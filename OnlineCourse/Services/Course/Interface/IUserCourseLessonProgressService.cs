using OnlineCourse.Data.Entity.Course;
using OnlineCourse.Data.Model.Course;
using OnlineCourse.Data.Model.Course.Request;

namespace OnlineCourse.Services.Course.Interface
{
    public interface IUserCourseLessonProgressService
    {
        Task<List<UserCourseLessonProgressModel>> GetAll();
        Task<List<UserCourseLessonProgressModel>> GetByUserId(string id);
        Task<List<UserCourseLessonProgressModel>> GetByCourseId(string id);
        Task<List<UserCourseLessonProgressModel>> GetByLessonId(string id);
        Task<UserCourseLessonProgressModel> CreateBeginProgress(RequestCreateUserCourseLessonProgressModel model);
        Task UpdateProgress(UserCourseLessonProgressModel model);
    }
}
