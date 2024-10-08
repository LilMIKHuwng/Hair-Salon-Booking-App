using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using HairSalon.ModelViews.AppointmentModelViews;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HairSalonBE.API.Controllers
{
	[Authorize(Roles = "User")]
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
        public async Task<IActionResult> CreateAppointment([FromQuery] CreateAppointmentModelView model)
        {
            var result = await _appointmentService.AddAppointmentAsync(model);

            return Ok(result);
        }

        [HttpGet("all")]
        public async Task<ActionResult<BasePaginatedList<AppointmentModelView>>> GetAllAppointments(int pageNumber = 1, int pageSize = 5,
            [FromQuery] DateTime? startDate = null, [FromQuery] DateTime? endDate = null, [FromQuery] string? id = null)
        {
            var result = await _appointmentService.GetAllAppointmentAsync(pageNumber, pageSize, startDate, endDate, id);

            return Ok(result);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAppointment(string id, [FromQuery] UpdateAppointmentModelView model)
        {
            var result = await _appointmentService.UpdateAppointmentAsync(id, model);
            
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(string id)
        {
            var result = await _appointmentService.DeleteAppointmentAsync(id);

            return Ok(result);
        }
    }
}
