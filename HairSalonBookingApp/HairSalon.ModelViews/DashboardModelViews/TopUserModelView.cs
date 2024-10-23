namespace HairSalon.ModelViews.DashboardModelViews
{
    public class TopUserModelView
    {
        public Guid? UserId { get; set; }
        public string UserName { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalFeedback { get; set; }
        public int TotalAppointment { get; set; }
    }

}
