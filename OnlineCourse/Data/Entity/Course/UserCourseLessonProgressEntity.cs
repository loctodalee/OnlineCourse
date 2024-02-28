using OnlineCourse.Data.Entity.Auth;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCourse.Data.Entity.Course
{
    [Table("tbl_user_course_lesson_progress")]
    public class UserCourseLessonProgressEntity : Entity
    {
        [ForeignKey("UserId")]
        public string UserId { get; set; }
        public UserEntity User { get; set; }

        [ForeignKey("CourseId")]
        public string CourseId { get; set; }
        public CourseEntity Course { get; set; }

        [ForeignKey("LessonId")]
        public string LessonId { get; set; }
        public LessonEntity Lesson { get; set;}

        public bool IsComplete {  get; set; }
    }
}
