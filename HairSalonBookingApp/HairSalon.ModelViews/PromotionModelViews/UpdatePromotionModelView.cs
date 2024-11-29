using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalon.ModelViews.PromotionModelViews
{
    public class UpdatePromotionModelView
    {
        public string Name { get; set; }

        [Range(0, 100, ErrorMessage = "Discount must be between 0% and 100%.")]
        public double? DiscountPercentage { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal? TotalAmount { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal? MaxAmount { get; set; }
        public int? Quantity { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
