namespace HairSalon.ModelViews.ApplicationUserModelViews
{
    public class ConfirmEmailModelView
    {
        public string Email { get; set; }
        public string OtpCode { get; set; }
        public DateTime? OtpExpiration { get; set; }
    }
}
