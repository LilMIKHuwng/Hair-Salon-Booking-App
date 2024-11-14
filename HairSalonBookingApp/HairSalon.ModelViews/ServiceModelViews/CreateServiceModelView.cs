using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace HairSalon.ModelViews.ServiceModelViews
{
    public class CreateServiceModelView
    {
        [Required(ErrorMessage ="Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Type is required.")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        public decimal Price { get; set; }

        public string? Description { get; set; }

        [Required(ErrorMessage = "TimeService is required.")]
        public int TimeService { get; set; }

        [Required(ErrorMessage = "Shop Id is required.")]
        public string ShopId { get; set; }

        [Required(ErrorMessage = "Service Image is required.")]
        public IFormFile ServiceImage { get; set; }
    }

}
