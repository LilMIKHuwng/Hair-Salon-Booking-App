using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HairSalon.RazorPage.Pages.Login
{
    public class LogoutModel : PageModel
    {
        public IActionResult OnGet()
        {
            // Display the confirmation page
            return Page();
        }

        public IActionResult OnPost()
        {
            // Clear UserId and UserRoles from session
            HttpContext.Session.Remove("UserId");
            HttpContext.Session.Remove("UserRoles");

            // Alternatively, use HttpContext.Session.Clear(); to clear all session variables if needed

            // Redirect to the login page or another preferred page
            return RedirectToPage("/Login/Login");
        }
    }
}
