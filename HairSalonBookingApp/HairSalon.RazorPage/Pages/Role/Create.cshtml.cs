using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.RoleModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                string response = await _roleService.AddRoleAsync(NewRole);
                if (response == "Role successfully added")
                {
                    ResponseMessage = response;
                    return Redirect("/Role/Index"); // Redirect back to the role list page
                }
                // Set ErrorMessage if there’s an error
                ErrorMessage = response;
            }
            return Page();
        }
    }
}
