using OnlineCourse.Data.Entity.Auth;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCourse.Data.Entity.Course
{
    [Table("tbl_user_course")]
    public class CourseUserEntity : Entity
    {
        [Required]
        [ForeignKey("UserId")]
        public string UserId { get; set; }
        public virtual UserEntity User { get; set; }

        [Required]
        [ForeignKey("CourseId")]
        public string CourseId { get; set; }
        public virtual CourseEntity Course { get; set; }
        public bool IsTeacher { get; set; }
    }
}
