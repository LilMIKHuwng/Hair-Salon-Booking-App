using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.RoleModelViews;
using HairSalon.Core;

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

        public async Task OnGetAsync(int pageNumber = 1, int pageSize = 5, string? id = null, string? name = null)
        {
            Roles = await _roleService.GetAllRoleAsync(pageNumber, pageSize, id, name);
        }
    }
}
