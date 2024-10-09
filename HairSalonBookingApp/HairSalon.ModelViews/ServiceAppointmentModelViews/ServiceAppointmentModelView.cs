namespace HairSalon.ModelViews.ServiceAppointmentModelViews;

public class ServiceAppointmentModelView
{
    public string Id { get; set; }
    public string ServiceId { get; set; }
    public string AppointmentId { get; set; }
    public string Description { get; set; }
    public int Rate { get; set; }
    public string Comment { get; set; }
}