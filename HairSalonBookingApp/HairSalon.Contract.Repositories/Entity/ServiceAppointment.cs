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
	public class ServiceAppointment : BaseEntity
	{
		public string ServiceId { get; set; }

		[ForeignKey("ServiceId")]
		public Service Service { get; set; }

		public string AppointmentId { get; set; }

		[ForeignKey("AppointmentId")]
		public Appointment Appointment { get; set; }

		[MaxLength(255)]
		public string Description { get; set; }
	}
}
