namespace HairSalon.ModelViews.ApplicationUserModelViews
{
    public class ResetPasswordModelView
    {
        public string Email { get; set; }
        public string OtpCode { get; set; }
        public DateTime? OtpExpiration { get; set; }
        public string NewPassword { get; set; }
    }
}

