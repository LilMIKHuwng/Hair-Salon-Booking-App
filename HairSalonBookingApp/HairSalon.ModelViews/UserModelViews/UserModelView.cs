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
		public string FullName { get; set; }
		public string BankAccount { get; set; }
		public string BankAccountName { get; set; }
		public string Bank { get; set; }
		public int Point { get; set; }
	}
}
