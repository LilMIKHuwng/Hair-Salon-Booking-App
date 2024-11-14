using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using HairSalon.ModelViews.ComboModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace HairSalon.RazorPage.Pages.Combo
{
    public class IndexModel : PageModel
    {
        private readonly IComboService _comboService;

        public IndexModel(IComboService comboService)
        {
            _comboService = comboService;
        }

        public BasePaginatedList<ComboModelView> Combos { get; set; }

        public async Task<IActionResult> OnGetAsync(int pageNumber = 1, int pageSize = 5, string? id = null, string? name = null)
        {
            var userRolesJson = HttpContext.Session.GetString("UserRoles");

            if (userRolesJson == null)
            {
                TempData["ErrorMessage"] = "You do not have permission to view this page.";
                return RedirectToPage("/Error");
            }

            var userRoles = JsonConvert.DeserializeObject<List<string>>(userRolesJson);

            // Check if the user has "Admin" or "Manager" roles
            if (!userRoles.Any(role => role == "Admin" || role == "Manager"))
            {
                TempData["ErrorMessage"] = "You do not have permission to view this page.";
                return Page(); // Show error message on the same page
            }

            // If authorized, retrieve roles data
            Combos = await _comboService.GetAllCombosAsync(pageNumber, pageSize, id, name);
            return Page();
        }


        public async Task<IActionResult> OnPostAsync(string id, string action)
        {
            if (string.IsNullOrEmpty(id))
            {
                TempData["ErrorMessage"] = "Combo ID is required.";
                return RedirectToPage();
            }

            //Save roleId to tempdata
            TempData["ComboId"] = id;

            switch (action?.ToLower())
            {
                case "update":
                    return RedirectToPage("/Combo/Update");
                case "detail":
                    return RedirectToPage("/Combo/Detail");
                case "delete":
                    return RedirectToPage("/Combo/Delete");
                default:
                    TempData["ErrorMessage"] = "Invalid action.";
                    return RedirectToPage();
            }
        }
    }
}
