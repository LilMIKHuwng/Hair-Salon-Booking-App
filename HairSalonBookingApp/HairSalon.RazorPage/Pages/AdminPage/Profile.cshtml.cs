using HairSalon.Contract.Services.Interface;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HairSalon.ModelViews.ApplicationUserModelViews;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HairSalon.RazorPage.Pages.AdminPage
{
	public class AdminProfilePageModel : PageModel
	{
		private readonly IAppUserService _userService;

		public AdminProfilePageModel(IAppUserService userService)
		{
			_userService = userService;
		}

		public GetInforAppUserModelView UserInfo { get; set; }

		public async Task<IActionResult> OnGetAsync()
		{
			var userRolesJson = HttpContext.Session.GetString("UserRoles");

			if (userRolesJson == null)
			{
				TempData["ErrorMessage"] = "You do not have permission to view this page.";
				return Page();
			}

			var userRoles = JsonConvert.DeserializeObject<List<string>>(userRolesJson);

			// Retrieve Username from session
			var username = HttpContext.Session.GetString("Username");

			// Use Username to get user information
			UserInfo = await _userService.GetMyInforUsersAsync(username);
			if (UserInfo == null)
			{
				TempData["ErrorMessage"] = "Failed to retrieve user information";
				return Page();
			}

			return Page();
		}
	}
}
