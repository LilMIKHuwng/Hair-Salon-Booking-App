using HairSalon.Core;
using HairSalon.ModelViews.ComboModelViews;
using HairSalon.ModelViews.DashboardModelViews;
using HairSalon.ModelViews.ServiceModelViews;

namespace HairSalon.Contract.Services.Interface
{
    public interface IDashboardService
    {
        Task<BasePaginatedList<StatisticAppointmentModelView>> GetAppointmentStatistic(string? startPeriod, string? endPeriod, string periodName, int pageNumber, int pageSize);
        Task<BasePaginatedList<TopUserModelView>> GetTopUsersByTotalAmount(int? top, int pageNumber, int pageSize);
        Task<BasePaginatedList<StatisticalComboModelView>> GetStatisticalCombosAsync(int pageNumber, int pageSize, int? month, int? year);
        Task<BasePaginatedList<StatisticalServiceModelView>> MonthlyServiceStatistics(int pageNumber, int pageSize, int? year, int? month);
    }
}
