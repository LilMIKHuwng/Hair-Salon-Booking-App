using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.RoleModelViews;
using HairSalon.ModelViews.SalaryPaymentModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace HairSalon.RazorPage.Pages.SalaryPayments
{
    public class CreateModel : PageModel
    {
        private readonly ISalaryPaymentService _salaryService;

        public CreateModel(ISalaryPaymentService salaryService)
        {
            _salaryService = salaryService;
        }

        [BindProperty]
        public CreateSalaryPaymentModelView SalaryPayment { get; set; }

        // Property to store response or success messages
        [TempData]
        public string ResponseMessage { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            // Retrieve user roles from session
            var userRolesJson = HttpContext.Session.GetString("UserRoles");
            if (userRolesJson == null)
            {
                TempData["DeniedMessage"] = "You do not have permission to add a SalaryPayment.";
                return Page();// Redirect to a different page with a denied message
            }

            var userRoles = JsonConvert.DeserializeObject<List<string>>(userRolesJson);

            // Check if the user has "Admin" or "Manager" roles
            if (!userRoles.Any(role => role == "Admin"))
            {
                TempData["DeniedMessage"] = "You do not have permission to add a SalaryPayment.";
                return Page(); // Redirect to a different page with a denied message
            }

            return Page(); // Allow access to the page if the user has the correct role
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var userId = HttpContext.Session.GetString("UserId");

                string response = await _salaryService.CreateSalaryPaymentAsync(SalaryPayment, userId);
                if (response == "Add new salary payment successfully!")
                {
                    ResponseMessage = response;
                    return Redirect("/SalaryPayments/Index"); // Redirect back to the role list page
                }
                // Set ErrorMessage if there’s an error
                TempData["ErrorMessage"] = response;
            }
            return Page(); // Return the same page in case of validation errors or other issues
        }
    }
}
