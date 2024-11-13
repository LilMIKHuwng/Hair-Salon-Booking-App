using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.ApplicationUserModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HairSalon.RazorPage.Pages.Login
{
    public class CreateUserModel : PageModel
    {
        private readonly IAppUserService _appUserService;

        public CreateUserModel(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        [BindProperty]
        public CreateAppUserModelView UserModel { get; set; }

        [TempData]
        public string SuccessMessage { get; set; }

        public void OnGet()
        {
            // Initialization or default values can be set here if needed
            UserModel = new CreateAppUserModelView();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = await _appUserService.AddAppUserAsync(UserModel);
            if (result == "User added successfully. Please check your email for the OTP to confirm your account.")
            {
                SuccessMessage = result;
                TempData["Email"] = UserModel.Email;
                return RedirectToPage("/Login/ConfirmEmail"); // Redirect to a page displaying all users or confirmation
            }

            TempData["ErrorMessage"] = result; // Show error message if user creation failed
            return Page();
        }
    }
}
