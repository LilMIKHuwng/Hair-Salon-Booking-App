using HairSalon.Contract.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace HairSalon.RazorPage.Pages.SalaryPayments
{
    public class ExportExcelModel : PageModel
    {
        private readonly ISalaryPaymentService _salaryService;

        public ExportExcelModel(ISalaryPaymentService salaryService)
        {
            _salaryService = salaryService;
        }

        // Make PaymentDate nullable
        [BindProperty(SupportsGet = true)]
        public string? PaymentDate { get; set; }

        // Make StylistId nullable
        [BindProperty(SupportsGet = true)]
        public Guid? StylistId { get; set; }

        [TempData]
        public string ResponseMessage { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
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

            // Perform the export operation and retrieve the Excel file as a byte array
            var excelFile = await _salaryService.ExportSalaryPaymentsToExcelAsync(StylistId, PaymentDate);
            if (excelFile == null || excelFile.Length == 0)
            {
                TempData["ErrorMessage"] = "Salary Payment not found or export failed.";
            }

            // Return the file as a downloadable Excel document
            return File(excelFile, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "SalaryPayments.xlsx");
        }
    }

}
