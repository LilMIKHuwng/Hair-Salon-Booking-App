using System.ComponentModel.DataAnnotations;

namespace HairSalon.ModelViews.ServiceModelViews
{
    public class UpdatedServiceModelView
    {
        public string? Name { get; set; }

        public string? Type { get; set; }

        public decimal? Price { get; set; }

        public string? Description { get; set; }

        public string? ShopId { get; set; }
    }
}
