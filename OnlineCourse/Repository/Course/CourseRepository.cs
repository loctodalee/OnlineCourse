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

        public override Task Update(CourseEntity entity)
        {
            var existed = context.Courses.Find(entity);
            if (existed == null)
            {
                throw new Exception("Permisson_Action is not existed!!");
            }
            try
            {
                existed.Name = entity.Name;
                existed.Price = entity.Price;
                existed.Description = entity.Description;
                return base.Update(entity);

            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
