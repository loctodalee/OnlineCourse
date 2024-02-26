using OnlineCourse.Data.Entity;
using OnlineCourse.Data.Entity.Auth;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCourse.Data.Entity.Auth
{
    public class RefreshTokens : Entity
    {
        public RefreshTokens()
        {
            IsActive = false;
        }

        [ForeignKey("UserId")]
        public UserEntity User { get; set; }
        public string UserId { get; set; }

        public string? Token { get; set; }
        public DateTime Expires { get; set; }
        
    }
}
   
