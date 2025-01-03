using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.VnPayModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace HairSalon.RazorPage.Pages.Payment
{
    public class DepositWalletModel : PageModel
    {
        private readonly IVnPayService _paymentService;

        public DepositWalletModel(IVnPayService paymentService)
        {
            _paymentService = paymentService;
        }

        [BindProperty]
        public DepositWalletModelView DepositWalletRequest { get; set; }

        public bool IsUserRole { get; set; }

        [TempData]
        public string ResponseMessage { get; set; }

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

            var UserId = HttpContext.Session.GetString("UserId");
            // Extract query parameters and assign to DepositWalletRequest object
            DepositWalletRequest = new DepositWalletModelView
            {
                UserId = UserId,  // Extract the userId
                Amount = Convert.ToDouble(Request.Query["vnp_Amount"]) / 100
            };

            if (ModelState.IsValid)
            {
                if (Guid.TryParse(UserId, out var userId) && DepositWalletRequest.Amount > 0)
                {
                    // Call the ExcuteDepositToWallet service method
                    var response = await _paymentService.ExecuteDepositToWallet(userId, DepositWalletRequest.Amount);

                    // Check the response and set a success or error message
                    if (response == "Success!")
                    {
                        ResponseMessage = "Deposit successful!";
                        return RedirectToPage("/AdminPage/Profile");
                    }
                    else
                    {
						ResponseMessage = response;
                    }
                }
                else
                {
					ResponseMessage = "Invalid user ID or amount entered.";
                }
            }

            return Page();
        }

    }
}
