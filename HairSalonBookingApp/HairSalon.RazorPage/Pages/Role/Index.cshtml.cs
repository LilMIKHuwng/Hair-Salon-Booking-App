using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.RoleModelViews;

namespace HairSalon.RazorPage.Pages.Role;

public class RoleManagementModel : PageModel
{

    private readonly IRoleService _roleService;

    public RoleManagementModel(IRoleService roleService)
    {
        _roleService = roleService;
    }

    public List<RoleModelView> Roles { get; set; }

    public async Task OnGetAsync(int pageNumber = 1, int pageSize = 10)
    {
        var result = await _roleService.GetAllRoleAsync(pageNumber, pageSize, null, null);
        Roles = result.Items.ToList();
    }

}
