using HairSalon.Core.Utils;
using HairSalon.Repositories.Entity;
using Microsoft.AspNetCore.Identity;


namespace HairSalon.Contract.Repositories.Entity
{
    public class ApplicationUserRoles : IdentityUserRole<Guid>
    {
        public string? CreatedBy { get; set; }
        public string? LastUpdatedBy { get; set; }
        public string? DeletedBy { get; set; }
        public DateTimeOffset CreatedTime { get; set; }
        public DateTimeOffset LastUpdatedTime { get; set; }
        public DateTimeOffset? DeletedTime { get; set; }
        public virtual ApplicationRoles Role { get; set; }
        public virtual ApplicationUsers User { get; set; }

        public ApplicationUserRoles()
        {
            CreatedTime = CoreHelper.SystemTimeNow;
            LastUpdatedTime = CreatedTime;
        }
    }
}
