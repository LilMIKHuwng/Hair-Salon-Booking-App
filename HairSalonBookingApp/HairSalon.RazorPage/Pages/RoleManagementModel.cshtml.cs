using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.RoleModelViews;

namespace HairSalon.RazorPage.Pages;

public class RoleManagementModel : PageModel
{
    
        private readonly IRoleService _roleService;

        public RoleManagementModel(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public List<RoleModelView> Roles { get; set; }

        [BindProperty]
        public CreateRoleModelView NewRole { get; set; }

        public async Task OnGetAsync(int pageNumber = 1, int pageSize = 10)
        {
            var result = await _roleService.GetAllRoleAsync(pageNumber, pageSize, null, null);
            Roles = result.Items.ToList();
        }

        public async Task<IActionResult> OnPostAddRoleAsync()
        {
            if (ModelState.IsValid)
            {
                string response = await _roleService.AddRoleAsync(NewRole);
                if (response == "Role successfully added")
                {
                    return RedirectToPage(); // Refresh page to show updated list
                }
                ModelState.AddModelError(string.Empty, response); // Display error if role exists
            }
            return Page();
        }

        public async Task<IActionResult> OnPostDeleteRoleAsync(string id)
        {
            string response = await _roleService.DeleteRoleAsync(id);
            if (response == "Role successfully deleted")
            {
                return RedirectToPage();
            }
            ModelState.AddModelError(string.Empty, response); // Display error if role deletion fails
            return Page();
        }
}
