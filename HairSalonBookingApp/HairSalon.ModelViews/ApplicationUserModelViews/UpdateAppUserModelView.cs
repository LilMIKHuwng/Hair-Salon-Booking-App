using Microsoft.AspNetCore.Http;

namespace HairSalon.ModelViews.ApplicationUserModelViews
{
	public class UpdateAppUserModelView
	{
		public string? FirstName { get; set; }

		public string? LastName { get; set; }

		public string? Email { get; set; }

		public string? Password { get; set; }

		public string? PhoneNumber { get; set; }

		public IFormFile? UserImage { get; set; }
	}
}
