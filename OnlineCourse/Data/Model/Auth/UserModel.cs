using OnlineCourse.Data.Entity.Auth;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OnlineCourse.Data.Model.Auth
{
    public class UserModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Account { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public bool Sex { get; set; }

        public DateTime DOB { get; set; }

        public string? Nationality { get; set; }

        public string? RefreshToken { get; set; }

        public ICollection<UserPermissionModel>? Permissions { get; set; }
    }
}
