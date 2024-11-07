using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using HairSalon.ModelViews.ApplicationUserModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace HairSalon.RazorPage.Pages.Admin;

public class StaffManagementModel : PageModel
{
    private readonly IAppUserService _userService;

    public StaffManagementModel(IAppUserService userService)
    {
        _userService = userService;
    }

    public BasePaginatedList<AppUserModelView> StaffList { get; set; }
    
    public async Task<IActionResult> OnGetAsync(int pageNumber = 1, int pageSize = 5, string? id = null, string? name = null)
    {
        // Check user roles from session
        var userRolesJson = HttpContext.Session.GetString("UserRoles");
        List<string>? userRoles;
        if (userRolesJson != null)
        {
            userRoles = JsonConvert.DeserializeObject<List<string>>(userRolesJson);
            
            // Check if the user has the "Admin" role
        }
        else
        {
            TempData["ErrorMessage"] = "You do not have permission to view this page.";
            return Page();
        }

        // If authorized, retrieve staff data with pagination and optional filters
        
        StaffList = await _userService.GetAllAppUserAsync(id, pageNumber, pageSize);
        if (!userRoles.Any(role => role == "Admin"))
        {
            id = HttpContext.Session.GetString("UserId");
            StaffList = await _userService.GetAllAppUserAsync(id, pageNumber, pageSize);
        }
        else
        {
            TempData["role"] = "Admin";
        }
        return Page();
    }
}