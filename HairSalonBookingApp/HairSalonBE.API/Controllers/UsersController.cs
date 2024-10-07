using Microsoft.AspNetCore.Mvc;
using HairSalon.ModelViews.UserModelViews;
using HairSalon.Contract.Services.Interface;
using HairSalon.Core;

namespace HairSalonBE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService) {
            _userService = userService;
        }

		[HttpGet("get-all")]
		public async Task<ActionResult<BasePaginatedList<UserModelView>>> GetAllUsers(int pageNumber = 1, int pageSize = 5)
		{
			try
			{
				var result = await _userService.GetAllUserAsync(pageNumber, pageSize);
				return Ok(result);
			}
			catch (Exception ex)
			{
				return BadRequest(new { Message = ex.Message });
			}
		}

		[HttpGet("get-by-id")]
		public async Task<ActionResult<UserModelView>> GetUserById(string id)
		{
			try
			{
				var result = await _userService.GetUserAsync(id);
				return Ok(result);
			}
			catch (Exception ex)
			{
				return NotFound(new { Message = ex.Message });
			}
		}

		[HttpPost("create")]
		public async Task<ActionResult<UserModelView>> CreateUser([FromQuery] CreateUserModelView model)
		{
			try
			{
				UserModelView result = await _userService.AddUserAsync(model);
				return Ok(result);
			}
			catch (Exception ex)
			{
				return BadRequest(new { Message = ex.Message });
			}
		}

		[HttpPut("update")]
		public async Task<IActionResult> UpdateUser(string id, [FromQuery] UpdateUserModelView model)
		{
			try
			{
				UserModelView result = await _userService.UpdateUserAsync(id, model);
				return Ok(result);
			}
			catch (Exception ex)
			{
				return BadRequest(new { Message = ex.Message });
			}
		}

		[HttpDelete("delete")]
		public async Task<IActionResult> DeleteUser(string id)
		{
			try
			{
				string result = await _userService.DeleteUserAsync(id);
				return Ok(result);
			}
			catch (Exception ex)
			{
				return BadRequest(new { Message = ex.Message });
			}
		}
	}
}
