using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalon.ModelViews.PromotionModelViews
{
    public class PromotionModelView
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double? DiscountPercentage { get; set; }
        public decimal? TotalAmount { get; set; }
        public decimal? MaxAmount { get; set; }
        public int? Quantity { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTimeOffset? CreatedTime { get; set; }
    }
}
