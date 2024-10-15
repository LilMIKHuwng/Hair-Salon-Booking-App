using HairSalon.Contract.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using HairSalon.ModelViews.SalaryPaymentModelViews;
using Microsoft.AspNetCore.Authorization;
using HairSalon.Core.Constants;
using HairSalon.Core.Base;
using HairSalon.Core;
using HairSalon.Services.Service;

namespace HairSalonBE.API.Controllers
{
    [Authorize(Roles = "Admin,Staff")]
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryPaymentController : ControllerBase
    {
        private readonly ISalaryPaymentService _salaryPaymentService;

        public SalaryPaymentController(ISalaryPaymentService salaryPaymentService)
        {
            _salaryPaymentService = salaryPaymentService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllSalaryPayments(string? id, Guid? stylistId, DateTime? paymentDate, int pageNumber = 1, int pageSize = 5)
        {
            var result = await _salaryPaymentService.GetAllSalaryPaymentAsync(id, stylistId, paymentDate, pageNumber, pageSize);
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateSalaryPayment
                                    ([FromQuery] CreateSalaryPaymentModelView model)
        {
            string result = await _salaryPaymentService.CreateSalaryPaymentAsync(model);
            return Ok(result);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateSalaryPayment(string id, [FromQuery] UpdatedSalaryPaymentModelView model)
        {
            string result = await _salaryPaymentService.UpdateSalaryPaymentAsync(id, model);
            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteSalaryPayment(string id)
        {
            string result = await _salaryPaymentService.DeleteSalaryPaymentAsync(id);
            return Ok(result);
        }
    }
}
