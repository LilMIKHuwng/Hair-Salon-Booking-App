using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using HairSalon.ModelViews.PaymentModelViews;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HairSalonBE.API.Controllers
{
	[Authorize(Roles = "User")]
	[Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
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
        public async Task<ActionResult<string>> CreatePayment([FromQuery] CreatePaymentModelView model)
        {
            string result = await _paymentService.AddPaymentAsync(model);
            return Ok(new { Message = result });
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<string>> UpdatePayment(string id, [FromQuery] UpdatedPaymentModelView model)
        {
            string result = await _paymentService.UpdatePaymentAsync(id, model);
            return Ok(new { Message = result });
        }

        [HttpDelete("delete/{id}")]
        [Authorize("Admin")]
        public async Task<ActionResult<string>> DeletePayment(string id)
        {
            string result = await _paymentService.DeletePaymentpAsync(id);
            return Ok(new { Message = result });
        }
    }
}
