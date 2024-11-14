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
            return RedirectToPage("/Error");
        }

        // If authorized, retrieve staff data with pagination and optional filters
        
        StaffList = await _userService.GetAllAppUserAsync(id, pageNumber, pageSize);
        if (!userRoles.Any(role => role == "Admin" || role == "Manager"))
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

	public async Task<IActionResult> OnPostAsync(string id, string action)
	{
		if (string.IsNullOrEmpty(id))
		{
			TempData["ErrorMessage"] = "User ID is required.";
			return RedirectToPage();
		}

		//Save roleId to tempdata
		TempData["UserId"] = id;

		switch (action?.ToLower())
		{
			case "update":
				return RedirectToPage("/Admin/Update");
			case "detail":
				return RedirectToPage("/Admin/Detail");
			case "delete":
				return RedirectToPage("/Admin/Delete");
			default:
				TempData["ErrorMessage"] = "Invalid action.";
				return RedirectToPage();
		}
	}

}