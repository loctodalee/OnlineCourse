using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnlineCourse.Data.Entity
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid().ToString("N");
            CreateTimes = DateTime.Now;
            LastUpdateTimes = DateTime.Now;
            IsActive = true;
        }
        [Required]
        [Key]
        public string Id { get; set; }
        public DateTime CreateTimes { get; set; }
        public DateTime LastUpdateTimes { get; set; }
        [DefaultValue(true)]
        public bool IsActive {  get; set; }
    }
}
