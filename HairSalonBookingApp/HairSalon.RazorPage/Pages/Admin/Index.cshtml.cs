﻿using HairSalon.Contract.Services.Interface;
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

        if (userRolesJson != null)
        {
            var userRoles = JsonConvert.DeserializeObject<List<string>>(userRolesJson);

            // Check if the user has the "Admin" role
            if (!userRoles.Any(role => role == "Admin"))
            {
                TempData["ErrorMessage"] = "You do not have permission to view this page.";
                return Page(); // Show error message on the same page
            }
        }
        else
        {
            TempData["ErrorMessage"] = "You do not have permission to view this page.";
            return Page();
        }

        // If authorized, retrieve staff data with pagination and optional filters
        StaffList = await _userService.GetAllAppUserAsync(id, pageNumber, pageSize);
        return Page();
    }
}