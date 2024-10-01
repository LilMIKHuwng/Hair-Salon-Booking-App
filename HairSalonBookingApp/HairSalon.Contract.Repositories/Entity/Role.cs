using HairSalon.Core.Base;
using System.ComponentModel.DataAnnotations;

namespace HairSalon.Contract.Repositories.Entity
{
	public class Role : BaseEntity
	{
		[Required]
		[MaxLength(100)]
		public string? RoleName { get; set; }

		[MaxLength(255)]
		public string? Description { get; set; }

		public virtual ICollection<UserInfo>? Users { get; set; }
	}
}
