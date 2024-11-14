using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using HairSalon.ModelViews.SalaryPaymentModelViews;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

public class SalaryManagentModel : PageModel
{
    private readonly ISalaryPaymentService _salaryService;

    public SalaryManagentModel(ISalaryPaymentService salaryService)
    {
        _salaryService = salaryService;
    }

    public BasePaginatedList<SalaryPaymentModelView> SalaryPayments { get; set; }
    public Dictionary<Guid, string> UserInfos { get; set; } = new Dictionary<Guid, string>();

    public async Task<IActionResult> OnGetAsync(string? id, Guid? stylistId, DateTime? paymentDate, decimal? baseSalary, int pageNumber = 1, int pageSize = 5)
    {
        var userRolesJson = HttpContext.Session.GetString("UserRoles");

        if (userRolesJson != null)
        {
            var userRoles = JsonConvert.DeserializeObject<List<string>>(userRolesJson);

            if (!userRoles.Any(role => role == "Admin" || role == "Manager"))
            {
                TempData["ErrorMessage"] = "You do not have permission to view this page.";
                return Page();
            }
        }
        else
        {
            TempData["ErrorMessage"] = "You do not have permission to view this page.";
            return Page();
        }

        SalaryPayments = await _salaryService.GetAllSalaryPaymentAsync(id, stylistId, paymentDate, baseSalary, pageNumber, pageSize);

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(string id, string action)
    {
        if (string.IsNullOrEmpty(id))
        {
            TempData["ErrorMessage"] = "Salary ID is required.";
            return RedirectToPage();
        }

        //Save roleId to tempdata
        TempData["SalaryId"] = id;

        switch (action?.ToLower())
        {
            case "update":
                return RedirectToPage("/SalaryPayments/Update");
            case "detail":
                return RedirectToPage("/SalaryPayments/Detail");
            case "delete":
                return RedirectToPage("/SalaryPayments/Delete");
            default:
                TempData["ErrorMessage"] = "Invalid action.";
                return RedirectToPage();
        }
    }
}
