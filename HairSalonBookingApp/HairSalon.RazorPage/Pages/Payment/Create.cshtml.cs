using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.VnPayModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace HairSalon.RazorPage.Pages.Payment
{
    public class CreateModel : PageModel
    {
        private readonly IVnPayService _paymentService;

        public CreateModel(IVnPayService paymentService)
        {
            _paymentService = paymentService;
        }

        [BindProperty]
        public PaymentResponseModelView NewPayment { get; set; }

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
            if (!userRoles.Any(role => role == "Admin"))
            {
                TempData["DeniedMessage"] = "You do not have permission";
                return Page(); // Redirect to a different page with a denied message
            }

            return Page();

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var userId = HttpContext.Session.GetString("UserId");
                string response = await _paymentService.ExcutePayment(NewPayment, userId);
                if (response == "Payment added successfully.")
                {
                    ResponseMessage = response;
                    return RedirectToPage("/Payment/Index"); // Redirect back to the payment list page
                }
                // Set ErrorMessage if there’s an error
                TempData["ErrorMessage"] = response;
            }
            return Page(); // Return the same page in case of validation errors or other issues
        }
    }
}

