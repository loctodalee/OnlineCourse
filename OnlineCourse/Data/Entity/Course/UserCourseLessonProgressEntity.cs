using OnlineCourse.Data.Entity.Auth;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCourse.Data.Entity.Course
{
    [Table("tbl_user_course_lesson_progress")]
    public class UserCourseLessonProgressEntity : Entity
    {
        [Required]
        [ForeignKey("UserId")]
        public string UserId { get; set; }
        public UserEntity User { get; set; }

        [Required]
        [ForeignKey("CourseId")]
        public string CourseId { get; set; }
        public CourseEntity Course { get; set; }

        [Required]
        [ForeignKey("LessonId")]
        public string LessonId { get; set; }
        public LessonEntity Lesson { get; set;}

        [DefaultValue(false)]
        public bool IsComplete {  get; set; }
    }
}
