using System.ComponentModel.DataAnnotations;

namespace HairSalon.ModelViews.AppointmentModelViews
{
    public class CreateAppointmentModelView
    {
        [Required(ErrorMessage = "UserId is required.")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "StylistId is required.")]
        public string StylistId { get; set; }

        [Required(ErrorMessage = "List services is required.")]
        public string[] ServiceIds { get; set; }

        [Required(ErrorMessage = "PointsEarned is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "PointsEarned must be a positive number.")]
        public int PointsEarned { get; set; }

        [Required(ErrorMessage = "AppointmentDate is required.")]
        public DateTime AppointmentDate { get; set; }
        [Required(ErrorMessage = "ServiceIds is required.")]
        public List<string> ServiceIds { get; set; }
    }
}
