using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCourse.Data.Entity.Auth
{
    [Table("tbl_per_action")]
    public class PermissionActionEntity : Entity
    {
        [ForeignKey("PermissionId")]
        public string PermissionId { get; set; }
        public virtual PermissionEntity Permission { get; set; }

        [ForeignKey("ActionId")]
        public string ActionId { get; set; }
        public virtual ActEntity Action { get; set; }
    }
}
