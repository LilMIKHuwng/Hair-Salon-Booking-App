using HairSalon.Contract.Repositories.Entity;
using HairSalon.Core.Utils;
using Microsoft.AspNetCore.Identity;

namespace HairSalon.Repositories.Entity
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string Password {  get; set; } = string.Empty;
        public string UserInfoId { get; set; }
        public virtual UserInfo? UserInfo { get; set; }
        public string? CreatedBy { get; set; }
        public string? LastUpdatedBy { get; set; }
        public string? DeletedBy { get; set; }
        public DateTimeOffset CreatedTime { get; set; }
        public DateTimeOffset LastUpdatedTime { get; set; }
        public DateTimeOffset? DeletedTime { get; set; }
        public ApplicationUser()
        {
            CreatedTime = CoreHelper.SystemTimeNow;
            LastUpdatedTime = CreatedTime;
        }
    }
}
