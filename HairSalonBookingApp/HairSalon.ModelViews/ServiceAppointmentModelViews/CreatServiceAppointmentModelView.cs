using System.ComponentModel.DataAnnotations;

namespace HairSalon.ModelViews.ServiceAppointmentModelViews;


public class CreatServiceAppointmentModelView
{
	[Required(ErrorMessage = "ServiceId is required.")]
	public string ServiceId { get; set; }

	[Required(ErrorMessage = "AppointmentId is required.")]
	public string AppointmentId { get; set; }

	public string? Description { get; set; }

	[Range(1, 5, ErrorMessage = "Rate must be between 1 and 5.")]
	public int? Rate { get; set; }

	[MaxLength(255, ErrorMessage = "Comment cannot exceed 255 characters.")]
	public string? Comment { get; set; }
}