using Microsoft.EntityFrameworkCore;
using OnlineCourse.Data;
using OnlineCourse.Data.Entity.Auth;

namespace OnlineCourse.Repository.Auth
{
    public class PerActionRepository : BaseRepository<PermissionActionEntity>
    {
        private DbSet<PermissionActionEntity> _permissions;
        private OnlineCourseDbContext context;
        
        public PerActionRepository(OnlineCourseDbContext context) : base(context)
        {
            this.context = context;
        }

        public override Task Update(PermissionActionEntity entity)
        {
            var existed = context.PermissionAction.Find(entity);
            if (existed == null)
            {
                throw new Exception("Permisson_Action is not existed!!");
            }
            try
            {
                existed.PermissionId = entity.PermissionId;
                existed.ActionId = entity.ActionId;
                return base.Update(existed);
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
