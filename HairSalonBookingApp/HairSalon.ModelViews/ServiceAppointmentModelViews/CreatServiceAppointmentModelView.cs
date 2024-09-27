using HairSalon.Contract.Repositories.Entity;

namespace HairSalon.ModelViews.ServiceAppointmentModelViews;


public class CreatServiceAppointmentModelView
{
    public string? ServiceId { get; set; }

    public Service Service { get; set; }

    public string? AppointmentId { get; set; }

    public Appointment Appointment { get; set; }

    public string? Description { get; set; }


    public CreatServiceAppointmentModelView(ServiceAppointment serviceAppointment)
    {
        ServiceId = serviceAppointment.ServiceId;
        Service = serviceAppointment.Service;
        AppointmentId = serviceAppointment.AppointmentId;
        Appointment = serviceAppointment.Appointment;
        Description = serviceAppointment.Description;
    }
}