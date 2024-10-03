using System.ComponentModel.DataAnnotations;

namespace HairSalon.ModelViews.PaymentModelViews
{
    public class UpdatedPaymentModelView
    {
        public string AppointmentId { get; set; }

        public decimal TotalAmount { get; set; }

		public string PaymentMethod { get;  set; }
    }
}
