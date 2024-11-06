using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.RoleModelViews;
using HairSalon.ModelViews.SalaryPaymentModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace HairSalon.RazorPage.Pages.SalaryPayments
{
    public class UpdateModel : PageModel
    {
        private readonly ISalaryPaymentService _salaryService;

        public UpdateModel(ISalaryPaymentService salaryService)
        {
            _salaryService = salaryService;
        }

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }

        [BindProperty]
        public SalaryPaymentModelView SalaryPayment { get; set; }

        [BindProperty] // Bind UpdatedRole to be populated from the form
        public UpdatedSalaryPaymentModelView UpdatedSalary { get; set; }

        [TempData]
        public string ResponseMessage { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
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
                TempData["DeniedMessage"] = "You do not have permission to add a role.";
                return Page();// Redirect to a different page with a denied message
            }

            var userRoles = JsonConvert.DeserializeObject<List<string>>(userRolesJson);

            // Check if the user has "Admin" or "Manager" roles
            if (!userRoles.Any(role => role == "Admin"))
            {
                TempData["DeniedMessage"] = "You do not have permission to add a role.";
                return Page(); // Redirect to a different page with a denied message
            }

            SalaryPayment = await _salaryService.GetSalaryByIdAsync(Id);
            if (SalaryPayment == null)
            {
                TempData["ErrorMessage"] = "SalaryPayment not found.";
                return RedirectToPage("/SalaryPayments/Index");
            }

            // Initialize UpdatedRole with existing role name for display in the form
            UpdatedSalary = new UpdatedSalaryPaymentModelView
            {
                UserId = Guid.TryParse(SalaryPayment.UserId, out var userId) ? userId : (Guid?)null,
                BaseSalary = SalaryPayment.BaseSalary,
                PaymentDate = SalaryPayment.PaymentDate,
                DayOffPermitted = SalaryPayment.DayOffPermitted,
                DayOffNoPermitted = SalaryPayment.DayOffNoPermitted
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var userId = HttpContext.Session.GetString("UserId");

            var response = await _salaryService.UpdateSalaryPaymentAsync(Id, userId, UpdatedSalary);
            if (response == "Updated salary payment successfully!")
            {
                ResponseMessage = response;
                return RedirectToPage("/SalaryPayments/Index");
            }

            TempData["ErrorMessage"] = response;
            return Page();
        }
    }
}
