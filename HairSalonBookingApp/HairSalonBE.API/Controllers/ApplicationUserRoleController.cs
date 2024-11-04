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

        /// <summary>
        ///     Tạo vai trò cho người dùng
        /// </summary>
        [HttpPost("create")]
        public async Task<IActionResult> CreateAppUserRole([FromQuery] CreateAppUserRoleModelView model)
        {
            var result = await _appUserRoleService.AddAppUserRoleAsync(model);

            return Ok(result);
        }

        /// <summary>
        ///     Lấy tất cả người dùng có vai trò
        /// </summary>
        [HttpGet("all")]
        public async Task<ActionResult<BasePaginatedList<AppUserRoleModelView>>> GetAllApplicationUserRoles(int pageNumber = 1, int pageSize = 5,
            [FromQuery] string? userId = null, [FromQuery] string? roleId = null)
        {
            var result = await _appUserRoleService.GetAllAppUserRoleAsync(pageNumber, pageSize, userId, roleId);

            return Ok(result);
        }

        /// <summary>
        ///     Cập nhật vai trò của người dùng
        /// </summary>
        [HttpPut("update")]
        public async Task<IActionResult> UpdateApplicationUserRole(string UserId, string RoleId, [FromQuery] UpdateAppUserRoleModelView model)
        {
            var result = await _appUserRoleService.UpdateAppUserRoleAsync(UserId, RoleId, model);

            return Ok(result);
        }

        /// <summary>
        ///     Xóa người dùng với vai trò đó
        /// </summary>
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteApplicationUserRole(string UserId, string RoleId)
        {
            string result = await _appUserRoleService.DeleteAppUserRoleAsync(UserId, RoleId);

            return Ok(result);
        }
    }
}
