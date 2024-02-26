using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCourse.Data.Entity.Auth
{
    [Table("tbl_User")]
    public class UserEntity : Entity
    {
        [Column(TypeName = "nvarchar(20)")]
        public string FirstName { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string LastName { get; set; }

        [StringLength(50)]
        public string Account { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        public bool Sex { get; set; }

        public DateTime DOB { get; set; }

        public string? Nationality { get; set; }

        [DefaultValue(false)]

        public string? VerifyToken { get; set; }

        public string? RefreshToken { get; set; }

        public ICollection<UserPermissionEntity>? Permissions { get; set; }
        public ICollection<RefreshTokens>? RefreshTokens { get; set; }

    }
}
