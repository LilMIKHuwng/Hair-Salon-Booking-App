using HairSalon.Core.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalon.Contract.Repositories.Entity
{
	public class ComboServices : BaseEntity
	{
		public string ServiceId { get; set; }

		[ForeignKey("ServiceId")]
		public virtual Service Service { get; set; }

		public string ComboId { get; set; }

		[ForeignKey("ComboId")]
		public virtual Combo Combo { get; set; }
	}
}
