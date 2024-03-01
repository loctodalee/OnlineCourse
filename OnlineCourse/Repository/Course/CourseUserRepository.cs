using Microsoft.EntityFrameworkCore;
using OnlineCourse.Data;
using OnlineCourse.Data.Entity.Auth;
using OnlineCourse.Data.Entity.Course;

namespace OnlineCourse.Repository.Course
{
    public class CourseUserRepository : BaseRepository<CourseUserEntity>
    {
        private DbSet<CourseUserEntity> _coursesUser;
        private OnlineCourseDbContext context {  get; set; }
        public CourseUserRepository(OnlineCourseDbContext context) : base(context)
        {
            this.context = context;
        }

    }
}
