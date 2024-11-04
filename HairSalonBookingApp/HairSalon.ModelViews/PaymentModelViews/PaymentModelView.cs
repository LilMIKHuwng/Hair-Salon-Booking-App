namespace HairSalon.ModelViews.PaymentModelViews
{
    public class PaymentModelView
    {
        public string Id { get; set; }

        public string AppointmentId { get; set; }

        public decimal TotalAmount { get; set; }

        public DateTime PaymentTime { get; set; } = DateTime.Now;

        public string PaymentMethod { get; set; }

        public  string BankCode { get; set; }
        public  string BankTranNo { get; set; }
        public  string CardType { get; set; }
        public  string ResponseCode { get; set; }
        public  string TransactionNo { get; set; }
        public  string TransactionStatus { get; set; }

    }
}
