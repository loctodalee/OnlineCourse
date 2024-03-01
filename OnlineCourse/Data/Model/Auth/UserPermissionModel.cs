using OnlineCourse.Data.Entity.Auth;

namespace OnlineCourse.Data.Model.Auth
{
    public class UserPermissionModel
    {
        public string UserId { get; set; }
        //public virtual UserModel? User { get; set; }

        public string PermissionId { get; set; }
        //public virtual PermissionModel? Permission { get; set; }
    }
}
