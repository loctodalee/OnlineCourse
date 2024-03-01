using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCourse.Data.Entity.Auth
{
    [Table("tbl_Permission")]
    public class PermissionEntity : Entity
    {
        [Required]
        public string Name {  get; set; }
        public ICollection<PermissionActionEntity> Actions { get; set; }
        
    }
}
