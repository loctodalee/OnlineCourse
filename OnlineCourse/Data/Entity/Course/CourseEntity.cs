using OnlineCourse.Data.Entity.Order;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCourse.Data.Entity.Course
{
    [Table("tbl_Course")]
    public class CourseEntity : Entity
    {
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        public string? BeginLessonId { get; set; }
        public ICollection<LessonEntity>? Lessons { get; set; }
        public ICollection<UserCourseLessonProgressEntity>? UserCourseLessonProgresses { get; set; }
        public ICollection<OrderEntity> Orders { get; set; }
    }
}
