using Microsoft.EntityFrameworkCore;
using OnlineCourse.Data;
using OnlineCourse.Data.Entity.Course;

namespace OnlineCourse.Repository.Course
{
    public class UserCourseLessonProgressRepository : BaseRepository<UserCourseLessonProgressEntity>
    {
        private OnlineCourseDbContext context;
        private DbSet<UserCourseLessonProgressEntity> progress;

        public UserCourseLessonProgressRepository (OnlineCourseDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
