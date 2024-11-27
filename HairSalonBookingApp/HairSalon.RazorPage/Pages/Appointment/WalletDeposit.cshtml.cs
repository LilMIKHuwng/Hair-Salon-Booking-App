using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.VnPayModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace HairSalon.RazorPage.Pages.Appointment
{
    public class WalletDepositModel : PageModel
    {
        private readonly IAppointmentService _appointmentService;

        public WalletDepositModel(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [BindProperty(SupportsGet = true)]
        public string AppointmentId { get; set; }

        public double Amount { get; private set; }
        public string Information { get; private set; }
        public string Type { get; private set; }
        public string? ErrorMessage { get; set; }

        public async Task<IActionResult> OnGet(string appointmentId)
        {
            AppointmentId = appointmentId;

            var appointment = await _appointmentService.GetAppointmentByIdAsync(AppointmentId);
            if (appointment == null)
            {
                ErrorMessage = "Appointment not found.";
                return Page();
            }

            // Set readonly fields
            Amount = (double)(appointment.TotalAmount * 10 / 100); // 10% deposit
            Information = $"Deposit for Appointment #{AppointmentId}";
            Type = "Wallet";

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var appointment = await _appointmentService.GetAppointmentByIdAsync(AppointmentId);
            if (appointment == null)
            {
                ErrorMessage = "Appointment not found.";
                return Page();
            }

            var paymentRequest = new PaymentRequestModelView
            {
                Amount = (double)(appointment.TotalAmount * 10 / 100),
                Information = AppointmentId,
                Type = "Wallet"
            };

            try
            {
                TempData["PaymentRequest"] = JsonConvert.SerializeObject(paymentRequest);
                return RedirectToPage("/Payment/PaymentByWallet");
            }
            catch (Exception ex)
            {
                ErrorMessage = $"An error occurred: {ex.Message}";
                return Page();
            }
        }
    } 
}
