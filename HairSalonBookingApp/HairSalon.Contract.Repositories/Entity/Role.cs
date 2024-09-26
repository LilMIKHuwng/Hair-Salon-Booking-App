using HairSalon.Core.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalon.Contract.Repositories.Entity
{
	public class Role : BaseEntity
	{
		[Required]
		[MaxLength(100)]
		public string RoleName { get; set; }

		[MaxLength(255)]
		public string Description { get; set; }

		public virtual ICollection<User> Users { get; set; }
	}
}
