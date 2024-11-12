using HairSalon.Contract.Services.Interface;
using HairSalon.Contract.Services.Cache;
using HairSalon.Core;
using HairSalon.ModelViews.RoleModelViews;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HairSalonBE.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly ICacheService _cacheService;
        private const string RoleCachePrefix = "Roles";

        public RoleController(IRoleService roleService, ICacheService cacheService)
        {
            _roleService = roleService;
            _cacheService = cacheService;
        }

        /// <summary>
        ///     Get all roles with pagination and optional filters
        /// </summary>
        [HttpGet("all")]
        public async Task<ActionResult<BasePaginatedList<RoleModelView>>> GetAllRoles
            ([FromQuery] string? id, [FromQuery] string? name, int pageNumber = 1, int pageSize = 5)
        {
            // Generate a unique cache key for this combination of parameters
            string cacheKey = $"{RoleCachePrefix}_Page{pageNumber}_Size{pageSize}_Id{id}_Name{name}";

            // Try to retrieve data from cache
            var cachedData = await _cacheService.GetListAsync<BasePaginatedList<RoleModelView>>(cacheKey);
            if (cachedData != null)
            {
                return Ok(cachedData);
            }

            // If cache miss, retrieve from service
            var result = await _roleService.GetAllRoleAsync(pageNumber, pageSize, id, name);

            // Store the result in cache with the specified prefix
            await _cacheService.SetAsync(cacheKey, result, TimeSpan.FromMinutes(10), RoleCachePrefix);

            return Ok(result);
        }

        /// <summary>
        ///     Create a new role
        /// </summary>
        [HttpPost("create")]
        public async Task<ActionResult<string>> CreateRole([FromQuery] CreateRoleModelView model)
        {
            string result = await _roleService.AddRoleAsync(model, null);

            // Clear all cached entries with the "Roles" prefix
            await _cacheService.RemoveByPrefixAsync(RoleCachePrefix);

            return Ok(new { Message = result });
        }

        /// <summary>
        ///     Update a role
        /// </summary>
        [HttpPut("update/{id}")]
        public async Task<ActionResult<string>> UpdateRole(string id, [FromQuery] UpdatedRoleModelView model)
        {
            string result = await _roleService.UpdateRoleAsync(id, model, null);

            // Clear all cached entries with the "Roles" prefix
            await _cacheService.RemoveByPrefixAsync(RoleCachePrefix);

            return Ok(new { Message = result });
        }

        /// <summary>
        ///     Delete a role
        /// </summary>
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<string>> DeleteRole(string id)
        {
            string result = await _roleService.DeleteRoleAsync(id, null);

            // Clear all cached entries with the "Roles" prefix
            await _cacheService.RemoveByPrefixAsync(RoleCachePrefix);

            return Ok(new { Message = result });
        }
    }
}
