using HairSalon.ModelViews.AuthModelViews;
using HairSalon.ModelViews.TokenModelViews;
using HairSalon.Services.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;

namespace HairSalonRazorApp.Pages
{
    public class Login : PageModel
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly TokenService _tokenService; 

        public Login(HttpClient httpClient, IConfiguration configuration, TokenService tokenService)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _tokenService = tokenService;
        }

        [BindProperty]
        public LoginModelView LoginModel { get; set; }

        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var jsonContent = JsonConvert.SerializeObject(LoginModel);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync("https://localhost:7286/api/auth/auth-account", content);

            if (response.IsSuccessStatusCode)
            {
                // Deserialize the response to get the tokens
                var responseBody = await response.Content.ReadAsStringAsync();
                var tokenResponse = JsonConvert.DeserializeObject<TokenModelView>(responseBody);

                if (tokenResponse == null)
                {
                    ErrorMessage = "Failed to retrieve token";
                    return Page();
                }

                // Get user roles using the access token
                var userRoles = await _tokenService.GetUserRoles(tokenResponse.AccessToken);

                // Check for required roles
                if (userRoles.Any(role => role == "Admin" || role == "Manager" || role == "Stylist"))
                {
                    HttpContext.Response.Cookies.Append("AuthToken", tokenResponse.AccessToken, new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true // Ensure this is true in production
                    });

                    return Redirect("/Index"); // Redirect to Index on successful login
                }
                else
                {
                    ErrorMessage = "Access denied. Insufficient permissions.";
                    return Page();
                }
            }
            else
            {
                ErrorMessage = "Invalid login attempt"; // Handle unauthorized access
                return Page();
            }
        }


    }

}
