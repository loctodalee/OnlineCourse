using OnlineCourse.Data.Entity.Auth;
using OnlineCourse.Data.Entity.Course;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCourse.Data.Entity.Order
{
    [Table("tbl_order")]
    public class OrderEntity : Entity
    {
        [ForeignKey("CourseId")]
        public string CourseId { get; set; }
        public virtual CourseEntity Course { get; set; }

        [ForeignKey("UserId")]
        public string UserId { get; set; }
        public virtual UserEntity? User { get; set; }
        public double Price { get; set; }
        public DateTime Buy_date {  get; set; }
        public bool IsPay {  get; set; }

    }
}
