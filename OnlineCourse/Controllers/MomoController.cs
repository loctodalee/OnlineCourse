using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineCourse.Data.Model.Order;
using OnlineCourse.Services.Payment.Interface;

namespace OnlineCourse.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class MomoController : Controller
    {
        private IMomoService _momoService;
       
        public MomoController(IServiceProvider serviceProvider)
        {
            _momoService = serviceProvider.GetRequiredService<IMomoService>();
        }

        [HttpPost("/api/[controller]/momo/payment")]
        public async Task<IActionResult> CreatePaymentUrl(OrderInfoModel model)
        {
            var response = await _momoService.CreatePaymentAsync(model);
            Redirect(response.PayUrl);
            return Ok(response);
        }

        [HttpGet]
        public IActionResult PaymentCallBack()
        {
            var response = _momoService.PaymentExecuteAsync(HttpContext.Request.Query);
            return Ok(response);
        }
    }
}
