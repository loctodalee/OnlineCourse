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

        public override Task Update(CourseUserEntity entity)
        {
            var existed = context.CourseUsers.Find(entity);
            if (existed == null)
            {
                throw new Exception("Course_user is not existed!!");
            }
            try
            {
                existed.UserId = entity.UserId;
                existed.CourseId = entity.CourseId;
                return base.Update(existed);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
