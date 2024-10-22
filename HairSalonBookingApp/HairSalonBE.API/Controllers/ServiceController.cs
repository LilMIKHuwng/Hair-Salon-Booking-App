using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using HairSalon.ModelViews.ServiceModelViews;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HairSalonBE.API.Controllers
{
	[Authorize(Roles = "Admin,Manager")]
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
        public async Task<ActionResult<BasePaginatedList<ServiceModelView>>> GetAllServices([FromQuery] string? id,
                                                                                            [FromQuery] string? name,
                                                                                            [FromQuery] string? type,
                                                                                            int pageNumber = 1,
                                                                                            int pageSize = 5)
        {
            var result = await _serviceService.GetAllServiceAsync(pageNumber, pageSize, id, name, type);
            return Ok(result);
        }

		[HttpPost("create")]
		public async Task<ActionResult<string>> CreateService([FromQuery] CreateServiceModelView model)
        {
            string result = await _serviceService.AddServiceAsync(model);
            return Ok(new { Message = result });
        }

		[HttpPut("update/{id}")]
		public async Task<ActionResult<string>> UpdateService(string id, [FromQuery] UpdatedServiceModelView model)
        {
            string result = await _serviceService.UpdateServiceAsync(id, model);
            return Ok(new { Message = result }); 
        }

		[HttpDelete("delete/{id}")]
		public async Task<ActionResult<string>> DeleteService(string id)
        {
            string result = await _serviceService.DeleteServiceAsync(id);
            return Ok(new { Message = result });
        }

        [HttpGet("statistic")]
        public async Task<ActionResult<BasePaginatedList<ServiceModelView>>> MonthlyServiceStatistics([FromQuery] int? year, [FromQuery] int? month, 
                                                                                                      int pageNumber = 1, int pageSize = 5)
        {
            var result = await _serviceService.MonthlyServiceStatistics(pageNumber, pageSize, year, month);
            return Ok(result);
        }
    }
}
