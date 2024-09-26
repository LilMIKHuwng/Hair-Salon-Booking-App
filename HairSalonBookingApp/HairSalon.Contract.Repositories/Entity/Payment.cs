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
	public class Payment : BaseEntity
	{
		[Required]
		public string AppointmentId { get; set; }

		[ForeignKey("AppointmentId")]
		public Appointment Appointment { get; set; }

		[Required]
		[Column(TypeName = "decimal(10, 2)")]
		public decimal TotalAmount { get; set; }

		public DateTime PaymentTime { get; set; } = DateTime.Now;

		[Required]
		[MaxLength(50)]
		public string PaymentMethod { get; set; }

	}
}
