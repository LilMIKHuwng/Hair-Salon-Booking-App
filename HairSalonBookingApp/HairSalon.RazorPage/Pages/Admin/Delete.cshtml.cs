using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.ApplicationUserModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HairSalon.RazorPage.Pages.Admin;

public class Delete : PageModel
{
    private readonly IAppUserService _userService;

    public Delete(IAppUserService userService)
    {
        _userService = userService;
    }
    [BindProperty(SupportsGet = true)]
    public string Id { get; set; }
    
    // Property to store response or success messages
    [TempData]
    public string ResponseMessage { get; set; }
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

        return Page();
    }
    
    public async Task<IActionResult> OnPostAsync()
    {
        var userId = HttpContext.Session.GetString("UserId");

        string response = await _userService.DeleteAppUserAsync(Id);
        if (response == "Role successfully deleted")
        {
            ResponseMessage = response;
            return RedirectToPage("/Admin/Index");
        }
        // Set ErrorMessage if deletion fails
        TempData["ErrorMessage"] = response;
        return RedirectToPage("/Admin/Index");
    }
}