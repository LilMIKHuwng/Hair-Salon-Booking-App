using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.RoleModelViews;
using HairSalon.Core;
using Newtonsoft.Json;

namespace HairSalon.RazorPage.Pages.Role
{
    public class RoleManagementModel : PageModel
    {
        private readonly IRoleService _roleService;

        public RoleManagementModel(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public BasePaginatedList<RoleModelView> Roles { get; set; }

        public string roleId { get; set; }

        public async Task<IActionResult> OnGetAsync(int pageNumber = 1, int pageSize = 5, string? id = null, string? name = null)
        {
            var userRolesJson = HttpContext.Session.GetString("UserRoles");

            if (userRolesJson != null)
            {
                var userRoles = JsonConvert.DeserializeObject<List<string>>(userRolesJson);

                // Check if the user has "Admin" or "Manager" roles
                if (!userRoles.Any(role => role == "Admin"))
                {
                    TempData["ErrorMessage"] = "You do not have permission to view this page.";
                    return Page(); // Show error message on the same page
                }
            }
            else
            {
                TempData["ErrorMessage"] = "You do not have permission to view this page.";
                return RedirectToPage("/Error");
            }

            // If authorized, retrieve roles data
            Roles = await _roleService.GetAllRoleAsync(pageNumber, pageSize, id, name);
            return Page();
        }

		public async Task<IActionResult> OnPostAsync(string id, string action)
		{
			if (string.IsNullOrEmpty(id))
			{
				TempData["ErrorMessage"] = "Role ID is required.";
				return RedirectToPage(); 
			}

            //Save roleId to tempdata
			TempData["RoleId"] = id;

			switch (action?.ToLower())
			{
				case "update":
					return RedirectToPage("/Role/Update");
				case "detail":
					return RedirectToPage("/Role/Detail");
				case "delete":
					return RedirectToPage("/Role/Delete");
				default:
					TempData["ErrorMessage"] = "Invalid action.";
					return RedirectToPage();
			}
		}
	}
}
