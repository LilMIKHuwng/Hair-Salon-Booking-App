using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using HairSalon.ModelViews.ServiceModelViews;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HairSalonBE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _service;

        public DashboardController(IDashboardService service)
        {
            _service = service;
        }

        /// <summary>
        ///     Thống kê tổng các lịch hẹn thành công, feedback và tiền dịch vụ của các lịch hẹn đó
        /// </summary>
        [HttpGet("appointment-statistics")]
        /*[Authorize(Roles = "Admin")]*/
        public async Task<IActionResult> GetAppointmentStatistic(string? startPeriod, string? endPeriod, string periodName = "day", int pageNumber = 1, int pageSize = 5)
        {
            var statistics = await _service.GetAppointmentStatistic(startPeriod, endPeriod, periodName, pageNumber, pageSize);
            return Ok(statistics);
        }

        /// <summary>
        ///     Thống kê người dùng có tổng feedback, tiền đã chi cho dịch vụ và các lịch hẹn
        /// </summary>
        [HttpGet("top-user")]
        /*[Authorize(Roles = "Admin")]*/
        public async Task<IActionResult> GetTopUsersByTotalAmount(int? top, int pageNumber = 1, int pageSize = 5)
        {
            var statistics = await _service.GetTopUsersByTotalAmount(top, pageNumber, pageSize);
            return Ok(statistics);
        }

        /// <summary>
        ///     Thống kê tổng các combo hiện có
        /// </summary>
		[HttpGet("combo-statistics")]
        public async Task<IActionResult> GetCombosStatistical(int pageNumber = 1, int pageSize = 5, [FromQuery] int? month = null, [FromQuery] int? year = null)
        {
            var result = await _service.GetStatisticalCombosAsync(pageNumber, pageSize, month, year);
            return Ok(result);
        }

        /// <summary>
        ///     Thống kê tổng các service hiện có
        /// </summary>
        [HttpGet("service-statistics")]
        public async Task<ActionResult<BasePaginatedList<ServiceModelView>>> GetMonthlyServiceStatistics([FromQuery] int? year, [FromQuery] int? month,
                                                                                                      int pageNumber = 1, int pageSize = 5)
        {
            var result = await _service.MonthlyServiceStatistics(pageNumber, pageSize, month, year);
            return Ok(result);
        }
    }
}
