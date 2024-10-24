namespace HairSalon.ModelViews.SalaryPaymentModelViews
{
    public class UpdatedSalaryPaymentModelView
    {
		public Guid? UserId { get; set; }
		public decimal? BaseSalary { get; set; }
		public DateTime? PaymentDate { get; set; }
		public int? DayOffPermitted { get; set; }
        public int? DayOffNoPermitted { get; set; }

    }
}
