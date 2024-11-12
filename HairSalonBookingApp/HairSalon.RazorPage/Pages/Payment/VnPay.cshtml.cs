using DocumentFormat.OpenXml.Office2010.Excel;
using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using HairSalon.ModelViews.AppointmentModelViews;
using HairSalon.ModelViews.VnPayModelViews;
using HairSalon.Services.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace HairSalon.RazorPage.Pages.Payment
{
    public class VnPayModel : PageModel
    {
        private readonly IVnPayService _paymentService;

        public VnPayModel(IVnPayService paymentService)
        {
            _paymentService = paymentService;
        }

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }

        public PaymentRequestModelView Payment { get; set; }

        public AppointmentModelView AppointmentId { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            // Retrieve user roles from session
            var userRolesJson = HttpContext.Session.GetString("UserRoles");
            if (userRolesJson == null)
            {
                TempData["DeniedMessage"] = "You do not have permission";
                return Page();// Redirect to a different page with a denied message
            }

            var userRoles = JsonConvert.DeserializeObject<List<string>>(userRolesJson);

            // Check if the user has "Admin" or "Manager" roles
            if (!userRoles.Any(role => role == "Admin" || role == "User"))
            {
                TempData["DeniedMessage"] = "You do not have permission";
                return Page(); // Redirect to a different page with a denied message
            }


            return Page();
        }

        // Handler to generate and redirect to the VNPay URL
        public async Task<IActionResult> OnPostPayWithVnPayAsync()
        {
            if (string.IsNullOrEmpty(Id))
            {
                TempData["ErrorMessage"] = "Appointment ID is required.";
                return Page();
            }

            AppointmentId = await _paymentService.GetAppointmentByIdAsync(Id);
            if (AppointmentId == null)
            {
                TempData["ErrorMessage"] = "AppointmentId not found.";
                return Page();
            }

            var paymentRequest = new PaymentRequestModelView { AppoinmentId = AppointmentId.Id };
            string paymentUrl = _paymentService.CreatePaymentUrl(paymentRequest, HttpContext);

            if (paymentUrl == "Appointment not found." || paymentUrl == "Appointment has not been completed.")
            {
                TempData["ErrorMessage"] = paymentUrl;
                return Page();
            }

            return Redirect(paymentUrl);
        }
        public IActionResult OnGetPaymentCallbackAsync()
        {
            var vnpResponseCode = Request.Query["vnp_ResponseCode"];
            var vnpTransactionStatus = Request.Query["vnp_TransactionStatus"];
            
            if (vnpResponseCode == "00" && vnpTransactionStatus == "00")
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
