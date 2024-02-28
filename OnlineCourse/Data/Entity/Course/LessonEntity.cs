using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCourse.Data.Entity.Course
{
    [Table("tbl_lesson")]
    public class LessonEntity : Entity
    {
        [ForeignKey("CourseId")]
        public string CourseId { get; set; }
        public virtual CourseEntity Course { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string VideoUrl {  get; set; }
    }
}
