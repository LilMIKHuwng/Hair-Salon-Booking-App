using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.ApplicationUserModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

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
        public CreateAppStylistModelView UserModel { get; set; }

        [TempData]
        public string SuccessMessage { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            // Initialization or default values can be set here if needed
            UserModel = new CreateAppStylistModelView();

            // Retrieve user roles from session
            var userRolesJson = HttpContext.Session.GetString("UserRoles");
            if (userRolesJson == null)
            {
                TempData["DeniedMessage"] = "You do not have permission";
                return RedirectToPage("/Error");
            }

            var userRoles = JsonConvert.DeserializeObject<List<string>>(userRolesJson);

            // Check if the user has "Admin" or "Manager" roles
            if (!userRoles.Any(role => role == "Admin" || role == "Manager"))
            {
                TempData["DeniedMessage"] = "You do not have permission";
                return Page(); // Redirect to a different page with a denied message
            }

            return Page(); // Allow access to the page if the user has the correct role
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = await _appUserService.AddAppStylistAsync(UserModel);

            TempData["ErrorMessage"] = result; // Show error message if user creation failed
            return Page();
        }
    }
}
