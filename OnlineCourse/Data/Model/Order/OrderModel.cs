using OnlineCourse.Data.Entity.Auth;
using OnlineCourse.Data.Entity.Course;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineCourse.Data.Model.Order
{
    public class OrderModel
    {
        public string Id { get; set; }
        public string CourseId { get; set; }
        public string UserId { get; set; }
        public double Price { get; set; }
        public DateTime Buy_date { get; set; }
        public bool IsPay { get; set; }
    }
}
