using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using HairSalon.ModelViews.ApplicationUserModelViews;
using HairSalon.ModelViews.AppUserRoleViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HairSalonBE.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ApplicationUserRoleController : ControllerBase
	{
		private readonly IAppUserRoleService _appUserRoleService;

		public ApplicationUserRoleController(IAppUserRoleService appUserRoleService)
		{
			_appUserRoleService = appUserRoleService;
		}

		[HttpPost()]
		public async Task<ActionResult<AppUserRoleModelView>> CreateAppUserRole([FromQuery] CreateAppUserRoleModelView model)
		{
			try
			{
				AppUserRoleModelView result = await _appUserRoleService.AddAppUserRoleAsync(model);
				return Ok(result);
			}
			catch (Exception ex)
			{
				return BadRequest(new { Message = ex.Message });
			}
		}

		[HttpGet("all")]
		public async Task<ActionResult<BasePaginatedList<AppUserRoleModelView>>> GetAllApplicationUserRoles(int pageNumber = 1, int pageSize = 5)
		{
			try
			{
				// Call service to get paginated list of appointments
				var result = await _appUserRoleService.GetAllAppUserRoleAsync(pageNumber, pageSize);
				return Ok(result);
			}
			catch (Exception ex)
			{
				return BadRequest(new { Message = ex.Message });
			}
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<AppUserRoleModelView>> GetApplicationUserRoleById(string UserId, string RoleId)
		{
			try
			{
				// Call service to get appointment by ID
				var result = await _appUserRoleService.GetAppUserRoleAsync(UserId, RoleId);
				return Ok(result);
			}
			catch (Exception ex)
			{
				return NotFound(new { Message = ex.Message });
			}
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateApplicationUserRole(string UserId, string RoleId, [FromQuery] UpdateAppUserRoleModelView model)
		{
			try
			{
				AppUserRoleModelView result = await _appUserRoleService.UpdateAppUserRoleAsync(UserId, RoleId, model);
				return Ok(result);
			}
			catch (Exception ex)
			{
				return BadRequest(new { Message = ex.Message });
			}
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteApplicationUserRole(string UserId, string RoleId)
		{
			try
			{
				string result = await _appUserRoleService.DeleteAppUserRoleAsync(UserId, RoleId);
				return Ok(result);
			}
			catch (Exception ex)
			{
				return BadRequest(new { Message = ex.Message });
			}
		}
	}
}
