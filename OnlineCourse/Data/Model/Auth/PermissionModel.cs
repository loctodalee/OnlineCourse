using OnlineCourse.Data.Entity.Auth;

namespace OnlineCourse.Data.Model.Auth
{
    public class PermissionModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public ICollection<PermissionActionModel> Actions { get; set; }
    }
}
