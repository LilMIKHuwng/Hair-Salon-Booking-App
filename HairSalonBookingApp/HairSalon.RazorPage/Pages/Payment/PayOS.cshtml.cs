using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.AppointmentModelViews;
using HairSalon.ModelViews.VnPayModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace HairSalon.RazorPage.Pages.Payment
{
    public class PayOS : PageModel
    {
        /*private readonly IPayOSService _payOSService;
		private readonly IAppointmentService _appointmentService;

		public PayOS(IPayOSService payOSService, IAppointmentService appointmentService)
		{
			_payOSService = payOSService;
			_appointmentService = appointmentService;
		}

		public double Amount { get; private set; }
		public string Information { get; private set; }
		public string Type { get; private set; }
		public string? ErrorMessage { get; set; }

		[BindProperty(SupportsGet = true)]
		public string AppointmentId { get; set; }

		public async Task<IActionResult> OnGetAsync()
		{
			if (string.IsNullOrEmpty(AppointmentId))
			{
				TempData["ErrorMessage"] = "Appointment ID is missing.";
				return Page();
			}

			var appointment = await _appointmentService.GetAppointmentByIdAsync(AppointmentId);
			if (appointment == null)
			{
				ErrorMessage = "Appointment not found.";
				return Page();
			}

			// Set properties to be displayed on the page
			Amount = ((double)appointment.TotalAmount * 0.9); 
			Information = $"Deposit for Appointment #{AppointmentId}";
			Type = "PayOS";

			return Page();
		}


		public async Task<IActionResult> OnPostAsync()
		{
			if (string.IsNullOrEmpty(AppointmentId))
			{
				ErrorMessage = "Appointment ID is required.";
				return Page();
			}

			var appointment = await _appointmentService.GetAppointmentByIdAsync(AppointmentId);
			if (appointment == null)
			{
				ErrorMessage = "Appointment not found.";
				return Page();
			}

			var paymentRequest = new PaymentRequestModelView
			{
				Amount = ((double)appointment.TotalAmount * 0.9), // Example logic
				Information = $"Deposit for Appointment #{AppointmentId}",
				Type = "PayOS"
			};

			try
			{
				var paymentLink = await _payOSService.CreatePaymentLink(paymentRequest);

				if (string.IsNullOrEmpty(paymentLink))
				{
					ErrorMessage = "Failed to generate the payment link.";
					return Page();
				}

				return Redirect(paymentLink);
			}
			catch (Exception ex)
			{
				ErrorMessage = $"An error occurred: {ex.Message}";
				return Page();
			}
		}*/

        private readonly IPayOSService _payOSService;
        private readonly IAppointmentService _appointmentService;

        public PayOS(IPayOSService payOSService, IAppointmentService appointmentService)
        {
            _payOSService = payOSService;
            _appointmentService = appointmentService;
        }

        [BindProperty(SupportsGet = true)]
        public string AppointmentId { get; set; }

        public double Amount { get; private set; }
        public string Information { get; private set; }

        public string Type { get; private set; }
        public string? ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(string appointmentId)
        {
            AppointmentId = appointmentId;

            var appointment = await _appointmentService.GetAppointmentByIdAsync(AppointmentId);
            if (appointment == null)
            {
                ErrorMessage = "Appointment not found.";
                return Page();
            }

            // Set readonly fields
            Amount = (double)(appointment.TotalAmount * 90 / 100);
            Information = $"Deposit for Appointment #{AppointmentId}";
            Type = "PayOS";

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ErrorMessage = "Invalid input. Please try again.";
                return Page();
            }

            HttpContext.Session.SetString("AppointmentId", AppointmentId);

            var appointment = await _appointmentService.GetAppointmentByIdAsync(AppointmentId);
            if (appointment == null)
            {
                ErrorMessage = "Appointment not found.";
                return Page();
            }
            var expirationTime = DateTimeOffset.UtcNow.AddMinutes(15);
            var paymentRequest = new PaymentRequestModelView
            {
                Amount = (double)(appointment.TotalAmount * 90 / 100),
                Information = $"Deposit for Appointment #{AppointmentId}",
                Type = "PayOS",
                TimeExpire = expirationTime.ToUnixTimeSeconds() + "",
            };

            try
            {
                var paymentLink = await _payOSService.CreatePaymentLink(paymentRequest);

                if (string.IsNullOrEmpty(paymentLink))
                {
                    ErrorMessage = "Failed to generate the payment link. Please try again.";
                    return Page();
                }

                // Redirect to the payment link
                return Redirect(paymentLink);
            }
            catch (Exception ex)
            {
                ErrorMessage = $"An error occurred: {ex.Message}";
                return Page();
            }
        }
    }
}


