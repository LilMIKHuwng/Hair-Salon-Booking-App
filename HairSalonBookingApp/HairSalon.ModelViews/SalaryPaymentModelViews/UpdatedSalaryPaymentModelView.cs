using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalon.ModelViews.SalaryPaymentModelViews
{
    public class UpdatedSalaryPaymentModelView
    {
		[Required(ErrorMessage = "User ID is required.")]
		public string UserId { get; set; }
		[Required(ErrorMessage = "BaseSalary is required.")]
		public decimal BaseSalary { get; set; }
		[Required(ErrorMessage = "PaymentDate is required.")]
		public DateTime PaymentDate { get; set; }
	}
}
