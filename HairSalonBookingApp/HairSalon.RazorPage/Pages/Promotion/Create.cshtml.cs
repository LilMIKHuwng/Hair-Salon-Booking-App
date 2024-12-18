using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.PromotionModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace HairSalon.RazorPage.Pages.Promotion
{
    public class CreateModel : PageModel
    {
        private readonly IPromotionService _promotionService;

        public CreateModel(IPromotionService promotionService)
        {
            _promotionService = promotionService;
        }

        [BindProperty]
        public CreatePromotionModelView NewPromotion { get; set; }

        // Property to store response or success messages
        [TempData]
        public string ResponseMessage { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            // Retrieve user roles from session
            var userRolesJson = HttpContext.Session.GetString("UserRoles");
            if (userRolesJson == null)
            {
                TempData["DeniedMessage"] = "You do not have permission to add a promotion.";
                return RedirectToPage("/Error");
            }

            var userRoles = JsonConvert.DeserializeObject<List<string>>(userRolesJson);

            // Check if the user has "Admin" 
            if (!userRoles.Any(role => role == "Admin" || role == "Manager"))
            {
                TempData["DeniedMessage"] = "You do not have permission to add a promotion.";
                return Page();
            }

            return Page(); // Allow access to the page if the user has the correct role
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var userId = HttpContext.Session.GetString("UserId");

                string response = await _promotionService.AddPromotionAsync(NewPromotion, userId);

                if (response == "Promotion successfully added")
                {
                    ResponseMessage = response;
                    return RedirectToPage("/Promotion/Index");
                }

                TempData["ErrorMessage"] = response;
            }
            return Page();
        }
    }
}
