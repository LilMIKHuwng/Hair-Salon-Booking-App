using HairSalon.Core.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HairSalon.Contract.Repositories.Entity
{
	public class Feedback : BaseEntity
	{
		[Required]
		public string ServiceId { get; set; }

		[ForeignKey("ServiceId")]
		public virtual Service Service { get; set; }

		[Required]
		[Range(1, 5)]
		public int Rate { get; set; }

		[MaxLength(255)]
		public string Comment { get; set; }

	}
}
