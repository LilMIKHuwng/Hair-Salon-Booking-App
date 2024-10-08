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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllSalaryPayments(string? id, DateTime? paymentDate, int pageNumber = 1, int pageSize = 5)
        {
            var result = await _salaryPaymentService.GetAllSalaryPaymentAsync(id, paymentDate, pageNumber, pageSize);
            return Ok(result);
        }

        [HttpPost("create")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateSalaryPayment
                                    ([FromQuery] CreateSalaryPaymentModelView model)
        {
            string result = await _salaryPaymentService.CreateSalaryPaymentAsync(model);
            return Ok(result);
        }

        [HttpPut("update/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateSalaryPayment(string id, [FromQuery] UpdatedSalaryPaymentModelView model)
        {
            string result = await _salaryPaymentService.UpdateSalaryPaymentAsync(id, model);
            return Ok(result);
        }

        [HttpDelete("delete")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteSalaryPayment(string id)
        {
            string result = await _salaryPaymentService.DeleteSalaryPaymentAsync(id);
            return Ok(result);
        }
    }
}
