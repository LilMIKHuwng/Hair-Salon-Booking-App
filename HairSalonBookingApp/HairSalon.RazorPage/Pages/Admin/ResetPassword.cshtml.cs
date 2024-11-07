using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.ApplicationUserModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace HairSalon.RazorPage.Pages.Admin;

public class ResetPasswordModel : PageModel
{
    private readonly IAppUserService _appUserService;

    public ResetPasswordModel(IAppUserService appUserService)
    {
        _appUserService = appUserService;
    }
    [BindProperty]
    public ResetPasswordAdminModelView Model { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {

        Model = new ResetPasswordAdminModelView();

        // Retrieve user roles from session
        var userRolesJson = HttpContext.Session.GetString("UserRoles");
        if (userRolesJson == null)
        {
            TempData["DeniedMessage"] = "You do not have permission";
            return RedirectToPage("/Error");
        }

        var userRoles = JsonConvert.DeserializeObject<List<string>>(userRolesJson);

        // Check if the user has "Admin" or "Manager" roles
        if (!userRoles.Any(role => role == "Admin"))
        {
            TempData["DeniedMessage"] = "You do not have permission";
            return Page(); // Redirect to a different page with a denied message
        }

        return Page(); // Allow access to the page if the user has the correct role
    }

    public async Task<IActionResult> OnPost()
    {
        if (!ModelState.IsValid)
        {
            TempData["ErrorMessage"] = "Please fix the errors in the form.";
            return Page();
        }

        // Call your service to reset the password here
        var isResetSuccessful = await _appUserService.ResetPasswordAdminAsync(Model);

        if (isResetSuccessful == "Password reset successfully.")
        {
            TempData["SuccessMessage"] = "Password reset successfully!";
            return Page(); // Optionally redirect to a success page
        }
        else
        {
            TempData["ErrorMessage"] = isResetSuccessful;
            return Page();
        }
    }
}