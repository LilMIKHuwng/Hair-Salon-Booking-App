using HairSalon.ModelViews.ApplicationUserModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HairSalon.RazorPage.Pages.Login
{
    public class EnterOtpModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public EnterOtpModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [BindProperty]
        public ResetPasswordModelView OtpModel { get; set; } = new ResetPasswordModelView();

        public string ResponseMessage { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var response = await _httpClient.PostAsJsonAsync("https://localhost:7286/api/applicationuser/reset-password", OtpModel);

            if (response.IsSuccessStatusCode)
            {
                ResponseMessage = await response.Content.ReadAsStringAsync();
                // Store ResponseMessage in TempData and redirect to the Login page
                TempData["ResponseMessage"] = ResponseMessage;
                return Redirect("/Login/Login");
            }
            else
            {
                ResponseMessage = "Error: " + await response.Content.ReadAsStringAsync();
            }

            return Page();
        }
    }
}
