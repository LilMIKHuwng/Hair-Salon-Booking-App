namespace HairSalon.ModelViews.ServiceAppointmentModelViews;


public class CreatServiceAppointmentModelView
{
    public string? ServiceId { get; set; }
    
    public string? AppointmentId { get; set; }
    
    public string? Description { get; set; }

    public string? CreatedBy { get; set; }
    
    public DateTimeOffset CreatedTime { get; set; }
    
}