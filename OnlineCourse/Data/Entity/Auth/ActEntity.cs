using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCourse.Data.Entity.Auth
{
    [Table("tbl_action")]
    public class ActEntity : Entity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string ActionCode { get; set; }
        public virtual ICollection<PermissionActionEntity> Actions { get; set; }
    }
}
