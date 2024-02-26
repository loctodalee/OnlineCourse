using Microsoft.EntityFrameworkCore;
using OnlineCourse.Data;
using OnlineCourse.Data.Entity.Auth;

namespace OnlineCourse.Repository.Auth
{
    public class RefreshTokensRepository : BaseRepository<RefreshTokens>
    {
        private DbSet<RefreshTokens> _refreshTokens;
        private OnlineCourseDbContext context;

        public RefreshTokensRepository(OnlineCourseDbContext context) : base(context)
        {
            this.context = context;
        }

        public override Task Update(RefreshTokens entity)
        {
            var existed = context.RefreshTokens.Where(c => c.Id == entity.Id).FirstOrDefault();
            if (existed == null)
            {
                throw new Exception("RefreshTokens is not existed");
            }

            try
            {
                existed.Token = entity.Token;
                existed.UserId = entity.UserId;
                existed.IsActive = entity.IsActive;
                return base.Update(existed);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
