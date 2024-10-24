using Microsoft.AspNetCore.Http;

namespace HairSalon.ModelViews.ComboModelViews
{
    public class UpdateComboModelView
    {
        public string? Name { get; set; } // Không có thuộc tính [Required]
		public string[]? ServiceIds { get; set; }
        public IFormFile? ComboImage { get; set; }
	}
}
