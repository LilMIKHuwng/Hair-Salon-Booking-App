using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HairSalon.ModelViews.SalaryPaymentModelViews
{
    public class CreateSalaryPaymentModelView
    {
        [Required(ErrorMessage = "BaseSalary is required.")]
        public string UserId { get; set; }
        [Required(ErrorMessage = "BaseSalary is required.")]
        public decimal BaseSalary { get; set; }
        [Required(ErrorMessage = "PaymentDate is required.")]
        public DateTime PaymentDate { get; set; } = DateTime.Now;
    }
}
