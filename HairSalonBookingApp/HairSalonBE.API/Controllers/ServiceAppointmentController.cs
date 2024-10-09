using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.ServiceAppointmentModelViews;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HairSalonBE.API.Controllers
{
    [Authorize(Roles = "User, Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceAppointmentController : ControllerBase
    {
        private readonly IServiceAppointment _serviceAppointment;

        public ServiceAppointmentController(IServiceAppointment serviceAppointment)
        {
            _serviceAppointment = serviceAppointment;
        }

		[HttpGet("all")]
		public async Task<IActionResult> GetAllServicesAppointments
            ( string? id, string? serviceId, string? appointmentId, int pageNumber = 1, int pageSize = 5)
		{
			var result = await _serviceAppointment.GetAllServiceAppointment(pageNumber, pageSize, id, serviceId, appointmentId);

			return Ok(result);
		}

		[HttpPost("create")]
        public async Task<IActionResult> CreateServiceAppointment(
            [FromQuery]CreatServiceAppointmentModelView creatServiceAppointmentModelView)
        {
            var result = await _serviceAppointment.CreateServiceAppointment(creatServiceAppointmentModelView);

            return Ok(result);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateServiceAppointment(string id,
             [FromQuery]EditServiceAppointmentModelView editServiceAppointmentModelView)
        {
            var result = await _serviceAppointment.EditServiceAppointment(id, editServiceAppointmentModelView);

            return Ok(result);
        }


        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteServiceAppointment(string id)
        {
            var result = await _serviceAppointment.DeleteServiceAppointment(id);

            return Ok(result);
        }
    }
}
