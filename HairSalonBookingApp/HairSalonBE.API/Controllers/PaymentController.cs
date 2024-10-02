using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using HairSalon.ModelViews.PaymentModelViews;
using HairSalon.ModelViews.ShopModelViews;
using HairSalon.Services.Service;
using Microsoft.AspNetCore.Mvc;

namespace HairSalonBE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        // GET: api/AllPayments
        [HttpGet("All")]
        public async Task<ActionResult<BasePaginatedList<PaymentModelView>>> GetAllPayments(int pageNumber = 1, int pageSize = 5)
        {
            try
            {
                var result = await _paymentService.GetAllPaymentAsync(pageNumber, pageSize);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        // GET: api/Payment/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentModelView>> GetPaymentById(string id)
        {
            try
            {
                var result = await _paymentService.GetPaymentAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        // POST: api/Payment
        [HttpPost()]
        public async Task<ActionResult<PaymentModelView>> CreatePayment([FromQuery] CreatePaymentModelView model)
        {
            try
            {
                PaymentModelView result = await _paymentService.AddPaymentAsync(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        // PUT: api/Payment/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePayment(string id, [FromQuery] UpdatedPaymentModelView model)
        {
            try
            {
                PaymentModelView result = await _paymentService.UpdatePaymentAsync(id, model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        // DELETE: api/Payment/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayment(string id)
        {
            try
            {
                string result = await _paymentService.DeletePaymentpAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}
