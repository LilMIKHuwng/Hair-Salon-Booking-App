using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using HairSalon.ModelViews.ServiceModelViews;
using HairSalon.ModelViews.ShopModelViews;
using HairSalon.Services.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HairSalonBE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet()]
        public async Task<ActionResult<BasePaginatedList<ServiceModelView>>> GetAllServices(int pageNumber = 1, int pageSize = 5)
        {
            try
            {
                // Call service to get paginated list of shops
                var result = await _serviceService.GetAllServiceAsync(pageNumber, pageSize);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }


        // GET: api/Shop/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceModelView>> GetServiceById(string id)
        {
            try
            {
                // Call service to get shop by ID
                var result = await _serviceService.GetServiceAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        // POST: api/service
        [HttpPost()]
        public async Task<ActionResult<ServiceModelView>> CreateService([FromQuery] CreateServiceModelView model)
        {
            try
            {
                ServiceModelView result = await _serviceService.AddServiceAsync(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });



            }
        }

        // PUT: api/service/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateService(string id, [FromQuery] UpdatedServiceModelView model)
        {
            try
            {
                ServiceModelView result = await _serviceService.UpdateServiceAsync(id, model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }


        // DELETE: api/service/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(string id)
        {
            try
            {
                string result = await _serviceService.DeleteServiceAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}
