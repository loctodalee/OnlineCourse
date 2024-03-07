using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using OnlineCourse.Data.Model;
using OnlineCourse.Data.Model.Order;
using OnlineCourse.Services.Payment.Interface;
using System.Security.Cryptography;
using System.Text;
using RestSharp;
using Newtonsoft.Json;
using OnlineCourse.Services.Order;
using OnlineCourse.Repository;

namespace OnlineCourse.Services.Payment
{
    public class MomoService : IMomoService
    {

        private readonly IOptions<MomoOptionModel> _options;
        private IOrderService _orderService;
        private IUnitOfWork _unitOfWork;

        public MomoService(IOptions<MomoOptionModel> options, IOrderService orderService, IUnitOfWork unitOfWork)
        {
            _options = options;
            _orderService = orderService;
            _unitOfWork = unitOfWork;
        }
        private string ComputeHmacSha256(string message, string secretKey)
        {
            var keyBytes = Encoding.UTF8.GetBytes(secretKey);
            var messageBytes = Encoding.UTF8.GetBytes(message);

            byte[] hashBytes;

            using (var hmac = new HMACSHA256(keyBytes))
            {
                hashBytes = hmac.ComputeHash(messageBytes);
            }

            var hashString = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

            return hashString;
        }

        public async Task<MomoCreatePaymentResponseModel> CreatePaymentAsync(RequestCreateOrderModel order)
        {
            var model = await _orderService.CreateOrder(order);
            var user = await _unitOfWork.UserRepository.GetSingleById(model.UserId);
            var course = await _unitOfWork.CourseRepository.GetSingleById(model.CourseId);
            var orderInfo = "Khách hàng: " + user.FirstName + user.LastName + ". Nội dung: Mua khóa hoc: " + course;
            var rawData =
                $"partnerCode={_options.Value.PartnerCode}&accessKey={_options.Value.AccessKey}&requestId={model.Id}&amount={model.Price}&orderId={model.Id}&orderInfo={orderInfo}&returnUrl={_options.Value.ReturnUrl}&notifyUrl={_options.Value.NotifyUrl}&extraData=";

            var signature = ComputeHmacSha256(rawData, _options.Value.SecretKey);

            var client = new RestClient(_options.Value.MomoApiUrl);
            var request = new RestRequest() { Method = Method.Post };
            request.AddHeader("Content-Type", "application/json; charset=UTF-8");

            // Create an object representing the request data
            var requestData = new
            {
                accessKey = _options.Value.AccessKey,
                partnerCode = _options.Value.PartnerCode,
                requestType = _options.Value.RequestType,
                notifyUrl = _options.Value.NotifyUrl,
                returnUrl = _options.Value.ReturnUrl,
                orderId = model.Id,
                amount = order.Price.ToString(),
                orderInfo = orderInfo,
                requestId = model.Id,
                extraData = "",
                signature = signature
            };

            request.AddParameter("application/json", JsonConvert.SerializeObject(requestData), ParameterType.RequestBody);

            var response = await client.ExecuteAsync(request);

            return JsonConvert.DeserializeObject<MomoCreatePaymentResponseModel>(response.Content);
        }

        public MomoExecuteResponseModel PaymentExecuteAsync(IQueryCollection collection)
        {
            var amount = collection.First(s => s.Key == "amount").Value;
            var orderInfo = collection.First(s => s.Key == "orderInfo").Value;
            var orderId = collection.First(s => s.Key == "orderId").Value;
            return new MomoExecuteResponseModel()
            {
                Amount = amount,
                OrderId = orderId,
                OrderInfo = orderInfo
            };
        }
    }
}
