using HairSalon.Core.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HairSalon.Contract.Repositories.Entity
{
	public class Payment : BaseEntity
	{
		[Required]
		public string? AppointmentId { get; set; }

		[ForeignKey("AppointmentId")]

		public virtual Appointment Appointment { get; set; }

		[Required]
		[Column(TypeName = "decimal(10, 2)")]
		public decimal TotalAmount { get; set; }

		public DateTime PaymentTime { get; set; } = DateTime.Now;

		[Required]
		[MaxLength(50)]
		public string? PaymentMethod { get; set; }

        public string? BankCode { get; set; }
        public  string? BankTranNo { get; set; }
        public  string? CardType { get; set; }
        public  string? ResponseCode { get; set; }
        public  string? TransactionNo { get; set; }
        public  string? TransactionStatus { get; set; }
        

    }
}
