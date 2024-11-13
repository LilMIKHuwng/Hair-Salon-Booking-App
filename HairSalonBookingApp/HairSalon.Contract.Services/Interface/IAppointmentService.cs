using HairSalon.Contract.Repositories.Entity;
using HairSalon.Core;
using HairSalon.ModelViews.AppointmentModelViews;

namespace HairSalon.Contract.Services.Interface
{
    public interface IAppointmentService
    {
        Task<string> AddAppointmentAsync(CreateAppointmentModelView model, string? userId);
        Task<BasePaginatedList<AppointmentModelView>> GetAllAppointmentAsync(int pageNumber, int pageSize, DateTime? startDate, DateTime? endDate, string? id, Guid? userId, Guid? stylistId, string? statusForAppointment);
        Task<string> UpdateAppointmentAsync(string id, UpdateAppointmentModelView model, string? userId);
        Task<string> DeleteAppointmentAsync(string id, string? userId);
        Task<string> MarkCompleted(string id, string? userId);
        Task<string> MarkConfirmed(string id, string? userId);
        Task<AppointmentModelView?> GetAppointmentByIdAsync(string id);
        Task<List<ServiceAppointment>> GetAllServiceAppointment(string appointmentId);
        Task<List<ComboAppointment>> GetAllComboAppointment(string appointmentId);
        Task<List<AppointmentModelView>> GetAppointmentsForDropdownAsync();
        Task<List<AppointmentModelView>> GetAppointmentsByUserIdAsync(string userId);
    }
}
