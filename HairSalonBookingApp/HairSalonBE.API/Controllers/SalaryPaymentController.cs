using HairSalon.Contract.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using HairSalon.ModelViews.SalaryPaymentModelViews;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace HairSalonBE.API.Controllers
{
    [Authorize(Roles = "Admin,Manager")]
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryPaymentController : ControllerBase
    {
        private readonly ISalaryPaymentService _salaryPaymentService;

        public SalaryPaymentController(ISalaryPaymentService salaryPaymentService)
        {
            _salaryPaymentService = salaryPaymentService;
        }

        /// <summary>
		///		Lấy tất cả lương
		/// </summary>
        [HttpGet("all")]
        public async Task<IActionResult> GetAllSalaryPayments(string? id, Guid? stylistId, DateTime? paymentDate, decimal? baseSalary, int pageNumber = 1, int pageSize = 5)
        {
            var result = await _salaryPaymentService.GetAllSalaryPaymentAsync(id, stylistId, paymentDate, baseSalary, pageNumber, pageSize);
            return Ok(result);
        }

        /// <summary>
		///		Tạo lương cho nhân viên
		/// </summary>
        [HttpPost("create")]
        public async Task<IActionResult> CreateSalaryPayment
                                    ([FromQuery] CreateSalaryPaymentModelView model)
        {
            
            string result = await _salaryPaymentService.CreateSalaryPaymentAsync(model);
            return Ok(result);
        }

        /// <summary>
		///		Cập nhật lương
		/// </summary>
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateSalaryPayment(string id, [FromQuery] UpdatedSalaryPaymentModelView model)
        {

            string result = await _salaryPaymentService.UpdateSalaryPaymentAsync(id, model);
            return Ok(result);
        }

        /// <summary>
		///		Xóa lương
		/// </summary>
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteSalaryPayment(string id)
        {
            string result = await _salaryPaymentService.DeleteSalaryPaymentAsync(id);
            return Ok(result);
        }

		/// <summary>
		///		Xuất tạo File Excel kiểm tra lương Stylist
		/// </summary>
		[HttpGet("export-excel")]
        public async Task<IActionResult> ExportToExcel([FromQuery] string? id, [FromQuery] Guid? stylistId, [FromQuery] string? paymentDate)
        {
            var excelData = await _salaryPaymentService.ExportSalaryPaymentsToExcelAsync(id, stylistId, paymentDate);
            return File(excelData, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "SalaryPayments.xlsx");
        }
    }
}
