using Microsoft.EntityFrameworkCore;
using OnlineCourse.Data;
using OnlineCourse.Data.Entity.Auth;

namespace OnlineCourse.Repository.Auth
{
    public class UserPerRepository : BaseRepository<UserPermissionEntity>
    {
        private DbSet<UserPermissionEntity> _usersPer;
        private OnlineCourseDbContext context;

        public UserPerRepository(OnlineCourseDbContext context) : base(context) { }

    }
}
