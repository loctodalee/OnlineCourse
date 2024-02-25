using Microsoft.EntityFrameworkCore;
using OnlineCourse.Data;
using OnlineCourse.Data.Entity.Auth;
using System.Security;

namespace OnlineCourse.Repository.Auth
{
    public class PermissionRepository : BaseRepository<PermissionEntity>
    {
        private DbSet<PermissionEntity> _permissions;
        private OnlineCourseDbContext context;
        public PermissionRepository(OnlineCourseDbContext context) : base(context)
        {
            this.context = context;
        }

        public override Task Update(PermissionEntity entity)
        {
            //var existed = await context.Set<PermissionEntity>().FirstOrDefaultAsync();
            var existed = context.Set<PermissionEntity>().FirstOrDefault();
            existed.Name = entity.Name;
            existed.Actions = entity.Actions;
            return base.Update(existed);
        }
    }
}
