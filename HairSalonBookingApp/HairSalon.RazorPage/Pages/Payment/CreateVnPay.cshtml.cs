using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.VnPayModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Globalization;

namespace HairSalon.RazorPage.Pages.Payment
{
    public class CreateVnPayModel : PageModel
    {
        private readonly IVnPayService _paymentService;

        public CreateVnPayModel(IVnPayService paymentService)
        {
            _paymentService = paymentService;
        }

        [BindProperty]
        public PaymentResponseModelView NewPayment { get; set; }

        public bool IsUserRole { get; set; }

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
                return RedirectToPage("/Error"); // Redirect to a different page with a denied message
            }

            var userRoles = JsonConvert.DeserializeObject<List<string>>(userRolesJson);

            // Check if the user has "Admin" or "Manager" roles
            if (!userRoles.Any(role => role == "Admin" || role == "User"))
            {
                TempData["DeniedMessage"] = "You do not have permission";
                return Page(); // Redirect to a different page with a denied message
            }

            IsUserRole = !userRoles.Contains("Admin") && userRoles.Contains("User");

            NewPayment = new PaymentResponseModelView
            {
                AppointmentId = Request.Query["vnp_OrderInfo"],
                TotalAmount = Convert.ToDecimal(Request.Query["vnp_Amount"]) / 100,
                BankCode = Request.Query["vnp_BankCode"],
                BankTranNo = Request.Query["vnp_BankTranNo"],
                CardType = Request.Query["vnp_CardType"],
                ResponseCode = Request.Query["vnp_ResponseCode"],
                TransactionNo = Request.Query["vnp_TransactionNo"],
                TransactionStatus = Request.Query["vnp_TransactionStatus"],
                Method = "VnPay",
                PaymentTime = DateTime.ParseExact(Request.Query["vnp_PayDate"], "yyyyMMddHHmmss", CultureInfo.InvariantCulture) // You can parse the date correctly
            };

            return Page();
        }

        // Method for handling POST request
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                // Execute the payment process
                var userId = HttpContext.Session.GetString("UserId");
                string response = await _paymentService.ExcutePayment(NewPayment, userId);
                if (response == "Payment added successfully.")
                {
                    ResponseMessage = response;
                    return RedirectToPage("/Payment/Index"); // Redirect to payment list page
                }

                // If payment fails, show error message
                TempData["ErrorMessage"] = response;
            }

            return Page(); // Return to the same page in case of error
        }
    }
}
