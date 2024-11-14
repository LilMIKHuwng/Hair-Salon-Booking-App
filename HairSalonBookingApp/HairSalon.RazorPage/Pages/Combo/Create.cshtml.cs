using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.ComboModelViews;
using HairSalon.ModelViews.ServiceModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace HairSalon.RazorPage.Pages.Combo
{
    public class CreateModel : PageModel
    {
        private readonly IComboService _comboService;
        private readonly IServiceService _serviceService;

        public CreateModel(IComboService comboService, IServiceService serviceService)
        {
            _comboService = comboService;
            _serviceService = serviceService;
        }

        [BindProperty]
        public CreateComboModelView NewCombo { get; set; }
		public List<ServiceModelView> AvailableServices { get; set; }

		// Property to store error messages
		[TempData]
        public string ErrorMessage { get; set; }

        // Property to store response or success messages
        [TempData]
        public string ResponseMessage { get; set; }

        // Property to store denied access messages
        [TempData]
        public string DeniedMessage { get; set; }

		public async Task<IActionResult> OnGetAsync(string? id, string? name, string? type, int pageNumber = 1, int pageSize = 5)
		{
			// Retrieve user roles from session
			var userRolesJson = HttpContext.Session.GetString("UserRoles");
			if (userRolesJson == null)
			{
				TempData["DeniedMessage"] = "You do not have permission";
                return RedirectToPage("/Error");
            }

			var userRoles = JsonConvert.DeserializeObject<List<string>>(userRolesJson);

			// Check if the user has "Admin" or "Manager" roles
			if (!userRoles.Any(role => role == "Admin"))
			{
				TempData["DeniedMessage"] = "You do not have permission";
				return Page(); // Redirect to a different page with a denied message
			}

			AvailableServices = await _serviceService.GetAllServiceAsync();
			return Page(); // Allow access to the page if the user has the correct role
        }

		public async Task<IActionResult> OnPostAsync(string? id, string? name, string? type, int pageNumber = 1, int pageSize = 5)
		{
			if (ModelState.IsValid)
			{
                var userId = HttpContext.Session.GetString("UserId");

                string response = await _comboService.CreateComboAsync(NewCombo, userId);
				if (response == "Combo successfully created.")

                {
					ResponseMessage = response;
					return RedirectToPage("/Combo/Index"); // Redirect back to the combo list page
				}
				// Set ErrorMessage if there’s an error
				ErrorMessage = response;
			}
			return Page(); // Return the same page in case of validation errors or other issues
		}

	}
}
