
using System.ComponentModel.DataAnnotations;

namespace HairSalon.ModelViews.AppointmentModelViews
{
    public class UpdateAppointmentModelView
    {
        public string? UserId { get; set; }
		public string? StylistId { get; set; }
        public string? StatusForAppointment { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "PointsEarned must be a positive number.")]
        public int? PointsEarned { get; set; }
        public DateTime? AppointmentDate { get; set; }
    }
}
