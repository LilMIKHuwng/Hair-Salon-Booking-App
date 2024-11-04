using HairSalon.Contract.Repositories.Entity;
using HairSalon.Core.Utils;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HairSalon.Repositories.Entity
{
    public class ApplicationUsers : IdentityUser<Guid>
    {
        public string Password {  get; set; } = string.Empty;

		[Required]
		[Column(TypeName = "decimal(10, 2)")]
		public decimal E_Wallet { get; set; }

		public string UserInfoId { get; set; }
        public virtual UserInfo? UserInfo { get; set; }
		public string? UserImage { get; set; }
		public string? CreatedBy { get; set; }
        public string? LastUpdatedBy { get; set; }
        public string? DeletedBy { get; set; }
        public DateTimeOffset CreatedTime { get; set; }
        public DateTimeOffset LastUpdatedTime { get; set; }
        public DateTimeOffset? DeletedTime { get; set; }
        public string? OtpCode { get; set; }
        public DateTime? OtpExpiration { get; set; }
        public string? OtpCodeResetPassword { get; set; }
        public DateTime? OtpExpirationResetPassword { get; set; }
        public string? RefreshToken { get; set; }
        public DateTimeOffset RefreshTokenExpiryTime { get; set; }

        public ApplicationUsers()
        {
            CreatedTime = CoreHelper.SystemTimeNow;
            LastUpdatedTime = CreatedTime;
        }
        public virtual ICollection<ApplicationUserRoles> UserRoles { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<SalaryPayment> SalaryPayments { get; set; }
        public virtual ICollection<Message> MessageSent { get; set; }
        public virtual ICollection<Message> MessageReceived { get; set; }
        
    }
}
