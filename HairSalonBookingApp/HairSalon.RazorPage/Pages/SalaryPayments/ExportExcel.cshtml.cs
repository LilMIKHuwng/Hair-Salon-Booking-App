using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.ApplicationUserModelViews;
using HairSalon.ModelViews.SalaryPaymentModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace HairSalon.RazorPage.Pages.SalaryPayments
{
    public class ExportExcelModel : PageModel
    {
        private readonly ISalaryPaymentService _salaryService;
        private readonly IAppUserService _appUserService;

        public ExportExcelModel(ISalaryPaymentService salaryService, IAppUserService appUserService)
        {
            _salaryService = salaryService;
            _appUserService = appUserService;
        }

        [BindProperty]
        public CreateSalaryPaymentModelView SalaryPayment { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? PaymentDate { get; set; }

        [BindProperty(SupportsGet = true)]
        public Guid? StylistId { get; set; }

        [TempData]
        public string ResponseMessage { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            // Retrieve user roles from session
            var userRolesJson = HttpContext.Session.GetString("UserRoles");
            if (userRolesJson == null)
            {
                TempData["DeniedMessage"] = "You do not have permission to export Salary Payments.";
                return Page();
            }

            var userRoles = JsonConvert.DeserializeObject<List<string>>(userRolesJson);
            if (!userRoles.Any(role => role == "Admin" || role == "Manager"))
            {
                TempData["DeniedMessage"] = "You do not have permission to export Salary Payments.";
                return Page();
            }

            try
            {
                // Fetch stylists (Users with 'Stylist' role)
                var stylistUsers = await _appUserService.GetUsersByRoleAsync("Stylist");

                // Check if stylistUsers is not null and contains any stylists
                ViewData["Stylists"] = stylistUsers ?? new List<AppUserModelView>();
                if (stylistUsers == null || !stylistUsers.Any())
                {
                    TempData["ErrorMessage"] = "No stylists found.";
                }
            }
            catch (Exception ex)
            {
                ViewData["Stylists"] = new List<AppUserModelView>(); // Fallback empty list
                TempData["ErrorMessage"] = "An error occurred while fetching stylists: " + ex.Message;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Check authorization in session
            var userRolesJson = HttpContext.Session.GetString("UserRoles");
            if (userRolesJson == null)
            {
                TempData["DeniedMessage"] = "You do not have permission to export Salary Payments.";
                return Page();
            }

            var userRoles = JsonConvert.DeserializeObject<List<string>>(userRolesJson);
            if (!userRoles.Any(role => role == "Admin" || role == "Manager"))
            {
                TempData["DeniedMessage"] = "You do not have permission to export Salary Payments.";
                return Page();
            }

            try
            {
                // Export salary payments based on selected stylist and payment date
                var excelFile = await _salaryService.ExportSalaryPaymentsToExcelAsync(StylistId, PaymentDate);
                if (excelFile == null || excelFile.Length == 0)
                {
                    TempData["ErrorMessage"] = "Salary Payment not found or export failed.";
                    return Page();
                }

                // Return the file as a downloadable Excel document
                return File(excelFile, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "SalaryPayments.xlsx");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred during export: " + ex.Message;
                return Page();
            }
        }
    }
}
