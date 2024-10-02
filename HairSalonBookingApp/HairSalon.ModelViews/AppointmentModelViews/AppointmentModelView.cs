namespace HairSalon.ModelViews.AppointmentModelViews
{
    public class AppointmentModelView
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string StylistId { get; set; }
        public string StatusForAppointment { get; set; }
        public int PointsEarned { get; set; }
        public DateTime AppointmentDate { get; set; }


    }
}
