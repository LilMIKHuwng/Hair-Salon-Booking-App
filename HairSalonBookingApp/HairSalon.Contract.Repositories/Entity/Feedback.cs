using HairSalon.Core.Base;
using HairSalon.Core.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalon.Contract.Repositories.Entity
{
    public class Feedback : BaseEntity
    {

		[Required]
		public string? AppointmentId { get; set; }

		[ForeignKey("AppointmentId")]

		public virtual Appointment Appointment { get; set; }

		[Range(1, 5)]
		public int? Rate { get; set; }

		[MaxLength(255)]
		public string? Comment { get; set; }
		public Feedback()
        {
            CreatedTime = CoreHelper.SystemTimeNow;
            LastUpdatedTime = CreatedTime;
        }
    }
}
