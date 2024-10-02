using System.ComponentModel.DataAnnotations;

namespace HairSalon.ModelViews.ApplicationUserModelViews
{
	public class UpdateAppUserModelView
	{
		[Required(ErrorMessage = "UserInfo is required.")]
		public string UserInfoId { get; set; }

		[Required(ErrorMessage = "Email is required.")]
		[EmailAddress(ErrorMessage = "Invalid Email Address.")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Password is required.")]
		public string Password { get; set; }

		[Required(ErrorMessage = "Phone number is required.")]
		[Phone(ErrorMessage = "Invalid Phone Number.")]
		[StringLength(20, ErrorMessage = "Phone number cannot be longer than 20 characters.")]
		public string PhoneNumber { get; set; }
	}
}
