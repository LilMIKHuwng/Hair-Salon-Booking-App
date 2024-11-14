using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using HairSalon.ModelViews.PaymentModelViews;
using HairSalon.ModelViews.VnPayModelViews;
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
        private readonly IPayOSService _payOSService;

        public PaymentController(IPaymentService paymentService, IVnPayService vpnPayService, IPayOSService payOsService)
        {
            _paymentService = paymentService;
            _vpnPayService = vpnPayService;
            _payOSService = payOsService;
        }

        /// <summary>
        ///     Lấy tất cả thông tin payment
        /// </summary>
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

        /// <summary>
        ///     Thực hiện thanh toán
        /// </summary>
        [HttpPost("create")]
        public async Task<ActionResult<string>> CreatePayment([FromQuery] PaymentResponseModelView model)
        {
            string result = await _vpnPayService.ExcutePayment(model, null);
            return Ok(new { Message = result });
        }

        /// <summary>
        ///     Tạo link VNPay
        /// </summary>
        [HttpPost("create-vnpay")]
        public async Task<ActionResult> CreateVnPay(PaymentRequestModelView model)
        {
            var paymentUrl = _vpnPayService.CreatePaymentUrl(model, HttpContext);
            return Ok(new { Url = paymentUrl });
        }

        /// <summary>
        ///     Xóa payment
        /// </summary>
        [HttpDelete("delete/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<string>> DeletePayment(string id)
        {
            string result = await _paymentService.DeletePaymentAsync(id, null);
            return Ok(new { Message = result });
        }

        /// <summary>
        ///     Tạo thông tin để nạp tiền vào ví
        /// </summary>
        [HttpPost("deposit")]
        public async Task<ActionResult<string>> Deposit([FromQuery] VnPayDepositWalletRequestModelView model)
        {
            string result = await _vpnPayService.DepositWallet(model, HttpContext, null);
            return Ok(new { Url = result });
        }
        /// <summary>
        ///     Tạo link PayOS
        /// </summary>
        [HttpPost("create-payos")]
        public async Task<ActionResult> CreatePayOsLink(PaymentRequestModelView model)
        {
            var paymentUrl = _payOSService.CreatePaymentLink(model);
            return Ok(new { Url = paymentUrl });
        }
        /// <summary>
        ///     Thực hiện gửi tiền vào ví
        /// </summary>
        [HttpPost("execute-deposit")]
        public async Task<ActionResult<string>> ExecuteDeposit(Guid userId, [FromQuery] double amount)
        {
            string result = await _vpnPayService.ExcuteDepositToWallet(userId, amount);
            return Ok(new { Url = result });
        }

        /// <summary>
        ///     Lấy tất cả thông tin payment by userId
        /// </summary>
        [HttpGet("all-userId")]
        public async Task<ActionResult<BasePaginatedList<PaymentModelView>>> GetAllPaymentsByUserId(
                                                                                     [FromQuery] string userId,
                                                                                    int pageNumber = 1,
                                                                                    int pageSize = 5)
        {
            var result = await _paymentService.GetAllPaymentByUserIdAsync(userId, pageNumber, pageSize);
            return Ok(result);
        }
    }
}
