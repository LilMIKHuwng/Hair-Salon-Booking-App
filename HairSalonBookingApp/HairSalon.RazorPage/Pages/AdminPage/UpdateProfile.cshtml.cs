using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.ApplicationUserModelViews;
using HairSalon.Repositories.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace HairSalon.RazorPage.Pages.AdminPage
{
	public class UpdateProfileModel : PageModel
	{
		private readonly IAppUserService _userService;
		private readonly UserManager<ApplicationUsers> _userManager;

		public UpdateProfileModel(IAppUserService userService, UserManager<ApplicationUsers> userManager)
		{
			_userService = userService;
			_userManager = userManager;
		}

		[BindProperty]
		public GetInforAppUserModelView UserInfo { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }

        public async Task<IActionResult> OnGetAsync()
		{
			// Check if user roles exist in session
			var userRolesJson = HttpContext.Session.GetString("UserRoles");
			if (string.IsNullOrEmpty(userRolesJson))
			{
				TempData["ErrorMessage"] = "You do not have permission to view this page.";
				return RedirectToPage("/Login/Login");
			}

			// Retrieve username from session
			var username = HttpContext.Session.GetString("Username");
			if (string.IsNullOrEmpty(username))
			{
				TempData["ErrorMessage"] = "Unable to identify the current user. Please log in again.";
				return RedirectToPage("/Login/Login");
			}

			// Retrieve user info
			UserInfo = await _userService.GetMyInforUsersAsync(username);
			if (UserInfo == null)
			{
				TempData["ErrorMessage"] = "Failed to retrieve user information.";
				return Page();
			}

			return Page();
		}
        public async Task<IActionResult> OnPostAsync()
        {
            // Check session for username
            var username = HttpContext.Session.GetString("Username");
            if (string.IsNullOrEmpty(username))
            {
                TempData["ErrorMessage"] = "Unable to identify the current user. Please log in again.";
                return RedirectToPage("/Login/Login");
            }

            // Check if email is null or empty
            if (string.IsNullOrEmpty(UserInfo.Email))
            {
                TempData["ErrorMessage"] = "Email cannot be empty.";
                return Page();
            }

            // Check if email already exists
            var existingEmailUser = await _userManager.FindByEmailAsync(UserInfo.Email);
            if (existingEmailUser != null && existingEmailUser.UserName != username)
            {
                TempData["ErrorMessage"] = "The email address is already in use by another user.";
                return Page();
            }

            // Check phone number (must be 10 digits and start with '0')
            if (string.IsNullOrEmpty(UserInfo.PhoneNumber) || UserInfo.PhoneNumber.Length != 10 || UserInfo.PhoneNumber[0] != '0')
            {
                TempData["ErrorMessage"] = "The phone number must be 10 digits and start with '0'.";
                return Page();
            }

            // Retrieve user from the database
            var appUser = await _userManager.Users
                .Include(u => u.UserInfo)
                .FirstOrDefaultAsync(u => u.UserName == username);

            if (appUser == null)
            {
                TempData["ErrorMessage"] = "User not found. Please ensure the account exists.";
                return RedirectToPage("/AdminPage/UpdateProfile");
            }

            try
            {
                // Update user basic info
                appUser.Email = UserInfo.Email;
                appUser.PhoneNumber = UserInfo.PhoneNumber;

                // Update extended user info
                if (appUser.UserInfo != null)
                {
                    appUser.UserInfo.Firstname = UserInfo.FirstName;
                    appUser.UserInfo.Lastname = UserInfo.LastName;
                    appUser.UserInfo.BankAccount = UserInfo.BankAccount;

                    // Check if username is being updated
                    if (appUser.UserName != UserInfo.UserName)
                    {
                        // Update the username in the appUser entity
                        appUser.UserName = UserInfo.UserName;

                        // Update the username in the session
                        HttpContext.Session.SetString("Username", UserInfo.UserName);
                    }
                }

                // Save changes
                var result = await _userManager.UpdateAsync(appUser);
                if (!result.Succeeded)
                {
                    TempData["ErrorMessage"] = "Failed to update profile. Please check your input and try again.";
                    return Page();
                }

                TempData["ResponseMessage"] = "Profile updated successfully!";
                return RedirectToPage("/AdminPage/Profile");
            }
            catch (DbUpdateException ex)
            {
                TempData["ErrorMessage"] = "A database error occurred. Please try again later.";
                Console.Error.WriteLine($"Database update failed: {ex}");
                return Page();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An unexpected error occurred. Please try again later.";
                Console.Error.WriteLine($"Unexpected error: {ex}");
                return Page();
            }
        }
    }
}
