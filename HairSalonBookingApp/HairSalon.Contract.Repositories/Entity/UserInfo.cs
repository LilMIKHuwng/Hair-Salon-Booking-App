using HairSalon.Core.Base;
namespace HairSalon.Contract.Repositories.Entity
{
	public class UserInfo : BaseEntity
	{
		public string FullName { get; set; } = string.Empty;
		public string? BankAccount { get; set; }
		public string? BankAccountName { get; set; }
		public string? Bank { get; set; }

        public int Point { get; set; } = 0;
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<SalaryPayment> SalaryPayments { get; set; }
    }
}
