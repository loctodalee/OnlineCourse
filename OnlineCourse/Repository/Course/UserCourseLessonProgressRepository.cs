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

        public override Task Update(UserCourseLessonProgressEntity entity)
        {
            var existed = context.UserCourseLessonProgress
                .Where(x => x.UserId == entity.UserId && x.CourseId == entity.CourseId && x.LessonId == entity.LessonId).FirstOrDefault();
            if (existed == null)
            {
                throw new Exception("Lesson Progress is not existed!!");
            }
            try
            {
                existed.IsComplete = entity.IsComplete;
                return base.Update(existed);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
