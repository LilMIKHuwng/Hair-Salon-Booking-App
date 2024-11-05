using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.RoleModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace HairSalon.RazorPage.Pages.Role
{
    public class CreateModel : PageModel
    {
        private readonly IRoleService _roleService;

        public CreateModel(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [BindProperty]
        public CreateRoleModelView NewRole { get; set; }

        // Property to store error messages
        [TempData]
        public string ErrorMessage { get; set; }

        // Property to store response or success messages
        [TempData]
        public string ResponseMessage { get; set; }

        // Property to store denied access messages
        [TempData]
        public string DeniedMessage { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            // Retrieve user roles from session
            var userRolesJson = HttpContext.Session.GetString("UserRoles");
            if (userRolesJson == null)
            {
                DeniedMessage = "You do not have permission to add a role.";
                return Page();// Redirect to a different page with a denied message
            }

            var userRoles = JsonConvert.DeserializeObject<List<string>>(userRolesJson);

            // Check if the user has "Admin" or "Manager" roles
            if (!userRoles.Any(role => role == "Admin" || role == "Manager"))
            {
                DeniedMessage = "You do not have permission to add a role.";
                return Page(); // Redirect to a different page with a denied message
            }

            return Page(); // Allow access to the page if the user has the correct role
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                string response = await _roleService.AddRoleAsync(NewRole);
                if (response == "Role successfully added")
                {
                    ResponseMessage = response;
                    return Redirect("/Roles"); // Redirect back to the role list page
                }
                // Set ErrorMessage if there’s an error
                ErrorMessage = response;
            }
            return Page(); // Return the same page in case of validation errors or other issues
        }
    }
}
