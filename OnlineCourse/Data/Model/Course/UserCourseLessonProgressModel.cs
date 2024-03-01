using OnlineCourse.Data.Entity.Auth;
using OnlineCourse.Data.Entity.Course;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineCourse.Data.Model.Course
{
    public class UserCourseLessonProgressModel
    {
        public string UserId { get; set; }

        public string CourseId { get; set; }

        public string LessonId { get; set; }

        public bool IsComplete { get; set; }
    }
}
