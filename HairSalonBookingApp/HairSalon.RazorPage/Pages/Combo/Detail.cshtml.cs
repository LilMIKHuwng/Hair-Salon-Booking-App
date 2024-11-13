using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.ComboModelViews;
using HairSalon.ModelViews.ServiceModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace HairSalon.RazorPage.Pages.Combo
{
    public class DetailModel : PageModel
    {
        private readonly IComboService _comboService;
        private readonly IServiceService _serviceService;

        public DetailModel(IComboService comboService, IServiceService serviceService)
        {
            _comboService = comboService;
            _serviceService = serviceService;
        }

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }

        public ComboModelView ComboDetail { get; set; }
        public IEnumerable<ServiceModelView> SelectedServices { get; set; } 

        public async Task<IActionResult> OnGetAsync()
        {
			// Retrieve user roles from session
			var userRolesJson = HttpContext.Session.GetString("UserRoles");
			if (userRolesJson == null)
			{
				TempData["DeniedMessage"] = "You do not have permission";
                return RedirectToPage("/Error");
            }

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

            var userRoles = JsonConvert.DeserializeObject<List<string>>(userRolesJson);

			// Check if the user has "Admin" or "Manager" roles
			if (!userRoles.Any(role => role == "Admin"))
			{
				TempData["DeniedMessage"] = "You do not have permission";
				return Page(); // Redirect to a different page with a denied message
			}

			ComboDetail = await _comboService.GetComboByIdAsync(Id);
            if (ComboDetail == null)
            {
                TempData["ErrorMessage"] = "Combo not found.";
                return RedirectToPage("/Combos");
            }

            if (ComboDetail.ServiceIds != null && ComboDetail.ServiceIds.Any())
            {
                SelectedServices = await _serviceService.GetByIdsAsync(ComboDetail.ServiceIds);
            }
            else
            {
                SelectedServices = Enumerable.Empty<ServiceModelView>();
            }

            return Page();
        }
    }
}
