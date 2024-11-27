using DocumentFormat.OpenXml.Office2010.Excel;
using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.AppointmentModelViews;
using HairSalon.ModelViews.VnPayModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace HairSalon.RazorPage.Pages.Payment
{
    public class PaymentByWalletModel : PageModel
    {
        private readonly IVnPayService _paymentService;
        private readonly IAppointmentService _appointmentService;
        private readonly IPaymentService _checkPaymentService;

        public PaymentByWalletModel(IVnPayService paymentService, IAppointmentService appointmentService, IPaymentService checkPaymentService)
        {
            _paymentService = paymentService;
            _appointmentService = appointmentService;
            _checkPaymentService = checkPaymentService;
        }

        [BindProperty]
        public PaymentResponseModelView NewPayment { get; set; }

        [BindProperty(SupportsGet = true)]
        public PaymentRequestModelView paymentRequest { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        [TempData]
        public string ResponseMessage { get; set; }

        [TempData]
        public string DeniedMessage { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            // Retrieve user roles from session
            var userRolesJson = HttpContext.Session.GetString("UserRoles");
            if (userRolesJson == null)
            {
                TempData["DeniedMessage"] = "You do not have permission";
                return RedirectToPage("/Error");// Redirect to a different page with a denied message
            }

            var userRoles = JsonConvert.DeserializeObject<List<string>>(userRolesJson);

            // Check if the user has "Admin" or "Manager" roles
            if (!userRoles.Any(role => role == "Admin" || role == "User"))
            {
                TempData["DeniedMessage"] = "You do not have permission";
                return Page(); // Redirect to a different page with a denied message
            }

            var userId = HttpContext.Session.GetString("UserId");
            if (string.IsNullOrEmpty(userId))
            {
                TempData["DeniedMessage"] = "User not found.";
                return Page();
            }

            // Get PaymentRequest from TempData
            var paymentRequestJson = TempData["PaymentRequest"]?.ToString();
            PaymentRequestModelView paymentRequest = new PaymentRequestModelView();
            if (!string.IsNullOrEmpty(paymentRequestJson))
            {
                paymentRequest = JsonConvert.DeserializeObject<PaymentRequestModelView>(paymentRequestJson);
            }

            // Ensure NewPayment is initialized
            if (NewPayment == null)
            {
                NewPayment = new PaymentResponseModelView();
            }

            NewPayment.AppointmentId = paymentRequest.Information;
            // Call service to get appointments for the user
            var allAppointments = await _appointmentService.GetAppointmentsByUserIdAsync(userId);
            //Get appointment by id if get all not work
            AppointmentModelView appointmentModelView = await _appointmentService.GetAppointmentByIdAsync(paymentRequest.Information);

            if (appointmentModelView != null)
            {
                bool isPaid = await _checkPaymentService.IsAppointmentPaidAsync(appointmentModelView.Id);

                if (!isPaid)
                {
                    var appointmentAmount = paymentRequest.Amount;

                    if (appointmentAmount != null)
                    {
                        NewPayment.TotalAmount = (decimal)appointmentAmount;
                    }
                    else
                    {
                        NewPayment.TotalAmount = 0;
                    }

                }
            }

            // Set method
            NewPayment.Method = "Wallet";
            // Set PaymentTime to the current date and time
            NewPayment.PaymentTime = DateTime.Now;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var userId = HttpContext.Session.GetString("UserId");
            var appointment = await _appointmentService.GetAppointmentByIdAsync(NewPayment.AppointmentId);
            string response = await _paymentService.ExecutePayment(NewPayment, userId);

            if (response == "Payment added successfully.")
            {
                if (appointment.StatusForAppointment == "Scheduled")
                {
                    var confirm = await _appointmentService.MarkConfirmed(NewPayment.AppointmentId, userId);
                }
                ResponseMessage = response;
                return RedirectToPage("/Payment/Index"); // Redirect back to the payment list page
            }
            // Set ErrorMessage if there�s an error
            TempData["ErrorMessage"] = response;

            return Page(); // Return the same page in case of validation errors or other issues
        }
    }
}
