using Microsoft.EntityFrameworkCore;
using OnlineCourse.Data;
using OnlineCourse.Data.Entity.Auth;

namespace OnlineCourse.Repository.Auth
{
    public class ActRepository : BaseRepository<ActEntity>
    {
        private DbSet<ActEntity> _actions;
        private OnlineCourseDbContext context;
        public ActRepository(OnlineCourseDbContext context) : base(context)
        {
            this.context = context;
        }

        public override Task Update(ActEntity entity)
        {
            var existed = context.Actions.Find(entity.Id);
            if (existed == null)
            {
                throw new Exception("Action not existed");
            }

            existed.Name = entity.Name;
            existed.ActionCode = entity.ActionCode;
            return base.Update(existed);
        }
    }
}
