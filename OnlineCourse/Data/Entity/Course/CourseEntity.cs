using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCourse.Data.Entity.Course
{
    [Table("tbl_Course")]
    public class CourseEntity : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public ICollection<LessonEntity> Lessons { get; set; }
    }
}
