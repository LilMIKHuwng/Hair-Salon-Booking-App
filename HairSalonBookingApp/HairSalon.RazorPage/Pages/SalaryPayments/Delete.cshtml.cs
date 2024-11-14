using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.SalaryPaymentModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace HairSalon.RazorPage.Pages.SalaryPayments
{
    public class DeleteModel : PageModel
    {
        private readonly ISalaryPaymentService _salaryService;

        public DeleteModel(ISalaryPaymentService salaryService)
        {
            _salaryService = salaryService;
        }

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }

        public SalaryPaymentModelView SalaryPayment { get; set; }

        // Property to store response or success messages
        [TempData]
        public string ResponseMessage { get; set; }

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
                TempData["ErrorMessage"] = "Invalid ID.";
                return RedirectToPage("/Error"); // Redirect to error page if Id is missing
            }

            // Retrieve user roles from session
            var userRolesJson = HttpContext.Session.GetString("UserRoles");
            if (userRolesJson == null)
            {
                TempData["DeniedMessage"] = "You do not have permission to delete a SalaryPayments.";
                return Page();// Redirect to a different page with a denied message
            }

            var userRoles = JsonConvert.DeserializeObject<List<string>>(userRolesJson);

            // Check if the user has "Admin" or "Manager" roles
            if (!userRoles.Any(role => role == "Admin" || role == "Manager"))
            {
                TempData["DeniedMessage"] = "You do not have permission to delete a SalaryPayments.";
                return Page(); // Redirect to a different page with a denied message
            }

            SalaryPayment = await _salaryService.GetSalaryByIdAsync(Id);
            if (SalaryPayment == null)
            {
                TempData["ErrorMessage"] = "SalaryPayment Not Found";
                return RedirectToPage("/SalaryPayments/Index"); // Redirect if SalaryPayment is not found
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var userId = HttpContext.Session.GetString("UserId");

            string response = await _salaryService.DeleteSalaryPaymentAsync(Id, userId);
            if (response == "Deleted salary payment successfully!")
            {
                ResponseMessage = response;
                return RedirectToPage("/SalaryPayments/Index");
            }
            // Set ErrorMessage if deletion fails
            TempData["ErrorMessage"] = response;
            return Page();
        }
    }
}
