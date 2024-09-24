using HairSalon.Core.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalon.Contract.Repositories.Entity
{
	public class Feedback : BaseEntity
	{
		[Required]
		public string ServiceId { get; set; }

		[ForeignKey("ServiceId")]
		public Service Service { get; set; }

		[Required]
		[Range(1, 5)]
		public int Rate { get; set; }

		public DateTime DateCreate { get; set; } = DateTime.Now;

		[MaxLength(255)]
		public string Comment { get; set; }

		[Required]
		public bool Status { get; set; }
	}
}
