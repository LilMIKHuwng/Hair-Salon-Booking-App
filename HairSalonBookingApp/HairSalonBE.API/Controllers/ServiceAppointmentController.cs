using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using HairSalon.ModelViews.ServiceAppointmentModelViews;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HairSalonBE.API.Controllers
{
    [Authorize(Roles = "User")]
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
		public async Task<ActionResult<BasePaginatedList<ServiceAppointmentModelView>>> GetAllServicesAppointments(
	                                                                                                int pageNumber = 1,
	                                                                                                int pageSize = 5,
	                                                                                                [FromQuery] string? id = null,
	                                                                                                [FromQuery] string? serviceId = null,
	                                                                                                [FromQuery] string? appointmentId = null)
		{
			var result = await _serviceAppointment.GetAllServiceAppointment(pageNumber, pageSize, id, serviceId, appointmentId);

			return Ok(result);
		}

		[HttpPost("create")]
        public async Task<ActionResult<string>> CreateServiceAppointment(
            CreatServiceAppointmentModelView creatServiceAppointmentModelView)
        {
            var result = await _serviceAppointment.CreateServiceAppointment(creatServiceAppointmentModelView);

            return Ok(result);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<string>> UpdateServiceAppointment(string id,
             EditServiceAppointmentModelView editServiceAppointmentModelView)
        {
            var result = await _serviceAppointment.EditServiceAppointment(id, editServiceAppointmentModelView);

            return Ok(result);
        }


        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<string>> DeleteServiceAppointment(string id)
        {
            var result = await _serviceAppointment.DeleteServiceAppointment(id);

            return Ok(result);
        }
    }
}
