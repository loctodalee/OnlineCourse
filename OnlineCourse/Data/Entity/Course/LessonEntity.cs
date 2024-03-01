using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCourse.Data.Entity.Course
{
    [Table("tbl_lesson")]
    public class LessonEntity : Entity
    {
        [Required]
        [ForeignKey("CourseId")]
        public string CourseId { get; set; }
        public virtual CourseEntity Course { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string VideoUrl {  get; set; }
        public string NextLessonId { get; set; }
        public ICollection<UserCourseLessonProgressEntity>? UserCourseLessonProgresses { get; set; }
    }
}
