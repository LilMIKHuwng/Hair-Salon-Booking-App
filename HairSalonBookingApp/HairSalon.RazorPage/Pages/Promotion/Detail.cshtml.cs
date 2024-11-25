using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.PromotionModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace HairSalon.RazorPage.Pages.Promotion
{
    public class DetailModel : PageModel
    {
        private readonly IPromotionService _promotionService;

        public DetailModel(IPromotionService promotionService)
        {
            _promotionService = promotionService;
        }

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }

        public PromotionModelView PromotionDetail { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            // Get roleId from TempData
            if (TempData.ContainsKey("PromotionId"))
            {
                Id = TempData["PromotionId"].ToString();
            }

            // Check if Id is provided
            if (string.IsNullOrEmpty(Id))
            {
                TempData["ErrorMessage"] = "Invalid Promotion ID.";
                return RedirectToPage("/Error"); // Redirect to error page if Id is missing
            }

            // Retrieve user roles from session
            var userRolesJson = HttpContext.Session.GetString("UserRoles");
            if (userRolesJson == null)
            {
                TempData["DeniedMessage"] = "You do not have permission to view this Promotion.";
                return Page(); // Show denied message if user roles are missing
            }

            var userRoles = JsonConvert.DeserializeObject<List<string>>(userRolesJson);

            // Check if the user has "Admin" or "Manager" roles
            if (!userRoles.Any(role => role == "Admin"))
            {
                TempData["DeniedMessage"] = "You do not have permission to view this Promotion.";
                return Page(); // Show denied message if user lacks permissions
            }

            PromotionDetail = await _promotionService.GetPromotionByIdAsync(Id);
            if (PromotionDetail == null)
            {
                TempData["ErrorMessage"] = "Promotion not found.";
                return RedirectToPage("/Promotion/Index");
            }
            return Page();
        }
    }
}
