using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.RoleModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
        public string ErrorMessage { get; set; }

        [TempData]
        public string ResponseMessage { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Role = await _roleService.GetRoleByIdAsync(Id);
            if (Role == null)
            {
                ErrorMessage = "Role not found.";
                return RedirectToPage("/Roles");
            }

            // Initialize UpdatedRole with existing role name for display in the form
            UpdatedRole = new UpdatedRoleModelView { Name = Role.Name };
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var response = await _roleService.UpdateRoleAsync(Id, UpdatedRole);
            if (response == "Role successfully updated")
            {
                ResponseMessage = response;
                return RedirectToPage("/Roles");
            }

            ErrorMessage = response;
            return Page();
        }
    }
}
