using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using HairSalon.ModelViews.DashboardModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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

        public async Task OnGet()
        {
            // Gọi service để lấy dữ liệu thống kê dựa trên các tham số truy vấn từ form
            AppointmentStatistics = await _dashboardService.GetAppointmentStatistic(StartPeriod, EndPeriod, PeriodName, PageNumber, 10);
        }
    }
}
