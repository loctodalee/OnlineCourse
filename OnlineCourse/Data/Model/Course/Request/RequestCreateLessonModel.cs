namespace OnlineCourse.Data.Model.Course.Request
{
    public class RequestCreateLessonModel
    {
        public string CourseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string VideoUrl { get; set; }
    }
}
