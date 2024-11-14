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

        /// <summary>
        ///     Tạo lịch hẹn
        /// </summary>
        [HttpPost("create")]
        public async Task<IActionResult> CreateAppointment([FromQuery] CreateAppointmentModelView model)
        {
            var result = await _appointmentService.AddAppointmentAsync(model, null);

            return Ok(result);
        }

        /// <summary>
        ///     Lấy tất cả lịch hẹn
        /// </summary>
        [HttpGet("all")]
        public async Task<ActionResult<BasePaginatedList<AppointmentModelView>>> GetAllAppointments(int pageNumber = 1, int pageSize = 5,
            [FromQuery] DateTime? startDate = null, [FromQuery] DateTime? endDate = null, [FromQuery] string? id = null, [FromQuery] Guid? userId = null,
            [FromQuery] Guid? stylistId = null, [FromQuery] string? statusForAppointment = null)
        {
            var result = await _appointmentService.GetAllAppointmentAsync(pageNumber, pageSize, startDate, endDate, id, userId, stylistId, statusForAppointment);
            return Ok(result);
        }

        /// <summary>
        ///     Cập nhật lịch hẹn
        /// </summary>
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateAppointment(string id, [FromQuery] UpdateAppointmentModelView model)
        {
            var result = await _appointmentService.UpdateAppointmentAsync(id, model, null);
            return Ok(result);
        }

        /// <summary>
        ///     Xóa lịch hẹn
        /// </summary>
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAppointment(string id)
        {
            var result = await _appointmentService.DeleteAppointmentAsync(id, null);
            return Ok(result);
        }

        /// <summary>
        ///     Thay đổi trạng thái "thành công" của lịch hẹn
        /// </summary>
        [HttpPut("mark-completed/{id}")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> MarkAppointmentCompleted(string id)
        {
            var result = await _appointmentService.MarkCompleted(id, null);
            return Ok(result);
        }

        /// <summary>
        ///     Thay đổi trạng thái "xác nhận" của lịch hẹn
        /// </summary>
        [HttpPut("mark-confirmed/{id}")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> MarkAppointmentConfirmed(string id)
        {
            var result = await _appointmentService.MarkConfirmed(id, null);
            return Ok(result);
        }

        [HttpGet("appointment")]
        public async Task<IActionResult> GetAppointmentsByUserIdAsync(string userId)
        {
            try
            {
                var appointments = await _appointmentService.GetAppointmentsByUserIdAsync(userId);

                if (appointments == null || !appointments.Any())
                {
                    return NotFound(new { message = "No completed appointments found for this user." });
                }

                return Ok(appointments);
            }
            catch (ArgumentException ex)
            {
                // Invalid userId
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                // General error
                return StatusCode(500, new { message = "An error occurred while retrieving appointments.", details = ex.Message });
            }
        }
    }
}
