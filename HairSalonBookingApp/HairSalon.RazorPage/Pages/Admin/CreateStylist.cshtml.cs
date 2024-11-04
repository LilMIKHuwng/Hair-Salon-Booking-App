using DocumentFormat.OpenXml.Spreadsheet;
using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.ApplicationUserModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HairSalon.RazorPage.Pages.Admin
{
    public class CreateStylistModel : PageModel
    {
        private readonly IAppUserService _appUserService;

        public CreateStylistModel(IAppUserService appUserService)
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

            TempData["ErrorMessage"] = result; // Show error message if user creation failed
            return Page();
        }
    }
}
