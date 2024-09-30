using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalon.ModelViews.UserModelViews
{
	public class UserModelView
	{
		public string Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public int Point { get; set; } = 0;
		public string PhoneNumber { get; set; }

		//public virtual RoleViewModel RoleVm { get; set; }
	}
}
