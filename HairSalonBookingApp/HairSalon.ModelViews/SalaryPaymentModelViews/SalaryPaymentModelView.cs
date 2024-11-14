using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HairSalon.ModelViews.SalaryPaymentModelViews
{
    public class SalaryPaymentModelView
    {
        public string Id { get; set; }

        public string UserId { get; set; }

        public decimal BaseSalary { get; set; }

        public DateTime PaymentDate { get; set; }
        public int DayOffPermitted { get; set; }
        public int DayOffNoPermitted { get; set; }
		public decimal DeductedSalary { get; set; }
		public decimal BonusSalary { get; set; }
        public string FullName { get; set; }
    }
}
