using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalon.ModelViews.PromotionModelViews
{
    public class CreatePromotionModelView
    {
        [Required]
        public string Name { get; set; }

		[Required]
		[Range(0, 100, ErrorMessage = "Discount must be between 0% and 100%.")]
        public double DiscountPercentage { get; set; }

		[Required]
		[Range(0, double.MaxValue, ErrorMessage = "Total Amount must be greater than 0.")]
		[Column(TypeName = "decimal(10, 2)")]
		public decimal TotalAmount { get; set; }

		[Required]
		[Range(0, double.MaxValue, ErrorMessage = "Max Amount must be greater than 0.")]
		[Column(TypeName = "decimal(10, 2)")]
		public decimal MaxAmount { get; set; }

		[Required]
		[Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
		public int Quantity { get; set; }

        [Required]
        public DateTime ExpiryDate { get; set; }
    }
}
