using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using HairSalon.ModelViews.ApplicationUserModelViews;
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

        [HttpPost("register")]
        public async Task<ActionResult<string>> CreateAppUser([FromQuery] CreateAppUserModelView model)
        {
            string result = await _appUserService.AddAppUserAsync(model);
            return Ok(result);
        }

		[HttpGet("all")]
		public async Task<ActionResult<BasePaginatedList<AppUserModelView>>> GetAllApplicationUsers(
	                                                                                        int pageNumber = 1,
	                                                                                        int pageSize = 5,
	                                                                                        [FromQuery] string? id = null,
	                                                                                        [FromQuery] string? email = null,
	                                                                                        [FromQuery] string? phoneNumber = null)
		{
			var result = await _appUserService.GetAllAppUserAsync(pageNumber, pageSize, id, email, phoneNumber);
			return Ok(result);
		}

		[HttpPut("{id}")]
        public async Task<IActionResult> UpdateApplicationUser(string id, [FromQuery] UpdateAppUserModelView model)
        {
            string result = await _appUserService.UpdateAppUserAsync(id, model);
            return Ok(result);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApplicationUser(string id)
        {
            string result = await _appUserService.DeleteAppUserAsync(id);
            return Ok(result);
        }
    }
}
