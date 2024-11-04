using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.RoleModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
