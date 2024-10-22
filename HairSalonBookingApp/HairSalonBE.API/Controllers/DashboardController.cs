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
        public async Task<IActionResult> GetAppointmentStatistic(string? startPeriod, string? endPeriod, string periodName = "day")
        {
            var statistics = await _service.GetAppointmentStatistic(startPeriod, endPeriod, periodName);
            return Ok(statistics);
        }

        [HttpGet("GetTopUsersByTotalAmount")]
        /*[Authorize(Roles = "Admin")]*/
        public async Task<IActionResult> GetTopUsersByTotalAmount(int? top)
        {
            var statistics = await _service.GetTopUsersByTotalAmount(top);
            return Ok(statistics);
        }
    }
}
