using Microsoft.EntityFrameworkCore;
using OnlineCourse.Data;
using OnlineCourse.Data.Entity.Auth;
using OnlineCourse.Data.Entity.Order;

namespace OnlineCourse.Repository.Order
{
    public class OrderRepository : BaseRepository<OrderEntity>
    {
        private DbSet<OrderEntity> _orders;
        private OnlineCourseDbContext context {  get; set; }
        public OrderRepository (OnlineCourseDbContext context) : base (context)
        {
            this.context = context;
        }

    }
}
