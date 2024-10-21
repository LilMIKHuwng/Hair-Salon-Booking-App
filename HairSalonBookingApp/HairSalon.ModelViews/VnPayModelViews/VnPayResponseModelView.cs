namespace HairSalon.ModelViews.VnPayModelViews
{
    public class VnPayResponseModelView
    {
        public string AppointmentId { get; set; }
        
        public decimal TotalAmount { get; set; }
        public DateTime PaymentTime { get; set; }
        public required string BankCode { get; set; }
        public required string BankTranNo { get; set; }
        public required string CardType { get; set; }
        public required string ResponseCode { get; set; }
        public required string TransactionNo { get; set; }
        public required string TransactionStatus { get; set; }
        public required string Method {  get; set; }
    }
}
