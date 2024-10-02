using HairSalon.Core;
using HairSalon.ModelViews.AppointmentModelViews;

namespace HairSalon.Contract.Services.Interface
{
    public interface IAppointmentService
    {
        Task<AppointmentModelView> AddAppointmentAsync(CreateAppointmentModelView model);
        Task<BasePaginatedList<AppointmentModelView>> GetAllAppointmentAsync(int pageNumber, int pageSize);
        Task<AppointmentModelView> GetAppointmentAsync(string id);
        Task<AppointmentModelView> UpdateAppointmentAsync(string id, UpdateAppointmentModelView model);
        Task<string> DeleteAppointmentAsync(string id);
    }
}
