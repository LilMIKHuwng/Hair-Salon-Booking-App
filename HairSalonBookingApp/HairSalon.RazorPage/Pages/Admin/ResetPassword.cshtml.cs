using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.ApplicationUserModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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

    public void OnGet()
    {
        Model = new ResetPasswordAdminModelView();
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