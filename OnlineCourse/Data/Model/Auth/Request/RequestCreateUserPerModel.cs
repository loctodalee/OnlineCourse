namespace OnlineCourse.Data.Model.Auth.Request
{
    public class RequestCreateUserPerModel
    {
        public string UserId { get; set; }
        //public virtual UserModel? User { get; set; }

        public string PermissionId { get; set; }
        //public virtual PermissionModel? Permission { get; set; }
    }
}
