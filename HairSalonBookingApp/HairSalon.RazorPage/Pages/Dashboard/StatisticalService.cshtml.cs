using HairSalon.Contract.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace HairSalon.RazorPage.Pages.Dashboard
{
    public class StatisticalServiceModel : PageModel
    {
        private readonly IDashboardService _dashBoardService;

        public List<string> ServiceNames { get; set; } = new List<string>();
        public List<int> ServiceCounts { get; set; } = new List<int>();

        public bool NoDataForSelectedMonth { get; set; } = false;

        [TempData]
        public string ResponseMessage { get; set; }

        [FromQuery]
        public int? InputMonth { get; set; }

        [FromQuery]
        public int? InputYear { get; set; }

        public StatisticalServiceModel(IDashboardService dashboardService)
        {
            _dashBoardService = dashboardService;
        }

        public async Task<IActionResult> OnGetAsync(int pageNumber = 1, int pageSize = 10)
        {
			// Retrieve user roles from session
			var userRolesJson = HttpContext.Session.GetString("UserRoles");
			if (userRolesJson == null)
			{
				TempData["ErrorMessage"] = "You do not have permission to view this page.";
				return RedirectToPage("/Error");
			}

			var userRoles = JsonConvert.DeserializeObject<List<string>>(userRolesJson);

			// Check if the user has "Admin" or "Manager" or "User" roles
			if (!userRoles.Any(role => role == "Admin" || role == "Manager"))
			{
				TempData["DeniedMessage"] = "You do not have permission to view this page.";
				return Page(); // Redirect to a different page with a denied message
			}

			var result = await _dashBoardService.MonthlyServiceStatistics(pageNumber, pageSize, InputMonth, InputYear);
            if (!result.Items.Any())
            {
                NoDataForSelectedMonth = true;
            }
            else
            {
                foreach (var service in result.Items)
                {
                    ServiceNames.Add(service.ServiceName);
                    ServiceCounts.Add(service.UsageCount);
                }
                NoDataForSelectedMonth = false;
            }

            return Page();
        }
    }
}
