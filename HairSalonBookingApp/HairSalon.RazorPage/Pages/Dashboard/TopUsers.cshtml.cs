using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using HairSalon.ModelViews.DashboardModelViews;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace HairSalon.RazorPage.Pages.Dashboard
{
	public class TopUsersModel : PageModel
	{
		private readonly IDashboardService _dashboardService;

		// Property to hold the list of top users
		public BasePaginatedList<TopUserModelView> TopUsers { get; set; }

		// Optional property to manage the 'top' filter
		public int? Top { get; set; }

		// Constructor
		public TopUsersModel(IDashboardService dashboardService)
		{
			_dashboardService = dashboardService;
		}

		public async Task OnGet(int? top, int pageNumber = 1, int pageSize = 5)
		{
			// Retrieve user roles from session
			var userRolesJson = HttpContext.Session.GetString("UserRoles");
			if (userRolesJson == null)
			{
				TempData["ErrorMessage"] = "You do not have permission to view this page.";
				RedirectToPage("/Error");
			}

			var userRoles = JsonConvert.DeserializeObject<List<string>>(userRolesJson);

			// Check if the user has "Admin" or "Manager" or "User" roles
			if (!userRoles.Any(role => role == "Admin" || role == "Manager"))
			{
				TempData["DeniedMessage"] = "You do not have permission to view this page.";
                RedirectToPage(); // Redirect to a different page with a denied message
            }
			// Store the value of 'top' in the property for UI use
			Top = top;

			// Call the service method to fetch the paginated top users
			TopUsers = await _dashboardService.GetTopUsersByTotalAmount(top, pageNumber, pageSize);
		}
	}
}
