using System.ComponentModel.DataAnnotations;

namespace HairSalon.ModelViews.AppointmentModelViews
{
    public class UpdateAppointmentModelView
    {
		public string? StylistId { get; set; }
        public string[]? ServiceIds { get; set; }
        public string[]? ComboIds { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "PointsEarned must be a positive number.")]
        public int? PointsEarned { get; set; }
        public DateTime? AppointmentDate { get; set; }
    }
}
