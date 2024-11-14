using HairSalon.Contract.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using HairSalon.ModelViews.SalaryPaymentModelViews;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using HairSalon.Contract.Services.Cache;
using HairSalon.Core;
using HairSalon.ModelViews.RoleModelViews;
using HairSalon.ModelViews.PaymentModelViews;
using DocumentFormat.OpenXml.Wordprocessing;

namespace HairSalonBE.API.Controllers
{
    [Authorize(Roles = "Admin,Manager")]
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryPaymentController : ControllerBase
    {
        private readonly ISalaryPaymentService _salaryPaymentService;
		private readonly ICacheService _cacheService;
		private const string SalaryCachePrefix = "Salary";

		public SalaryPaymentController(ISalaryPaymentService salaryPaymentService, ICacheService cacheService)
        {
            _salaryPaymentService = salaryPaymentService;
            _cacheService = cacheService;
        }

        /// <summary>
		///		Lấy tất cả lương
		/// </summary>
        [HttpGet("all")]
        public async Task<IActionResult> GetAllSalaryPayments(string? id, Guid? stylistId, DateTime? paymentDate, decimal? baseSalary, int pageNumber = 1, int pageSize = 5)
        {
            // Genarate cache key
            string cacheKey = $"{SalaryCachePrefix}_Page{pageNumber}_Size{pageSize}_Id{id}_stylistId{stylistId}_date{paymentDate}_baseSalary{baseSalary}";

            // Try to retrieve data from cache
            var cacheData = await _cacheService.GetListAsync<BasePaginatedList<SalaryPaymentModelView>>(cacheKey);
            if(cacheData != null)
            {
                return Ok(cacheData);
            }

			// If cache miss, retrieve from service
			var result = await _salaryPaymentService.GetAllSalaryPaymentAsync(id, stylistId, paymentDate, baseSalary, pageNumber, pageSize);

			// Store the result in cache
			await _cacheService.SetAsync(cacheKey, result, TimeSpan.FromMinutes(10), SalaryCachePrefix);

			return Ok(result);
        }

        /// <summary>
		///		Tạo lương cho nhân viên
		/// </summary>
        [HttpPost("create")]
        public async Task<IActionResult> CreateSalaryPayment
                                    ([FromQuery] CreateSalaryPaymentModelView model)
        {
            string result = await _salaryPaymentService.CreateSalaryPaymentAsync(model, null);

			await _cacheService.RemoveByPrefixAsync(SalaryCachePrefix);

			return Ok(new { Message = result });
        }

        /// <summary>
		///		Cập nhật lương
		/// </summary>
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateSalaryPayment(string id, [FromQuery] UpdatedSalaryPaymentModelView model)
        {

            string result = await _salaryPaymentService.UpdateSalaryPaymentAsync(id, null, model);

			await _cacheService.RemoveByPrefixAsync(SalaryCachePrefix);

			return Ok(new { Message = result });
		}

        /// <summary>
		///		Xóa lương
		/// </summary>
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteSalaryPayment(string id)
        {
            string result = await _salaryPaymentService.DeleteSalaryPaymentAsync(id, null);

			await _cacheService.RemoveByPrefixAsync(SalaryCachePrefix);

			return Ok(new { Message = result });
		}

		/// <summary>
		///		Xuất tạo File Excel kiểm tra lương Stylist
		/// </summary>
		[HttpGet("export-excel")]
        public async Task<IActionResult> ExportToExcel([FromQuery] Guid? stylistId, [FromQuery] string? paymentDate)
        {
            var excelData = await _salaryPaymentService.ExportSalaryPaymentsToExcelAsync(stylistId, paymentDate);
			return File(excelData, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "SalaryPayments.xlsx");
        }
    }
}
