using Microsoft.EntityFrameworkCore;
using OnlineCourse.Data;
using OnlineCourse.Data.Entity.Course;

namespace OnlineCourse.Repository.Course
{
    public class CourseRepository : BaseRepository<CourseEntity>
    {
        private OnlineCourseDbContext context {  get; set; }
        public CourseRepository(OnlineCourseDbContext context) : base(context)
        {
            this.context = context;
        }

        
    }
}
