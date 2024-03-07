using OnlineCourse.Data.Model;
using OnlineCourse.Data.Model.Order;

namespace OnlineCourse.Services.Payment.Interface
{
    public interface IMomoService
    {
        Task<MomoCreatePaymentResponseModel> CreatePaymentAsync(RequestCreateOrderModel model);
        MomoExecuteResponseModel PaymentExecuteAsync(IQueryCollection collection);
    }
}
