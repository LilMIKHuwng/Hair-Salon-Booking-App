using HairSalon.Contract.Services.Interface;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet]
        /*[Authorize(Roles = "Admin")]*/
        public async Task<IActionResult> GetAppointmentStatistic(string? startPeriod, string? endPeriod, string periodName = "day", int pageNumber = 1, int pageSize = 5)
        {
            var statistics = await _service.GetAppointmentStatistic(startPeriod, endPeriod, periodName, pageNumber, pageSize);
            return Ok(statistics);
        }

        [HttpGet("GetTopUsersByTotalAmount")]
        /*[Authorize(Roles = "Admin")]*/
        public async Task<IActionResult> GetTopUsersByTotalAmount(int? top, int pageNumber = 1, int pageSize = 5)
        {
            var statistics = await _service.GetTopUsersByTotalAmount(top, pageNumber, pageSize);
            return Ok(statistics);
        }
    }
}
