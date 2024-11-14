using System.ComponentModel.DataAnnotations;

namespace HairSalon.ModelViews.AppointmentModelViews
{
    public class CreateAppointmentModelView
    {
        public string? StylistId { get; set; }
        public string[]? ServiceIds { get; set; }
        public string[]? ComboIds { get; set; }

        [Required(ErrorMessage = "PointsEarned is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "PointsEarned must be a positive number.")]
        public int PointsEarned { get; set; }

        [Required(ErrorMessage = "AppointmentDate is required.")]
        public DateTime AppointmentDate { get; set; }
    }
}
