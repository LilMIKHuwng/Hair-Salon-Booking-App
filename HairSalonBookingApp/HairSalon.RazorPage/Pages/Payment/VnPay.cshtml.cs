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
        private readonly IVnPayService _paymentService;
        private readonly IConfiguration _configuration;

        public VnPayModel(IVnPayService paymentService, IConfiguration configuration)
        {
            _paymentService = paymentService;
            _configuration = configuration;
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
            if (!userRoles.Any(role => role == "Admin"))
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

            // Ti?p t?c g?i hàm CreatePaymentUrl n?u c?u hình h?p l?
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
            // L?y các tham s? tr? v? t? VNPay
            var vnpResponseCode = Request.Query["vnp_ResponseCode"];
            var vnpTransactionStatus = Request.Query["vnp_TransactionStatus"];
            

            // Ki?m tra mã ph?n h?i t? VNPay (là "00" n?u thành công)
            if (vnpResponseCode == "00" && vnpTransactionStatus == "00")
            {
                // Thanh toán thành công, ?i?u h??ng v? trang Index
                TempData["SuccessMessage"] = "Payment successful!";
                return RedirectToPage("/Payment/Index");
            }
            else
            {
                // Thanh toán không thành công
                TempData["ErrorMessage"] = "Payment failed or invalid response. Please try again.";
                return RedirectToPage("/Payment/Index");
            }
        }
    }
}
