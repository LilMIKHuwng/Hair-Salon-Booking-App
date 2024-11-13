using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.ApplicationUserModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HairSalon.RazorPage.Pages.Admin;

public class Detail : PageModel
{
    private readonly IAppUserService _userService;

    public Detail(IAppUserService userService)
    {
        _userService = userService;
    }
    [BindProperty(SupportsGet = true)]
    public string Id { get; set; }
    public GetInforAppUserModelView UserDetail { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
		// Get Id from TempData
		if (TempData.ContainsKey("UserId"))
		{
			Id = TempData["UserId"].ToString();
		}

		// Check if Id is provided
		if (string.IsNullOrEmpty(Id))
        {
            TempData["ErrorMessage"] = "Invalid User ID.";
            return RedirectToPage("/Error"); // Redirect to error page if Id is missing
        }

        // Retrieve user roles from session
        var userRolesJson = HttpContext.Session.GetString("UserRoles");
        if (userRolesJson == null)
        {
            TempData["DeniedMessage"] = "You do not have permission to view user details.";
            return RedirectToPage("/Error");
        }

        var result = await _userService.GetAllAppUserAsync(Id, 1, 1);
        UserDetail  = await _userService.GetMyInforUsersAsync(result.Items.FirstOrDefault(x => true).UserName);

        if (UserDetail == null)
        {
            TempData["ErrorMessage"] = "User not found.";
            return RedirectToPage("/User/Index");
        }

        return Page();
    }
}