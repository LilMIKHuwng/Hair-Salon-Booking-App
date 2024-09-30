using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalon.ModelViews.UserModelViews
{
	public class UpdateUserModelView
	{
		[Required(ErrorMessage = "Role is required.")]
		public string RoleId { get; set; }

		[Required(ErrorMessage = "First Name is required.")]
		public string FirstName { get; set; }

		[Required(ErrorMessage = "Last Name is required.")]
		public string LastName { get; set; }

		[Required(ErrorMessage = "Email is required.")]
		[EmailAddress(ErrorMessage = "Invalid Email Address.")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Password is required.")]
		public string Password { get; set; }

		public int Point { get; set; } = 0;

		[Required(ErrorMessage = "Phone number is required.")]
		[Phone(ErrorMessage = "Invalid Phone Number.")]
		[StringLength(20, ErrorMessage = "Phone number cannot be longer than 20 characters.")]
		public string PhoneNumber { get; set; }
	}
}
