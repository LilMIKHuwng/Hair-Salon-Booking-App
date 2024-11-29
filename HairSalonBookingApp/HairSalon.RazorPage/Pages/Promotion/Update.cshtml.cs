using DocumentFormat.OpenXml.Office2010.Excel;
using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.PromotionModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace HairSalon.RazorPage.Pages.Promotion
{
    public class UpdateModel : PageModel
    {
        private readonly IPromotionService _promotionService;

        public UpdateModel(IPromotionService promotionService)
        {
            _promotionService = promotionService;
        }

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }

        [BindProperty]
        public PromotionModelView Promotion { get; set; }

        [BindProperty]
        public UpdatePromotionModelView UpdatedPromotion { get; set; }

        [TempData]
        public string ResponseMessage { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            // Get roleId from TempData
            if (TempData.ContainsKey("PromotionId"))
            {
                Id = TempData["PromotionId"].ToString();
            }

            if (string.IsNullOrEmpty(Id))
            {
                TempData["ErrorMessage"] = "Invalid Promotion ID.";
                return RedirectToPage("/Error");
            }

            var userRolesJson = HttpContext.Session.GetString("UserRoles");
            if (userRolesJson == null)
            {
                TempData["DeniedMessage"] = "You do not have permission to update a service.";
                return RedirectToPage("/Error");// Redirect to a different page with a denied message
            }

            var userRoles = JsonConvert.DeserializeObject<List<string>>(userRolesJson);

            if (!userRoles.Any(role => role == "Admin" || role == "Manager"))
            {
                TempData["DeniedMessage"] = "You do not have permission to update a service.";
                return Page(); // Redirect to a different page with a denied message
            }

            Promotion = await _promotionService.GetPromotionByIdAsync(Id);
            if (Promotion == null)
            {
                TempData["ErrorMessage"] = "Promotion not found.";
                return RedirectToPage("/Promotion/Index");
            }

            // Initialize UpdatedService with existing service name for display in the form
            UpdatedPromotion = new UpdatePromotionModelView
            {
                Name = Promotion.Name,
                DiscountPercentage = Promotion.DiscountPercentage,
                TotalAmount = Promotion.TotalAmount,
                MaxAmount = Promotion.MaxAmount,
                Quantity = Promotion.Quantity,
                ExpiryDate = Promotion.ExpiryDate,
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var userId = HttpContext.Session.GetString("UserId");

            var response = await _promotionService.UpdatePromotionAsync(Id, UpdatedPromotion, userId);
            if (response == "Promotion successfully updated")
            {
                ResponseMessage = response;
                return RedirectToPage("/Promotion/Index");
            }

            TempData["ErrorMessage"] = response;
            return Page();
        }
    }
}
