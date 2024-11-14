using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.PaymentModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace HairSalon.RazorPage.Pages.Payment
{
    public class DeleteModel : PageModel
    {
        private readonly IPaymentService _paymentService;

        public DeleteModel(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }

        public PaymentModelView Payment { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        [TempData]
        public string ResponseMessage { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            // Get Id from TempData
            if (TempData.ContainsKey("PaymentId"))
            {
                Id = TempData["PaymentId"].ToString();
            }

            // Check if Id is provided
            if (string.IsNullOrEmpty(Id))
            {
                TempData["ErrorMessage"] = "Invalid Role ID.";
                return RedirectToPage("/Error"); // Redirect to error page if Id is missing
            }

            // Retrieve user roles from session
            var userRolesJson = HttpContext.Session.GetString("UserRoles");
            if (userRolesJson == null)
            {
                TempData["DeniedMessage"] = "You do not have permission";
                return RedirectToPage("/Error");// Redirect to a different page with a denied message
            }

            var userRoles = JsonConvert.DeserializeObject<List<string>>(userRolesJson);

            // Check if the user has "Admin" or "Manager" roles
            if (!userRoles.Any(role => role == "Admin"))
            {
                TempData["DeniedMessage"] = "You do not have permission";
                return Page(); // Redirect to a different page with a denied message
            }
            Payment = await _paymentService.GetPaymentByIdAsync(Id);
            if (Payment == null)
            {
                ErrorMessage = "Payment Not Found";
                return RedirectToPage("/Payment/Index"); // Redirect if Payment is not found
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var userId = HttpContext.Session.GetString("UserId");
            string response = await _paymentService.DeletePaymentAsync(Id, userId);
            if (response == "Payment deleted successfully.")
            {
                ResponseMessage = response;
                return RedirectToPage("/Payment/Index");
            }
            // Set ErrorMessage if deletion fails
            TempData["ErrorMessage"] = response;
            return Page();
        }
    }
}
