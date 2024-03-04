using Microsoft.EntityFrameworkCore;
using OnlineCourse.Data;
using OnlineCourse.Data.Entity.Auth;
using OnlineCourse.Data.Entity.Course;

namespace OnlineCourse.Repository.Course
{
    public class LessonRepository : BaseRepository<LessonEntity>
    {
        private OnlineCourseDbContext context;

        public LessonRepository (OnlineCourseDbContext context) : base(context)
        {
            this.context = context;
        }

        public override Task Update(LessonEntity entity)
        {
            var existed = context.Lessons.Find(entity);
            if (existed == null)
            {
                throw new Exception("Lesson is not existed!!");
            }
            try
            {
                existed.Title = entity.Title;
                existed.Description = entity.Description;
                existed.VideoUrl = entity.VideoUrl;
                existed.NextLessonId = entity.NextLessonId;
                return base.Update(existed);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
