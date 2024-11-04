using HairSalon.Core.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HairSalon.Contract.Repositories.Entity
{
	public class Combo : BaseEntity
	{
		[Required]
		[MaxLength(100)]
		public string Name { get; set; }

		[Required]
		[Column(TypeName = "decimal(10, 2)")]
		public decimal TotalPrice { get; set; }

		[Required]
		public int TimeCombo { get; set; }

		public string? ComboImage { get; set; }

		public virtual ICollection<ComboAppointment>? ComboAppointments { get; set; }

		public virtual ICollection<ComboServices>? ComboServices { get; set; }
	}
}
