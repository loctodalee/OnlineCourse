using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCourse.Data.Entity.Auth
{
    [Table("tbl_user_per")]
    public class UserPermissionEntity : Entity
    {
        //public ICollection<PermissionEntity> Permissions { get; set; }
        //public ICollection<UserEntity> Users { get; set; }

        [ForeignKey("UserId")]
        public string UserId { get; set; }
        public virtual UserEntity? User { get; set; }

        [ForeignKey("PermissionId")]
        public string PermissionId { get; set; }
        public virtual PermissionEntity? Permission { get; set; }
    }
}
