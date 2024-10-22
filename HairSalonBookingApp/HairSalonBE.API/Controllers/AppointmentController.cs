using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using HairSalon.ModelViews.AppointmentModelViews;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace HairSalonBE.API.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
    [ApiController]

    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAppointment([FromQuery] CreateAppointmentModelView model)
        {
            var result = await _appointmentService.AddAppointmentAsync(model);

            return Ok(result);
        }

        [HttpGet("all")]
        public async Task<ActionResult<BasePaginatedList<AppointmentModelView>>> GetAllAppointments(int pageNumber = 1, int pageSize = 5,
            [FromQuery] DateTime? startDate = null, [FromQuery] DateTime? endDate = null, [FromQuery] string? id = null, [FromQuery] Guid? userId = null,
            [FromQuery] Guid? stylistId = null, [FromQuery] string? statusForAppointment = null)
        {
            var result = await _appointmentService.GetAllAppointmentAsync(pageNumber, pageSize, startDate, endDate, id, userId, stylistId, statusForAppointment);
            return Ok(result);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateAppointment(string id, [FromQuery] UpdateAppointmentModelView model)
        {
            var result = await _appointmentService.UpdateAppointmentAsync(id, model);
            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAppointment(string id)
        {
            var result = await _appointmentService.DeleteAppointmentAsync(id);
            return Ok(result);
        }

        [HttpPut("mark-completed/{id}")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> MarkAppointmentCompleted(string id)
        {
            var result = await _appointmentService.MarkCompleted(id);
            return Ok(result);
        }

        [HttpPut("mark-confirmed/{id}")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> MarkAppointmentConfirmed(string id)
        {
            var result = await _appointmentService.MarkConfirmed(id);
            return Ok(result);
        }
    }
}
