using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using HairSalon.ModelViews.AppUserRoleViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HairSalonBE.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserRoleController : ControllerBase
    {
        private readonly IAppUserRoleService _appUserRoleService;

        public ApplicationUserRoleController(IAppUserRoleService appUserRoleService)
        {
            _appUserRoleService = appUserRoleService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAppUserRole([FromQuery] CreateAppUserRoleModelView model)
        {
            var result = await _appUserRoleService.AddAppUserRoleAsync(model);

            return Ok(result);
        }

        [HttpGet("all")]
        public async Task<ActionResult<BasePaginatedList<AppUserRoleModelView>>> GetAllApplicationUserRoles(int pageNumber = 1, int pageSize = 5,
            [FromQuery] string? userId = null, [FromQuery] string? roleId = null)
        {
            var result = await _appUserRoleService.GetAllAppUserRoleAsync(pageNumber, pageSize, userId, roleId);

            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateApplicationUserRole(string UserId, string RoleId, [FromQuery] UpdateAppUserRoleModelView model)
        {
            var result = await _appUserRoleService.UpdateAppUserRoleAsync(UserId, RoleId, model);

            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteApplicationUserRole(string UserId, string RoleId)
        {
            string result = await _appUserRoleService.DeleteAppUserRoleAsync(UserId, RoleId);

            return Ok(result);
        }
    }
}
