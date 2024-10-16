using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using HairSalon.ModelViews.ApplicationUserModelViews;
using HairSalonBE.API.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HairSalonBE.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private readonly IAppUserService _appUserService;

        public ApplicationUserController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        [HttpPost("user-register")]
        public async Task<ActionResult<string>> CreateAppUser([FromQuery] CreateAppUserModelView model)
        {
            string result = await _appUserService.AddAppUserAsync(model);
            return Ok(result);
        }

        [HttpPost("stylist-register")]
        [Authorize("Admin")]
        public async Task<ActionResult<string>> CreateAppStylist([FromQuery] CreateAppStylistModelView model)
        {
            string result = await _appUserService.AddAppStylistAsync(model);
            return Ok(result);
        }

        [HttpPost("confirm-email")]
        public async Task<ActionResult<string>> ConfirmEmail([FromBody] ConfirmEmailModelView model)
        {
            string result = await _appUserService.ConfirmEmailAsync(model);
            return Ok(result);
        }

        [HttpGet("all")]
        [Authorize("Admin")]
        public async Task<ActionResult<BasePaginatedList<AppUserModelView>>> GetAllApplicationUsers(string? userId, int pageNumber = 1, int pageSize = 5)
        {
            var result = await _appUserService.GetAllAppUserAsync(userId, pageNumber, pageSize);
            return Ok(result);
        }

        [HttpPut("update/{userId}")]
        [Authorize("Admin")]
        public async Task<IActionResult> UpdateApplicationUser(string userId, [FromQuery] UpdateAppUserModelView model)
        {
            string result = await _appUserService.UpdateAppUserAsync(userId, model);
            return Ok(result);
        }

        [HttpDelete("delete/{userId}")]
        [Authorize("Admin")]
        public async Task<IActionResult> DeleteApplicationUser(string userId)
        {
            string result = await _appUserService.DeleteAppUserAsync(userId);
            return Ok(result);
        }

        [HttpPost("forgot-password")]
        public async Task<ActionResult<string>> ForgotPassword([FromBody] ForgotPasswordModelView model)
        {
            string result = await _appUserService.ForgotPasswordAsync(model);
            return Ok(result);
        }

        [HttpPost("reset-password")]
        public async Task<ActionResult<string>> ResetPassword([FromBody] ResetPasswordModelView model)
        {
            string result = await _appUserService.ResetPasswordAsync(model);
            return Ok(result);
        }

        [HttpPost("admin/reset-password")]
        [Authorize("Admin")]
        public async Task<ActionResult<string>> ResetPasswordAdminAsync([FromBody] ResetPasswordAdminModelView model)
        {
            string result = await _appUserService.ResetPasswordAdminAsync(model);
            return Ok(result);
        }

        [HttpGet("my-information")]
        [Authorize]
        public async Task<ActionResult<GetInforAppUserModelView>> GetMyInforUsersAsync()
        {
            // Lấy username từ JWT token
            var username = User.GetUsername();

            // Gọi service để lấy thông tin người dùng
            var result = await _appUserService.GetMyInforUsersAsync(username);

            if (result == null)
            {
                return NotFound("User not found");
            }
            return Ok(result);
        }
    }
}
