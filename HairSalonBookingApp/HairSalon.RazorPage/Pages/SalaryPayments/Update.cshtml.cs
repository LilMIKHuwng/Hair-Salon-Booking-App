using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.ApplicationUserModelViews;
using HairSalon.ModelViews.SalaryPaymentModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace HairSalon.RazorPage.Pages.SalaryPayments
{
    public class UpdateModel : PageModel
    {
        private readonly ISalaryPaymentService _salaryService;
        private readonly IAppUserService _appUserService;

        public UpdateModel(ISalaryPaymentService salaryService, IAppUserService appUserService)
        {
            _salaryService = salaryService;
            _appUserService = appUserService;
        }

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }

        [BindProperty]
        public SalaryPaymentModelView SalaryPayment { get; set; }

        [BindProperty]
        public UpdatedSalaryPaymentModelView UpdatedSalary { get; set; }

        [TempData]
        public string ResponseMessage { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var userRolesJson = HttpContext.Session.GetString("UserRoles");
            if (userRolesJson == null)
            {
                TempData["DeniedMessage"] = "You do not have permission to update a SalaryPayment.";
                return Page();
            }

            var userRoles = JsonConvert.DeserializeObject<List<string>>(userRolesJson);
            if (!userRoles.Any(role => role == "Admin" || role == "Manager"))
            {
                TempData["DeniedMessage"] = "You do not have permission to update a SalaryPayment.";
                return Page();
            }

            try
            {
                // Get Id from TempData
                if (TempData.ContainsKey("SalaryId"))
                {
                    Id = TempData["SalaryId"].ToString();
                }

                // Fetch stylists (Users with 'Stylist' role)
                var stylistUsers = await _appUserService.GetUsersByRoleAsync("Stylist");
                ViewData["Stylists"] = stylistUsers ?? new List<AppUserModelView>();

                // Retrieve salary payment details
                SalaryPayment = await _salaryService.GetSalaryByIdAsync(Id);
                if (SalaryPayment == null)
                {
                    TempData["ErrorMessage"] = "SalaryPayment not found.";
                    return RedirectToPage("/SalaryPayments/Index");
                }

                // Initialize UpdatedSalary with existing values
                UpdatedSalary = new UpdatedSalaryPaymentModelView
                {
                    UserId = Guid.TryParse(SalaryPayment.UserId, out var userId) ? userId : (Guid?)null,
                    BaseSalary = SalaryPayment.BaseSalary,
                    PaymentDate = SalaryPayment.PaymentDate,
                    DayOffPermitted = SalaryPayment.DayOffPermitted,
                    DayOffNoPermitted = SalaryPayment.DayOffNoPermitted
                };
            }
            catch (Exception ex)
            {
                ViewData["Stylists"] = new List<AppUserModelView>();
                TempData["ErrorMessage"] = "An error occurred while fetching data: " + ex.Message;
            }

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