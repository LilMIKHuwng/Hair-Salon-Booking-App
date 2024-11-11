using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using HairSalon.ModelViews.DashboardModelViews;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
			// Store the value of 'top' in the property for UI use
			Top = top;

			// Call the service method to fetch the paginated top users
			TopUsers = await _dashboardService.GetTopUsersByTotalAmount(top, pageNumber, pageSize);
		}
	}
}
