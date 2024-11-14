using AutoMapper;
using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.ApplicationUserModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HairSalon.RazorPage.Pages.Admin;

public class Update : PageModel
{
	private readonly IAppUserService _userService;

	public Update(IAppUserService userService, IMapper mapper)
	{
		_userService = userService;
	}

	[BindProperty(SupportsGet = true)]
	public string Id { get; set; }

	[BindProperty]
	public GetInforAppUserModelView User { get; set; }

	[BindProperty]
	public UpdateAppUserModelView UpdatedUser { get; set; }

	[TempData]
	public string ResponseMessage { get; set; }

	public async Task<IActionResult> OnGetAsync()
	{
		// Get Id from TempData
		if (TempData.ContainsKey("UserId"))
		{
			Id = TempData["UserId"].ToString();
		}

		// Check if Id is provided
		if (string.IsNullOrEmpty(Id))
		{
			TempData["ErrorMessage"] = "Invalid User ID.";
			return RedirectToPage("/Error"); // Redirect to error page if Id is missing
		}

		// Retrieve user roles from session
		var userRolesJson = HttpContext.Session.GetString("UserRoles");
		if (userRolesJson == null)
		{
			TempData["DeniedMessage"] = "You do not have permission to update a user.";
			return RedirectToPage("/Error");
		}


		var result = await _userService.GetAllAppUserAsync(Id, 1, 1);
		var userInfo = await _userService.GetMyInforUsersAsync(result.Items.FirstOrDefault(x => x.Id == Id).UserName);

		if (userInfo == null)
		{
			TempData["ErrorMessage"] = "User not found.";
			return RedirectToPage("/User/Index");
		}

		// Initialize UpdatedUser with existing user details for display in the form
		UpdatedUser = new UpdateAppUserModelView()
		{
			FirstName = userInfo.FirstName,
			LastName = userInfo.LastName,
			PhoneNumber = userInfo.PhoneNumber,
			Email = userInfo.Email,
			// Add other properties as needed
		};
		return Page();
	}

	public async Task<IActionResult> OnPostAsync()
	{
		var userId = HttpContext.Session.GetString("UserId");

		var response = await _userService.UpdateAppUserAsync(Id, UpdatedUser);



		if (response == "User successfully updated")
		{
			ResponseMessage = response;
			return RedirectToPage("/Admin/Index");
		}
		else if (response == "Email updated successfully. Please check your new email for a confirmation code.")
		{
			TempData["Email"] = UpdatedUser.Email;
			return RedirectToPage("/Admin/ConfirmEmail");
		}

		TempData["ErrorMessage"] = response;
		return Page();
	}
}
