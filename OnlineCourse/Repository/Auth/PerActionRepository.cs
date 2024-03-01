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

    }
}
