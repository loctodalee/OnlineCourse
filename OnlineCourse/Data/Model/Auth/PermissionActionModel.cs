using OnlineCourse.Data.Entity.Auth;

namespace OnlineCourse.Data.Model.Auth
{
    public class PermissionActionModel
    {
        public string Id { get; set; }
        public string PermissionId { get; set; }
        public virtual PermissionModel Permission { get; set; }

        public string ActionId { get; set; }
        public virtual ActModel Action { get; set; }
    }
}
