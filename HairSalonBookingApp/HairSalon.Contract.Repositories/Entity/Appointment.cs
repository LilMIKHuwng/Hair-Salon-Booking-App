using HairSalon.Core.Base;
using HairSalon.Repositories.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HairSalon.Contract.Repositories.Entity
{
	public class Appointment : BaseEntity
	{
		[Required]
		public Guid? UserId { get; set; }

		[ForeignKey("UserId")]

		public virtual ApplicationUsers User { get; set; }

		public Guid? StylistId { get; set; }
		public virtual ApplicationUsers Stylist { get; set; }

        [MaxLength(50)]
		public string? StatusForAppointment { get; set; }

		public int PointsEarned { get; set; } = 0;

		public int TotalTime {  get; set; }

		[Required]
		[Column(TypeName = "decimal(10, 2)")]
		public decimal TotalAmount { get; set; }

		[Required]
		public DateTime AppointmentDate { get; set; }
		
		public virtual ICollection<ServiceAppointment>? ServiceAppointments { get; set; }
		public virtual ICollection<ComboAppointment>? ComboAppointments { get; set; }

		public virtual Payment? Payment { get; set; }
		public virtual Feedback? Feedback { get; set; }
	}
}
