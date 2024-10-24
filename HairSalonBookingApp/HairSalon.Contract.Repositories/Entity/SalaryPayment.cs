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

		public virtual ApplicationUsers User { get; set; }

		[Required]
		[Column(TypeName = "decimal(10, 2)")]
		public decimal BaseSalary { get; set; }

		[Required]
		public DateTime PaymentDate { get; set; }

		[Required]
		public int DayOffPermitted { get; set; }

		[Required]
		public int DayOffNoPermitted { get; set; }

		[Required]
		[Column(TypeName = "decimal(10, 2)")]
		public decimal DeductedSalary { get; set; }

		[Required]
		[Column(TypeName = "decimal(10, 2)")]
		public decimal BonusSalary { get; set; }


	}
}
