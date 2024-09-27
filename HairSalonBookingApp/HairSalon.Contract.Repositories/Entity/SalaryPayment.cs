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
	public class SalaryPayment : BaseEntity
	{
		[Required]
		public string? UserId { get; set; }

		[ForeignKey("UserId")]
		public User? User { get; set; }

		[Required]
		[Column(TypeName = "decimal(10, 2)")]
		public decimal BaseSalary { get; set; }

		[Required]
		public DateTime PaymentDate { get; set; }

	}
}
