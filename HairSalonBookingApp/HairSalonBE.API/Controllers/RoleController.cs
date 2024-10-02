using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using HairSalon.ModelViews.RoleModelViews;
using Microsoft.AspNetCore.Mvc;

namespace HairSalonBE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

		[HttpGet("all")]
		public async Task<ActionResult<BasePaginatedList<RoleModelView>>> GetAllRoles(int pageNumber = 1, int pageSize = 5)
		{
			try
			{
				var result = await _roleService.GetAllRoleAsync(pageNumber, pageSize);
				return Ok(result);
			}
			catch (Exception ex)
			{
				return BadRequest(new { Message = ex.Message });
			}
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<RoleModelView>> GetRoleById(string id)
		{
			try
			{
				var result = await _roleService.GetRoleAsync(id);
				return Ok(result);
			}
			catch (Exception ex)
			{
				return NotFound(new { Message = ex.Message });
			}
		}

		[HttpPost()]
		public async Task<ActionResult<RoleModelView>> CreateRole([FromQuery] CreateRoleModelView model)
		{
			try
			{
				RoleModelView result = await _roleService.AddRoleAsync(model);
				return Ok(result);
			}
			catch (Exception ex)
			{
				return BadRequest(new { Message = ex.Message });
			}
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateRole(string id, [FromQuery] UpdatedRoleModelView model)
		{
			try
			{
				RoleModelView result = await _roleService.UpdateRoleAsync(id, model);
				return Ok(result);
			}
			catch (Exception ex)
			{
				return BadRequest(new { Message = ex.Message });
			}
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteRole(string id)
		{
			try
			{
				string result = await _roleService.DeleteRoleAsync(id);
				return Ok(result);
			}
			catch (Exception ex)
			{
				return BadRequest(new { Message = ex.Message });
			}
		}
	}
}
