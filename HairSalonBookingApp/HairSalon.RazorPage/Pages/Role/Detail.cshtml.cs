using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.RoleModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace HairSalon.RazorPage.Pages.Role
{
    public class DetailModel : PageModel
    {
        private readonly IRoleService _roleService;

        public DetailModel(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }

        public RoleModelView RoleDetail { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
			// Get roleId from TempData
			if (TempData.ContainsKey("RoleId"))
			{
				Id = TempData["RoleId"].ToString();
			}

			// Check if Id is provided
			if (string.IsNullOrEmpty(Id))
            {
                TempData["ErrorMessage"] = "Invalid Role ID.";
                return RedirectToPage("/Error"); // Redirect to error page if Id is missing
            }

            // Retrieve user roles from session
            var userRolesJson = HttpContext.Session.GetString("UserRoles");
            if (userRolesJson == null)
            {
                TempData["DeniedMessage"] = "You do not have permission";
                return RedirectToPage("/Error");
            }

            var userRoles = JsonConvert.DeserializeObject<List<string>>(userRolesJson);

            // Check if the user has "Admin" or "Manager" roles
            if (!userRoles.Any(role => role == "Admin"))
            {
                TempData["DeniedMessage"] = "You do not have permission";
                return Page(); // Redirect to a different page with a denied message
            }

            RoleDetail = await _roleService.GetRoleByIdAsync(Id);
            if (RoleDetail == null)
            {
                TempData["ErrorMessage"] = "Role not found.";
                return RedirectToPage("/Role/Index");
            }
            return Page();
        }
    }
}
