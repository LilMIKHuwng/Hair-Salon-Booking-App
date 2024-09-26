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
	public class Service : BaseEntity
	{
		[Required]
		[MaxLength(100)]
		public string Name { get; set; }

		[MaxLength(50)]
		public string Type { get; set; }

		[Required]
		[Column(TypeName = "decimal(10, 2)")]
		public decimal Price { get; set; }

		[MaxLength(255)]
		public string Description { get; set; }

		public string ShopId { get; set; }

		[ForeignKey("ShopId")]
		public Shop Shop { get; set; }

		public virtual ICollection<ServiceAppointment> ServiceAppointments { get; set; }
	}
}
