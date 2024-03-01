using OnlineCourse.Data.Entity.Auth;
using OnlineCourse.Data.Entity.Course;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineCourse.Data.Model.Course.Request
{
    public class RequestCreateUserCourseLessonProgressModel
    {
        public string UserId { get; set; }
        public string CourseId { get; set; }

    }
}
