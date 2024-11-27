using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.AppointmentModelViews;
using HairSalon.ModelViews.VnPayModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace HairSalon.RazorPage.Pages.Payment
{
    public class VnPayModel : PageModel
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IVnPayService _vnPayService;

        public VnPayModel(IAppointmentService appointmentService, IVnPayService vnPayService)
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
            Amount = ((double)appointment.TotalAmount * 0.9);
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

            var paymentRequest = new PaymentRequestModelView
            {
                Amount = ((double)appointment.TotalAmount * 0.9),
                Information = AppointmentId,
                Type = "VNPay"
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


