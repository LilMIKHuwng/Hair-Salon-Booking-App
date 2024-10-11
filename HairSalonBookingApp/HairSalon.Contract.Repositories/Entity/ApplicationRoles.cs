using HairSalon.Core.Utils;
using Microsoft.AspNetCore.Identity;

namespace HairSalon.Contract.Repositories.Entity
{
    public class ApplicationRoles : IdentityRole<Guid>
    {
        public string? CreatedBy { get; set; }
        public string? LastUpdatedBy { get; set; }
        public string? DeletedBy { get; set; }
        public DateTimeOffset CreatedTime { get; set; }
        public DateTimeOffset LastUpdatedTime { get; set; }
        public DateTimeOffset? DeletedTime { get; set; }

        public virtual ICollection<ApplicationUserRoles> UserRoles { get; set; }

        public ApplicationRoles()
        {
            CreatedTime = CoreHelper.SystemTimeNow;
            LastUpdatedTime = CreatedTime;
        }

    }
}