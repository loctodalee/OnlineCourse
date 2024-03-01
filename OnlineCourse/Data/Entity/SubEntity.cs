using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnlineCourse.Data.Entity
{
    public abstract class SubEntity
    {
        protected SubEntity()
        {
            CreateTimes = DateTime.Now;
            LastUpdateTimes = DateTime.Now;
            IsActive = true;
        }
        [Key]
        public DateTime CreateTimes { get; set; }
        public DateTime LastUpdateTimes { get; set; }
        [DefaultValue(true)]
        public bool IsActive {  get; set; }
    }
}
