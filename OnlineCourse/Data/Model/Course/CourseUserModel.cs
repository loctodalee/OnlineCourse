using OnlineCourse.Data.Entity.Auth;
using OnlineCourse.Data.Entity.Course;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCourse.Data.Model.Course
{
    public class CourseUserModel
    {
        public string UserId { get; set; }
        public string CourseId { get; set; }
        public bool IsTeacher { get; set; }
    }
}
