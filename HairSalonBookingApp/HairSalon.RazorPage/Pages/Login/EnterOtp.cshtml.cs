using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.ApplicationUserModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HairSalon.RazorPage.Pages.Login
{
    public class EnterOtpModel : PageModel
    {
        private readonly IAppUserService _appUserService;

        public EnterOtpModel(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        [BindProperty]
        public ResetPasswordModelView OtpModel { get; set; } = new ResetPasswordModelView();

        // Property to store response or success messages
        [TempData]
        public string ResponseMessage { get; set; }

        // Property to store error messages
        [TempData]
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var response = await _appUserService.ResetPasswordAsync(OtpModel);

            if (response == "Invalid or expired OTP code.")
            {
                TempData["ErrorMessage"] = response;
            }
            else
            {
                // Store ResponseMessage in TempData and redirect to the Login page
                ResponseMessage = response;
                return RedirectToPage("/Login/Login");
            }

            return Page();
        }
    }
}
