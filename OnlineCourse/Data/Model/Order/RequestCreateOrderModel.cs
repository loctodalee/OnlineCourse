namespace OnlineCourse.Data.Model.Order
{
    public class RequestCreateOrderModel
    {
        public string CourseId { get; set; }
        public string UserId { get; set; }
        public double Price { get; set; }
        public DateTime Buy_date { get; set; }
    }
}
