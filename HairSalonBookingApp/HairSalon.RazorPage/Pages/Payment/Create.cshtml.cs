using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.ShopModelViews;
using HairSalon.ModelViews.VnPayModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Security.Claims;

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

        // Property to store error messages
        [TempData]
        public string ErrorMessage { get; set; }

        // Property to store response or success messages
        [TempData]
        public string ResponseMessage { get; set; }

        // Property to store denied access messages
        [TempData]
        public string DeniedMessage { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            // Retrieve user roles from session
            var userRolesJson = HttpContext.Session.GetString("UserRoles");
            if (userRolesJson == null)
            {
                DeniedMessage = "You do not have permission to add a Payment.";
                return Page();// Redirect to a different page with a denied message
            }

            var userRoles = JsonConvert.DeserializeObject<List<string>>(userRolesJson);

            // Check if the user has "Admin" or "Manager" roles
            if (!userRoles.Any(role => role == "Admin" || role == "Manager"))
            {
                DeniedMessage = "You do not have permission to add a Payment.";
                return Page(); // Redirect to a different page with a denied message
            }

            return Page(); // Allow access to the page if the user has the correct role
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var userIdClaim = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
                if (userIdClaim != null)
                {
                    // Chuy?n ??i string sang Guid n?u NewPayment.UserId là Guid
                    if (Guid.TryParse(userIdClaim.Value, out Guid userId))
                    {
                        NewPayment.UserId = userId; // Gán giá tr? ?ã chuy?n ??i
                    }
                    else
                    {
                        // X? lý n?u không th? chuy?n ??i sang Guid
                        ErrorMessage = "User ID không hop le.";
                        return Page();
                    }
                }

                string response = await _paymentService.ExcutePayment(NewPayment);
                if (response == "Payment added successfully.")
                {
                    ResponseMessage = response;
                    return Redirect("/Payment/Index"); // Redirect back to the payment list page
                }
                // Set ErrorMessage if there’s an error
                ErrorMessage = response;
            }
            return Page(); // Return the same page in case of validation errors or other issues
        }
    }
}
