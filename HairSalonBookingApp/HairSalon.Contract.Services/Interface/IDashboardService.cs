using HairSalon.ModelViews.DashboardModelViews;

namespace HairSalon.Contract.Services.Interface
{
    public interface IDashboardService
    {
        Task<IEnumerable<StatisticAppointmentModelView>> GetAppointmentStatistic(string? startPeriod, string? endPeriod, string periodName);
    }
}
