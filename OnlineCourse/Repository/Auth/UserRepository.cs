using Microsoft.EntityFrameworkCore;
using OnlineCourse.Data;
using OnlineCourse.Data.Entity.Auth;

namespace OnlineCourse.Repository.Auth
{
    public class UserRepository : BaseRepository<UserEntity>
    {
        private DbSet<UserEntity> _users;
        private OnlineCourseDbContext context;
        public UserRepository(OnlineCourseDbContext context) : base(context) { }

        public override Task Update(UserEntity entity)
        {
            var existed = context.Users.Where(c => c.Id == entity.Id).FirstOrDefault();
            if (existed == null)
            {
                throw new Exception("User is not existed");
            }

            try
            {
                existed.FirstName = entity.FirstName;
                existed.LastName = entity.LastName;
                existed.Account = existed.Account;
                existed.Password = entity.Password;
                existed.Email = entity.Email;
                existed.PhoneNumber = entity.PhoneNumber;
                existed.Sex = entity.Sex;
                existed.DOB = entity.DOB;
                existed.Nationality = entity.Nationality;


                return base.Update(existed);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
