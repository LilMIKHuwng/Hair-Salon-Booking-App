using HairSalon.Contract.Repositories.Entity;
using HairSalon.ModelViews.ServiceAppointmentModelViews;

namespace HairSalon.Contract.Services.Interface;

public interface IServiceAppointment
{
    Task<IList<ServiceAppointmentModelView>> GetAllServiceAppointment();
    Task<IList<ServiceAppointmentModelView>> GetAllServiceAppointmentByServiceId(string serviceId);
    Task<IList<ServiceAppointmentModelView>> GetAllServiceAppointmentByAppointmentID(string appointmentId);
    Task<Boolean> DeleteServiceAppointment(DeleteServiceAppointmentModelView deleteServiceAppointmentModelView);
    Task<List<ServiceAppointmentModelView>> GetAllServiceAppointmentByUserId(string userId);
    Task<Boolean> EditServiceAppointment(EditServiceAppointmentModelView editServiceAppointmentModelView);
    Task<ServiceAppointment> CreateServiceAppointment(CreatServiceAppointmentModelView creatServiceAppointmentModelView);
    Task<ServiceAppointmentModelView> GetServiceAppointmentById(String id);
}