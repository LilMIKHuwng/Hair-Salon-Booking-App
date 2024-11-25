using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.PromotionModelViews;
using HairSalon.Core;
using Newtonsoft.Json;

namespace HairSalon.RazorPage.Pages.Promotion
{
    public class PromotionModel : PageModel
    {
        private readonly IPromotionService _promotionService;

        public PromotionModel(IPromotionService promotionService)
        {
            _promotionService = promotionService;
        }

        public BasePaginatedList<PromotionModelView> Promotions { get; set; }


        public async Task<IActionResult> OnGetAsync(int pageNumber = 1, int pageSize = 5, string? promotionId = null, string? name = null, string? code = null)
        {
            var userRolesJson = HttpContext.Session.GetString("UserRoles");

            if (userRolesJson != null)
            {
                var userRoles = JsonConvert.DeserializeObject<List<string>>(userRolesJson);

                // Check if the user has "Admin" or "Manager" roles
                if (!userRoles.Any(role => role == "Admin"))
                {
                    TempData["ErrorMessage"] = "You do not have permission to view this page.";
                    return Page(); // Show error message on the same page
                }
            }
            else
            {
                TempData["ErrorMessage"] = "You do not have permission to view this page.";
                return RedirectToPage("/Error");
            }

            // If authorized, retrieve roles data
            Promotions = await _promotionService.GetAllPromotionsAsync(pageNumber, pageSize, name, code);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id, string action)
        {
            if (string.IsNullOrEmpty(id))
            {
                TempData["ErrorMessage"] = "Promotion ID is required.";
                return RedirectToPage();
            }

            //Save roleId to tempdata
            TempData["PromotionId"] = id;

            switch (action?.ToLower())
            {
                case "update":
                    return RedirectToPage("/Promotion/Update");
                case "detail":
                    return RedirectToPage("/Promotion/Detail");
                case "delete":
                    return RedirectToPage("/Promotion/Delete");
                default:
                    TempData["ErrorMessage"] = "Invalid action.";
                    return RedirectToPage();
            }
        }
    }
}