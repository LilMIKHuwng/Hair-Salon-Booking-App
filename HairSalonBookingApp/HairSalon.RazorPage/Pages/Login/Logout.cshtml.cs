using HairSalon.Services.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace HairSalon.RazorPage.Pages.Login
{
    public class LogoutModel : PageModel
    {
        private readonly TokenService _tokenService;

        public LogoutModel(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            // Retrieve user roles from session
            var userRolesJson = HttpContext.Session.GetString("UserRoles");
            if (userRolesJson == null)
            {
                TempData["DeniedMessage"] = "You do not have permission";
                return Page(); // Redirect to a different page with a denied message
            }

            var userRoles = JsonConvert.DeserializeObject<List<string>>(userRolesJson);

            // Check if the user has "Admin" or "Manager" roles
            if (userRoles == null)
            {
                TempData["DeniedMessage"] = "You do not have permission";
                return Page(); // Redirect to a different page with a denied message
            }

            return Page(); // Allow access to the page if the user has the correct role
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var username = HttpContext.Session.GetString("Username");

            var result = await _tokenService.Revoke(username); // Make sure Revoke is asynchronous

            if (result == null)
            {
                TempData["ErrorMessage"] = "Failed to Logout";
                return Page();
            }
            else
            {
                // Clear UserId and UserRoles from session
                HttpContext.Session.Remove("UserId");
                HttpContext.Session.Remove("UserRoles");
                HttpContext.Session.Remove("Username");

                // Alternatively, use HttpContext.Session.Clear(); to clear all session variables if needed

                // Redirect to the login page or another preferred page
                return RedirectToPage("/Login/Login");
            }
        }
    }
}
