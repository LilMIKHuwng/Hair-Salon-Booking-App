using Microsoft.AspNetCore.Http;

namespace HairSalon.ModelViews.ShopModelViews
{
    public class UpdatedShopModelView
    {
        public string? Name { get; set; }

        public string? Address { get; set; }

        public string? ShopEmail { get; set; }

        public string? ShopPhone { get; set; }

        public TimeSpan? OpenTime { get; set; }

        public TimeSpan? CloseTime { get; set; }

        public string? Title { get; set; }

        public IFormFile? ShopImage { get; set; }

    }
}
