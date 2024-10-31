using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.RoleModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HairSalon.RazorPage.Pages.Role
{
    public class DeleteModel : PageModel
    {
        private readonly IRoleService _roleService;

        public DeleteModel(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }

        public RoleModelView Role { get; set; }

        // Property to store error messages
        [TempData]
        public string ErrorMessage { get; set; }

        // Property to store response or success messages
        [TempData]
        public string ResponseMessage { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Role = await _roleService.GetRoleByIdAsync(Id);
            if (Role == null)
            {
                ErrorMessage = "Role Not Found";
                return Redirect("/Role/Index"); // Redirect if role is not found
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            string response = await _roleService.DeleteRoleAsync(Id);
            if (response == "Role successfully deleted")
            {
                ResponseMessage = response;
                return Redirect("/Role/Index");
            }
            // Set ErrorMessage if deletion fails
            ErrorMessage = response;
            return Page();
        }
    }
}
