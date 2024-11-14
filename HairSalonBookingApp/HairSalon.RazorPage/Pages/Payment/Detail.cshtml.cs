using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.PaymentModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace HairSalon.RazorPage.Pages.Payment
{
    public class DetailModel : PageModel
    {
        private readonly IPaymentService _paymentService;

        public DetailModel(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }

        public PaymentModelView PaymentDetail { get; set; }

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
                return Page();// Redirect to a different page with a denied message
            }

            var userRoles = JsonConvert.DeserializeObject<List<string>>(userRolesJson);

            // Check if the user has "Admin" or "Manager" roles
            if (!userRoles.Any(role => role == "Admin" || role == "User"))
            {
                TempData["DeniedMessage"] = "You do not have permission";
                return Page(); // Redirect to a different page with a denied message
            }

            PaymentDetail = await _paymentService.GetPaymentByIdAsync(Id);
            if (PaymentDetail == null)
            {
                TempData["ErrorMessage"] = "Payment not found.";
                return RedirectToPage("/Payment/Index");
            }
            return Page();
        }
    }
}
