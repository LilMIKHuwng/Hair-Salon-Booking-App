using System.ComponentModel.DataAnnotations;

namespace HairSalon.ModelViews.PaymentModelViews
{
    public class CreatePaymentModelView
    {
        [Required(ErrorMessage = "AppointmentId is required.")]
        public string AppointmentId { get; set; }

        [Required(ErrorMessage = "TotalAmount is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "TotalAmount must be greater than 0.")]
        public decimal TotalAmount { get; set; }

		public DateTime PaymentTime { get; set; } = DateTime.Now;

		[Required(ErrorMessage = "PaymentMethod is required.")]
        public string PaymentMethod { get; set; }

    }
}
