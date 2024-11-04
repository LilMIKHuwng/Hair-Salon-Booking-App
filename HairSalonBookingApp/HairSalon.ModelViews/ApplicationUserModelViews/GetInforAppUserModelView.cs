namespace HairSalon.ModelViews.ApplicationUserModelViews
{
    public class GetInforAppUserModelView
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? BankAccount { get; set; }
        public decimal E_Wallet { get; set; }
        public IList<string> Roles { get; set; } = new List<string>();
        public int Point { get; set; } = 0;
    }
}

