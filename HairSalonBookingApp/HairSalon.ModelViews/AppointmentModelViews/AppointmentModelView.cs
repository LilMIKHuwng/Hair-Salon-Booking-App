namespace HairSalon.ModelViews.AppointmentModelViews
{
    public class AppointmentModelView
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string StylistId { get; set; }
        public string StatusForAppointment { get; set; }
        public int PointsEarned { get; set; }
		public int TotalTime { get; set; }
		public decimal TotalAmount { get; set; }
		public DateTime AppointmentDate { get; set; }
        public string UserName { get; set; }
    }
}
