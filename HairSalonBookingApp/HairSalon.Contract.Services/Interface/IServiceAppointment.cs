using HairSalon.Contract.Repositories.Entity;
using HairSalon.ModelViews.ServiceAppointmentModelViews;

namespace HairSalon.Contract.Services.Interface;

public interface IServiceAppointment
{
    Task<IList<ServiceAppointmentModelView>> GetAllServiceAppointment();
    Task<IList<ServiceAppointmentModelView>> GetAllServiceAppointmentByServiceEntity(Service service);
    Task<IList<ServiceAppointmentModelView>> GetAllServiceAppointmentByAppointmentEntity(Appointment appointment);
    Task<Boolean> DeleteServiceAppointment(String id);
    Task<List<ServiceAppointmentModelView>> GetAllServiceAppointmentByUserEntity(User user);
    Task<Boolean> EditServiceAppointment();
    Task<ServiceAppointment> CreateServiceAppointment(ServiceAppointmentModelView serviceAppointmentModelView);
    Task<ServiceAppointmentModelView> GetServiceAppointmentById(String id);
}