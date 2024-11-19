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
        private readonly IVnPayService _paymentService;
        private readonly IAppointmentService _appointmentService; 
        private readonly IPaymentService _checkPaymentService;
        private readonly IPayOSService _payOsService;
        
        public PayOS(IVnPayService paymentService, 
            IAppointmentService appointmentService, 
            IPaymentService checkPaymentService,
            IPayOSService payOsService)
        {
            _paymentService = paymentService;
            _appointmentService = appointmentService;
            _checkPaymentService = checkPaymentService;
            _payOsService = payOsService;
        }

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }
        public PaymentRequestModelView Payment { get; set; }
        public List<AppointmentModelView> Appointments { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            // Retrieve user roles from session
            var userRolesJson = HttpContext.Session.GetString("UserRoles");
            if (userRolesJson == null)
            {
                TempData["DeniedMessage"] = "You do not have permission";
                return RedirectToPage("/Error"); // Redirect to a different page with a denied message
            }

            var userRoles = JsonConvert.DeserializeObject<List<string>>(userRolesJson);

            // Check if the user has "Admin" or "Manager" roles
            if (!userRoles.Any(role => role == "Admin" || role == "User"))
            {
                TempData["DeniedMessage"] = "You do not have permission";
                return Page(); // Redirect to a different page with a denied message
            }

            // Get the userId (You need to retrieve this based on your app's context)
            var userId = HttpContext.Session.GetString("UserId");
            if (string.IsNullOrEmpty(userId))
            {
                TempData["DeniedMessage"] = "User not found.";
                return Page();
            }

            // Call service to get appointments for the user
            var allAppointments = await _appointmentService.GetAppointmentsByUserIdAsync(userId);

            // Filter out the appointments that have already been paid
            Appointments = new List<AppointmentModelView>();
            foreach (var appointment in allAppointments)
            {
                bool isPaid = await _checkPaymentService.IsAppointmentPaidAsync(appointment.Id);
                if (!isPaid) // Only add appointments that are not paid
                {
                    Appointments.Add(appointment);
                }
            }

            return Page();

        }

        // Handler to generate and redirect to the PayOS URL
        public async Task<IActionResult> OnPostPayWithVnPayAsync()
        {
            if (string.IsNullOrEmpty(Id))
            {
                TempData["ErrorMessage"] = "Appointment ID is required.";
                return RedirectToPage("/Error");
            }

            var appointment = await _paymentService.GetAppointmentByIdAsync(Id);
            if (appointment == null)
            {
                TempData["ErrorMessage"] = "AppointmentId not found.";
                return Page();
            }

            var paymentRequest = new PaymentRequestModelView { AppoinmentId = appointment.Id };
            var paymentUrl = await _payOsService.CreatePaymentLink(paymentRequest);
            HttpContext.Session.SetString("AppointmentId", appointment.Id);
            if (paymentUrl == "Appointment not found." || paymentUrl == "Appointment has not been completed.")
            {
                TempData["ErrorMessage"] = paymentUrl;
                return Page();
            }

            return Redirect(paymentUrl);
        }

        public IActionResult OnGetPaymentCallbackAsync()
        {
            var vnpResponseCode = Request.Query["code"];
            var vnpTransactionStatus = Request.Query["status"];

            if (vnpResponseCode == "00" && vnpTransactionStatus == "PAID")
            {
                TempData["SuccessMessage"] = "Payment successful!";
                return RedirectToPage("/Payment/Index");
            }
            else
            {
                TempData["ErrorMessage"] = "Payment failed or invalid response. Please try again.";
                return RedirectToPage("/Payment/Index");
            }
        }
    }
}


