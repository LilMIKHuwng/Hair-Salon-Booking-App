using HairSalon.Core;
using HairSalon.ModelViews.AppointmentModelViews;
using System.Security.Claims;

namespace HairSalon.Contract.Services.Interface
{
    public interface IAppointmentService
    {
        Task<string> AddAppointmentAsync(CreateAppointmentModelView model);
        Task<BasePaginatedList<AppointmentModelView>> GetAllAppointmentAsync(int pageNumber, int pageSize, DateTime? startDate, DateTime? endDate);
        Task<AppointmentModelView> GetAppointmentAsync(string id);
        Task<string> UpdateAppointmentAsync(string id, UpdateAppointmentModelView model);
        Task<string> DeleteAppointmentAsync(string id);
    }
}
