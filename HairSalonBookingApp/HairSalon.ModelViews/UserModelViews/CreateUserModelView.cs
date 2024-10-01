using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalon.ModelViews.UserModelViews
{
	public class CreateUserModelView
	{
		[Required(ErrorMessage = "Fullname is required.")]
		public string FullName { get; set; }

		[Required(ErrorMessage = "Bank Account is required.")]
		public string BankAccount { get; set; }

		[Required(ErrorMessage = "Bank Account Name is required.")]
		public string BankAccountName { get; set; }

		[Required(ErrorMessage = "Bank is required.")]
		public string Bank { get; set; }
		public int Point { get; set; } = 0;
	}
}
