using HairSalon.ModelViews.ApplicationUserModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HairSalon.RazorPage.Pages.Login
{
    public class ForgotPasswordModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public ForgotPasswordModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [BindProperty]
        public string Email { get; set; }

        public string ResponseMessage { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var model = new ForgotPasswordModelView { Email = Email };
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7286/api/applicationuser/forgot-password", model);

            if (response.IsSuccessStatusCode)
            {
                ResponseMessage = await response.Content.ReadAsStringAsync();
                TempData["ResponseMessage"] = ResponseMessage;
                TempData["Email"] = Email;
                // Use Redirect to pass the email to the EnterOtp page as a query parameter
                return Redirect("/Login/EnterOtp");
            }
            else
            {
                ResponseMessage = "Error: " + await response.Content.ReadAsStringAsync();
            }

            return Page();
        }
    }
}
