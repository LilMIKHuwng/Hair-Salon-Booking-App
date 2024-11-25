using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.AuthModelViews;
using HairSalon.Repositories.Entity;
using HairSalon.Services.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace HairSalon.RazorPage.Pages.Login
{
    public class LoginModel : PageModel
    {
        private readonly IAppUserService _appUserService;
        private readonly IConfiguration _configuration;
        private readonly TokenService _tokenService;
        private readonly SignInManager<ApplicationUsers> _signInManager;
        private readonly ILogger<LoginModel> _logger;

        public LoginModel(
            IAppUserService appUserService,
            IConfiguration configuration,
            TokenService tokenService,
            SignInManager<ApplicationUsers> signInManager,
            ILogger<LoginModel> logger)
        {
            _appUserService = appUserService;
            _configuration = configuration;
            _tokenService = tokenService;
            _signInManager = signInManager;
            _logger = logger;
        }

        [BindProperty]
        public LoginModelView LoginModelView { get; set; }
        public IList<AuthenticationScheme> ExternalLogins { get; set; }
        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl ??= Url.Content("~/");

            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync()
        {

            ApplicationUsers account = await _appUserService.AuthenticateAsync(LoginModelView);

            if (account == null)
            {
                TempData["ErrorMessage"] = "Invalid login attempt";
                return Page();
            }

            var token = await _tokenService.GenerateJwtTokenAsync(account.Id.ToString(), account.UserName);

            if (token == null)
            {
                TempData["ErrorMessage"] = "Failed to retrieve token";
                return Page();
            }

            // Get user roles using the access token
            var userRoles = await _tokenService.GetUserRoles(token.AccessToken);

            if (userRoles != null)
            {
                HttpContext.Session.SetString("UserId", account.Id.ToString());
                HttpContext.Session.SetString("Username", account.UserName.ToString());
                HttpContext.Session.SetString("UserRoles", JsonConvert.SerializeObject(userRoles));
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to retrieve user roles";
                return Page();
            }

            return Redirect("/Index"); // Redirect to Index on successful login
        }
    }
}
