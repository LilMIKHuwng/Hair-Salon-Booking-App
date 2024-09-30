using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using HairSalon.ModelViews.AppointmentModelViews;
using HairSalon.ModelViews.ShopModelViews;
using HairSalon.Services.Service;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace HairSalonBE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpPost()]
        public async Task<ActionResult<AppointmentModelView>> CreateAppointment([FromQuery] AppointmentCreateModel model)
        {
            try
            {
                AppointmentModelView result = await _appointmentService.AddAppointmentAsync(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpGet("all")]
        public async Task<ActionResult<BasePaginatedList<AppointmentModelView>>> GetAllAppointments(int pageNumber = 1, int pageSize = 5)
        {
            try
            {
                // Call service to get paginated list of appointments
                var result = await _appointmentService.GetAllAppointmentAsync(pageNumber, pageSize);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppointmentModelView>> GetAppointmentById(string id)
        {
            try
            {
                // Call service to get appointment by ID
                var result = await _appointmentService.GetAppointmentAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAppointment(string id, [FromQuery] UpdateAppointmentModel model)
        {
            try
            {
                AppointmentModelView result = await _appointmentService.UpdateAppointmentAsync(id, model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(string id)
        {
            try
            {
                string result = await _appointmentService.DeleteAppointmentAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}