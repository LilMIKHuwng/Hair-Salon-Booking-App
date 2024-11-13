using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.ComboModelViews;
using HairSalon.ModelViews.ServiceModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HairSalon.RazorPage.Pages.Combo
{
    public class UpdateModel : PageModel
    {
        private readonly IComboService _comboService;
        private readonly IServiceService _serviceService;

        public UpdateModel(IComboService comboService, IServiceService serviceService)
        {
            _comboService = comboService;
            _serviceService = serviceService;
        }

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }

        [BindProperty]
        public ComboModelView Combo { get; set; }

        [BindProperty]
        public UpdateComboModelView UpdatedCombo { get; set; } = new UpdateComboModelView(); // Đảm bảo đã được khởi tạo

        [TempData]
        public string ErrorMessage { get; set; }

        [TempData]
        public string ResponseMessage { get; set; }

        public List<ServiceModelView> AvailableServices { get; set; }

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

			Combo = await _comboService.GetComboByIdAsync(Id);
            if (Combo == null)
            {
                ErrorMessage = "Combo not found.";
                return RedirectToPage("/Combos");
            }

            UpdatedCombo = new UpdateComboModelView
            {
                Name = Combo.Name,
                ServiceIds = Combo.ServiceIds ?? Array.Empty<string>()  
            };

            AvailableServices = await _serviceService.GetAllServiceAsync(); 

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var selectedServiceIds = Request.Form["UpdatedCombo.ServiceIds"];
            UpdatedCombo.ServiceIds = selectedServiceIds.ToArray();

			var userId = HttpContext.Session.GetString("UserId");

			var response = await _comboService.UpdateComboAsync(Id, UpdatedCombo, userId);
            if (response == "Combo successfully updated with services.")
            {
                ResponseMessage = response;
                return RedirectToPage("/Combo/Index");
            }

            ErrorMessage = response;
            return Page();
        }
    }
}
