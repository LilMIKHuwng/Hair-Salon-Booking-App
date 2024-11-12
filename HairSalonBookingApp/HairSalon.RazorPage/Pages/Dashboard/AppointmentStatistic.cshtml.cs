using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using HairSalon.ModelViews.DashboardModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace HairSalon.RazorPage.Pages.Dashboard
{
    public class AppointmentStatisticModel : PageModel
    {
        private readonly IDashboardService _dashboardService;

        public AppointmentStatisticModel(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [BindProperty(SupportsGet = true)]
        public string? StartPeriod { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? EndPeriod { get; set; }

        [BindProperty(SupportsGet = true)]
        public string PeriodName { get; set; } = "month";

        [BindProperty(SupportsGet = true)]
        public int PageNumber { get; set; } = 1;

        public BasePaginatedList<StatisticAppointmentModelView> AppointmentStatistics { get; set; }

        public async Task OnGetAsync()
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
			// Gọi service để lấy dữ liệu thống kê dựa trên các tham số truy vấn từ form
			AppointmentStatistics = await _dashboardService.GetAppointmentStatistic(StartPeriod, EndPeriod, PeriodName, PageNumber, 10);
        }
    }
}
