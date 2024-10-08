using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using HairSalon.ModelViews.ServiceModelViews;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HairSalonBE.API.Controllers
{
	[Authorize(Roles = "User")]
	[Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet("all")]
        public async Task<ActionResult<BasePaginatedList<ServiceModelView>>> GetAllServices(int pageNumber = 1,
                                                                                            int pageSize = 5,
                                                                                            [FromQuery] string? id = null,
                                                                                            [FromQuery] string? name = null,
                                                                                            [FromQuery] string? type = null)
        {
            var result = await _serviceService.GetAllServiceAsync(pageNumber, pageSize, id, name, type);
            return Ok(result);
        }

        [HttpPost()]
        public async Task<ActionResult<string>> CreateService([FromQuery] CreateServiceModelView model)
        {
            string result = await _serviceService.AddServiceAsync(model);
            return Ok(new { Message = result });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<string>> UpdateService(string id, [FromQuery] UpdatedServiceModelView model)
        {
            string result = await _serviceService.UpdateServiceAsync(id, model);
            return Ok(new { Message = result }); 
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteService(string id)
        {
            string result = await _serviceService.DeleteServiceAsync(id);
            return Ok(new { Message = result });
        }
    }
}
