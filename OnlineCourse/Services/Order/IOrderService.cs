using OnlineCourse.Data.Model.Order;

namespace OnlineCourse.Services.Order
{
    public interface IOrderService
    {
        Task<List<OrderModel>> GetAll();
        Task<List<OrderModel>> GetOrdersByUserId(string id);
        Task<List<OrderModel>> GetOrdersByCourseId(string id);
        Task<OrderModel> GetOrderById(string id);
        Task<OrderModel> CreateOrder(RequestCreateOrderModel request);
        Task UpdateOrder(OrderModel order);
        Task DeleteOrder(string id);
    }
}
