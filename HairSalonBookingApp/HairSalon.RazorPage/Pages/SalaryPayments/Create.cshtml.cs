using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.ApplicationUserModelViews;
using HairSalon.ModelViews.SalaryPaymentModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace HairSalon.RazorPage.Pages.SalaryPayments
{
    public class CreateModel : PageModel
    {
        private readonly ISalaryPaymentService _salaryService;
        private readonly IAppUserService _appUserService;

        public CreateModel(ISalaryPaymentService salaryService, IAppUserService appUserService)
        {
            _salaryService = salaryService;
            _appUserService = appUserService;
        }

        [BindProperty]
        public CreateSalaryPaymentModelView SalaryPayment { get; set; }

        public AppUserModelView UserModel { get; set; }

        // Property to store response or success messages
        [TempData]
        public string ResponseMessage { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var userRolesJson = HttpContext.Session.GetString("UserRoles");
            if (userRolesJson == null)
            {
                TempData["DeniedMessage"] = "You do not have permission to add a SalaryPayment.";
                return RedirectToPage("/Error");
            }

            var userRoles = JsonConvert.DeserializeObject<List<string>>(userRolesJson);
            if (!userRoles.Any(role => role == "Admin" || role == "Manager"))
            {
                TempData["DeniedMessage"] = "You do not have permission to add a SalaryPayment.";
                return Page();
            }

            try
            {
                // Fetch stylists (Users with 'Stylist' role)
                var stylistUsers = await _appUserService.GetUsersByRoleAsync("Stylist");

                // Check if stylistUsers is not null and contains any stylists
                if (stylistUsers != null && stylistUsers.Any())
                {
                    ViewData["Stylists"] = stylistUsers;
                }
                else
                {
                    // Provide a default list or message if no stylists are found
                    ViewData["Stylists"] = new List<AppUserModelView>();  // Empty list or a default placeholder
                    TempData["ErrorMessage"] = "No stylists found.";
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions, log it, and provide a fallback
                ViewData["Stylists"] = new List<AppUserModelView>();  // Empty list or a placeholder
                TempData["ErrorMessage"] = "An error occurred while fetching stylists: " + ex.Message;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var userId = HttpContext.Session.GetString("UserId");

                // Ensure user ID is available in session
                if (string.IsNullOrEmpty(userId))
                {
                    TempData["ErrorMessage"] = "User ID is missing.";
                    return Page();
                }

                // Call the service to create the salary payment
                string response = await _salaryService.CreateSalaryPaymentAsync(SalaryPayment, userId);
                if (response == "Add new salary payment successfully!")
                {
                    ResponseMessage = response;
                    return RedirectToPage("/SalaryPayments/Index");
                }
                else
                {
                    // If there is an error, display the response as an error message
                    TempData["ErrorMessage"] = response;
                }
            }
            // Ensure stylist list is reloaded on error
            var stylistUsers = await _appUserService.GetUsersByRoleAsync("Stylist");
            ViewData["Stylists"] = stylistUsers ?? new List<AppUserModelView>();

            return Page(); // Return the same page in case of validation errors or other issues
        }
    }
}
