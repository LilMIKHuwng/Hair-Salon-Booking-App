using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using HairSalon.ModelViews.PaymentModelViews;
using HairSalon.ModelViews.RoleModelViews;
using HairSalon.ModelViews.VnPayModelViews;
using HairSalon.Services.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HairSalonBE.API.Controllers
{
	[Authorize(Roles = "User,Admin,Manager")]
	[Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private readonly IVnPayService _vpnPayService;

        public PaymentController(IPaymentService paymentService, IVnPayService vpnPayService)
        {
            _paymentService = paymentService;
            _vpnPayService = vpnPayService;
        }

        [HttpGet("all")]
        public async Task<ActionResult<BasePaginatedList<PaymentModelView>>> GetAllPayments(
                                                                                    int pageNumber = 1,
                                                                                    int pageSize = 5,
                                                                                    [FromQuery] string? id = null,
                                                                                    [FromQuery] string? appointmentId = null,
                                                                                    [FromQuery] string? paymentMethod = null)
        {
            var result = await _paymentService.GetAllPaymentAsync(pageNumber, pageSize, id, appointmentId, paymentMethod);
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<ActionResult<string>> CreatePayment([FromQuery] VnPayResponseModelView model)
        {
            if(model.Method == "VNPAY")
            {
                string result = await _vpnPayService.ExcutePayment(model);
                return Ok(new { Message = result });
            }
            return BadRequest();
        }

        [HttpPost("create-vnpay")]
        public async Task<ActionResult> CreateVnPay(VnPayRequestModelView model)
        {
            var paymentUrl = _vpnPayService.CreatePaymentUrl(model, HttpContext);
            return Ok(new { Url = paymentUrl });
        }

        [HttpDelete("delete/{id}")]
		[Authorize(Roles = "Admin")]
		public async Task<ActionResult<string>> DeletePayment(string id)
        {
            string result = await _paymentService.DeletePaymentpAsync(id);
            return Ok(new { Message = result });
        }
    }
}
