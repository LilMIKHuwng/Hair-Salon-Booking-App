using DocumentFormat.OpenXml.EMMA;
using HairSalon.Repositories.Entity;
using HairSalon.Services.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace HairSalon.RazorPage.Pages.Login
{
    public class ConfirmEmailExternalModel : PageModel
    {
        private readonly UserManager<ApplicationUsers> _userManager;
        private readonly SignInManager<ApplicationUsers> _signInManager;
        private readonly ILogger<ConfirmEmailExternalModel> _logger;
        private readonly TokenService _tokenService;

        public ConfirmEmailExternalModel(TokenService tokenService, UserManager<ApplicationUsers> userManager, SignInManager<ApplicationUsers> signInManager, ILogger<ConfirmEmailExternalModel> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _logger = logger;
        }

        [TempData]
        public string StatusMessage { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var info = await _signInManager.GetExternalLoginInfoAsync();

            var account = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);
            if (account != null)
            {
                var token = await _tokenService.GenerateJwtTokenAsync(account.Id.ToString(), account.UserName);

                if (token != null)
                {
                    HttpContext.Session.SetString("UserId", account.Id.ToString());
                    HttpContext.Session.SetString("Username", account.UserName);
                    HttpContext.Session.SetString("UserRoles", JsonConvert.SerializeObject(await _tokenService.GetUserRoles(token.AccessToken)));
                }
            }

            StatusMessage = "Your email has been successfully confirmed! Welcome to HairSalon, you're now all set to get started!";
            return Page();
        }
    }
}
