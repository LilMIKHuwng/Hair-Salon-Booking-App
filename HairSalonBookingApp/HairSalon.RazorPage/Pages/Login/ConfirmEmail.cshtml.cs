using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.ApplicationUserModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HairSalon.RazorPage.Pages.Login
{
    public class ConfirmEmailModel : PageModel
    {
        private readonly IAppUserService _appUserService;

        public ConfirmEmailModel(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        // Email property, with validation, populated from TempData in OnGet
        [BindProperty]
        public string Email { get; set; }

        // OTP code property, with validation
        [BindProperty]
        public string OtpCode { get; set; }

        // TempData properties to store messages
        [TempData]
        public string ResponseMessage { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Create the model for confirmation
            var confirmEmailModel = new ConfirmEmailModelView
            {
                Email = Email,
                OtpCode = OtpCode
            };

            // Call the service to confirm email
            var response = await _appUserService.ConfirmEmailAsync(confirmEmailModel);
            if (response == "Email confirmed successfully. Your account is now active.")
            {
                ResponseMessage = response;
                return RedirectToPage("/Login/Login");
            }

            // If confirmation fails, display error message
            TempData["ErrorMessage"] = response;
            return Page();
        }
    }
}
