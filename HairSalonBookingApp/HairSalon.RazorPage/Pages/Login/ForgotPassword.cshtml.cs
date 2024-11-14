using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.ApplicationUserModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HairSalon.RazorPage.Pages.Login
{
    public class ForgotPasswordModel : PageModel
    {
        private readonly IAppUserService _appUserService;

        public ForgotPasswordModel(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        [BindProperty]
        public string Email { get; set; }

        // Property to store response or success messages
        [TempData]
        public string ResponseMessage { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var model = new ForgotPasswordModelView { Email = Email };
            var response = await _appUserService.ForgotPasswordAsync(model);

            if (response == "Email not found.")
            {
                TempData["ErrorMessage"] = response;
            }
            else
            {
                ResponseMessage = response;
                TempData["Email"] = Email;
                // Use Redirect to pass the email to the EnterOtp page as a query parameter
                return RedirectToPage("/Login/EnterOtp");
            }

            return Page();
        }
    }
}
