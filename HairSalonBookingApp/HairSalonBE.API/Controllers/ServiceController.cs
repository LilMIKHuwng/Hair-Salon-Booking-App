using HairSalon.Contract.Services.Cache;
using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using HairSalon.ModelViews.ServiceModelViews;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HairSalonBE.API.Controllers
{
    [Authorize(Roles = "Admin,Manager")]
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;
        private readonly ICacheService _cacheService;
        private const string ServiceCachePrefix = "Services";

        public ServiceController(IServiceService serviceService, ICacheService cacheService)
        {
            _serviceService = serviceService;
            _cacheService = cacheService;
        }

        /// <summary>
        ///     Get all services with pagination and optional filters
        /// </summary>
        [HttpGet("all")]
        public async Task<ActionResult<BasePaginatedList<ServiceModelView>>> GetAllServices(
            [FromQuery] string? id,
            [FromQuery] string? name,
            [FromQuery] string? type,
            int pageNumber = 1,
            int pageSize = 5)
        {
            // Generate a unique cache key for this combination of parameters
            string cacheKey = $"{ServiceCachePrefix}_Page{pageNumber}_Size{pageSize}_Id{id}_Name{name}_Type{type}";

            // Try to retrieve data from cache
            var cachedData = await _cacheService.GetListAsync<BasePaginatedList<ServiceModelView>>(cacheKey);
            if (cachedData != null)
            {
                return Ok(cachedData);
            }

            // If cache miss, retrieve from service
            var result = await _serviceService.GetAllServiceAsync(pageNumber, pageSize, id, name, type);

            // Store the result in cache with the specified prefix
            await _cacheService.SetAsync(cacheKey, result, TimeSpan.FromMinutes(10), ServiceCachePrefix);

            return Ok(result);
        }

        /// <summary>
        ///     Create a new service
        /// </summary>
        [HttpPost("create")]
        public async Task<ActionResult<string>> CreateService([FromQuery] CreateServiceModelView model)
        {
            string result = await _serviceService.AddServiceAsync(model, null);

            // Clear all cached entries with the "Services" prefix
            await _cacheService.RemoveByPrefixAsync(ServiceCachePrefix);

            return Ok(new { Message = result });
        }

        /// <summary>
        ///     Update a service
        /// </summary>
        [HttpPut("update/{id}")]
        public async Task<ActionResult<string>> UpdateService(string id, [FromQuery] UpdatedServiceModelView model)
        {
            string result = await _serviceService.UpdateServiceAsync(id, model, null);

            // Clear all cached entries with the "Services" prefix
            await _cacheService.RemoveByPrefixAsync(ServiceCachePrefix);

            return Ok(new { Message = result });
        }

        /// <summary>
        ///     Delete a service
        /// </summary>
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<string>> DeleteService(string id)
        {
            string result = await _serviceService.DeleteServiceAsync(id, null);

            // Clear all cached entries with the "Services" prefix
            await _cacheService.RemoveByPrefixAsync(ServiceCachePrefix);

            return Ok(new { Message = result });
        }
    }
}
