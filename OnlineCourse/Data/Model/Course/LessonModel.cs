using OnlineCourse.Data.Entity.Course;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineCourse.Data.Model.Course
{
    public class LessonModel
    {
        public string Id { get; set; }
        public string CourseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string VideoUrl { get; set; }
        public string NextLessonId { get; set; }
    }
}
