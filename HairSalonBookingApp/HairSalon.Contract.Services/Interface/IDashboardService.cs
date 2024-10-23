using HairSalon.Core;
using HairSalon.ModelViews.DashboardModelViews;

namespace HairSalon.Contract.Services.Interface
{
    public interface IDashboardService
    {
        Task<BasePaginatedList<StatisticAppointmentModelView>> GetAppointmentStatistic(string? startPeriod, string? endPeriod, string periodName, int pageNumber, int pageSize);
        Task<BasePaginatedList<TopUserModelView>> GetTopUsersByTotalAmount(int? top, int pageNumber, int pageSize);
    }
}
