
namespace HairSalon.ModelViews.AppointmentModelViews
{
    public class UpdateAppointmentModelView
    {
		public string StylistId { get; set; }
        public string StatusForAppointment { get; set; }
        public int PointsEarned { get; set; }
        public DateTime AppointmentDate { get; set; }
    }
}
