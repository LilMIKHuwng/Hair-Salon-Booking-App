using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
