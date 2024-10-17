using HairSalon.Core;
using HairSalon.ModelViews.AppointmentModelViews;

namespace HairSalon.Contract.Services.Interface
{
    public interface IAppointmentService
    {
        Task<string> AddAppointmentAsync(CreateAppointmentModelView model);
        Task<BasePaginatedList<AppointmentModelView>> GetAllAppointmentAsync(int pageNumber, int pageSize, DateTime? startDate, DateTime? endDate, string? id);
        Task<string> UpdateAppointmentAsync(string id, UpdateAppointmentModelView model);
        Task<string> DeleteAppointmentAsync(string id);
        Task<string> MarkCompleted(string id);
        Task<string> MarkConfirmed(string id);
    }
}
