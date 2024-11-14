using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.SalaryPaymentModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace HairSalon.RazorPage.Pages.SalaryPayments
{
    public class DetailModel : PageModel
    {
        private readonly ISalaryPaymentService _salaryService;

        public DetailModel(ISalaryPaymentService salaryService)
        {
            _salaryService = salaryService;
        }

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }

        public SalaryPaymentModelView SalaryDetail { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            // Get Id from TempData
            if (TempData.ContainsKey("SalaryId"))
            {
                Id = TempData["SalaryId"].ToString();
            }

            // Check if Id is provided
            if (string.IsNullOrEmpty(Id))
            {
                TempData["ErrorMessage"] = "Invalid  ID.";
                return RedirectToPage("/Error"); // Redirect to error page if Id is missing
            }

            // Retrieve user roles from session
            var userRolesJson = HttpContext.Session.GetString("UserRoles");
            if (userRolesJson == null)
            {
                TempData["DeniedMessage"] = "You do not have permission to add a SalaryPayments.";
                return Page();// Redirect to a different page with a denied message
            }

            var userRoles = JsonConvert.DeserializeObject<List<string>>(userRolesJson);

            // Check if the user has "Admin" or "Manager" roles
            if (!userRoles.Any(role => role == "Admin" || role == "Manager"))
            {
                TempData["DeniedMessage"] = "You do not have permission to add a SalaryPayments.";
                return Page(); // Redirect to a different page with a denied message
            }

            SalaryDetail = await _salaryService.GetSalaryByIdAsync(Id);
            if (SalaryDetail == null)
            {
                TempData["ErrorMessage"] = "SalaryPayment not found.";
                return RedirectToPage("/SalaryPayments/Index");
            }
            return Page();
        }
    }
}
