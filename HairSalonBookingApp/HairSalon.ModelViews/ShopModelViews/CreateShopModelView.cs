using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace HairSalon.ModelViews.ShopModelViews
{
    public class CreateShopModelView
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; } 

        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; } 

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string ShopEmail { get; set; } 

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid Phone Number.")]
        [StringLength(20, ErrorMessage = "Phone number cannot be longer than 20 characters.")]
        public string ShopPhone { get; set; }

        [Required(ErrorMessage = "Open Time is required.")]
        public TimeSpan OpenTime { get; set; }

        [Required(ErrorMessage = "Close Time is required.")]
        public TimeSpan CloseTime { get; set; } 

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, ErrorMessage = "Title cannot be longer than 100 characters.")]
        public string Title { get; set; }

        /*[Required(ErrorMessage = "Cần Thêm Hình Loại Sản Phẩm")]*/
        public IFormFile ShopImage { get; set; }
    }
}
