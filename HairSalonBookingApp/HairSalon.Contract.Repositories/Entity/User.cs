using HairSalon.Core.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HairSalon.Contract.Repositories.Entity
{
	public class User : BaseEntity
	{
		[Required]
		public string RoleId { get; set; }

		[ForeignKey("RoleId")]
		public virtual Role Role { get; set; }

		[Required]
		[MaxLength(100)]
		public string FirstName { get; set; }

		[MaxLength(100)]
		public string LastName { get; set; }

		[Required]
		[MaxLength(100)]
		public string Email { get; set; }

		[Required]
		[MaxLength(255)]
		public string Password { get; set; }

		public int Point { get; set; } = 0;

		[MaxLength(20)]
		public string PhoneNumber { get; set; }

		public virtual ICollection<Appointment> Appointments { get; set; }

		public virtual ICollection<SalaryPayment> SalaryPayments { get; set; }
	}
}
