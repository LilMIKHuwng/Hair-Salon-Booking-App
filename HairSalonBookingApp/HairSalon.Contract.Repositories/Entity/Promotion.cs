using HairSalon.Core.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HairSalon.Contract.Repositories.Entity
{
    public class Promotion : BaseEntity
    {
        [Required]
        public string Name { get; set; } 

        [Range(0, 100, ErrorMessage = "Discount must be between 0% and 100%.")]
        public double? DiscountPercentage { get; set; } 

        [Column(TypeName = "decimal(10, 2)")]
        public decimal? TotalAmount { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal? MaxAmount { get; set; } 

        public int? Quantity { get; set; }

        [Required]
        public DateTime ExpiryDate { get; set; }

        public virtual ICollection<Appointment>? Appointments { get; set; } = [];

    }
}
