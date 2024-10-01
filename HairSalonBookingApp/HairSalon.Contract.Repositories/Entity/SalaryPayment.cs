using HairSalon.Core.Base;
using HairSalon.Repositories.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HairSalon.Contract.Repositories.Entity
{
	public class SalaryPayment : BaseEntity
	{
		[Required]
		public Guid? UserId { get; set; }

		[ForeignKey("UserId")]

		public virtual ApplicationUser User { get; set; }

		[Required]
		[Column(TypeName = "decimal(10, 2)")]
		public decimal BaseSalary { get; set; }

		[Required]
		public DateTime PaymentDate { get; set; }

	}
}
