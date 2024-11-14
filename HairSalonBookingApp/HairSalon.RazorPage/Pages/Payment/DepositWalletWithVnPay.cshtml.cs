using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.VnPayModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace HairSalon.RazorPage.Pages.Payment
{
    public class DepositWalletWithVnPayModel : PageModel
    {
        // Injecting dependencies for VnPayService and HttpContextAccessor
        private readonly IVnPayService _paymentService;

        public DepositWalletWithVnPayModel(IVnPayService paymentService)
        {
            _paymentService = paymentService;
        }

        // Binding properties for the Amount and UserId from the query string
        [BindProperty(SupportsGet = true)]
        public string Amount { get; set; }

        [BindProperty]
        public VnPayDepositWalletRequestModelView DepositWalletRequest { get; set; }

        
        public string ResponseMessage { get; set; }

        // TempData for messages
        [TempData]
        public string ErrorMessage { get; set; }

        [TempData]
        public string DeniedMessage { get; set; }

        // Method for handling GET request
        public async Task<IActionResult> OnGetAsync()
        {
            // Retrieve user roles from session
            var userRolesJson = HttpContext.Session.GetString("UserRoles");
            if (userRolesJson == null)
            {
                TempData["DeniedMessage"] = "You do not have permission";
                return RedirectToPage("/Error");
            }

            var userRoles = JsonConvert.DeserializeObject<List<string>>(userRolesJson);

            // Check if the user has "Admin" role
            if (!userRoles.Any(role => role == "Admin" || role == "User"))
            {
                TempData["DeniedMessage"] = "You do not have permission";
                return Page();
            }

            return Page();
        }


        // Method for handling POST request
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var userId = HttpContext.Session.GetString("UserId");
                // Call the DepositWallet method and get the payment URL
                string paymentUrl = await _paymentService.DepositWallet(DepositWalletRequest, HttpContext, userId);

                // Redirect the user to the VNPay payment URL
                if (!string.IsNullOrEmpty(paymentUrl))
                {
                    return Redirect(paymentUrl);
                }
                else
                {
                    // If the payment URL is empty or null, set an error message
                    TempData["ErrorMessage"] = "Failed to initiate payment. Please try again.";
                }
            }
            else
            {
                // If the model state is invalid, show an error message
                TempData["ErrorMessage"] = "Invalid input. Please check your data and try again.";
            }

            // Return to the same page if there was an error
            return Page();
        }
    }
}
