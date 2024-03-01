using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCourse.Data.Entity.Auth
{
    [Table("tbl_per_action")]
    public class PermissionActionEntity : SubEntity
    {
        [Required]
        [ForeignKey("PermissionId")]
        public string PermissionId { get; set; }
        public virtual PermissionEntity Permission { get; set; }

        [Required]
        [ForeignKey("ActionId")]
        public string ActionId { get; set; }
        public virtual ActEntity Action { get; set; }
    }
}
