namespace OnlineCourse.Data.Model.Course.Request
{
    public class RequestCreateCourseUserModel
    {
        public string UserId { get; set; }
        public string CourseId { get; set; }
        public bool IsTeacher { get; set; }
    }
}
