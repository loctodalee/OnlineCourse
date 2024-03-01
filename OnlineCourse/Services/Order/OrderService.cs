using Nelibur.ObjectMapper;
using OnlineCourse.Data.Entity.Order;
using OnlineCourse.Data.Model.Order;
using OnlineCourse.Repository;

namespace OnlineCourse.Services.Order
{
    public class OrderService : IOrderService
    {
        private IUnitOfWork _unitOfWork;
        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<OrderModel>> GetAll()
        {
            try
            {
                var list = await _unitOfWork.OrderRepository.GetAll();
                var validList = list.Where(x => x.IsActive == true).ToList();

                var model = TinyMapper.Map<List<OrderModel>>(validList);
                return model;
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<OrderModel>> GetOrdersByUserId(string id)
        {
            try
            {
                var list = await _unitOfWork.OrderRepository.GetAll();
                var validList = list.Where(x => x.IsActive == true && x.UserId == id).ToList();

                var model = TinyMapper.Map<List<OrderModel>>(validList);
                return model;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<OrderModel>> GetOrdersByCourseId(string id)
        {
            try
            {
                var list = await _unitOfWork.OrderRepository.GetAll();
                var validList = list.Where(x => x.IsActive == true && x.CourseId == id).ToList();

                var model = TinyMapper.Map<List<OrderModel>>(validList);
                return model;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<OrderModel> GetOrderById(string id)
        {
            try
            {
                var entity = await _unitOfWork.OrderRepository.GetSingleById(id);
                if(entity == null)
                {
                    throw new Exception("Not found");
                }

                var model = TinyMapper.Map<OrderModel>(entity);
                return model;
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<OrderModel> CreateOrder(RequestCreateOrderModel model)
        {
            try
            {
                var list = await _unitOfWork.OrderRepository.GetAll();
                var existed = list.Any(x => x.UserId == model.UserId && x.CourseId == model.CourseId && x.IsPay == true && x.IsActive == true);
                if (existed)
                {
                    throw new Exception("Order is existed");
                }
                var entity = TinyMapper.Map<OrderEntity>(model);

                await _unitOfWork.OrderRepository.Add(entity);
                var resModel = TinyMapper.Map<OrderModel>(entity);
                return resModel;
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateOrder(OrderModel model)
        {
            try
            {
                var existed = await _unitOfWork.OrderRepository.GetSingleById(model.Id);

                if(existed == null || existed.IsActive == false)
                {
                    throw new Exception("Not found");
                }
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteOrder(string id)
        {
            try
            {
                var existed = await _unitOfWork.OrderRepository.GetSingleById(id);

                if(existed  != null && existed.IsPay == true)
                {
                    throw new Exception("Can not delete");
                }

                await _unitOfWork.OrderRepository.Delete(existed);
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
