using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.RoleModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace HairSalon.RazorPage.Pages.Role
{
	public class UpdateModel : PageModel
	{
		private readonly IRoleService _roleService;

		public UpdateModel(IRoleService roleService)
		{
			_roleService = roleService;
		}

		[BindProperty(SupportsGet = true)]
		public string Id { get; set; }

		[BindProperty]
		public RoleModelView Role { get; set; }

		[BindProperty] // Bind UpdatedRole to be populated from the form
		public UpdatedRoleModelView UpdatedRole { get; set; }

		[TempData]
		public string ResponseMessage { get; set; }

		// OnGetAsync method to handle GET request, populate data for form
		public async Task<IActionResult> OnGetAsync()
		{
			// Get roleId from TempData
			if (TempData.ContainsKey("RoleId"))
			{
				Id = TempData["RoleId"].ToString();
			}

			if (string.IsNullOrEmpty(Id))
			{
				TempData["ErrorMessage"] = "Invalid Role ID.";
				return RedirectToPage("/Error");
			}

			var userRolesJson = HttpContext.Session.GetString("UserRoles");
			if (userRolesJson == null)
			{
				TempData["DeniedMessage"] = "You do not have permission";
				return RedirectToPage("/Error");
			}

			var userRoles = JsonConvert.DeserializeObject<List<string>>(userRolesJson);

			if (!userRoles.Any(role => role == "Admin"))
			{
				TempData["DeniedMessage"] = "You do not have permission";
				return Page();
			}

			Role = await _roleService.GetRoleByIdAsync(Id);
			if (Role == null)
			{
				TempData["ErrorMessage"] = "Role not found.";
				return RedirectToPage("/Role/Index");
			}

			UpdatedRole = new UpdatedRoleModelView { Name = Role.Name };
			return Page();
		}

		// OnPostAsync method to handle form submission
		public async Task<IActionResult> OnPostAsync()
		{
			// "Id" will be automatically populated from the hidden input in the form
			var userId = HttpContext.Session.GetString("UserId");

			var response = await _roleService.UpdateRoleAsync(Id, UpdatedRole, userId);
			if (response == "Role successfully updated")
			{
				ResponseMessage = response;
				return RedirectToPage("/Role/Index");
			}

			TempData["ErrorMessage"] = response;
			return Page();
		}
	}

}
