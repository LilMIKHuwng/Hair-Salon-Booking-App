using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.ComboModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace HairSalon.RazorPage.Pages.Combo
{
    public class DeleteModel : PageModel
    {
        private readonly IComboService _comboService;

        public DeleteModel(IComboService comboService)
        {
            _comboService = comboService;
        }
        
        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }

        public ComboModelView Combo { get; set; }

        // Property to store error messages
        [TempData]
        public string ErrorMessage { get; set; }

        // Property to store response or success messages
        [TempData]
        public string ResponseMessage { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            // Get Id from TempData
            if (TempData.ContainsKey("ComboId"))
            {
                Id = TempData["ComboId"].ToString();
            }

            // Check if Id is provided
            if (string.IsNullOrEmpty(Id))
			{
				TempData["ErrorMessage"] = "Invalid Combo ID.";
				return RedirectToPage("/Error"); // Redirect to error page if Id is missing
			}

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

			Combo = await _comboService.GetComboByIdAsync(Id);
            if (Combo == null)
            {
                ErrorMessage = "Combo Not Found";
                return RedirectToPage("/Combo/Index");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
			var userId = HttpContext.Session.GetString("UserId");

			string response = await _comboService.DeleteComboAsync(Id, userId);
            if (response == "Deleted combo successfully!")
            {
                ResponseMessage = response;
                return RedirectToPage("/Combo/Index");
            }
            // Set ErrorMessage if deletion fails
            ErrorMessage = response;
            return Page();
        }
    }
}
