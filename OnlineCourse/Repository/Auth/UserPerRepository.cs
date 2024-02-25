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

        public override Task Update(UserPermissionEntity entity)
        {
            var existed = context.UserPermission.Find(entity);
            if (existed == null)
            {
                throw new Exception("User_Per not existed !!");
            }
            try
            {
                existed.PermissionId = entity.PermissionId;
                existed.UserId = entity.UserId;
                return base.Update(existed);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
