using System.ComponentModel.DataAnnotations;

namespace HairSalon.ModelViews.SalaryPaymentModelViews
{
    public class CreateSalaryPaymentModelView
    {
        [Required(ErrorMessage = "User ID is required.")]
        public Guid UserId { get; set; }
        [Required(ErrorMessage = "BaseSalary is required.")]
        public decimal BaseSalary { get; set; }
        [Required(ErrorMessage = "PaymentDate is required.")]
        public DateTime PaymentDate { get; set; }
        public int DayOffPermitted { get; set; }
        public int DayOffNoPermitted { get; set; }
    }
}
