using HairSalon.Contract.Repositories.Entity;

namespace HairSalon.ModelViews.ServiceAppointmentModelViews;

public class ServiceAppointmentModelView
{
    public string? ServiceId { get; set; }
    public string? AppointmentId { get; set; }
    public string? Description { get; set; }
    public DateTimeOffset CreatedTime { get; set; }
    public string? CreatedBy { get; set; }
    public Service Service { get; set; }
    public Appointment Appointment { get; set; }

    public ServiceAppointmentModelView(ServiceAppointment serviceAppointment)
    {
        ServiceId = serviceAppointment.ServiceId;
        AppointmentId = serviceAppointment.AppointmentId;
        Description = serviceAppointment.Description;
        Service = serviceAppointment.Service;
        Appointment = serviceAppointment.Appointment;
        CreatedTime = serviceAppointment.CreatedTime;
        CreatedBy = serviceAppointment.CreatedBy;
    }
}