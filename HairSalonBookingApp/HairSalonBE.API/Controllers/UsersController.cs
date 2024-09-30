using Microsoft.AspNetCore.Mvc;
using HairSalon.ModelViews.UserModelViews;
using HairSalon.Contract.Services.Interface;
using HairSalon.Core.Base;
using HairSalon.Core;
using HairSalon.ModelViews.ShopModelViews;
using HairSalon.Services.Service;

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

        /*[HttpGet()]
        public async Task<IActionResult> Login(int index = 1, int pageSize = 10)
        {
            IList<UserResponseModel> a = await _userService.GetAll();
            return Ok(BaseResponse<IList<UserResponseModel>>.OkResponse(a));
        }*/

		// GET: api/Shop
		[HttpGet("all")]
		public async Task<ActionResult<BasePaginatedList<UserModelView>>> GetAllUsers(int pageNumber = 1, int pageSize = 5)
		{
			try
			{
				// Call service to get paginated list of shops
				var result = await _userService.GetAllUserAsync(pageNumber, pageSize);
				return Ok(result);
			}
			catch (Exception ex)
			{
				return BadRequest(new { Message = ex.Message });
			}
		}

		// GET: api/Shop/{id}
		[HttpGet("{id}")]
		public async Task<ActionResult<UserModelView>> GetUserById(string id)
		{
			try
			{
				// Call service to get shop by ID
				var result = await _userService.GetUserAsync(id);
				return Ok(result);
			}
			catch (Exception ex)
			{
				return NotFound(new { Message = ex.Message });
			}
		}

		// POST: api/Shop
		[HttpPost()]
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

		// PUT: api/Shop/{id}
		[HttpPut("{id}")]
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

		// DELETE: api/Shop/{id}
		[HttpDelete("{id}")]
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
