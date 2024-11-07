using HairSalon.Contract.Services.Interface;
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

		public RoleController(IRoleService roleService)
		{
			_roleService = roleService;
		}

		/// <summary>
		///		Lấy tất cả vai trò 
		/// </summary>
		[HttpGet("all")]
		public async Task<ActionResult<BasePaginatedList<RoleModelView>>> GetAllRoles
			([FromQuery] string? id, [FromQuery] string? name, int pageNumber = 1, int pageSize = 5)
		{
			var result = await _roleService.GetAllRoleAsync(pageNumber, pageSize, id, name);
			return Ok(result);
		}

        /// <summary>
        ///		Tạo vai trò
        /// </summary>
        [HttpPost("create")]
		public async Task<ActionResult<string>> CreateRole([FromQuery] CreateRoleModelView model)
		{
			string result = await _roleService.AddRoleAsync(model, null);
			return Ok(new { Message = result });
		}

        /// <summary>
        ///		Cập nhật vai trò
        /// </summary>
        [HttpPut("update/{id}")]
		public async Task<ActionResult<string>> UpdateRole(string id, [FromQuery] UpdatedRoleModelView model)
		{
			string result = await _roleService.UpdateRoleAsync(id, model, null);
			return Ok(new { Message = result });
		}

        /// <summary>
        ///		Xóa vai trò
        /// </summary>
        [HttpDelete("delete/{id}")]
		public async Task<ActionResult<string>> DeleteRole(string id)
		{
			string result = await _roleService.DeleteRoleAsync(id, null);
			return Ok(new { Message = result });
		}
	}
}
