using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCourse.Data.Entity.Auth
{
    [Table("tbl_action")]
    public class ActEntity : Entity
    {
        public string Name { get; set; }
        public string ActionCode { get; set; }
    }
}
