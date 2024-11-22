using Azure.Core;
using HairSalon.Contract.Services.Interface;
using HairSalon.Repositories.Entity;
using HairSalon.Services.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Security.Policy;
using System.Text.Encodings.Web;
using HairSalon.Contract.Repositories.Entity;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using HairSalon.Contract.Repositories.Interface;
using HairSalon.Repositories.UOW;
using Microsoft.EntityFrameworkCore;

public class ExternalLoginModel : PageModel
{
    private readonly SignInManager<ApplicationUsers> _signInManager;
    private readonly UserManager<ApplicationUsers> _userManager;
    private readonly TokenService _tokenService;
    private readonly IEmailService _emailSender;
    private readonly ILogger<ExternalLoginModel> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public ExternalLoginModel(
        IUnitOfWork unitOfWork,
        SignInManager<ApplicationUsers> signInManager,
        UserManager<ApplicationUsers> userManager,
        TokenService tokenService,
        ILogger<ExternalLoginModel> logger,
        IEmailService emailSender)
    {
        _unitOfWork = unitOfWork;
        _signInManager = signInManager;
        _userManager = userManager;
        _tokenService = tokenService;
        _logger = logger;
        _emailSender = emailSender;
    }

    [BindProperty]
    public InputModel Input { get; set; }

    public string ProviderDisplayName { get; set; }
    public string ReturnUrl { get; set; }

    [TempData]
    public string ErrorMessage { get; set; }

    public class InputModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }

    public IActionResult OnGetAsync()
    {
        return RedirectToPage("./Login");
    }

    public IActionResult OnPost(string provider, string returnUrl = null)
    {
        var redirectUrl = Url.Page("./ExternalLogin", pageHandler: "Callback", values: new { returnUrl });
        var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
        return new ChallengeResult(provider, properties);
    }

    public async Task<IActionResult> OnGetCallbackAsync(string returnUrl = null, string remoteError = null)
    {
        // Set the return URL or default to home
        returnUrl ??= Url.Content("~/");

        // Handle external provider errors
        if (remoteError != null)
        {
            ErrorMessage = $"Error from external provider: {remoteError}";
            return RedirectToPage("./Login", new { ReturnUrl = returnUrl });
        }

        // Get external login information
        var info = await _signInManager.GetExternalLoginInfoAsync();
        if (info == null)
        {
            ErrorMessage = "Error loading external login information.";
            return RedirectToPage("./Login", new { ReturnUrl = returnUrl });
        }

        // Try signing in with external login
        var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);

        if (result.Succeeded)
        {
            // Successful login: log information and set session data
            _logger.LogInformation("{Name} logged in with {LoginProvider} provider.", info.Principal.Identity.Name, info.LoginProvider);

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

            return Redirect("/Index");

        } else {

            // If the user does not have an account, then ask the user to create an account.
            ReturnUrl = returnUrl;
            ProviderDisplayName = info.ProviderDisplayName;
            if (info.Principal.HasClaim(c => c.Type == ClaimTypes.Email))
            {
                Input = new InputModel
                {
                    Email = info.Principal.FindFirstValue(ClaimTypes.Email)
                };
            }

            return Page();
        }
    }

    public async Task<IActionResult> OnPostConfirmationAsync(string returnUrl = null)
    {
        returnUrl = returnUrl ?? Url.Content("~/");

        var info = await _signInManager.GetExternalLoginInfoAsync();
        if (info == null)
        {
            _logger.LogWarning("Failed to retrieve external login information.");
            ErrorMessage = "Error loading external login information.";
            return RedirectToPage("/Login", new { ReturnUrl = returnUrl });
        }

        if (ModelState.IsValid)
        {

            var userInfo = new UserInfo
            {
                Firstname = Input.Email.Split('@')[0],
                Lastname = Input.Email.Split('@')[1],
            };

            var user = new ApplicationUsers
            {
                UserName = Input.Email.Split('@')[0],
                Email = Input.Email,
                UserInfo = userInfo,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user);
            if (result.Succeeded)
            {
                result = await _userManager.AddLoginAsync(user, info);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created an account using {Name} provider.", info.LoginProvider);

                    // Assign the "User" role to the new account
                    try
                    {
                        // Check if the "User" role exists
                        var roleRepository = _unitOfWork.GetRepository<ApplicationRoles>();
                        var userRole = await roleRepository.Entities.FirstOrDefaultAsync(r => r.Name == "User");
                        if (userRole == null)
                        {
                            ModelState.AddModelError(string.Empty, "The 'User' role does not exist. Please create it first.");
                            return Page();
                        }

                        // Create and insert the user-role mapping
                        var userRoleRepository = _unitOfWork.GetRepository<ApplicationUserRoles>();
                        var applicationUserRole = new ApplicationUserRoles
                        {
                            UserId = user.Id,
                            RoleId = userRole.Id,
                            CreatedBy = user.Id.ToString(),
                            CreatedTime = DateTime.UtcNow,
                            LastUpdatedBy = user.Id.ToString(),
                            LastUpdatedTime = DateTime.UtcNow
                        };

                        await userRoleRepository.InsertAsync(applicationUserRole);
                        await _unitOfWork.SaveAsync();
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Error assigning role to the user.");
                        ModelState.AddModelError(string.Empty, "An error occurred while assigning the role.");
                        return Page();
                    }

                    // Generate email confirmation token and send the confirmation email
                    var userId = await _userManager.GetUserIdAsync(user);
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

                    await _emailSender.SendEmailExternalAsync(Input.Email, "Welcome to HairSalon!",
                        $"Hello {Input.Email},<br><br>" +
                        $"We're excited to have you on board at HairSalon! Your account has been successfully created.<br>" +
                        "Thank you for choosing HairSalon!<br>" +
                        "Best regards,<br>" +
                        "The HairSalon Team"
                        );

                    await _signInManager.SignInAsync(user, isPersistent: false, info.LoginProvider);

                    return Redirect("/Login/ConfirmEmailExternal");
                }
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        ProviderDisplayName = info.ProviderDisplayName;
        ReturnUrl = returnUrl;
        return Page();
    }

}