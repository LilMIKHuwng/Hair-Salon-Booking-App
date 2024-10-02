using System.ComponentModel.DataAnnotations;

namespace HairSalon.ModelViews.PaymentModelViews
{
    public class UpdatedPaymentModelView
    {
        public string AppointmentId { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "TotalAmount must be greater than 0.")]
        public decimal TotalAmount { get; set; }

		public DateTime PaymentTime { get; set; } = DateTime.Now;

		public string PaymentMethod { get;  set; }
    }
}
