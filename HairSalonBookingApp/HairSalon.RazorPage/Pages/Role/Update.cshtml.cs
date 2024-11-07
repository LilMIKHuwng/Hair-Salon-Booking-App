using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.RoleModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace HairSalon.RazorPage.Pages.Role
{
    public class UpdateModel : PageModel
    {
        private readonly IRoleService _roleService;

        public UpdateModel(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }

        [BindProperty]
        public RoleModelView Role { get; set; }

        [BindProperty] // Bind UpdatedRole to be populated from the form
        public UpdatedRoleModelView UpdatedRole { get; set; }

        [TempData]
        public string ResponseMessage { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
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

            Role = await _roleService.GetRoleByIdAsync(Id);
            if (Role == null)
            {
                TempData["ErrorMessage"] = "Role not found.";
                return RedirectToPage("/Role/Index");
            }

            // Initialize UpdatedRole with existing role name for display in the form
            UpdatedRole = new UpdatedRoleModelView { Name = Role.Name };
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var userId = HttpContext.Session.GetString("UserId");

            var response = await _roleService.UpdateRoleAsync(Id, UpdatedRole, userId);
            if (response == "Role successfully updated")
            {
                ResponseMessage = response;
                return RedirectToPage("/Role/Index");
            }

            TempData["ErrorMessage"] = response;
            return Page();
        }
    }
}
