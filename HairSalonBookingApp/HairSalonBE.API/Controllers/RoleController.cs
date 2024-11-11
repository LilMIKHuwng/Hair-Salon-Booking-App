using HairSalon.Contract.Services.Interface;
using HairSalon.Contract.Services.Cache;
using HairSalon.Core;
using HairSalon.ModelViews.RoleModelViews;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HairSalonBE.API.Controllers
{
	[Authorize(Roles = "Admin")]
	[Route("api/[controller]")]
	[ApiController]
	public class RoleController : ControllerBase
	{
		private readonly IRoleService _roleService;
		private readonly ICacheService _cacheService;

		public RoleController(IRoleService roleService, ICacheService cacheService)
		{
			_roleService = roleService;
			_cacheService = cacheService;
		}

		/// <summary>
		///		Lấy tất cả vai trò 
		/// </summary>
		[HttpGet("all")]
		public async Task<ActionResult<BasePaginatedList<RoleModelView>>> GetAllRoles
			([FromQuery] string? id, [FromQuery] string? name, int pageNumber = 1, int pageSize = 5)
		{
			// Generate cache key
			string cacheKey = $"Roles";

			// Try to retrieve data from cache
			var cachedData = await _cacheService.GetListAsync<BasePaginatedList<RoleModelView>>(cacheKey);
			if (cachedData != null)
			{
				return Ok(cachedData);
			}

			// If cache miss, retrieve from service
			var result = await _roleService.GetAllRoleAsync(pageNumber, pageSize, id, name);

			// Store the result in cache
			await _cacheService.SetAsync(cacheKey, result, TimeSpan.FromMinutes(10));

			return Ok(result);
		}

		/// <summary>
		///		Tạo vai trò
		/// </summary>
		[HttpPost("create")]
		public async Task<ActionResult<string>> CreateRole([FromQuery] CreateRoleModelView model)
		{
			string result = await _roleService.AddRoleAsync(model, null);

			await _cacheService.RemoveAsync("Roles");

			return Ok(new { Message = result });
		}

		/// <summary>
		///		Cập nhật vai trò
		/// </summary>
		[HttpPut("update/{id}")]
		public async Task<ActionResult<string>> UpdateRole(string id, [FromQuery] UpdatedRoleModelView model)
		{
			string result = await _roleService.UpdateRoleAsync(id, model, null);

			await _cacheService.RemoveAsync("Roles");

			return Ok(new { Message = result });
		}

		/// <summary>
		///		Xóa vai trò
		/// </summary>
		[HttpDelete("delete/{id}")]
		public async Task<ActionResult<string>> DeleteRole(string id)
		{
			string result = await _roleService.DeleteRoleAsync(id, null);

			await _cacheService.RemoveAsync("Roles");

			return Ok(new { Message = result });
		}
	}
}
