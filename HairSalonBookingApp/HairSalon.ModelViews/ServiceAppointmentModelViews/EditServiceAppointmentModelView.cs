namespace HairSalon.ModelViews.ServiceAppointmentModelViews;

public class EditServiceAppointmentModelView
{
    public string Id { get; set; }
    public string ServiceId { get; set; }
    public string AppointmentId { get; set; }
    public string? Description { get; set; }
    public string? LastUpdatedBy { get; set; }
    public DateTimeOffset LastUpdatedTime { get; set; }
    
}