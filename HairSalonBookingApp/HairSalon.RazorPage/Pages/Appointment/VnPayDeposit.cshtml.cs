using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.VnPayModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HairSalon.RazorPage.Pages.Appointment
{
    public class VnPayDepositModel : PageModel
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IVnPayService _vnPayService;

        public VnPayDepositModel(IAppointmentService appointmentService, IVnPayService vnPayService)
        {
            _appointmentService = appointmentService;
            _vnPayService = vnPayService;
        }

        [BindProperty(SupportsGet = true)]
        public string AppointmentId { get; set; }

        public double Amount { get; private set; }
        public string Information { get; private set; }
        public string Type { get; private set; }
        public string? ErrorMessage { get; set; }

		public int CountdownTimeInSeconds { get; private set; } = 0;

		public async Task<IActionResult> OnGetAsync(string appointmentId)
        {
            AppointmentId = appointmentId;

            var appointment = await _appointmentService.GetAppointmentByIdAsync(AppointmentId);
            if (appointment == null)
            {
                ErrorMessage = "Appointment not found.";
                return Page();
            }

			var createTime = appointment.CreatedTime;
			var now = DateTime.UtcNow;
			var maxTime = createTime.AddMinutes(15);
			var timeLeft = maxTime - now;

			CountdownTimeInSeconds = (int)Math.Max(0, timeLeft.TotalSeconds);

			// Set readonly fields
			Amount = (double)(appointment.TotalAmount * 10 / 100); // 10% deposit
            Information = $"Deposit for Appointment #{AppointmentId}";
            Type = "VNPay";

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ErrorMessage = "Invalid input. Please try again.";
                return Page();
            }

            var appointment = await _appointmentService.GetAppointmentByIdAsync(AppointmentId);
            if (appointment == null)
            {
                ErrorMessage = "Appointment not found.";
                return Page();
            }
            var timeRemaining = TimeSpan.FromMinutes(15) - (DateTimeOffset.Now - appointment.CreatedTime);
            var expirationTime = DateTime.UtcNow.Add(timeRemaining).AddHours(7);
            var paymentRequest = new PaymentRequestModelView
            {
                Amount = (double)(appointment.TotalAmount * 10 / 100),
                Information = AppointmentId,
                Type = "VNPay",
                TimeExpire = expirationTime.ToString("yyyyMMddHHmmss")
            };

            try
            {
                // Generate VnPay payment link
                var paymentUrl = await _vnPayService.CreatePaymentUrl(paymentRequest, HttpContext);

                if (string.IsNullOrEmpty(paymentUrl))
                {
                    ErrorMessage = "Failed to generate the payment link. Please try again.";
                    return Page();
                }

                // Redirect to the payment link
                return Redirect(paymentUrl);
            }
            catch (Exception ex)
            {
                ErrorMessage = $"An error occurred: {ex.Message}";
                return Page();
            }
        }
    }
}
