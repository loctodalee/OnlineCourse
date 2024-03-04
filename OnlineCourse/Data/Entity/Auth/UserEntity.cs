using OnlineCourse.Data.Entity.Course;
using OnlineCourse.Data.Entity.Order;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCourse.Data.Entity.Auth
{
    [Table("tbl_User")]
    public class UserEntity : Entity
    {
        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string FirstName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string Account { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        public bool Sex { get; set; }

        public DateTime DOB { get; set; }

        public string? Nationality { get; set; }

        [DefaultValue(false)]

        public string? VerifyToken { get; set; }

        public string? RefreshToken { get; set; }

        public virtual ICollection<UserPermissionEntity>? Permissions { get; set; }
        public virtual ICollection<RefreshTokens>? RefreshTokens { get; set; }
        public virtual ICollection<OrderEntity>? Orders { get; set; }
        public virtual ICollection<CourseUserEntity>? Courses { get; set;}
        public virtual ICollection<UserCourseLessonProgressEntity>? UserCourseLessonProgresses { get; set; }

    }
}
