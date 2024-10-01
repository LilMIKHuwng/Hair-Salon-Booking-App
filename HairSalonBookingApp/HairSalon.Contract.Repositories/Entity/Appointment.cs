using HairSalon.Core.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HairSalon.Contract.Repositories.Entity
{
	public class Appointment : BaseEntity
	{
		[Required]
		public string UserId { get; set; }

		[ForeignKey("UserId")]
		public virtual UserInfo User { get; set; }

		// StylistId là một khóa ngoại tham chiếu đến bảng User
		public string? StylistId { get; set; }

		// Tham chiếu đến Stylist trong bảng User
		public virtual UserInfo Stylist { get; set; } // Mối quan hệ sẽ được cấu hình trong OnModelCreating

		[MaxLength(50)]
		public string StatusForAppointment { get; set; }

		public int PointsEarned { get; set; } = 0;

		[Required]
		public DateTime AppointmentDate { get; set; }

		public virtual ICollection<ServiceAppointment> ServiceAppointments { get; set; }
	}
}
